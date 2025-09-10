import { MediaStreamAPI } from "../MediaStream/MediaStream";
import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

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


    start(timeslice: number): void {
        this.#mediaRecorder.start(timeslice > 0 ? timeslice : undefined);
    }

    stop(): void {
        this.#mediaRecorder.stop();
    }

    resume(): void {
        this.#mediaRecorder.resume();
    }

    pause(): void {
        this.#mediaRecorder.pause();
    }

    requestData(): void {
        this.#mediaRecorder.requestData();
    }


    isTypeSupported(mimeType: string): boolean {
        return MediaRecorder.isTypeSupported(mimeType);
    }


    // events


    #eventTrigger: DotNet.DotNetObject;

    initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.#eventTrigger = eventTrigger;
    }


    // dataavailable event

    #ondataavailable = async (event: BlobEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDataAvailable", new Uint8Array(await event.data.arrayBuffer()));

    activateOndataavailable(): void {
        this.#mediaRecorder.addEventListener("dataavailable", this.#ondataavailable);
    }

    deactivateOndataavailable(): void {
        this.#mediaRecorder.removeEventListener("dataavailable", this.#ondataavailable);
    }


    // error event

    #onerror = (event: Event) => BlazorInvoke.method(this.#eventTrigger, "InvokeError", event);

    activateOnerror(): void {
        this.#mediaRecorder.addEventListener("error", this.#onerror);
    }

    deactivateOnerror(): void {
        this.#mediaRecorder.removeEventListener("error", this.#onerror);
    }


    // start event

    #onstart = () => BlazorInvoke.method(this.#eventTrigger, "InvokeStart");

    activateOnstart(): void {
        this.#mediaRecorder.addEventListener("start", this.#onstart);
    }

    deactivateOnstart(): void {
        this.#mediaRecorder.removeEventListener("start", this.#onstart);
    }


    // stop event

    #onstop = () => BlazorInvoke.method(this.#eventTrigger, "InvokeStop");

    activateOnstop(): void {
        this.#mediaRecorder.addEventListener("stop", this.#onstop);
    }

    deactivateOnstop(): void {
        this.#mediaRecorder.removeEventListener("stop", this.#onstop);
    }


    // resume event

    #onresume = () => BlazorInvoke.method(this.#eventTrigger, "InvokeResume");

    activateOnresume(): void {
        this.#mediaRecorder.addEventListener("resume", this.#onresume);
    }

    deactivateOnresume(): void {
        this.#mediaRecorder.removeEventListener("resume", this.#onresume);
    }


    // pause event

    #onpause = () => BlazorInvoke.method(this.#eventTrigger, "InvokePause");

    activateOnpause(): void {
        this.#mediaRecorder.addEventListener("pause", this.#onpause);
    }

    deactivateOnpause(): void {
        this.#mediaRecorder.removeEventListener("pause", this.#onpause);
    }
}
