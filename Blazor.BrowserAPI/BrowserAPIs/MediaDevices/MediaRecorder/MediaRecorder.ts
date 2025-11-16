import { MediaStreamAPI } from "../MediaStream/MediaStream";
import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class MediaRecorderAPI {
    private mediaRecorder: MediaRecorder;

    public constructor(mediaStream: MediaStream, options: MediaRecorderOptions) {
        this.mediaRecorder = new MediaRecorder(mediaStream, options);
    }


    public getMimeType(): string {
        return this.mediaRecorder.mimeType;
    }

    public getState(): "inactive" | "paused" | "recording" {
        return this.mediaRecorder.state;
    }

    public getStream(): MediaStreamAPI {
        return new MediaStreamAPI(this.mediaRecorder.stream);
    }

    public getAudioBitsPerSecond(): number {
        return this.mediaRecorder.audioBitsPerSecond;
    }

    public getVideoBitsPerSecond(): number {
        return this.mediaRecorder.videoBitsPerSecond;
    }


    public start(timeslice: number): void {
        this.mediaRecorder.start(timeslice > 0 ? timeslice : undefined);
    }

    public stop(): void {
        this.mediaRecorder.stop();
    }

    public resume(): void {
        this.mediaRecorder.resume();
    }

    public pause(): void {
        this.mediaRecorder.pause();
    }

    public requestData(): void {
        this.mediaRecorder.requestData();
    }


    public isTypeSupported(mimeType: string): boolean {
        return MediaRecorder.isTypeSupported(mimeType);
    }


    // events


    private eventTrigger: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // dataavailable event

    private ondataavailable = async (event: BlobEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDataAvailable", new Uint8Array(await event.data.arrayBuffer()));

    public activateOndataavailable(): void {
        this.mediaRecorder.addEventListener("dataavailable", this.ondataavailable);
    }

    public deactivateOndataavailable(): void {
        this.mediaRecorder.removeEventListener("dataavailable", this.ondataavailable);
    }


    // error event

    private onerror = (event: Event) => BlazorInvoke.method(this.eventTrigger, "InvokeError", event);

    public activateOnerror(): void {
        this.mediaRecorder.addEventListener("error", this.onerror);
    }

    public deactivateOnerror(): void {
        this.mediaRecorder.removeEventListener("error", this.onerror);
    }


    // start event

    private onstart = () => BlazorInvoke.method(this.eventTrigger, "InvokeStart");

    public activateOnstart(): void {
        this.mediaRecorder.addEventListener("start", this.onstart);
    }

    public deactivateOnstart(): void {
        this.mediaRecorder.removeEventListener("start", this.onstart);
    }


    // stop event

    private onstop = () => BlazorInvoke.method(this.eventTrigger, "InvokeStop");

    public activateOnstop(): void {
        this.mediaRecorder.addEventListener("stop", this.onstop);
    }

    public deactivateOnstop(): void {
        this.mediaRecorder.removeEventListener("stop", this.onstop);
    }


    // resume event

    private onresume = () => BlazorInvoke.method(this.eventTrigger, "InvokeResume");

    public activateOnresume(): void {
        this.mediaRecorder.addEventListener("resume", this.onresume);
    }

    public deactivateOnresume(): void {
        this.mediaRecorder.removeEventListener("resume", this.onresume);
    }


    // pause event

    private onpause = () => BlazorInvoke.method(this.eventTrigger, "InvokePause");

    public activateOnpause(): void {
        this.mediaRecorder.addEventListener("pause", this.onpause);
    }

    public deactivateOnpause(): void {
        this.mediaRecorder.removeEventListener("pause", this.onpause);
    }
}
