import { MediaStreamWrapper } from "../MediaStream/MediaStream";

export class MediaRecorderWrapper {
    /** @type {MediaRecorder} */
    #mediaRecorder;

    /**
     * @param {MediaStream} mediaStream
     * @param {MediaRecorderOptions} options
     */
    constructor(mediaStream, options) {
        this.#mediaRecorder = new MediaRecorder(mediaStream, options);
    }


    /**
     * @returns {string}
     */
    getMimeType() {
        return this.#mediaRecorder.mimeType;
    }

    /**
     * @returns {"inactive" | "paused" | "recording"}
     */
    getState() {
        return this.#mediaRecorder.state;
    }

    /**
     * @returns {MediaStreamWrapper}
     */
    getStream() {
        return new MediaStreamWrapper(this.#mediaRecorder.stream);
    }

    /**
     * @returns {number}
     */
    getAudioBitsPerSecond() {
        return this.#mediaRecorder.audioBitsPerSecond;
    }

    /**
     * @returns {number}
     */
    getVideoBitsPerSecond() {
        return this.#mediaRecorder.videoBitsPerSecond;
    }


    /**
     * @param {number} timeslice
     */
    start(timeslice) {
        this.#mediaRecorder.start(timeslice > 0 ? timeslice : undefined);
    }

    /**
     */
    stop() {
        this.#mediaRecorder.stop();
    }

    /**
     */
    resume() {
        this.#mediaRecorder.resume();
    }

    /**
     */
    pause() {
        this.#mediaRecorder.pause();
    }

    /**
     */
    requestData() {
        this.#mediaRecorder.requestData();
    }


    /**
     * @param {string} mimeType
     * @returns {boolean}
     */
    isTypeSupported(mimeType) {
        return MediaRecorder.isTypeSupported(mimeType);
    }


    // events

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOndataavailable(eventTrigger) {
        this.#mediaRecorder.ondataavailable = async (event) => await eventTrigger.invokeMethodAsync("InvokeDataavailable", new Uint8Array(await event.data.arrayBuffer()));
    }
    /**
     */
    deactivateOndataavailable() {
        this.#mediaRecorder.ondataavailable = null;
    }

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnerror(eventTrigger) {
        this.#mediaRecorder.onerror = (event) => eventTrigger.invokeMethodAsync("InvokeError", event);
    }
    /**
     */
    deactivateOnerror() {
        this.#mediaRecorder.onerror = null;
    }

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnstart(eventTrigger) {
        this.#mediaRecorder.onstart = () => eventTrigger.invokeMethodAsync("InvokeStart");
    }
    /**
     */
    deactivateOnstart() {
        this.#mediaRecorder.onstart = null;
    }

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnstop(eventTrigger) {
        this.#mediaRecorder.onstop = () => eventTrigger.invokeMethodAsync("InvokeStop");
    }
    /**
     */
    deactivateOnstop() {
        this.#mediaRecorder.onstop = null;
    }

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnresume(eventTrigger) {
        this.#mediaRecorder.onresume = () => eventTrigger.invokeMethodAsync("InvokeResume");
    }
    /**
     */
    deactivateOnresume() {
        this.#mediaRecorder.onresume = null;
    }

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnpause(eventTrigger) {
        this.#mediaRecorder.onpause = () => eventTrigger.invokeMethodAsync("InvokePause");
    }
    /**
     */
    deactivateOnpause() {
        this.#mediaRecorder.onpause = null;
    }
}
