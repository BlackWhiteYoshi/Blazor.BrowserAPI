using AutoInterfaceAttributes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>An instance of this class takes a <see cref="ElementReference"/> and exposes an interface to interact with it.</para>
/// <para>
/// This factory <b>does not dispose</b> the created objects, they must disposed manually.
/// So do not forget to call <see cref="IDisposable.Dispose"/> on a htmlElement-object when you are done with it.
/// </para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed partial class ElementFactoryInProcess(IModuleManager moduleManager) : IElementFactoryInProcess {
    /// <summary>
    /// Takes a <see cref="ElementReference"/> and returns a <see cref="IHTMLElementInProcess"/> interface to interact with the given html-element.
    /// </summary>
    /// <param name="htmlElement">An <see cref="ElementReference"/> referencing a html tag.</param>
    /// <returns>An object that can be used to interact with the given html element.</returns>
    public IHTMLElementInProcess CreateHTMLElement(ElementReference htmlElement) {
        IJSInProcessObjectReference htmlElementJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("HTMLElementAPI.create", [htmlElement]);
        return new HTMLElementInProcess(htmlElementJS);
    }
}
