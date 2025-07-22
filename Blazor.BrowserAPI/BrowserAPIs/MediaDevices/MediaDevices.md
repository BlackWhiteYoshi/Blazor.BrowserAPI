# Media Devices

The *MediaDevices* interface of the Media Capture and Streams API provides access to connected media input devices like cameras and microphones, as well as screen sharing.
In essence, it lets you obtain access to any hardware source of media data.


<br><br />
## Example

```razor
<button @onclick="StartRecording" disabled="@(mediaRecorder is not null)">Start Recording audio/video</button>
<button @onclick="StopRecording" disabled="@(mediaRecorder is null)">Stop Recording audio/video</button>

@* live playback of stream *@
<video @ref="videoElement" controls></video>

@* download video as file *@
<button @onclick="SaveVideoAsFile" disabled="@(videoData.Count == 0)">Download audio/video as file</button>
```

```csharp
public sealed partial class ExampleComponent : ComponentBase, IAsyncDisposable {
    [Inject]
    public required IMediaDevices MediaDevices { private get; init; }

    public async ValueTask DisposeAsync() {
        if (mediaRecorder is not null) {
            mediaRecorder.OnDataavailable -= SaveChunk;
            await mediaRecorder.DisposeAsync();
        }
        if (mediaStream is not null)
            await mediaStream.DisposeAsync();

        if (video is not null)
            await video.DisposeAsync();
    }


    private IMediaStream? mediaStream = null;
    private IMediaRecorder? mediaRecorder = null;

    private readonly List<byte> videoData = [];
    private void SaveChunk(byte[] data) => videoData.AddRange(data);

    private static void OutputToConsole(JsonElement error) => Console.WriteLine(error);


    private async Task StartRecording() {
        mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);

        videoData.Clear();
        mediaRecorder = await mediaStream.CreateRecorder(mimeType: "video/mp4");
        mediaRecorder.OnError += OutputToConsole;
        mediaRecorder.OnDataavailable += SaveChunk;

        await mediaRecorder.Start(100);

        // playback the stream
        if (video is not null) {
            await video.SetSrcObject(mediaStream);
            await video.Play();
        }
    }

    private async Task StopRecording() {
        if (this.mediaRecorder is null || this.mediaStream is null)
            return;

        IMediaStream mediaStream = this.mediaStream;
        IMediaRecorder mediaRecorder = this.mediaRecorder;
        this.mediaStream = null;
        this.mediaRecorder = null;

        await mediaRecorder.Stop();

        // stop playback the stream
        if (video is not null)
            await video.SetSrcObject(null);

        await Task.Delay(5000); // delay cleanup to make sure that the last chunk is saved
        mediaRecorder.OnDataavailable -= SaveChunk;
        mediaRecorder.OnError -= OutputToConsole;
        await mediaRecorder.DisposeAsync();
        await mediaStream.DisposeAsync();
    }



    // get video element reference for live playback of the stream

    [Inject]
    public required IElementFactory ElementFactory { private get; init; }

    private ElementReference videoElement;
    private IHTMLMediaElement? video;

    protected override void OnAfterRender(bool firstRender) {
        if (firstRender)
            video = ElementFactory.CreateHTMLMediaElement(videoElement);
    }



    // download video as file

    [Inject]
    public required IDownload Download { private get; init; }

    private async Task SaveVideoAsFile() {
        if (videoData.Count > 0)
            await Download.DownloadAsFile("example.mp4", [.. videoData]);
    }
}
```

**Note**:
Blazor Server (SignalR) with default settings has problems to perform the *OnDataavailable* callback in time
and that can cause disconnects.
Blazor Webassembly works just fine.


<br><br />
## Members

### IMediaDevices

The *MediaDevices* interface of the Media Capture and Streams API provides access to connected media input devices like cameras and microphones, as well as screen sharing.
In essence, it lets you obtain access to any hardware source of media data.

#### Properties

| **Name**             | **Type**                                        | get/set | **Description**                                                                                                                                                            |
| -------------------- | ----------------------------------------------- | ------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| SupportedConstraints | ValueTask&lt;MediaTrackSupportedConstraints&gt; | get     | Returns an object based on the MediaTrackSupportedConstraints dictionary, whose member fields each specify one of the constrainable properties the user agent understands. |

