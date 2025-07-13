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



    // Properties


    // Attributes

    getSrc(): string {
        return this.#htmlMediaElement.src;
    }

    setSrc(value: string) {
        this.#htmlMediaElement.src = value;
    }

    getSrcObject(): [MediaStreamAPI] | [null] {
        const result = this.#htmlMediaElement.srcObject;
        if (result instanceof MediaStream)
            return [DotNet.createJSObjectReference(new MediaStreamAPI(result))];
        else
            return [null];
    }

    setSrcObject(value: MediaStreamAPI | null) {
        if (value !== null)
            this.#htmlMediaElement.srcObject = value?.getStream();
        else
            this.#htmlMediaElement.srcObject = null;
    }

    getControls(): boolean {
        return this.#htmlMediaElement.controls;
    }

    setControls(value: boolean) {
        this.#htmlMediaElement.controls = value;
    }

    getAutoplay(): boolean {
        return this.#htmlMediaElement.autoplay;
    }

    setAutoplay(value: boolean) {
        this.#htmlMediaElement.autoplay = value;
    }

    getLoop(): boolean {
        return this.#htmlMediaElement.loop;
    }

    setLoop(value: boolean) {
        this.#htmlMediaElement.loop = value;
    }

    getDefaultMuted(): boolean {
        return this.#htmlMediaElement.defaultMuted;
    }

    setDefaultMuted(value: boolean) {
        this.#htmlMediaElement.defaultMuted = value;
    }


    getPreload(): "none" | "metadata" | "auto" | "" {
        return this.#htmlMediaElement.preload;
    }

    setPreload(value: "none" | "metadata" | "auto" | "") {
        this.#htmlMediaElement.preload = value;
    }


    // State

    getCurrentSrc(): string {
        return this.#htmlMediaElement.currentSrc;
    }

    getCurrentTime(): number {
        return this.#htmlMediaElement.currentTime;
    }

    setCurrentTime(value: number) {
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

    setMuted(value: boolean) {
        this.#htmlMediaElement.muted = value;
    }

    getVolume(): number {
        return this.#htmlMediaElement.volume;
    }

    setVolume(value: number) {
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

    setPlaybackRate(value: number) {
        this.#htmlMediaElement.playbackRate = value;
    }

    getDefaultPlaybackRate(): number {
        return this.#htmlMediaElement.defaultPlaybackRate;
    }

    setDefaultPlaybackRate(value: number) {
        this.#htmlMediaElement.defaultPlaybackRate = value;
    }

    getCrossOrigin(): string {
        return this.#htmlMediaElement.crossOrigin ?? "anonymous";
    }

    /** @param value "anonymous" | "use-credentials" */
    setCrossOrigin(value: string) {
        this.#htmlMediaElement.crossOrigin = value;
    }

    getPreservesPitch(): boolean {
        return this.#htmlMediaElement.preservesPitch;
    }

    setPreservesPitch(value: boolean) {
        this.#htmlMediaElement.preservesPitch = value;
    }

    getDisableRemotePlayback(): boolean {
        return this.#htmlMediaElement.disableRemotePlayback;
    }

    setDisableRemotePlayback(value: boolean) {
        this.#htmlMediaElement.disableRemotePlayback = value;
    }



    // Methods

    play(): Promise<void> {
        return this.#htmlMediaElement.play();
    }

    pause() {
        this.#htmlMediaElement.pause();
    }

    load() {
        this.#htmlMediaElement.load();
    }

    fastSeek(time: number) {
        this.#htmlMediaElement.fastSeek(time);
    }

    canPlayType(type: string): "probably" | "maybe" | "" {
        return this.#htmlMediaElement.canPlayType(type);
    }



    // events


    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // Ready

    // error event

    #onerrorCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeError", this.#htmlMediaElement.error!.code, this.#htmlMediaElement.error!.message);

    activateOnerror() {
        this.#htmlMediaElement.addEventListener("error", this.#onerrorCallback);
        if (this.#htmlMediaElement.error !== null)
            this.#onerrorCallback();
    }

    deactivateOnerror() {
        this.#htmlMediaElement.removeEventListener("error", this.#onerrorCallback);
    }


    // canplay event

    #oncanplayCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeCanplay");

    activateOncanplay() {
        this.#htmlMediaElement.addEventListener("canplay", this.#oncanplayCallback);
    }

    deactivateOncanplay() {
        this.#htmlMediaElement.removeEventListener("canplay", this.#oncanplayCallback);
    }


    // canplaythrough event

    #oncanplaythroughCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeCanplaythrough");

    activateOncanplaythrough() {
        this.#htmlMediaElement.addEventListener("canplaythrough", this.#oncanplaythroughCallback);
    }

    deactivateOncanplaythrough() {
        this.#htmlMediaElement.removeEventListener("canplaythrough", this.#oncanplaythroughCallback);
    }


    // playing event

    #onplayingCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokePlaying");

    activateOnplaying() {
        this.#htmlMediaElement.addEventListener("playing", this.#onplayingCallback);
    }

    deactivateOnplaying() {
        this.#htmlMediaElement.removeEventListener("playing", this.#onplayingCallback);
    }


    // Data

    // loadstart event

    #onloadstartCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeLoadstart");

    activateOnloadstart() {
        this.#htmlMediaElement.addEventListener("loadstart", this.#onloadstartCallback);
    }

    deactivateOnloadstart() {
        this.#htmlMediaElement.removeEventListener("loadstart", this.#onloadstartCallback);
    }


    // progress event

    #onprogressCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeProgress");

    activateOnprogress() {
        this.#htmlMediaElement.addEventListener("progress", this.#onprogressCallback);
    }

    deactivateOnprogress() {
        this.#htmlMediaElement.removeEventListener("progress", this.#onprogressCallback);
    }


    // loadeddata event

    #onloadeddataCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeLoadeddata");

    activateOnloadeddata() {
        this.#htmlMediaElement.addEventListener("loadeddata", this.#onloadeddataCallback);
    }

    deactivateOnloadeddata() {
        this.#htmlMediaElement.removeEventListener("loadeddata", this.#onloadeddataCallback);
    }


    // loadedmetadata event

    #onloadedmetadataCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeLoadedmetadata");

    activateOnloadedmetadata() {
        this.#htmlMediaElement.addEventListener("loadedmetadata", this.#onloadedmetadataCallback);
    }

    deactivateOnloadedmetadata() {
        this.#htmlMediaElement.removeEventListener("loadedmetadata", this.#onloadedmetadataCallback);
    }


    // stalled event

    #onstalledCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeStalled");

    activateOnstalled() {
        this.#htmlMediaElement.addEventListener("stalled", this.#onstalledCallback);
    }

    deactivateOnstalled() {
        this.#htmlMediaElement.removeEventListener("stalled", this.#onstalledCallback);
    }


    // suspend event

    #onsuspendCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeSuspend");

    activateOnsuspend() {
        this.#htmlMediaElement.addEventListener("suspend", this.#onsuspendCallback);
    }

    deactivateOnsuspend() {
        this.#htmlMediaElement.removeEventListener("suspend", this.#onsuspendCallback);
    }


    // waiting event

    #onwaitingCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeWaiting");

    activateOnwaiting() {
        this.#htmlMediaElement.addEventListener("waiting", this.#onwaitingCallback);
    }

    deactivateOnwaiting() {
        this.#htmlMediaElement.removeEventListener("waiting", this.#onwaitingCallback);
    }


    // abort event

    #onabortCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeAbort");

    activateOnabort() {
        this.#htmlMediaElement.addEventListener("abort", this.#onabortCallback);
    }

    deactivateOnabort() {
        this.#htmlMediaElement.removeEventListener("abort", this.#onabortCallback);
    }


    // emptied event

    #onemptiedCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeEmptied");

    activateOnemptied() {
        this.#htmlMediaElement.addEventListener("emptied", this.#onemptiedCallback);
    }

    deactivateOnemptied() {
        this.#htmlMediaElement.removeEventListener("emptied", this.#onemptiedCallback);
    }


    // Timing

    // play event

    #onplayCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokePlay");

    activateOnplay() {
        this.#htmlMediaElement.addEventListener("play", this.#onplayCallback);
    }

    deactivateOnplay() {
        this.#htmlMediaElement.removeEventListener("play", this.#onplayCallback);
    }


    // pause event

    #onpauseCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokePause");

    activateOnpause() {
        this.#htmlMediaElement.addEventListener("pause", this.#onpauseCallback);
    }

    deactivateOnpause() {
        this.#htmlMediaElement.removeEventListener("pause", this.#onpauseCallback);
    }


    // ended event

    #onendedCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeEnded");

    activateOnended() {
        this.#htmlMediaElement.addEventListener("ended", this.#onendedCallback);
    }

    deactivateOnended() {
        this.#htmlMediaElement.removeEventListener("ended", this.#onendedCallback);
    }


    // seeking event

    #onseekingCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeSeeking");

    activateOnseeking() {
        this.#htmlMediaElement.addEventListener("seeking", this.#onseekingCallback);
    }

    deactivateOnseeking() {
        this.#htmlMediaElement.removeEventListener("seeking", this.#onseekingCallback);
    }


    // seeked event

    #onseekedCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeSeeked");

    activateOnseeked() {
        this.#htmlMediaElement.addEventListener("seeked", this.#onseekedCallback);
    }

    deactivateOnseeked() {
        this.#htmlMediaElement.removeEventListener("seeked", this.#onseekedCallback);
    }


    // timeupdate event

    #ontimeupdateCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeTimeupdate");

    activateOntimeupdate() {
        this.#htmlMediaElement.addEventListener("timeupdate", this.#ontimeupdateCallback);
    }

    deactivateOntimeupdate() {
        this.#htmlMediaElement.removeEventListener("timeupdate", this.#ontimeupdateCallback);
    }


    // Setting

    // volumechange event

    #onvolumechangeCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeVolumechange");

    activateOnvolumechange() {
        this.#htmlMediaElement.addEventListener("volumechange", this.#onvolumechangeCallback);
    }

    deactivateOnvolumechange() {
        this.#htmlMediaElement.removeEventListener("volumechange", this.#onvolumechangeCallback);
    }


    // ratechange event

    #onratechangeCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeRatechange");

    activateOnratechange() {
        this.#htmlMediaElement.addEventListener("ratechange", this.#onratechangeCallback);
    }

    deactivateOnratechange() {
        this.#htmlMediaElement.removeEventListener("ratechange", this.#onratechangeCallback);
    }


    // durationchange event

    #ondurationchangeCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeDurationchange");

    activateOndurationchange() {
        this.#htmlMediaElement.addEventListener("durationchange", this.#ondurationchangeCallback);
    }

    deactivateOndurationchange() {
        this.#htmlMediaElement.removeEventListener("durationchange", this.#ondurationchangeCallback);
    }



    static #toTimeRangeArray(timeRanges: TimeRanges) {
        let result = [];

        for (let i = 0; i < timeRanges.length; i++)
            result.push({ start: timeRanges.start(i), end: timeRanges.end(i) });

        return result;
    }
}
