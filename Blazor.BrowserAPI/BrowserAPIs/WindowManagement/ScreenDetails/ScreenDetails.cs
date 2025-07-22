using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>ScreenDetails</i> interface of the Window Management API represents the details of all the screens available to the user's device.</para>
/// <para>This information is accessed via the <see cref="IWindowManagement.GetScreenDetails">Window.getScreenDetails()</see> method.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class ScreenDetails(IJSObjectReference screenDetailsJS) : ScreenDetailsBase(screenDetailsJS), IScreenDetails {
    /// <summary>
    /// Releases the JS instance for this ScreenDetails.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() {
        DisposeEventTrigger();
        return screenDetailsJS.DisposeTrySync();
    }


    /// <summary>
    /// A single ScreenDetailed object representing detailed information about the screen that the current browser window is displayed in.
    /// </summary>
    public ValueTask<IScreenDetailed> CurrentScreen => GetCurrentScreen(default);

    /// <inheritdoc cref="CurrentScreen" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IScreenDetailed> GetCurrentScreen(CancellationToken cancellationToken) {
        IJSObjectReference screenDetailedJS = await screenDetailsJS.InvokeTrySync<IJSObjectReference>("getCurrentScreen", cancellationToken);
        return new ScreenDetailed(screenDetailedJS);
    }


    /// <summary>
    /// An array of ScreenDetailed objects, each one representing detailed information about one specific screen available to the user's device.
    /// </summary>
    public ValueTask<IScreenDetailed[]> Screens => GetScreens(default);

    /// <inheritdoc cref="Screens" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IScreenDetailed[]> GetScreens(CancellationToken cancellationToken) {
        IJSObjectReference[] screenDetailedJSArray = await screenDetailsJS.InvokeTrySync<IJSObjectReference[]>("getScreens", cancellationToken);

        ScreenDetailed[] result = new ScreenDetailed[screenDetailedJSArray.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new ScreenDetailed(screenDetailedJSArray[i]);
        return result;
    }
}
