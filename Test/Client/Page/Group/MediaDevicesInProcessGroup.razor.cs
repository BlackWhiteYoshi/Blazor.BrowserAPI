using Microsoft.AspNetCore.Components;
using System.Text;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class MediaDevicesInProcessGroup : ComponentBase {
    public const string TEST_MIME_TYPE = "video/mp4";


    [Inject]
    public required IMediaDevicesInProcess MediaDevices { private get; init; }


    public const string LABEL_OUTPUT = "media-devices-inprocess-output";
    private string labelOutput = string.Empty;


    // Media Devices

    public const string BUTTON_ENUMERATE_DEVICES = "media-devices-inprocess-enumerate-devices";
    private async Task EnumerateDevices() {
        MediaDeviceInfo[] deviceInfoList = await MediaDevices.EnumerateDevices();

        if (deviceInfoList.Length > 0) {
            StringBuilder builder = new();
            foreach (MediaDeviceInfo deviceInfo in deviceInfoList) {
                builder.Append(deviceInfo.ToString());
                builder.Append(" --- ");
            }
            labelOutput = builder.ToString();
        }
        else
            labelOutput = "[]";
    }

    public const string BUTTON_GET_SUPPORTED_CONSTRAINTS = "media-devices-inprocess-get-supported-constraints";
    private void GetSupportedConstraints() {
        MediaTrackSupportedConstraints supportedConstraints = MediaDevices.SupportedConstraints;
        labelOutput = supportedConstraints.ToString();
    }


    public const string BUTTON_GET_USER_MEDIA = "media-devices-inprocess-get-user-media";
    private async Task GetUserMedia() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
    }

    public const string BUTTON_GET_USER_MEDIA_WITH_CONSTRAINT = "media-devices-inprocess-get-user-media-with-constraint";
    private async Task GetUserMediaWithConstraint() {
        MediaTrackConstraints videoConstraint = new() {
            AutoGainControl = ConstrainBoolean.Ideal(true),
            AspectRatio = ConstrainDouble.Exact(2.0),
            Height = ConstrainULong.Ideal(200, 100, 400),
            DisplaySurface = (string[])["browser", "monitor"],
            FacingMode = ConstrainDOMString.Exact("user")
        };
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: videoConstraint);
    }


    public const string BUTTON_GET_DISPLAY_MEDIA = "media-devices-inprocess-get-display-media";
    private async Task GetDisplayMedia() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetDisplayMedia(audio: true, video: true);
    }

    public const string BUTTON_GET_DISPLAY_MEDIA_WITH_CONSTRAINT = "media-devices-inprocess-get-display-media-with-constraint";
    private async Task GetDisplayMediaWithConstraint() {
        MediaTrackConstraints videoConstraint = new() {
            AutoGainControl = ConstrainBoolean.Ideal(true),
            AspectRatio = 2.0,
            Height = ConstrainULong.Ideal(200)
        };
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetDisplayMedia(audio: true, video: videoConstraint);
    }


    // Media Stream

    public const string BUTTON_GET_ACTIVE = "media-stream-get-active";
    private async Task GetActive() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);

        bool active = mediaStream.Active;
        labelOutput = active.ToString();
    }

    public const string BUTTON_GET_ID = "media-stream-get-id";
    private async Task GetId() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);

        string id = mediaStream.Id;
        labelOutput = id;
    }


    // Media Recorder Properties

    public const string BUTTON_GET_MIME_TYPE = "media-recorder-get-mime-type";
    private async Task GetMimeType() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        string mimeType = mediaRecorder.MimeType;
        labelOutput = mimeType;
    }

    public const string BUTTON_GET_STATE = "media-recorder-get-state";
    private async Task GetState() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        string state = mediaRecorder.State;
        labelOutput = state;
    }

    public const string BUTTON_GET_STREAM = "media-recorder-get-stream";
    private async Task GetStream() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        using IMediaStreamInProcess streamReference2 = mediaRecorder.Stream;
        labelOutput = (mediaStream.Id == streamReference2.Id).ToString();
    }

    public const string BUTTON_GET_AUDIO_BITS_PER_SECOND = "media-recorder-get-audio-bits-per-second";
    private async Task GetAudioBitsPerSecond() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        ulong audioBitsPerSecond = mediaRecorder.AudioBitsPerSecond;
        labelOutput = audioBitsPerSecond.ToString();
    }

    public const string BUTTON_GET_VIDEO_BITS_PER_SECOND = "media-recorder-get-video-bits-per-second";
    private async Task GetVideoBitsPerSecond() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        ulong videoBitsPerSecond = mediaRecorder.VideoBitsPerSecond;
        labelOutput = videoBitsPerSecond.ToString();
    }


    // Media Recorder Methods

    public const string BUTTON_START = "media-recorder-start";
    private async Task Start() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.Start();
        labelOutput = mediaRecorder.State.ToString();
    }

    public const string BUTTON_STOP = "media-recorder-stop";
    private async Task Stop() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.Start();
        mediaRecorder.Stop();
        labelOutput = mediaRecorder.State.ToString();
    }

    public const string BUTTON_RESUME = "media-recorder-resume";
    private async Task Resume() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.Start();
        mediaRecorder.Pause();
        mediaRecorder.Resume();
        labelOutput = mediaRecorder.State.ToString();
    }

    public const string BUTTON_PAUSE = "media-recorder-pause";
    private async Task Pause() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.Start();
        mediaRecorder.Pause();
        labelOutput = mediaRecorder.State.ToString();
    }

    public const string BUTTON_REQUEST_DATA = "media-recorder-request-data";
    private async Task RequestData() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.OnDataavailable += OnDataavailable;
        mediaRecorder.Start();
        await Task.Delay(100);
        mediaRecorder.RequestData();
        

        void OnDataavailable(byte[] data) {
            labelOutput = data.Length.ToString();
            StateHasChanged();
            mediaRecorder.OnDataavailable -= OnDataavailable;
            mediaRecorder.Dispose();
        }
    }

    public const string BUTTON_IS_TYPE_SUPPORTED = "media-recorder-is-type-supported";
    private async Task IsTypeSupported() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        bool isTypeSupported = mediaRecorder.IsTypeSupported(TEST_MIME_TYPE);
        labelOutput = isTypeSupported.ToString();
    }


    // Media Recorder Events

    public const string BUTTON_REGISTER_ON_DATAAVAILABLE = "media-recorder-dataavailable-event";
    private async Task RegisterOnDataavailable() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.OnDataavailable += OnDataavailable;
        mediaRecorder.Start();
        await Task.Delay(100);
        mediaRecorder.Stop();


        void OnDataavailable(byte[] data) {
            labelOutput = data.Length.ToString();
            StateHasChanged();
            mediaRecorder.OnDataavailable -= OnDataavailable;
            mediaRecorder.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_ERROR = "media-recorder-error-event";
    private async Task RegisterOnError() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.OnError += OnError;

        void OnError(JsonElement error) {
            labelOutput = error.ToString();
            StateHasChanged();
            mediaRecorder.OnError -= OnError;
            mediaRecorder.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_START = "media-recorder-start-event";
    private async Task RegisterOnStart() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.OnStart += OnStart;
        mediaRecorder.Start();
        mediaRecorder.Stop();


        void OnStart() {
            labelOutput = "started";
            StateHasChanged();
            mediaRecorder.OnStart -= OnStart;
            mediaRecorder.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_STOP = "media-recorder-stop-event";
    private async Task RegisterOnStop() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.OnStop += OnStop;
        mediaRecorder.Start();
        mediaRecorder.Stop();


        void OnStop() {
            labelOutput = "stopped";
            StateHasChanged();
            mediaRecorder.OnStop -= OnStop;
            mediaRecorder.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_RESUME = "media-recorder-resume-event";
    private async Task RegisterOnResume() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.OnResume += OnResume;
        mediaRecorder.Start();
        mediaRecorder.Pause();
        mediaRecorder.Resume();
        mediaRecorder.Stop();


        void OnResume() {
            labelOutput = "resumed";
            StateHasChanged();
            mediaRecorder.OnResume -= OnResume;
            mediaRecorder.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_PAUSE = "media-recorder-pause-event";
    private async Task RegisterOnPause() {
        using IMediaStreamInProcess mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.OnPause += OnPause;
        mediaRecorder.Start();
        mediaRecorder.Pause();
        mediaRecorder.Stop();


        void OnPause() {
            labelOutput = "paused";
            StateHasChanged();
            mediaRecorder.OnPause -= OnPause;
            mediaRecorder.Dispose();
        }
    }
}