#### Methods

| **Name**                | **Parameters**                                                                                            | **ReturnType**                                  | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| ----------------------- | --------------------------------------------------------------------------------------------------------- | ----------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| EnumerateDevices        | [CancellationToken cancellationToken = default]                                                           | ValueTask&lt;MediaDeviceInfo[]&gt;              | Requests a list of the currently available media input and output devices, such as microphones, cameras, headsets, and so forth. The returned Promise is resolved with an array of MediaDeviceInfo objects describing the devices.<br />The returned list will omit any devices that are blocked by the document Permission Policy: microphone, camera, speaker-selection(for output devices), and so on. Access to particular non-default devices is also gated by the Permissions API, and the list will omit devices for which the user has not granted explicit permission.                                                                                                                                                     |
| GetSupportedConstraints | CancellationToken cancellationToken                                                                       | ValueTask&lt;MediaTrackSupportedConstraints&gt; | see Property *SupportedConstraints*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| GetUserMedia            | bool audio, bool video, [CancellationToken cancellationToken = default]                                   | ValueTask&lt;IMediaStream&gt;                   | Prompts the user for permission to use a media input which produces a MediaStream with tracks containing the requested types of media.<br />That stream can include, for example, a video track (produced by either a hardware or virtual video source such as a camera, video recording device, screen sharing service, and so forth), an audio track (similarly, produced by a physical or virtual audio source like a microphone, A/D converter, or the like), and possibly other track types.<br />It returns a Promise that resolves to a MediaStream object. If the user denies permission, or matching media is not available, then the promise is rejected with NotAllowedError or NotFoundError DOMException respectively. |
| GetUserMedia            | MediaTrackConstraints audio, bool video, [CancellationToken cancellationToken = default]                  | ValueTask&lt;IMediaStream&gt;                   | see Method *GetUserMedia(bool, bool, CancellationToken)*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| GetUserMedia            | bool audio, MediaTrackConstraints video, [CancellationToken cancellationToken = default]                  | ValueTask&lt;IMediaStream&gt;                   | see Method *GetUserMedia(bool, bool, CancellationToken)*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| GetUserMedia            | MediaTrackConstraints audio, MediaTrackConstraints video, [CancellationToken cancellationToken = default] | ValueTask&lt;IMediaStream&gt;                   | see Method *GetUserMedia(bool, bool, CancellationToken)*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| GetDisplayMedia         | bool audio, bool video, [CancellationToken cancellationToken = default]                                   | ValueTask&lt;IMediaStream&gt;                   | With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| GetDisplayMedia         | MediaTrackConstraints audio, bool video, [CancellationToken cancellationToken = default]                  | ValueTask&lt;IMediaStream&gt;                   | see Method *GetDisplayMedia(bool, bool, CancellationToken)*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| GetDisplayMedia         | bool audio, MediaTrackConstraints video, [CancellationToken cancellationToken = default]                  | ValueTask&lt;IMediaStream&gt;                   | see Method *GetDisplayMedia(bool, bool, CancellationToken)*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| GetDisplayMedia         | MediaTrackConstraints audio, MediaTrackConstraints video, [CancellationToken cancellationToken = default] | ValueTask&lt;IMediaStream&gt;                   | see Method *GetDisplayMedia(bool, bool, CancellationToken)*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |


<br></br>
### IMediaStream

