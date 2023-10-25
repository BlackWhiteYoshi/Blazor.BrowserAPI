using AutoInterfaceAttributes;
using Microsoft.JSInterop;

namespace BrowserAPI;

[AutoInterface(Modifier = "public partial", Inheritance = new[] { typeof(IAsyncDisposable) })]
internal sealed class Dialog : DialogBase, IDialog {
    protected override Task<IJSObjectReference> DialogJS { get; }

    public Dialog(Task<IJSObjectReference> dialogJS) {
        DialogJS = dialogJS;
    }

    [IgnoreAutoInterface]
    public async ValueTask DisposeAsync() => await (await DialogJS).DisposeAsync();


    /// <summary>
    /// The <i>open</i> property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.
    /// </summary>
    public ValueTask<bool> Open => GetOpen(default);

    /// <summary>
    /// The <i>open</i> property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetOpen(CancellationToken cancellationToken) => await (await DialogJS).InvokeTrySync<bool>("getOpen", cancellationToken);

    /// <summary>
    /// The <i>open</i> property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.
    /// </summary>
    /// <param name="value">Sets the dialog state:<br/>true = open<br/>false = close</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetOpen(bool value, CancellationToken cancellationToken = default) => await (await DialogJS).InvokeVoidTrySync("setOpen", cancellationToken, value);


    /// <summary>
    /// The <i>returnValue</i> property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.
    /// </summary>
    public ValueTask<string> ReturnValue => GetReturnValue(default);

    /// <summary>
    /// The <i>returnValue</i> property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetReturnValue(CancellationToken cancellationToken) => await (await DialogJS).InvokeTrySync<string>("getReturnValue", cancellationToken);

    /// <summary>
    /// The <i>returnValue</i> property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.
    /// </summary>
    /// <param name="returnValue">A string representing the updated value of the dialog.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetReturnValue(string returnValue, CancellationToken cancellationToken = default) => await (await DialogJS).InvokeVoidTrySync("setReturnValue", cancellationToken, returnValue);


    /// <summary>
    /// The <i>show()</i> method of the HTMLDialogElement interface displays the dialog modelessly, i.e. still allowing interaction with content outside of the dialog.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Show(CancellationToken cancellationToken = default) => await (await DialogJS).InvokeVoidTrySync("show", cancellationToken);

    /// <summary>
    /// The <i>showModal()</i> method of the HTMLDialogElement interface displays the dialog as a modal, over the top of any other dialogs that might be present. It displays in the top layer, along with a ::backdrop pseudo-element. Interaction outside the dialog is blocked and the content outside it is rendered inert.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ShowModal(CancellationToken cancellationToken = default) => await (await DialogJS).InvokeVoidTrySync("showModal", cancellationToken);


    /// <summary>
    /// The <i>close()</i> method of the HTMLDialogElement interface closes the &lt;dialog&gt;.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Close(CancellationToken cancellationToken = default) => await (await DialogJS).InvokeVoidTrySync("close", cancellationToken);

    /// <summary>
    /// The <i>close()</i> method of the HTMLDialogElement interface closes the &lt;dialog&gt; and updates the returnValue of the dialog.
    /// </summary>
    /// <param name="returnValue">A string representing an updated value for the <see cref="ReturnValue"/> of the dialog.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Close(string returnValue, CancellationToken cancellationToken = default) => await (await DialogJS).InvokeVoidTrySync("close", cancellationToken, returnValue);
}
