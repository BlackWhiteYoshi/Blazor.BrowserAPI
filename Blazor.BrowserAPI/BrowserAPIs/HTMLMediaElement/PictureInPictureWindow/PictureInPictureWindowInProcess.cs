using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>Represents an object able to programmatically obtain the width and height and resize event of the floating video window.</para>
/// <para>An object with this interface is obtained using the <see cref="IHTMLMediaElementInProcess.RequestPictureInPicture"/> return value.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="Dispose"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class PictureInPictureWindowInProcess(IJSInProcessObjectReference pictureInPictureWindowJS) : PictureInPictureWindowBase(pictureInPictureWindowJS), IPictureInPictureWindowInProcess {
    private IJSInProcessObjectReference PictureInPictureWindowJS => (IJSInProcessObjectReference)base.pictureInPictureWindowJS;

    /// <summary>
    /// Releases the JS instance for this pictureInPictureWindow.
    /// </summary>
    /// <returns></returns>
    public void Dispose() {
        DisposeEventTrigger();
        PictureInPictureWindowJS.Dispose();
    }


    /// <summary>
    /// Returns the width of the floating video window in pixels if it is open. Otherwise, it returns 0.
    /// </summary>
    public int Width => PictureInPictureWindowJS.Invoke<int>("getWidth");

    /// <summary>
    /// Returns the height of the floating video window in pixels if it is open. Otherwise, it returns 0.
    /// </summary>
    public int Height => PictureInPictureWindowJS.Invoke<int>("getHeight");
}
