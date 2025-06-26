using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>MediaDevices</i> interface of the Media Capture and Streams API provides access to connected media input devices like cameras and microphones, as well as screen sharing.
/// In essence, it lets you obtain access to any hardware source of media data.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class MediaDevices(IModuleManager moduleManager) : MediaDevicesBase(moduleManager), IMediaDevices {
    /// <summary>
    /// The getSupportedConstraints() method of the MediaDevices interface returns an object based on the MediaTrackSupportedConstraints dictionary,
    /// whose member fields each specify one of the constrainable properties the user agent understands.
    /// </summary>
    public ValueTask<MediaTrackSupportedConstraints> SupportedConstraints => GetSupportedConstraints(default);

    /// <summary>
    /// The getSupportedConstraints() method of the MediaDevices interface returns an object based on the MediaTrackSupportedConstraints dictionary,
    /// whose member fields each specify one of the constrainable properties the user agent understands.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// A new object based on the MediaTrackSupportedConstraints dictionary listing the constraints supported by the user agent.
    /// Because only constraints supported by the user agent are included in the list, each of these Boolean properties has the value true.
    /// </returns>
    public ValueTask<MediaTrackSupportedConstraints> GetSupportedConstraints(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<MediaTrackSupportedConstraints>("MediaDevicesAPI.getSupportedConstraints", cancellationToken);


    /// <summary>
    /// <para>The getUserMedia() method of the MediaDevices interface prompts the user for permission to use a media input which produces a MediaStream with tracks containing the requested types of media.</para>
    /// <para>
    /// That stream can include, for example, a video track (produced by either a hardware or virtual video source such as a camera, video recording device, screen sharing service, and so forth),
    /// an audio track (similarly, produced by a physical or virtual audio source like a microphone, A/D converter, or the like),
    /// and possibly other track types.
    /// </para>
    /// <para>
    /// It returns a Promise that resolves to a MediaStream object.
    /// If the user denies permission, or matching media is not available, then the promise is rejected with NotAllowedError or NotFoundError DOMException respectively.
    /// </para>
    /// </summary>
    /// <param name="audio">A flag that indicates an audio track is included to the stream.</param>
    /// <param name="video">A flag that indicates a video track is included to the stream.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise whose fulfillment handler receives a MediaStream object when the requested media has successfully been obtained.</returns>
    public async ValueTask<IMediaStream> GetUserMedia(bool audio, bool video, CancellationToken cancellationToken = default) {
        IJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<IJSObjectReference>("MediaDevicesAPI.getUserMedia", cancellationToken, [audio, video]);
        return new MediaStream(mediaStreamJS);
    }

    /// <summary>
    /// <para>The getUserMedia() method of the MediaDevices interface prompts the user for permission to use a media input which produces a MediaStream with tracks containing the requested types of media.</para>
    /// <para>
    /// That stream can include, for example, a video track (produced by either a hardware or virtual video source such as a camera, video recording device, screen sharing service, and so forth),
    /// an audio track (similarly, produced by a physical or virtual audio source like a microphone, A/D converter, or the like),
    /// and possibly other track types.
    /// </para>
    /// <para>
    /// It returns a Promise that resolves to a MediaStream object.
    /// If the user denies permission, or matching media is not available, then the promise is rejected with NotAllowedError or NotFoundError DOMException respectively.
    /// </para>
    /// </summary>
    /// <param name="audio">A constraints object that holds more detailed information about the requirements for the audio.</param>
    /// <param name="video">A flag that indicates a video track is included to the stream.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise whose fulfillment handler receives a MediaStream object when the requested media has successfully been obtained.</returns>
    public async ValueTask<IMediaStream> GetUserMedia(MediaTrackConstraints audio, bool video, CancellationToken cancellationToken = default) {
        IJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<IJSObjectReference>("MediaDevicesAPI.getUserMedia", cancellationToken, [audio, video]);
        return new MediaStream(mediaStreamJS);
    }

    /// <summary>
    /// <para>The getUserMedia() method of the MediaDevices interface prompts the user for permission to use a media input which produces a MediaStream with tracks containing the requested types of media.</para>
    /// <para>
    /// That stream can include, for example, a video track (produced by either a hardware or virtual video source such as a camera, video recording device, screen sharing service, and so forth),
    /// an audio track (similarly, produced by a physical or virtual audio source like a microphone, A/D converter, or the like),
    /// and possibly other track types.
    /// </para>
    /// <para>
    /// It returns a Promise that resolves to a MediaStream object.
    /// If the user denies permission, or matching media is not available, then the promise is rejected with NotAllowedError or NotFoundError DOMException respectively.
    /// </para>
    /// </summary>
    /// <param name="audio">A flag that indicates an audio track is included to the stream.</param>
    /// <param name="video">A constraints object that holds more detailed information about the requirements for the video.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise whose fulfillment handler receives a MediaStream object when the requested media has successfully been obtained.</returns>
    public async ValueTask<IMediaStream> GetUserMedia(bool audio, MediaTrackConstraints video, CancellationToken cancellationToken = default) {
        IJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<IJSObjectReference>("MediaDevicesAPI.getUserMedia", cancellationToken, [audio, video]);
        return new MediaStream(mediaStreamJS);
    }

    /// <summary>
    /// <para>The getUserMedia() method of the MediaDevices interface prompts the user for permission to use a media input which produces a MediaStream with tracks containing the requested types of media.</para>
    /// <para>
    /// That stream can include, for example, a video track (produced by either a hardware or virtual video source such as a camera, video recording device, screen sharing service, and so forth),
    /// an audio track (similarly, produced by a physical or virtual audio source like a microphone, A/D converter, or the like),
    /// and possibly other track types.
    /// </para>
    /// <para>
    /// It returns a Promise that resolves to a MediaStream object.
    /// If the user denies permission, or matching media is not available, then the promise is rejected with NotAllowedError or NotFoundError DOMException respectively.
    /// </para>
    /// </summary>
    /// <param name="audio">A constraints object that holds more detailed information about the requirements for the audio.</param>
    /// <param name="video">A constraints object that holds more detailed information about the requirements for the video.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise whose fulfillment handler receives a MediaStream object when the requested media has successfully been obtained.</returns>
    public async ValueTask<IMediaStream> GetUserMedia(MediaTrackConstraints audio, MediaTrackConstraints video, CancellationToken cancellationToken = default) {
        IJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<IJSObjectReference>("MediaDevicesAPI.getUserMedia", cancellationToken, [audio, video]);
        return new MediaStream(mediaStreamJS);
    }


    /// <summary>
    /// With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input.
    /// </summary>
    /// <param name="audio">A flag that indicates an audio track is included to the stream.</param>
    /// <param name="video">A flag that indicates a video track is included to the stream.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise that resolves to a MediaStream containing a video track whose contents come from a user-selected screen area, as well as an optional audio track.</returns>
    public async ValueTask<IMediaStream> GetDisplayMedia(bool audio, bool video, CancellationToken cancellationToken = default) {
        IJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<IJSObjectReference>("MediaDevicesAPI.getDisplayMedia", cancellationToken, [audio, video]);
        return new MediaStream(mediaStreamJS);
    }

    /// <summary>
    /// With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input.
    /// </summary>
    /// <param name="audio">A constraints object that holds more detailed information about the requirements for the audio.</param>
    /// <param name="video">A flag that indicates a video track is included to the stream.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise that resolves to a MediaStream containing a video track whose contents come from a user-selected screen area, as well as an optional audio track.</returns>
    public async ValueTask<IMediaStream> GetDisplayMedia(MediaTrackConstraints audio, bool video, CancellationToken cancellationToken = default) {
        IJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<IJSObjectReference>("MediaDevicesAPI.getDisplayMedia", cancellationToken, [audio, video]);
        return new MediaStream(mediaStreamJS);
    }

    /// <summary>
    /// With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input.
    /// </summary>
    /// <param name="audio">A flag that indicates an audio track is included to the stream.</param>
    /// <param name="video">A constraints object that holds more detailed information about the requirements for the video.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise that resolves to a MediaStream containing a video track whose contents come from a user-selected screen area, as well as an optional audio track.</returns>
    public async ValueTask<IMediaStream> GetDisplayMedia(bool audio, MediaTrackConstraints video, CancellationToken cancellationToken = default) {
        IJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<IJSObjectReference>("MediaDevicesAPI.getDisplayMedia", cancellationToken, [audio, video]);
        return new MediaStream(mediaStreamJS);
    }

    /// <summary>
    /// With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input.
    /// </summary>
    /// <param name="audio">A constraints object that holds more detailed information about the requirements for the audio.</param>
    /// <param name="video">A constraints object that holds more detailed information about the requirements for the video.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise that resolves to a MediaStream containing a video track whose contents come from a user-selected screen area, as well as an optional audio track.</returns>
    public async ValueTask<IMediaStream> GetDisplayMedia(MediaTrackConstraints audio, MediaTrackConstraints video, CancellationToken cancellationToken = default) {
        IJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<IJSObjectReference>("MediaDevicesAPI.getDisplayMedia", cancellationToken, [audio, video]);
        return new MediaStream(mediaStreamJS);
    }
}
