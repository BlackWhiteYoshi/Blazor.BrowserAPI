using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IPictureInPictureWindow")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IPictureInPictureWindowInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class PictureInPictureWindowBase(IJSObjectReference pictureInPictureWindowJS) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IJSObjectReference pictureInPictureWindowJS = pictureInPictureWindowJS;


    #region Events

    [method: DynamicDependency(nameof(InvokeResize))]
    private sealed class EventTrigger(PictureInPictureWindowBase pictureInPictureWindow) {
        [JSInvokable] public void InvokeResize() => pictureInPictureWindow._onResize?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return pictureInPictureWindowJS.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await pictureInPictureWindowJS.InvokeVoidTrySync(jsMethodName);
    }

    private async ValueTask DeactivateJSEvent(string jsMethodName) {
        await pictureInPictureWindowJS.InvokeVoidTrySync(jsMethodName);
    }


    private Action? _onResize;
    /// <summary>
    /// <para>Fires when the floating video window has been resized.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnResize {
        add {
            if (_onResize == null)
                _ = ActivateJSEvent("activateOnresize").Preserve();
            _onResize += value;
        }
        remove {
            _onResize -= value;
            if (_onResize == null)
                _ = DeactivateJSEvent("deactivateOnresize").Preserve();
        }
    }

    #endregion
}
