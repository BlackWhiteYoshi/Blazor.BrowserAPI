using BrowserAPI.Test.Client;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class HTMLMediaElementInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    #region Attributes

    [Fact]
    public async Task GetSrc() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_SRC_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("https://localhost:5000/HTMLMediaElement_audio.mp3", result);
    }

    [Fact]
    public async Task SetSrc() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_SRC_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("src");
        Assert.Equal(HTMLMediaElementGroup.TEST_SRC, result);
    }


    [Fact]
    public async Task GetControls() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_CONTROLS_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetControls() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_CONTROLS_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("controls");
        Assert.Equal("", result);
    }


    [Fact]
    public async Task GetAutoplay() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_AUTOPLAY_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetAutoplay() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_AUTOPLAY_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("autoplay");
        Assert.Equal("", result);
    }


    [Fact]
    public async Task GetLoop() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_LOOP_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetLoop() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_LOOP_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("loop");
        Assert.Equal("", result);
    }


    [Fact]
    public async Task GetDefaultMuted() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_DEFAULT_MUTED_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetDefaultMuted() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_DEFAULT_MUTED_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("muted");
        Assert.Equal("", result);
    }


    [Fact]
    public async Task GetPreload() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PRELOAD_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("auto", result);
    }

    [Fact]
    public async Task SetPreload() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_PRELOAD_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("preload");
        Assert.Equal(HTMLMediaElementGroup.TEST_PRELOAD, result);
    }

    #endregion


    #region State

    [Fact]
    public async Task GetCurrentSrc() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_CURRENT_SRC_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("https://localhost:5000/HTMLMediaElement_audio.mp3", result);
    }


    [Fact]
    public async Task GetCurrentTime() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_CURRENT_TIME_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("0", result);
    }

    [Fact]
    public async Task SetCurrentTime() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_CURRENT_TIME_INPROCESS).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        Assert.Equal(HTMLMediaElementGroup.TEST_CURRENT_TIME, result);
    }


    [Fact]
    public async Task GetDuration() {
        await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_DURATION_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("60.0512", result);
    }


    [Fact]
    public async Task GetSeekable() {
        await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_SEEKABLE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("1: [0, 60.0512]", result);
    }


    [Fact]
    public async Task GetMuted() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_MUTED_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetMuted() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_MUTED_INPROCESS).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.muted;");
        Assert.True(result);
    }


    [Fact]
    public async Task GetVolume() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_VOLUME_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("1", result);
    }

    [Fact]
    public async Task SetVolume() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_VOLUME_INPROCESS).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.volume;");
        Assert.Equal(HTMLMediaElementGroup.TEST_VOLUME, result);
    }


    [Fact]
    public async Task GetPaused() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PAUSED_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }


    [Fact]
    public async Task GetEnded() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_ENDED_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }


    [Fact]
    public async Task GetSeeking() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_SEEKING_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }


    [Fact]
    public async Task GetReadyState() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_READY_STATE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("0", result);
    }


    [Fact]
    public async Task GetNetworkState() {
        await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_NETWORK_STATE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("1", result);
    }


    [Fact]
    public async Task GetBuffered() {
        await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_BUFFERED_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("1: [0, 60.0512]", result);
    }


    [Fact]
    public async Task GetPlayed() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PLAYED_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("0: ", result);
    }

    #endregion


    #region Settings

    [Fact]
    public async Task GetPlaybackRate() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PLAYBACK_RATE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("1", result);
    }

    [Fact]
    public async Task SetPlaybackRate() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_PLAYBACK_RATE_INPROCESS).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.playbackRate;");
        Assert.Equal(HTMLMediaElementGroup.TEST_PLAYBACK_RATE, result);
    }


    [Fact]
    public async Task GetDefaultPlaybackRate() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_DEFAULT_PLAYBACK_RATE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("1", result);
    }

    [Fact]
    public async Task SetDefaultPlaybackRate() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_DEFAULT_PLAYBACK_RATE_INPROCESS).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.defaultPlaybackRate;");
        Assert.Equal(HTMLMediaElementGroup.TEST_DEFAULT_PLAYBACK_RATE, result);
    }


    [Fact]
    public async Task GetCrossOrigin() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_CROSS_ORIGIN_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("anonymous", result);
    }

    [Fact]
    public async Task SetCrossOrigin() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_CROSS_ORIGIN_INPROCESS).ClickAsync();

        string result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<string>("audioElement => audioElement.crossOrigin;");
        Assert.Equal(HTMLMediaElementGroup.TEST_CROSS_ORIGIN, result);
    }


    [Fact]
    public async Task GetPreservesPitch() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PRESERVES_PITCH_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }

    [Fact]
    public async Task SetPreservesPitch() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_PRESERVES_PITCH_INPROCESS).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.preservesPitch;");
        Assert.False(result);
    }


    [Fact]
    public async Task GetDisableRemotePlayback() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_DISABLE_REMOTE_PLAYBACK_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetDisableRemotePlayback() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_DISABLE_REMOTE_PLAYBACK_INPROCESS).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.disableRemotePlayback;");
        Assert.True(result);
    }

    #endregion


    #region Methods

    [Fact]
    public async Task Play() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_PLAY_INPROCESS).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        Assert.False(result);
    }

    [Fact]
    public async Task Pause() {
        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(100);
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_PAUSE_INPROCESS).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        Assert.True(result);
        double currentTime = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        Assert.True(currentTime > 0.0);
    }

    [Fact]
    public async Task Load() {
        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(100);
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_LOAD_INPROCESS).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        Assert.True(result);
        double currentTime = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        Assert.Equal(0.0, currentTime);
    }

    // does not work in Chromium Browser. To make this test work, go to PlayWrightFixture.InitializeAsync() and change "Chromium" to "Firefox"
    //[Fact]
    //public async Task FastSeek() {
    //    await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

    //    await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_FAST_SEEK_INPROCESS).ClickAsync();

    //    double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
    //    Assert.True(Math.Abs(HTMLMediaElementGroup.TEST_FAST_SEEK - result) < 0.1);
    //}

    [Fact]
    public async Task CanPlayType() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_CAN_PLAY_TYPE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("probably", result);
    }

    #endregion


    #region Events Ready

    [Fact]
    public async Task RegisterOnError() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_ERROR_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'invalid';");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Error: errorCode = 4, MEDIA_ELEMENT_ERROR: Format error", result);
    }

    [Fact]
    public async Task RegisterOnCanplay() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_CANPLAY_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Canplay", result);
    }

    [Fact]
    public async Task RegisterOnCanplaythrough() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_CANPLAYTHROUGH_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Canplaythrough", result);
    }

    [Fact]
    public async Task RegisterOnPlaying() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_PLAYING_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Playing", result);
    }

    #endregion


    #region Events Data

    [Fact]
    public async Task RegisterOnLoadstart() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_LOADSTART_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Loadstart", result);
    }

    [Fact]
    public async Task RegisterOnProgress() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_PROGRESS_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Progress", result);
    }

    [Fact]
    public async Task RegisterOnLoadeddata() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_LOADEDDATA_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Loadeddata", result);
    }

    [Fact]
    public async Task RegisterOnLoadedmetadata() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_LOADEDMETADATA_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Loadedmetadata", result);
    }

    [Fact]
    public async Task RegisterOnStalled() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_STALLED_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("", result);
        // need proper test setup
        //Assert.Equal("Stalled", result);
    }

    [Fact]
    public async Task RegisterOnSuspend() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_SUSPEND_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("", result);
        // need proper test setup
        //Assert.Equal("Suspend", result);
    }

    [Fact]
    public async Task RegisterOnWaiting() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_WAITING_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("", result);
        // need proper test setup
        //Assert.Equal("Waiting", result);
    }

    [Fact]
    public async Task RegisterOnAbort() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_ABORT_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Abort", result);
    }

    [Fact]
    public async Task RegisterOnEmptied() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_EMPTIED_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Emptied", result);
    }

    #endregion


    #region Events Timing

    [Fact]
    public async Task RegisterOnPlay() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_PLAY_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Play", result);
    }

    [Fact]
    public async Task RegisterOnPause() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_PAUSE_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("""
            audioElement => {
                audioElement.play();
                audioElement.pause();
            }
            """);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Pause", result);
    }

    [Fact]
    public async Task RegisterOnEnded() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_ENDED_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("""
            audioElement => {
                audioElement.currentTime = 60.0;
                audioElement.play();
            }
            """);
        await Task.Delay(1000);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Ended", result);
    }

    [Fact]
    public async Task RegisterOnSeeking() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_SEEKING_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Seeking", result);
    }

    [Fact]
    public async Task RegisterOnSeeked() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_SEEKED_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");
        await Task.Delay(200);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Seeked", result);
    }

    [Fact]
    public async Task RegisterOnTimeupdate() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_TIMEUPDATE_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");
        await Task.Delay(200);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Timeupdate", result);
    }

    #endregion


    #region Events Setting

    [Fact]
    public async Task RegisterOnVolumechange() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_VOLUMECHANGE_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.volume = 0.5;");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Volumechange", result);
    }

    [Fact]
    public async Task RegisterOnRatechange() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_RATECHANGE_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.playbackRate = 0.5;");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Ratechange", result);
    }

    [Fact]
    public async Task RegisterOnDurationchange() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_DURATIONCHANGE_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'invalid';");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Durationchange", result);
    }

    #endregion
}
