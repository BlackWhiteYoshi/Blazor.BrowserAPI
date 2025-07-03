import { MediaStreamAPI } from "../MediaStream/MediaStream";
import { blazorInvokeMethod } from "../../../Extensions/blazorExtensions";

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


    // dataavailable event

    #ondataavailableCallback = async (event: BlobEvent) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeDataavailable", new Uint8Array(await event.data.arrayBuffer()));

    activateOndataavailable() {
        this.#mediaRecorder.addEventListener("dataavailable", this.#ondataavailableCallback);
    }

    deactivateOndataavailable() {
        this.#mediaRecorder.removeEventListener("dataavailable", this.#ondataavailableCallback);
    }


    // error event

    #onerrorCallback = (event: Event) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeError", event);

    activateOnerror() {
        this.#mediaRecorder.addEventListener("error", this.#onerrorCallback);
    }

    deactivateOnerror() {
        this.#mediaRecorder.removeEventListener("error", this.#onerrorCallback);
    }


    // start event

    #onstartCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeStart");

    activateOnstart() {
        this.#mediaRecorder.addEventListener("start", this.#onstartCallback);
    }

    deactivateOnstart() {
        this.#mediaRecorder.removeEventListener("start", this.#onstartCallback);
    }


    // stop event

    #onstopCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeStop");

    activateOnstop() {
        this.#mediaRecorder.addEventListener("stop", this.#onstopCallback);
    }

    deactivateOnstop() {
        this.#mediaRecorder.removeEventListener("stop", this.#onstopCallback);
    }


    // resume event

    #onresumeCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeResume");

    activateOnresume() {
        this.#mediaRecorder.addEventListener("resume", this.#onresumeCallback);
    }

    deactivateOnresume() {
        this.#mediaRecorder.removeEventListener("resume", this.#onresumeCallback);
    }


    // pause event

    #onpauseCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokePause");

    activateOnpause() {
        this.#mediaRecorder.addEventListener("pause", this.#onpauseCallback);
    }

    deactivateOnpause() {
        this.#mediaRecorder.removeEventListener("pause", this.#onpauseCallback);
    }
}
