using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>ScreenDetails</i> interface of the Window Management API represents the details of all the screens available to the user's device.</para>
/// <para>This information is accessed via the <see cref="IWindowManagementInProcess.GetScreenDetails">Window.getScreenDetails()</see> method.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class ScreenDetailsInProcess(IJSInProcessObjectReference screenDetailsJS) : ScreenDetailsBase(screenDetailsJS), IScreenDetailsInProcess {
    private IJSInProcessObjectReference ScreenDetailsJS => (IJSInProcessObjectReference)base.screenDetailsJS;

    /// <summary>
    /// Releases the JS instance for this ScreenDetails.
    /// </summary>
    public void Dispose() {
        DisposeEventTrigger();
        ScreenDetailsJS.Dispose();
    }


    /// <summary>
    /// A single ScreenDetailed object representing detailed information about the screen that the current browser window is displayed in.
    /// </summary>
    public IScreenDetailedInProcess CurrentScreen {
        get {
            IJSInProcessObjectReference screenDetailedJS = ScreenDetailsJS.Invoke<IJSInProcessObjectReference>("getCurrentScreen");
            return new ScreenDetailedInProcess(screenDetailedJS);
        }
    }


    /// <summary>
    /// An array of ScreenDetailed objects, each one representing detailed information about one specific screen available to the user's device.
    /// </summary>
    public IScreenDetailedInProcess[] Screens {
        get {
            IJSInProcessObjectReference[] screenDetailedJSArray = ScreenDetailsJS.Invoke<IJSInProcessObjectReference[]>("getScreens");

            ScreenDetailedInProcess[] result = new ScreenDetailedInProcess[screenDetailedJSArray.Length];
            for (int i = 0; i < result.Length; i++)
                result[i] = new ScreenDetailedInProcess(screenDetailedJSArray[i]);
            return result;
        }
    }
}
