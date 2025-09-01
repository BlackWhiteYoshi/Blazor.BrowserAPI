using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>HTMLDialogElement</i> interface provides methods to manipulate &lt;dialog&gt; elements. It inherits properties and methods from the HTMLElement interface.
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="DisposeAsync"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class HTMLDialogElement(Task<IJSObjectReference> dialogTask) : HTMLDialogElementBase(dialogTask), IHTMLDialogElement {
    /// <summary>
    /// Releases the JS instance for this dialog.
    /// </summary>
    /// <returns></returns>
    public async ValueTask DisposeAsync() {
        DisposeEventTrigger();
        await (await dialogTask).DisposeTrySync();
    }


    /// <summary>
    /// Creates a new JS object and a new C# object to represent the underlying html element as <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement">HTMLElement</see>.
    /// </summary>
    /// <remarks>Note: The original object as well as the returned result must be disposed manually. Do not forget to Dispose each object when you are done with it.</remarks>
    /// <returns></returns>
    public async ValueTask<IHTMLElement> ToHTMLElement(CancellationToken cancellationToken = default) {
        Task<IJSObjectReference> htmlElementTask = (await dialogTask).InvokeTrySync<IJSObjectReference>("toHTMLElement", cancellationToken).AsTask();
        return new HTMLElement(htmlElementTask);
    }


    /// <summary>
    /// <para>
    /// Indicates the types of user actions that can be used to close the associated &lt;dialog&gt; element.
    /// It sets or returns the dialog's closedby attribute value.
    /// </para>
    /// <para>
    /// Possible values are:<br />
    /// - "any": The dialog can be dismissed with a light dismiss user action, a platform-specific user action, or a developer-specified mechanism.<br />
    /// - "closerequest": The dialog can be dismissed with a platform-specific user action or a developer-specified mechanism.<br />
    /// - "none": The dialog can only be dismissed with a developer-specified mechanism.
    /// </para>
    /// </summary>
    public ValueTask<string> ClosedBy => GetClosedBy(default);

    /// <inheritdoc cref="ClosedBy" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetClosedBy(CancellationToken cancellationToken) => await (await dialogTask).InvokeTrySync<string>("getClosedBy", cancellationToken);

    /// <inheritdoc cref="ClosedBy" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetClosedBy(string value, CancellationToken cancellationToken = default) => await (await dialogTask).InvokeVoidTrySync("setClosedBy", cancellationToken, [value]);


    /// <summary>
    /// Reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.
    /// </summary>
    public ValueTask<bool> Open => GetOpen(default);

    /// <inheritdoc cref="Open" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetOpen(CancellationToken cancellationToken) => await (await dialogTask).InvokeTrySync<bool>("getOpen", cancellationToken);

    /// <inheritdoc cref="Open" />
    /// <param name="value">Sets the dialog state:<br/>true = open<br/>false = close</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetOpen(bool value, CancellationToken cancellationToken = default) => await (await dialogTask).InvokeVoidTrySync("setOpen", cancellationToken, [value]);


    /// <summary>
    /// Gets/Sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.
    /// </summary>
    public ValueTask<string> ReturnValue => GetReturnValue(default);

    /// <inheritdoc cref="ReturnValue" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetReturnValue(CancellationToken cancellationToken) => await (await dialogTask).InvokeTrySync<string>("getReturnValue", cancellationToken);

    /// <inheritdoc cref="ReturnValue" />
    /// <param name="value">A string representing the updated value of the dialog.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetReturnValue(string value, CancellationToken cancellationToken = default) => await (await dialogTask).InvokeVoidTrySync("setReturnValue", cancellationToken, [value]);


    /// <summary>
    /// Displays the dialog modelessly, i.e. still allowing interaction with content outside of the dialog.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Show(CancellationToken cancellationToken = default) => await (await dialogTask).InvokeVoidTrySync("show", cancellationToken);

    /// <summary>
    /// Displays the dialog as a modal, over the top of any other dialogs that might be present. It displays in the top layer, along with a ::backdrop pseudo-element.
    /// Interaction outside the dialog is blocked and the content outside it is rendered inert.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ShowModal(CancellationToken cancellationToken = default) => await (await dialogTask).InvokeVoidTrySync("showModal", cancellationToken);


    /// <summary>
    /// Closes the &lt;dialog&gt;.<br />
    /// An optional string may be passed as an argument, updating the returnValue of the dialog.
    /// </summary>
    /// <param name="returnValue">A string representing an updated value for the <see cref="ReturnValue"/> of the dialog.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Close(string? returnValue = null, CancellationToken cancellationToken = default) => await (await dialogTask).InvokeVoidTrySync("close", cancellationToken, [returnValue]);

    /// <summary>
    /// <para>
    /// Requests to close the &lt;dialog&gt;.<br />
    /// An optional string may be passed as an argument, updating the returnValue of the dialog.
    /// </para>
    /// <para>
    /// This method differs from the <see cref="Close"/> method in that it fires a cancel event before firing the close event.
    /// Authors can call Event.preventDefault() in the handler for the cancel event to prevent the dialog from closing.
    /// </para>
    /// <para>This method exposes the same behavior as the dialog's internal close watcher.</para>
    /// </summary>
    /// <param name="returnValue">A string representing an updated value for the <see cref="ReturnValue"/> of the dialog.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask RequestClose(string? returnValue = null, CancellationToken cancellationToken = default) => await (await dialogTask).InvokeVoidTrySync("requestClose", cancellationToken, [returnValue]);
}
