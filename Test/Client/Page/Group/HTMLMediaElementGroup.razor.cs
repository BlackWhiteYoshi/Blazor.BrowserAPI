using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class HTMLMediaElementGroup : ComponentBase, IAsyncDisposable {
    public const string TEST_SRC = "<src>-test";
    public const string TEST_SET_SRC_OBJECT = "set src object done";
    public const string TEST_PRELOAD = "none";
    public const double TEST_CURRENT_TIME = 10.0;
    public const double TEST_VOLUME = 0.6;
    public const double TEST_PLAYBACK_RATE = 0.5;
    public const double TEST_DEFAULT_PLAYBACK_RATE = 0.3;
    public const string TEST_CROSS_ORIGIN = "use-credentials";
    public const int TEST_VIDEO_WIDTH = 200;
    public const int TEST_VIDEO_HEIGHT = 100;
    public const string TEST_VIDEO_POSTER = "data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' viewBox='-4 -4 8 8'><circle cx='0' cy='0' r='4' fill='%23484' /></svg>";
    public const string TEST_EVENT_PICTURE_IN_PICTURE_WINDOW_RESIZE = "pictureInPictureWindow resized";
    public const double TEST_FAST_SEEK = 20.0;
    public const string TEST_EVENT_ERROR = "Error";
    public const string TEST_EVENT_CAN_PLAY = "CanPlay event";
    public const string TEST_EVENT_CAN_PLAY_THROUGH = "CanPlayThrough event";
    public const string TEST_EVENT_PLAYING = "Playing event";
    public const string TEST_EVENT_LOAD_START = "LoadStart event";
    public const string TEST_EVENT_PROGRESS = "Progress event";
    public const string TEST_EVENT_LOADED_DATA = "LoadedData event";
    public const string TEST_EVENT_LOADED_METADATA = "LoadedMetadata event";
    public const string TEST_EVENT_STALLED = "stalled event";
    public const string TEST_EVENT_SUSPEND = "Suspend event";
    public const string TEST_EVENT_WAITING = "Waiting event";
    public const string TEST_EVENT_ABORT = "Abort event";
    public const string TEST_EVENT_EMPTIED = "Emptied event";
    public const string TEST_EVENT_PLAY = "Play event";
    public const string TEST_EVENT_PAUSE = "Pause event";
    public const string TEST_EVENT_ENDED = "Ended event";
    public const string TEST_EVENT_SEEKING = "Seeking event";
    public const string TEST_EVENT_SEEKED = "Seeked event";
    public const string TEST_EVENT_TIME_UPDATE = "TimeUpdate event";
    public const string TEST_EVENT_VOLUME_CHANGE = "VolumeChange event";
    public const string TEST_EVENT_RATE_CHANGE = "RateChange event";
    public const string TEST_EVENT_DURATION_CHANGE = "DurationChange event";
    public const string TEST_EVENT_RESIZE = "Resize event";
    public const string TEST_EVENT_ENTER_PICTURE_IN_PICTURE = "EnterPictureInPicture event";
    public const string TEST_EVENT_LEAVE_PICTURE_IN_PICTURE = "LeavePictureInPicture event";


    [Inject]
    public required IElementFactory ElementFactory { private get; init; }


    private IHTMLMediaElement? _audioElement;
    private IHTMLMediaElement AudioElement => _audioElement ??= ElementFactory.CreateHTMLMediaElement(audioElement);

    public const string AUDIO_ELEMENT = "htmlmediaelement-audio-element";
    private ElementReference audioElement;


    private IHTMLMediaElement? _videoElement;
    private IHTMLMediaElement VideoElement => _videoElement ??= ElementFactory.CreateHTMLMediaElement(videoElement);

    public const string VIDEO_ELEMENT = "htmlmediaelement-video-element";
    private ElementReference videoElement;


    public const string LABEL_OUTPUT = "htmlmediaelement-output";
    private string labelOutput = string.Empty;


    public async ValueTask DisposeAsync() {
        if (_audioElement is not null)
            await _audioElement.DisposeAsync();
        if (_videoElement is not null)
            await _videoElement.DisposeAsync();
    }


    #region Attributes

    public const string BUTTON_GET_SRC_PROPERTY = "htmlmediaelement-get-src-property";
    private async Task GetSrc_Property() {
        string value = await AudioElement.Src;
        labelOutput = value;
    }

    public const string BUTTON_GET_SRC_METHOD = "htmlmediaelement-get-src-method";
    private async Task GetSrc_Method() {
        string value = await AudioElement.GetSrc(default);
        labelOutput = value;
    }

    public const string BUTTON_SET_SRC = "htmlmediaelement-set-src";
    private async Task SetSrc() {
        await AudioElement.SetSrc(TEST_SRC);
    }


    public const string BUTTON_GET_SRC_OBJECT_PROPERTY = "htmlmediaelement-get-src-object-property";
    private async Task GetSrcObject_Property() {
        IMediaStream? value = await AudioElement.SrcObject;
        labelOutput = (value is not null).ToString();
        if (value != null)
            await value.DisposeAsync();
    }

    public const string BUTTON_GET_SRC_OBJECT_METHOD = "htmlmediaelement-get-src-object-method";
    private async Task GetSrcObject_Method() {
        IMediaStream? value = await AudioElement.GetSrcObject(default);
        labelOutput = (value is not null).ToString();
        if (value != null)
            await value.DisposeAsync();
    }

    public const string BUTTON_SET_SRC_OBJECT = "htmlmediaelement-set-src-object";
    private async Task SetSrcObject() {
        await AudioElement.SetSrcObject(null);
        labelOutput = TEST_SET_SRC_OBJECT;
    }


    public const string BUTTON_GET_CONTROLS_PROPERTY = "htmlmediaelement-get-controls-property";
    private async Task GetControls_Property() {
        bool value = await AudioElement.Controls;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_CONTROLS_METHOD = "htmlmediaelement-get-controls-method";
    private async Task GetControls_Method() {
        bool value = await AudioElement.GetControls(default);
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_CONTROLS = "htmlmediaelement-set-controls";
    private async Task SetControls() {
        await AudioElement.SetControls(false);
    }


    public const string BUTTON_GET_AUTOPLAY_PROPERTY = "htmlmediaelement-get-autoplay-property";
    private async Task GetAutoplay_Property() {
        bool value = await AudioElement.Autoplay;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_AUTOPLAY_METHOD = "htmlmediaelement-get-autoplay-method";
    private async Task GetAutoplay_Method() {
        bool value = await AudioElement.GetAutoplay(default);
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_AUTOPLAY = "htmlmediaelement-set-autoplay";
    private async Task SetAutoplay() {
        await AudioElement.SetAutoplay(true);
    }


    public const string BUTTON_GET_LOOP_PROPERTY = "htmlmediaelement-get-loop-property";
    private async Task GetLoop_Property() {
        bool value = await AudioElement.Loop;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_LOOP_METHOD = "htmlmediaelement-get-loop-method";
    private async Task GetLoop_Method() {
        bool value = await AudioElement.GetLoop(default);
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_LOOP = "htmlmediaelement-set-loop";
    private async Task SetLoop() {
        await AudioElement.SetLoop(true);
    }


    public const string BUTTON_GET_DEFAULT_MUTED_PROPERTY = "htmlmediaelement-get-default-muted-property";
    private async Task GetDefaultMuted_Property() {
        bool value = await AudioElement.DefaultMuted;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_DEFAULT_MUTED_METHOD = "htmlmediaelement-get-default-muted-method";
    private async Task GetDefaultMuted_Method() {
        bool value = await AudioElement.GetDefaultMuted(default);
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_DEFAULT_MUTED = "htmlmediaelement-set-default-muted";
    private async Task SetDefaultMuted() {
        await AudioElement.SetDefaultMuted(true);
    }


    public const string BUTTON_GET_PRELOAD_PROPERTY = "htmlmediaelement-get-preload-property";
    private async Task GetPreload_Property() {
        string value = await AudioElement.Preload;
        labelOutput = value;
    }

    public const string BUTTON_GET_PRELOAD_METHOD = "htmlmediaelement-get-preload-method";
    private async Task GetPreload_Method() {
        string value = await AudioElement.GetPreload(default);
        labelOutput = value;
    }

    public const string BUTTON_SET_PRELOAD = "htmlmediaelement-set-preload";
    private async Task SetPreload() {
        await AudioElement.SetPreload(TEST_PRELOAD);
    }

    #endregion


    #region State

    public const string BUTTON_GET_CURRENT_SRC_PROPERTY = "htmlmediaelement-get-current-src-property";
    private async Task GetCurrentSrc_Property() {
        string value = await AudioElement.CurrentSrc;
        labelOutput = value;
    }

    public const string BUTTON_GET_CURRENT_SRC_METHOD = "htmlmediaelement-get-current-src-method";
    private async Task GetCurrentSrc_Method() {
        string value = await AudioElement.GetCurrentSrc(default);
        labelOutput = value;
    }


    public const string BUTTON_GET_CURRENT_TIME_PROPERTY = "htmlmediaelement-get-current-time-property";
    private async Task GetCurrentTime_Property() {
        double value = await AudioElement.CurrentTime;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_CURRENT_TIME_METHOD = "htmlmediaelement-get-current-time-method";
    private async Task GetCurrentTime_Method() {
        double value = await AudioElement.GetCurrentTime(default);
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_CURRENT_TIME = "htmlmediaelement-set-current-time";
    private async Task SetCurrentTime() {
        await AudioElement.SetCurrentTime(TEST_CURRENT_TIME);
    }


    public const string BUTTON_GET_DURATION_PROPERTY = "htmlmediaelement-get-duration-property";
    private async Task GetDuration_Property() {
        double value = await AudioElement.Duration;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_DURATION_METHOD = "htmlmediaelement-get-duration-method";
    private async Task GetDuration_Method() {
        double value = await AudioElement.GetDuration(default);
        labelOutput = value.ToString();
    }


    public const string BUTTON_GET_SEEKABLE_PROPERTY = "htmlmediaelement-get-seekable-property";
    private async Task GetSeekable_Property() {
        TimeRange[] value = await AudioElement.Seekable;
        labelOutput = $"{value.Length}: {string.Join(", ", value.Select((TimeRange timeRange) => $"[{timeRange.Start}, {timeRange.End}]"))}";
    }

    public const string BUTTON_GET_SEEKABLE_METHOD = "htmlmediaelement-get-seekable-method";
    private async Task GetSeekable_Method() {
        TimeRange[] value = await AudioElement.GetSeekable(default);
        labelOutput = $"{value.Length}: {string.Join(", ", value.Select((TimeRange timeRange) => $"[{timeRange.Start}, {timeRange.End}]"))}";
    }


    public const string BUTTON_GET_MUTED_PROPERTY = "htmlmediaelement-get-muted-property";
    private async Task GetMuted_Property() {
        bool value = await AudioElement.Muted;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_MUTED_METHOD = "htmlmediaelement-get-muted-method";
    private async Task GetMuted_Method() {
        bool value = await AudioElement.GetMuted(default);
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_MUTED = "htmlmediaelement-set-muted";
    private async Task SetMuted() {
        await AudioElement.SetMuted(true);
    }


    public const string BUTTON_GET_VOLUME_PROPERTY = "htmlmediaelement-get-volume-property";
    private async Task GetVolume_Property() {
        double value = await AudioElement.Volume;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_VOLUME_METHOD = "htmlmediaelement-get-volume-method";
    private async Task GetVolume_Method() {
        double value = await AudioElement.GetVolume(default);
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_VOLUME = "htmlmediaelement-set-volume";
    private async Task SetVolume() {
        await AudioElement.SetVolume(TEST_VOLUME);
    }


    public const string BUTTON_GET_PAUSED_PROPERTY = "htmlmediaelement-get-paused-property";
    private async Task GetPaused_Property() {
        bool value = await AudioElement.Paused;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_PAUSED_METHOD = "htmlmediaelement-get-paused-method";
    private async Task GetPaused_Method() {
        bool value = await AudioElement.GetPaused(default);
        labelOutput = value.ToString();
    }


    public const string BUTTON_GET_ENDED_PROPERTY = "htmlmediaelement-get-ended-property";
    private async Task GetEnded_Property() {
        bool value = await AudioElement.Ended;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_ENDED_METHOD = "htmlmediaelement-get-ended-method";
    private async Task GetEnded_Method() {
        bool value = await AudioElement.GetEnded(default);
        labelOutput = value.ToString();
    }


    public const string BUTTON_GET_SEEKING_PROPERTY = "htmlmediaelement-get-seeking-property";
    private async Task GetSeeking_Property() {
        bool value = await AudioElement.Seeking;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_SEEKING_METHOD = "htmlmediaelement-get-seeking-method";
    private async Task GetSeeking_Method() {
        bool value = await AudioElement.GetSeeking(default);
        labelOutput = value.ToString();
    }


    public const string BUTTON_GET_READY_STATE_PROPERTY = "htmlmediaelement-get-ready-state-property";
    private async Task GetReadyState_Property() {
        int value = await AudioElement.ReadyState;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_READY_STATE_METHOD = "htmlmediaelement-get-ready-state-method";
    private async Task GetReadyState_Method() {
        int value = await AudioElement.GetReadyState(default);
        labelOutput = value.ToString();
    }


    public const string BUTTON_GET_NETWORK_STATE_PROPERTY = "htmlmediaelement-get-network-state-property";
    private async Task GetNetworkState_Property() {
        int value = await AudioElement.NetworkState;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_NETWORK_STATE_METHOD = "htmlmediaelement-get-network-state-method";
    private async Task GetNetworkState_Method() {
        int value = await AudioElement.GetNetworkState(default);
        labelOutput = value.ToString();
    }


    public const string BUTTON_GET_BUFFERED_PROPERTY = "htmlmediaelement-get-buffered-property";
    private async Task GetBuffered_Property() {
        TimeRange[] value = await AudioElement.Buffered;
        labelOutput = $"{value.Length}: {string.Join(", ", value.Select((TimeRange timeRange) => $"[{timeRange.Start}, {timeRange.End}]"))}";
    }

    public const string BUTTON_GET_BUFFERED_METHOD = "htmlmediaelement-get-buffered-method";
    private async Task GetBuffered_Method() {
        TimeRange[] value = await AudioElement.GetBuffered(default);
        labelOutput = $"{value.Length}: {string.Join(", ", value.Select((TimeRange timeRange) => $"[{timeRange.Start}, {timeRange.End}]"))}";
    }


    public const string BUTTON_GET_PLAYED_PROPERTY = "htmlmediaelement-get-played-property";
    private async Task GetPlayed_Property() {
        TimeRange[] value = await AudioElement.Played;
        labelOutput = $"{value.Length}: {string.Join(", ", value.Select((TimeRange timeRange) => $"[{timeRange.Start}, {timeRange.End}]"))}";
    }

    public const string BUTTON_GET_PLAYED_METHOD = "htmlmediaelement-get-played-method";
    private async Task GetPlayed_Method() {
        TimeRange[] value = await AudioElement.GetPlayed(default);
        labelOutput = $"{value.Length}: {string.Join(", ", value.Select((TimeRange timeRange) => $"[{timeRange.Start}, {timeRange.End}]"))}";
    }

    #endregion


    #region Settings

    public const string BUTTON_GET_PLAYBACK_RATE_PROPERTY = "htmlmediaelement-get-playback-rate-property";
    private async Task GetPlaybackRate_Property() {
        double value = await AudioElement.PlaybackRate;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_PLAYBACK_RATE_METHOD = "htmlmediaelement-get-playback-rate-method";
    private async Task GetPlaybackRate_Method() {
        double value = await AudioElement.GetPlaybackRate(default);
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_PLAYBACK_RATE = "htmlmediaelement-set-playback-rate";
    private async Task SetPlaybackRate() {
        await AudioElement.SetPlaybackRate(TEST_PLAYBACK_RATE);
    }


    public const string BUTTON_GET_DEFAULT_PLAYBACK_RATE_PROPERTY = "htmlmediaelement-get-default_playback-rate-property";
    private async Task GetDefaultPlaybackRate_Property() {
        double value = await AudioElement.DefaultPlaybackRate;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_DEFAULT_PLAYBACK_RATE_METHOD = "htmlmediaelement-get-default-playback-rate-method";
    private async Task GetDefaultPlaybackRate_Method() {
        double value = await AudioElement.GetDefaultPlaybackRate(default);
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_DEFAULT_PLAYBACK_RATE = "htmlmediaelement-set-default-playback-rate";
    private async Task SetDefaultPlaybackRate() {
        await AudioElement.SetDefaultPlaybackRate(TEST_DEFAULT_PLAYBACK_RATE);
    }


    public const string BUTTON_GET_CROSS_ORIGIN_PROPERTY = "htmlmediaelement-get-cross-origin-property";
    private async Task GetCrossOrigin_Property() {
        string value = await AudioElement.CrossOrigin;
        labelOutput = value;
    }

    public const string BUTTON_GET_CROSS_ORIGIN_METHOD = "htmlmediaelement-get-cross-origin-method";
    private async Task GetCrossOrigin_Method() {
        string value = await AudioElement.GetCrossOrigin(default);
        labelOutput = value;
    }

    public const string BUTTON_SET_CROSS_ORIGIN = "htmlmediaelement-set-cross-origin";
    private async Task SetCrossOrigin() {
        await AudioElement.SetCrossOrigin(TEST_CROSS_ORIGIN);
    }


    public const string BUTTON_GET_PRESERVES_PITCH_PROPERTY = "htmlmediaelement-get-preserves-pitch-property";
    private async Task GetPreservesPitch_Property() {
        bool value = await AudioElement.PreservesPitch;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_PRESERVES_PITCH_METHOD = "htmlmediaelement-get-preserves-pitch-method";
    private async Task GetPreservesPitch_Method() {
        bool value = await AudioElement.GetPreservesPitch(default);
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_PRESERVES_PITCH = "htmlmediaelement-set-preserves-pitch";
    private async Task SetPreservesPitch() {
        await AudioElement.SetPreservesPitch(false);
    }


    public const string BUTTON_GET_DISABLE_REMOTE_PLAYBACK_PROPERTY = "htmlmediaelement-get-disable-remote-playback-property";
    private async Task GetDisableRemotePlayback_Property() {
        bool value = await AudioElement.DisableRemotePlayback;
        labelOutput = value.ToString();
    }

    public const string BUTTON_GET_DISABLE_REMOTE_PLAYBACK_METHOD = "htmlmediaelement-get-disable-remote-playback-method";
    private async Task GetDisableRemotePlayback_Method() {
        bool value = await AudioElement.GetDisableRemotePlayback(default);
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_DISABLE_REMOTE_PLAYBACK = "htmlmediaelement-set-disable-remote-playback";
    private async Task SetDisableRemotePlayback() {
        await AudioElement.SetDisableRemotePlayback(true);
    }

    #endregion


    #region Video (<video> elements only)

    public const string BUTTON_GET_WIDTH_PROPERTY = "htmlmediaelement-get-width-property";
    private async Task GetWidth_Property() {
        int width = await VideoElement.Width;
        labelOutput = width.ToString();
    }

    public const string BUTTON_GET_WIDTH_METHOD = "htmlmediaelement-get-width-method";
    private async Task GetWidth_Method() {
        int width = await VideoElement.GetWidth(default);
        labelOutput = width.ToString();
    }

    public const string BUTTON_SET_WIDTH = "htmlmediaelement-set-width";
    private async Task SetWidth() {
        await VideoElement.SetWidth(TEST_VIDEO_WIDTH);
    }


    public const string BUTTON_GET_HEIGHT_PROPERTY = "htmlmediaelement-get-height-property";
    private async Task GetHeight_Property() {
        int height = await VideoElement.Height;
        labelOutput = height.ToString();
    }

    public const string BUTTON_GET_HEIGHT_METHOD = "htmlmediaelement-get-height-method";
    private async Task GetHeight_Method() {
        int height = await VideoElement.GetHeight(default);
        labelOutput = height.ToString();
    }

    public const string BUTTON_SET_HEIGHT = "htmlmediaelement-set-height";
    private async Task SetHeight() {
        await VideoElement.SetHeight(TEST_VIDEO_HEIGHT);
    }


    public const string BUTTON_GET_VIDEO_WIDTH_PROPERTY = "htmlmediaelement-get-video-width-property";
    private async Task GetVideoWidth_Property() {
        int videoWidth = await VideoElement.VideoWidth;
        labelOutput = videoWidth.ToString();
    }

    public const string BUTTON_GET_VIDEO_WIDTH_METHOD = "htmlmediaelement-get-video-width-method";
    private async Task GetVideoWidth_Method() {
        int videoWidth = await VideoElement.GetVideoWidth(default);
        labelOutput = videoWidth.ToString();
    }


    public const string BUTTON_GET_VIDEO_HEIGHT_PROPERTY = "htmlmediaelement-get-video-height-property";
    private async Task GetVideoHeight_Property() {
        int videoHeight = await VideoElement.VideoHeight;
        labelOutput = videoHeight.ToString();
    }

    public const string BUTTON_GET_VIDEO_HEIGHT_METHOD = "htmlmediaelement-get-video-height-method";
    private async Task GetVideoHeight_Method() {
        int videoHeight = await VideoElement.GetVideoHeight(default);
        labelOutput = videoHeight.ToString();
    }


    public const string BUTTON_GET_POSTER_PROPERTY = "htmlmediaelement-get-poster-property";
    private async Task GetPoster_Property() {
        string poster = await VideoElement.Poster;
        labelOutput = poster;
    }

    public const string BUTTON_GET_POSTER_METHOD = "htmlmediaelement-get-poster-method";
    private async Task GetPoster_Method() {
        string poster = await VideoElement.GetPoster(default);
        labelOutput = poster;
    }

    public const string BUTTON_SET_POSTER = "htmlmediaelement-set-poster";
    private async Task SetPoster() {
        await VideoElement.SetPoster(TEST_VIDEO_POSTER);
    }


    public const string BUTTON_GET_DISABLE_PICTURE_IN_PICTURE_PROPERTY = "htmlmediaelement-get-disable-picture-in-picture-property";
    private async Task GetDisablePictureInPicture_Property() {
        bool disablePictureInPicture = await VideoElement.DisablePictureInPicture;
        labelOutput = disablePictureInPicture.ToString();
    }

    public const string BUTTON_GET_DISABLE_PICTURE_IN_PICTURE_METHOD = "htmlmediaelement-get-disable-picture-in-picture-method";
    private async Task GetDisablePictureInPicture_Method() {
        bool disablePictureInPicture = await VideoElement.GetDisablePictureInPicture(default);
        labelOutput = disablePictureInPicture.ToString();
    }

    public const string BUTTON_SET_DISABLE_PICTURE_IN_PICTURE = "htmlmediaelement-set-disable-picture-in-picture";
    private async Task SetDisablePictureInPicture() {
        await VideoElement.SetDisablePictureInPicture(true);
    }

    #endregion


    #region PictureInPictureWindow

    public const string BUTTON_GET_PICTURE_IN_PICTURE_WINDOW_WIDTH_PROPERTY = "htmlmediaelement-get-picture-in-picture-window-width-property";
    private async Task GetPictureInPictureWindowWidth_Property() {
        await using IPictureInPictureWindow pictureInPictureWindow = await VideoElement.RequestPictureInPicture();
        int width = await pictureInPictureWindow.Width;
        labelOutput = width.ToString();
    }

    public const string BUTTON_GET_PICTURE_IN_PICTURE_WINDOW_WIDTH_METHOD = "htmlmediaelement-get-picture-in-picture-window-width-method";
    private async Task GetPictureInPictureWindowWidth_Method() {
        await using IPictureInPictureWindow pictureInPictureWindow = await VideoElement.RequestPictureInPicture();
        int width = await pictureInPictureWindow.GetWidth(default);
        labelOutput = width.ToString();
    }


    public const string BUTTON_GET_PICTURE_IN_PICTURE_WINDOW_HEIGHT_PROPERTY = "htmlmediaelement-get-picture-in-picture-window-height-property";
    private async Task GetPictureInPictureWindowHeight_Property() {
        await using IPictureInPictureWindow pictureInPictureWindow = await VideoElement.RequestPictureInPicture();
        int height = await pictureInPictureWindow.Height;
        labelOutput = height.ToString();
    }

    public const string BUTTON_GET_PICTURE_IN_PICTURE_WINDOW_HEIGHT_METHOD = "htmlmediaelement-get-picture-in-picture-window-height-method";
    private async Task GetPictureInPictureWindowHeight_Method() {
        await using IPictureInPictureWindow pictureInPictureWindow = await VideoElement.RequestPictureInPicture();
        int height = await pictureInPictureWindow.GetHeight(default);
        labelOutput = height.ToString();
    }


    public const string BUTTON_REGISTER_PICTURE_IN_PICTURE_WINDOW_ON_RESIZE = "htmlmediaelement-register-picture-in-picture-window-resize-event";
    private async Task RegisterPictureInPictureWindowOnResize() {
        IPictureInPictureWindow pictureInPictureWindow = await VideoElement.RequestPictureInPicture();
        pictureInPictureWindow.OnResize += OnResize;

        void OnResize() {
            labelOutput = TEST_EVENT_PICTURE_IN_PICTURE_WINDOW_RESIZE;
            StateHasChanged();
            pictureInPictureWindow.OnResize -= OnResize;
            _ = pictureInPictureWindow.DisposeAsync().Preserve();
        }
    }

    #endregion


    #region Methods

    public const string BUTTON_PLAY = "htmlmediaelement-play";
    private async Task Play() {
        await AudioElement.Play();
    }

    public const string BUTTON_PAUSE = "htmlmediaelement-pause";
    private async Task Pause() {
        await AudioElement.Pause();
    }

    public const string BUTTON_LOAD = "htmlmediaelement-load";
    private async Task Load() {
        await AudioElement.Load();
    }

    public const string BUTTON_FAST_SEEK = "htmlmediaelement-fast-seek";
    private async Task FastSeek() {
        await AudioElement.FastSeek(TEST_FAST_SEEK);
    }

    public const string BUTTON_CAN_PLAY_TYPE = "htmlmediaelement-can-play-type";
    private async Task CanPlayType() {
        string value = await AudioElement.CanPlayType("audio/mpeg");
        labelOutput = value;
    }


    public const string BUTTON_REQUEST_PICTURE_IN_PICTURE = "htmlmediaelement-request-picture-in-picture";
    private async Task RequestPictureInPicture() {
        await using IPictureInPictureWindow pictureInPictureWindow = await VideoElement.RequestPictureInPicture();
        labelOutput = (pictureInPictureWindow is not null).ToString();
    }

    #endregion


    #region Events

    // Ready

    public const string BUTTON_REGISTER_ON_ERROR = "htmlmediaelement-error-event";
    private void RegisterOnError() {
        AudioElement.OnError += (int code, string message) => {
            labelOutput = $"{TEST_EVENT_ERROR}: errorCode = {code}, {message}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CAN_PLAY = "htmlmediaelement-can-play-event";
    private void RegisterOnCanPlay() {
        AudioElement.OnCanPlay += () => {
            labelOutput = TEST_EVENT_CAN_PLAY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CAN_PLAY_THROUGH = "htmlmediaelement-can-play-through-event";
    private void RegisterOnCanPlayThrough() {
        AudioElement.OnCanPlayThrough += () => {
            labelOutput = TEST_EVENT_CAN_PLAY_THROUGH;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PLAYING = "htmlmediaelement-playing-event";
    private void RegisterOnPlaying() {
        AudioElement.OnPlaying += () => {
            labelOutput = TEST_EVENT_PLAYING;
            StateHasChanged();
        };
    }


    // Data

    public const string BUTTON_REGISTER_ON_LOAD_START = "htmlmediaelement-load-start-event";
    private void RegisterOnLoadStart() {
        AudioElement.OnLoadStart += () => {
            labelOutput = TEST_EVENT_LOAD_START;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PROGRESS = "htmlmediaelement-progress-event";
    private void RegisterOnProgress() {
        AudioElement.OnProgress += () => {
            labelOutput = TEST_EVENT_PROGRESS;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOADED_DATA = "htmlmediaelement-loaded-data-event";
    private void RegisterOnLoadedData() {
        AudioElement.OnLoadedData += () => {
            labelOutput = TEST_EVENT_LOADED_DATA;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOADED_METADATA = "htmlmediaelement-loaded-metadata-event";
    private void RegisterOnLoadedMetadata() {
        AudioElement.OnLoadedMetadata += () => {
            labelOutput = TEST_EVENT_LOADED_METADATA;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_STALLED = "htmlmediaelement-stalled-event";
    private void RegisterOnStalled() {
        AudioElement.OnStalled += () => {
            labelOutput = TEST_EVENT_STALLED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SUSPEND = "htmlmediaelement-suspend-event";
    private void RegisterOnSuspend() {
        AudioElement.OnSuspend += () => {
            labelOutput = TEST_EVENT_SUSPEND;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_WAITING = "htmlmediaelement-waiting-event";
    private void RegisterOnWaiting() {
        AudioElement.OnWaiting += () => {
            labelOutput = TEST_EVENT_WAITING;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ABORT = "htmlmediaelement-abort-event";
    private void RegisterOnAbort() {
        AudioElement.OnAbort += () => {
            labelOutput = TEST_EVENT_ABORT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_EMPTIED = "htmlmediaelement-emptied-event";
    private void RegisterOnEmptied() {
        AudioElement.OnEmptied += () => {
            labelOutput = TEST_EVENT_EMPTIED;
            StateHasChanged();
        };
    }


    // Timing

    public const string BUTTON_REGISTER_ON_PLAY = "htmlmediaelement-play-event";
    private void RegisterOnPlay() {
        AudioElement.OnPlay += () => {
            labelOutput = TEST_EVENT_PLAY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PAUSE = "htmlmediaelement-pause-event";
    private void RegisterOnPause() {
        AudioElement.OnPause += () => {
            labelOutput = TEST_EVENT_PAUSE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ENDED = "htmlmediaelement-ended-event";
    private void RegisterOnEnded() {
        AudioElement.OnEnded += () => {
            labelOutput = TEST_EVENT_ENDED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SEEKING = "htmlmediaelement-seeking-event";
    private void RegisterOnSeeking() {
        AudioElement.OnSeeking += () => {
            labelOutput = TEST_EVENT_SEEKING;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SEEKED = "htmlmediaelement-seeked-event";
    private void RegisterOnSeeked() {
        AudioElement.OnSeeked += () => {
            labelOutput = TEST_EVENT_SEEKED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TIME_UPDATE = "htmlmediaelement-time-update-event";
    private void RegisterOnTimeUpdate() {
        AudioElement.OnTimeUpdate += () => {
            labelOutput = TEST_EVENT_TIME_UPDATE;
            StateHasChanged();
        };
    }


    // Setting

    public const string BUTTON_REGISTER_ON_VOLUME_CHANGE = "htmlmediaelement-volume-change-event";
    private void RegisterOnVolumeChange() {
        AudioElement.OnVolumeChange += () => {
            labelOutput = TEST_EVENT_VOLUME_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_RATE_CHANGE = "htmlmediaelement-rate-change-event";
    private void RegisterOnRateChange() {
        AudioElement.OnRateChange += () => {
            labelOutput = TEST_EVENT_RATE_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DURATION_CHANGE = "htmlmediaelement-duration-change-event";
    private void RegisterOnDurationChange() {
        AudioElement.OnDurationChange += () => {
            labelOutput = TEST_EVENT_DURATION_CHANGE;
            StateHasChanged();
        };
    }


    // Video

    public const string BUTTON_REGISTER_ON_RESIZE = "htmlmediaelement-resize-event";
    private void RegisterOnResize() {
        VideoElement.OnResize += () => {
            labelOutput = TEST_EVENT_RESIZE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ENTER_PICTURE_IN_PICTURE = "htmlmediaelement-enter-picture-in-picture-event";
    private void RegisterOnEnterPictureInPicture() {
        VideoElement.OnEnterPictureInPicture += (IPictureInPictureWindow pictureInPictureWindow) => {
            labelOutput = TEST_EVENT_ENTER_PICTURE_IN_PICTURE;
            StateHasChanged();
            _ = pictureInPictureWindow.DisposeAsync().Preserve();
        };
    }

    public const string BUTTON_REGISTER_ON_LEAVE_PICTURE_IN_PICTURE = "htmlmediaelement-leave-picture-in-picture-event";
    private void RegisterOnLeavePictureInPicture() {
        VideoElement.OnLeavePictureInPicture += (IPictureInPictureWindow pictureInPictureWindow) => {
            labelOutput = TEST_EVENT_LEAVE_PICTURE_IN_PICTURE;
            StateHasChanged();
            _ = pictureInPictureWindow.DisposeAsync().Preserve();
        };
    }

    #endregion
}
