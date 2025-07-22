using AutoInterfaceAttributes;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IMediaDevices")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IMediaDevicesInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class MediaDevicesBase(IModuleManager moduleManager) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IModuleManager moduleManager = moduleManager;


    /// <summary>
    /// <para>
    /// Requests a list of the currently available media input and output devices, such as microphones, cameras, headsets, and so forth.
    /// The returned Promise is resolved with an array of MediaDeviceInfo objects describing the devices.
    /// </para>
    /// <para>
    /// The returned list will omit any devices that are blocked by the document Permission Policy: microphone, camera, speaker-selection(for output devices), and so on.
    /// Access to particular non-default devices is also gated by the Permissions API, and the list will omit devices for which the user has not granted explicit permission.
    /// </para>
    /// </summary>
    /// <returns>
    /// <para>
    /// A Promise that is fulfilled with an array of MediaDeviceInfo objects. Each object in the array describes one of the available media input and output devices.
    /// The order is significant — the default capture devices will be listed first.
    /// </para>
    /// <para>Other than default devices, only devices for which permission has been granted are "available".</para>
    /// <para>If the media device is an input device, an InputDeviceInfo object will be returned instead.</para>
    /// <para>If enumeration fails, the promise is rejected.</para>
    /// </returns>
    public ValueTask<MediaDeviceInfo[]> EnumerateDevices(CancellationToken cancellationToken = default) => moduleManager.InvokeAsync<MediaDeviceInfo[]>("MediaDevicesAPI.enumerateDevices", cancellationToken);
}
