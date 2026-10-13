using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>
/// The Permissions API provides a consistent programmatic way to query the status of API permissions attributed to the current context, such as a web page or worker.
/// For example, it can be used to determine if permission to access a particular feature or API has been granted, denied, or requires specific user permission.
/// </para>
/// <para>The <i>Permissions</i> interface of the Permissions API provides the core Permission API functionality, such as methods for querying and revoking permissions.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IPermissionsBase<IJSInProcessObjectReference, IPermissionStatusInProcess>)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class PermissionsInProcess(IModuleManager moduleManager) : PermissionsBase<IJSInProcessObjectReference, IPermissionStatusInProcess>(moduleManager), IPermissionsInProcess;
