using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>HTMLMediaElement</i> interface adds to HTMLElement the properties and methods needed to support basic media-related capabilities that are common to audio and video.</para>
/// <para>The <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLVideoElement">HTMLVideoElement</see> and <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLAudioElement">HTMLAudioElement</see> elements both inherit this interface.</para>
/// <para>Objects of this class must disposed manually, so do not forget to call <see cref="DisposeAsync"/> when you are done with it.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class HTMLMediaElement(Task<IJSObjectReference> htmlMediaElementTask) : HTMLMediaElementBase, IHTMLMediaElement {
    private protected override Task<IJSObjectReference> HTMLMediaElementTask { get; } = htmlMediaElementTask;


    /// <summary>
    /// Releases the JS instance for this htmlMediaElement.
    /// </summary>
    /// <returns></returns>
    public async ValueTask DisposeAsync() {
        DisposeEventTrigger();
        await (await HTMLMediaElementTask).DisposeTrySync();
    }


    // Attributes

    /// <summary>
    /// <para>A string that reflects the src HTML attribute, which contains the URL of a media resource to use.</para>
    /// <para>
    /// Note: The best way to know the URL of the media resource currently in active use in this element is to look at the value of the currentSrc attribute,
    /// which also takes into account selection of a best or preferred media resource from a list provided in an HTMLSourceElement (which represents a &lt;source&gt; element).
    /// </para>
    /// </summary>
    public ValueTask<string> Src => GetSrc(default);

    /// <summary>
    /// <para>A string that reflects the src HTML attribute, which contains the URL of a media resource to use.</para>
    /// <para>
    /// Note: The best way to know the URL of the media resource currently in active use in this element is to look at the value of the currentSrc attribute,
    /// which also takes into account selection of a best or preferred media resource from a list provided in an HTMLSourceElement (which represents a &lt;source&gt; element).
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetSrc(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<string>("getSrc", cancellationToken);

    /// <summary>
    /// <para>A string that reflects the src HTML attribute, which contains the URL of a media resource to use.</para>
    /// <para>
    /// Note: The best way to know the URL of the media resource currently in active use in this element is to look at the value of the currentSrc attribute,
    /// which also takes into account selection of a best or preferred media resource from a list provided in an HTMLSourceElement (which represents a &lt;source&gt; element).
    /// </para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetSrc(string value, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("setSrc", cancellationToken, [value]);


    /// <summary>
    /// A MediaStream representing the media to play or that has played in the current HTMLMediaElement, or null if not assigned.
    /// </summary>
    public ValueTask<IMediaStream?> SrcObject => GetSrcObject(default);

    /// <summary>
    /// A MediaStream representing the media to play or that has played in the current HTMLMediaElement, or null if not assigned.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IMediaStream?> GetSrcObject(CancellationToken cancellationToken) {
        try {
            IJSObjectReference mediaStream = await (await HTMLMediaElementTask).InvokeTrySync<IJSObjectReference>("getSrcObject", cancellationToken);
            return new MediaStream(mediaStream);
        }
        catch (JSException) {
            return null;
        }
    }

    /// <summary>
    /// A MediaStream representing the media to play or that has played in the current HTMLMediaElement, or null if not assigned.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetSrcObject(IMediaStream? value, CancellationToken cancellationToken = default)
        => await (await HTMLMediaElementTask).InvokeVoidTrySync("setSrcObject", cancellationToken, [value?.MediaStreamJS]);


    /// <summary>
    /// A boolean that reflects the controls HTML attribute, indicating whether user interface items for controlling the resource should be displayed.
    /// </summary>
    public ValueTask<bool> Controls => GetControls(default);

    /// <summary>
    /// A boolean that reflects the controls HTML attribute, indicating whether user interface items for controlling the resource should be displayed.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetControls(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<bool>("getControls", cancellationToken);

    /// <summary>
    /// A boolean that reflects the controls HTML attribute, indicating whether user interface items for controlling the resource should be displayed.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetControls(bool value, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("setControls", cancellationToken, [value]);


    /// <summary>
    /// <para>A boolean value that reflects the autoplay HTML attribute, indicating whether playback should automatically begin as soon as enough media is available to do so without interruption.</para>
    /// <para>A media element whose source is a MediaStream and whose autoplay property is true will begin playback when it becomes active(that is, when MediaStream.active becomes true).</para>
    /// </summary>
    public ValueTask<bool> Autoplay => GetAutoplay(default);

    /// <summary>
    /// <para>A boolean value that reflects the autoplay HTML attribute, indicating whether playback should automatically begin as soon as enough media is available to do so without interruption.</para>
    /// <para>A media element whose source is a MediaStream and whose autoplay property is true will begin playback when it becomes active(that is, when MediaStream.active becomes true).</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetAutoplay(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<bool>("getAutoplay", cancellationToken);

    /// <summary>
    /// <para>A boolean value that reflects the autoplay HTML attribute, indicating whether playback should automatically begin as soon as enough media is available to do so without interruption.</para>
    /// <para>A media element whose source is a MediaStream and whose autoplay property is true will begin playback when it becomes active(that is, when MediaStream.active becomes true).</para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAutoplay(bool value, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("setAutoplay", cancellationToken, [value]);


    /// <summary>
    /// A boolean that reflects the loop HTML attribute, which indicates whether the media element should start over when it reaches the end.
    /// </summary>
    public ValueTask<bool> Loop => GetLoop(default);

    /// <summary>
    /// A boolean that reflects the loop HTML attribute, which indicates whether the media element should start over when it reaches the end.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetLoop(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<bool>("getLoop", cancellationToken);

    /// <summary>
    /// A boolean that reflects the loop HTML attribute, which indicates whether the media element should start over when it reaches the end.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetLoop(bool value, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("setLoop", cancellationToken, [value]);


    /// <summary>
    /// <para>A boolean that reflects the muted HTML attribute, which indicates whether the media element's audio output should be muted by default.</para>
    /// <para>This property has no dynamic effect. To mute and unmute the audio output, use the muted property.</para>
    /// </summary>
    public ValueTask<bool> DefaultMuted => GetDefaultMuted(default);

    /// <summary>
    /// <para>A boolean that reflects the muted HTML attribute, which indicates whether the media element's audio output should be muted by default.</para>
    /// <para>This property has no dynamic effect. To mute and unmute the audio output, use the muted property.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetDefaultMuted(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<bool>("getDefaultMuted", cancellationToken);

    /// <summary>
    /// <para>A boolean that reflects the muted HTML attribute, which indicates whether the media element's audio output should be muted by default.</para>
    /// <para>This property has no dynamic effect. To mute and unmute the audio output, use the muted property.</para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetDefaultMuted(bool value, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("setDefaultMuted", cancellationToken, [value]);


    /// <summary>
    /// <para>A string that reflects the preload HTML attribute, indicating what data should be preloaded, if any.</para>
    /// <para>
    /// Possible values are:<br />
    /// - "none": Indicates that the media should not be preloaded.<br />
    /// - "metadata": Indicates that only media metadata (e.g. length) is fetched.<br />
    /// - "auto": Indicates that the whole media file can be downloaded, even if the user is not expected to use it.<br />
    /// - "": A synonym of the auto value.
    /// </para>
    /// </summary>
    public ValueTask<string> Preload => GetPreload(default);

    /// <summary>
    /// <para>A string that reflects the preload HTML attribute, indicating what data should be preloaded, if any.</para>
    /// <para>
    /// Possible values are:<br />
    /// - "none": Indicates that the media should not be preloaded.<br />
    /// - "metadata": Indicates that only media metadata (e.g. length) is fetched.<br />
    /// - "auto": Indicates that the whole media file can be downloaded, even if the user is not expected to use it.<br />
    /// - "": A synonym of the auto value.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetPreload(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<string>("getPreload", cancellationToken);

    /// <summary>
    /// <para>A string that reflects the preload HTML attribute, indicating what data should be preloaded, if any.</para>
    /// <para>
    /// Possible values are:<br />
    /// - "none": Indicates that the media should not be preloaded.<br />
    /// - "metadata": Indicates that only media metadata (e.g. length) is fetched.<br />
    /// - "auto": Indicates that the whole media file can be downloaded, even if the user is not expected to use it.<br />
    /// - "": A synonym of the auto value.
    /// </para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetPreload(string value, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("setPreload", cancellationToken, [value]);


    // State

    /// <summary>
    /// <para>Returns a string with the absolute URL of the chosen media resource.</para>
    /// <para>This could happen, for example, if the web server selects a media file based on the resolution of the user's display. The value is an empty string if the networkState property is EMPTY.</para>
    /// </summary>
    public ValueTask<string> CurrentSrc => GetCurrentSrc(default);

    /// <summary>
    /// <para>Returns a string with the absolute URL of the chosen media resource.</para>
    /// <para>This could happen, for example, if the web server selects a media file based on the resolution of the user's display. The value is an empty string if the networkState property is EMPTY.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetCurrentSrc(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<string>("getCurrentSrc", cancellationToken);


    /// <summary>
    /// <para>A double-precision floating-point value indicating the current playback time in seconds.</para>
    /// <para>
    /// if the media has not started to play and has not been seeked, this value is the media's initial playback time.
    /// Setting this value seeks the media to the new time. The time is specified relative to the media's timeline.
    /// </para>
    /// </summary>
    public ValueTask<double> CurrentTime => GetCurrentTime(default);

    /// <summary>
    /// <para>A double-precision floating-point value indicating the current playback time in seconds.</para>
    /// <para>
    /// if the media has not started to play and has not been seeked, this value is the media's initial playback time.
    /// Setting this value seeks the media to the new time. The time is specified relative to the media's timeline.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<double> GetCurrentTime(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<double>("getCurrentTime", cancellationToken);

    /// <summary>
    /// <para>A double-precision floating-point value indicating the current playback time in seconds</para>
    /// <para>
    /// if the media has not started to play and has not been seeked, this value is the media's initial playback time.
    /// Setting this value seeks the media to the new time. The time is specified relative to the media's timeline.
    /// </para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetCurrentTime(double value, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("setCurrentTime", cancellationToken, [value]);


    /// <summary>
    /// <para>A read-only double-precision floating-point value indicating the total duration of the media in seconds.</para>
    /// <para>
    /// If no media data is available, the returned value is NaN.<br />
    /// If the media is of indefinite length (such as streamed live media, a WebRTC call's media, or similar), the value is +Infinity.
    /// </para>
    /// </summary>
    public ValueTask<double> Duration => GetDuration(default);

    /// <summary>
    /// <para>A read-only double-precision floating-point value indicating the total duration of the media in seconds.</para>
    /// <para>
    /// If no media data is available, the returned value is NaN.<br />
    /// If the media is of indefinite length (such as streamed live media, a WebRTC call's media, or similar), the value is +Infinity.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<double> GetDuration(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<double>("getDuration", cancellationToken);


    /// <summary>
    /// Returns a TimeRanges object that contains the time ranges that the user is able to seek to.
    /// </summary>
    public ValueTask<TimeRange[]> Seekable => GetSeekable(default);

    /// <summary>
    /// Returns a TimeRanges object that contains the time ranges that the user is able to seek to.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TimeRange[]> GetSeekable(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<TimeRange[]>("getSeekable", cancellationToken);


    /// <summary>
    /// <para>A boolean that determines whether audio is muted. true if the audio is muted and false otherwise.</para>
    /// <para>true means muted and false means not muted.</para>
    /// </summary>
    public ValueTask<bool> Muted => GetMuted(default);

    /// <summary>
    /// <para>A boolean that determines whether audio is muted. true if the audio is muted and false otherwise.</para>
    /// <para>true means muted and false means not muted.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetMuted(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<bool>("getMuted", cancellationToken);

    /// <summary>
    /// <para>A boolean that determines whether audio is muted. true if the audio is muted and false otherwise.</para>
    /// <para>true means muted and false means not muted.</para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetMuted(bool value, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("setMuted", cancellationToken, [value]);


    /// <summary>
    /// A double indicating the audio volume, from 0.0 (silent) to 1.0 (loudest).
    /// </summary>
    public ValueTask<double> Volume => GetVolume(default);

    /// <summary>
    /// A double indicating the audio volume, from 0.0 (silent) to 1.0 (loudest).
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<double> GetVolume(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<double>("getVolume", cancellationToken);

    /// <summary>
    /// A double indicating the audio volume, from 0.0 (silent) to 1.0 (loudest).
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetVolume(double value, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("setVolume", cancellationToken, [value]);


    /// <summary>
    /// <para>Returns a boolean that indicates whether the media element is paused.</para>
    /// <para>true is paused and false is not paused.</para>
    /// </summary>
    public ValueTask<bool> Paused => GetPaused(default);

    /// <summary>
    /// <para>Returns a boolean that indicates whether the media element is paused.</para>
    /// <para>true is paused and false is not paused.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetPaused(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<bool>("getPaused", cancellationToken);


    /// <summary>
    /// <para>Returns a boolean that indicates whether the media element has finished playing.</para>
    /// <para>true if the media contained in the element has finished playing.</para>
    /// <para>If the source of the media is a MediaStream, this value is true if the value of the stream's active property is false.</para>
    /// </summary>
    public ValueTask<bool> Ended => GetEnded(default);

    /// <summary>
    /// <para>Returns a boolean that indicates whether the media element has finished playing.</para>
    /// <para>true if the media contained in the element has finished playing.</para>
    /// <para>If the source of the media is a MediaStream, this value is true if the value of the stream's active property is false.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetEnded(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<bool>("getEnded", cancellationToken);


    /// <summary>
    /// Returns a boolean that indicates whether the media is in the process of seeking to a new position.
    /// </summary>
    public ValueTask<bool> Seeking => GetSeeking(default);

    /// <summary>
    /// Returns a boolean that indicates whether the media is in the process of seeking to a new position.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetSeeking(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<bool>("getSeeking", cancellationToken);


    /// <summary>
    /// <para>Returns a unsigned short (enumeration) indicating the readiness state of the media.</para>
    /// <para>
    /// Possible values are:<br />
    /// 0 = HAVE_NOTHING: No information is available about the media resource.<br />
    /// 1 = HAVE_METADATA: Enough of the media resource has been retrieved that the metadata attributes are initialized. Seeking will no longer raise an exception.<br />
    /// 2 = HAVE_CURRENT_DATA: Data is available for the current playback position, but not enough to actually play more than one frame.<br />
    /// 3 = HAVE_FUTURE_DATA: Data for the current playback position as well as for at least a little bit of time into the future is available (in other words, at least two frames of video, for example).<br />
    /// 4 = HAVE_ENOUGH_DATA: Enough data is available—and the download rate is high enough—that the media can be played through to the end without interruption.
    /// </para>
    /// </summary>
    public ValueTask<int> ReadyState => GetReadyState(default);

    /// <summary>
    /// <para>Returns a unsigned short (enumeration) indicating the readiness state of the media.</para>
    /// <para>
    /// Possible values are:<br />
    /// 0 = HAVE_NOTHING: No information is available about the media resource.<br />
    /// 1 = HAVE_METADATA: Enough of the media resource has been retrieved that the metadata attributes are initialized. Seeking will no longer raise an exception.<br />
    /// 2 = HAVE_CURRENT_DATA: Data is available for the current playback position, but not enough to actually play more than one frame.<br />
    /// 3 = HAVE_FUTURE_DATA: Data for the current playback position as well as for at least a little bit of time into the future is available (in other words, at least two frames of video, for example).<br />
    /// 4 = HAVE_ENOUGH_DATA: Enough data is available—and the download rate is high enough—that the media can be played through to the end without interruption.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetReadyState(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<int>("getReadyState", cancellationToken);


    /// <summary>
    /// <para>Returns a unsigned short (enumeration) indicating the current state of fetching the media over the network.</para>
    /// <para>
    /// Possible values are:<br />
    /// 0 = NETWORK_EMPTY: There is no data yet. Also, readyState is HAVE_NOTHING.<br />
    /// 1 = NETWORK_IDLE: HTMLMediaElement is active and has selected a resource, but is not using the network.<br />
    /// 2 = NETWORK_LOADING: The browser is downloading HTMLMediaElement data.<br />
    /// 3 = NETWORK_NO_SOURCE: No HTMLMediaElement src found.
    /// </para>
    /// </summary>
    public ValueTask<int> NetworkState => GetNetworkState(default);

    /// <summary>
    /// <para>Returns a unsigned short (enumeration) indicating the current state of fetching the media over the network.</para>
    /// <para>
    /// Possible values are:<br />
    /// 0 = NETWORK_EMPTY: There is no data yet. Also, readyState is HAVE_NOTHING.<br />
    /// 1 = NETWORK_IDLE: HTMLMediaElement is active and has selected a resource, but is not using the network.<br />
    /// 2 = NETWORK_LOADING: The browser is downloading HTMLMediaElement data.<br />
    /// 3 = NETWORK_NO_SOURCE: No HTMLMediaElement src found.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetNetworkState(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<int>("getNetworkState", cancellationToken);


    /// <summary>
    /// Returns a TimeRanges object that indicates the ranges of the media source that the browser has buffered (if any) at the moment the buffered property is accessed.
    /// </summary>
    public ValueTask<TimeRange[]> Buffered => GetBuffered(default);

    /// <summary>
    /// Returns a TimeRanges object that indicates the ranges of the media source that the browser has buffered (if any) at the moment the buffered property is accessed.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TimeRange[]> GetBuffered(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<TimeRange[]>("getBuffered", cancellationToken);


    /// <summary>
    /// Returns a TimeRanges object that contains the ranges of the media source that the browser has played, if any.
    /// </summary>
    public ValueTask<TimeRange[]> Played => GetPlayed(default);

    /// <summary>
    /// Returns a TimeRanges object that contains the ranges of the media source that the browser has played, if any.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TimeRange[]> GetPlayed(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<TimeRange[]>("getPlayed", cancellationToken);


    // Settings

    /// <summary>
    /// <para>A double that indicates the rate at which the media is being played back.</para>
    /// <para>
    /// This is used to implement user controls for fast forward, slow motion, and so forth.<br />
    /// The normal playback rate is multiplied by this value to obtain the current rate, so a value of 1.0 indicates normal speed.
    /// </para>
    /// <para>A negative playbackRate value indicates that the media should be played backwards, but support for this is not yet widespread.</para>
    /// <para>The audio is muted when the fast forward or slow motion is outside a useful range(for example, Gecko mutes the sound outside the range 0.25 to 4.0).</para>
    /// <para>The pitch of the audio is corrected by default. You can disable pitch correction using the HTMLMediaElement.preservesPitch property.</para>
    /// </summary>
    public ValueTask<double> PlaybackRate => GetPlaybackRate(default);

    /// <summary>
    /// <para>A double that indicates the rate at which the media is being played back.</para>
    /// <para>
    /// This is used to implement user controls for fast forward, slow motion, and so forth.<br />
    /// The normal playback rate is multiplied by this value to obtain the current rate, so a value of 1.0 indicates normal speed.
    /// </para>
    /// <para>A negative playbackRate value indicates that the media should be played backwards, but support for this is not yet widespread.</para>
    /// <para>The audio is muted when the fast forward or slow motion is outside a useful range(for example, Gecko mutes the sound outside the range 0.25 to 4.0).</para>
    /// <para>The pitch of the audio is corrected by default. You can disable pitch correction using the HTMLMediaElement.preservesPitch property.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<double> GetPlaybackRate(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<double>("getPlaybackRate", cancellationToken);

    /// <summary>
    /// <para>A double that indicates the rate at which the media is being played back.</para>
    /// <para>
    /// This is used to implement user controls for fast forward, slow motion, and so forth.<br />
    /// The normal playback rate is multiplied by this value to obtain the current rate, so a value of 1.0 indicates normal speed.
    /// </para>
    /// <para>A negative playbackRate value indicates that the media should be played backwards, but support for this is not yet widespread.</para>
    /// <para>The audio is muted when the fast forward or slow motion is outside a useful range(for example, Gecko mutes the sound outside the range 0.25 to 4.0).</para>
    /// <para>The pitch of the audio is corrected by default. You can disable pitch correction using the HTMLMediaElement.preservesPitch property.</para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetPlaybackRate(double value, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("setPlaybackRate", cancellationToken, [value]);


    /// <summary>
    /// <para>A double indicating the default playback rate for the media.</para>
    /// <para>A double. 1.0 is "normal speed," values lower than 1.0 make the media play slower than normal, higher values make it play faster.</para>
    /// </summary>
    public ValueTask<double> DefaultPlaybackRate => GetDefaultPlaybackRate(default);

    /// <summary>
    /// <para>A double indicating the default playback rate for the media.</para>
    /// <para>A double. 1.0 is "normal speed," values lower than 1.0 make the media play slower than normal, higher values make it play faster.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<double> GetDefaultPlaybackRate(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<double>("getDefaultPlaybackRate", cancellationToken);

    /// <summary>
    /// <para>A double indicating the default playback rate for the media.</para>
    /// <para>A double. 1.0 is "normal speed," values lower than 1.0 make the media play slower than normal, higher values make it play faster.</para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetDefaultPlaybackRate(double value, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("setDefaultPlaybackRate", cancellationToken, [value]);


    /// <summary>
    /// <para>A string indicating the CORS setting for this media element. See <see href="https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/crossorigin">CORS settings attributes</see> for details.</para>
    /// <para>
    /// Possible values are:<br />
    /// "anonymous":
    /// Requests sent by the HTMLMediaElement will use the <i>cors</i> mode and the <i>same-origin</i> credentials mode.
    /// This means that CORS is enabled and credentials are sent if the resource is fetched from the same origin from which the document was loaded.<br />
    /// "use-credentials":
    /// Requests sent by the HTMLMediaElement will use the <i>cors</i> mode and the <i>include</i> credentials mode.
    /// All resources requests by the element will use CORS, regardless of what domain the fetch is from.<br />
    /// "" (or any other value):
    /// The same as specifing as "anonymous".
    /// </para>
    /// <para>If the <i>crossOrigin</i> property is not specified, the resource is fetched without CORS (the <i>no-cors</i> mode and the <i>same-origin</i> credentials mode).</para>
    /// </summary>
    public ValueTask<string> CrossOrigin => GetCrossOrigin(default);

    /// <summary>
    /// <para>A string indicating the CORS setting for this media element. See <see href="https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/crossorigin">CORS settings attributes</see> for details.</para>
    /// <para>
    /// Possible values are:<br />
    /// "anonymous":
    /// Requests sent by the HTMLMediaElement will use the <i>cors</i> mode and the <i>same-origin</i> credentials mode.
    /// This means that CORS is enabled and credentials are sent if the resource is fetched from the same origin from which the document was loaded.<br />
    /// "use-credentials":
    /// Requests sent by the HTMLMediaElement will use the <i>cors</i> mode and the <i>include</i> credentials mode.
    /// All resources requests by the element will use CORS, regardless of what domain the fetch is from.<br />
    /// "" (or any other value):
    /// The same as specifing as "anonymous".
    /// </para>
    /// <para>If the <i>crossOrigin</i> property is not specified, the resource is fetched without CORS (the <i>no-cors</i> mode and the <i>same-origin</i> credentials mode).</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetCrossOrigin(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<string>("getCrossOrigin", cancellationToken);

    /// <summary>
    /// <para>A string indicating the CORS setting for this media element. See <see href="https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/crossorigin">CORS settings attributes</see> for details.</para>
    /// <para>
    /// Possible values are:<br />
    /// "anonymous":
    /// Requests sent by the HTMLMediaElement will use the <i>cors</i> mode and the <i>same-origin</i> credentials mode.
    /// This means that CORS is enabled and credentials are sent if the resource is fetched from the same origin from which the document was loaded.<br />
    /// "use-credentials":
    /// Requests sent by the HTMLMediaElement will use the <i>cors</i> mode and the <i>include</i> credentials mode.
    /// All resources requests by the element will use CORS, regardless of what domain the fetch is from.<br />
    /// "" (or any other value):
    /// The same as specifing as "anonymous".
    /// </para>
    /// <para>If the <i>crossOrigin</i> property is not specified, the resource is fetched without CORS (the <i>no-cors</i> mode and the <i>same-origin</i> credentials mode).</para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetCrossOrigin(string value, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("setCrossOrigin", cancellationToken, [value]);


    /// <summary>
    /// <para>
    /// A boolean value that determines if the pitch of the sound will be preserved.<br />
    /// If set to false, the pitch will adjust to the speed of the audio.</para>
    /// <para>Default is true.</para>
    /// </summary>
    public ValueTask<bool> PreservesPitch => GetPreservesPitch(default);

    /// <summary>
    /// <para>
    /// A boolean value that determines if the pitch of the sound will be preserved.<br />
    /// If set to false, the pitch will adjust to the speed of the audio.</para>
    /// <para>Default is true.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetPreservesPitch(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<bool>("getPreservesPitch", cancellationToken);

    /// <summary>
    /// <para>
    /// A boolean value that determines if the pitch of the sound will be preserved.<br />
    /// If set to false, the pitch will adjust to the speed of the audio.
    /// </para>
    /// <para>Default is true.</para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetPreservesPitch(bool value, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("setPreservesPitch", cancellationToken, [value]);


    /// <summary>
    /// <para>A boolean that sets or returns the remote playback state, indicating whether the media element is allowed to have a remote playback UI.</para>
    /// <para>false means "not disabled", which means "enabled"</para>
    /// </summary>
    public ValueTask<bool> DisableRemotePlayback => GetDisableRemotePlayback(default);

    /// <summary>
    /// <para>A boolean that sets or returns the remote playback state, indicating whether the media element is allowed to have a remote playback UI.</para>
    /// <para>false means "not disabled", which means "enabled"</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetDisableRemotePlayback(CancellationToken cancellationToken) => await (await HTMLMediaElementTask).InvokeTrySync<bool>("getDisableRemotePlayback", cancellationToken);

    /// <summary>
    /// <para>A boolean that sets or returns the remote playback state, indicating whether the media element is allowed to have a remote playback UI.</para>
    /// <para>false means "not disabled", which means "enabled"</para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetDisableRemotePlayback(bool value, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("setDisableRemotePlayback", cancellationToken, [value]);


    // Methods

    /// play() is declared in HTMLMediaElementBase

    /// <summary>
    /// <para>Pauses the media playback.</para>
    /// <para>If the media is already in a paused state this method will have no effect.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Pause(CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("pause", cancellationToken);

    /// <summary>
    /// Resets the media to the beginning and selects the best available source from the sources provided using the <i>src</i> attribute or the <i>&lt;source&gt;</i> element.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Load(CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("load", cancellationToken);

    /// <summary>
    /// <para>Quickly seeks to the given time with low precision.</para>
    /// <para>Note: If you need to seek with precision, you should set HTMLMediaElement.currentTime instead.</para>
    /// </summary>
    /// <param name="time"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask FastSeek(double time, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidTrySync("fastSeek", cancellationToken, [time]);

    /// <summary>
    /// Given a string specifying a MIME media type (potentially with the codecs parameter included), canPlayType() returns the string<br />
    /// - "probably", if the media should be playable<br />
    /// - "maybe", if there's not enough information to determine whether the media will play or not<br />
    /// - "", if the media cannot be played
    /// </summary>
    /// <param name="type">A string specifying the MIME type of the media and (optionally) a codecs parameter containing a comma-separated list of the supported codecs.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>"probably", "maybe" or ""</returns>
    public async ValueTask<string> CanPlayType(string type, CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeTrySync<string>("canPlayType", cancellationToken, [type]);
}
