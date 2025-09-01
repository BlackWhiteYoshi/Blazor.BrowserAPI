import { HTMLElementAPI } from "../HTMLElement/HTMLElement";
import { PictureInPictureWindowAPI } from "./PictureInPictureWindow/PictureInPictureWindow";
import { MediaStreamAPI } from "../MediaDevices/MediaStream/MediaStream";
import { blazorInvokeMethod } from "../../Extensions/blazorExtensions";

export class HTMLMediaElementAPI {
    #htmlMediaElement: HTMLMediaElement;

    constructor(htmlMediaElement: HTMLMediaElement) {
        this.#htmlMediaElement = htmlMediaElement;
    }

    static create(htmlMediaElement: HTMLMediaElement): HTMLMediaElementAPI {
        return new HTMLMediaElementAPI(htmlMediaElement);
    }


    toHTMLElement(): HTMLElementAPI {
        return new HTMLElementAPI(this.#htmlMediaElement);
    }


    static #toTimeRangeArray(timeRanges: TimeRanges) {
        let result = [];

        for (let i = 0; i < timeRanges.length; i++)
            result.push({ start: timeRanges.start(i), end: timeRanges.end(i) });

        return result;
    }



    // Properties


    // Attributes

    getSrc(): string {
        return this.#htmlMediaElement.src;
    }

    setSrc(value: string): void {
        this.#htmlMediaElement.src = value;
    }

    getSrcObject(): [MediaStreamAPI] | [null] {
        const result = this.#htmlMediaElement.srcObject;
        if (result instanceof MediaStream)
            return [DotNet.createJSObjectReference(new MediaStreamAPI(result))];
        else
            return [null];
    }

    setSrcObject(value: MediaStreamAPI | null): void {
        if (value !== null)
            this.#htmlMediaElement.srcObject = value?.getStream();
        else
            this.#htmlMediaElement.srcObject = null;
    }

    getControls(): boolean {
        return this.#htmlMediaElement.controls;
    }

    setControls(value: boolean): void {
        this.#htmlMediaElement.controls = value;
    }

    getAutoplay(): boolean {
        return this.#htmlMediaElement.autoplay;
    }

    setAutoplay(value: boolean): void {
        this.#htmlMediaElement.autoplay = value;
    }

    getLoop(): boolean {
        return this.#htmlMediaElement.loop;
    }

    setLoop(value: boolean): void {
        this.#htmlMediaElement.loop = value;
    }

    getDefaultMuted(): boolean {
        return this.#htmlMediaElement.defaultMuted;
    }

    setDefaultMuted(value: boolean): void {
        this.#htmlMediaElement.defaultMuted = value;
    }


    getPreload(): "none" | "metadata" | "auto" | "" {
        return this.#htmlMediaElement.preload;
    }

    setPreload(value: "none" | "metadata" | "auto" | ""): void {
        this.#htmlMediaElement.preload = value;
    }


    // State

    getCurrentSrc(): string {
        return this.#htmlMediaElement.currentSrc;
    }

    getCurrentTime(): number {
        return this.#htmlMediaElement.currentTime;
    }

    setCurrentTime(value: number): void {
        this.#htmlMediaElement.currentTime = value;
    }


    getDuration(): number {
        return this.#htmlMediaElement.duration;
    }

    /** @returns TimeRanges */
    getSeekable(): { start: number, end: number; }[] {
        return HTMLMediaElementAPI.#toTimeRangeArray(this.#htmlMediaElement.seekable);
    }

    getMuted(): boolean {
        return this.#htmlMediaElement.muted;
    }

    setMuted(value: boolean): void {
        this.#htmlMediaElement.muted = value;
    }

    getVolume(): number {
        return this.#htmlMediaElement.volume;
    }

    setVolume(value: number): void {
        this.#htmlMediaElement.volume = value;
    }

    getPaused(): boolean {
        return this.#htmlMediaElement.paused;
    }

    getEnded(): boolean {
        return this.#htmlMediaElement.ended;
    }

    getSeeking(): boolean {
        return this.#htmlMediaElement.seeking;
    }

    /** @returns 0 = HAVE_NOTHING, 1 = HAVE_METADATA, 2 = HAVE_CURRENT_DATA, 3 = HAVE_FUTURE_DATA, 4 = HAVE_ENOUGH_DATA */
    getReadyState(): number {
        return this.#htmlMediaElement.readyState;
    }

