﻿using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>MediaRecorder</i> interface of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/MediaStream_Recording_API">MediaStream Recording API</see> provides functionality to easily record media.</para>
/// <para>It is created using the <see cref="IMediaStreamInProcess.CreateRecorder">CreateRecorder() method</see>.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class MediaRecorderInProcess(IJSInProcessObjectReference mediaRecorderJS) : MediaRecorderBase(mediaRecorderJS), IMediaRecorderInProcess {
    private IJSInProcessObjectReference MediaRecorderJS => (IJSInProcessObjectReference)base.mediaRecorderJS;

    /// <summary>
    /// Stops recording and releases the JS instance for this media recorder.
    /// </summary>
    public void Dispose() {
        Stop();
        DisposeEventTrigger();
        MediaRecorderJS.Dispose();
    }


    /// <summary>
    /// <para>
    /// The <i>mimeType</i> read-only property of the MediaRecorder interface returns the <see href="https://developer.mozilla.org/en-US/docs/Glossary/MIME">MIME</see> media type that was specified when creating the MediaRecorder object,
    /// or, if none was specified, which was chosen by the browser.
    /// This is the file format of the file that would result from writing all of the recorded data to disk.
    /// </para>
    /// <para>
    /// Keep in mind that not all codecs are supported by a given container;
    /// if you write media using a codec that is not supported by a given media container, the resulting file may not work reliably if at all when you try to play it back.
    /// See our <see href="https://developer.mozilla.org/en-US/docs/Web/Media/Formats">media type and format guide</see> for information about container and codec support across browsers.
    /// </para>
    /// </summary>
    public string MimeType => MediaRecorderJS.Invoke<string>("getMimeType");

    /// <summary>
    /// <para>The <i>state</i> read-only property of the MediaRecorder interface returns the current state of the current MediaRecorder object:</para>
    /// <para>
    /// "inactive" - Recording is not occurring — it has either not been started yet, or it has been started and then stopped.<br />
    /// "recording" - Recording has been started and the user agent is capturing data.<br />
    /// "paused" - Recording has been started, then paused, but not yet stopped or resumed.
    /// </para>
    /// </summary>
    public string State => MediaRecorderJS.Invoke<string>("getState");

    /// <summary>
    /// The <i>stream</i> read-only property of the MediaRecorder interface returns the stream that was passed into the <see cref="IMediaStreamInProcess.CreateRecorder">CreateRecorder() method</see> when the MediaRecorder was created.
    /// </summary>
    public IMediaStreamInProcess Stream => new MediaStreamInProcess(MediaRecorderJS.Invoke<IJSInProcessObjectReference>("getStream"));

    /// <summary>
    /// The <i>videoBitsPerSecond</i> read-only property of the MediaRecorder interface returns the video encoding bit rate in use.<br />
    /// This may differ from the bit rate specified in the constructor, if it was provided.
    /// </summary>
    public ulong AudioBitsPerSecond => MediaRecorderJS.Invoke<ulong>("getAudioBitsPerSecond");

    /// <summary>
    /// The <i>videoBitsPerSecond</i> read-only property of the MediaRecorder interface returns the video encoding bit rate in use.<br />
    /// This may differ from the bit rate specified in the constructor, if it was provided.
    /// </summary>
    public ulong VideoBitsPerSecond => MediaRecorderJS.Invoke<ulong>("getVideoBitsPerSecond");


    /// <summary>
    /// Begins recording media; this method can optionally be passed a timeslice argument with a value in milliseconds.
    /// If this is specified, the media will be captured in separate chunks of that duration, rather than the default behavior of recording the media in a single large chunk.
    /// </summary>
    /// <param name="timeslice">
    /// <para>
    /// The number of milliseconds to record into each Blob.
    /// If this parameter isn't included (a value less or equal 0), the entire media duration is recorded into a single Blob unless the requestData() method is called to obtain the Blob
    /// and trigger the creation of a new Blob into which the media continues to be recorded.
    /// </para>
    /// <para>Note: Like other time values in web APIs, timeslice is not exact and the real intervals may be slightly longer due to other pending tasks before the creation of the next blob.</para>
    /// </param>
    /// <returns></returns>
    public void Start(int timeslice = 0) => MediaRecorderJS.InvokeVoid("start", [timeslice]);

    /// <summary>
    /// Stops recording, at which point a dataavailable event containing the final Blob of saved data is fired. No more recording occurs.
    /// </summary>
    /// <returns></returns>
    public void Stop() => MediaRecorderJS.InvokeVoid("stop");

    /// <summary>
    /// Resumes recording of media after having been paused.
    /// </summary>
    /// <returns></returns>
    public void Resume() => MediaRecorderJS.InvokeVoid("resume");

    /// <summary>
    /// Pauses the recording of media.
    /// </summary>
    /// <returns></returns>
    public void Pause() => MediaRecorderJS.InvokeVoid("pause");

    /// <summary>
    /// Requests a Blob containing the saved data received thus far (or since the last time requestData() was called.
    /// After calling this method, recording continues, but in a new Blob.
    /// </summary>
    /// <returns></returns>
    public void RequestData() => MediaRecorderJS.InvokeVoid("requestData");


    /// <summary>
    /// The <i>isTypeSupported()</i> static method of the MediaRecorder interface returns a Boolean which is true if the MIME media type specified is one the user agent should be able to successfully record.
    /// </summary>
    /// <remarks>In C# this method is not static because it needs an reference to the JS-module.</remarks>
    /// <param name="mimeType"></param>
    /// <returns></returns>
    public bool IsTypeSupported(string mimeType) => MediaRecorderJS.Invoke<bool>("isTypeSupported");
}
