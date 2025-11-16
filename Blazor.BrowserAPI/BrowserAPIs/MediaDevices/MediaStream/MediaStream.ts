import { MediaRecorderAPI } from "../MediaRecorder/MediaRecorder";

export class MediaStreamAPI {
    private mediaStream: MediaStream;

    public constructor(mediaStream: MediaStream) {
        this.mediaStream = mediaStream;
    }

    public dispose(): void {
        for (const mediaStreamTrack of this.mediaStream.getTracks()) {
            mediaStreamTrack.stop();
            this.mediaStream.removeTrack(mediaStreamTrack);
        }
    }


    public getStream(): MediaStream {
        return this.mediaStream;
    }


    public getActive(): boolean {
        return this.mediaStream.active;
    }

    public getId(): string {
        return this.mediaStream.id;
    }


    public createMediaRecorder(mimeType: string, audioBitsPerSecond: number, videoBitsPerSecond: number, bitsPerSecond: number): MediaRecorderAPI {
        const options: MediaRecorderOptions = {
            mimeType: mimeType !== "" ? mimeType : undefined,
            audioBitsPerSecond: audioBitsPerSecond > 0 ? audioBitsPerSecond : undefined,
            videoBitsPerSecond: videoBitsPerSecond > 0 ? videoBitsPerSecond : undefined,
            bitsPerSecond: bitsPerSecond > 0 ? bitsPerSecond : undefined
        };
        return new MediaRecorderAPI(this.mediaStream, options);
    }
}