    /** @returns 0 = NETWORK_EMPTY, 1 = NETWORK_IDLE, 2 = NETWORK_LOADING or 3 = NETWORK_NO_SOURCE */
    getNetworkState(): number {
        return this.#htmlMediaElement.networkState;
    }

    /** @returns TimeRanges */
    getBuffered(): { start: number, end: number; }[] {
        return HTMLMediaElementAPI.#toTimeRangeArray(this.#htmlMediaElement.buffered);
    }

    /** @returns  TimeRanges */
    getPlayed(): { start: number, end: number; }[] {
        return HTMLMediaElementAPI.#toTimeRangeArray(this.#htmlMediaElement.played);
    }


    // Settings

    getPlaybackRate(): number {
        return this.#htmlMediaElement.playbackRate;
    }

    setPlaybackRate(value: number): void {
        this.#htmlMediaElement.playbackRate = value;
    }

    getDefaultPlaybackRate(): number {
        return this.#htmlMediaElement.defaultPlaybackRate;
    }

    setDefaultPlaybackRate(value: number): void {
        this.#htmlMediaElement.defaultPlaybackRate = value;
    }

    getCrossOrigin(): string {
        return this.#htmlMediaElement.crossOrigin ?? "anonymous";
    }

    /** @param value "anonymous" | "use-credentials" */
    setCrossOrigin(value: string): void {
        this.#htmlMediaElement.crossOrigin = value;
    }

    getPreservesPitch(): boolean {
        return this.#htmlMediaElement.preservesPitch;
    }

    setPreservesPitch(value: boolean): void {
        this.#htmlMediaElement.preservesPitch = value;
    }

    getDisableRemotePlayback(): boolean {
        return this.#htmlMediaElement.disableRemotePlayback;
    }

    setDisableRemotePlayback(value: boolean): void {
        this.#htmlMediaElement.disableRemotePlayback = value;
    }


    // Video (HTMLVideoElement only)

