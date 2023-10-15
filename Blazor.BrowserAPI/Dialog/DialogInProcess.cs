using AutoInterfaceAttributes;
using Microsoft.JSInterop;

namespace BrowserAPI;

[AutoInterface(Modifier = "public partial", Inheritance = new[] { typeof(IDisposable) })]
internal sealed class DialogInProcess : DialogBase, IDialogInProcess {
    private readonly IJSInProcessObjectReference _dialogJS;
    protected override IJSObjectReference DialogJS => _dialogJS;

    public DialogInProcess(IJSInProcessObjectReference dialogJS) {
        _dialogJS = dialogJS;
    }

    public void Dispose() => _dialogJS.Dispose();


    /// <summary>
    /// The <i>open</i> property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.
    /// </summary>
    public bool Open {
        get => _dialogJS.Invoke<bool>("getOpen");
        set => _dialogJS.InvokeVoid("setOpen", value);
    }

    /// <summary>
    /// The <i>returnValue</i> property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.
    /// </summary>
    public string ReturnValue {
        get => _dialogJS.Invoke<string>("getReturnValue");
        set => _dialogJS.InvokeVoid("setReturnValue", value);
    }


    /// <summary>
    /// The <i>show()</i> method of the HTMLDialogElement interface displays the dialog modelessly, i.e. still allowing interaction with content outside of the dialog.
    /// </summary>
    public void Show() => _dialogJS.InvokeVoid("show");
    
    /// <summary>
    /// The <i>showModal()</i> method of the HTMLDialogElement interface displays the dialog as a modal, over the top of any other dialogs that might be present. It displays in the top layer, along with a ::backdrop pseudo-element. Interaction outside the dialog is blocked and the content outside it is rendered inert.
    /// </summary>
    public void ShowModal() => _dialogJS.InvokeVoid("showModal");


    /// <summary>
    /// The <i>close()</i> method of the HTMLDialogElement interface closes the &lt;dialog&gt;.
    /// </summary>
    public void Close() => _dialogJS.InvokeVoid("close");

    /// <summary>
    /// The <i>close()</i> method of the HTMLDialogElement interface closes the &lt;dialog&gt; and updates the returnValue of the dialog.
    /// </summary>
    public void Close(string returnValue) => _dialogJS.InvokeVoid("close", returnValue);
}
