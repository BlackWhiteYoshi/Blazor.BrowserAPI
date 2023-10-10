using AutoInterfaceAttributes;
using Microsoft.JSInterop;

namespace BrowserAPI;

/// <summary>
/// The <i>HTMLDialogElement</i> interface provides methods to manipulate &lt;dialog&gt; elements. It inherits properties and methods from the HTMLElement interface.
/// </summary>
[AutoInterface(Modifier = "public partial", Inheritance = new[] { typeof(IAsyncDisposable) })]
internal sealed class Dialog : DialogBase, IDialog {
    protected override IJSObjectReference DialogJS { get; }

    public Dialog(IJSObjectReference dialogJS) {
        DialogJS = dialogJS;
    }

    public ValueTask DisposeAsync() => DialogJS.DisposeAsync();


    /// <summary>
    /// The <i>open</i> property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction. 
    /// </summary>
    public ValueTask<bool> Open => GetOpen(default);

    /// <summary>
    /// The <i>open</i> property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction. 
    /// </summary>
    public ValueTask<bool> GetOpen(CancellationToken cancellationToken) => DialogJS.InvokeTrySync<bool>("getOpen", cancellationToken);

    /// <summary>
    /// The <i>open</i> property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction. 
    /// </summary>
    public ValueTask SetOpen(bool value, CancellationToken cancellationToken = default) => DialogJS.InvokeVoidTrySync("setOpen", cancellationToken, value);


    /// <summary>
    /// The <i>returnValue</i> property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.
    /// </summary>
    public ValueTask<string> ReturnValue => GetReturnValue(default);

    /// <summary>
    /// The <i>returnValue</i> property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.
    /// </summary>
    public ValueTask<string> GetReturnValue(CancellationToken cancellationToken) => DialogJS.InvokeTrySync<string>("getReturnValue", cancellationToken);

    /// <summary>
    /// The <i>returnValue</i> property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.
    /// </summary>
    public ValueTask SetReturnValue(string returnValue, CancellationToken cancellationToken = default) => DialogJS.InvokeVoidTrySync("setReturnValue", cancellationToken, returnValue);


    /// <summary>
    /// The <i>show()</i> method of the HTMLDialogElement interface displays the dialog modelessly, i.e. still allowing interaction with content outside of the dialog. 
    /// </summary>
    public ValueTask Show(CancellationToken cancellationToken = default) => DialogJS.InvokeVoidTrySync("show", cancellationToken);

    /// <summary>
    /// The <i>showModal()</i> method of the HTMLDialogElement interface displays the dialog as a modal, over the top of any other dialogs that might be present. It displays in the top layer, along with a ::backdrop pseudo-element. Interaction outside the dialog is blocked and the content outside it is rendered inert. 
    /// </summary>
    public ValueTask ShowModal(CancellationToken cancellationToken = default) => DialogJS.InvokeVoidTrySync("showModal", cancellationToken);


    /// <summary>
    /// The <i>close()</i> method of the HTMLDialogElement interface closes the &lt;dialog&gt;. An optional string may be passed as an argument, updating the returnValue of the dialog. 
    /// </summary>
    public ValueTask Close(CancellationToken cancellationToken = default) => DialogJS.InvokeVoidTrySync("close", cancellationToken);

    /// <summary>
    /// The <i>close()</i> method of the HTMLDialogElement interface closes the &lt;dialog&gt;. An optional string may be passed as an argument, updating the returnValue of the dialog. 
    /// </summary>
    public ValueTask Close(string returnValue, CancellationToken cancellationToken = default) => DialogJS.InvokeVoidTrySync("close", cancellationToken, returnValue);
}
