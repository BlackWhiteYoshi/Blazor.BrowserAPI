using AutoInterfaceAttributes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI")]
public sealed partial class ElementFactory : IElementFactory {
    /// <summary>
    /// Takes a <see cref="ElementReference"/> of &lt;dialog&gt; and returns a <see cref="IHTMLDialogElement"/> interface to interact with the given &lt;dialog&gt;.
    /// </summary>
    /// <param name="dialogElement">An <see cref="ElementReference"/> referencing a &lt;dialog&gt; html tag.</param>
    /// <returns>An object that can be used to interact with the given &lt;dialog&gt; element.</returns>
    public IHTMLDialogElement CreateHTMLDialogElement(ElementReference dialogElement) {
        Task<IJSObjectReference> dialogTask = moduleManager.InvokeTrySync<IJSObjectReference>("HTMLDialogElementAPI.create", default, [dialogElement]).AsTask();
        return new HTMLDialogElement(dialogTask);
    }
}
