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
    public void Dispose() => DisposeEventTrigger();


    #region Events

    [method: DynamicDependency(nameof(InvokePopState))]
    private sealed class EventTrigger(HistoryBase historyBase) {
        [JSInvokable] public void InvokePopState(object? state) => historyBase._onPopState?.Invoke((JsonElement?)state);
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return moduleManager.InvokeTrySync("HistoryAPI.initEvents", default, [_objectReferenceEventTrigger, moduleManager.IsInProcess]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await moduleManager.InvokeTrySync(jsMethodName, default);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => moduleManager.InvokeTrySync(jsMethodName, default);


    private Action<JsonElement?>? _onPopState;
    /// <summary>
    /// <para>
    /// The popstate event of the Window interface is fired when the active history entry changes while the user navigates the session history.
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

    #endregion
}
