using AutoInterfaceAttributes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI")]
public sealed partial class ElementFactoryInProcess : IElementFactoryInProcess {
    /// <summary>
    /// Takes a <see cref="ElementReference"/> of &lt;dialog&gt; and returns a <see cref="IHTMLDialogElementInProcess"/> interface to interact with the given &lt;dialog&gt;.
    /// </summary>
    /// <param name="dialogElement">An <see cref="ElementReference"/> referencing a &lt;dialog&gt; html tag.</param>
    /// <returns>An object that can be used to interact with the given &lt;dialog&gt; element.</returns>
    public IHTMLDialogElementInProcess CreateHTMLDialogElement(ElementReference dialogElement) {
        IJSInProcessObjectReference dialogJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("HTMLDialogElementAPI.create", [dialogElement]);
        return new HTMLDialogElementInProcess(dialogJS);
    }
}
