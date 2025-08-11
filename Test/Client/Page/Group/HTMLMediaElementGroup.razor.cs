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
    public const double TEST_FAST_SEEK = 20.0;


    [Inject]
    public required IElementFactory ElementFactory { private get; init; }


    private IHTMLMediaElement? _audioElement;
    private IHTMLMediaElement AudioElement => _audioElement ??= ElementFactory.CreateHTMLMediaElement(audioElement);

    public const string AUDIO_ELEMENT = "htmlmediaelement-audio-element";
    private ElementReference audioElement;


    public const string LABEL_OUTPUT = "htmlmediaelement-output";
    private string labelOutput = string.Empty;


    public ValueTask DisposeAsync() => _audioElement?.DisposeAsync() ?? ValueTask.CompletedTask;


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
        await AudioElement.SetControls(true);
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

    #endregion


    #region Events

    // Ready

    public const string BUTTON_REGISTER_ON_ERROR = "htmlmediaelement-error-event";
    private void RegisterOnError() {
        AudioElement.OnError += (int code, string message) => {
            labelOutput = $"Error: errorCode = {code}, {message}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CANPLAY = "htmlmediaelement-canplay-event";
    private void RegisterOnCanplay() {
        AudioElement.OnCanplay += () => {
            labelOutput = "Canplay";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CANPLAYTHROUGH = "htmlmediaelement-canplaythrough-event";
    private void RegisterOnCanplaythrough() {
        AudioElement.OnCanplaythrough += () => {
            labelOutput = "Canplaythrough";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PLAYING = "htmlmediaelement-playing-event";
    private void RegisterOnPlaying() {
        AudioElement.OnPlaying += () => {
            labelOutput = "Playing";
            StateHasChanged();
        };
    }


    // Data

    public const string BUTTON_REGISTER_ON_LOADSTART = "htmlmediaelement-loadstart-event";
    private void RegisterOnLoadstart() {
        AudioElement.OnLoadstart += () => {
            labelOutput = "Loadstart";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PROGRESS = "htmlmediaelement-progress-event";
    private void RegisterOnProgress() {
        AudioElement.OnProgress += () => {
            labelOutput = "Progress";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOADEDDATA = "htmlmediaelement-loadeddata-event";
    private void RegisterOnLoadeddata() {
        AudioElement.OnLoadeddata += () => {
            labelOutput = "Loadeddata";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOADEDMETADATA = "htmlmediaelement-loadedmetadata-event";
    private void RegisterOnLoadedmetadata() {
        AudioElement.OnLoadedmetadata += () => {
            labelOutput = "Loadedmetadata";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_STALLED = "htmlmediaelement-stalled-event";
    private void RegisterOnStalled() {
        AudioElement.OnStalled += () => {
            labelOutput = "Stalled";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SUSPEND = "htmlmediaelement-suspend-event";
    private void RegisterOnSuspend() {
        AudioElement.OnSuspend += () => {
            labelOutput = "Suspend";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_WAITING = "htmlmediaelement-waiting-event";
    private void RegisterOnWaiting() {
        AudioElement.OnWaiting += () => {
            labelOutput = "Waiting";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ABORT = "htmlmediaelement-abort-event";
    private void RegisterOnAbort() {
        AudioElement.OnAbort += () => {
            labelOutput = "Abort";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_EMPTIED = "htmlmediaelement-emptied-event";
    private void RegisterOnEmptied() {
        AudioElement.OnEmptied += () => {
            labelOutput = "Emptied";
            StateHasChanged();
        };
    }


    // Timing

    public const string BUTTON_REGISTER_ON_PLAY = "htmlmediaelement-play-event";
    private void RegisterOnPlay() {
        AudioElement.OnPlay += () => {
            labelOutput = "Play";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PAUSE = "htmlmediaelement-pause-event";
    private void RegisterOnPause() {
        AudioElement.OnPause += () => {
            labelOutput = "Pause";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ENDED = "htmlmediaelement-ended-event";
    private void RegisterOnEnded() {
        AudioElement.OnEnded += () => {
            labelOutput = "Ended";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SEEKING = "htmlmediaelement-seeking-event";
    private void RegisterOnSeeking() {
        AudioElement.OnSeeking += () => {
            labelOutput = "Seeking";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SEEKED = "htmlmediaelement-seeked-event";
    private void RegisterOnSeeked() {
        AudioElement.OnSeeked += () => {
            labelOutput = "Seeked";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TIMEUPDATE = "htmlmediaelement-timeupdate-event";
    private void RegisterOnTimeupdate() {
        AudioElement.OnTimeupdate += () => {
            labelOutput = "Timeupdate";
            StateHasChanged();
        };
    }


    // Setting

    public const string BUTTON_REGISTER_ON_VOLUMECHANGE = "htmlmediaelement-volumechange-event";
    private void RegisterOnVolumechange() {
        AudioElement.OnVolumechange += () => {
            labelOutput = "Volumechange";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_RATECHANGE = "htmlmediaelement-ratechange-event";
    private void RegisterOnRatechange() {
        AudioElement.OnRatechange += () => {
            labelOutput = "Ratechange";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DURATIONCHANGE = "htmlmediaelement-durationchange-event";
    private void RegisterOnDurationchange() {
        AudioElement.OnDurationchange += () => {
            labelOutput = "Durationchange";
            StateHasChanged();
        };
    }

    #endregion
}
