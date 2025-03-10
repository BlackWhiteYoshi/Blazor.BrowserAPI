using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IDialog")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IDialogInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class DialogBase {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected abstract Task<IJSObjectReference> DialogTask { get; }


    #region Events

    [method: DynamicDependency(nameof(InvokeCancel))]
    [method: DynamicDependency(nameof(InvokeClose))]
    private sealed class EventTrigger(DialogBase dialog) {
        [JSInvokable] public void InvokeCancel() => dialog._onCancel?.Invoke();
        [JSInvokable] public void InvokeClose() => dialog._onClose?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger(IJSObjectReference dialog) {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return dialog.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger, dialog is IJSInProcessObjectReference]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        IJSObjectReference dialog = await DialogTask;
        await InitEventTrigger(dialog);
        await dialog.InvokeVoidTrySync(jsMethodName);
    }

    private async ValueTask DeactivateJSEvent(string jsMethodName) {
        IJSObjectReference dialog = await DialogTask;
        await dialog.InvokeVoidTrySync(jsMethodName);
    }


    private Action? _onCancel;
    /// <summary>
    /// The <i>cancel</i> event fires on a &lt;dialog&gt; when the user instructs the browser that they wish to dismiss the current open dialog. The browser fires this event when the user presses the Esc key.
    /// </summary>
    public event Action OnCancel {
        add {
            if (_onCancel == null)
                _ = ActivateJSEvent("activateOncancel").Preserve();
            _onCancel += value;
        }
        remove {
            _onCancel -= value;
            if (_onCancel == null)
                _ = DeactivateJSEvent("deactivateOncancel").Preserve();
        }
    }

    private Action? _onClose;
    /// <summary>
    /// The <i>close</i> event is fired on an HTMLDialogElement object when the &lt;dialog&gt; it represents has been closed.
    /// </summary>
    public event Action OnClose {
        add {
            if (_onClose == null)
                _ = ActivateJSEvent("activateOnclose").Preserve();
            _onClose += value;
        }
        remove {
            _onClose -= value;
            if (_onClose == null)
                _ = DeactivateJSEvent("deactivateOnclose").Preserve();
        }
    }

    #endregion
}
