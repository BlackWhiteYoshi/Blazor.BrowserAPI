using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>ScreenDetailed</i> interface of the Window Management API represents detailed information about one specific screen available to the user's device.</para>
/// <para><i>ScreenDetailed</i> objects can be accessed via the <see cref="IScreenDetails.Screens">ScreenDetails.screens</see> and <see cref="IScreenDetails.CurrentScreen">ScreenDetails.currentScreen</see> properties.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class ScreenDetailed(IJSObjectReference screenDetailedJS) : ScreenDetailedBase(screenDetailedJS), IScreenDetailed {
    /// <summary>
    /// Releases the JS instance for this ScreenDetails.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() {
        DisposeEventTrigger();
        return screenDetailedJS.DisposeTrySync();
    }


    /// <summary>
    /// <para>A number representing the x-coordinate (left-hand edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.</para>
    /// <para>
    /// This is equal to the true left-hand edge, ignoring any OS UI element drawn at the left of the screen.
    /// Windows cannot be placed in those areas; to get the left-hand coordinate of the screen area that windows can be placed in, use <see cref="AvailLeft"/>.
    /// </para>
    /// </summary>
    public ValueTask<int> Left => GetLeft(default);

    /// <summary>
    /// <para>A number representing the x-coordinate (left-hand edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.</para>
    /// <para>
    /// This is equal to the true left-hand edge, ignoring any OS UI element drawn at the left of the screen.
    /// Windows cannot be placed in those areas; to get the left-hand coordinate of the screen area that windows can be placed in, use <see cref="AvailLeft"/>.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetLeft(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getLeft", cancellationToken);


    /// <summary>
    /// <para>A number representing the y-coordinate (top edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.</para>
    /// <para>
    /// This is equal to the true top edge, ignoring any OS UI element drawn at the top of the screen.
    /// Windows cannot be placed in those areas; to get the top coordinate of the screen area that windows can be placed in, use <see cref="AvailTop"/>.
    /// </para>
    /// </summary>
    public ValueTask<int> Top => GetTop(default);

    /// <summary>
    /// <para>A number representing the y-coordinate (top edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.</para>
    /// <para>
    /// This is equal to the true top edge, ignoring any OS UI element drawn at the top of the screen.
    /// Windows cannot be placed in those areas; to get the top coordinate of the screen area that windows can be placed in, use <see cref="AvailTop"/>.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetTop(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getTop", cancellationToken);


    /// <summary>
    /// <para>A number representing the y-coordinate (top edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.</para>
    /// <para>
    /// This is equal to the <see cref="Left"/> property, plus the width of any OS UI element drawn on the left of the screen.
    /// Windows cannot be placed in those areas, so availLeft is useful for giving you the left boundary of the actual area available to open or place windows.
    /// </para>
    /// </summary>
    public ValueTask<int> AvailLeft => GetAvailLeft(default);

    /// <summary>
    /// <para>A number representing the y-coordinate (top edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.</para>
    /// <para>
    /// This is equal to the <see cref="Left"/> property, plus the width of any OS UI element drawn on the left of the screen.
    /// Windows cannot be placed in those areas, so availLeft is useful for giving you the left boundary of the actual area available to open or place windows.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetAvailLeft(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getAvailLeft", cancellationToken);


    /// <summary>
    /// <para>A number representing the y-coordinate (top edge) of the available screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.</para>
    /// <para>
    /// This is equal to the <see cref="Top"/> property, plus the height of any OS UI element drawn at the top of the screen.
    /// Windows cannot be placed in those areas, so availTop is useful for giving you the top boundary of the actual area available to open or place windows.
    /// </para>
    /// </summary>
    public ValueTask<int> AvailTop => GetAvailTop(default);

    /// <summary>
    /// <para>A number representing the y-coordinate (top edge) of the available screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.</para>
    /// <para>
    /// This is equal to the <see cref="Top"/> property, plus the height of any OS UI element drawn at the top of the screen.
    /// Windows cannot be placed in those areas, so availTop is useful for giving you the top boundary of the actual area available to open or place windows.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetAvailTop(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getAvailTop", cancellationToken);



    /// <summary>
    /// <para>A descriptive label for the screen, for example "Built-in Retina Display".</para>
    /// <para>This is useful for constructing a list of options to display to the user if you want them to choose a screen to display content on.</para>
    /// </summary>
    public ValueTask<string> Label => GetLabel(default);

    /// <summary>
    /// <para>A descriptive label for the screen, for example "Built-in Retina Display".</para>
    /// <para>This is useful for constructing a list of options to display to the user if you want them to choose a screen to display content on.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetLabel(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<string>("getLabel", cancellationToken);


    /// <summary>
    /// <para>A number representing the screen's device pixel ratio.</para>
    /// <para>
    /// This is the same as the value returned by <i>Window.devicePixelRatio</i>, except that <i>Window.devicePixelRatio</i>:<br />
    /// - always returns the device pixel ratio for the current screen.<br />
    /// - also includes scaling of the window itself, i.e., page zoom (at least on some browser implementations).
    /// </para>
    /// </summary>
    public ValueTask<double> DevicePixelRatio => GetDevicePixelRatio(default);

    /// <summary>
    /// <para>A number representing the screen's device pixel ratio.</para>
    /// <para>
    /// This is the same as the value returned by <i>Window.devicePixelRatio</i>, except that <i>Window.devicePixelRatio</i>:<br />
    /// - always returns the device pixel ratio for the current screen.<br />
    /// - also includes scaling of the window itself, i.e., page zoom (at least on some browser implementations).
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetDevicePixelRatio(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<double>("getDevicePixelRatio", cancellationToken);


    /// <summary>
    /// <para>A boolean indicating whether the screen is set as the operating system (OS) primary screen or not.</para>
    /// <para>
    /// The OS hosting the browser will have one primary screen, and one or more secondary screens.
    /// The primary screen can usually be specified by the user via OS settings, and generally contains OS UI features such as the taskbar/icon dock.
    /// The primary screen may change for a number of reasons, such as a screen being unplugged.
    /// </para>
    /// </summary>
    public ValueTask<bool> IsPrimary => GetIsPrimary(default);

    /// <summary>
    /// <para>A boolean indicating whether the screen is set as the operating system (OS) primary screen or not.</para>
    /// <para>
    /// The OS hosting the browser will have one primary screen, and one or more secondary screens.
    /// The primary screen can usually be specified by the user via OS settings, and generally contains OS UI features such as the taskbar/icon dock.
    /// The primary screen may change for a number of reasons, such as a screen being unplugged.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetIsPrimary(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<bool>("getIsPrimary", cancellationToken);


    /// <summary>
    /// A boolean indicating whether the screen is internal to the device or external.
    /// External devices are generally manufactured separately from the device they are attached to and can be connected and disconnected as needed,
    /// whereas internal screens are part of the device and not intended to be disconnected.
    /// </summary>
    public ValueTask<bool> IsInternal => GetIsInternal(default);

    /// <summary>
    /// A boolean indicating whether the screen is internal to the device or external.
    /// External devices are generally manufactured separately from the device they are attached to and can be connected and disconnected as needed,
    /// whereas internal screens are part of the device and not intended to be disconnected.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetIsInternal(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<bool>("getIsInternal", cancellationToken);



    // Screen

    /// <summary>
    /// Returns the width of the screen in CSS pixels.
    /// </summary>
    public ValueTask<int> Width => GetWidth(default);

    /// <summary>
    /// Returns the width of the screen in CSS pixels.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetWidth(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getWidth", cancellationToken);


    /// <summary>
    /// Returns the height of the screen in CSS pixels.
    /// </summary>
    public ValueTask<int> Height => GetHeight(default);

    /// <summary>
    /// Returns the height of the screen in CSS pixels.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetHeight(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getHeight", cancellationToken);


    /// <summary>
    /// Returns the amount of horizontal space (in CSS pixels) available to the window.
    /// </summary>
    public ValueTask<int> AvailWidth => GetAvailWidth(default);

    /// <summary>
    /// Returns the amount of horizontal space (in CSS pixels) available to the window.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetAvailWidth(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getAvailWidth", cancellationToken);


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
    public ValueTask<int> GetAvailHeight(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getAvailHeight", cancellationToken);


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
    public ValueTask<int> GetColorDepth(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getColorDepth", cancellationToken);


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
    public ValueTask<int> GetPixelDepth(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getPixelDepth", cancellationToken);


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
    public ValueTask<bool> GetIsExtended(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<bool>("getIsExtended", cancellationToken);


    // Screen orientation

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
    public ValueTask<string> GetOrientationType(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<string>("getOrientationType", cancellationToken);


    /// <summary>
    /// Returns the document's current orientation angle.
    /// </summary>
    public ValueTask<double> OrientationAngle => GetOrientationAngle(default);

    /// <summary>
    /// Returns the document's current orientation angle.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetOrientationAngle(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<double>("getOrientationAngle", cancellationToken);


    // public ValueTask LockOrientation(...) is in ScreenDetaildBase

    /// <summary>
    /// Unlocks the orientation of the containing document from its default orientation.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask UnlockOrientation(CancellationToken cancellationToken = default) => screenDetailedJS.InvokeVoidTrySync("unlockOrientation", cancellationToken);
}
