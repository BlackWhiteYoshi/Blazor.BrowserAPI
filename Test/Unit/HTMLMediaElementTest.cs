using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class HTMLMediaElementTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    #region Attributes

    [Test]
    public async Task GetSrc_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_SRC_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/HTMLMediaElement_audio.mp3");
    }

    [Test]
    public async Task GetSrc_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_SRC_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/HTMLMediaElement_audio.mp3");
    }

    [Test]
    public async Task SetSrc() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_SRC).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("src");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_SRC);
    }


    [Test]
    public async Task GetSrcObject_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_SRC_OBJECT_PROPERTY).ClickAsync();
        // an assertion happens in DisposeAsync()
    }

    [Test]
    public async Task GetSrcObject_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_SRC_OBJECT_METHOD).ClickAsync();
        // an assertion happens in DisposeAsync()
    }

    [Test]
    public async Task SetSrcObject() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_SRC_OBJECT).ClickAsync();
        // an assertion happens in DisposeAsync()
    }


    [Test]
    public async Task GetControls_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_CONTROLS_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetControls_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_CONTROLS_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetControls() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_CONTROLS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("controls");
        await Assert.That(result).IsEqualTo("");
    }


    [Test]
    public async Task GetAutoplay_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_AUTOPLAY_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetAutoplay_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_AUTOPLAY_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetAutoplay() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_AUTOPLAY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("autoplay");
        await Assert.That(result).IsEqualTo("");
    }


    [Test]
    public async Task GetLoop_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_LOOP_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetLoop_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_LOOP_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetLoop() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_LOOP).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("loop");
        await Assert.That(result).IsEqualTo("");
    }


    [Test]
    public async Task GetDefaultMuted_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_DEFAULT_MUTED_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetDefaultMuted_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_DEFAULT_MUTED_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetDefaultMuted() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_DEFAULT_MUTED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("muted");
        await Assert.That(result).IsEqualTo("");
    }


    [Test]
    public async Task GetPreload_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PRELOAD_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("auto");
    }

    [Test]
    public async Task GetPreload_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PRELOAD_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("auto");
    }

    [Test]
    public async Task SetPreload() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_PRELOAD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("preload");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_PRELOAD);
    }

    #endregion


    #region State

    [Test]
    public async Task GetCurrentSrc_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_CURRENT_SRC_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/HTMLMediaElement_audio.mp3");
    }

    [Test]
    public async Task GetCurrentSrc_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_CURRENT_SRC_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/HTMLMediaElement_audio.mp3");
    }


    [Test]
    public async Task GetCurrentTime_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_CURRENT_TIME_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    public async Task GetCurrentTime_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_CURRENT_TIME_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    public async Task SetCurrentTime() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_CURRENT_TIME).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_CURRENT_TIME);
    }


    [Test]
    public async Task GetDuration_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_DURATION_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("60.0512");
    }

    [Test]
    public async Task GetDuration_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_DURATION_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("60.0512");
    }


    [Test]
    public async Task GetSeekable_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_SEEKABLE_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1: [0, 60.0512]");
    }

    [Test]
    public async Task GetSeekable_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_SEEKABLE_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1: [0, 60.0512]");
    }


    [Test]
    public async Task GetMuted_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_MUTED_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetMuted_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_MUTED_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetMuted() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_MUTED).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.muted;");
        await Assert.That(result).IsTrue();
    }


    [Test]
    public async Task GetVolume_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_VOLUME_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetVolume_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_VOLUME_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task SetVolume() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_VOLUME).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.volume;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_VOLUME);
    }


    [Test]
    public async Task GetPaused_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PAUSED_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetPaused_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PAUSED_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetEnded_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_ENDED_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetEnded_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_ENDED_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task GetSeeking_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_SEEKING_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetSeeking_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_SEEKING_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task GetReadyState_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_READY_STATE_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotNull().IsNotEmpty();
    }

    [Test]
    public async Task GetReadyState_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_READY_STATE_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotNull().IsNotEmpty();
    }


    [Test]
    public async Task GetNetworkState_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_NETWORK_STATE_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetNetworkState_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_NETWORK_STATE_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }


    [Test]
    public async Task GetBuffered_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_BUFFERED_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result![0] is '0' or '1').IsTrue();
        await Assert.That(result![1] is ':' ).IsTrue();
        await Assert.That(result![2] is ' ').IsTrue();
    }

    [Test]
    public async Task GetBuffered_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_BUFFERED_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result![0] is '0' or '1').IsTrue();
        await Assert.That(result![1] is ':').IsTrue();
        await Assert.That(result![2] is ' ').IsTrue();
    }


    [Test]
    public async Task GetPlayed_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PLAYED_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0: ");
    }

    [Test]
    public async Task GetPlayed_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PLAYED_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0: ");
    }

    #endregion


    #region Settings

    [Test]
    public async Task GetPlaybackRate_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PLAYBACK_RATE_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetPlaybackRate_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PLAYBACK_RATE_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task SetPlaybackRate() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_PLAYBACK_RATE).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.playbackRate;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_PLAYBACK_RATE);
    }


    [Test]
    public async Task GetDefaultPlaybackRate_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_DEFAULT_PLAYBACK_RATE_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetDefaultPlaybackRate_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_DEFAULT_PLAYBACK_RATE_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task SetDefaultPlaybackRate() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_DEFAULT_PLAYBACK_RATE).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.defaultPlaybackRate;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_DEFAULT_PLAYBACK_RATE);
    }


    [Test]
    public async Task GetCrossOrigin_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_CROSS_ORIGIN_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("anonymous");
    }

    [Test]
    public async Task GetCrossOrigin_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_CROSS_ORIGIN_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("anonymous");
    }

    [Test]
    public async Task SetCrossOrigin() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_CROSS_ORIGIN).ClickAsync();

        string result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<string>("audioElement => audioElement.crossOrigin;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_CROSS_ORIGIN);
    }


    [Test]
    public async Task GetPreservesPitch_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PRESERVES_PITCH_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetPreservesPitch_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_PRESERVES_PITCH_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetPreservesPitch() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_PRESERVES_PITCH).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.preservesPitch;");
        await Assert.That(result).IsFalse();
    }


    [Test]
    public async Task GetDisableRemotePlayback_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_DISABLE_REMOTE_PLAYBACK_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetDisableRemotePlayback_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_DISABLE_REMOTE_PLAYBACK_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetDisableRemotePlayback() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_SET_DISABLE_REMOTE_PLAYBACK).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.disableRemotePlayback;");
        await Assert.That(result).IsTrue();
    }

    #endregion


    #region Methods

    [Test]
    public async Task Play() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_PLAY).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Pause() {
        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(100);
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_PAUSE).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        await Assert.That(result).IsTrue();
        double currentTime = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(currentTime > 0.0).IsTrue();
    }

    [Test]
    public async Task Load() {
        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(100);
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_LOAD).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        await Assert.That(result).IsTrue();
        double currentTime = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(currentTime).IsEqualTo(0.0);
    }

    // does not work in Chromium Browser. To make this test work, go to PlayWrightFixture.InitializeAsync() and change "Chromium" to "Firefox"
    [Test, Explicit]
    public async Task FastSeek() {
        await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_FAST_SEEK).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(Math.Abs(HTMLMediaElementGroup.TEST_FAST_SEEK - result) < 0.1).IsTrue();
    }

    [Test]
    public async Task CanPlayType() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_CAN_PLAY_TYPE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("probably");
    }

    #endregion


    #region Events

    // Ready

    [Test]
    public async Task RegisterOnError() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_ERROR).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'invalid';");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Error: errorCode = 4, MEDIA_ELEMENT_ERROR: Format error");
    }

    [Test]
    public async Task RegisterOnCanplay() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_CANPLAY).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Canplay");
    }

    [Test]
    public async Task RegisterOnCanplaythrough() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_CANPLAYTHROUGH).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Canplaythrough");
    }

    [Test]
    public async Task RegisterOnPlaying() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_PLAYING).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Playing");
    }

    
    // Data

    [Test]
    public async Task RegisterOnLoadstart() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_LOADSTART).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Loadstart");
    }

    [Test]
    public async Task RegisterOnProgress() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_PROGRESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Progress");
    }

    [Test]
    public async Task RegisterOnLoadeddata() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_LOADEDDATA).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Loadeddata");
    }

    [Test]
    public async Task RegisterOnLoadedmetadata() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_LOADEDMETADATA).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Loadedmetadata");
    }

    [Test]
    public async Task RegisterOnStalled() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_STALLED).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("");
        // need proper test setup
        //await Assert.That(result).IsEqualTo("Stalled");
    }

    [Test]
    public async Task RegisterOnSuspend() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_SUSPEND).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Suspend");
    }

    [Test]
    public async Task RegisterOnWaiting() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_WAITING).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("");
        // need proper test setup
        //await Assert.That(result).IsEqualTo("Waiting");
    }

    [Test]
    public async Task RegisterOnAbort() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_ABORT).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Abort");
    }

    [Test]
    public async Task RegisterOnEmptied() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_EMPTIED).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Emptied");
    }

    
    // Timing

    [Test]
    public async Task RegisterOnPlay() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_PLAY).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Play");
    }

    [Test]
    public async Task RegisterOnPause() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_PAUSE).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("""
            audioElement => {
                audioElement.play();
                audioElement.pause();
            }
            """);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Pause");
    }

    [Test]
    public async Task RegisterOnEnded() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_ENDED).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("""
            audioElement => {
                audioElement.currentTime = 60.0;
                audioElement.play();
            }
            """);
        await Task.Delay(1000);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Ended");
    }

    [Test]
    public async Task RegisterOnSeeking() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_SEEKING).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Seeking");
    }

    [Test]
    public async Task RegisterOnSeeked() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_SEEKED).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");
        await Task.Delay(200);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Seeked");
    }

    [Test]
    public async Task RegisterOnTimeupdate() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_TIMEUPDATE).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");
        await Task.Delay(200);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Timeupdate");
    }

    
    // Setting

    [Test]
    public async Task RegisterOnVolumechange() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_VOLUMECHANGE).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.volume = 0.5;");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Volumechange");
    }

    [Test]
    public async Task RegisterOnRatechange() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_RATECHANGE).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.playbackRate = 0.5;");

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Ratechange");
    }

    [Test]
    public async Task RegisterOnDurationchange() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_REGISTER_ON_DURATIONCHANGE).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'invalid';");
        await Task.Delay(300);
        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'HTMLMediaElement_audio.mp3';");
        await Task.Delay(300);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Durationchange");
    }

    #endregion
}
