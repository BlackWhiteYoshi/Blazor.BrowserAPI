using BrowserAPI.Test.Client;
using Microsoft.Playwright;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class MediaDevicesTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    private const string MEDIA_STREAM_ID = "fake-stream";
    private const string MEDIA_RECORDER_MIMETYPE = "video/mp4";
    private const string MEDIA_RECORDER_STATE = "inactive";
    private const string MEDIA_RECORDER_AUDIO_BITS_PER_SECOND = "1200";
    private const string MEDIA_RECORDER_VIDEO_BITS_PER_SECOND = "2400";
    private const string MEDIA_RECORDER_START_MESSAGE = "start executed";
    private const string MEDIA_RECORDER_STOP_MESSAGE = "stop executed";
    private const string MEDIA_RECORDER_RESUME_MESSAGE = "resume executed";
    private const string MEDIA_RECORDER_PAUSE_MESSAGE = "pause executed";
    private const string MEDIA_RECORDER_REQUESTDATA_MESSAGE = "requestData executed";
    private const string MEDIA_RECORDER_EVENT_ERROR_MESSAGE = "fake-error";

    private const string JS_MEDIASTREAM_OBJECT = $$"""
        {
            id: "{{MEDIA_STREAM_ID}}",
            active: true,
            getTracks: () => []
        }
        """;

    private const string JS_MEDIARECORDER_OBJECT = $$"""
        {
            mimeType: "{{MEDIA_RECORDER_MIMETYPE}}",
            state: "{{MEDIA_RECORDER_STATE}}",
            stream: mediaStream,
            audioBitsPerSecond: {{MEDIA_RECORDER_AUDIO_BITS_PER_SECOND}},
            videoBitsPerSecond: {{MEDIA_RECORDER_VIDEO_BITS_PER_SECOND}},

            start: (timeslice) => console.log('{{MEDIA_RECORDER_START_MESSAGE}}'),
            stop: () => console.log('{{MEDIA_RECORDER_STOP_MESSAGE}}'),
            resume: () => console.log('{{MEDIA_RECORDER_RESUME_MESSAGE}}'),
            pause: () => console.log('{{MEDIA_RECORDER_PAUSE_MESSAGE}}'),
            requestData: () => console.log('{{MEDIA_RECORDER_REQUESTDATA_MESSAGE}}'),

            addEventListener: (type, listener) => {
                switch (type) {
                    case "dataavailable": // parameter -> event: BlobEvent
                        const event = { data: { arrayBuffer: () => Promise.resolve([1, 2, 3, 4]) } };
                        window.setTimeout(() => listener(event), 300);
                        break;
                    case "error": // parameter -> event: Event
                        window.setTimeout(() => listener("{{MEDIA_RECORDER_EVENT_ERROR_MESSAGE}}"), 300);
                        break;
                    default: // no parameters
                        window.setTimeout(listener, 300);
                        break;
                }
            },
            removeEventListener: (type, listener) => { }
        }
        """;

    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        await BrowserContext.GrantPermissionsAsync(["camera", "microphone"]);

        await Page.EvaluateAsync($$"""
            navigator.mediaDevices.getUserMedia = (options) => Promise.resolve({{JS_MEDIASTREAM_OBJECT}});
            navigator.mediaDevices.getDisplayMedia = (options) => Promise.resolve({{JS_MEDIASTREAM_OBJECT}});
            MediaRecorder.isTypeSupported = (mimeType) => true;

            const OriginalMediaRecorder = MediaRecorder;
            window.MediaRecorder = function (mediaStream, options) { return {{JS_MEDIARECORDER_OBJECT}}; };
            MediaRecorder.prototype = OriginalMediaRecorder.prototype;
            Object.setPrototypeOf(MediaRecorder, OriginalMediaRecorder);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
    }


    // Media Devices

    [Test]
    public async Task EnumerateDevices() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_ENUMERATE_DEVICES);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MediaDeviceInfo");
    }

    [Test]
    public async Task GetSupportedConstraints_Property() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_SUPPORTED_CONSTRAINTS_PROPERTY);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MediaTrackSupportedConstraint");
    }

    [Test]
    public async Task GetSupportedConstraints_Method() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_SUPPORTED_CONSTRAINTS_METHOD);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MediaTrackSupportedConstraint");
    }


    [Test]
    public async Task GetUserMedia() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_USER_MEDIA);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetUserMediaWithConstraint() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_USER_MEDIA_WITH_CONSTRAINT);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetDisplayMedia() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_DISPLAY_MEDIA);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetDisplayMediaWithConstraint() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_DISPLAY_MEDIA_WITH_CONSTRAINT);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // Media Stream

    [Test]
    public async Task GetActive_Property() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_ACTIVE_PROPERTY);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetActive_Method() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_ACTIVE_METHOD);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetId_Property() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_ID_PROPERTY);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MEDIA_STREAM_ID);
    }

    [Test]
    public async Task GetId_Method() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_ID_METHOD);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MEDIA_STREAM_ID);
    }


    // Media Recorder Properties

    [Test]
    public async Task GetMimeType_Property() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_MIME_TYPE_PROPERTY);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MEDIA_RECORDER_MIMETYPE);
    }

    [Test]
    public async Task GetMimeType_Method() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_MIME_TYPE_METHOD);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MEDIA_RECORDER_MIMETYPE);
    }


    [Test]
    public async Task GetState_Property() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_STATE_PROPERTY);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MEDIA_RECORDER_STATE);
    }

    [Test]
    public async Task GetState_Method() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_STATE_METHOD);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MEDIA_RECORDER_STATE);
    }


    [Test]
    public async Task GetStream_Property() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_STREAM_PROPERTY);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetStream_Method() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_STREAM_METHOD);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetAudioBitsPerSecond_Property() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_AUDIO_BITS_PER_SECOND_PROPERTY);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MEDIA_RECORDER_AUDIO_BITS_PER_SECOND);
    }

    [Test]
    public async Task GetAudioBitsPerSecond_Method() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_AUDIO_BITS_PER_SECOND_METHOD);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MEDIA_RECORDER_AUDIO_BITS_PER_SECOND);
    }


    [Test]
    public async Task GetVideoBitsPerSecond_Property() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_VIDEO_BITS_PER_SECOND_PROPERTY);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MEDIA_RECORDER_VIDEO_BITS_PER_SECOND);
    }

    [Test]
    public async Task GetVideoBitsPerSecond_Method() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_GET_VIDEO_BITS_PER_SECOND_METHOD);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MEDIA_RECORDER_VIDEO_BITS_PER_SECOND);
    }


    // Media Recorder Methods

    private sealed class ConsoleMessageCapture : IDisposable {
        public List<string> Text { get; private set; } = [];

        private readonly IPage page;

        public ConsoleMessageCapture(IPage page) {
            this.page = page;
            page.Console += OnConsoleMessage;
        }

        public void Dispose() => page.Console -= OnConsoleMessage;


        private void OnConsoleMessage(object? sender, IConsoleMessage message) {
            if (message.Text.StartsWith("Debugging hotkey"))
                return;

            Text.Add(message.Text);
        }
    }


    [Test]
    public async Task Start() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(MediaDevicesGroup.BUTTON_START);

        await Assert.That(consoleMessageCapture.Text).Contains(MEDIA_RECORDER_START_MESSAGE);
    }

    [Test]
    public async Task Stop() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(MediaDevicesGroup.BUTTON_STOP);

        await Assert.That(consoleMessageCapture.Text).Contains(MEDIA_RECORDER_STOP_MESSAGE);
    }

    [Test]
    public async Task Resume() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(MediaDevicesGroup.BUTTON_RESUME);

        await Assert.That(consoleMessageCapture.Text).Contains(MEDIA_RECORDER_RESUME_MESSAGE);
    }

    [Test]
    public async Task Pause() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(MediaDevicesGroup.BUTTON_PAUSE);

        await Assert.That(consoleMessageCapture.Text).Contains(MEDIA_RECORDER_PAUSE_MESSAGE);
    }

    [Test]
    public async Task RequestData() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(MediaDevicesGroup.BUTTON_REQUEST_DATA);

        await Assert.That(consoleMessageCapture.Text).Contains(MEDIA_RECORDER_REQUESTDATA_MESSAGE);
    }

    [Test]
    public async Task IsTypeSupported() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_IS_TYPE_SUPPORTED);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // Media Recorder Events

    [Test]
    public async Task RegisterOnDataAvailable() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_REGISTER_ON_DATA_AVAILABLE);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("4");
    }

    [Test]
    public async Task RegisterOnError() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_REGISTER_ON_ERROR);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MEDIA_RECORDER_EVENT_ERROR_MESSAGE);
    }

    [Test]
    public async Task RegisterOnStart() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_REGISTER_ON_START);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MediaDevicesGroup.TEST_EVENT_ON_START);
    }

    [Test]
    public async Task RegisterOnStop() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_REGISTER_ON_STOP);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MediaDevicesGroup.TEST_EVENT_ON_STOP);
    }

    [Test]
    public async Task RegisterOnResume() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_REGISTER_ON_RESUME);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MediaDevicesGroup.TEST_EVENT_ON_RESUME);
    }

    [Test]
    public async Task RegisterOnPause() {
        await ExecuteTest(MediaDevicesGroup.BUTTON_REGISTER_ON_PAUSE);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(MediaDevicesGroup.TEST_EVENT_ON_PAUSE);
    }
}
