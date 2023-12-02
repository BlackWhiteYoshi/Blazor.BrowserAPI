using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

/// <summary>
/// The <i>HTMLDialogElement</i> interface provides methods to manipulate &lt;dialog&gt; elements. It inherits properties and methods from the HTMLElement interface.
/// </summary>
[AutoInterface(Name = "IDialog", Modifier = "public partial")]
[AutoInterface(Name = "IDialogInProcess", Modifier = "public partial")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
internal abstract class DialogBase {
    protected abstract Task<IJSObjectReference> DialogTask { get; }


    #region Cancel event

    private Action? _onCancel;
    /// <summary>
    /// The <i>cancel</i> event fires on a &lt;dialog&gt; when the user instructs the browser that they wish to dismiss the current open dialog. The browser fires this event when the user presses the Esc key.
    /// </summary>
    public event Action OnCancel {
        add {
            if (_onCancel == null)
                Task.Factory.StartNew(async () => await (await DialogTask).InvokeVoidTrySync("activateOncancel", default, [DotNetObjectReference.Create(new CancelTrigger(this))]));

            _onCancel += value;
        }
        remove {
            _onCancel -= value;

            if (_onCancel == null)
                Task.Factory.StartNew(async () => await (await DialogTask).InvokeVoidTrySync("deactivateOncancel", default));
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class CancelTrigger(DialogBase dialogBase) {
        [JSInvokable]
        public void Trigger() => dialogBase._onCancel?.Invoke();
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
                Task.Factory.StartNew(async () => await (await DialogTask).InvokeVoidTrySync("activateOnclose", default, [DotNetObjectReference.Create(new CloseTrigger(this))]));

            _onClose += value;
        }
        remove {
            _onClose -= value;

            if (_onClose == null)
                Task.Factory.StartNew(async () => await (await DialogTask).InvokeVoidTrySync("deactivateOnclose", default));
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class CloseTrigger(DialogBase dialogBase) {
        [JSInvokable]
        public void Trigger() => dialogBase._onClose?.Invoke();
    }

    #endregion
}
