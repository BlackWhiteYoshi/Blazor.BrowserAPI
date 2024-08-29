using Microsoft.AspNetCore.Components;
using System.Text;

namespace BrowserAPI.Test.Client;

public sealed partial class MediaDevicesGroup : ComponentBase {
    public const string TEST_MIME_TYPE = "video/mp4";


    [Inject]
    public required IMediaDevices MediaDevices { private get; init; }

    [Inject]
    public required IMediaDevicesInProcess MediaDevicesInProcess { private get; init; }


    public const string LABEL_OUTPUT = "media-devices-output";
    private string labelOutput = string.Empty;


    #region Async

    // Media Devices

    public const string BUTTON_ENUMERATE_DEVICES = "media-devices-enumerate-devices";
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


    public const string BUTTON_GET_SUPPORTED_CONSTRAINTS_PROPERTY = "media-devices-get-supported-constraints-property";
    private async Task GetSupportedConstraints_Property() {
        MediaTrackSupportedConstraints supportedConstraints = await MediaDevices.SupportedConstraints;
        labelOutput = supportedConstraints.ToString();
    }

    public const string BUTTON_GET_SUPPORTED_CONSTRAINTS_METHOD = "media-devices-get-supported-constraints-method";
    private async Task GetSupportedConstraints_Method() {
        MediaTrackSupportedConstraints supportedConstraints = await MediaDevices.GetSupportedConstraints(default);
        labelOutput = supportedConstraints.ToString();
    }


