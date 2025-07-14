using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>ScreenDetailed</i> interface of the Window Management API represents detailed information about one specific screen available to the user's device.</para>
/// <para><i>ScreenDetailed</i> objects can be accessed via the <see cref="IScreenDetailsInProcess.Screens">ScreenDetails.screens</see> and <see cref="IScreenDetailsInProcess.CurrentScreen">ScreenDetails.currentScreen</see> properties.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class ScreenDetailedInProcess(IJSInProcessObjectReference screenDetailedJS) : ScreenDetailedBase(screenDetailedJS), IScreenDetailedInProcess {
    private IJSInProcessObjectReference ScreenDetailedJS => (IJSInProcessObjectReference)base.screenDetailedJS;

    /// <summary>
    /// Releases the JS instance for this ScreenDetails.
    /// </summary>
    public void Dispose() {
        DisposeEventTrigger();
        ScreenDetailedJS.Dispose();
    }


    /// <summary>
    /// <para>A number representing the x-coordinate (left-hand edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.</para>
    /// <para>
    /// This is equal to the true left-hand edge, ignoring any OS UI element drawn at the left of the screen.
    /// Windows cannot be placed in those areas; to get the left-hand coordinate of the screen area that windows can be placed in, use <see cref="AvailLeft"/>.
    /// </para>
    /// </summary>
    public int Left => ScreenDetailedJS.Invoke<int>("getLeft");

    /// <summary>
    /// <para>A number representing the y-coordinate (top edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.</para>
    /// <para>
    /// This is equal to the true top edge, ignoring any OS UI element drawn at the top of the screen.
    /// Windows cannot be placed in those areas; to get the top coordinate of the screen area that windows can be placed in, use <see cref="AvailTop"/>.
    /// </para>
    /// </summary>
    public int Top => ScreenDetailedJS.Invoke<int>("getTop");

    /// <summary>
    /// <para>A number representing the y-coordinate (top edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.</para>
    /// <para>
    /// This is equal to the <see cref="Left"/> property, plus the width of any OS UI element drawn on the left of the screen.
    /// Windows cannot be placed in those areas, so availLeft is useful for giving you the left boundary of the actual area available to open or place windows.
    /// </para>
    /// </summary>
    public int AvailLeft => ScreenDetailedJS.Invoke<int>("getAvailLeft");

    /// <summary>
    /// <para>A number representing the y-coordinate (top edge) of the available screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.</para>
    /// <para>
    /// This is equal to the <see cref="Top"/> property, plus the height of any OS UI element drawn at the top of the screen.
    /// Windows cannot be placed in those areas, so availTop is useful for giving you the top boundary of the actual area available to open or place windows.
    /// </para>
    /// </summary>
    public int AvailTop => ScreenDetailedJS.Invoke<int>("getAvailTop");


    /// <summary>
    /// <para>A descriptive label for the screen, for example "Built-in Retina Display".</para>
    /// <para>This is useful for constructing a list of options to display to the user if you want them to choose a screen to display content on.</para>
    /// </summary>
    public string Label => ScreenDetailedJS.Invoke<string>("getLabel");

    /// <summary>
    /// <para>A number representing the screen's device pixel ratio.</para>
    /// <para>
    /// This is the same as the value returned by <i>Window.devicePixelRatio</i>, except that <i>Window.devicePixelRatio</i>:<br />
    /// - always returns the device pixel ratio for the current screen.<br />
    /// - also includes scaling of the window itself, i.e., page zoom (at least on some browser implementations).
    /// </para>
    /// </summary>
    public double DevicePixelRatio => ScreenDetailedJS.Invoke<double>("getDevicePixelRatio");

    /// <summary>
    /// <para>A boolean indicating whether the screen is set as the operating system (OS) primary screen or not.</para>
    /// <para>
    /// The OS hosting the browser will have one primary screen, and one or more secondary screens.
    /// The primary screen can usually be specified by the user via OS settings, and generally contains OS UI features such as the taskbar/icon dock.
    /// The primary screen may change for a number of reasons, such as a screen being unplugged.
    /// </para>
    /// </summary>
    public bool IsPrimary => ScreenDetailedJS.Invoke<bool>("getIsPrimary");

    /// <summary>
    /// A boolean indicating whether the screen is internal to the device or external.
    /// External devices are generally manufactured separately from the device they are attached to and can be connected and disconnected as needed,
    /// whereas internal screens are part of the device and not intended to be disconnected.
    /// </summary>
    public bool IsInternal => ScreenDetailedJS.Invoke<bool>("getIsInternal");



    // Screen

    /// <summary>
    /// Returns the width of the screen in CSS pixels.
    /// </summary>
    public int Width => ScreenDetailedJS.Invoke<int>("getWidth");

    /// <summary>
    /// Returns the height of the screen in CSS pixels.
    /// </summary>
    public int Height => ScreenDetailedJS.Invoke<int>("getHeight");

    /// <summary>
    /// Returns the amount of horizontal space (in CSS pixels) available to the window.
    /// </summary>
    public int AvailWidth => ScreenDetailedJS.Invoke<int>("getAvailWidth");

    /// <summary>
    /// <para>
    /// Returns the height, in CSS pixels, of the space available for Web content on the screen.
    /// Since Screen is exposed on the Window interface's window.screen property, you access <i>availHeight</i> using <i>window.screen.availHeight</i>.
    /// </para>
    /// <para>You can similarly use <see cref="AvailWidth">Screen.availWidth</see> to get the number of pixels which are horizontally available to the browser for its use.</para>
    /// </summary>
    public int AvailHeight => ScreenDetailedJS.Invoke<int>("getAvailHeight");

    /// <summary>
    /// Returns the color depth of the screen.
    /// Per the CSSOM, some implementations return 24 for compatibility reasons.
    /// See the browser compatibility section for those that don't.
    /// </summary>
    public int ColorDepth => ScreenDetailedJS.Invoke<int>("getColorDepth");

    /// <summary>
    /// Returns the bit depth of the screen.
    /// Per the CSSOM, some implementations return 24 for compatibility reasons.
    /// See the browser compatibility section for those that don't.
    /// </summary>
    public int PixelDepth => ScreenDetailedJS.Invoke<int>("getPixelDepth");

    /// <summary>
    /// <para>Returns true if the user's device has multiple screens, and false if not.</para>
    /// <para>
    /// This property is typically accessed via window.screen.isExtended,
    /// and can be used to test whether multiple screens are available before attempting to create a multi-window, multi-screen layout using the <see href="https://developer.mozilla.org/en-US/docs/Web/API/Window_Management_API">Window Management API</see>.
    /// </para>
    /// </summary>
    public bool IsExtended => ScreenDetailedJS.Invoke<bool>("getIsExtended");


    // orientation

    /// <summary>
    /// Returns the document's current orientation type, one of:<br />
    /// - "portrait-primary"<br />
    /// - "portrait-secondary"<br />
    /// - "landscape-primary"<br />
    /// - "landscape-secondary"
    /// </summary>
    public string OrientationType => ScreenDetailedJS.Invoke<string>("getOrientationType");

    /// <summary>
    /// Returns the document's current orientation angle.
    /// </summary>
    public double OrientationAngle => ScreenDetailedJS.Invoke<double>("getOrientationAngle");


    // public ValueTask LockOrientation(...) is in ScreenDetailedBase

    /// <summary>
    /// Unlocks the orientation of the containing document from its default orientation.
    /// </summary>
    /// <returns></returns>
    public void UnlockOrientation() => ScreenDetailedJS.InvokeVoid("unlockOrientation");
}
