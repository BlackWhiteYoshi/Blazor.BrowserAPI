using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

/// <summary>
/// The <i>HTMLDialogElement</i> interface provides methods to manipulate &lt;dialog&gt; elements. It inherits properties and methods from the HTMLElement interface.
/// </summary>
[AutoInterface(Name = "IDialog", Modifier = "public partial")]
[AutoInterface(Name = "IDialogInProcess", Modifier = "public partial")]
internal abstract class DialogBase {
    protected abstract IJSObjectReference DialogJS { get; }


    #region Cancel event

    private Action? _onCancel;
    /// <summary>
    /// The <i>cancel</i> event fires on a &lt;dialog&gt; when the user instructs the browser that they wish to dismiss the current open dialog. The browser fires this event when the user presses the Esc key.
    /// </summary>
    public event Action OnCancel {
        add {
            if (_onCancel == null)
                _ = DialogJS.InvokeVoidTrySync("activateOncancel", default, DotNetObjectReference.Create(new CancelTrigger(this))).Preserve();

            _onCancel += value;
        }
        remove {
            _onCancel -= value;

            if (_onCancel == null)
                _ = DialogJS.InvokeVoidTrySync("deactivateOncancel", default).Preserve();
        }
    }

    private sealed class CancelTrigger {
        private readonly DialogBase _dialogBase;

        [DynamicDependency(nameof(Trigger))]
        public CancelTrigger(DialogBase dialogBase) {
            _dialogBase = dialogBase;
        }

        [JSInvokable]
        public void Trigger() => _dialogBase._onCancel?.Invoke();
    }

    #endregion


    #region Close event

    private Action? _onClose;
    /// <summary>
    /// The <i>close</i> event is fired on an HTMLDialogElement object when the &lt;dialog&gt; it represents has been closed.
    /// </summary>
    public event Action OnClose {
        add {
            if (_onClose == null)
                _ = DialogJS.InvokeVoidTrySync("activateOnclose", default, DotNetObjectReference.Create(new CloseTrigger(this))).Preserve();

            _onClose += value;
        }
        remove {
            _onClose -= value;

            if (_onClose == null)
                _ = DialogJS.InvokeVoidTrySync("deactivateOnclose", default).Preserve();
        }
    }

    private sealed class CloseTrigger {
        private readonly DialogBase _dialogBase;

        [DynamicDependency(nameof(Trigger))]
        public CloseTrigger(DialogBase dialogBase) {
            _dialogBase = dialogBase;
        }

        [JSInvokable]
        public void Trigger() => _dialogBase._onClose?.Invoke();
    }

    #endregion
}
