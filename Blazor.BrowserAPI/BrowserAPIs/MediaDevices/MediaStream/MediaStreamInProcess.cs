using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>MediaStream</i> interface of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/Media_Capture_and_Streams_API">Media Capture and Streams API</see> represents a stream of media content.
/// A stream consists of several tracks, such as video or audio tracks. Each track is specified as an instance of <see href="https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrack">MediaStreamTrack</see>.
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class MediaStreamInProcess(IJSInProcessObjectReference mediaStreamJS) : IMediaStreamInProcess {
    [AutoInterfaceVisibilityInternal]
    IJSInProcessObjectReference IMediaStreamInProcess.MediaStreamJS => mediaStreamJS;

    /// <summary>
    /// Releases the JS instance for this media stream.
    /// </summary>
    public void Dispose() {
        mediaStreamJS.InvokeVoid("dispose");
        mediaStreamJS.Dispose();
    }


    /// <summary>
    /// A Boolean value that returns true if the MediaStream is active, or false otherwise.
    /// </summary>
    public bool Active => mediaStreamJS.Invoke<bool>("getActive");

    /// <summary>
    /// A string containing a 36-character universally unique identifier (UUID) for the object.
    /// </summary>
    public string Id => mediaStreamJS.Invoke<string>("getId");


    /// <summary>
    /// Creates a new MediaRecorder object, given a MediaStream to record.
    /// Options are available to do things like set the container's MIME type (such as "video/webm" or "video/mp4") and the bit rates of the audio and video tracks or a single overall bit rate.
    /// </summary>
    /// <remarks>
    /// <para>If bits per second values are not specified for video and/or audio, the default adopted for video is 2.5Mbps, while the audio default is adaptive, depending upon the sample rate and the number of channels.</para>
    /// <para>Video resolution, frame rate and similar settings are specified as constraints when calling getUserMedia(), not here in the MediaStream Recording API.</para>
    /// </remarks>
    /// <param name="mimeType">A MIME type specifying the format for the resulting media; you may specify the container format (the browser will select its preferred codecs for audio and/or video), or you may use the codecs parameter and/or the profiles parameter to provide detailed information about which codecs to use and how to configure them. Applications can check in advance if a mimeType is supported by the user agent by calling MediaRecorder.isTypeSupported(). Defaults to an empty string.</param>
    /// <param name="audioBitsPerSecond">The chosen bitrate for the audio component of the media.</param>
    /// <param name="videoBitsPerSecond">The chosen bitrate for the video component of the media.</param>
    /// <param name="bitsPerSecond">The chosen bitrate for the audio and video components of the media. This can be specified instead of the above two properties. If this is specified along with one or the other of the above properties, this will be used for the one that isn't specified.</param>
    /// <returns></returns>
    public IMediaRecorderInProcess CreateRecorder(string mimeType = "", int audioBitsPerSecond = 0, int videoBitsPerSecond = 0, int bitsPerSecond = 0) {
        IJSInProcessObjectReference mediaRecorder = mediaStreamJS.Invoke<IJSInProcessObjectReference>("createMediaRecorder", [mimeType, audioBitsPerSecond, videoBitsPerSecond, bitsPerSecond]);
        return new MediaRecorderInProcess(mediaRecorder);
    }
}
