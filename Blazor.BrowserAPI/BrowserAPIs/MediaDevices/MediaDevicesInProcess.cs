using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>MediaDevices</i> interface of the Media Capture and Streams API provides access to connected media input devices like cameras and microphones, as well as screen sharing.
/// In essence, it lets you obtain access to any hardware source of media data.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IMediaDevicesBase<IJSInProcessObjectReference, IMediaStreamInProcess>)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class MediaDevicesInProcess(IModuleManager moduleManager) : MediaDevicesBase<IJSInProcessObjectReference, IMediaStreamInProcess>(moduleManager), IMediaDevicesInProcess {
    /// <summary>
    /// Returns an object based on the MediaTrackSupportedConstraints dictionary,
    /// whose member fields each specify one of the constrainable properties the user agent understands.
    /// </summary>
    public MediaTrackSupportedConstraints SupportedConstraints => moduleManager.InvokeSync<MediaTrackSupportedConstraints>("MediaDevicesAPI.getSupportedConstraints");
}
