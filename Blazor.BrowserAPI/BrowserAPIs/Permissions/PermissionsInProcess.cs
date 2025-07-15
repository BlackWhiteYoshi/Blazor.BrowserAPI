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
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class PermissionsInProcess(IModuleManager moduleManager) : IPermissionsInProcess {
    /// <summary>
    /// <para>Returns the user permission status for a given API.</para>
    /// <para>
    /// The user permission names are defined in the respective specifications for each feature.
    /// The permissions supported by different browser versions are listed in the <see href="https://developer.mozilla.org/en-US/docs/Web/API/Permissions#browser_compatibility">compatibility data of the Permissions interface</see>.
    /// </para>
    /// </summary>
    /// <param name="name">
    /// <para>
    /// A string containing the name of the API whose permissions you want to query, such as camera, bluetooth, microphone, geolocation.<br />
    /// The returned Promise will reject with a TypeError if the permission name is not supported by the browser.
    /// </para>
    /// <para>
    /// The <see href="https://developer.mozilla.org/en-US/docs/Web/API/Permissions_API#permission-aware_apis">Permission-aware APIs</see> are listed below:<br />
    /// "background-sync" - Background Synchronization API<br />
    /// "clipboard-read" - Clipboard API<br />
    /// "clipboard-write" - Clipboard API<br />
    /// "compute-pressure" - Compute Pressure API<br />
    /// "geolocation" - Geolocation API<br />
    /// "local-fonts" - Local Font Access API<br />
    /// "camera" - Media Capture and Streams API<br />
    /// "microphone" - Media Capture and Streams API<br />
    /// "notifications" - Notifications API<br />
    /// "payment-handler" - Payment Handler API<br />
    /// "push" - Push API<br />
    /// "screen-wake-lock" - Screen Wake Lock API<br />
    /// "accelerometer" - Sensor APIs<br />
    /// "gyroscope" - Sensor APIs<br />
    /// "magnetometer" - Sensor APIs<br />
    /// "ambient-light-sensor" - Sensor APIs<br />
    /// "storage-access" - Storage Access API<br />
    /// "top-level-storage-access" - Storage Access API<br />
    /// "persistent-storage" - Storage API<br />
    /// "bluetooth" - Web Bluetooth API<br />
    /// "midi" - Web MIDI API<br />
    /// "window-management" - Window Management API
    /// </para>
    /// </param>
    /// <param name="userVisibleOnly">
    /// <para>Only relevant for "push" permission.</para>
    /// <para>
    /// Indicates whether you want to show a notification for every message or be able to send silent push notifications.<br />
    /// The default is false.
    /// </para>
    /// </param>
    /// <param name="sysex">
    /// <para>Only relevant for "midi" permission.</para>
    /// <para>
    /// Indicates whether you need and/or receive system exclusive messages.<br />
    /// The default is false.
    /// </para>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IPermissionStatusInProcess> Query(string name, bool userVisibleOnly = false, bool sysex = false, CancellationToken cancellationToken = default) {
        IJSInProcessObjectReference permissionStatusJS = await moduleManager.InvokeAsync<IJSInProcessObjectReference>("PermissionsAPI.query", cancellationToken, [name, userVisibleOnly, sysex]);
        return new PermissionStatusInProcess(permissionStatusJS);
    }
}
