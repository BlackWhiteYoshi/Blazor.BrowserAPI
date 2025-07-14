using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IScreenDetailed")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IScreenDetailedInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class ScreenDetailedBase(IJSObjectReference screenDetailedJS) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IJSObjectReference screenDetailedJS = screenDetailedJS;


    /// <summary>
    /// <para>Locks the orientation of the containing document to the specified orientation.</para>
    /// <para>
    /// Typically orientation locking is only enabled on mobile devices, and when the browser context is full screen. If locking is supported, then it must work for all the parameter values listed as follows:<br />
    /// - "any"<br />
    /// - "natural"<br />
    /// - "landscape"<br />
    /// - "landscape-primary"<br />
    /// - "landscape-secondary"<br />
    /// - "portrait"<br />
    /// - "portrait-primary"<br />
    /// - "portrait-secondary"
    /// </para>
    /// </summary>
    /// <param name="orientation">
    /// An orientation lock type. One of the following:<br />
    /// - "any": Any of "portrait-primary", "portrait-secondary", "landscape-primary" or "landscape-secondary".<br />
    /// - "natural": The natural orientation of the screen from the underlying operating system: either "portrait-primary" or "landscape-primary".<br />
    /// - "landscape": An orientation where screen width is greater than the screen height. Depending on the platform convention, this may be "landscape-primary", "landscape-secondary", or both.<br />
    /// - "landscape-primary": The "primary" landscape mode. If the natural orientation is a landscape mode (screen width is greater than height), this will be the same as the natural orientation, and correspond to an angle of 0 degrees. If the natural orientation is a portrait mode, then the user agent can choose either landscape orientation as the "landscape-primary" with an angle of either 90 or 270 degrees ("landscape-secondary" will be the other orientation and angle).<br />
    /// - "landscape-secondary": The secondary landscape mode. If the natural orientation is a landscape mode, this orientation is upside down relative to the natural orientation, and will have an angle of 180 degrees. If the natural orientation is a portrait mode, this can be either orientation as selected by the user agent: whichever was not selected for "landscape-primary".<br />
    /// - "portrait": An orientation where screen height is greater than the screen width. Depending on the platform convention, this may be "portrait-primary", "portrait-secondary", or both.<br />
    /// - "portrait-primary": The "primary" portrait mode. If the natural orientation is a portrait mode (screen height is greater than width), this will be the same as the natural orientation, and correspond to an angle of 0 degrees. If the natural orientation is a landscape mode, then the user agent can choose either portrait orientation as the "portrait-primary" and "portrait-secondary"; one of those will be assigned the angle of 90 degrees and the other will have an angle of 270 degrees.<br />
    /// - "portrait-secondary": The secondary portrait orientation. If the natural orientation is a portrait mode, this will have an angle of 180 degrees (in other words, the device is upside down relative to its natural orientation). If the natural orientation is a landscape mode, this can be either orientation as selected by the user agent: whichever was not selected for "portrait-primary".<br />
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask LockOrientation(string orientation, CancellationToken cancellationToken = default) => screenDetailedJS.InvokeVoidAsync("lockOrientation", cancellationToken, [orientation]);


    #region Events

    [method: DynamicDependency(nameof(InvokeChange))]
    [method: DynamicDependency(nameof(InvokeOrientationChange))]
    private sealed class EventTrigger(ScreenDetailedBase screenDetailed) {
        [JSInvokable] public void InvokeChange() => screenDetailed._onChange?.Invoke();
        [JSInvokable] public void InvokeOrientationChange() => screenDetailed._onOrientationChange?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return screenDetailedJS.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger, screenDetailedJS is IJSInProcessObjectReference]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await screenDetailedJS.InvokeVoidTrySync(jsMethodName);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => screenDetailedJS.InvokeVoidTrySync(jsMethodName);


    private Action? _onChange;
    /// <summary>
    /// Fired on a specific screen when one or more of the following properties change on it:<br />
    /// - width<br />
    /// - height<br />
    /// - availWidth<br />
    /// - availHeight<br />
    /// - colorDepth<br />
    /// - orientation
    /// </summary>
    public event Action OnChange {
        add {
            if (_onChange == null)
                _ = ActivateJSEvent("activateOnchange").Preserve();
            _onChange += value;
        }
        remove {
            _onChange -= value;
            if (_onChange == null)
                _ = DeactivateJSEvent("deactivateOnchange").Preserve();
        }
    }

    private Action? _onOrientationChange;
    /// <summary>
    /// Fired whenever the screen changes orientation, for example when a user rotates their mobile phone.
    /// </summary>
    public event Action OnOrientationChange {
        add {
            if (_onOrientationChange == null)
                _ = ActivateJSEvent("activateOnorientationchange").Preserve();
            _onOrientationChange += value;
        }
        remove {
            _onOrientationChange -= value;
            if (_onOrientationChange == null)
                _ = DeactivateJSEvent("deactivateOnorientationchange").Preserve();
        }
    }

    #endregion
}
