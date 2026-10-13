using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>Represents an object able to programmatically obtain the width and height and resize event of the floating video window.</para>
/// <para>An object with this interface is obtained using the <see cref="IHTMLMediaElementBase{IJSInProcessObjectReference, IPictureInPictureWindowInProcess}.RequestPictureInPicture"/> return value.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="Dispose"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IPictureInPictureWindowBase<IJSInProcessObjectReference>), typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class PictureInPictureWindowInProcess(IJSInProcessObjectReference pictureInPictureWindowJS) : PictureInPictureWindowBase<IJSInProcessObjectReference>(pictureInPictureWindowJS), IPictureInPictureWindowInProcess {
    /// <summary>
    /// Releases the JS instance for this pictureInPictureWindow.
    /// </summary>
    /// <returns></returns>
    public void Dispose() {
        DisposeEventTrigger();
        pictureInPictureWindowJS.Dispose();
    }


    /// <summary>
    /// Returns the width of the floating video window in pixels if it is open. Otherwise, it returns 0.
    /// </summary>
    public int Width => pictureInPictureWindowJS.Invoke<int>("getWidth");

    /// <summary>
    /// Returns the height of the floating video window in pixels if it is open. Otherwise, it returns 0.
    /// </summary>
    public int Height => pictureInPictureWindowJS.Invoke<int>("getHeight");
}
