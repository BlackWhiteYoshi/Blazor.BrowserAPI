using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

[AutoInterface(Modifier = "public partial", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
internal sealed class DialogInProcess(IJSInProcessObjectReference dialogJS) : DialogBase, IDialogInProcess {
    protected override Task<IJSObjectReference> DialogTask { get; } = Task.FromResult<IJSObjectReference>(dialogJS);

    [IgnoreAutoInterface]
    public void Dispose() => dialogJS.Dispose();


    /// <summary>
    /// The <i>open</i> property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.
    /// </summary>
    public bool Open {
        get => dialogJS.Invoke<bool>("getOpen");
        set => dialogJS.InvokeVoid("setOpen", [value]);
    }

    /// <summary>
    /// The <i>returnValue</i> property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.
    /// </summary>
    public string ReturnValue {
        get => dialogJS.Invoke<string>("getReturnValue");
        set => dialogJS.InvokeVoid("setReturnValue", [value]);
    }


    /// <summary>
    /// The <i>show()</i> method of the HTMLDialogElement interface displays the dialog modelessly, i.e. still allowing interaction with content outside of the dialog.
    /// </summary>
    public void Show() => dialogJS.InvokeVoid("show");

    /// <summary>
    /// The <i>showModal()</i> method of the HTMLDialogElement interface displays the dialog as a modal, over the top of any other dialogs that might be present. It displays in the top layer, along with a ::backdrop pseudo-element. Interaction outside the dialog is blocked and the content outside it is rendered inert.
    /// </summary>
    public void ShowModal() => dialogJS.InvokeVoid("showModal");


    /// <summary>
    /// The <i>close()</i> method of the HTMLDialogElement interface closes the &lt;dialog&gt;.
    /// </summary>
    public void Close() => dialogJS.InvokeVoid("close");

    /// <summary>
    /// The <i>close()</i> method of the HTMLDialogElement interface closes the &lt;dialog&gt; and updates the returnValue of the dialog.
    /// </summary>
    /// <param name="returnValue">A string representing an updated value for the <see cref="ReturnValue"/> of the dialog.</param>
    public void Close(string returnValue) => dialogJS.InvokeVoid("close", [returnValue]);
}