    public const string BUTTON_GET_USER_MEDIA = "media-devices-get-user-media";
    private async Task GetUserMedia() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
    }

    public const string BUTTON_GET_USER_MEDIA_WITH_CONSTRAINT = "media-devices-get-user-media-with-constraint";
    private async Task GetUserMediaWithConstraint() {
        MediaTrackConstraints videoConstraint = new() {
            AutoGainControl = ConstrainBoolean.Ideal(true),
            AspectRatio = ConstrainDouble.Exact(2.0),
            Height = ConstrainULong.Ideal(200, 100, 400),
            DisplaySurface = (string[])["browser", "monitor"],
            FacingMode = ConstrainDOMString.Exact("user")
        };
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: videoConstraint);
    }


    public const string BUTTON_GET_DISPLAY_MEDIA = "media-devices-get-display-media";
    private async Task GetDisplayMedia() {
        await using IMediaStream mediaStream = await MediaDevices.GetDisplayMedia(audio: true, video: true);
    }

    public const string BUTTON_GET_DISPLAY_MEDIA_WITH_CONSTRAINT = "media-devices-get-display-media-with-constraint";
    private async Task GetDisplayMediaWithConstraint() {
        MediaTrackConstraints videoConstraint = new() {
            AutoGainControl = ConstrainBoolean.Ideal(true),
            AspectRatio = 2.0,
            Height = ConstrainULong.Ideal(200)
        };
        await using IMediaStream mediaStream = await MediaDevices.GetDisplayMedia(audio: true, video: videoConstraint);
    }


    // Media Stream

    public const string BUTTON_GET_ACTIVE_PROPERTY = "media-stream-get-active-property";
    private async Task GetActive_Property() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        
        bool active = await mediaStream.Active;
        labelOutput = active.ToString();
    }

    public const string BUTTON_GET_ACTIVE_METHOD = "media-stream-get-active-method";
    private async Task GetActive_Method() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        
        bool active = await mediaStream.GetActive(default);
        labelOutput = active.ToString();
    }


    public const string BUTTON_GET_ID_PROPERTY = "media-stream-get-id-property";
    private async Task GetId_Property() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        
        string id = await mediaStream.Id;
        labelOutput = id;
    }

    public const string BUTTON_GET_ID_METHOD = "media-stream-get-id-method";
    private async Task GetId_Method() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        
        string id = await mediaStream.GetId(default);
        labelOutput = id;
    }


    // Media Recorder Properties

    public const string BUTTON_GET_MIME_TYPE_PROPERTY = "media-recorder-get-mime-type-property";
    private async Task GetMimeType_Property() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        string mimeType = await mediaRecorder.MimeType;
        labelOutput = mimeType;
    }

    public const string BUTTON_GET_MIME_TYPE_METHOD = "media-recorder-get-mime-type-method";
    private async Task GetMimeType_Method() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        string mimeType = await mediaRecorder.GetMimeType(default);
        labelOutput = mimeType;
    }


    public const string BUTTON_GET_STATE_PROPERTY = "media-recorder-get-state-property";
    private async Task GetState_Property() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        string state = await mediaRecorder.State;
        labelOutput = state;
    }

    public const string BUTTON_GET_STATE_METHOD = "media-recorder-get-state-method";
    private async Task GetState_Method() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        string state = await mediaRecorder.GetState(default);
        labelOutput = state;
    }


    public const string BUTTON_GET_STREAM_PROPERTY = "media-recorder-get-stream-property";
    private async Task GetStream_Property() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        await using IMediaStream streamReference2 = await mediaRecorder.Stream;
        labelOutput = (await mediaStream.Id == await streamReference2.Id).ToString();
    }

    public const string BUTTON_GET_STREAM_METHOD = "media-recorder-get-stream-method";
    private async Task GetStream_Method() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        await using IMediaStream streamReference2 = await mediaRecorder.GetStream(default);
        labelOutput = (await mediaStream.Id == await streamReference2.Id).ToString();
    }


    public const string BUTTON_GET_AUDIO_BITS_PER_SECOND_PROPERTY = "media-recorder-get-audio-bits-per-second-property";
    private async Task GetAudioBitsPerSecond_Property() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        ulong audioBitsPerSecond = await mediaRecorder.AudioBitsPerSecond;
        labelOutput = audioBitsPerSecond.ToString();
    }

    public const string BUTTON_GET_AUDIO_BITS_PER_SECOND_METHOD = "media-recorder-get-audio-bits-per-second-method";
    private async Task GetAudioBitsPerSecond_Method() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        ulong audioBitsPerSecond = await mediaRecorder.GetAudioBitsPerSecond(default);
        labelOutput = audioBitsPerSecond.ToString();
    }


    public const string BUTTON_GET_VIDEO_BITS_PER_SECOND_PROPERTY = "media-recorder-get-video-bits-per-second-property";
    private async Task GetVideoBitsPerSecond_Property() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        ulong videoBitsPerSecond = await mediaRecorder.VideoBitsPerSecond;
        labelOutput = videoBitsPerSecond.ToString();
    }

    public const string BUTTON_GET_VIDEO_BITS_PER_SECOND_METHOD = "media-recorder-get-video-bits-per-second-method";
    private async Task GetVideoBitsPerSecond_Method() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        ulong videoBitsPerSecond = await mediaRecorder.GetVideoBitsPerSecond(default);
        labelOutput = videoBitsPerSecond.ToString();
    }


    // Media Recorder Methods

    public const string BUTTON_START = "media-recorder-start";
    private async Task Start() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        await mediaRecorder.Start();
        labelOutput = (await mediaRecorder.State).ToString();
    }

    public const string BUTTON_STOP = "media-recorder-stop";
    private async Task Stop() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        await mediaRecorder.Start();
        await mediaRecorder.Stop();
        labelOutput = (await mediaRecorder.State).ToString();
    }

    public const string BUTTON_RESUME = "media-recorder-resume";
    private async Task Resume() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        await mediaRecorder.Start();
        await mediaRecorder.Pause();
        await mediaRecorder.Resume();
        labelOutput = (await mediaRecorder.State).ToString();
    }

    public const string BUTTON_PAUSE = "media-recorder-pause";
    private async Task Pause() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        await mediaRecorder.Start();
        await mediaRecorder.Pause();
        labelOutput = (await mediaRecorder.State).ToString();
    }

    public const string BUTTON_REQUEST_DATA = "media-recorder-request-data";
    private async Task RequestData() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        TaskCompletionSource taskCompletionSource = new();
        mediaRecorder.OnDataavailable += OnDataavailable;
        await mediaRecorder.Start();
        await mediaRecorder.RequestData();
        await taskCompletionSource.Task;


        void OnDataavailable(byte[] data) {
            labelOutput = data.Length.ToString();
            mediaRecorder.OnDataavailable -= OnDataavailable;
            taskCompletionSource.SetResult();
        };
    }

    public const string BUTTON_IS_TYPE_SUPPORTED = "media-recorder-is-type-supported";
    private async Task IsTypeSupported() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        bool isTypeSupported = await mediaRecorder.IsTypeSupported(TEST_MIME_TYPE);
        labelOutput = isTypeSupported.ToString();
    }


    // Media Recorder Events

    public const string BUTTON_REGISTER_ON_DATAAVAILABLE = "media-recorder-dataavailable-event";
    private async Task RegisterOnDataavailable() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        mediaRecorder.OnDataavailable += (byte[] data) => labelOutput = data.Length.ToString();
        await mediaRecorder.Start();
        await mediaRecorder.Stop();
    }

    public const string BUTTON_REGISTER_ON_ERROR = "media-recorder-error-event";
    private async Task RegisterOnError() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        mediaRecorder.OnError += (string error) => labelOutput = error;
    }

    public const string BUTTON_REGISTER_ON_START = "media-recorder-start-event";
    private async Task RegisterOnStart() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        mediaRecorder.OnStart += () => labelOutput = "started";
        await mediaRecorder.Start();
        await mediaRecorder.Stop();
    }

    public const string BUTTON_REGISTER_ON_STOP = "media-recorder-stop-event";
    private async Task RegisterOnStop() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        mediaRecorder.OnStop += () => labelOutput = "stopped";
        await mediaRecorder.Start();
        await mediaRecorder.Stop();
    }

    public const string BUTTON_REGISTER_ON_RESUME = "media-recorder-resume-event";
    private async Task RegisterOnResume() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        mediaRecorder.OnResume += () => labelOutput = "resumed";
        await mediaRecorder.Start();
        await mediaRecorder.Pause();
        await mediaRecorder.Resume();
        await mediaRecorder.Stop();
    }

    public const string BUTTON_REGISTER_ON_PAUSE = "media-recorder-pause-event";
    private async Task RegisterOnPause() {
        await using IMediaStream mediaStream = await MediaDevices.GetUserMedia(audio: true, video: true);
        await using IMediaRecorder mediaRecorder = await mediaStream.CreateRecorder();

        mediaRecorder.OnPause += () => labelOutput = "paused";
        await mediaRecorder.Start();
        await mediaRecorder.Pause();
        await mediaRecorder.Stop();
    }

    #endregion


    #region InProcess

    // Media Devices InProcess

    public const string BUTTON_ENUMERATE_DEVICES_INPROCESS = "media-devices-enumerate-devices-inprocess";
    private async Task EnumerateDevices_InProcess() {
        MediaDeviceInfo[] deviceInfoList = await MediaDevicesInProcess.EnumerateDevices();

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

    public const string BUTTON_GET_SUPPORTED_CONSTRAINTS_INPROCESS = "media-devices-get-supported-constraints-inprocess";
    private void GetSupportedConstraints_InProcess() {
        MediaTrackSupportedConstraints supportedConstraints = MediaDevicesInProcess.SupportedConstraints;
        labelOutput = supportedConstraints.ToString();
    }


    public const string BUTTON_GET_USER_MEDIA_INPROCESS = "media-devices-get-user-media-inprocess";
    private async Task GetUserMedia_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
    }

    public const string BUTTON_GET_USER_MEDIA_WITH_CONSTRAINT_INPROCESS = "media-devices-get-user-media-with-constraint-inprocess";
    private async Task GetUserMediaWithConstraint_InProcess() {
        MediaTrackConstraints videoConstraint = new() {
            AutoGainControl = ConstrainBoolean.Ideal(true),
            AspectRatio = ConstrainDouble.Exact(2.0),
            Height = ConstrainULong.Ideal(200, 100, 400),
            DisplaySurface = (string[])["browser", "monitor"],
            FacingMode = ConstrainDOMString.Exact("user")
        };
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: videoConstraint);
    }


    public const string BUTTON_GET_DISPLAY_MEDIA_INPROCESS = "media-devices-get-display-media-inprocess";
    private async Task GetDisplayMedia_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetDisplayMedia(audio: true, video: true);
    }

    public const string BUTTON_GET_DISPLAY_MEDIA_WITH_CONSTRAINT_INPROCESS = "media-devices-get-display-media-with-constraint-inprocess";
    private async Task GetDisplayMediaWithConstraint_InProcess() {
        MediaTrackConstraints videoConstraint = new() {
            AutoGainControl = ConstrainBoolean.Ideal(true),
            AspectRatio = 2.0,
            Height = ConstrainULong.Ideal(200)
        };
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetDisplayMedia(audio: true, video: videoConstraint);
    }


    // Media Stream InProcess

    public const string BUTTON_GET_ACTIVE_INPROCESS = "media-stream-get-active-inprocess";
    private async Task GetActive_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);

        bool active = mediaStream.Active;
        labelOutput = active.ToString();
    }

    public const string BUTTON_GET_ID_INPROCESS = "media-stream-get-id-inprocess";
    private async Task GetId_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);

        string id = mediaStream.Id;
        labelOutput = id;
    }


    // Media Recorder Properties InProcess

    public const string BUTTON_GET_MIME_TYPE_INPROCESS = "media-recorder-get-mime-type-inprocess";
    private async Task GetMimeType_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        string mimeType = mediaRecorder.MimeType;
        labelOutput = mimeType;
    }

    public const string BUTTON_GET_STATE_INPROCESS = "media-recorder-get-state-inprocess";
    private async Task GetState_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        string state = mediaRecorder.State;
        labelOutput = state;
    }

    public const string BUTTON_GET_STREAM_INPROCESS = "media-recorder-get-stream-inprocess";
    private async Task GetStream_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        using IMediaStreamInProcess streamReference2 = mediaRecorder.Stream;
        labelOutput = (mediaStream.Id == streamReference2.Id).ToString();
    }

    public const string BUTTON_GET_AUDIO_BITS_PER_SECOND_INPROCESS = "media-recorder-get-audio-bits-per-second-inprocess";
    private async Task GetAudioBitsPerSecond_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        ulong audioBitsPerSecond = mediaRecorder.AudioBitsPerSecond;
        labelOutput = audioBitsPerSecond.ToString();
    }

    public const string BUTTON_GET_VIDEO_BITS_PER_SECOND_INPROCESS = "media-recorder-get-video-bits-per-second-inprocess";
    private async Task GetVideoBitsPerSecond_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        ulong videoBitsPerSecond = mediaRecorder.VideoBitsPerSecond;
        labelOutput = videoBitsPerSecond.ToString();
    }


    // Media Recorder Methods InProcess

    public const string BUTTON_START_INPROCESS = "media-recorder-start-inprocess";
    private async Task Start_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.Start();
        labelOutput = mediaRecorder.State.ToString();
    }

    public const string BUTTON_STOP_INPROCESS = "media-recorder-stop-inprocess";
    private async Task Stop_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.Start();
        mediaRecorder.Stop();
        labelOutput = mediaRecorder.State.ToString();
    }

    public const string BUTTON_RESUME_INPROCESS = "media-recorder-resume-inprocess";
    private async Task Resume_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.Start();
        mediaRecorder.Pause();
        mediaRecorder.Resume();
        labelOutput = mediaRecorder.State.ToString();
    }

    public const string BUTTON_PAUSE_INPROCESS = "media-recorder-pause-inprocess";
    private async Task Pause_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.Start();
        mediaRecorder.Pause();
        labelOutput = mediaRecorder.State.ToString();
    }

    public const string BUTTON_REQUEST_DATA_INPROCESS = "media-recorder-request-data-inprocess";
    private async Task RequestData_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.OnDataavailable += OnDataavailable;
        mediaRecorder.Start();
        await Task.Delay(100);
        mediaRecorder.RequestData();
        await Task.Delay(100);


        void OnDataavailable(byte[] data) {
            labelOutput = data.Length.ToString();
            mediaRecorder.OnDataavailable -= OnDataavailable;
        };
    }

    public const string BUTTON_IS_TYPE_SUPPORTED_INPROCESS = "media-recorder-is-type-supported-inprocess";
    private async Task IsTypeSupported_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        bool isTypeSupported = mediaRecorder.IsTypeSupported(TEST_MIME_TYPE);
        labelOutput = isTypeSupported.ToString();
    }


    // Media Recorder Events InProcess

    public const string BUTTON_REGISTER_ON_DATAAVAILABLE_INPROCESS = "media-recorder-dataavailable-event-inprocess";
    private async Task RegisterOnDataavailable_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        TaskCompletionSource taskCompletionSource = new();
        mediaRecorder.OnDataavailable += (byte[] data) => {
            labelOutput = data.Length.ToString();
            taskCompletionSource.SetResult();
        };
        mediaRecorder.Start();
        mediaRecorder.Stop();
        await taskCompletionSource.Task;
    }

    public const string BUTTON_REGISTER_ON_ERROR_INPROCESS = "media-recorder-error-event-inprocess";
    private async Task RegisterOnError_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        mediaRecorder.OnError += (string error) => labelOutput = error;
    }

    public const string BUTTON_REGISTER_ON_START_INPROCESS = "media-recorder-start-event-inprocess";
    private async Task RegisterOnStart_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        TaskCompletionSource taskCompletionSource = new();
        mediaRecorder.OnStart += () => {
            labelOutput = "started";
            taskCompletionSource.SetResult();
        };
        mediaRecorder.Start();
        mediaRecorder.Stop();
        await taskCompletionSource.Task;
    }

    public const string BUTTON_REGISTER_ON_STOP_INPROCESS = "media-recorder-stop-event-inprocess";
    private async Task RegisterOnStop_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        TaskCompletionSource taskCompletionSource = new();
        mediaRecorder.OnStop += () => {
            labelOutput = "stopped";
            taskCompletionSource.SetResult();
        };
        mediaRecorder.Start();
        mediaRecorder.Stop();
        await taskCompletionSource.Task;
    }

    public const string BUTTON_REGISTER_ON_RESUME_INPROCESS = "media-recorder-resume-event-inprocess";
    private async Task RegisterOnResume_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        TaskCompletionSource taskCompletionSource = new();
        mediaRecorder.OnResume += () => {
            labelOutput = "resumed";
            taskCompletionSource.SetResult();
        };
        mediaRecorder.Start();
        mediaRecorder.Pause();
        mediaRecorder.Resume();
        mediaRecorder.Stop();
        await taskCompletionSource.Task;
    }

    public const string BUTTON_REGISTER_ON_PAUSE_INPROCESS = "media-recorder-pause-event-inprocess";
    private async Task RegisterOnPause_InProcess() {
        using IMediaStreamInProcess mediaStream = await MediaDevicesInProcess.GetUserMedia(audio: true, video: true);
        using IMediaRecorderInProcess mediaRecorder = mediaStream.CreateRecorder(mimeType: TEST_MIME_TYPE);

        TaskCompletionSource taskCompletionSource = new();
        mediaRecorder.OnPause += () => {
            labelOutput = "paused";
            taskCompletionSource.SetResult();
        };
        mediaRecorder.Start();
        mediaRecorder.Pause();
        mediaRecorder.Stop();
        await taskCompletionSource.Task;
    }

    #endregion
}
