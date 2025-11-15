using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>PermissionStatus</i> interface of the Permissions API provides the state of an object and an event handler for monitoring changes to said state.
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class PermissionStatus(IJSObjectReference permissionStatusJS) : PermissionStatusBase(permissionStatusJS), IPermissionStatus {
    /// <summary>
    /// Releases the JS instance for this media recorder.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() {
        DisposeEventTrigger();
        return permissionStatusJS.DisposeTrySync();
    }


    /// <summary>
    /// Returns the name of a requested permission, identical to the <i>name</i> passed to <see cref="IPermissions.Query"/>.
    /// </summary>
    public ValueTask<string> Name => GetName(CancellationToken.None);

    /// <inheritdoc cref="Name" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetName(CancellationToken cancellationToken) => permissionStatusJS.InvokeTrySync<string>("getName", cancellationToken);


    /// <summary>
    /// Returns the state of a requested permission. This property returns one of<br />
    /// - "granted": The user, or the user agent on the user's behalf, has given express permission to use a powerful feature. The caller can use the feature possibly without having the user agent ask the user's permission.<br />
    /// - "denied": The user, or the user agent on the user's behalf, has denied access to this powerful feature. The caller can't use the feature.<br />
    /// - "prompt": The user has not given express permission to use the feature (i.e., it's the same as denied). It also means that if a caller attempts to use the feature, the user agent will either be prompting the user for permission or access to the feature will be denied.
    /// </summary>
    public ValueTask<string> State => GetState(CancellationToken.None);

    /// <inheritdoc cref="State" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetState(CancellationToken cancellationToken) => permissionStatusJS.InvokeTrySync<string>("getState", cancellationToken);
}
