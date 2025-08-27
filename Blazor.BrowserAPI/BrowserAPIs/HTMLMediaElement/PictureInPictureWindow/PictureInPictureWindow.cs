using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>Represents an object able to programmatically obtain the width and height and resize event of the floating video window.</para>
/// <para>An object with this interface is obtained using the <see cref="IHTMLMediaElement.RequestPictureInPicture"/> return value.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="DisposeAsync"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class PictureInPictureWindow(IJSObjectReference pictureInPictureWindowJS) : PictureInPictureWindowBase(pictureInPictureWindowJS), IPictureInPictureWindow {
    /// <summary>
    /// Releases the JS instance for this pictureInPictureWindow.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() {
        DisposeEventTrigger();
        return pictureInPictureWindowJS.DisposeTrySync();
    }


    /// <summary>
    /// Returns the width of the floating video window in pixels if it is open. Otherwise, it returns 0.
    /// </summary>
    public ValueTask<int> Width => GetWidth(default);

    /// <inheritdoc cref="Width" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetWidth(CancellationToken cancellationToken) => pictureInPictureWindowJS.InvokeTrySync<int>("getWidth", cancellationToken);


    /// <summary>
    /// Returns the height of the floating video window in pixels if it is open. Otherwise, it returns 0.
    /// </summary>
    public ValueTask<int> Height => GetHeight(default);

    /// <inheritdoc cref="Height" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetHeight(CancellationToken cancellationToken) => pictureInPictureWindowJS.InvokeTrySync<int>("getHeight", cancellationToken);
}
