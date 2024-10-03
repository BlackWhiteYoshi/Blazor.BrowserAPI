using BrowserAPI.Test.Client;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class HTMLMediaElementInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    #region Attributes

    [Fact]
    public async Task GetSrc() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_SRC).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("https://localhost:5000/HTMLMediaElement_audio.mp3", result);
    }

    [Fact]
    public async Task SetSrc() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_SRC).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("src");
        Assert.Equal(HTMLMediaElementInProcessGroup.TEST_SRC, result);
    }


    [Fact]
    public async Task GetSrcObject() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_SRC_OBJECT).ClickAsync();
        // an assertion happens in DisposeAsync()
    }

    [Fact]
    public async Task SetSrcObject() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_SRC_OBJECT).ClickAsync();
        // an assertion happens in DisposeAsync()
    }


    [Fact]
    public async Task GetControls() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_CONTROLS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetControls() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_CONTROLS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("controls");
        Assert.Equal("", result);
    }


    [Fact]
    public async Task GetAutoplay() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_AUTOPLAY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetAutoplay() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_AUTOPLAY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("autoplay");
        Assert.Equal("", result);
    }


    [Fact]
    public async Task GetLoop() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_LOOP).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetLoop() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_LOOP).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("loop");
        Assert.Equal("", result);
    }


    [Fact]
    public async Task GetDefaultMuted() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_DEFAULT_MUTED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetDefaultMuted() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_DEFAULT_MUTED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("muted");
        Assert.Equal("", result);
    }


    [Fact]
    public async Task GetPreload() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_PRELOAD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("auto", result);
    }

    [Fact]
    public async Task SetPreload() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_PRELOAD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("preload");
        Assert.Equal(HTMLMediaElementInProcessGroup.TEST_PRELOAD, result);
    }

    #endregion


    #region State

    [Fact]
    public async Task GetCurrentSrc() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_CURRENT_SRC).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("https://localhost:5000/HTMLMediaElement_audio.mp3", result);
    }


    [Fact]
    public async Task GetCurrentTime() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_CURRENT_TIME).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("0", result);
    }

    [Fact]
    public async Task SetCurrentTime() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_CURRENT_TIME).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        Assert.Equal(HTMLMediaElementInProcessGroup.TEST_CURRENT_TIME, result);
    }


    [Fact]
    public async Task GetDuration() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_DURATION).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("60.0512", result);
    }


    [Fact]
    public async Task GetSeekable() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_SEEKABLE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("1: [0, 60.0512]", result);
    }


    [Fact]
    public async Task GetMuted() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_MUTED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetMuted() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_MUTED).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.muted;");
        Assert.True(result);
    }


    [Fact]
    public async Task GetVolume() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_VOLUME).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("1", result);
    }

    [Fact]
    public async Task SetVolume() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_VOLUME).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.volume;");
        Assert.Equal(HTMLMediaElementInProcessGroup.TEST_VOLUME, result);
    }


    [Fact]
    public async Task GetPaused() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_PAUSED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }


    [Fact]
    public async Task GetEnded() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_ENDED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }


    [Fact]
    public async Task GetSeeking() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_SEEKING).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }


    [Fact]
    public async Task GetReadyState() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_READY_STATE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.NotEmpty(result!);
    }


    [Fact]
    public async Task GetNetworkState() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_NETWORK_STATE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("1", result);
    }


    [Fact]
    public async Task GetBuffered() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_BUFFERED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.True(result![0] is '0' or '1');
        Assert.True(result![1] is ':');
        Assert.True(result![2] is ' ');
    }


    [Fact]
    public async Task GetPlayed() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_PLAYED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("0: ", result);
    }

    #endregion


    #region Settings

    [Fact]
    public async Task GetPlaybackRate() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_PLAYBACK_RATE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("1", result);
    }

    [Fact]
    public async Task SetPlaybackRate() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_PLAYBACK_RATE).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.playbackRate;");
        Assert.Equal(HTMLMediaElementInProcessGroup.TEST_PLAYBACK_RATE, result);
    }


    [Fact]
    public async Task GetDefaultPlaybackRate() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_DEFAULT_PLAYBACK_RATE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("1", result);
    }

    [Fact]
    public async Task SetDefaultPlaybackRate() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_DEFAULT_PLAYBACK_RATE).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.defaultPlaybackRate;");
        Assert.Equal(HTMLMediaElementInProcessGroup.TEST_DEFAULT_PLAYBACK_RATE, result);
    }


    [Fact]
    public async Task GetCrossOrigin() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_CROSS_ORIGIN).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("anonymous", result);
    }

    [Fact]
    public async Task SetCrossOrigin() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_CROSS_ORIGIN).ClickAsync();

        string result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<string>("audioElement => audioElement.crossOrigin;");
        Assert.Equal(HTMLMediaElementInProcessGroup.TEST_CROSS_ORIGIN, result);
    }


    [Fact]
    public async Task GetPreservesPitch() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_PRESERVES_PITCH).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }

    [Fact]
    public async Task SetPreservesPitch() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_PRESERVES_PITCH).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.preservesPitch;");
        Assert.False(result);
    }


    [Fact]
    public async Task GetDisableRemotePlayback() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_DISABLE_REMOTE_PLAYBACK).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetDisableRemotePlayback() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_DISABLE_REMOTE_PLAYBACK).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.disableRemotePlayback;");
        Assert.True(result);
    }

    #endregion


    #region Methods

    [Fact]
    public async Task Play() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_PLAY).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        Assert.False(result);
    }

    [Fact]
    public async Task Pause() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(100);
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_PAUSE).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        Assert.True(result);
        double currentTime = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        Assert.True(currentTime > 0.0);
    }

    [Fact]
    public async Task Load() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(100);
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_LOAD).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        Assert.True(result);
        double currentTime = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        Assert.Equal(0.0, currentTime);
    }

    // does not work in Chromium Browser. To make this test work, go to PlayWrightFixture.InitializeAsync() and change "Chromium" to "Firefox"
    //[Fact]
    //public async Task FastSeek() {
    //    await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

    //    await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_FAST_SEEK).ClickAsync();

    //    double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
    //    Assert.True(Math.Abs(HTMLMediaElementInProcessGroup.TEST_FAST_SEEK - result) < 0.1);
    //}

    [Fact]
    public async Task CanPlayType() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_CAN_PLAY_TYPE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("probably", result);
    }

    #endregion


    #region Events Ready

    [Fact]
    public async Task RegisterOnError() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_ERROR).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'invalid';");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Error: errorCode = 4, MEDIA_ELEMENT_ERROR: Format error", result);
    }

    [Fact]
    public async Task RegisterOnCanplay() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_CANPLAY).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Canplay", result);
    }

    [Fact]
    public async Task RegisterOnCanplaythrough() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_CANPLAYTHROUGH).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Canplaythrough", result);
    }

    [Fact]
    public async Task RegisterOnPlaying() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_PLAYING).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Playing", result);
    }

    #endregion


    #region Events Data

    [Fact]
    public async Task RegisterOnLoadstart() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_LOADSTART).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Loadstart", result);
    }

    [Fact]
    public async Task RegisterOnProgress() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_PROGRESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Progress", result);
    }

    [Fact]
    public async Task RegisterOnLoadeddata() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_LOADEDDATA).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Loadeddata", result);
    }

    [Fact]
    public async Task RegisterOnLoadedmetadata() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_LOADEDMETADATA).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Loadedmetadata", result);
    }

    [Fact]
    public async Task RegisterOnStalled() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_STALLED).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("", result);
        // need proper test setup
        //Assert.Equal("Stalled", result);
    }

    [Fact]
    public async Task RegisterOnSuspend() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_SUSPEND).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Suspend", result);
    }

    [Fact]
    public async Task RegisterOnWaiting() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_WAITING).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("", result);
        // need proper test setup
        //Assert.Equal("Waiting", result);
    }

    [Fact]
    public async Task RegisterOnAbort() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_ABORT).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Abort", result);
    }

    [Fact]
    public async Task RegisterOnEmptied() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_EMPTIED).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Emptied", result);
    }

    #endregion


    #region Events Timing

    [Fact]
    public async Task RegisterOnPlay() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_PLAY).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Play", result);
    }

    [Fact]
    public async Task RegisterOnPause() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_PAUSE).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("""
            audioElement => {
                audioElement.play();
                audioElement.pause();
            }
            """);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Pause", result);
    }

    [Fact]
    public async Task RegisterOnEnded() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_ENDED).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("""
            audioElement => {
                audioElement.currentTime = 60.0;
                audioElement.play();
            }
            """);
        await Task.Delay(1000);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Ended", result);
    }

    [Fact]
    public async Task RegisterOnSeeking() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_SEEKING).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Seeking", result);
    }

    [Fact]
    public async Task RegisterOnSeeked() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_SEEKED).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");
        await Task.Delay(200);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Seeked", result);
    }

    [Fact]
    public async Task RegisterOnTimeupdate() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_TIMEUPDATE).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");
        await Task.Delay(200);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Timeupdate", result);
    }

    #endregion


    #region Events Setting

    [Fact]
    public async Task RegisterOnVolumechange() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_VOLUMECHANGE).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.volume = 0.5;");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Volumechange", result);
    }

    [Fact]
    public async Task RegisterOnRatechange() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_RATECHANGE).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.playbackRate = 0.5;");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Ratechange", result);
    }

    [Fact]
    public async Task RegisterOnDurationchange() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_DURATIONCHANGE).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'invalid';");
        await Task.Delay(300);
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'HTMLMediaElement_audio.mp3';");
        await Task.Delay(300);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("Durationchange", result);
    }

    #endregion
}
