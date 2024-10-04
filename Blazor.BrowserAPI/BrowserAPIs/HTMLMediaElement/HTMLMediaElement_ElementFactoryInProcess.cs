using AutoInterfaceAttributes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI")]
public sealed partial class ElementFactoryInProcess : IElementFactoryInProcess {
    /// <summary>
    /// Takes a <see cref="ElementReference"/> of <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLVideoElement">&lt;video&gt;</see> or <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLAudioElement">&lt;audio&gt;</see> and returns a <see cref="IHTMLMediaElementInProcess"/> interface to interact with the given element.
    /// </summary>
    /// <param name="htmlMediaElement">An <see cref="ElementReference"/> referencing a <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLVideoElement">&lt;video&gt;</see> or <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLAudioElement">&lt;audio&gt;</see> html tag.</param>
    /// <returns>An object that can be used to interact with the given <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLVideoElement">&lt;video&gt;</see> or <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLAudioElement">&lt;audio&gt;</see> element.</returns>
    public IHTMLMediaElementInProcess CreateHTMLMediaElement(ElementReference htmlMediaElement) {
        IJSInProcessObjectReference htmlMediaElementJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("HTMLMediaElementAPI.create", [htmlMediaElement]);
        return new HTMLMediaElementInProcess(htmlMediaElementJS);
    }
}
