using AutoInterfaceAttributes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>An instance of this class takes a <see cref="ElementReference"/> and exposes an interface to interact with it.</para>
/// <para>
/// This factory <b>does not dispose</b> the created objects, they must disposed manually.
/// So do not forget to call <see cref="IAsyncDisposable.DisposeAsync"/> on a htmlElement-object when you are done with it.
/// </para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed partial class ElementFactory(IModuleManager moduleManager) : IElementFactory {
    /// <summary>
    /// Takes a <see cref="ElementReference"/> and returns a <see cref="IHTMLElement"/> interface to interact with the given html-element.
    /// </summary>
    /// <param name="htmlElement">An <see cref="ElementReference"/> referencing a html tag.</param>
    /// <returns>An object that can be used to interact with the given html element.</returns>
    public IHTMLElement CreateHTMLElement(ElementReference htmlElement) {
        Task<IJSObjectReference> htmlElementJS = moduleManager.InvokeTrySync<IJSObjectReference>("createHTMLElement", default, [htmlElement]).AsTask();
        return new HTMLElement(htmlElementJS);
    }
}
