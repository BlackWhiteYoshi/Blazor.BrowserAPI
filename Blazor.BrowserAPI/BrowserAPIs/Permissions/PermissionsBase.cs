using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base interface of <see cref="IPermissions"/> and <see cref="IPermissionsInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
/// </summary>
/// <typeparam name="TJSObjectReference"></typeparam>
/// <typeparam name="TPermissionStatus"></typeparam>
/// <param name="moduleManager"></param>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class PermissionsBase<TJSObjectReference, TPermissionStatus>(IModuleManager moduleManager)
    where TJSObjectReference : IJSObjectReference
    where TPermissionStatus : IPermissionStatusBase<TJSObjectReference> {
    private protected IModuleManager moduleManager = moduleManager;


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
    public async ValueTask<TPermissionStatus> Query(string name, bool userVisibleOnly = false, bool sysex = false, CancellationToken cancellationToken = default) {
        TJSObjectReference permissionStatusJS = await moduleManager.InvokeAsync<TJSObjectReference>("PermissionsAPI.query", cancellationToken, [name, userVisibleOnly, sysex]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TPermissionStatus)(IPermissionStatus)new PermissionStatus(permissionStatusJS);
        else
            return (TPermissionStatus)(IPermissionStatusInProcess)new PermissionStatusInProcess((IJSInProcessObjectReference)permissionStatusJS);
    }
}
