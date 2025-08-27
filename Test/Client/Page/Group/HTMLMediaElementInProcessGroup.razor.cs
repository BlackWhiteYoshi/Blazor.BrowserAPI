using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class HTMLMediaElementInProcessGroup : ComponentBase, IDisposable {
    public const string TEST_SRC = "<src>-test-inprocess";
    public const string TEST_SET_SRC_OBJECT = "set src object done";
    public const string TEST_PRELOAD = "none";
    public const double TEST_CURRENT_TIME = 11.0;
    public const double TEST_VOLUME = 0.7;
    public const double TEST_PLAYBACK_RATE = 0.6;
    public const double TEST_DEFAULT_PLAYBACK_RATE = 0.4;
    public const string TEST_CROSS_ORIGIN = "use-credentials";
    public const int TEST_VIDEO_WIDTH = 200;
    public const int TEST_VIDEO_HEIGHT = 100;
    public const string TEST_VIDEO_POSTER = "data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' viewBox='-4 -4 8 8'><circle cx='0' cy='0' r='4' fill='%23484' /></svg>";
    public const string TEST_PICTURE_IN_PICTURE_WINDOW_RESIZE_EVENT = "pictureInPictureWindow resized";
    public const double TEST_FAST_SEEK = 21.0;


    [Inject]
    public required IElementFactoryInProcess ElementFactory { private get; init; }


    private IHTMLMediaElementInProcess? _audioElement;
    private IHTMLMediaElementInProcess AudioElement => _audioElement ??= ElementFactory.CreateHTMLMediaElement(audioElement);

    public const string AUDIO_ELEMENT = "htmlmediaelement-inprocess-audio-element";
    private ElementReference audioElement;


    private IHTMLMediaElementInProcess? _videoElement;
    private IHTMLMediaElementInProcess VideoElement => _videoElement ??= ElementFactory.CreateHTMLMediaElement(videoElement);

    public const string VIDEO_ELEMENT = "htmlmediaelement-inprocess-video-element";
    private ElementReference videoElement;


    public const string LABEL_OUTPUT = "htmlmediaelement-inprocess-output";
    private string labelOutput = string.Empty;


    public void Dispose() {
        _audioElement?.Dispose();
        _videoElement?.Dispose();
    }


    #region Attributes

    public const string BUTTON_GET_SRC = "htmlmediaelement-inprocess-get-src";
    private void GetSrc() {
        string value = AudioElement.Src;
        labelOutput = value;
    }

    public const string BUTTON_SET_SRC = "htmlmediaelement-inprocess-set-src";
    private void SetSrc() {
        AudioElement.Src = TEST_SRC;
    }


    public const string BUTTON_GET_SRC_OBJECT = "htmlmediaelement-inprocess-get-src-object";
    private void GetSrcObject() {
        IMediaStreamInProcess? value = AudioElement.SrcObject;
        labelOutput = (value is not null).ToString();
        value?.Dispose();
    }

    public const string BUTTON_SET_SRC_OBJECT = "htmlmediaelement-inprocess-set-src-object";
    private void SetSrcObject() {
        AudioElement.SrcObject = null;
        labelOutput = TEST_SET_SRC_OBJECT;
    }


    public const string BUTTON_GET_CONTROLS = "htmlmediaelement-inprocess-get-controls";
    private void GetControls() {
        bool value = AudioElement.Controls;
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_CONTROLS = "htmlmediaelement-inprocess-set-controls";
    private void SetControls() {
        AudioElement.Controls = false;
    }


    public const string BUTTON_GET_AUTOPLAY = "htmlmediaelement-inprocess-get-autoplay";
    private void GetAutoplay() {
        bool value = AudioElement.Autoplay;
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_AUTOPLAY = "htmlmediaelement-inprocess-set-autoplay";
    private void SetAutoplay() {
        AudioElement.Autoplay = true;
    }


    public const string BUTTON_GET_LOOP = "htmlmediaelement-inprocess-get-loop";
    private void GetLoop() {
        bool value = AudioElement.Loop;
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_LOOP = "htmlmediaelement-inprocess-set-loop";
    private void SetLoop() {
        AudioElement.Loop = true;
    }


    public const string BUTTON_GET_DEFAULT_MUTED = "htmlmediaelement-inprocess-get-default-muted";
    private void GetDefaultMuted() {
        bool value = AudioElement.DefaultMuted;
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_DEFAULT_MUTED = "htmlmediaelement-inprocess-set-default-muted";
    private void SetDefaultMuted() {
        AudioElement.DefaultMuted = true;
    }


    public const string BUTTON_GET_PRELOAD = "htmlmediaelement-inprocess-get-preload";
    private void GetPreload() {
        string value = AudioElement.Preload;
        labelOutput = value;
    }

    public const string BUTTON_SET_PRELOAD = "htmlmediaelement-inprocess-set-preload";
    private void SetPreload() {
        AudioElement.Preload = TEST_PRELOAD;
    }

    #endregion


    #region State

    public const string BUTTON_GET_CURRENT_SRC = "htmlmediaelement-inprocess-get-current-src";
    private void GetCurrentSrc() {
        string value = AudioElement.CurrentSrc;
        labelOutput = value;
    }


    public const string BUTTON_GET_CURRENT_TIME = "htmlmediaelement-inprocess-get-current-time";
    private void GetCurrentTime() {
        double value = AudioElement.CurrentTime;
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_CURRENT_TIME = "htmlmediaelement-inprocess-set-current-time";
    private void SetCurrentTime() {
        AudioElement.CurrentTime = TEST_CURRENT_TIME;
    }


    public const string BUTTON_GET_DURATION = "htmlmediaelement-inprocess-get-duration";
    private void GetDuration() {
        double value = AudioElement.Duration;
        labelOutput = value.ToString();
    }


    public const string BUTTON_GET_SEEKABLE = "htmlmediaelement-inprocess-get-seekable";
    private void GetSeekable() {
        TimeRange[] value = AudioElement.Seekable;
        labelOutput = $"{value.Length}: {string.Join(", ", value.Select((TimeRange timeRange) => $"[{timeRange.Start}, {timeRange.End}]"))}";
    }


    public const string BUTTON_GET_MUTED = "htmlmediaelement-inprocess-get-muted";
    private void GetMuted() {
        bool value = AudioElement.Muted;
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_MUTED = "htmlmediaelement-inprocess-set-muted";
    private void SetMuted() {
        AudioElement.Muted = true;
    }


    public const string BUTTON_GET_VOLUME = "htmlmediaelement-inprocess-get-volume";
    private void GetVolume() {
        double value = AudioElement.Volume;
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_VOLUME = "htmlmediaelement-inprocess-set-volume";
    private void SetVolume() {
        AudioElement.Volume = TEST_VOLUME;
    }


    public const string BUTTON_GET_PAUSED = "htmlmediaelement-inprocess-get-paused";
    private void GetPaused() {
        bool value = AudioElement.Paused;
        labelOutput = value.ToString();
    }


    public const string BUTTON_GET_ENDED = "htmlmediaelement-inprocess-get-ended";
    private void GetEnded() {
        bool value = AudioElement.Ended;
        labelOutput = value.ToString();
    }


    public const string BUTTON_GET_SEEKING = "htmlmediaelement-inprocess-get-seeking";
    private void GetSeeking() {
        bool value = AudioElement.Seeking;
        labelOutput = value.ToString();
    }


    public const string BUTTON_GET_READY_STATE = "htmlmediaelement-inprocess-get-ready-state";
    private void GetReadyState() {
        int value = AudioElement.ReadyState;
        labelOutput = value.ToString();
    }


    public const string BUTTON_GET_NETWORK_STATE = "htmlmediaelement-inprocess-get-network-state";
    private void GetNetworkState() {
        int value = AudioElement.NetworkState;
        labelOutput = value.ToString();
    }


    public const string BUTTON_GET_BUFFERED = "htmlmediaelement-inprocess-get-buffered";
    private void GetBuffered() {
        TimeRange[] value = AudioElement.Buffered;
        labelOutput = $"{value.Length}: {string.Join(", ", value.Select((TimeRange timeRange) => $"[{timeRange.Start}, {timeRange.End}]"))}";
    }


    public const string BUTTON_GET_PLAYED = "htmlmediaelement-inprocess-get-played";
    private void GetPlayed() {
        TimeRange[] value = AudioElement.Played;
        labelOutput = $"{value.Length}: {string.Join(", ", value.Select((TimeRange timeRange) => $"[{timeRange.Start}, {timeRange.End}]"))}";
    }

    #endregion


    #region Settings

    public const string BUTTON_GET_PLAYBACK_RATE = "htmlmediaelement-inprocess-get-playback-rate";
    private void GetPlaybackRate() {
        double value = AudioElement.PlaybackRate;
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_PLAYBACK_RATE = "htmlmediaelement-inprocess-set-playback-rate";
    private void SetPlaybackRate() {
        AudioElement.PlaybackRate = TEST_PLAYBACK_RATE;
    }


    public const string BUTTON_GET_DEFAULT_PLAYBACK_RATE = "htmlmediaelement-inprocess-get-default_playback-rate";
    private void GetDefaultPlaybackRate() {
        double value = AudioElement.DefaultPlaybackRate;
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_DEFAULT_PLAYBACK_RATE = "htmlmediaelement-inprocess-set-default-playback-rate";
    private void SetDefaultPlaybackRate() {
        AudioElement.DefaultPlaybackRate = TEST_DEFAULT_PLAYBACK_RATE;
    }


    public const string BUTTON_GET_CROSS_ORIGIN = "htmlmediaelement-inprocess-get-cross-origin";
    private void GetCrossOrigin() {
        string value = AudioElement.CrossOrigin;
        labelOutput = value;
    }

    public const string BUTTON_SET_CROSS_ORIGIN = "htmlmediaelement-inprocess-set-cross-origin";
    private void SetCrossOrigin() {
        AudioElement.CrossOrigin = TEST_CROSS_ORIGIN;
    }


    public const string BUTTON_GET_PRESERVES_PITCH = "htmlmediaelement-inprocess-get-preserves-pitch";
    private void GetPreservesPitch() {
        bool value = AudioElement.PreservesPitch;
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_PRESERVES_PITCH = "htmlmediaelement-inprocess-set-preserves-pitch";
    private void SetPreservesPitch() {
        AudioElement.PreservesPitch = false;
    }


    public const string BUTTON_GET_DISABLE_REMOTE_PLAYBACK = "htmlmediaelement-inprocess-get-disable-remote-playback";
    private void GetDisableRemotePlayback() {
        bool value = AudioElement.DisableRemotePlayback;
        labelOutput = value.ToString();
    }

    public const string BUTTON_SET_DISABLE_REMOTE_PLAYBACK = "htmlmediaelement-inprocess-set-disable-remote-playback";
    private void SetDisableRemotePlayback() {
        AudioElement.DisableRemotePlayback = true;
    }

    #endregion


    #region Video (<video> elements only)

    public const string BUTTON_GET_WIDTH = "htmlmediaelement-inprocess-get-width";
    private void GetWidth() {
        int width = VideoElement.Width;
        labelOutput = width.ToString();
    }

    public const string BUTTON_SET_WIDTH = "htmlmediaelement-inprocess-set-width";
    private void SetWidth() {
        VideoElement.Width = TEST_VIDEO_WIDTH;
    }


    public const string BUTTON_GET_HEIGHT = "htmlmediaelement-inprocess-get-height";
    private void GetHeight() {
        int height = VideoElement.Height;
        labelOutput = height.ToString();
    }

    public const string BUTTON_SET_HEIGHT = "htmlmediaelement-inprocess-set-height";
    private void SetHeight() {
        VideoElement.Height = TEST_VIDEO_HEIGHT;
    }


    public const string BUTTON_GET_VIDEO_WIDTH = "htmlmediaelement-inprocess-get-video-width";
    private void GetVideoWidth() {
        int videoWidth = VideoElement.VideoWidth;
        labelOutput = videoWidth.ToString();
    }

    public const string BUTTON_GET_VIDEO_HEIGHT = "htmlmediaelement-inprocess-get-video-height";
    private void GetVideoHeight() {
        int videoHeight = VideoElement.VideoHeight;
        labelOutput = videoHeight.ToString();
    }


    public const string BUTTON_GET_POSTER = "htmlmediaelement-inprocess-get-poster";
    private void GetPoster() {
        string poster = VideoElement.Poster;
        labelOutput = poster;
    }

    public const string BUTTON_SET_POSTER = "htmlmediaelement-inprocess-set-poster";
    private void SetPoster() {
        VideoElement.Poster = TEST_VIDEO_POSTER;
    }


    public const string BUTTON_GET_DISABLE_PICTURE_IN_PICTURE = "htmlmediaelement-inprocess-get-disable-picture-in-picture";
    private void GetDisablePictureInPicture() {
        bool disablePictureInPicture = VideoElement.DisablePictureInPicture;
        labelOutput = disablePictureInPicture.ToString();
    }

    public const string BUTTON_SET_DISABLE_PICTURE_IN_PICTURE = "htmlmediaelement-inprocess-set-disable-picture-in-picture";
    private void SetDisablePictureInPicture() {
        VideoElement.DisablePictureInPicture = true;
    }

    #endregion


    #region PictureInPictureWindow

    public const string BUTTON_GET_PICTURE_IN_PICTURE_WINDOW_WIDTH = "htmlmediaelement-inprocess-get-picture-in-picture-window-width";
    private async Task GetPictureInPictureWindowWidth() {
        using IPictureInPictureWindowInProcess pictureInPictureWindow = await VideoElement.RequestPictureInPicture();
        int width = pictureInPictureWindow.Width;
        labelOutput = width.ToString();
    }

    public const string BUTTON_GET_PICTURE_IN_PICTURE_WINDOW_HEIGHT = "htmlmediaelement-inprocess-get-picture-in-picture-window-height";
    private async Task GetPictureInPictureWindowHeight() {
        using IPictureInPictureWindowInProcess pictureInPictureWindow = await VideoElement.RequestPictureInPicture();
        int height = pictureInPictureWindow.Height;
        labelOutput = height.ToString();
    }


    public const string BUTTON_REGISTER_PICTURE_IN_PICTURE_WINDOW_ON_RESIZE = "htmlmediaelement-inprocess-register-picture-in-picture-window-resize-event";
    private async Task RegisterPictureInPictureWindowOnResize() {
        IPictureInPictureWindowInProcess pictureInPictureWindow = await VideoElement.RequestPictureInPicture();
        pictureInPictureWindow.OnResize += OnResize;

        void OnResize() {
            labelOutput = TEST_PICTURE_IN_PICTURE_WINDOW_RESIZE_EVENT;
            StateHasChanged();
            pictureInPictureWindow.OnResize -= OnResize;
            pictureInPictureWindow.Dispose();
        }
    }

    #endregion


    #region Methods

    public const string BUTTON_PLAY = "htmlmediaelement-inprocess-play";
    private async Task Play() {
        await AudioElement.Play();
    }

    public const string BUTTON_PAUSE = "htmlmediaelement-inprocess-pause";
    private void Pause() {
        AudioElement.Pause();
    }

    public const string BUTTON_LOAD = "htmlmediaelement-inprocess-load";
    private void Load() {
        AudioElement.Load();
    }

    public const string BUTTON_FAST_SEEK = "htmlmediaelement-inprocess-fast-seek";
    private void FastSeek() {
        AudioElement.FastSeek(TEST_FAST_SEEK);
    }

    public const string BUTTON_CAN_PLAY_TYPE = "htmlmediaelement-inprocess-can-play-type";
    private void CanPlayType() {
        string value = AudioElement.CanPlayType("audio/mpeg");
        labelOutput = value;
    }


    public const string BUTTON_REQUEST_PICTURE_IN_PICTURE = "htmlmediaelement-inprocess-request-picture-in-picture";
    private async Task RequestPictureInPicture() {
        using IPictureInPictureWindowInProcess pictureInPictureWindow = await VideoElement.RequestPictureInPicture();
        labelOutput = (pictureInPictureWindow is not null).ToString();
    }

    #endregion


    #region Events

    // Ready

    public const string BUTTON_REGISTER_ON_ERROR = "htmlmediaelement-inprocess-error-event";
    private void RegisterOnError() {
        AudioElement.OnError += (int code, string message) => {
            labelOutput = $"Error: errorCode = {code}, {message}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CAN_PLAY = "htmlmediaelement-inprocess-can-play-event";
    private void RegisterOnCanPlay() {
        AudioElement.OnCanPlay += () => {
            labelOutput = "Canplay";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CAN_PLAY_THROUGH = "htmlmediaelement-inprocess-can-play-through-event";
    private void RegisterOnCanPlayThrough() {
        AudioElement.OnCanPlayThrough += () => {
            labelOutput = "Canplaythrough";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PLAYING = "htmlmediaelement-inprocess-playing-event";
    private void RegisterOnPlaying() {
        AudioElement.OnPlaying += () => {
            labelOutput = "Playing";
            StateHasChanged();
        };
    }


    // Data

    public const string BUTTON_REGISTER_ON_LOAD_START = "htmlmediaelement-inprocess-load-start-event";
    private void RegisterOnLoadStart() {
        AudioElement.OnLoadStart += () => {
            labelOutput = "Loadstart";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PROGRESS = "htmlmediaelement-inprocess-progress-event";
    private void RegisterOnProgress() {
        AudioElement.OnProgress += () => {
            labelOutput = "Progress";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOADED_DATA = "htmlmediaelement-inprocess-loaded-data-event";
    private void RegisterOnLoadedData() {
        AudioElement.OnLoadedData += () => {
            labelOutput = "Loadeddata";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOADED_METADATA = "htmlmediaelement-inprocess-loaded-metadata-event";
    private void RegisterOnLoadedMetadata() {
        AudioElement.OnLoadedMetadata += () => {
            labelOutput = "Loadedmetadata";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_STALLED = "htmlmediaelement-inprocess-stalled-event";
    private void RegisterOnStalled() {
        AudioElement.OnStalled += () => {
            labelOutput = "Stalled";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SUSPEND = "htmlmediaelement-inprocess-suspend-event";
    private void RegisterOnSuspend() {
        AudioElement.OnSuspend += () => {
            labelOutput = "Suspend";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_WAITING = "htmlmediaelement-inprocess-waiting-event";
    private void RegisterOnWaiting() {
        AudioElement.OnWaiting += () => {
            labelOutput = "Waiting";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ABORT = "htmlmediaelement-inprocess-abort-event";
    private void RegisterOnAbort() {
        AudioElement.OnAbort += () => {
            labelOutput = "Abort";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_EMPTIED = "htmlmediaelement-inprocess-emptied-event";
    private void RegisterOnEmptied() {
        AudioElement.OnEmptied += () => {
            labelOutput = "Emptied";
            StateHasChanged();
        };
    }


    // Timing

    public const string BUTTON_REGISTER_ON_PLAY = "htmlmediaelement-inprocess-play-event";
    private void RegisterOnPlay() {
        AudioElement.OnPlay += () => {
            labelOutput = "Play";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PAUSE = "htmlmediaelement-inprocess-pause-event";
    private void RegisterOnPause() {
        AudioElement.OnPause += () => {
            labelOutput = "Pause";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ENDED = "htmlmediaelement-inprocess-ended-event";
    private void RegisterOnEnded() {
        AudioElement.OnEnded += () => {
            labelOutput = "Ended";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SEEKING = "htmlmediaelement-inprocess-seeking-event";
    private void RegisterOnSeeking() {
        AudioElement.OnSeeking += () => {
            labelOutput = "Seeking";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SEEKED = "htmlmediaelement-inprocess-seeked-event";
    private void RegisterOnSeeked() {
        AudioElement.OnSeeked += () => {
            labelOutput = "Seeked";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TIME_UPDATE = "htmlmediaelement-inprocess-time-update-event";
    private void RegisterOnTimeUpdate() {
        AudioElement.OnTimeUpdate += () => {
            labelOutput = "Timeupdate";
            StateHasChanged();
        };
    }


    // Setting

    public const string BUTTON_REGISTER_ON_VOLUME_CHANGE = "htmlmediaelement-inprocess-volume-change-event";
    private void RegisterOnVolumeChange() {
        AudioElement.OnVolumeChange += () => {
            labelOutput = "Volumechange";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_RATE_CHANGE = "htmlmediaelement-inprocess-rate-change-event";
    private void RegisterOnRateChange() {
        AudioElement.OnRateChange += () => {
            labelOutput = "Ratechange";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DURATION_CHANGE = "htmlmediaelement-inprocess-duration-change-event";
    private void RegisterOnDurationChange() {
        AudioElement.OnDurationChange += () => {
            labelOutput = "Durationchange";
            StateHasChanged();
        };
    }


    // Video

    public const string BUTTON_REGISTER_ON_RESIZE = "htmlmediaelement-inprocess-resize-event";
    private void RegisterOnResize() {
        VideoElement.OnResize += () => {
            labelOutput = "Resize";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ENTER_PICTURE_IN_PICTURE = "htmlmediaelement-inprocess-enter-picture-in-picture-event";
    private void RegisterOnEnterPictureInPicture() {
        VideoElement.OnEnterPictureInPicture += (IPictureInPictureWindowInProcess pictureInPictureWindow) => {
            labelOutput = "EnterPictureInPicture";
            StateHasChanged();
            pictureInPictureWindow.Dispose();
        };
    }

    public const string BUTTON_REGISTER_ON_LEAVE_PICTURE_IN_PICTURE = "htmlmediaelement-inprocess-leave-picture-in-picture-event";
    private void RegisterOnLeavePictureInPicture() {
        VideoElement.OnLeavePictureInPicture += (IPictureInPictureWindowInProcess pictureInPictureWindow) => {
            labelOutput = "LeavePictureInPicture";
            StateHasChanged();
            pictureInPictureWindow.Dispose();
        };
    }

    #endregion
}
