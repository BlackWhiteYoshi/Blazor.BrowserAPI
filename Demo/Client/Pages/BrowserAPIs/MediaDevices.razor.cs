using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Demo.Client;

public sealed partial class MediaDevices : ComponentBase {
    [Inject]
    public required IMediaDevices PMediaDevices { private get; init; }

    public async ValueTask DisposeAsync() {
        try {
            if (mediaRecorder is not null) {
                mediaRecorder.OnDataAvailable -= SaveChunk;
                await mediaRecorder.DisposeAsync();
            }
            if (mediaStream is not null)
                await mediaStream.DisposeAsync();

            if (_audio is not null)
                await _audio.DisposeAsync();
            if (_video is not null)
                await _video.DisposeAsync();
        }
        catch (JSDisconnectedException) { }
    }


    private IHTMLMediaElement? playbackElement = null;
    private IMediaStream? mediaStream = null;
    private IMediaRecorder? mediaRecorder = null;

    private bool isRecording = false;
    private string mimeType = string.Empty;
    private bool mimeTypeError = false;
    private bool hasVideoData;

    private readonly List<byte> mediaData = [];
    private void SaveChunk(byte[] data) => mediaData.AddRange(data);

    private static void OutputToConsole(JsonElement error) => System.Console.WriteLine(error);


    private Task StartRecordingAudio() => StartRecording(isAudio: true, isVideo: false);

    private Task StartRecordingVideo() => StartRecording(isAudio: false, isVideo: true);

    private Task StartRecordingVideoAudio() => StartRecording(isAudio: true, isVideo: true);

    private async Task StartRecording(bool isAudio, bool isVideo) {
        isRecording = true;
        string[] encodingList;
        if (isVideo) {
            encodingList = ["video/mp4;codecs=avc1.42E01E,mp4a.40.2", "video/mp4;codecs=avc1,mp4a.40.2", "video/mp4", "video/webm;codecs=vp9,opus", "video/webm;codecs=vp8,opus", "video/webm;codecs=h264,opus", "video/webm", "video/ogg;codecs=theora,opus"];
            hasVideoData = true;
            playbackElement = Video;
        }
        else {
            encodingList = ["audio/mpeg", "audio/mp4;codecs=mp4a.40.2", "audio/mp4", "audio/aac", "audio/webm;codecs=opus", "audio/webm", "audio/ogg;codecs=opus", "audio/wav"];
            hasVideoData = false;
            playbackElement = Audio;
        }

        foreach (string encoding in encodingList)
            if (await PMediaDevices.IsTypeSupported(encoding)) {
                mimeType = encoding;
                mimeTypeError = false;
                goto _validMimeTypeFound;
            }
        /* foreach-else */ {
            mimeType = "no encoding supported";
            mimeTypeError = true;
            isRecording = false;
            return;
        }
        _validMimeTypeFound:

        mediaStream = await PMediaDevices.GetUserMedia(audio: isAudio, video: isVideo);

        mediaData.Clear();
        mediaRecorder = await mediaStream.CreateRecorder(mimeType);
        mediaRecorder.OnError += OutputToConsole;
        mediaRecorder.OnDataAvailable += SaveChunk;

        await mediaRecorder.Start(100);

        // playback the stream
        await playbackElement.SetSrcObject(mediaStream);
        await playbackElement.Play();
    }

    private async Task StopRecording() {
        isRecording = false;

        IMediaStream mediaStream = this.mediaStream!;
        IMediaRecorder mediaRecorder = this.mediaRecorder!;
        this.mediaStream = null;
        this.mediaRecorder = null;

        await mediaRecorder.Stop();
        await playbackElement!.SetSrcObject(null);

        await Task.Delay(1000); // delay cleanup to make sure that the last chunk is saved
        mediaRecorder.OnDataAvailable -= SaveChunk;
        mediaRecorder.OnError -= OutputToConsole;
        await mediaRecorder.DisposeAsync();
        await mediaStream.DisposeAsync();
    }



    // get element reference for live playback of the stream

    [Inject]
    public required IElementFactory ElementFactory { private get; init; }

    private ElementReference audioElement;
    private IHTMLMediaElement? _audio;
    private IHTMLMediaElement Audio => _audio ??= ElementFactory.CreateHTMLMediaElement(audioElement);

    private ElementReference videoElement;
    private IHTMLMediaElement? _video;
    private IHTMLMediaElement Video => _video ??= ElementFactory.CreateHTMLMediaElement(videoElement);



    // download as file

    [Inject]
    public required IDownload Download { private get; init; }

    private async Task SaveAsFile() {
        int mimeTypeLength = mimeType.IndexOf(';');
        if (mimeTypeLength == -1)
            mimeTypeLength = mimeType.Length;

        string fileName = mimeType.AsSpan(0, mimeTypeLength) switch {
            "audio/mpeg" => "example.mp3",
            "audio/mp4"  => "example.m4a",
            "audio/aac"  => "example.aac",
            "audio/webm" => "example.webm",
            "audio/ogg"  => "example.ogg",
            "audio/wav"  => "example.wav",

            "video/mp4"  => "example.mp4",
            "video/webm" => "example.webm",
            "video/ogg"  => "example.ogv",

            _ => throw new UnreachableException($"mimeType = {mimeType}")
        };
        await Download.DownloadAsFile(fileName, [.. mediaData]);
    }
}
