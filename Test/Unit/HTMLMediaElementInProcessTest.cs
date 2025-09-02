using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class HTMLMediaElementInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override Task InitializeAsync()
        => TestContext.Current?.TestName switch {
            nameof(GetVideoWidth)
            or nameof(GetVideoHeight)
            or nameof(RegisterOnResize) => NewPage(BrowserId.Firefox),
            nameof(FastSeek) => NewPage(BrowserId.Firefox),
            _ => NewPage(BrowserId.Chromium)
        };


    [Test]
    public async Task ToHTMLElement() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_TO_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    #region Attributes

    [Test]
    public async Task GetSrc() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_SRC);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/HTMLMediaElement_audio.mp3");
    }

    [Test]
    public async Task SetSrc() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_SRC);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("src");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_SRC);
    }


    [Test]
    public async Task GetSrcObject() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_SRC_OBJECT);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetSrcObject() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_SRC_OBJECT);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_SET_SRC_OBJECT);
    }


    [Test]
    public async Task GetControls() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_CONTROLS);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetControls() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_CONTROLS);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("controls");
        await Assert.That(result).IsNull();
    }


    [Test]
    public async Task GetAutoplay() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_AUTOPLAY);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetAutoplay() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_AUTOPLAY);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("autoplay");
        await Assert.That(result).IsEqualTo("");
    }


    [Test]
    public async Task GetLoop() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_LOOP);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetLoop() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_LOOP);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("loop");
        await Assert.That(result).IsEqualTo("");
    }


    [Test]
    public async Task GetDefaultMuted() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_DEFAULT_MUTED);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetDefaultMuted() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_DEFAULT_MUTED);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("muted");
        await Assert.That(result).IsEqualTo("");
    }


    [Test]
    public async Task GetPreload() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_PRELOAD);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("metadata");
    }

    [Test]
    public async Task SetPreload() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_PRELOAD);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).GetAttributeAsync("preload");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_PRELOAD);
    }

    #endregion


    #region State

    [Test]
    public async Task GetCurrentSrc() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_CURRENT_SRC);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/HTMLMediaElement_audio.mp3");
    }


    [Test]
    public async Task GetCurrentTime() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_CURRENT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    public async Task SetCurrentTime() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_CURRENT_TIME);

        double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_CURRENT_TIME);
    }


    [Test]
    public async Task GetDuration() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_DURATION).WaitForAsync(); // minimal delay
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_DURATION);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("60.0512");
    }


    [Test]
    public async Task GetSeekable() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_SEEKABLE).WaitForAsync(); // minimal delay
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_SEEKABLE);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1: [0, 60.0512]");
    }


    [Test]
    public async Task GetMuted() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_MUTED);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetMuted() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_MUTED);

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.muted;");
        await Assert.That(result).IsTrue();
    }


    [Test]
    public async Task GetVolume() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_VOLUME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task SetVolume() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_VOLUME);

        double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.volume;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_VOLUME);
    }


    [Test]
    public async Task GetPaused() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_PAUSED);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetEnded() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_ENDED);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task GetSeeking() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_SEEKING);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task GetReadyState() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_READY_STATE);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotNull().IsNotEmpty();
    }


    [Test]
    public async Task GetNetworkState() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_GET_NETWORK_STATE).WaitForAsync(); // minimal delay
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_NETWORK_STATE);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }


    [Test]
    public async Task GetBuffered() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_BUFFERED);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result![0] is '0' or '1').IsTrue();
        await Assert.That(result![1]).IsEqualTo(':');
        await Assert.That(result![2]).IsEqualTo(' ');
    }


    [Test]
    public async Task GetPlayed() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_PLAYED);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0: ");
    }

    #endregion


    #region Settings

    [Test]
    public async Task GetPlaybackRate() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_PLAYBACK_RATE);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task SetPlaybackRate() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_PLAYBACK_RATE);

        double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.playbackRate;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_PLAYBACK_RATE);
    }


    [Test]
    public async Task GetDefaultPlaybackRate() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_DEFAULT_PLAYBACK_RATE);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task SetDefaultPlaybackRate() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_DEFAULT_PLAYBACK_RATE);

        double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.defaultPlaybackRate;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_DEFAULT_PLAYBACK_RATE);
    }


    [Test]
    public async Task GetCrossOrigin() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_CROSS_ORIGIN);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("anonymous");
    }

    [Test]
    public async Task SetCrossOrigin() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_CROSS_ORIGIN);

        string result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<string>("audioElement => audioElement.crossOrigin;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_CROSS_ORIGIN);
    }


    [Test]
    public async Task GetPreservesPitch() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_PRESERVES_PITCH);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetPreservesPitch() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_PRESERVES_PITCH);

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.preservesPitch;");
        await Assert.That(result).IsFalse();
    }


    [Test]
    public async Task GetDisableRemotePlayback() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_DISABLE_REMOTE_PLAYBACK);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetDisableRemotePlayback() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_DISABLE_REMOTE_PLAYBACK);

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.disableRemotePlayback;");
        await Assert.That(result).IsTrue();
    }

    #endregion


    #region Video (<video> elements only)

    [Test]
    public async Task GetWidth() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync($"videoElement => videoElement.width = {HTMLMediaElementInProcessGroup.TEST_VIDEO_WIDTH};");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_WIDTH);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_VIDEO_WIDTH.ToString());
    }

    [Test]
    public async Task SetWidth() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_WIDTH);

        int result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync<int>("videoElement => videoElement.width;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_VIDEO_WIDTH);
    }


    [Test]
    public async Task GetHeight() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync($"videoElement => videoElement.height = {HTMLMediaElementInProcessGroup.TEST_VIDEO_HEIGHT};");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_HEIGHT);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_VIDEO_HEIGHT.ToString());
    }

    [Test]
    public async Task SetHeight() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_HEIGHT);

        int result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync<int>("videoElement => videoElement.height;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_VIDEO_HEIGHT);
    }


    [Test]
    public async Task GetVideoWidth() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_VIDEO_WIDTH);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1280");
    }

    [Test]
    public async Task GetVideoHeight() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_VIDEO_HEIGHT);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("720");
    }


    [Test]
    public async Task GetPoster() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync($"""videoElement => videoElement.poster = "{HTMLMediaElementInProcessGroup.TEST_VIDEO_POSTER}";""");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_POSTER);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_VIDEO_POSTER);
    }

    [Test]
    public async Task SetPoster() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_POSTER);

        string result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync<string>("videoElement => videoElement.poster;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_VIDEO_POSTER);
    }


    [Test]
    public async Task GetDisablePictureInPicture() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_DISABLE_PICTURE_IN_PICTURE);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetDisablePictureInPicture() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_SET_DISABLE_PICTURE_IN_PICTURE);

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync<bool>("videoElement => videoElement.disablePictureInPicture;");
        await Assert.That(result).IsTrue();
    }

    #endregion


    /* Chromium does not load .mp4 and firefox does not support this feauture

    #region PictureInPictureWindow

    [Test]
    public async Task GetPictureInPictureWindowWidth() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_PICTURE_IN_PICTURE_WINDOW_WIDTH);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThan(0);
    }

    [Test]
    public async Task GetPictureInPictureWindowHeight() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_GET_PICTURE_IN_PICTURE_WINDOW_HEIGHT);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThan(0);
    }


    [Test]
    public async Task RegisterPictureInPictureWindowOnResize() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_PICTURE_IN_PICTURE_WINDOW_ON_RESIZE);

        // ? resize floating video

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_PICTURE_IN_PICTURE_WINDOW_RESIZE);
    }

    #endregion

    */


    #region Methods

    [Test]
    public async Task Play() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_PLAY);

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Pause() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(4 * STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_PAUSE);

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        await Assert.That(result).IsTrue();
        double currentTime = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(currentTime).IsGreaterThan(0.0);
    }

    [Test]
    public async Task Load() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_LOAD);

        bool result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        await Assert.That(result).IsTrue();
        double currentTime = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(currentTime).IsEqualTo(0.0);
    }

    [Test]
    public async Task FastSeek() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.BUTTON_FAST_SEEK).WaitForAsync(); // minimal delay
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_FAST_SEEK);

        double result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(Math.Abs(HTMLMediaElementInProcessGroup.TEST_FAST_SEEK - result) < 0.1).IsTrue();
    }

    [Test]
    public async Task CanPlayType() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_CAN_PLAY_TYPE);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("probably");
    }


    /* Chromium does not load .mp4 and firefox does not support this feauture

    [Test]
    public async Task RequestPictureInPicture() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REQUEST_PICTURE_IN_PICTURE);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    */

    #endregion


    #region Events

    // Ready

    [Test]
    public async Task RegisterOnError() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_ERROR);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'invalid';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo($"{HTMLMediaElementInProcessGroup.TEST_EVENT_ERROR}: errorCode = 4, MEDIA_ELEMENT_ERROR: Format error");
    }

    [Test]
    public async Task RegisterOnCanPlay() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_CAN_PLAY);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_CAN_PLAY);
    }

    [Test]
    public async Task RegisterOnCanPlayThrough() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_CAN_PLAY_THROUGH);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_CAN_PLAY_THROUGH);
    }

    [Test]
    public async Task RegisterOnPlaying() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_PLAYING);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_PLAYING);
    }


    // Data

    [Test]
    public async Task RegisterOnLoadStart() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_LOAD_START);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_LOAD_START);
    }

    [Test]
    public async Task RegisterOnProgress() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_PROGRESS);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_PROGRESS);
    }

    [Test]
    public async Task RegisterOnLoadedData() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_LOADED_DATA);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_LOADED_DATA);
    }

    [Test]
    public async Task RegisterOnLoadedMetadata() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_LOADED_METADATA);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_LOADED_METADATA);
    }

    [Test]
    public async Task RegisterOnStalled() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_STALLED);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.dispatchEvent(new Event('stalled'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_STALLED);
    }

    [Test]
    public async Task RegisterOnSuspend() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_SUSPEND);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_SUSPEND);
    }

    [Test]
    public async Task RegisterOnWaiting() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_WAITING);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.dispatchEvent(new Event('waiting'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_WAITING);
    }

    [Test]
    public async Task RegisterOnAbort() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_ABORT);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_ABORT);
    }

    [Test]
    public async Task RegisterOnEmptied() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_EMPTIED);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_EMPTIED);
    }


    // Timing

    [Test]
    public async Task RegisterOnPlay() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_PLAY);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_PLAY);
    }

    [Test]
    public async Task RegisterOnPause() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_PAUSE);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("""
            audioElement => {
                audioElement.play();
                audioElement.pause();
            }
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_PAUSE);
    }

    [Test]
    public async Task RegisterOnEnded() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_ENDED);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("""
            audioElement => {
                audioElement.currentTime = 60.0;
                audioElement.play();
            }
            """);
        await Task.Delay(4 * STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_ENDED);
    }

    [Test]
    public async Task RegisterOnSeeking() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_SEEKING);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_SEEKING);
    }

    [Test]
    public async Task RegisterOnSeeked() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_SEEKED);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_SEEKED);
    }

    [Test]
    public async Task RegisterOnTimeUpdate() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_TIME_UPDATE);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_TIME_UPDATE);
    }


    // Setting

    [Test]
    public async Task RegisterOnVolumeChange() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_VOLUME_CHANGE);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.volume = 0.5;");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_VOLUME_CHANGE);
    }

    [Test]
    public async Task RegisterOnRateChange() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_RATE_CHANGE);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.playbackRate = 0.5;");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_RATE_CHANGE);
    }

    [Test]
    public async Task RegisterOnDurationChange() {
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_DURATION_CHANGE);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'invalid';");
        await Task.Delay(STANDARD_WAIT_TIME);
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'HTMLMediaElement_audio.mp3';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_DURATION_CHANGE);
    }


    // Video

    [Test]
    public async Task RegisterOnResize() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.src = '';");
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_RESIZE);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.src = 'HTMLMediaElement_video.mp4';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_RESIZE);
    }

    /* Chromium does not load .mp4 and firefox does not support PictureInPictureWindow

    [Test]
    public async Task RegisterOnEnterPictureInPicture() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_ENTER_PICTURE_IN_PICTURE);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.requestPictureInPicture();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_ENTER_PICTURE_IN_PICTURE);
    }

    [Test]
    public async Task RegisterOnLeavePictureInPicture() {
        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await ExecuteTest(HTMLMediaElementInProcessGroup.BUTTON_REGISTER_ON_ENTER_PICTURE_IN_PICTURE);

        await Page.GetByTestId(HTMLMediaElementInProcessGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.requestPictureInPicture();");
        await Task.Delay(STANDARD_WAIT_TIME);

        // close window

        string? result = await Page.GetByTestId(HTMLMediaElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementInProcessGroup.TEST_EVENT_LEAVE_PICTURE_IN_PICTURE);
    }

    */

    #endregion
}
