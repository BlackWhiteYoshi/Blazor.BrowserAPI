using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IHistory")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IHistoryInProcess")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class HistoryBase(IModuleManager moduleManager) : IDisposable {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IModuleManager moduleManager = moduleManager;

    /// <summary>
    /// Releases the <see cref="EventTrigger"/> object used to trigger the events.
    /// </summary>
    public void Dispose() => _objectReferenceEventTrigger?.Dispose();

    #region Events

    [method: DynamicDependency(nameof(InvokePageReveal))]
    [method: DynamicDependency(nameof(InvokePageSwap))]
    [method: DynamicDependency(nameof(InvokePageShow))]
    [method: DynamicDependency(nameof(InvokePageHide))]
    [method: DynamicDependency(nameof(InvokePopState))]
    [method: DynamicDependency(nameof(InvokeHashChange))]
    private sealed class EventTrigger(HistoryBase historyBase) {
        [JSInvokable] public void InvokePageReveal() => historyBase._onPageReveal?.Invoke();
        [JSInvokable] public void InvokePageSwap() => historyBase._onPageSwap?.Invoke();
        [JSInvokable] public void InvokePageShow(bool persisted) => historyBase._onPageShow?.Invoke(persisted);
        [JSInvokable] public void InvokePageHide(bool persisted) => historyBase._onPageHide?.Invoke(persisted);
        [JSInvokable] public void InvokePopState(object? state) => historyBase._onPopState?.Invoke((JsonElement?)state);
        [JSInvokable] public void InvokeHashChange(string newURL, string oldURL) => historyBase._onHashChange?.Invoke(newURL, oldURL);
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return moduleManager.InvokeTrySync("HistoryAPI.initEvents", default, [_objectReferenceEventTrigger]);
    }


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await moduleManager.InvokeTrySync(jsMethodName, default);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => moduleManager.InvokeTrySync(jsMethodName, default);


    private Action? _onPageReveal;
    /// <summary>
    /// <para>Is fired when a document is first rendered, either when loading a fresh document from the network or activating a document (either from back/forward cache (bfcache) or prerender).</para>
    /// <para>
    /// This is useful in the case of cross-document (MPA) view transitions for manipulating an active transition from the inbound page of a navigation.
    /// For example, you might wish to skip the transition, or customize the inbound transition animation via JavaScript.
    /// </para>
    /// </summary>
    public event Action OnPageReveal {
        add {
            if (_onPageReveal == null)
                _ = ActivateJSEvent("HistoryAPI.activateOnpagereveal").Preserve();
            _onPageReveal += value;
        }
        remove {
            _onPageReveal -= value;
            if (_onPageReveal == null)
                _ = DeactivateJSEvent("HistoryAPI.deactivateOnpagereveal").Preserve();
        }
    }

    private Action? _onPageSwap;
    /// <summary>
    /// <para>Is fired when you navigate across documents, when the previous document is about to unload.</para>
    /// <para>
    /// This is useful in the case of cross-document (MPA) view transitions for manipulating an active transition from the outbound page of a navigation.
    /// For example, you might wish to skip the transition, or customize the outbound transition animation via JavaScript.
    /// </para>
    /// <para>It also provides access to the navigation type and current and destination document history entries.</para>
    /// </summary>
    public event Action OnPageSwap {
        add {
            if (_onPageSwap == null)
                _ = ActivateJSEvent("HistoryAPI.activateOnpageswap").Preserve();
            _onPageSwap += value;
        }
        remove {
            _onPageSwap -= value;
            if (_onPageSwap == null)
                _ = DeactivateJSEvent("HistoryAPI.deactivateOnpageswap").Preserve();
        }
    }

    private Action<bool>? _onPageShow;
    /// <summary>
    /// <para>Is fired when the browser displays the window's document due to navigation.</para>
    /// <para>
    /// This includes:<br />
    /// - Initially loading the page<br />
    /// - Navigating to the page from another page in the same window or tab<br />
    /// - Restoring a frozen page on mobile OSes <br />
    /// - Returning to the page using the browser's forward or back buttons
    /// </para>
    /// <para>Parameter is the <i>persisted</i> property that indicates if a webpage is loading from a cache.</para>
    /// </summary>
    /// <remarks>Note: During the initial page load, the pageshow event fires after the <see cref="IWindow.OnLoad"/> event.</remarks>
    public event Action<bool> OnPageShow {
        add {
            if (_onPageShow == null)
                _ = ActivateJSEvent("HistoryAPI.activateOnpageshow").Preserve();
            _onPageShow += value;
        }
        remove {
            _onPageShow -= value;
            if (_onPageShow == null)
                _ = DeactivateJSEvent("HistoryAPI.deactivateOnpageshow").Preserve();
        }
    }

    private Action<bool>? _onPageHide;
    /// <summary>
    /// <para>Is fired when the browser hides the current page in the process of presenting a different page from the session's history.</para>
    /// <para>For example, when the user clicks the browser's Back button, the current page receives a pagehide event before the previous page is shown.</para>
    /// <para>Parameter is the <i>persisted</i> property that indicates if a webpage is loading from a cache.</para>
    /// </summary>
    public event Action<bool> OnPageHide {
        add {
            if (_onPageHide == null)
                _ = ActivateJSEvent("HistoryAPI.activateOnpagehide").Preserve();
            _onPageHide += value;
        }
        remove {
            _onPageHide -= value;
            if (_onPageHide == null)
                _ = DeactivateJSEvent("HistoryAPI.deactivateOnpagehide").Preserve();
        }
    }

    private Action<JsonElement?>? _onPopState;
    /// <summary>
    /// <para>
    /// Is fired when the active history entry changes while the user navigates the session history.
    /// It changes the current history entry to that of the last page the user visited or,
    /// if <i>history.pushState()</i> has been used to add a history entry to the history stack, that history entry is used instead.
    /// </para>
    /// <para>Parameter is the <see href="https://developer.mozilla.org/en-US/docs/Web/API/History/state">state</see> value as JSON.</para>
    /// </summary>
    public event Action<JsonElement?> OnPopState {
        add {
            if (_onPopState == null)
                _ = ActivateJSEvent("HistoryAPI.activateOnpopstate").Preserve();
            _onPopState += value;
        }
        remove {
            _onPopState -= value;
            if (_onPopState == null)
                _ = DeactivateJSEvent("HistoryAPI.deactivateOnpopstate").Preserve();
        }
    }

    private Action<string, string>? _onHashChange;
    /// <summary>
    /// <para>Is fired when the fragment identifier of the URL has changed (the part of the URL beginning with and following the # symbol).</para>
    /// <para>This event does not fire when the hash is modified using <see cref="IHistory.PushState"/> or <see cref="IHistory.ReplaceState"/>.</para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string <i>newURL</i>: Returns the new URL to which the window is navigating.<br />
    /// - string <i>oldURL</i>: Returns the previous URL from which the window was navigated.
    /// </para>
    /// </summary>
    public event Action<string, string> OnHashChange {
        add {
            if (_onHashChange == null)
                _ = ActivateJSEvent("HistoryAPI.activateOnhashchange").Preserve();
            _onHashChange += value;
        }
        remove {
            _onHashChange -= value;
            if (_onHashChange == null)
                _ = DeactivateJSEvent("HistoryAPI.deactivateOnhashchange").Preserve();
        }
    }

    #endregion
}
