using AutoInterfaceAttributes;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>Screen</i> interface represents a screen, usually the one on which the current window is being rendered, and is obtained using window.screen.</para>
/// <para>Note that browsers determine which screen to report as current by detecting which screen has the center of the browser window.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class Screen(IModuleManager moduleManager) : ScreenBase(moduleManager), IScreen {
    /// <summary>
    /// Returns the width of the screen in CSS pixels.
    /// </summary>
    public ValueTask<int> Width => GetWidth(default);

    /// <summary>
    /// Returns the width of the screen in CSS pixels.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetWidth(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("ScreenAPI.getWidth", cancellationToken);


    /// <summary>
    /// Returns the height of the screen in CSS pixels.
    /// </summary>
    public ValueTask<int> Height => GetHeight(default);

    /// <summary>
    /// Returns the height of the screen in CSS pixels.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetHeight(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("ScreenAPI.getHeight", cancellationToken);


    /// <summary>
    /// Returns the amount of horizontal space (in CSS pixels) available to the window.
    /// </summary>
    public ValueTask<int> AvailWidth => GetAvailWidth(default);

    /// <summary>
    /// Returns the amount of horizontal space (in CSS pixels) available to the window.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetAvailWidth(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("ScreenAPI.getAvailWidth", cancellationToken);


    /// <summary>
    /// <para>
    /// Returns the height, in CSS pixels, of the space available for Web content on the screen.
    /// Since Screen is exposed on the Window interface's window.screen property, you access <i>availHeight</i> using <i>window.screen.availHeight</i>.
    /// </para>
    /// <para>You can similarly use <see cref="AvailWidth">Screen.availWidth</see> to get the number of pixels which are horizontally available to the browser for its use.</para>
    /// </summary>
    public ValueTask<int> AvailHeight => GetAvailHeight(default);

    /// <summary>
    /// <para>
    /// Returns the height, in CSS pixels, of the space available for Web content on the screen.
    /// Since Screen is exposed on the Window interface's window.screen property, you access <i>availHeight</i> using <i>window.screen.availHeight</i>.
    /// </para>
    /// <para>You can similarly use <see cref="AvailWidth">Screen.availWidth</see> to get the number of pixels which are horizontally available to the browser for its use.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetAvailHeight(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("ScreenAPI.getAvailHeight", cancellationToken);


    /// <summary>
    /// Returns the color depth of the screen.
    /// Per the CSSOM, some implementations return 24 for compatibility reasons.
    /// See the browser compatibility section for those that don't.
    /// </summary>
    public ValueTask<int> ColorDepth => GetColorDepth(default);

    /// <summary>
    /// Returns the color depth of the screen.
    /// Per the CSSOM, some implementations return 24 for compatibility reasons.
    /// See the browser compatibility section for those that don't.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetColorDepth(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("ScreenAPI.getColorDepth", cancellationToken);


    /// <summary>
    /// Returns the bit depth of the screen.
    /// Per the CSSOM, some implementations return 24 for compatibility reasons.
    /// See the browser compatibility section for those that don't.
    /// </summary>
    public ValueTask<int> PixelDepth => GetPixelDepth(default);

    /// <summary>
    /// Returns the bit depth of the screen.
    /// Per the CSSOM, some implementations return 24 for compatibility reasons.
    /// See the browser compatibility section for those that don't.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetPixelDepth(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("ScreenAPI.getPixelDepth", cancellationToken);


    /// <summary>
    /// <para>Returns true if the user's device has multiple screens, and false if not.</para>
    /// <para>
    /// This property is typically accessed via window.screen.isExtended,
    /// and can be used to test whether multiple screens are available before attempting to create a multi-window, multi-screen layout using the <see href="https://developer.mozilla.org/en-US/docs/Web/API/Window_Management_API">Window Management API</see>.
    /// </para>
    /// </summary>
    public ValueTask<bool> IsExtended => GetIsExtended(default);

    /// <summary>
    /// <para>Returns true if the user's device has multiple screens, and false if not.</para>
    /// <para>
    /// This property is typically accessed via window.screen.isExtended,
    /// and can be used to test whether multiple screens are available before attempting to create a multi-window, multi-screen layout using the <see href="https://developer.mozilla.org/en-US/docs/Web/API/Window_Management_API">Window Management API</see>.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetIsExtended(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("ScreenAPI.getIsExtended", cancellationToken);


    // orientation

    /// <summary>
    /// Returns the document's current orientation type, one of:<br />
    /// - "portrait-primary"<br />
    /// - "portrait-secondary"<br />
    /// - "landscape-primary"<br />
    /// - "landscape-secondary"
    /// </summary>
    public ValueTask<string> OrientationType => GetOrientationType(default);

    /// <summary>
    /// Returns the document's current orientation type, one of:<br />
    /// - "portrait-primary"<br />
    /// - "portrait-secondary"<br />
    /// - "landscape-primary"<br />
    /// - "landscape-secondary"
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetOrientationType(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("ScreenAPI.getOrientationType", cancellationToken);


    /// <summary>
    /// Returns the document's current orientation angle.
    /// </summary>
    public ValueTask<double> OrientationAngle => GetOrientationAngle(default);

    /// <summary>
    /// Returns the document's current orientation angle.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetOrientationAngle(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<double>("ScreenAPI.getOrientationAngle", cancellationToken);


    // public ValueTask LockOrientation(...) is in ScreenBase

    /// <summary>
    /// Unlocks the orientation of the containing document from its default orientation.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask UnlockOrientation(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("ScreenAPI.unlockOrientation", cancellationToken);
}
