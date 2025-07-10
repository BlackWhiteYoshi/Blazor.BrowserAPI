using AutoInterfaceAttributes;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>Screen</i> interface represents a screen, usually the one on which the current window is being rendered, and is obtained using window.screen.</para>
/// <para>Note that browsers determine which screen to report as current by detecting which screen has the center of the browser window.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class ScreenInProcess(IModuleManager moduleManager) : ScreenBase(moduleManager), IScreenInProcess {
    /// <summary>
    /// Returns the width of the screen in CSS pixels.
    /// </summary>
    public int Width => moduleManager.InvokeSync<int>("ScreenAPI.getWidth");

    /// <summary>
    /// Returns the height of the screen in CSS pixels.
    /// </summary>
    public int Height => moduleManager.InvokeSync<int>("ScreenAPI.getHeight");

    /// <summary>
    /// Returns the amount of horizontal space (in CSS pixels) available to the window.
    /// </summary>
    public int AvailWidth => moduleManager.InvokeSync<int>("ScreenAPI.getAvailWidth");

    /// <summary>
    /// <para>
    /// Returns the height, in CSS pixels, of the space available for Web content on the screen.
    /// Since Screen is exposed on the Window interface's window.screen property, you access <i>availHeight</i> using <i>window.screen.availHeight</i>.
    /// </para>
    /// <para>You can similarly use <see cref="AvailWidth">Screen.availWidth</see> to get the number of pixels which are horizontally available to the browser for its use.</para>
    /// </summary>
    public int AvailHeight => moduleManager.InvokeSync<int>("ScreenAPI.getAvailHeight");

    /// <summary>
    /// Returns the color depth of the screen.
    /// Per the CSSOM, some implementations return 24 for compatibility reasons.
    /// See the browser compatibility section for those that don't.
    /// </summary>
    public int ColorDepth => moduleManager.InvokeSync<int>("ScreenAPI.getColorDepth");

    /// <summary>
    /// Returns the bit depth of the screen.
    /// Per the CSSOM, some implementations return 24 for compatibility reasons.
    /// See the browser compatibility section for those that don't.
    /// </summary>
    public int PixelDepth => moduleManager.InvokeSync<int>("ScreenAPI.getPixelDepth");

    /// <summary>
    /// <para>Returns true if the user's device has multiple screens, and false if not.</para>
    /// <para>
    /// This property is typically accessed via window.screen.isExtended,
    /// and can be used to test whether multiple screens are available before attempting to create a multi-window, multi-screen layout using the <see href="https://developer.mozilla.org/en-US/docs/Web/API/Window_Management_API">Window Management API</see>.
    /// </para>
    /// </summary>
    public bool IsExtended => moduleManager.InvokeSync<bool>("ScreenAPI.getIsExtended");


    // orientation

    /// <summary>
    /// Returns the document's current orientation type, one of:<br />
    /// - "portrait-primary"<br />
    /// - "portrait-secondary"<br />
    /// - "landscape-primary"<br />
    /// - "landscape-secondary"
    /// </summary>
    public string OrientationType => moduleManager.InvokeSync<string>("ScreenAPI.getOrientationType");

    /// <summary>
    /// Returns the document's current orientation angle.
    /// </summary>
    public double OrientationAngle => moduleManager.InvokeSync<double>("ScreenAPI.getOrientationAngle");


    // public ValueTask LockOrientation(...) is in ScreenBase

    /// <summary>
    /// Unlocks the orientation of the containing document from its default orientation.
    /// </summary>
    /// <returns></returns>
    public void UnlockOrientation() => moduleManager.InvokeSync("ScreenAPI.unlockOrientation");
}
