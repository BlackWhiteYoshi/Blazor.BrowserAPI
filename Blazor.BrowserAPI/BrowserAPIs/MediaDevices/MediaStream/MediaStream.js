import { MediaRecorderWrapper } from "../MediaRecorder/MediaRecorder";


/**
 * @param {MediaStream} mediaStream
 * @returns {MediaStreamWrapper}
 */
export function createMediaStream(mediaStream) {
    return new MediaStreamWrapper(mediaStream);
}


export class MediaStreamWrapper {
    /** @type {MediaStream} */
    #mediaStream;

    /**
     * @param {MediaStream} mediaStream
     */
    constructor(mediaStream) {
        this.#mediaStream = mediaStream;
    }

    /**
     */
    dispose() {
        for (const mediaStreamTrack of this.#mediaStream.getTracks()) {
            mediaStreamTrack.stop();
            this.#mediaStream.removeTrack(mediaStreamTrack);
        }
    }


    /**
     * @returns {MediaStream}
     */
    getStream() {
        return this.#mediaStream;
    }


    /**
     * @returns {boolean}
     */
    getActive() {
        return this.#mediaStream.active;
    }

    /**
     * @returns {string}
     */
    getId() {
        return this.#mediaStream.id;
    }


    /**
     * @param {string} mimeType
     * @param {number} audioBitsPerSecond
     * @param {number} videoBitsPerSecond
     * @param {number} bitsPerSecond
     */
    createMediaRecorder(mimeType, audioBitsPerSecond, videoBitsPerSecond, bitsPerSecond) {
        /** @type {MediaRecorderOptions} */
        const options = {
            mimeType: mimeType !== "" ? mimeType : undefined,
            audioBitsPerSecond: audioBitsPerSecond > 0 ? audioBitsPerSecond : undefined,
            videoBitsPerSecond: videoBitsPerSecond > 0 ? videoBitsPerSecond : undefined,
            bitsPerSecond: bitsPerSecond > 0 ? bitsPerSecond : undefined
        };
        return new MediaRecorderWrapper(this.#mediaStream, options);
    }
}
