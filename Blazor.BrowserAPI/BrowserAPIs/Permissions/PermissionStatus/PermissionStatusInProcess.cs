using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>PermissionStatus</i> interface of the Permissions API provides the state of an object and an event handler for monitoring changes to said state.
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class PermissionStatusInProcess(IJSInProcessObjectReference permissionStatusJS) : PermissionStatusBase(permissionStatusJS), IPermissionStatusInProcess {
    private IJSInProcessObjectReference PermissionStatusJS => (IJSInProcessObjectReference)base.permissionStatusJS;

    /// <summary>
    /// Releases the JS instance for this media recorder.
    /// </summary>
    public void Dispose() {
        DisposeEventTrigger();
        PermissionStatusJS.Dispose();
    }


    /// <summary>
    /// Returns the name of a requested permission, identical to the <i>name</i> passed to <see cref="IPermissionsInProcess.Query"/>.
    /// </summary>
    public string Name => PermissionStatusJS.Invoke<string>("getName");

    /// <summary>
    /// Returns the state of a requested permission. This property returns one of<br />
    /// - "granted": The user, or the user agent on the user's behalf, has given express permission to use a powerful feature. The caller can use the feature possibly without having the user agent ask the user's permission.<br />
    /// - "denied": The user, or the user agent on the user's behalf, has denied access to this powerful feature. The caller can't use the feature.<br />
    /// - "prompt": The user has not given express permission to use the feature (i.e., it's the same as denied). It also means that if a caller attempts to use the feature, the user agent will either be prompting the user for permission or access to the feature will be denied.
    /// </summary>
    public string State => PermissionStatusJS.Invoke<string>("getState");
}
