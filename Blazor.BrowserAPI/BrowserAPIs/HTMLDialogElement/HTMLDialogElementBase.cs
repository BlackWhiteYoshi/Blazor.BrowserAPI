using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// Base interface of <see cref="IHTMLDialogElement"/> and <see cref="IHTMLDialogElementInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class HTMLDialogElementBase<TJSObjectReference>(Task<TJSObjectReference> dialogTask) where TJSObjectReference : IJSObjectReference {
    private protected Task<TJSObjectReference> dialogTask = dialogTask;


    #region Events

    [method: DynamicDependency(nameof(InvokeClose))]
    [method: DynamicDependency(nameof(InvokeCancel))]
    private sealed class EventTrigger(HTMLDialogElementBase<TJSObjectReference> dialog) {
        [JSInvokable] public void InvokeClose() => dialog._onClose?.Invoke();
        [JSInvokable] public void InvokeCancel() => dialog._onCancel?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger(TJSObjectReference dialog) {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return dialog.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        TJSObjectReference dialog = await dialogTask;
        await InitEventTrigger(dialog);
        await dialog.InvokeVoidTrySync(jsMethodName);
    }

    private async ValueTask DeactivateJSEvent(string jsMethodName) {
        TJSObjectReference dialog = await dialogTask;
        await dialog.InvokeVoidTrySync(jsMethodName);
    }


    // Events

    private Action? _onClose;
    /// <summary>
    /// Is fired on an HTMLDialogElement object when the &lt;dialog&gt; it represents has been closed.
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

    private Action? _onCancel;
    /// <summary>
    /// Fires on a &lt;dialog&gt; when the user instructs the browser that they wish to dismiss the current open dialog. The browser fires this event when the user presses the Esc key.
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

    #endregion
}
