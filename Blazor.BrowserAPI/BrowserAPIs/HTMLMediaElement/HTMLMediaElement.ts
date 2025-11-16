import { HTMLElementAPI } from "../HTMLElement/HTMLElement";
import { PictureInPictureWindowAPI } from "./PictureInPictureWindow/PictureInPictureWindow";
import { MediaStreamAPI } from "../MediaDevices/MediaStream/MediaStream";
import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class HTMLMediaElementAPI {
    private _htmlMediaElement: HTMLMediaElement;
    public get htmlMediaElement(): HTMLMediaElement {
        return this._htmlMediaElement;
    }

    public constructor(htmlMediaElement: HTMLMediaElement) {
        this._htmlMediaElement = htmlMediaElement;
    }

    public static create(htmlMediaElement: HTMLMediaElement): HTMLMediaElementAPI {
        return new HTMLMediaElementAPI(htmlMediaElement);
    }


    public toHTMLElement(): HTMLElementAPI {
        return new HTMLElementAPI(this.htmlMediaElement);
    }


    private static toTimeRangeArray(timeRanges: TimeRanges) {
        let result = [];

        for (let i = 0; i < timeRanges.length; i++)
            result.push({ start: timeRanges.start(i), end: timeRanges.end(i) });

        return result;
    }



    // Properties


    // Attributes

    public getSrc(): string {
        return this.htmlMediaElement.src;
    }

    public setSrc(value: string): void {
        this.htmlMediaElement.src = value;
    }

    public getSrcObject(): [MediaStreamAPI] | [null] {
        const result = this.htmlMediaElement.srcObject;
        if (result instanceof MediaStream)
            return [DotNet.createJSObjectReference(new MediaStreamAPI(result))];
        else
            return [null];
    }

    public setSrcObject(value: MediaStreamAPI | null): void {
        if (value !== null)
            this.htmlMediaElement.srcObject = value?.getStream();
        else
            this.htmlMediaElement.srcObject = null;
    }

    public getControls(): boolean {
        return this.htmlMediaElement.controls;
    }

    public setControls(value: boolean): void {
        this.htmlMediaElement.controls = value;
    }

    public getAutoplay(): boolean {
        return this.htmlMediaElement.autoplay;
    }

    public setAutoplay(value: boolean): void {
        this.htmlMediaElement.autoplay = value;
    }

    public getLoop(): boolean {
        return this.htmlMediaElement.loop;
    }

    public setLoop(value: boolean): void {
        this.htmlMediaElement.loop = value;
    }

    public getDefaultMuted(): boolean {
        return this.htmlMediaElement.defaultMuted;
    }

    public setDefaultMuted(value: boolean): void {
        this.htmlMediaElement.defaultMuted = value;
    }


    public getPreload(): "none" | "metadata" | "auto" | "" {
        return this.htmlMediaElement.preload;
    }

    public setPreload(value: "none" | "metadata" | "auto" | ""): void {
        this.htmlMediaElement.preload = value;
    }


    // State

    public getCurrentSrc(): string {
        return this.htmlMediaElement.currentSrc;
    }

    public getCurrentTime(): number {
        return this.htmlMediaElement.currentTime;
    }

    public setCurrentTime(value: number): void {
        this.htmlMediaElement.currentTime = value;
    }


    public getDuration(): number {
        return this.htmlMediaElement.duration;
    }

    /** @returns TimeRanges */
    public getSeekable(): { start: number, end: number; }[] {
        return HTMLMediaElementAPI.toTimeRangeArray(this.htmlMediaElement.seekable);
    }

    public getMuted(): boolean {
        return this.htmlMediaElement.muted;
    }

    public setMuted(value: boolean): void {
        this.htmlMediaElement.muted = value;
    }

    public getVolume(): number {
        return this.htmlMediaElement.volume;
    }

    public setVolume(value: number): void {
        this.htmlMediaElement.volume = value;
    }

    public getPaused(): boolean {
        return this.htmlMediaElement.paused;
    }

    public getEnded(): boolean {
        return this.htmlMediaElement.ended;
    }

    public getSeeking(): boolean {
        return this.htmlMediaElement.seeking;
    }

    /** @returns 0 = HAVE_NOTHING, 1 = HAVE_METADATA, 2 = HAVE_CURRENT_DATA, 3 = HAVE_FUTURE_DATA, 4 = HAVE_ENOUGH_DATA */
    public getReadyState(): number {
        return this.htmlMediaElement.readyState;
    }

    /** @returns 0 = NETWORK_EMPTY, 1 = NETWORK_IDLE, 2 = NETWORK_LOADING or 3 = NETWORK_NO_SOURCE */
    public getNetworkState(): number {
        return this.htmlMediaElement.networkState;
    }

    /** @returns TimeRanges */
    public getBuffered(): { start: number, end: number; }[] {
        return HTMLMediaElementAPI.toTimeRangeArray(this.htmlMediaElement.buffered);
    }

    /** @returns  TimeRanges */
    public getPlayed(): { start: number, end: number; }[] {
        return HTMLMediaElementAPI.toTimeRangeArray(this.htmlMediaElement.played);
    }


    // Settings

    public getPlaybackRate(): number {
        return this.htmlMediaElement.playbackRate;
    }

    public setPlaybackRate(value: number): void {
        this.htmlMediaElement.playbackRate = value;
    }

    public getDefaultPlaybackRate(): number {
        return this.htmlMediaElement.defaultPlaybackRate;
    }

    public setDefaultPlaybackRate(value: number): void {
        this.htmlMediaElement.defaultPlaybackRate = value;
    }

    public getCrossOrigin(): string {
        return this.htmlMediaElement.crossOrigin ?? "anonymous";
    }

    /** @param value "anonymous" | "use-credentials" */
    public setCrossOrigin(value: string): void {
        this.htmlMediaElement.crossOrigin = value;
    }

    public getPreservesPitch(): boolean {
        return this.htmlMediaElement.preservesPitch;
    }

    public setPreservesPitch(value: boolean): void {
        this.htmlMediaElement.preservesPitch = value;
    }

    public getDisableRemotePlayback(): boolean {
        return this.htmlMediaElement.disableRemotePlayback;
    }

    public setDisableRemotePlayback(value: boolean): void {
        this.htmlMediaElement.disableRemotePlayback = value;
    }


    // Video (HTMLVideoElement only)

    public getWidth(): number {
        return (<HTMLVideoElement>this.htmlMediaElement).width;
    }

    public setWidth(value: number): void {
        (<HTMLVideoElement>this.htmlMediaElement).width = value;
    }

    public getHeight(): number {
        return (<HTMLVideoElement>this.htmlMediaElement).height;
    }

    public setHeight(value: number): void {
        (<HTMLVideoElement>this.htmlMediaElement).height = value;
    }

    public getVideoWidth(): number {
        return (<HTMLVideoElement>this.htmlMediaElement).videoWidth;
    }

    public getVideoHeight(): number {
        return (<HTMLVideoElement>this.htmlMediaElement).videoHeight;
    }

    public getPoster(): string {
        return (<HTMLVideoElement>this.htmlMediaElement).poster;
    }

    public setPoster(value: string): void {
        (<HTMLVideoElement>this.htmlMediaElement).poster = value;
    }

    public getDisablePictureInPicture(): boolean {
        return (<HTMLVideoElement>this.htmlMediaElement).disablePictureInPicture;
    }

    public setDisablePictureInPicture(value: boolean): void {
        (<HTMLVideoElement>this.htmlMediaElement).disablePictureInPicture = value;
    }


    // Methods

    public play(): Promise<void> {
        return this.htmlMediaElement.play();
    }

    public pause(): void {
        this.htmlMediaElement.pause();
    }

    public load(): void {
        this.htmlMediaElement.load();
    }

    public fastSeek(time: number): void {
        this.htmlMediaElement.fastSeek(time);
    }

    public canPlayType(type: string): "probably" | "maybe" | "" {
        return this.htmlMediaElement.canPlayType(type);
    }

    // HTMLVideoElement only
    public async requestPictureInPicture(): Promise<PictureInPictureWindowAPI> {
        const pictureInPictureWindow = await (<HTMLVideoElement>this.htmlMediaElement).requestPictureInPicture();
        return new PictureInPictureWindowAPI(pictureInPictureWindow);
    }


    // events


    private eventTrigger: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // Ready

    // error event

    private onerror = () => BlazorInvoke.method(this.eventTrigger, "InvokeError", this.htmlMediaElement.error!.code, this.htmlMediaElement.error!.message);

    public activateOnerror(): void {
        this.htmlMediaElement.addEventListener("error", this.onerror);
        if (this.htmlMediaElement.error !== null)
            this.onerror();
    }

    public deactivateOnerror(): void {
        this.htmlMediaElement.removeEventListener("error", this.onerror);
    }


    // canplay event

    private oncanplay = () => BlazorInvoke.method(this.eventTrigger, "InvokeCanPlay");

    public activateOncanplay(): void {
        this.htmlMediaElement.addEventListener("canplay", this.oncanplay);
    }

    public deactivateOncanplay(): void {
        this.htmlMediaElement.removeEventListener("canplay", this.oncanplay);
    }


    // canplaythrough event

    private oncanplaythrough = () => BlazorInvoke.method(this.eventTrigger, "InvokeCanPlayThrough");

    public activateOncanplaythrough(): void {
        this.htmlMediaElement.addEventListener("canplaythrough", this.oncanplaythrough);
    }

    public deactivateOncanplaythrough(): void {
        this.htmlMediaElement.removeEventListener("canplaythrough", this.oncanplaythrough);
    }


    // playing event

    private onplaying = () => BlazorInvoke.method(this.eventTrigger, "InvokePlaying");

    public activateOnplaying(): void {
        this.htmlMediaElement.addEventListener("playing", this.onplaying);
    }

    public deactivateOnplaying(): void {
        this.htmlMediaElement.removeEventListener("playing", this.onplaying);
    }


    // Data

    // loadstart event

    private onloadstart = () => BlazorInvoke.method(this.eventTrigger, "InvokeLoadStart");

    public activateOnloadstart(): void {
        this.htmlMediaElement.addEventListener("loadstart", this.onloadstart);
    }

    public deactivateOnloadstart(): void {
        this.htmlMediaElement.removeEventListener("loadstart", this.onloadstart);
    }


    // progress event

    private onprogress = () => BlazorInvoke.method(this.eventTrigger, "InvokeProgress");

    public activateOnprogress(): void {
        this.htmlMediaElement.addEventListener("progress", this.onprogress);
    }

    public deactivateOnprogress(): void {
        this.htmlMediaElement.removeEventListener("progress", this.onprogress);
    }


    // loadeddata event

    private onloadeddata = () => BlazorInvoke.method(this.eventTrigger, "InvokeLoadedData");

    public activateOnloadeddata(): void {
        this.htmlMediaElement.addEventListener("loadeddata", this.onloadeddata);
    }

    public deactivateOnloadeddata(): void {
        this.htmlMediaElement.removeEventListener("loadeddata", this.onloadeddata);
    }


    // loadedmetadata event

    private onloadedmetadata = () => BlazorInvoke.method(this.eventTrigger, "InvokeLoadedMetadata");

    public activateOnloadedmetadata(): void {
        this.htmlMediaElement.addEventListener("loadedmetadata", this.onloadedmetadata);
    }

    public deactivateOnloadedmetadata(): void {
        this.htmlMediaElement.removeEventListener("loadedmetadata", this.onloadedmetadata);
    }


    // stalled event

    private onstalled = () => BlazorInvoke.method(this.eventTrigger, "InvokeStalled");

    public activateOnstalled(): void {
        this.htmlMediaElement.addEventListener("stalled", this.onstalled);
    }

    public deactivateOnstalled(): void {
        this.htmlMediaElement.removeEventListener("stalled", this.onstalled);
    }


    // suspend event

    private onsuspend = () => BlazorInvoke.method(this.eventTrigger, "InvokeSuspend");

    public activateOnsuspend(): void {
        this.htmlMediaElement.addEventListener("suspend", this.onsuspend);
    }

    public deactivateOnsuspend(): void {
        this.htmlMediaElement.removeEventListener("suspend", this.onsuspend);
    }


    // waiting event

    private onwaiting = () => BlazorInvoke.method(this.eventTrigger, "InvokeWaiting");

    public activateOnwaiting(): void {
        this.htmlMediaElement.addEventListener("waiting", this.onwaiting);
    }

    public deactivateOnwaiting(): void {
        this.htmlMediaElement.removeEventListener("waiting", this.onwaiting);
    }


    // abort event

    private onabort = () => BlazorInvoke.method(this.eventTrigger, "InvokeAbort");

    public activateOnabort(): void {
        this.htmlMediaElement.addEventListener("abort", this.onabort);
    }

    public deactivateOnabort(): void {
        this.htmlMediaElement.removeEventListener("abort", this.onabort);
    }


    // emptied event

    private onemptied = () => BlazorInvoke.method(this.eventTrigger, "InvokeEmptied");

    public activateOnemptied(): void {
        this.htmlMediaElement.addEventListener("emptied", this.onemptied);
    }

    public deactivateOnemptied(): void {
        this.htmlMediaElement.removeEventListener("emptied", this.onemptied);
    }


    // Timing

    // play event

    private onplay = () => BlazorInvoke.method(this.eventTrigger, "InvokePlay");

    public activateOnplay(): void {
        this.htmlMediaElement.addEventListener("play", this.onplay);
    }

    public deactivateOnplay(): void {
        this.htmlMediaElement.removeEventListener("play", this.onplay);
    }


    // pause event

    private onpause = () => BlazorInvoke.method(this.eventTrigger, "InvokePause");

    public activateOnpause(): void {
        this.htmlMediaElement.addEventListener("pause", this.onpause);
    }

    public deactivateOnpause(): void {
        this.htmlMediaElement.removeEventListener("pause", this.onpause);
    }


    // ended event

    private onended = () => BlazorInvoke.method(this.eventTrigger, "InvokeEnded");

    public activateOnended(): void {
        this.htmlMediaElement.addEventListener("ended", this.onended);
    }

    public deactivateOnended(): void {
        this.htmlMediaElement.removeEventListener("ended", this.onended);
    }


    // seeking event

    private onseeking = () => BlazorInvoke.method(this.eventTrigger, "InvokeSeeking");

    public activateOnseeking(): void {
        this.htmlMediaElement.addEventListener("seeking", this.onseeking);
    }

    public deactivateOnseeking(): void {
        this.htmlMediaElement.removeEventListener("seeking", this.onseeking);
    }


    // seeked event

    private onseeked = () => BlazorInvoke.method(this.eventTrigger, "InvokeSeeked");

    public activateOnseeked(): void {
        this.htmlMediaElement.addEventListener("seeked", this.onseeked);
    }

    public deactivateOnseeked(): void {
        this.htmlMediaElement.removeEventListener("seeked", this.onseeked);
    }


    // timeupdate event

    private ontimeupdate = () => BlazorInvoke.method(this.eventTrigger, "InvokeTimeUpdate");

    public activateOntimeupdate(): void {
        this.htmlMediaElement.addEventListener("timeupdate", this.ontimeupdate);
    }

    public deactivateOntimeupdate(): void {
        this.htmlMediaElement.removeEventListener("timeupdate", this.ontimeupdate);
    }


    // Setting

    // volumechange event

    private onvolumechange = () => BlazorInvoke.method(this.eventTrigger, "InvokeVolumeChange");

    public activateOnvolumechange(): void {
        this.htmlMediaElement.addEventListener("volumechange", this.onvolumechange);
    }

    public deactivateOnvolumechange(): void {
        this.htmlMediaElement.removeEventListener("volumechange", this.onvolumechange);
    }


    // ratechange event

    private onratechange = () => BlazorInvoke.method(this.eventTrigger, "InvokeRateChange");

    public activateOnratechange(): void {
        this.htmlMediaElement.addEventListener("ratechange", this.onratechange);
    }

    public deactivateOnratechange(): void {
        this.htmlMediaElement.removeEventListener("ratechange", this.onratechange);
    }


    // durationchange event

    private ondurationchange = () => BlazorInvoke.method(this.eventTrigger, "InvokeDurationChange");

    public activateOndurationchange(): void {
        this.htmlMediaElement.addEventListener("durationchange", this.ondurationchange);
    }

    public deactivateOndurationchange(): void {
        this.htmlMediaElement.removeEventListener("durationchange", this.ondurationchange);
    }


    // Video

    // HTMLMediaElement - resize event

    private onresize = () => BlazorInvoke.method(this.eventTrigger, "InvokeResize");

    public activateOnresize(): void {
        this.htmlMediaElement.addEventListener("resize", this.onresize);
    }

    public deactivateOnresize(): void {
        this.htmlMediaElement.removeEventListener("resize", this.onresize);
    }


    // HTMLMediaElement - enterpictureinpicture event

    private onenterpictureinpicture = (event: PictureInPictureEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeEnterPictureInPicture", DotNet.createJSObjectReference(event.pictureInPictureWindow));

    public activateOnenterpictureinpicture(): void {
        this.htmlMediaElement.addEventListener("enterpictureinpicture", this.onenterpictureinpicture);
    }

    public deactivateOnenterpictureinpicture(): void {
        this.htmlMediaElement.removeEventListener("enterpictureinpicture", this.onenterpictureinpicture);
    }


    // HTMLMediaElement - leavepictureinpicture event

    private onleavepictureinpicture = (event: PictureInPictureEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeLeavePictureInPicture", DotNet.createJSObjectReference(event.pictureInPictureWindow));

    public activateOnleavepictureinpicture(): void {
        this.htmlMediaElement.addEventListener("leavepictureinpicture", this.onleavepictureinpicture);
    }

    public deactivateOnleavepictureinpicture(): void {
        this.htmlMediaElement.removeEventListener("leavepictureinpicture", this.onleavepictureinpicture);
    }
}