    getWidth(): number {
        return (<HTMLVideoElement>this.#htmlMediaElement).width;
    }

    setWidth(value: number): void {
        (<HTMLVideoElement>this.#htmlMediaElement).width = value;
    }

    getHeight(): number {
        return (<HTMLVideoElement>this.#htmlMediaElement).height;
    }

    setHeight(value: number): void {
        (<HTMLVideoElement>this.#htmlMediaElement).height = value;
    }

    getVideoWidth(): number {
        return (<HTMLVideoElement>this.#htmlMediaElement).videoWidth;
    }

    getVideoHeight(): number {
        return (<HTMLVideoElement>this.#htmlMediaElement).videoHeight;
    }

    getPoster(): string {
        return (<HTMLVideoElement>this.#htmlMediaElement).poster;
    }

    setPoster(value: string): void {
        (<HTMLVideoElement>this.#htmlMediaElement).poster = value;
    }

    getDisablePictureInPicture(): boolean {
        return (<HTMLVideoElement>this.#htmlMediaElement).disablePictureInPicture;
    }

    setDisablePictureInPicture(value: boolean): void {
        (<HTMLVideoElement>this.#htmlMediaElement).disablePictureInPicture = value;
    }


    // Methods

    play(): Promise<void> {
        return this.#htmlMediaElement.play();
    }

    pause(): void {
        this.#htmlMediaElement.pause();
    }

    load(): void {
        this.#htmlMediaElement.load();
    }

    fastSeek(time: number): void {
        this.#htmlMediaElement.fastSeek(time);
    }

    canPlayType(type: string): "probably" | "maybe" | "" {
        return this.#htmlMediaElement.canPlayType(type);
    }

    // HTMLVideoElement only
    async requestPictureInPicture(): Promise<PictureInPictureWindowAPI> {
        const pictureInPictureWindow = await (<HTMLVideoElement>this.#htmlMediaElement).requestPictureInPicture();
        return new PictureInPictureWindowAPI(pictureInPictureWindow);
    }


    // events


    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean): void {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // Ready

    // error event

    #onerror = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeError", this.#htmlMediaElement.error!.code, this.#htmlMediaElement.error!.message);

    activateOnerror(): void {
        this.#htmlMediaElement.addEventListener("error", this.#onerror);
        if (this.#htmlMediaElement.error !== null)
            this.#onerror();
    }

    deactivateOnerror(): void {
        this.#htmlMediaElement.removeEventListener("error", this.#onerror);
    }


    // canplay event

    #oncanplay = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeCanPlay");

    activateOncanplay(): void {
        this.#htmlMediaElement.addEventListener("canplay", this.#oncanplay);
    }

    deactivateOncanplay(): void {
        this.#htmlMediaElement.removeEventListener("canplay", this.#oncanplay);
    }


    // canplaythrough event

    #oncanplaythrough = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeCanPlayThrough");

    activateOncanplaythrough(): void {
        this.#htmlMediaElement.addEventListener("canplaythrough", this.#oncanplaythrough);
    }

    deactivateOncanplaythrough(): void {
        this.#htmlMediaElement.removeEventListener("canplaythrough", this.#oncanplaythrough);
    }


    // playing event

    #onplaying = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokePlaying");

    activateOnplaying(): void {
        this.#htmlMediaElement.addEventListener("playing", this.#onplaying);
    }

    deactivateOnplaying(): void {
        this.#htmlMediaElement.removeEventListener("playing", this.#onplaying);
    }


    // Data

    // loadstart event

    #onloadstart = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeLoadStart");

    activateOnloadstart(): void {
        this.#htmlMediaElement.addEventListener("loadstart", this.#onloadstart);
    }

    deactivateOnloadstart(): void {
        this.#htmlMediaElement.removeEventListener("loadstart", this.#onloadstart);
    }


    // progress event

    #onprogress = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeProgress");

    activateOnprogress(): void {
        this.#htmlMediaElement.addEventListener("progress", this.#onprogress);
    }

    deactivateOnprogress(): void {
        this.#htmlMediaElement.removeEventListener("progress", this.#onprogress);
    }


    // loadeddata event

    #onloadeddata = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeLoadedData");

    activateOnloadeddata(): void {
        this.#htmlMediaElement.addEventListener("loadeddata", this.#onloadeddata);
    }

    deactivateOnloadeddata(): void {
        this.#htmlMediaElement.removeEventListener("loadeddata", this.#onloadeddata);
    }


    // loadedmetadata event

    #onloadedmetadata = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeLoadedMetadata");

    activateOnloadedmetadata(): void {
        this.#htmlMediaElement.addEventListener("loadedmetadata", this.#onloadedmetadata);
    }

    deactivateOnloadedmetadata(): void {
        this.#htmlMediaElement.removeEventListener("loadedmetadata", this.#onloadedmetadata);
    }


    // stalled event

    #onstalled = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeStalled");

    activateOnstalled(): void {
        this.#htmlMediaElement.addEventListener("stalled", this.#onstalled);
    }

    deactivateOnstalled(): void {
        this.#htmlMediaElement.removeEventListener("stalled", this.#onstalled);
    }


    // suspend event

    #onsuspend = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeSuspend");

    activateOnsuspend(): void {
        this.#htmlMediaElement.addEventListener("suspend", this.#onsuspend);
    }

    deactivateOnsuspend(): void {
        this.#htmlMediaElement.removeEventListener("suspend", this.#onsuspend);
    }


    // waiting event

    #onwaiting = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeWaiting");

    activateOnwaiting(): void {
        this.#htmlMediaElement.addEventListener("waiting", this.#onwaiting);
    }

    deactivateOnwaiting(): void {
        this.#htmlMediaElement.removeEventListener("waiting", this.#onwaiting);
    }


    // abort event

    #onabort = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeAbort");

    activateOnabort(): void {
        this.#htmlMediaElement.addEventListener("abort", this.#onabort);
    }

    deactivateOnabort(): void {
        this.#htmlMediaElement.removeEventListener("abort", this.#onabort);
    }


    // emptied event

    #onemptied = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeEmptied");

    activateOnemptied(): void {
        this.#htmlMediaElement.addEventListener("emptied", this.#onemptied);
    }

    deactivateOnemptied(): void {
        this.#htmlMediaElement.removeEventListener("emptied", this.#onemptied);
    }


    // Timing

    // play event

    #onplay = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokePlay");

    activateOnplay(): void {
        this.#htmlMediaElement.addEventListener("play", this.#onplay);
    }

    deactivateOnplay(): void {
        this.#htmlMediaElement.removeEventListener("play", this.#onplay);
    }


    // pause event

    #onpause = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokePause");

    activateOnpause(): void {
        this.#htmlMediaElement.addEventListener("pause", this.#onpause);
    }

    deactivateOnpause(): void {
        this.#htmlMediaElement.removeEventListener("pause", this.#onpause);
    }


    // ended event

    #onended = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeEnded");

    activateOnended(): void {
        this.#htmlMediaElement.addEventListener("ended", this.#onended);
    }

    deactivateOnended(): void {
        this.#htmlMediaElement.removeEventListener("ended", this.#onended);
    }


    // seeking event

    #onseeking = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeSeeking");

    activateOnseeking(): void {
        this.#htmlMediaElement.addEventListener("seeking", this.#onseeking);
    }

    deactivateOnseeking(): void {
        this.#htmlMediaElement.removeEventListener("seeking", this.#onseeking);
    }


    // seeked event

    #onseeked = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeSeeked");

    activateOnseeked(): void {
        this.#htmlMediaElement.addEventListener("seeked", this.#onseeked);
    }

    deactivateOnseeked(): void {
        this.#htmlMediaElement.removeEventListener("seeked", this.#onseeked);
    }


    // timeupdate event

    #ontimeupdate = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeTimeUpdate");

    activateOntimeupdate(): void {
        this.#htmlMediaElement.addEventListener("timeupdate", this.#ontimeupdate);
    }

    deactivateOntimeupdate(): void {
        this.#htmlMediaElement.removeEventListener("timeupdate", this.#ontimeupdate);
    }


    // Setting

    // volumechange event

    #onvolumechange = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeVolumeChange");

    activateOnvolumechange(): void {
        this.#htmlMediaElement.addEventListener("volumechange", this.#onvolumechange);
    }

    deactivateOnvolumechange(): void {
        this.#htmlMediaElement.removeEventListener("volumechange", this.#onvolumechange);
    }


    // ratechange event

    #onratechange = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeRateChange");

    activateOnratechange(): void {
        this.#htmlMediaElement.addEventListener("ratechange", this.#onratechange);
    }

    deactivateOnratechange(): void {
        this.#htmlMediaElement.removeEventListener("ratechange", this.#onratechange);
    }


    // durationchange event

    #ondurationchange = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeDurationChange");

    activateOndurationchange(): void {
        this.#htmlMediaElement.addEventListener("durationchange", this.#ondurationchange);
    }

    deactivateOndurationchange(): void {
        this.#htmlMediaElement.removeEventListener("durationchange", this.#ondurationchange);
    }


    // Video

    // HTMLMediaElement - resize event

    #onresize = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeResize");

    activateOnresize(): void {
        this.#htmlMediaElement.addEventListener("resize", this.#onresize);
    }

    deactivateOnresize(): void {
        this.#htmlMediaElement.removeEventListener("resize", this.#onresize);
    }


    // HTMLMediaElement - enterpictureinpicture event

    #onenterpictureinpicture = (event: PictureInPictureEvent) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeEnterPictureInPicture", DotNet.createJSObjectReference(event.pictureInPictureWindow));

    activateOnenterpictureinpicture(): void {
        this.#htmlMediaElement.addEventListener("enterpictureinpicture", this.#onenterpictureinpicture);
    }

    deactivateOnenterpictureinpicture(): void {
        this.#htmlMediaElement.removeEventListener("enterpictureinpicture", this.#onenterpictureinpicture);
    }


    // HTMLMediaElement - leavepictureinpicture event

    #onleavepictureinpicture = (event: PictureInPictureEvent) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeLeavePictureInPicture", DotNet.createJSObjectReference(event.pictureInPictureWindow));

    activateOnleavepictureinpicture(): void {
        this.#htmlMediaElement.addEventListener("leavepictureinpicture", this.#onleavepictureinpicture);
    }

    deactivateOnleavepictureinpicture(): void {
        this.#htmlMediaElement.removeEventListener("leavepictureinpicture", this.#onleavepictureinpicture);
    }
}
