import { MediaStreamAPI } from "../MediaStream/MediaStream";

export class MediaRecorderAPI {
    #mediaRecorder: MediaRecorder;

    constructor(mediaStream: MediaStream, options: MediaRecorderOptions) {
        this.#mediaRecorder = new MediaRecorder(mediaStream, options);
    }


    getMimeType(): string {
        return this.#mediaRecorder.mimeType;
    }

    getState(): "inactive" | "paused" | "recording" {
        return this.#mediaRecorder.state;
    }

    getStream(): MediaStreamAPI {
        return new MediaStreamAPI(this.#mediaRecorder.stream);
    }

    getAudioBitsPerSecond(): number {
        return this.#mediaRecorder.audioBitsPerSecond;
    }

    getVideoBitsPerSecond(): number {
        return this.#mediaRecorder.videoBitsPerSecond;
    }


    start(timeslice: number) {
        this.#mediaRecorder.start(timeslice > 0 ? timeslice : undefined);
    }

    stop() {
        this.#mediaRecorder.stop();
    }

    resume() {
        this.#mediaRecorder.resume();
    }

    pause() {
        this.#mediaRecorder.pause();
    }

    requestData() {
        this.#mediaRecorder.requestData();
    }


    isTypeSupported(mimeType: string): boolean {
        return MediaRecorder.isTypeSupported(mimeType);
    }


    // events

    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // #region dataavailable event

    #ondataavailableCallback = async (event: BlobEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeDataavailable", new Uint8Array(await event.data.arrayBuffer()))
        : await this.#eventTrigger.invokeMethodAsync("InvokeDataavailable", new Uint8Array(await event.data.arrayBuffer()));

    activateOndataavailable() {
        this.#mediaRecorder.addEventListener("dataavailable", this.#ondataavailableCallback);
    }

    deactivateOndataavailable() {
        this.#mediaRecorder.removeEventListener("dataavailable", this.#ondataavailableCallback);
    }

    // #endregion


    // #region error event

    #onerrorCallback = (event: Event) => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeError", event) : this.#eventTrigger.invokeMethodAsync("InvokeError", event);

    activateOnerror() {
        this.#mediaRecorder.addEventListener("error", this.#onerrorCallback);
    }

    deactivateOnerror() {
        this.#mediaRecorder.removeEventListener("error", this.#onerrorCallback);
    }

    // #endregion


    // #region start event

    #onstartCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeStart") : this.#eventTrigger.invokeMethodAsync("InvokeStart");

    activateOnstart() {
        this.#mediaRecorder.addEventListener("start", this.#onstartCallback);
    }

    deactivateOnstart() {
        this.#mediaRecorder.removeEventListener("start", this.#onstartCallback);
    }

    // #endregion


    // #region stop event

    #onstopCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeStop") : this.#eventTrigger.invokeMethodAsync("InvokeStop");

    activateOnstop() {
        this.#mediaRecorder.addEventListener("stop", this.#onstopCallback);
    }

    deactivateOnstop() {
        this.#mediaRecorder.removeEventListener("stop", this.#onstopCallback);
    }

    // #endregion


    // #region resume event

    #onresumeCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeResume") : this.#eventTrigger.invokeMethodAsync("InvokeResume");

    activateOnresume() {
        this.#mediaRecorder.addEventListener("resume", this.#onresumeCallback);
    }

    deactivateOnresume() {
        this.#mediaRecorder.removeEventListener("resume", this.#onresumeCallback);
    }

    // #endregion


    // #region pause event

    #onpauseCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokePause") : this.#eventTrigger.invokeMethodAsync("InvokePause");

    activateOnpause() {
        this.#mediaRecorder.addEventListener("pause", this.#onpauseCallback);
    }

    deactivateOnpause() {
        this.#mediaRecorder.removeEventListener("pause", this.#onpauseCallback);
    }

    // #endregion
}
