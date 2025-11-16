using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>HTMLDialogElement</i> interface provides methods to manipulate &lt;dialog&gt; elements. It inherits properties and methods from the HTMLElement interface.
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="Dispose"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class HTMLDialogElementInProcess(IJSInProcessObjectReference dialogJS) : HTMLDialogElementBase(Task.FromResult<IJSObjectReference>(dialogJS)), IHTMLDialogElementInProcess {
    /// <summary>
    /// Releases the JS instance for this dialog.
    /// </summary>
    public void Dispose() {
        DisposeEventTrigger();
        dialogJS.Dispose();
    }


    /// <summary>
    /// Creates a new JS object and a new C# object to represent the underlying html element as <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement">HTMLElement</see>.
    /// </summary>
    /// <remarks>Note: The original object as well as the returned result must be disposed manually. Do not forget to Dispose each object when you are done with it.</remarks>
    /// <returns></returns>
    public IHTMLElementInProcess ToHTMLElement() {
        IJSInProcessObjectReference htmlElementJS = dialogJS.Invoke<IJSInProcessObjectReference>("toHTMLElement");
        return new HTMLElementInProcess(htmlElementJS);
    }


    /// <summary>
    /// <para>
    /// Indicates the types of user actions that can be used to close the associated &lt;dialog&gt; element.
    /// It sets or returns the dialog's closedby attribute value.
    /// </para>
    /// <para>
    /// Possible values are:<br />
    /// - "any": The dialog can be dismissed with a light dismiss user action, a platform-specific user action, or a developer-specified mechanism.<br />
    /// - "closerequest": The dialog can be dismissed with a platform-specific user action or a developer-specified mechanism.<br/>
    /// - "none": The dialog can only be dismissed with a developer-specified mechanism.
    /// </para>
    /// </summary>
    public string ClosedBy {
        get => dialogJS.Invoke<string>("getClosedBy");
        set => dialogJS.InvokeVoid("setClosedBy", [value]);
    }

    /// <summary>
    /// Reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.
    /// </summary>
    public bool Open {
        get => dialogJS.Invoke<bool>("getOpen");
        set => dialogJS.InvokeVoid("setOpen", [value]);
    }

    /// <summary>
    /// Gets/Sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.
    /// </summary>
    public string ReturnValue {
        get => dialogJS.Invoke<string>("getReturnValue");
        set => dialogJS.InvokeVoid("setReturnValue", [value]);
    }


    /// <summary>
    /// Displays the dialog modelessly, i.e. still allowing interaction with content outside of the dialog.
    /// </summary>
    public void Show() => dialogJS.InvokeVoid("show");

    /// <summary>
    /// Displays the dialog as a modal, over the top of any other dialogs that might be present. It displays in the top layer, along with a ::backdrop pseudo-element.
    /// Interaction outside the dialog is blocked and the content outside it is rendered inert.
    /// </summary>
    public void ShowModal() => dialogJS.InvokeVoid("showModal");


    /// <summary>
    /// Closes the &lt;dialog&gt;.<br />
    /// An optional string may be passed as an argument, updating the returnValue of the dialog.
    /// </summary>
    /// <param name="returnValue">A string representing an updated value for the <see cref="ReturnValue"/> of the dialog.</param>
    public void Close(string? returnValue = null) => dialogJS.InvokeVoid("close", [returnValue]);

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
    public void RequestClose(string? returnValue = null) => dialogJS.InvokeVoid("requestClose", [returnValue]);
}
