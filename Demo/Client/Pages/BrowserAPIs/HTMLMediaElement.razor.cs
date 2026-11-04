using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Demo.Client;

public sealed partial class HTMLMediaElement : ComponentBase, IAsyncDisposable {
    [Inject]
    public required IElementFactory ElementFactory { private get; init; }

    private ElementReference audioElement;
    private IHTMLMediaElement? _audio;
    private IHTMLMediaElement Audio => _audio ??= ElementFactory.CreateHTMLMediaElement(audioElement);

    private ElementReference videoElement;
    private IHTMLMediaElement? _video;
    private IHTMLMediaElement Video => _video ??= ElementFactory.CreateHTMLMediaElement(videoElement);

    public async ValueTask DisposeAsync() {
        try {
            if (_audio is not null)
                await _audio.DisposeAsync();
            if (_video is not null)
                await _video.DisposeAsync();
        }
        catch (JSDisconnectedException) { }
    }


    private bool isDoubleSpeedAudio = false;
    private bool isMutedAudio = false;
    private bool isHalfVolumeAudio = false;

    private async Task PlayAudio() => await Audio.Play();

    private async Task PauseAudio() => await Audio.Pause();

    private async Task ResetAudio() => await Audio.SetCurrentTime(0.0);

    private async Task ToggleSpeedAudio() {
        await Audio.SetPlaybackRate(!isDoubleSpeedAudio ? 2.0 : 1.0);
        isDoubleSpeedAudio = !isDoubleSpeedAudio;
    }

    private async Task ToggleMutedAudio() {
        await Audio.SetMuted(!isMutedAudio);
        isMutedAudio = !isMutedAudio;
    }

    private async Task ToggleVolumeAudio() {
        await Audio.SetVolume(!isHalfVolumeAudio ? 0.5 : 1.0);
        isHalfVolumeAudio = !isHalfVolumeAudio;
    }


    private bool isDoubleSpeedVideo = false;
    private bool isMutedVideo = false;
    private bool isHalfVolumeVideo = false;

    private async Task PlayVideo() => await Video.Play();

    private async Task PauseVideo() => await Video.Pause();

    private async Task ResetVideo() => await Video.SetCurrentTime(0.0);

    private async Task ToggleSpeedVideo() {
        await Video.SetPlaybackRate(!isDoubleSpeedVideo ? 2.0 : 1.0);
        isDoubleSpeedVideo = !isDoubleSpeedVideo;
    }

    private async Task ToggleMutedVideo() {
        await Video.SetMuted(!isMutedVideo);
        isMutedVideo = !isMutedVideo;
    }

    private async Task ToggleVolumeVideo() {
        await Video.SetVolume(!isHalfVolumeVideo ? 0.5 : 1.0);
        isHalfVolumeVideo = !isHalfVolumeVideo;
    }

    private async Task OpenPictureInPicture() {
        await using IPictureInPictureWindow pictureInPictureWindow = await Video.RequestPictureInPicture();
    }
}
