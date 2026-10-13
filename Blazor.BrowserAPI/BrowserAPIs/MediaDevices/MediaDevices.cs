using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>MediaDevices</i> interface of the Media Capture and Streams API provides access to connected media input devices like cameras and microphones, as well as screen sharing.
/// In essence, it lets you obtain access to any hardware source of media data.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IMediaDevicesBase<IJSObjectReference, IMediaStream>)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class MediaDevices(IModuleManager moduleManager) : MediaDevicesBase<IJSObjectReference, IMediaStream>(moduleManager), IMediaDevices {
    /// <summary>
    /// Returns an object based on the MediaTrackSupportedConstraints dictionary,
    /// whose member fields each specify one of the constrainable properties the user agent understands.
    /// </summary>
    public ValueTask<MediaTrackSupportedConstraints> SupportedConstraints => GetSupportedConstraints(CancellationToken.None);

    /// <inheritdoc cref="SupportedConstraints" />
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// A new object based on the MediaTrackSupportedConstraints dictionary listing the constraints supported by the user agent.
    /// Because only constraints supported by the user agent are included in the list, each of these Boolean properties has the value true.
    /// </returns>
    public ValueTask<MediaTrackSupportedConstraints> GetSupportedConstraints(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<MediaTrackSupportedConstraints>("MediaDevicesAPI.getSupportedConstraints", cancellationToken);
}
