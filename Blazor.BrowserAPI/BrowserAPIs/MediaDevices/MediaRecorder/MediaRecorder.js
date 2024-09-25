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

    /** @type {import("../../../blazor").DotNet.DotNetObject} */
    #eventTrigger;

    /** @type {boolean} */
    #isEventTriggerSync;


    // #region dataavailable event

    /**
     * @param {BlobEvent} event
     */
    #ondataavailableCallback = async (event) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeDataavailable", new Uint8Array(await event.data.arrayBuffer()))
        : await this.#eventTrigger.invokeMethodAsync("InvokeDataavailable", new Uint8Array(await event.data.arrayBuffer()));

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOndataavailable(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#mediaRecorder.addEventListener("dataavailable", this.#ondataavailableCallback);
    }

    /**
     */
    deactivateOndataavailable() {
        this.#mediaRecorder.removeEventListener("dataavailable", this.#ondataavailableCallback);
    }

    // #endregion


    // #region error event

    /**
     * @param {Event} event
     */
    #onerrorCallback = (event) => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeError", event) : this.#eventTrigger.invokeMethodAsync("InvokeError", event);

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnerror(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#mediaRecorder.addEventListener("error", this.#onerrorCallback);
    }

    /**
     */
    deactivateOnerror() {
        this.#mediaRecorder.removeEventListener("error", this.#onerrorCallback);
    }

    // #endregion


    // #region start event

    /**
     */
    #onstartCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeStart") : this.#eventTrigger.invokeMethodAsync("InvokeStart");

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnstart(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#mediaRecorder.addEventListener("start", this.#onstartCallback);
    }

    /**
     */
    deactivateOnstart() {
        this.#mediaRecorder.removeEventListener("start", this.#onstartCallback);
    }

    // #endregion


    // #region stop event

    /**
     */
    #onstopCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeStop") : this.#eventTrigger.invokeMethodAsync("InvokeStop");

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnstop(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#mediaRecorder.addEventListener("stop", this.#onstopCallback);
    }

    /**
     */
    deactivateOnstop() {
        this.#mediaRecorder.removeEventListener("stop", this.#onstopCallback);
    }

    // #endregion


    // #region resume event

    /**
     */
    #onresumeCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeResume") : this.#eventTrigger.invokeMethodAsync("InvokeResume");

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnresume(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#mediaRecorder.addEventListener("resume", this.#onresumeCallback);
    }

    /**
     */
    deactivateOnresume() {
        this.#mediaRecorder.removeEventListener("resume", this.#onresumeCallback);
    }

    // #endregion


    // #region pause event

    /**
     */
    #onpauseCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokePause") : this.#eventTrigger.invokeMethodAsync("InvokePause");

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnpause(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#mediaRecorder.addEventListener("pause", this.#onpauseCallback);
    }

    /**
     */
    deactivateOnpause() {
        this.#mediaRecorder.removeEventListener("pause", this.#onpauseCallback);
    }

    // #endregion
}
