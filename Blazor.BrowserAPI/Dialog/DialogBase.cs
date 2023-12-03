using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

[AutoInterface(Name = "IDialog", Modifier = "public partial")]
[AutoInterface(Name = "IDialogInProcess", Modifier = "public partial")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
internal abstract class DialogBase {
    protected abstract Task<IJSObjectReference> DialogTask { get; }


    #region Cancel event

    private DotNetObjectReference<CancelTrigger>? objectReferenceCancelTrigger;

    private Action? _onCancel;
    /// <summary>
    /// The <i>cancel</i> event fires on a &lt;dialog&gt; when the user instructs the browser that they wish to dismiss the current open dialog. The browser fires this event when the user presses the Esc key.
    /// </summary>
    public event Action OnCancel {
        add {
            if (objectReferenceCancelTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceCancelTrigger = DotNetObjectReference.Create(new CancelTrigger(this));
                    await (await DialogTask).InvokeVoidTrySync("activateOncancel", default, [objectReferenceCancelTrigger]);
                });

            _onCancel += value;
        }
        remove {
            _onCancel -= value;

            if (_onCancel == null && objectReferenceCancelTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await DialogTask).InvokeVoidTrySync("deactivateOncancel", default);
                    objectReferenceCancelTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class CancelTrigger(DialogBase dialog) {
        [JSInvokable]
        public void Trigger() => dialog._onCancel?.Invoke();
    }

    #endregion


    #region Close event

    private DotNetObjectReference<CloseTrigger>? objectReferenceCloseTrigger;

    private Action? _onClose;
    /// <summary>
    /// The <i>close</i> event is fired on an HTMLDialogElement object when the &lt;dialog&gt; it represents has been closed.
    /// </summary>
    public event Action OnClose {
        add {
            if (objectReferenceCloseTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceCloseTrigger = DotNetObjectReference.Create(new CloseTrigger(this));
                    await (await DialogTask).InvokeVoidTrySync("activateOnclose", default, [objectReferenceCloseTrigger]);
                });

            _onClose += value;
        }
        remove {
            _onClose -= value;

            if (_onClose == null && objectReferenceCloseTrigger != null) {
                Task.Factory.StartNew(async () => {
                    await (await DialogTask).InvokeVoidTrySync("deactivateOnclose", default);
                    objectReferenceCloseTrigger.Dispose();
                });
            }
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class CloseTrigger(DialogBase dialog) {
        [JSInvokable]
        public void Trigger() => dialog._onClose?.Invoke();
    }

    #endregion
}
