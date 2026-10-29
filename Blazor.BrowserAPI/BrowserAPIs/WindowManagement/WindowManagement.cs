using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>Window Management API</i> allows you to get detailed information on the displays connected to your device and more easily place windows on specific screens,
/// paving the way towards more effective multi-screen applications.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IWindowManagementBase<IJSObjectReference, IScreenDetails>)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class WindowManagement(IModuleManager moduleManager) : WindowManagementBase<IJSObjectReference, IScreenDetails>(moduleManager), IWindowManagement {
    /// <summary>
    /// The Window property <i>screen</i> returns a reference to the screen object associated with the window.
    /// The screen object, implementing the Screen interface, is a special object for inspecting properties of the screen on which the current window is being rendered.
    /// </summary>
    public IScreen Screen { get; } = new Screen(moduleManager);
}
