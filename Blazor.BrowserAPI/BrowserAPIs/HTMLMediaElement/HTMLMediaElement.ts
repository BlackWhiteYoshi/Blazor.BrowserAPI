import { DotNet } from "../../blazor";
import { MediaStreamAPI } from "../MediaDevices/MediaStream/MediaStream";

export class HTMLMediaElementAPI {
    #htmlMediaElement: HTMLMediaElement;

    constructor(htmlMediaElement: HTMLMediaElement) {
        this.#htmlMediaElement = htmlMediaElement;
    }

    static create(htmlMediaElement: HTMLMediaElement): HTMLMediaElementAPI {
        return new HTMLMediaElementAPI(htmlMediaElement);
    }


    /**
     * Properties
     **/

    // Attributes

    getSrc(): string {
        return this.#htmlMediaElement.src;
    }

    setSrc(value: string) {
        this.#htmlMediaElement.src = value;
    }

    getSrcObject(): MediaStreamAPI | null {
        const result = this.#htmlMediaElement.srcObject;
        if (result instanceof MediaStream)
            return new MediaStreamAPI(result);
        else
            return null;
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



    /**
     * Methods
     **/

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



    /**
     * Events
     **/

    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;


    // Ready

    // #region error event

    #onerrorCallback = () => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeError", this.#htmlMediaElement.error!.code, this.#htmlMediaElement.error!.message)
        : this.#eventTrigger.invokeMethodAsync("InvokeError", this.#htmlMediaElement.error!.code, this.#htmlMediaElement.error!.message);

    activateOnerror(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("error", this.#onerrorCallback);
        if (this.#htmlMediaElement.error !== null)
            this.#onerrorCallback();
    }

    deactivateOnerror() {
        this.#htmlMediaElement.removeEventListener("error", this.#onerrorCallback);
    }

    // #endregion


    // #region canplay event

    #oncanplayCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeCanplay") : this.#eventTrigger.invokeMethodAsync("InvokeCanplay");

    activateOncanplay(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("canplay", this.#oncanplayCallback);
    }

    deactivateOncanplay() {
        this.#htmlMediaElement.removeEventListener("canplay", this.#oncanplayCallback);
    }

    // #endregion


    // #region canplaythrough event

    #oncanplaythroughCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeCanplaythrough") : this.#eventTrigger.invokeMethodAsync("InvokeCanplaythrough");

    activateOncanplaythrough(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("canplaythrough", this.#oncanplaythroughCallback);
    }

    deactivateOncanplaythrough() {
        this.#htmlMediaElement.removeEventListener("canplaythrough", this.#oncanplaythroughCallback);
    }

    // #endregion


    // #region playing event

    #onplayingCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokePlaying") : this.#eventTrigger.invokeMethodAsync("InvokePlaying");

    activateOnplaying(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("playing", this.#onplayingCallback);
    }

    deactivateOnplaying() {
        this.#htmlMediaElement.removeEventListener("playing", this.#onplayingCallback);
    }

    // #endregion


    // Data

    // #region loadstart event

    #onloadstartCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeLoadstart") : this.#eventTrigger.invokeMethodAsync("InvokeLoadstart");

    activateOnloadstart(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("loadstart", this.#onloadstartCallback);
    }

    deactivateOnloadstart() {
        this.#htmlMediaElement.removeEventListener("loadstart", this.#onloadstartCallback);
    }

    // #endregion


    // #region progress event

    #onprogressCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeProgress") : this.#eventTrigger.invokeMethodAsync("InvokeProgress");

    activateOnprogress(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("progress", this.#onprogressCallback);
    }

    deactivateOnprogress() {
        this.#htmlMediaElement.removeEventListener("progress", this.#onprogressCallback);
    }

    // #endregion


    // #region loadeddata event

    #onloadeddataCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeLoadeddata") : this.#eventTrigger.invokeMethodAsync("InvokeLoadeddata");

    activateOnloadeddata(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("loadeddata", this.#onloadeddataCallback);
    }

    deactivateOnloadeddata() {
        this.#htmlMediaElement.removeEventListener("loadeddata", this.#onloadeddataCallback);
    }

    // #endregion


    // #region loadedmetadata event

    #onloadedmetadataCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeLoadedmetadata") : this.#eventTrigger.invokeMethodAsync("InvokeLoadedmetadata");

    activateOnloadedmetadata(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("loadedmetadata", this.#onloadedmetadataCallback);
    }

    deactivateOnloadedmetadata() {
        this.#htmlMediaElement.removeEventListener("loadedmetadata", this.#onloadedmetadataCallback);
    }

    // #endregion


    // #region stalled event

    #onstalledCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeStalled") : this.#eventTrigger.invokeMethodAsync("InvokeStalled");

    activateOnstalled(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("stalled", this.#onstalledCallback);
    }

    deactivateOnstalled() {
        this.#htmlMediaElement.removeEventListener("stalled", this.#onstalledCallback);
    }

    // #endregion


    // #region suspend event

    #onsuspendCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeSuspend") : this.#eventTrigger.invokeMethodAsync("InvokeSuspend");

    activateOnsuspend(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("suspend", this.#onsuspendCallback);
    }

    deactivateOnsuspend() {
        this.#htmlMediaElement.removeEventListener("suspend", this.#onsuspendCallback);
    }

    // #endregion


    // #region waiting event

    #onwaitingCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeWaiting") : this.#eventTrigger.invokeMethodAsync("InvokeWaiting");

    activateOnwaiting(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("waiting", this.#onwaitingCallback);
    }

    deactivateOnwaiting() {
        this.#htmlMediaElement.removeEventListener("waiting", this.#onwaitingCallback);
    }

    // #endregion


    // #region abort event

    #onabortCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeAbort") : this.#eventTrigger.invokeMethodAsync("InvokeAbort");

    activateOnabort(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("abort", this.#onabortCallback);
    }

    deactivateOnabort() {
        this.#htmlMediaElement.removeEventListener("abort", this.#onabortCallback);
    }

    // #endregion


    // #region emptied event

    #onemptiedCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeEmptied") : this.#eventTrigger.invokeMethodAsync("InvokeEmptied");

    activateOnemptied(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("emptied", this.#onemptiedCallback);
    }

    deactivateOnemptied() {
        this.#htmlMediaElement.removeEventListener("emptied", this.#onemptiedCallback);
    }

    // #endregion


    // Timing

    // #region play event

    #onplayCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokePlay") : this.#eventTrigger.invokeMethodAsync("InvokePlay");

    activateOnplay(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("play", this.#onplayCallback);
    }

    deactivateOnplay() {
        this.#htmlMediaElement.removeEventListener("play", this.#onplayCallback);
    }

    // #endregion


    // #region pause event

    #onpauseCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokePause") : this.#eventTrigger.invokeMethodAsync("InvokePause");

    activateOnpause(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("pause", this.#onpauseCallback);
    }

    deactivateOnpause() {
        this.#htmlMediaElement.removeEventListener("pause", this.#onpauseCallback);
    }

    // #endregion


    // #region ended event

    #onendedCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeEnded") : this.#eventTrigger.invokeMethodAsync("InvokeEnded");

    activateOnended(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("ended", this.#onendedCallback);
    }

    deactivateOnended() {
        this.#htmlMediaElement.removeEventListener("ended", this.#onendedCallback);
    }

    // #endregion


    // #region seeking event

    #onseekingCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeSeeking") : this.#eventTrigger.invokeMethodAsync("InvokeSeeking");

    activateOnseeking(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("seeking", this.#onseekingCallback);
    }

    deactivateOnseeking() {
        this.#htmlMediaElement.removeEventListener("seeking", this.#onseekingCallback);
    }

    // #endregion


    // #region seeked event

    #onseekedCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeSeeked") : this.#eventTrigger.invokeMethodAsync("InvokeSeeked");

    activateOnseeked(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("seeked", this.#onseekedCallback);
    }

    deactivateOnseeked() {
        this.#htmlMediaElement.removeEventListener("seeked", this.#onseekedCallback);
    }

    // #endregion


    // #region timeupdate event

    #ontimeupdateCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeTimeupdate") : this.#eventTrigger.invokeMethodAsync("InvokeTimeupdate");

    activateOntimeupdate(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("timeupdate", this.#ontimeupdateCallback);
    }

    deactivateOntimeupdate() {
        this.#htmlMediaElement.removeEventListener("timeupdate", this.#ontimeupdateCallback);
    }

    // #endregion


    // Setting

    // #region volumechange event

    #onvolumechangeCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeVolumechange") : this.#eventTrigger.invokeMethodAsync("InvokeVolumechange");

    activateOnvolumechange(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("volumechange", this.#onvolumechangeCallback);
    }

    deactivateOnvolumechange() {
        this.#htmlMediaElement.removeEventListener("volumechange", this.#onvolumechangeCallback);
    }

    // #endregion


    // #region ratechange event

    #onratechangeCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeRatechange") : this.#eventTrigger.invokeMethodAsync("InvokeRatechange");

    activateOnratechange(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("ratechange", this.#onratechangeCallback);
    }

    deactivateOnratechange() {
        this.#htmlMediaElement.removeEventListener("ratechange", this.#onratechangeCallback);
    }

    // #endregion


    // #region durationchange event

    #ondurationchangeCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeDurationchange") : this.#eventTrigger.invokeMethodAsync("InvokeDurationchange");

    activateOndurationchange(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlMediaElement.addEventListener("durationchange", this.#ondurationchangeCallback);
    }

    deactivateOndurationchange() {
        this.#htmlMediaElement.removeEventListener("durationchange", this.#ondurationchangeCallback);
    }

    // #endregion



    static #toTimeRangeArray(timeRanges: TimeRanges) {
        let result = [];

        for (let i = 0; i < timeRanges.length; i++)
            result.push({ start: timeRanges.start(i), end: timeRanges.end(i) });

        return result;
    }
}
