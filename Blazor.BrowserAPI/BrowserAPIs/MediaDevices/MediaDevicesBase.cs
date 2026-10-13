using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// Base interface of <see cref="IMediaDevices"/> and <see cref="IMediaDevicesInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class MediaDevicesBase<TJSObjectReference, TMediaStream>(IModuleManager moduleManager) where TJSObjectReference : IJSObjectReference {
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


    /// <summary>
    /// <para>Prompts the user for permission to use a media input which produces a MediaStream with tracks containing the requested types of media.</para>
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
    public async ValueTask<TMediaStream> GetUserMedia(bool audio, bool video, CancellationToken cancellationToken = default) {
        TJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<TJSObjectReference>("MediaDevicesAPI.getUserMedia", cancellationToken, [audio, video]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference)) // TMediaStream = IMediaStreamInProcess
            return (TMediaStream)(IMediaStream)new MediaStream(mediaStreamJS);
        else // TMediaStream = IMediaStream
            return (TMediaStream)(IMediaStreamInProcess)new MediaStreamInProcess((IJSInProcessObjectReference)mediaStreamJS);
    }

    /// <inheritdoc cref="GetUserMedia(bool, bool, CancellationToken)" />
    /// <param name="audio">A constraints object that holds more detailed information about the requirements for the audio.</param>
    /// <param name="video">A flag that indicates a video track is included to the stream.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise whose fulfillment handler receives a MediaStream object when the requested media has successfully been obtained.</returns>
    public async ValueTask<TMediaStream> GetUserMedia(MediaTrackConstraints audio, bool video, CancellationToken cancellationToken = default) {
        TJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<TJSObjectReference>("MediaDevicesAPI.getUserMedia", cancellationToken, [audio, video]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference)) // TMediaStream = IMediaStreamInProcess
            return (TMediaStream)(IMediaStream)new MediaStream(mediaStreamJS);
        else // TMediaStream = IMediaStream
            return (TMediaStream)(IMediaStreamInProcess)new MediaStreamInProcess((IJSInProcessObjectReference)mediaStreamJS);
    }

    /// <inheritdoc cref="GetUserMedia(bool, bool, CancellationToken)" />
    /// <param name="audio">A flag that indicates an audio track is included to the stream.</param>
    /// <param name="video">A constraints object that holds more detailed information about the requirements for the video.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise whose fulfillment handler receives a MediaStream object when the requested media has successfully been obtained.</returns>
    public async ValueTask<TMediaStream> GetUserMedia(bool audio, MediaTrackConstraints video, CancellationToken cancellationToken = default) {
        TJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<TJSObjectReference>("MediaDevicesAPI.getUserMedia", cancellationToken, [audio, video]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference)) // TMediaStream = IMediaStreamInProcess
            return (TMediaStream)(IMediaStream)new MediaStream(mediaStreamJS);
        else // TMediaStream = IMediaStream
            return (TMediaStream)(IMediaStreamInProcess)new MediaStreamInProcess((IJSInProcessObjectReference)mediaStreamJS);
    }

    /// <inheritdoc cref="GetUserMedia(bool, bool, CancellationToken)" />
    /// <param name="audio">A constraints object that holds more detailed information about the requirements for the audio.</param>
    /// <param name="video">A constraints object that holds more detailed information about the requirements for the video.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise whose fulfillment handler receives a MediaStream object when the requested media has successfully been obtained.</returns>
    public async ValueTask<TMediaStream> GetUserMedia(MediaTrackConstraints audio, MediaTrackConstraints video, CancellationToken cancellationToken = default) {
        TJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<TJSObjectReference>("MediaDevicesAPI.getUserMedia", cancellationToken, [audio, video]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference)) // TMediaStream = IMediaStreamInProcess
            return (TMediaStream)(IMediaStream)new MediaStream(mediaStreamJS);
        else // TMediaStream = IMediaStream
            return (TMediaStream)(IMediaStreamInProcess)new MediaStreamInProcess((IJSInProcessObjectReference)mediaStreamJS);
    }


    /// <summary>
    /// With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input.
    /// </summary>
    /// <param name="audio">A flag that indicates an audio track is included to the stream.</param>
    /// <param name="video">A flag that indicates a video track is included to the stream.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise that resolves to a MediaStream containing a video track whose contents come from a user-selected screen area, as well as an optional audio track.</returns>
    public async ValueTask<TMediaStream> GetDisplayMedia(bool audio, bool video, CancellationToken cancellationToken = default) {
        TJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<TJSObjectReference>("MediaDevicesAPI.getDisplayMedia", cancellationToken, [audio, video]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference)) // TMediaStream = IMediaStreamInProcess
            return (TMediaStream)(IMediaStream)new MediaStream(mediaStreamJS);
        else // TMediaStream = IMediaStream
            return (TMediaStream)(IMediaStreamInProcess)new MediaStreamInProcess((IJSInProcessObjectReference)mediaStreamJS);
    }

    /// <inheritdoc cref="GetDisplayMedia(bool, bool, CancellationToken)" />
    /// <param name="audio">A constraints object that holds more detailed information about the requirements for the audio.</param>
    /// <param name="video">A flag that indicates a video track is included to the stream.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise that resolves to a MediaStream containing a video track whose contents come from a user-selected screen area, as well as an optional audio track.</returns>
    public async ValueTask<TMediaStream> GetDisplayMedia(MediaTrackConstraints audio, bool video, CancellationToken cancellationToken = default) {
        TJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<TJSObjectReference>("MediaDevicesAPI.getDisplayMedia", cancellationToken, [audio, video]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference)) // TMediaStream = IMediaStreamInProcess
            return (TMediaStream)(IMediaStream)new MediaStream(mediaStreamJS);
        else // TMediaStream = IMediaStream
            return (TMediaStream)(IMediaStreamInProcess)new MediaStreamInProcess((IJSInProcessObjectReference)mediaStreamJS);
    }

    /// <inheritdoc cref="GetDisplayMedia(bool, bool, CancellationToken)" />
    /// <param name="audio">A flag that indicates an audio track is included to the stream.</param>
    /// <param name="video">A constraints object that holds more detailed information about the requirements for the video.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise that resolves to a MediaStream containing a video track whose contents come from a user-selected screen area, as well as an optional audio track.</returns>
    public async ValueTask<TMediaStream> GetDisplayMedia(bool audio, MediaTrackConstraints video, CancellationToken cancellationToken = default) {
        TJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<TJSObjectReference>("MediaDevicesAPI.getDisplayMedia", cancellationToken, [audio, video]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference)) // TMediaStream = IMediaStreamInProcess
            return (TMediaStream)(IMediaStream)new MediaStream(mediaStreamJS);
        else // TMediaStream = IMediaStream
            return (TMediaStream)(IMediaStreamInProcess)new MediaStreamInProcess((IJSInProcessObjectReference)mediaStreamJS);
    }

    /// <inheritdoc cref="GetDisplayMedia(bool, bool, CancellationToken)" />
    /// <param name="audio">A constraints object that holds more detailed information about the requirements for the audio.</param>
    /// <param name="video">A constraints object that holds more detailed information about the requirements for the video.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A Promise that resolves to a MediaStream containing a video track whose contents come from a user-selected screen area, as well as an optional audio track.</returns>
    public async ValueTask<TMediaStream> GetDisplayMedia(MediaTrackConstraints audio, MediaTrackConstraints video, CancellationToken cancellationToken = default) {
        TJSObjectReference mediaStreamJS = await moduleManager.InvokeAsync<TJSObjectReference>("MediaDevicesAPI.getDisplayMedia", cancellationToken, [audio, video]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference)) // TMediaStream = IMediaStreamInProcess
            return (TMediaStream)(IMediaStream)new MediaStream(mediaStreamJS);
        else // TMediaStream = IMediaStream
            return (TMediaStream)(IMediaStreamInProcess)new MediaStreamInProcess((IJSInProcessObjectReference)mediaStreamJS);
    }
}
