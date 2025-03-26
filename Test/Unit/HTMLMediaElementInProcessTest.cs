using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class HTMLMediaElementInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    #region Attributes

    [Test]
    [Retry(3)]
    public async Task GetSrc() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_SRC).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/HTMLMediaElement_audio.mp3");
    }

    [Test]
    [Retry(3)]
    public async Task SetSrc() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_SRC).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("src");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_SRC);
    }


    [Test]
    [Retry(3)]
    public async Task GetSrcObject() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_SRC_OBJECT).ClickAsync();
        // an assertion happens in DisposeAsync()
    }

    [Test]
    [Retry(3)]
    public async Task SetSrcObject() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_SRC_OBJECT).ClickAsync();
        // an assertion happens in DisposeAsync()
    }


    [Test]
    [Retry(3)]
    public async Task GetControls() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_CONTROLS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    [Retry(3)]
    public async Task SetControls() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_CONTROLS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("controls");
        await Assert.That(result).IsEqualTo("");
    }


    [Test]
    [Retry(3)]
    public async Task GetAutoplay() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_AUTOPLAY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    [Retry(3)]
    public async Task SetAutoplay() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_AUTOPLAY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("autoplay");
        await Assert.That(result).IsEqualTo("");
    }


    [Test]
    [Retry(3)]
    public async Task GetLoop() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_LOOP).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    [Retry(3)]
    public async Task SetLoop() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_LOOP).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("loop");
        await Assert.That(result).IsEqualTo("");
    }


    [Test]
    [Retry(3)]
    public async Task GetDefaultMuted() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_DEFAULT_MUTED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    [Retry(3)]
    public async Task SetDefaultMuted() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_DEFAULT_MUTED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("muted");
        await Assert.That(result).IsEqualTo("");
    }


    [Test]
    [Retry(3)]
    public async Task GetPreload() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_PRELOAD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("auto");
    }

    [Test]
    [Retry(3)]
    public async Task SetPreload() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_PRELOAD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("preload");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_PRELOAD);
    }

    #endregion


    #region State

    [Test]
    [Retry(3)]
    public async Task GetCurrentSrc() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_CURRENT_SRC).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/HTMLMediaElement_audio.mp3");
    }


    [Test]
    [Retry(3)]
    public async Task GetCurrentTime() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_CURRENT_TIME).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    [Retry(3)]
    public async Task SetCurrentTime() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_CURRENT_TIME).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_CURRENT_TIME);
    }


    [Test]
    [Retry(3)]
    public async Task GetDuration() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_DURATION).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("60.0512");
    }


    [Test]
    [Retry(3)]
    public async Task GetSeekable() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_SEEKABLE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1: [0, 60.0512]");
    }


    [Test]
    [Retry(3)]
    public async Task GetMuted() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_MUTED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    [Retry(3)]
    public async Task SetMuted() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_MUTED).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.muted;");
        await Assert.That(result).IsTrue();
    }


    [Test]
    [Retry(3)]
    public async Task GetVolume() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_VOLUME).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    [Retry(3)]
    public async Task SetVolume() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_VOLUME).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.volume;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_VOLUME);
    }


    [Test]
    [Retry(3)]
    public async Task GetPaused() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_PAUSED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    [Retry(3)]
    public async Task GetEnded() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_ENDED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    [Retry(3)]
    public async Task GetSeeking() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_SEEKING).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    [Retry(3)]
    public async Task GetReadyState() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_READY_STATE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotNull().IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task GetNetworkState() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_NETWORK_STATE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }


    [Test]
    [Retry(3)]
    public async Task GetBuffered() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_BUFFERED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result![0] is '0' or '1').IsTrue();
        await Assert.That(result![1] is ':').IsTrue();
        await Assert.That(result![2] is ' ').IsTrue();
    }


    [Test]
    [Retry(3)]
    public async Task GetPlayed() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_PLAYED).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0: ");
    }

    #endregion


    #region Settings

    [Test]
    [Retry(3)]
    public async Task GetPlaybackRate() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_PLAYBACK_RATE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    [Retry(3)]
    public async Task SetPlaybackRate() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_PLAYBACK_RATE).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.playbackRate;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_PLAYBACK_RATE);
    }


    [Test]
    [Retry(3)]
    public async Task GetDefaultPlaybackRate() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_DEFAULT_PLAYBACK_RATE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    [Retry(3)]
    public async Task SetDefaultPlaybackRate() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_DEFAULT_PLAYBACK_RATE).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.defaultPlaybackRate;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_DEFAULT_PLAYBACK_RATE);
    }


    [Test]
    [Retry(3)]
    public async Task GetCrossOrigin() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_CROSS_ORIGIN).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("anonymous");
    }

    [Test]
    [Retry(3)]
    public async Task SetCrossOrigin() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_CROSS_ORIGIN).ClickAsync();

        string result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<string>("audioElement => audioElement.crossOrigin;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_CROSS_ORIGIN);
    }


    [Test]
    [Retry(3)]
    public async Task GetPreservesPitch() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_PRESERVES_PITCH).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    [Retry(3)]
    public async Task SetPreservesPitch() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_PRESERVES_PITCH).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.preservesPitch;");
        await Assert.That(result).IsFalse();
    }


    [Test]
    [Retry(3)]
    public async Task GetDisableRemotePlayback() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_DISABLE_REMOTE_PLAYBACK).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    [Retry(3)]
    public async Task SetDisableRemotePlayback() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_SET_DISABLE_REMOTE_PLAYBACK).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.disableRemotePlayback;");
        await Assert.That(result).IsTrue();
    }

    #endregion


    #region Methods

    [Test]
    [Retry(3)]
    public async Task Play() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_PLAY).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        await Assert.That(result).IsFalse();
    }

    [Test]
    [Retry(3)]
    public async Task Pause() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(100);
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_PAUSE).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        await Assert.That(result).IsTrue();
        double currentTime = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(currentTime > 0.0).IsTrue();
    }

    [Test]
    [Retry(3)]
    public async Task Load() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(100);
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_LOAD).ClickAsync();

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        await Assert.That(result).IsTrue();
        double currentTime = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(currentTime).IsEqualTo(0.0);
    }

    // does not work in Chromium Browser. To make this test work, go to PlayWrightFixture.InitializeAsync() and change "Chromium" to "Firefox"
    [Test, Explicit]
    public async Task FastSeek() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).ClickAsync(); // minimal delay

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_FAST_SEEK).ClickAsync();

        double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(Math.Abs(HTMLMediaElementInProcessGroup.TEST_FAST_SEEK - result) < 0.1).IsTrue();
    }

    [Test]
    [Retry(3)]
    public async Task CanPlayType() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_CAN_PLAY_TYPE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("probably");
    }

    #endregion


    #region Events Ready

    [Test]
    [Retry(3)]
    public async Task RegisterOnError() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_ERROR).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'invalid';");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Error: errorCode = 4, MEDIA_ELEMENT_ERROR: Format error");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnCanplay() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_CANPLAY).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Canplay");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnCanplaythrough() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_CANPLAYTHROUGH).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Canplaythrough");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnPlaying() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_PLAYING).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Playing");
    }

    #endregion


    #region Events Data

    [Test]
    [Retry(3)]
    public async Task RegisterOnLoadstart() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_LOADSTART).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Loadstart");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnProgress() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_PROGRESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Progress");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnLoadeddata() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_LOADEDDATA).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Loadeddata");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnLoadedmetadata() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_LOADEDMETADATA).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Loadedmetadata");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnStalled() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_STALLED).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("");
        // need proper test setup
        //await Assert.That(result).IsEqualTo("Stalled");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnSuspend() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_SUSPEND).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(500);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Suspend");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnWaiting() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_WAITING).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("");
        // need proper test setup
        //await Assert.That(result).IsEqualTo("Waiting");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnAbort() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_ABORT).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Abort");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnEmptied() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_EMPTIED).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Emptied");
    }

    #endregion


    #region Events Timing

    [Test]
    [Retry(3)]
    public async Task RegisterOnPlay() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_PLAY).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Play");
    }

    [Test]
    [Retry(3)]
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
        await Assert.That(result).IsEqualTo("Pause");
    }

    [Test]
    [Retry(3)]
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
        await Assert.That(result).IsEqualTo("Ended");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnSeeking() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_SEEKING).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Seeking");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnSeeked() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_SEEKED).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");
        await Task.Delay(200);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Seeked");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnTimeupdate() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_TIMEUPDATE).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");
        await Task.Delay(200);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Timeupdate");
    }

    #endregion


    #region Events Setting

    [Test]
    [Retry(3)]
    public async Task RegisterOnVolumechange() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_VOLUMECHANGE).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.volume = 0.5;");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Volumechange");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnRatechange() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_RATECHANGE).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.playbackRate = 0.5;");

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Ratechange");
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnDurationchange() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_DURATIONCHANGE).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'invalid';");
        await Task.Delay(300);
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'HTMLMediaElement_audio.mp3';");
        await Task.Delay(300);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Durationchange");
    }

    #endregion
}
