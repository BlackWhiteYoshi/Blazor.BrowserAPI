﻿using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>HTMLDialogElement</i> interface provides methods to manipulate &lt;dialog&gt; elements. It inherits properties and methods from the HTMLElement interface.
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="DisposeAsync"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class Dialog(Task<IJSObjectReference> dialogTask) : DialogBase(dialogTask), IDialog {
    /// <summary>
    /// Releases the JS instance for this dialog.
    /// </summary>
    /// <returns></returns>
    public async ValueTask DisposeAsync() {
        DisposeEventTrigger();
        await (await dialogTask).DisposeTrySync();
    }


    /// <summary>
    /// The <i>open</i> property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.
    /// </summary>
    public ValueTask<bool> Open => GetOpen(default);

    /// <summary>
    /// The <i>open</i> property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetOpen(CancellationToken cancellationToken) => await (await dialogTask).InvokeTrySync<bool>("getOpen", cancellationToken);

    /// <summary>
    /// The <i>open</i> property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.
    /// </summary>
    /// <param name="value">Sets the dialog state:<br/>true = open<br/>false = close</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetOpen(bool value, CancellationToken cancellationToken = default) => await (await dialogTask).InvokeVoidTrySync("setOpen", cancellationToken, [value]);


    /// <summary>
    /// The <i>returnValue</i> property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.
    /// </summary>
    public ValueTask<string> ReturnValue => GetReturnValue(default);

    /// <summary>
    /// The <i>returnValue</i> property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetReturnValue(CancellationToken cancellationToken) => await (await dialogTask).InvokeTrySync<string>("getReturnValue", cancellationToken);

    /// <summary>
    /// The <i>returnValue</i> property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.
    /// </summary>
    /// <param name="returnValue">A string representing the updated value of the dialog.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetReturnValue(string returnValue, CancellationToken cancellationToken = default) => await (await dialogTask).InvokeVoidTrySync("setReturnValue", cancellationToken, [returnValue]);


    /// <summary>
    /// The <i>show()</i> method of the HTMLDialogElement interface displays the dialog modelessly, i.e. still allowing interaction with content outside of the dialog.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Show(CancellationToken cancellationToken = default) => await (await dialogTask).InvokeVoidTrySync("show", cancellationToken);

    /// <summary>
    /// The <i>showModal()</i> method of the HTMLDialogElement interface displays the dialog as a modal, over the top of any other dialogs that might be present. It displays in the top layer, along with a ::backdrop pseudo-element. Interaction outside the dialog is blocked and the content outside it is rendered inert.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ShowModal(CancellationToken cancellationToken = default) => await (await dialogTask).InvokeVoidTrySync("showModal", cancellationToken);


    /// <summary>
    /// The <i>close()</i> method of the HTMLDialogElement interface closes the &lt;dialog&gt;.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Close(CancellationToken cancellationToken = default) => await (await dialogTask).InvokeVoidTrySync("close", cancellationToken);

    /// <summary>
    /// The <i>close()</i> method of the HTMLDialogElement interface closes the &lt;dialog&gt; and updates the returnValue of the dialog.
    /// </summary>
    /// <param name="returnValue">A string representing an updated value for the <see cref="ReturnValue"/> of the dialog.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Close(string returnValue, CancellationToken cancellationToken = default) => await (await dialogTask).InvokeVoidTrySync("close", cancellationToken, [returnValue]);
}
