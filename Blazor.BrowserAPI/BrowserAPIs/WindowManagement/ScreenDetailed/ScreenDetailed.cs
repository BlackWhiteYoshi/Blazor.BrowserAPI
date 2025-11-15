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
    public ValueTask<int> Left => GetLeft(CancellationToken.None);

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
    public ValueTask<int> Top => GetTop(CancellationToken.None);

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
    public ValueTask<int> AvailLeft => GetAvailLeft(CancellationToken.None);

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
    public ValueTask<int> AvailTop => GetAvailTop(CancellationToken.None);

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
    public ValueTask<string> Label => GetLabel(CancellationToken.None);

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
    public ValueTask<double> DevicePixelRatio => GetDevicePixelRatio(CancellationToken.None);

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
    public ValueTask<bool> IsPrimary => GetIsPrimary(CancellationToken.None);

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
    public ValueTask<bool> IsInternal => GetIsInternal(CancellationToken.None);

    /// <summary>
    /// A boolean indicating whether the screen is internal to the device or external.
    /// External devices are generally manufactured separately from the device they are attached to and can be connected and disconnected as needed,
    /// whereas internal screens are part of the device and not intended to be disconnected.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetIsInternal(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<bool>("getIsInternal", cancellationToken);



    // Screen

    /// <inheritdoc cref="Screen.Width" />
    public ValueTask<int> Width => GetWidth(CancellationToken.None);

    /// <inheritdoc cref="Width" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetWidth(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getWidth", cancellationToken);


    /// <inheritdoc cref="Screen.Height" />
    public ValueTask<int> Height => GetHeight(CancellationToken.None);

    /// <inheritdoc cref="Height" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetHeight(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getHeight", cancellationToken);


    /// <inheritdoc cref="Screen.AvailWidth" />
    public ValueTask<int> AvailWidth => GetAvailWidth(CancellationToken.None);

    /// <inheritdoc cref="AvailWidth" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetAvailWidth(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getAvailWidth", cancellationToken);


    /// <inheritdoc cref="Screen.AvailHeight" />
    public ValueTask<int> AvailHeight => GetAvailHeight(CancellationToken.None);

    /// <inheritdoc cref="AvailHeight" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetAvailHeight(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getAvailHeight", cancellationToken);


    /// <inheritdoc cref="Screen.ColorDepth" />
    public ValueTask<int> ColorDepth => GetColorDepth(CancellationToken.None);

    /// <inheritdoc cref="ColorDepth" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetColorDepth(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getColorDepth", cancellationToken);


    /// <inheritdoc cref="Screen.PixelDepth" />
    public ValueTask<int> PixelDepth => GetPixelDepth(CancellationToken.None);

    /// <inheritdoc cref="PixelDepth" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetPixelDepth(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<int>("getPixelDepth", cancellationToken);


    /// <inheritdoc cref="Screen.IsExtended" />
    public ValueTask<bool> IsExtended => GetIsExtended(CancellationToken.None);

    /// <inheritdoc cref="IsExtended" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetIsExtended(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<bool>("getIsExtended", cancellationToken);


    // Screen orientation

    /// <inheritdoc cref="Screen.OrientationType" />
    public ValueTask<string> OrientationType => GetOrientationType(CancellationToken.None);

    /// <inheritdoc cref="OrientationType" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetOrientationType(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<string>("getOrientationType", cancellationToken);


    /// <inheritdoc cref="Screen.OrientationAngle" />
    public ValueTask<double> OrientationAngle => GetOrientationAngle(CancellationToken.None);

    /// <inheritdoc cref="OrientationAngle" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetOrientationAngle(CancellationToken cancellationToken) => screenDetailedJS.InvokeTrySync<double>("getOrientationAngle", cancellationToken);


    // public ValueTask LockOrientation(...) is in ScreenDetaildBase

    /// <inheritdoc cref="Screen.UnlockOrientation" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask UnlockOrientation(CancellationToken cancellationToken = default) => screenDetailedJS.InvokeVoidTrySync("unlockOrientation", cancellationToken);
}
