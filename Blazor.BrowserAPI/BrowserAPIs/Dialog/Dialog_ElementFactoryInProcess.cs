using AutoInterfaceAttributes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI")]
public sealed partial class ElementFactoryInProcess : IElementFactoryInProcess {
    /// <summary>
    /// Takes a <see cref="ElementReference"/> of &lt;dialog&gt; and returns a <see cref="IDialogInProcess"/> interface to interact with the given &lt;dialog&gt;.
    /// </summary>
    /// <param name="dialog">An <see cref="ElementReference"/> referencing a &lt;dialog&gt; html tag.</param>
    /// <returns>An object that can be used to interact with the given &lt;dialog&gt; element.</returns>
    public IDialogInProcess CreateDialog(ElementReference dialog) {
        IJSInProcessObjectReference dialogJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("createDialog", [dialog]);
        return new DialogInProcess(dialogJS);
    }
}
