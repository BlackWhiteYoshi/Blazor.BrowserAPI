using BrowserAPI.Test.Client;
using TUnit.Core.Interfaces;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class HTMLMediaElementTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override Task InitializeAsync()
        => (TestContext.Current as ITestMetadata)?.DisplayName switch {
            nameof(GetVideoWidth_Property)
            or nameof(GetVideoWidth_Method)
            or nameof(GetVideoHeight_Property)
            or nameof(GetVideoHeight_Method)
            or nameof(RegisterOnResize) => NewPage(BrowserId.Firefox),
            nameof(FastSeek) => NewPage(BrowserId.Firefox),
            _ => NewPage(BrowserId.Chromium)
        };


    [Test]
    public async Task ToHTMLElement() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_TO_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    #region Attributes

    [Test]
    public async Task GetSrc_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_SRC_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/HTMLMediaElement_audio.mp3");
    }

    [Test]
    public async Task GetSrc_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_SRC_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/HTMLMediaElement_audio.mp3");
    }

    [Test]
    public async Task SetSrc() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_SRC);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("src");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_SRC);
    }


    [Test]
    public async Task GetSrcObject_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_SRC_OBJECT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetSrcObject_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_SRC_OBJECT_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetSrcObject() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_SRC_OBJECT);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_SET_SRC_OBJECT);
    }


    [Test]
    public async Task GetControls_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_CONTROLS_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetControls_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_CONTROLS_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetControls() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_CONTROLS);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("controls");
        await Assert.That(result).IsNull();
    }


    [Test]
    public async Task GetAutoplay_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_AUTOPLAY_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetAutoplay_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_AUTOPLAY_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetAutoplay() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_AUTOPLAY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("autoplay");
        await Assert.That(result).IsEqualTo("");
    }


    [Test]
    public async Task GetLoop_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_LOOP_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetLoop_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_LOOP_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetLoop() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_LOOP);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("loop");
        await Assert.That(result).IsEqualTo("");
    }


    [Test]
    public async Task GetDefaultMuted_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_DEFAULT_MUTED_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetDefaultMuted_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_DEFAULT_MUTED_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetDefaultMuted() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_DEFAULT_MUTED);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("muted");
        await Assert.That(result).IsEqualTo("");
    }


    [Test]
    public async Task GetPreload_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_PRELOAD_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("metadata");
    }

    [Test]
    public async Task GetPreload_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_PRELOAD_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("metadata");
    }

    [Test]
    public async Task SetPreload() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_PRELOAD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).GetAttributeAsync("preload");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_PRELOAD);
    }

    #endregion


    #region State

    [Test]
    public async Task GetCurrentSrc_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_CURRENT_SRC_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/HTMLMediaElement_audio.mp3");
    }

    [Test]
    public async Task GetCurrentSrc_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_CURRENT_SRC_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/HTMLMediaElement_audio.mp3");
    }


    [Test]
    public async Task GetCurrentTime_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_CURRENT_TIME_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    public async Task GetCurrentTime_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_CURRENT_TIME_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    public async Task SetCurrentTime() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_CURRENT_TIME);

        double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_CURRENT_TIME);
    }


    [Test]
    public async Task GetDuration_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_DURATION_PROPERTY).WaitForAsync(); // minimal delay
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_DURATION_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("60.0512");
    }

    [Test]
    public async Task GetDuration_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_DURATION_METHOD).WaitForAsync(); // minimal delay
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_DURATION_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("60.0512");
    }


    [Test]
    public async Task GetSeekable_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_SEEKABLE_PROPERTY).WaitForAsync(); // minimal delay
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_SEEKABLE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1: [0, 60.0512]");
    }

    [Test]
    public async Task GetSeekable_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_SEEKABLE_METHOD).WaitForAsync(); // minimal delay
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_SEEKABLE_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1: [0, 60.0512]");
    }


    [Test]
    public async Task GetMuted_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_MUTED_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetMuted_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_MUTED_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetMuted() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_MUTED);

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.muted;");
        await Assert.That(result).IsTrue();
    }


    [Test]
    public async Task GetVolume_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_VOLUME_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetVolume_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_VOLUME_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task SetVolume() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_VOLUME);

        double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.volume;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_VOLUME);
    }


    [Test]
    public async Task GetPaused_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_PAUSED_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetPaused_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_PAUSED_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetEnded_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_ENDED_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetEnded_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_ENDED_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task GetSeeking_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_SEEKING_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetSeeking_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_SEEKING_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task GetReadyState_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_READY_STATE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotNullOrEmpty();
    }

    [Test]
    public async Task GetReadyState_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_READY_STATE_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotNullOrEmpty();
    }


    [Test]
    public async Task GetNetworkState_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_NETWORK_STATE_PROPERTY).WaitForAsync(); // minimal delay
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_NETWORK_STATE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetNetworkState_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_GET_NETWORK_STATE_METHOD).WaitForAsync(); // minimal delay
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_NETWORK_STATE_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }


    [Test]
    public async Task GetBuffered_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_BUFFERED_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result![0] is '0' or '1').IsTrue();
        await Assert.That(result![1]).IsEqualTo(':');
        await Assert.That(result![2]).IsEqualTo(' ');
    }

    [Test]
    public async Task GetBuffered_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_BUFFERED_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result![0] is '0' or '1').IsTrue();
        await Assert.That(result![1] is ':').IsTrue();
        await Assert.That(result![2] is ' ').IsTrue();
    }


    [Test]
    public async Task GetPlayed_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_PLAYED_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0: ");
    }

    [Test]
    public async Task GetPlayed_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_PLAYED_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0: ");
    }

    #endregion


    #region Settings

    [Test]
    public async Task GetPlaybackRate_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_PLAYBACK_RATE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetPlaybackRate_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_PLAYBACK_RATE_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task SetPlaybackRate() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_PLAYBACK_RATE);

        double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.playbackRate;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_PLAYBACK_RATE);
    }


    [Test]
    public async Task GetDefaultPlaybackRate_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_DEFAULT_PLAYBACK_RATE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetDefaultPlaybackRate_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_DEFAULT_PLAYBACK_RATE_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task SetDefaultPlaybackRate() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_DEFAULT_PLAYBACK_RATE);

        double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.defaultPlaybackRate;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_DEFAULT_PLAYBACK_RATE);
    }


    [Test]
    public async Task GetCrossOrigin_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_CROSS_ORIGIN_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("anonymous");
    }

    [Test]
    public async Task GetCrossOrigin_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_CROSS_ORIGIN_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("anonymous");
    }

    [Test]
    public async Task SetCrossOrigin() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_CROSS_ORIGIN);

        string result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<string>("audioElement => audioElement.crossOrigin;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_CROSS_ORIGIN);
    }


    [Test]
    public async Task GetPreservesPitch_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_PRESERVES_PITCH_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetPreservesPitch_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_PRESERVES_PITCH_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetPreservesPitch() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_PRESERVES_PITCH);

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.preservesPitch;");
        await Assert.That(result).IsFalse();
    }


    [Test]
    public async Task GetDisableRemotePlayback_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_DISABLE_REMOTE_PLAYBACK_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetDisableRemotePlayback_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_DISABLE_REMOTE_PLAYBACK_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetDisableRemotePlayback() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_DISABLE_REMOTE_PLAYBACK);

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.disableRemotePlayback;");
        await Assert.That(result).IsTrue();
    }

    #endregion


    #region Video (<video> elements only)

    [Test]
    public async Task GetWidth_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync($"videoElement => videoElement.width = {HTMLMediaElementGroup.TEST_VIDEO_WIDTH};");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_WIDTH_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_VIDEO_WIDTH.ToString());
    }

    [Test]
    public async Task GetWidth_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync($"videoElement => videoElement.width = {HTMLMediaElementGroup.TEST_VIDEO_WIDTH};");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_WIDTH_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_VIDEO_WIDTH.ToString());
    }

    [Test]
    public async Task SetWidth() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_WIDTH);

        int result = await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync<int>("videoElement => videoElement.width;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_VIDEO_WIDTH);
    }


    [Test]
    public async Task GetHeight_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync($"videoElement => videoElement.height = {HTMLMediaElementGroup.TEST_VIDEO_HEIGHT};");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_HEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_VIDEO_HEIGHT.ToString());
    }

    [Test]
    public async Task GetHeight_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync($"videoElement => videoElement.height = {HTMLMediaElementGroup.TEST_VIDEO_HEIGHT};");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_HEIGHT_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_VIDEO_HEIGHT.ToString());
    }

    [Test]
    public async Task SetHeight() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_HEIGHT);

        int result = await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync<int>("videoElement => videoElement.height;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_VIDEO_HEIGHT);
    }


    [Test]
    public async Task GetVideoWidth_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_VIDEO_WIDTH_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1280");
    }

    [Test]
    public async Task GetVideoWidth_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_VIDEO_WIDTH_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1280");
    }


    [Test]
    public async Task GetVideoHeight_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_VIDEO_HEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("720");
    }

    [Test]
    public async Task GetVideoHeight_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_VIDEO_HEIGHT_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("720");
    }


    [Test]
    public async Task GetPoster_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync($"""videoElement => videoElement.poster = "{HTMLMediaElementGroup.TEST_VIDEO_POSTER}";""");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_POSTER_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_VIDEO_POSTER);
    }

    [Test]
    public async Task GetPoster_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync($"""videoElement => videoElement.poster = "{HTMLMediaElementGroup.TEST_VIDEO_POSTER}";""");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_POSTER_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_VIDEO_POSTER);
    }

    [Test]
    public async Task SetPoster() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_POSTER);

        string result = await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync<string>("videoElement => videoElement.poster;");
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_VIDEO_POSTER);
    }


    [Test]
    public async Task GetDisablePictureInPicture_Property() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_DISABLE_PICTURE_IN_PICTURE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetDisablePictureInPicture_Method() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_DISABLE_PICTURE_IN_PICTURE_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetDisablePictureInPicture() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_SET_DISABLE_PICTURE_IN_PICTURE);

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync<bool>("videoElement => videoElement.disablePictureInPicture;");
        await Assert.That(result).IsTrue();
    }

    #endregion


    /* Chromium does not load .mp4 and firefox does not support PictureInPictureWindow

    #region PictureInPictureWindow

    [Test]
    public async Task GetPictureInPictureWindowWidth_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_PICTURE_IN_PICTURE_WINDOW_WIDTH_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThan(0);
    }

    [Test]
    public async Task GetPictureInPictureWindowWidth_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_PICTURE_IN_PICTURE_WINDOW_WIDTH_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThan(0);
    }


    [Test]
    public async Task GetPictureInPictureWindowHeight_Property() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_PICTURE_IN_PICTURE_WINDOW_HEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThan(0);
    }

    [Test]
    public async Task GetPictureInPictureWindowHeight_Method() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_GET_PICTURE_IN_PICTURE_WINDOW_HEIGHT_METHOD);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThan(0);
    }


    [Test]
    public async Task RegisterPictureInPictureWindowOnResize() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_PICTURE_IN_PICTURE_WINDOW_ON_RESIZE);

        // ? resize floating video

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_PICTURE_IN_PICTURE_WINDOW_RESIZE);
    }

    #endregion

    */


    #region Methods

    [Test]
    public async Task Play() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_PLAY);

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Pause() {
        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(4 * STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_PAUSE);

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        await Assert.That(result).IsTrue();
        double currentTime = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(currentTime).IsGreaterThan(0.0);
    }

    [Test]
    public async Task Load() {
        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_LOAD);

        bool result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<bool>("audioElement => audioElement.paused;");
        await Assert.That(result).IsTrue();
        double currentTime = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(currentTime).IsEqualTo(0.0);
    }

    [Test]
    public async Task FastSeek() {
        await Page.GetByTestId(HTMLMediaElementGroup.BUTTON_FAST_SEEK).WaitForAsync(); // minimal delay
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_FAST_SEEK);

        double result = await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync<double>("audioElement => audioElement.currentTime;");
        await Assert.That(Math.Abs(HTMLMediaElementGroup.TEST_FAST_SEEK - result) < 0.1).IsTrue();
    }

    [Test]
    public async Task CanPlayType() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_CAN_PLAY_TYPE);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("probably");
    }


    /* Chromium does not load .mp4 and firefox does not support PictureInPictureWindow

    [Test]
    public async Task RequestPictureInPicture() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REQUEST_PICTURE_IN_PICTURE);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    */

    #endregion


    #region Events

    // Ready

    [Test]
    public async Task RegisterOnError() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_ERROR);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'invalid';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo($"{HTMLMediaElementGroup.TEST_EVENT_ERROR}: errorCode = 4, MEDIA_ELEMENT_ERROR: Format error");
    }

    [Test]
    public async Task RegisterOnCanPlay() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_CAN_PLAY);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_CAN_PLAY);
    }

    [Test]
    public async Task RegisterOnCanPlayThrough() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_CAN_PLAY_THROUGH);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_CAN_PLAY_THROUGH);
    }

    [Test]
    public async Task RegisterOnPlaying() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_PLAYING);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_PLAYING);
    }


    // Data

    [Test]
    public async Task RegisterOnLoadStart() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_LOAD_START);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_LOAD_START);
    }

    [Test]
    public async Task RegisterOnProgress() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_PROGRESS);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_PROGRESS);
    }

    [Test]
    public async Task RegisterOnLoadedData() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_LOADED_DATA);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_LOADED_DATA);
    }

    [Test]
    public async Task RegisterOnLoadedMetadata() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_LOADED_METADATA);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_LOADED_METADATA);
    }

    [Test]
    public async Task RegisterOnStalled() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_STALLED);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.dispatchEvent(new Event('stalled'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_STALLED);
    }

    [Test]
    public async Task RegisterOnSuspend() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_SUSPEND);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_SUSPEND);
    }

    [Test]
    public async Task RegisterOnWaiting() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_WAITING);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.dispatchEvent(new Event('waiting'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_WAITING);
    }

    [Test]
    public async Task RegisterOnAbort() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_ABORT);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_ABORT);
    }

    [Test]
    public async Task RegisterOnEmptied() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_EMPTIED);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.load();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_EMPTIED);
    }


    // Timing

    [Test]
    public async Task RegisterOnPlay() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_PLAY);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.play();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_PLAY);
    }

    [Test]
    public async Task RegisterOnPause() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_PAUSE);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("""
            audioElement => {
                audioElement.play();
                audioElement.pause();
            }
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_PAUSE);
    }

    [Test]
    public async Task RegisterOnEnded() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_ENDED);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("""
            audioElement => {
                audioElement.currentTime = 60.0;
                audioElement.play();
            }
            """);
        await Task.Delay(4 * STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_ENDED);
    }

    [Test]
    public async Task RegisterOnSeeking() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_SEEKING);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_SEEKING);
    }

    [Test]
    public async Task RegisterOnSeeked() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_SEEKED);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_SEEKED);
    }

    [Test]
    public async Task RegisterOnTimeUpdate() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_TIME_UPDATE);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.currentTime = 10.0;");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_TIME_UPDATE);
    }


    // Setting

    [Test]
    public async Task RegisterOnVolumeChange() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_VOLUME_CHANGE);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.volume = 0.5;");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_VOLUME_CHANGE);
    }

    [Test]
    public async Task RegisterOnRateChange() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_RATE_CHANGE);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.playbackRate = 0.5;");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_RATE_CHANGE);
    }

    [Test]
    public async Task RegisterOnDurationChange() {
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_DURATION_CHANGE);

        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'invalid';");
        await Task.Delay(STANDARD_WAIT_TIME);
        await Page.GetByTestId(HTMLMediaElementGroup.AUDIO_ELEMENT).EvaluateAsync("audioElement => audioElement.src = 'HTMLMediaElement_audio.mp3';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_DURATION_CHANGE);
    }


    // Video

    [Test]
    public async Task RegisterOnResize() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.src = '';");
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_RESIZE);

        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.src = 'HTMLMediaElement_video.mp4';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_RESIZE);
    }

    /* Chromium does not load .mp4 and firefox does not support PictureInPictureWindow

    [Test]
    public async Task RegisterOnEnterPictureInPicture() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_ENTER_PICTURE_IN_PICTURE);

        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.requestPictureInPicture();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_ENTER_PICTURE_IN_PICTURE);
    }

    [Test]
    public async Task RegisterOnLeavePictureInPicture() {
        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.load();");
        await ExecuteTest(HTMLMediaElementGroup.BUTTON_REGISTER_ON_ENTER_PICTURE_IN_PICTURE);

        await Page.GetByTestId(HTMLMediaElementGroup.VIDEO_ELEMENT).EvaluateAsync("videoElement => videoElement.requestPictureInPicture();");
        await Task.Delay(STANDARD_WAIT_TIME);

        // close window

        string? result = await Page.GetByTestId(HTMLMediaElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLMediaElementGroup.TEST_EVENT_LEAVE_PICTURE_IN_PICTURE);
    }

    */

    #endregion
}
