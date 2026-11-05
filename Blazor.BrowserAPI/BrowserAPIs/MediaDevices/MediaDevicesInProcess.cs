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


    /// <summary>
    /// The <i>isTypeSupported()</i> static method of the MediaRecorder interface returns a Boolean which is true if the MIME media type specified is one the user agent should be able to successfully record.
    /// </summary>
    /// <remarks>Even this static method is a member of MediaRecorder, it is also available here to use it in a static context.</remarks>
    /// <param name="mimeType"></param>
    /// <returns></returns>
    public bool IsTypeSupported(string mimeType) => moduleManager.InvokeSync<bool>("MediaDevicesAPI.isTypeSupported", [mimeType]);
}