The *MediaStream* interface of the [Media Capture and Streams API](https://developer.mozilla.org/en-US/docs/Web/API/Media_Capture_and_Streams_API) represents a stream of media content.
A stream consists of several tracks, such as video or audio tracks. Each track is specified as an instance of [MediaStreamTrack](https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrack).

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Properties

| **Name** | **Type**                | get/set | **Description**                                                                         |
| -------- | ----------------------- | ------- | --------------------------------------------------------------------------------------- |
| Active   | ValueTask&lt;bool&gt;   | get     | A Boolean value that returns true if the MediaStream is active, or false otherwise.     |
| Id       | ValueTask&lt;string&gt; | get     | A string containing a 36-character universally unique identifier (UUID) for the object. |

#### Methods

| **Name**       | **Parameters**                                                                                                                                               | **ReturnType**                  | **Description**                                                                                                                                                                                                                                              |
| -------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| GetActive      | CancellationToken cancellationToken                                                                                                                          | ValueTask&lt;bool&gt;           | see Property *Active*                                                                                                                                                                                                                                        |
| GetId          | CancellationToken cancellationToken                                                                                                                          | ValueTask&lt;string&gt;         | see Property *Id*                                                                                                                                                                                                                                            |
| CreateRecorder | [string mimeType = ""], [int audioBitsPerSecond = 0], [int videoBitsPerSecond = 0], [int bitsPerSecond = 0], [CancellationToken cancellationToken = default] | ValueTask&lt;IMediaRecorder&gt; | Creates a new MediaRecorder object, given a MediaStream to record. Options are available to do things like set the container's MIME type (such as "video/webm" or "video/mp4") and the bit rates of the audio and video tracks or a single overall bit rate. |


<br></br>
### IMediaRecoder

The *MediaRecorder* interface of the [MediaStream Recording API](https://developer.mozilla.org/en-US/docs/Web/API/MediaStream_Recording_API) provides functionality to easily record media.

It is created using the IMediaStream.CreateRecorder() method.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Properties

| **Name**           | **Type**                      | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| ------------------ | ----------------------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| MimeType           | ValueTask&lt;string&gt;       | get     | Returns the [MIME](https://developer.mozilla.org/en-US/docs/Glossary/MIME) media type that was specified when creating the MediaRecorder object, or, if none was specified, which was chosen by the browser. This is the file format of the file that would result from writing all of the recorded data to disk.<br />Keep in mind that not all codecs are supported by a given container; if you write media using a codec that is not supported by a given media container, the resulting file may not work reliably if at all when you try to play it back. See our [media type and format guide](https://developer.mozilla.org/en-US/docs/Web/Media/Formats) for information about container and codec support across browsers. |
| State              | ValueTask&lt;string&gt;       | get     | Returns the current state of the current MediaRecorder object:<br />"inactive" - Recording is not occurring — it has either not been started yet, or it has been started and then stopped.<br />"recording" - Recording has been started and the user agent is capturing data.<br />"paused" - Recording has been started, then paused, but not yet stopped or resumed.                                                                                                                                                                                                                                                                                                                                                              |
| Stream             | ValueTask&lt;IMediaStream&gt; | get     | Returns the stream that was passed into the IMediaStream.CreateRecorder() method when the MediaRecorder was created.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| AudioBitsPerSecond | ValueTask&lt;ulong&gt;        | get     | Returns the audio encoding bit rate in use. This may differ from the bit rate specified in the constructor, if it was provided.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| VideoBitsPerSecond | ValueTask&lt;ulong&gt;        | get     | Returns the video encoding bit rate in use. This may differ from the bit rate specified in the constructor, if it was provided.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |

#### Methods

| **Name**              | **Parameters**                                                       | **ReturnType**                | **Description**                                                                                                                                                                                                                                                                         |
| --------------------- | -------------------------------------------------------------------- | ----------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetMimeType           | CancellationToken cancellationToken                                  | ValueTask&lt;string&gt;       | see Property *MimeType*                                                                                                                                                                                                                                                                 |
| GetState              | CancellationToken cancellationToken                                  | ValueTask&lt;string&gt;       | see Property *State*                                                                                                                                                                                                                                                                    |
| GetStream             | CancellationToken cancellationToken                                  | ValueTask&lt;IMediaStream&gt; | see Property *Stream*                                                                                                                                                                                                                                                                   |
| GetAudioBitsPerSecond | CancellationToken cancellationToken                                  | ValueTask&lt;ulong&gt;        | see Property *AudioBitsPerSecond*                                                                                                                                                                                                                                                       |
| GetVideoBitsPerSecond | CancellationToken cancellationToken                                  | ValueTask&lt;ulong&gt;        | see Property *VideoBitsPerSecond*                                                                                                                                                                                                                                                       |
| Start                 | [int timeslice = 0], [CancellationToken cancellationToken = default] | ValueTask                     | Begins recording media; this method can optionally be passed a timeslice argument with a value in milliseconds. If this is specified, the media will be captured in separate chunks of that duration, rather than the default behavior of recording the media in a single large chunk.  |
| Stop                  | [CancellationToken cancellationToken = default]                      | ValueTask                     | Stops recording, at which point a dataavailable event containing the final Blob of saved data is fired. No more recording occurs.                                                                                                                                                       |
| Resume                | [CancellationToken cancellationToken = default]                      | ValueTask                     | Resumes recording of media after having been paused.                                                                                                                                                                                                                                    |
| Pause                 | [CancellationToken cancellationToken = default]                      | ValueTask                     | Pauses the recording of media.                                                                                                                                                                                                                                                          |
| RequestData           | [CancellationToken cancellationToken = default]                      | ValueTask                     | Requests a Blob containing the saved data received thus far (or since the last time requestData() was called. After calling this method, recording continues, but in a new Blob.                                                                                                        |
| IsTypeSupported       | string mimeType, [CancellationToken cancellationToken = default]     | ValueTask&lt;bool&gt;         | The *isTypeSupported()* static method of the MediaRecorder interface returns a Boolean which is true if the MIME media type specified is one the user agent should be able to successfully record.<br />In C# this method is not static because it needs an reference to the JS-module. |

#### Events

| **Name**        | **Type**                  | **Description**                                                                                                                                                                                                                                                                                                             |
| --------------- | ------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnDataavailable | Action&lt;byte[]&gt;      | Fires periodically each time timeslice milliseconds of media have been recorded (or when the entire media has been recorded, if timeslice wasn't specified). The event, of type BlobEvent, contains the recorded media in its data property.<br />Parameter is the recorded binary data.                                    |
| OnError         | Action&lt;JsonElement&gt; | Fired when there are fatal errors that stop recording. The received event is based on the MediaRecorderErrorEvent interface, whose error property contains a DOMException that describes the actual error that occurred.<br />Parameter is of type [Event](https://developer.mozilla.org/en-US/docs/Web/API/Event) as JSON. |
| OnStart         | Action                    | Fired when media recording starts.                                                                                                                                                                                                                                                                                          |
| OnStop          | Action                    | Fired when media recording ends, either when the MediaStream ends, or after the MediaRecorder.stop() method is called.                                                                                                                                                                                                      |
| OnResume        | Action                    | Fired when media recording resumes after being paused.                                                                                                                                                                                                                                                                      |
| OnPause         | Action                    | Fired when media recording is paused.                                                                                                                                                                                                                                                                                       |



<br></br>
### IMediaDevicesInProcess

The *MediaDevices* interface of the Media Capture and Streams API provides access to connected media input devices like cameras and microphones, as well as screen sharing.
In essence, it lets you obtain access to any hardware source of media data.

#### Properties

| **Name**             | **Type**                       | get/set | **Description**                                                                                                                                                            |
| -------------------- | ------------------------------ | ------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| SupportedConstraints | MediaTrackSupportedConstraints | get     | Returns an object based on the MediaTrackSupportedConstraints dictionary, whose member fields each specify one of the constrainable properties the user agent understands. |

#### Methods

| **Name**                | **Parameters**                                                                                            | **ReturnType**                         | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| ----------------------- | --------------------------------------------------------------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| EnumerateDevices        | [CancellationToken cancellationToken = default]                                                           | ValueTask&lt;MediaDeviceInfo[]&gt;     | Requests a list of the currently available media input and output devices, such as microphones, cameras, headsets, and so forth. The returned Promise is resolved with an array of MediaDeviceInfo objects describing the devices.<br />The returned list will omit any devices that are blocked by the document Permission Policy: microphone, camera, speaker-selection(for output devices), and so on. Access to particular non-default devices is also gated by the Permissions API, and the list will omit devices for which the user has not granted explicit permission.                                                                                                                                                                                                             |
| GetUserMedia            | bool audio, bool video, [CancellationToken cancellationToken = default]                                   | ValueTask&lt;IMediaStreamInProcess&gt; | The getUserMedia() method of the MediaDevices interface prompts the user for permission to use a media input which produces a MediaStream with tracks containing the requested types of media.<br />That stream can include, for example, a video track (produced by either a hardware or virtual video source such as a camera, video recording device, screen sharing service, and so forth), an audio track (similarly, produced by a physical or virtual audio source like a microphone, A/D converter, or the like), and possibly other track types.<br />It returns a Promise that resolves to a MediaStream object. If the user denies permission, or matching media is not available, then the promise is rejected with NotAllowedError or NotFoundError DOMException respectively. |
| GetUserMedia            | MediaTrackConstraints audio, bool video, [CancellationToken cancellationToken = default]                  | ValueTask&lt;IMediaStreamInProcess&gt; | see Method *GetUserMedia(bool, bool, CancellationToken)*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| GetUserMedia            | bool audio, MediaTrackConstraints video, [CancellationToken cancellationToken = default]                  | ValueTask&lt;IMediaStreamInProcess&gt; | see Method *GetUserMedia(bool, bool, CancellationToken)*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| GetUserMedia            | MediaTrackConstraints audio, MediaTrackConstraints video, [CancellationToken cancellationToken = default] | ValueTask&lt;IMediaStreamInProcess&gt; | see Method *GetUserMedia(bool, bool, CancellationToken)*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| GetDisplayMedia         | bool audio, bool video, [CancellationToken cancellationToken = default]                                   | ValueTask&lt;IMediaStreamInProcess&gt; | With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
| GetDisplayMedia         | MediaTrackConstraints audio, bool video, [CancellationToken cancellationToken = default]                  | ValueTask&lt;IMediaStreamInProcess&gt; | see Method *GetDisplayMedia(bool, bool, CancellationToken)*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| GetDisplayMedia         | bool audio, MediaTrackConstraints video, [CancellationToken cancellationToken = default]                  | ValueTask&lt;IMediaStreamInProcess&gt; | see Method *GetDisplayMedia(bool, bool, CancellationToken)*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| GetDisplayMedia         | MediaTrackConstraints audio, MediaTrackConstraints video, [CancellationToken cancellationToken = default] | ValueTask&lt;IMediaStreamInProcess&gt; | see Method *GetDisplayMedia(bool, bool, CancellationToken)*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |


<br></br>
### IMediaStreamInProcess

The *MediaStream* interface of the [Media Capture and Streams API](https://developer.mozilla.org/en-US/docs/Web/API/Media_Capture_and_Streams_API) represents a stream of media content.
A stream consists of several tracks, such as video or audio tracks. Each track is specified as an instance of [MediaStreamTrack](https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrack).

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Properties

| **Name** | **Type** | get/set | **Description**                                                                         |
| -------- | -------- | ------- | --------------------------------------------------------------------------------------- |
| Active   | bool     | get     | A Boolean value that returns true if the MediaStream is active, or false otherwise.     |
| Id       | string   | get     | A string containing a 36-character universally unique identifier (UUID) for the object. |

#### Methods

| **Name**       | **Parameters**                                                                                               | **ReturnType**          | **Description**                                                                                                                                                                                                                                              |
| -------------- | ------------------------------------------------------------------------------------------------------------ | ----------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| CreateRecorder | [string mimeType = ""], [int audioBitsPerSecond = 0], [int videoBitsPerSecond = 0], [int bitsPerSecond = 0], | IMediaRecorderInProcess | Creates a new MediaRecorder object, given a MediaStream to record. Options are available to do things like set the container's MIME type (such as "video/webm" or "video/mp4") and the bit rates of the audio and video tracks or a single overall bit rate. |


<br></br>
### IMediaRecoderInProcess

The *MediaRecorder* interface of the [MediaStream Recording API](https://developer.mozilla.org/en-US/docs/Web/API/MediaStream_Recording_API) provides functionality to easily record media.

It is created using the IMediaStreamInProcess.CreateRecorder() method.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Properties

| **Name**           | **Type**              | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| ------------------ | --------------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| MimeType           | string                | get     | Returns the [MIME](https://developer.mozilla.org/en-US/docs/Glossary/MIME) media type that was specified when creating the MediaRecorder object, or, if none was specified, which was chosen by the browser. This is the file format of the file that would result from writing all of the recorded data to disk.<br />Keep in mind that not all codecs are supported by a given container; if you write media using a codec that is not supported by a given media container, the resulting file may not work reliably if at all when you try to play it back. See our [media type and format guide](https://developer.mozilla.org/en-US/docs/Web/Media/Formats) for information about container and codec support across browsers. |
| State              | string                | get     | Returns the current state of the current MediaRecorder object:<br />"inactive" - Recording is not occurring — it has either not been started yet, or it has been started and then stopped.<br />"recording" - Recording has been started and the user agent is capturing data.<br />"paused" - Recording has been started, then paused, but not yet stopped or resumed.                                                                                                                                                                                                                                                                                                                                                              |
| Stream             | IMediaStreamInProcess | get     | Returns the stream that was passed into the IMediaStreamInProcess.CreateRecorder() method when the MediaRecorder was created.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| AudioBitsPerSecond | ulong                 | get     | Returns the audio encoding bit rate in use. This may differ from the bit rate specified in the constructor, if it was provided.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| VideoBitsPerSecond | ulong                 | get     | Returns the video encoding bit rate in use. This may differ from the bit rate specified in the constructor, if it was provided.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |

#### Methods

| **Name**              | **Parameters**      | **ReturnType** | **Description**                                                                                                                                                                                                                                                                         |
| --------------------- | ------------------- | -------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Start                 | [int timeslice = 0] | void           | Begins recording media; this method can optionally be passed a timeslice argument with a value in milliseconds. If this is specified, the media will be captured in separate chunks of that duration, rather than the default behavior of recording the media in a single large chunk.  |
| Stop                  | *empty*             | void           | Stops recording, at which point a dataavailable event containing the final Blob of saved data is fired. No more recording occurs.                                                                                                                                                       |
| Resume                | *empty*             | void           | Resumes recording of media after having been paused.                                                                                                                                                                                                                                    |
| Pause                 | *empty*             | void           | Pauses the recording of media.                                                                                                                                                                                                                                                          |
| RequestData           | *empty*             | void           | Requests a Blob containing the saved data received thus far (or since the last time requestData() was called. After calling this method, recording continues, but in a new Blob.                                                                                                        |
| IsTypeSupported       | string mimeType     | bool           | The *isTypeSupported()* static method of the MediaRecorder interface returns a Boolean which is true if the MIME media type specified is one the user agent should be able to successfully record.<br />In C# this method is not static because it needs an reference to the JS-module. |

#### Events

| **Name**        | **Type**                  | **Description**                                                                                                                                                                                                                                                                                                             |
| --------------- | ------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnDataavailable | Action&lt;byte[]&gt;      | Fires periodically each time timeslice milliseconds of media have been recorded (or when the entire media has been recorded, if timeslice wasn't specified). The event, of type BlobEvent, contains the recorded media in its data property.<br />Parameter is the recorded binary data.                                    |
| OnError         | Action&lt;JsonElement&gt; | Fired when there are fatal errors that stop recording. The received event is based on the MediaRecorderErrorEvent interface, whose error property contains a DOMException that describes the actual error that occurred.<br />Parameter is of type [Event](https://developer.mozilla.org/en-US/docs/Web/API/Event) as JSON. |
| OnStart         | Action                    | Fired when media recording starts.                                                                                                                                                                                                                                                                                          |
| OnStop          | Action                    | Fired when media recording ends, either when the MediaStream ends, or after the MediaRecorder.stop() method is called.                                                                                                                                                                                                      |
| OnResume        | Action                    | Fired when media recording resumes after being paused.                                                                                                                                                                                                                                                                      |
| OnPause         | Action                    | Fired when media recording is paused.                                                                                                                                                                                                                                                                                       |
