using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IScreenDetails")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IScreenDetailsInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class ScreenDetailsBase(IJSObjectReference screenDetailsJS) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IJSObjectReference screenDetailsJS = screenDetailsJS;


    #region Events

    [method: DynamicDependency(nameof(InvokeCurrentScreenChange))]
    [method: DynamicDependency(nameof(InvokeScreensChange))]
    private sealed class EventTrigger(ScreenDetailsBase screenDetails) {
        [JSInvokable] public void InvokeCurrentScreenChange() => screenDetails._onCurrentScreenChange?.Invoke();
        [JSInvokable] public void InvokeScreensChange() => screenDetails._onScreensChange?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return screenDetailsJS.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await screenDetailsJS.InvokeVoidTrySync(jsMethodName);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => screenDetailsJS.InvokeVoidTrySync(jsMethodName);


    private Action? _onCurrentScreenChange;
    /// <summary>
    /// Is fired when the ScreenDetails.currentScreen changes in one of the following ways:<br />
    /// - The current screen changes to a different screen, i.e., the current browser window is moved to a different screen.<br />
    /// - One or more of the following properties change on the current screen: width, height, availWidth, availHeight, colorDepth, orientation<br />
    /// - One or more properties of <see href="https://developer.mozilla.org/en-US/docs/Web/API/ScreenDetailed">ScreenDetailed</see> changes.
    /// </summary>
    public event Action OnCurrentScreenChange {
        add {
            if (_onCurrentScreenChange == null)
                _ = ActivateJSEvent("activateOncurrentscreenchange").Preserve();
            _onCurrentScreenChange += value;
        }
        remove {
            _onCurrentScreenChange -= value;
            if (_onCurrentScreenChange == null)
                _ = DeactivateJSEvent("deactivateOncurrentscreenchange").Preserve();
        }
    }

    private Action? _onScreensChange;
    /// <summary>
    /// Is fired when the set of screens available to the system has changed: that is, a new screen has become available or an existing screen has become unavailable.
    /// This will be reflected in a change in the screens array.
    /// </summary>
    public event Action OnScreensChange {
        add {
            if (_onScreensChange == null)
                _ = ActivateJSEvent("activateOnscreenschange").Preserve();
            _onScreensChange += value;
        }
        remove {
            _onScreensChange -= value;
            if (_onScreensChange == null)
                _ = DeactivateJSEvent("deactivateOnscreenschange").Preserve();
        }
    }

    #endregion
}
