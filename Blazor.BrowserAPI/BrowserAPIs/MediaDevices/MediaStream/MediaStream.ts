import { MediaRecorderAPI } from "../MediaRecorder/MediaRecorder";

export class MediaStreamAPI {
    #mediaStream: MediaStream;

    constructor(mediaStream: MediaStream) {
        this.#mediaStream = mediaStream;
    }

    dispose() {
        for (const mediaStreamTrack of this.#mediaStream.getTracks()) {
            mediaStreamTrack.stop();
            this.#mediaStream.removeTrack(mediaStreamTrack);
        }
    }


    getStream(): MediaStream {
        return this.#mediaStream;
    }


    getActive(): boolean {
        return this.#mediaStream.active;
    }

    getId(): string {
        return this.#mediaStream.id;
    }


    createMediaRecorder(mimeType: string, audioBitsPerSecond: number, videoBitsPerSecond: number, bitsPerSecond: number): MediaRecorderAPI {
        const options: MediaRecorderOptions = {
            mimeType: mimeType !== "" ? mimeType : undefined,
            audioBitsPerSecond: audioBitsPerSecond > 0 ? audioBitsPerSecond : undefined,
            videoBitsPerSecond: videoBitsPerSecond > 0 ? videoBitsPerSecond : undefined,
            bitsPerSecond: bitsPerSecond > 0 ? bitsPerSecond : undefined
        };
        return new MediaRecorderAPI(this.#mediaStream, options);
    }
}
