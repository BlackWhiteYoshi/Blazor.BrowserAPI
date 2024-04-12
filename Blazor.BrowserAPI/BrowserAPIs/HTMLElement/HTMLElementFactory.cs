using AutoInterfaceAttributes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>This class can take a <see cref="ElementReference"/> and creates a <see cref="IHTMLElement"/> or <see cref="IHTMLElementInProcess"/> object with it.</para>
/// <para>
/// This factory <b>does not dispose</b> the created onjects, they must disposed manually.
/// So do not forget to call <see cref="IDisposable.Dispose"/>/<see cref="IAsyncDisposable.DisposeAsync"/> on a htmlElement-object when you are done with it.
/// </para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class HTMLElementFactory(IModuleManager moduleManager) : IHTMLElementFactory {
    /// <summary>
    /// Takes a <see cref="ElementReference"/> and returns a <see cref="IHTMLElement"/> interface to interact with the given html-element.
    /// </summary>
    /// <param name="htmlElement">An <see cref="ElementReference"/> referencing a html tag.</param>
    /// <returns>An object that can be used to interact with the given html element.</returns>
    public IHTMLElement Create(ElementReference htmlElement) {
        Task<IJSObjectReference> htmlElementJS = moduleManager.InvokeTrySync<IJSObjectReference>("createHTMLElement", default, [htmlElement]).AsTask();
        return new HTMLElement(htmlElementJS);
    }

    /// <summary>
    /// Takes a <see cref="ElementReference"/> and returns a <see cref="IHTMLElementInProcess"/> interface to interact with the given html-element.
    /// </summary>
    /// <param name="htmlElement">An <see cref="ElementReference"/> referencing a html tag.</param>
    /// <returns>An object that can be used to interact with the given html element.</returns>
    public IHTMLElementInProcess CreateInProcess(ElementReference htmlElement) {
        IJSInProcessObjectReference htmlElementJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("createHTMLElement", [htmlElement]);
        return new HTMLElementInProcess(htmlElementJS);
    }
}
