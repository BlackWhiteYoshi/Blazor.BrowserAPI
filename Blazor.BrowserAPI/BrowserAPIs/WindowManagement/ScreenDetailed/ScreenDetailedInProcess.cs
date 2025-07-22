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

    /// <inheritdoc cref="ScreenInProcess.Width" />
    public int Width => ScreenDetailedJS.Invoke<int>("getWidth");

    /// <inheritdoc cref="ScreenInProcess.Height" />
    public int Height => ScreenDetailedJS.Invoke<int>("getHeight");

    /// <inheritdoc cref="ScreenInProcess.AvailWidth" />
    public int AvailWidth => ScreenDetailedJS.Invoke<int>("getAvailWidth");

    /// <inheritdoc cref="ScreenInProcess.AvailHeight" />
    public int AvailHeight => ScreenDetailedJS.Invoke<int>("getAvailHeight");

    /// <inheritdoc cref="ScreenInProcess.ColorDepth" />
    public int ColorDepth => ScreenDetailedJS.Invoke<int>("getColorDepth");

    /// <inheritdoc cref="ScreenInProcess.PixelDepth" />
    public int PixelDepth => ScreenDetailedJS.Invoke<int>("getPixelDepth");

    /// <inheritdoc cref="ScreenInProcess.IsExtended" />
    public bool IsExtended => ScreenDetailedJS.Invoke<bool>("getIsExtended");


    // orientation

    /// <inheritdoc cref="ScreenInProcess.OrientationType" />
    public string OrientationType => ScreenDetailedJS.Invoke<string>("getOrientationType");

    /// <inheritdoc cref="ScreenInProcess.OrientationAngle" />
    public double OrientationAngle => ScreenDetailedJS.Invoke<double>("getOrientationAngle");


    // public ValueTask LockOrientation(...) is in ScreenDetailedBase

    /// <inheritdoc cref="ScreenInProcess.UnlockOrientation" />
    public void UnlockOrientation() => ScreenDetailedJS.InvokeVoid("unlockOrientation");
}
