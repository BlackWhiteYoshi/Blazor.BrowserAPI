import { MediaStreamWrapper, createMediaStream } from "../MediaDevices/MediaStream/MediaStream";


/**
 * @param {HTMLMediaElement} htmlMediaElement
 * @returns {HTMLMediaElementWrapper}
 */
export function createHTMLMediaElement(htmlMediaElement) {
    return new HTMLMediaElementWrapper(htmlMediaElement);
}


export class HTMLMediaElementWrapper {
    /** @type {HTMLMediaElement} */
    #htmlMediaElement;

    /**
     * @param {HTMLMediaElement} htmlMediaElement
     */
    constructor(htmlMediaElement) {
        this.#htmlMediaElement = htmlMediaElement;
    }

    /**
     * @param {TimeRanges} timeRanges
     */
    static #toTimeRangeArray(timeRanges) {
        let result = [];

        for (let i = 0; i < timeRanges.length; i++)
            result.push({ start: timeRanges.start(i), end: timeRanges.end(i) });

        return result;
    }



    /**
     * Properties
     **/

    // Attributes

    /**
     * @returns {string}
     */
    getSrc() {
        return this.#htmlMediaElement.src;
    }
    /**
     * @param {string} value
     */
    setSrc(value) {
        this.#htmlMediaElement.src = value;
    }

    /**
     * @returns {MediaStreamWrapper | null}
     */
    getSrcObject() {
        const result = this.#htmlMediaElement.srcObject;
        if (result instanceof MediaStream)
            return new MediaStreamWrapper(result);
        else
            return null;
    }
    /**
     * @param {MediaStreamWrapper | null} value
     */
    setSrcObject(value) {
        if (value !== null)
            this.#htmlMediaElement.srcObject = value.getStream();
        else
            this.#htmlMediaElement.srcObject = value;
    }

    /**
     * @returns {boolean}
     */
    getControls() {
        return this.#htmlMediaElement.controls;
    }
    /**
     * @param {boolean} value
     */
    setControls(value) {
        this.#htmlMediaElement.controls = value;
    }

    /**
     * @returns {boolean}
     */
    getAutoplay() {
        return this.#htmlMediaElement.autoplay;
    }
    /**
     * @param {boolean} value
     */
    setAutoplay(value) {
        this.#htmlMediaElement.autoplay = value;
    }

    /**
     * @returns {boolean}
     */
    getLoop() {
        return this.#htmlMediaElement.loop;
    }
    /**
     *  @param {boolean} value
     */
    setLoop(value) {
        this.#htmlMediaElement.loop = value;
    }

    /**
     * @returns {boolean}
     */
    getDefaultMuted() {
        return this.#htmlMediaElement.defaultMuted;
    }
    /**
     *  @param {boolean} value
     */
    setDefaultMuted(value) {
        this.#htmlMediaElement.defaultMuted = value;
    }

    /**
     * @returns {string}
     */
    getPreload() {
        return this.#htmlMediaElement.preload;
    }
    /**
     * @param {"none" | "metadata" | "auto" | ""} value
     */
    setPreload(value) {
        this.#htmlMediaElement.preload = value;
    }


    // State

    /**
     * @returns {string}
     */
    getCurrentSrc() {
        return this.#htmlMediaElement.currentSrc;
    }

    /**
     * @returns {number}
     */
    getCurrentTime() {
        return this.#htmlMediaElement.currentTime;
    }
    /**
     *  @param {number} value
     */
    setCurrentTime(value) {
        this.#htmlMediaElement.currentTime = value;
    }

    /**
     * @returns {number}
     */
    getDuration() {
        return this.#htmlMediaElement.duration;
    }

    /**
     * TimeRanges
     * @returns {{ start: number, end: number }[]}
     */
    getSeekable() {
        return HTMLMediaElementWrapper.#toTimeRangeArray(this.#htmlMediaElement.seekable);
    }

    /**
     * @returns {boolean}
     */
    getMuted() {
        return this.#htmlMediaElement.muted;
    }
    /**
     *  @param {boolean} value
     */
    setMuted(value) {
        this.#htmlMediaElement.muted = value;
    }

    /**
     * @returns {number}
     */
    getVolume() {
        return this.#htmlMediaElement.volume;
    }
    /**
     * @param {number} value
     */
    setVolume(value) {
        this.#htmlMediaElement.volume = value;
    }

    /**
     * @returns {boolean}
     */
    getPaused() {
        return this.#htmlMediaElement.paused;
    }

    /**
     * @returns {boolean}
     */
    getEnded() {
        return this.#htmlMediaElement.ended;
    }

    /**
     * @returns {boolean}
     */
    getSeeking() {
        return this.#htmlMediaElement.seeking;
    }

    /**
     * @returns {number} // 0 = HAVE_NOTHING, 1 = HAVE_METADATA, 2 = HAVE_CURRENT_DATA, 3 = HAVE_FUTURE_DATA, 4 = HAVE_ENOUGH_DATA
     */
    getReadyState() {
        return this.#htmlMediaElement.readyState;
    }

    /**
     * @returns {number} // 0 = NETWORK_EMPTY, 1 = NETWORK_IDLE, 2 = NETWORK_LOADING or 3 = NETWORK_NO_SOURCE
     */
    getNetworkState() {
        return this.#htmlMediaElement.networkState;
    }

    /**
     * TimeRanges
     * @returns {{ start: number, end: number }[]}
     */
    getBuffered() {
        return HTMLMediaElementWrapper.#toTimeRangeArray(this.#htmlMediaElement.buffered);
    }

    /**
     * TimeRanges
     * @returns {{ start: number, end: number }[]}
     */
    getPlayed() {
        return HTMLMediaElementWrapper.#toTimeRangeArray(this.#htmlMediaElement.played);
    }


    // Settings

    /**
     * @returns {number}
     */
    getPlaybackRate() {
        return this.#htmlMediaElement.playbackRate;
    }
    /**
     * @param {number} value
     */
    setPlaybackRate(value) {
        this.#htmlMediaElement.playbackRate = value;
    }

    /**
     * @returns {number}
     */
    getDefaultPlaybackRate() {
        return this.#htmlMediaElement.defaultPlaybackRate;
    }
    /**
     *  @param {number} value
     */
    setDefaultPlaybackRate(value) {
        this.#htmlMediaElement.defaultPlaybackRate = value;
    }

    /**
     * @returns {string}
     */
    getCrossOrigin() {
        return this.#htmlMediaElement.crossOrigin ?? "anonymous";
    }
    /**
     * @param {string} value // "anonymous" | "use-credentials"
     */
    setCrossOrigin(value) {
        this.#htmlMediaElement.crossOrigin = value;
    }

    /**
     * @returns {boolean}
     */
    getPreservesPitch() {
        return this.#htmlMediaElement.preservesPitch;
    }
    /**
     * @param {boolean} value
     */
    setPreservesPitch(value) {
        this.#htmlMediaElement.preservesPitch = value;
    }

    /**
     * @returns {boolean}
     */
    getDisableRemotePlayback() {
        return this.#htmlMediaElement.disableRemotePlayback;
    }
    /**
     *  @param {boolean} value
     */
    setDisableRemotePlayback(value) {
        this.#htmlMediaElement.disableRemotePlayback = value;
    }



    /**
     * Methods
     **/

    /**
     * @returns {Promise<void>}
     */
    play() {
        return this.#htmlMediaElement.play();
    }

    /**
     */
    pause() {
        this.#htmlMediaElement.pause();
    }

    /**
     */
    load() {
        this.#htmlMediaElement.load();
    }

    /**
     * @param {number} time
     */
    fastSeek(time) {
        this.#htmlMediaElement.fastSeek(time);
    }

    /**
     * @param {string} type
     * @returns {"probably" | "maybe" | ""}
     */
    canPlayType(type) {
        return this.#htmlMediaElement.canPlayType(type);
    }



    /**
     * Events
     **/

    /** @type {import("../../blazor").DotNet.DotNetObject} */
    #eventTrigger;


    // Ready

    // #region error event

    /**
     */
    #onerrorCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeError", /** @type {MediaError} */(this.#htmlMediaElement.error).code, /** @type {MediaError} */(this.#htmlMediaElement.error).message);

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnerror(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("error", this.#onerrorCallback);
        if (this.#htmlMediaElement.error !== null)
            this.#onerrorCallback();
    }

    /**
     */
    deactivateOnerror() {
        this.#htmlMediaElement.removeEventListener("error", this.#onerrorCallback);
    }

    // #endregion


    // #region canplay event

    /**
     */
    #oncanplayCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeCanplay");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOncanplay(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("canplay", this.#oncanplayCallback);
    }

    /**
     */
    deactivateOncanplay() {
        this.#htmlMediaElement.removeEventListener("canplay", this.#oncanplayCallback);
    }

    // #endregion


    // #region canplaythrough event

    /**
     */
    #oncanplaythroughCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeCanplaythrough");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOncanplaythrough(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("canplaythrough", this.#oncanplaythroughCallback);
    }

    /**
     */
    deactivateOncanplaythrough() {
        this.#htmlMediaElement.removeEventListener("canplaythrough", this.#oncanplaythroughCallback);
    }

    // #endregion


    // #region playing event

    /**
     */
    #onplayingCallback = () => this.#eventTrigger.invokeMethodAsync("InvokePlaying");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnplaying(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("playing", this.#onplayingCallback);
    }

    /**
     */
    deactivateOnplaying() {
        this.#htmlMediaElement.removeEventListener("playing", this.#onplayingCallback);
    }

    // #endregion


    // Data

    // #region loadstart event

    /**
     */
    #onloadstartCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeLoadstart");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnloadstart(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("loadstart", this.#onloadstartCallback);
    }

    /**
     */
    deactivateOnloadstart() {
        this.#htmlMediaElement.removeEventListener("loadstart", this.#onloadstartCallback);
    }

    // #endregion


    // #region progress event

    /**
     */
    #onprogressCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeProgress");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnprogress(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("progress", this.#onprogressCallback);
    }

    /**
     */
    deactivateOnprogress() {
        this.#htmlMediaElement.removeEventListener("progress", this.#onprogressCallback);
    }

    // #endregion


    // #region loadeddata event

    /**
     */
    #onloadeddataCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeLoadeddata");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnloadeddata(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("loadeddata", this.#onloadeddataCallback);
    }

    /**
     */
    deactivateOnloadeddata() {
        this.#htmlMediaElement.removeEventListener("loadeddata", this.#onloadeddataCallback);
    }

    // #endregion


    // #region loadedmetadata event

    /**
     */
    #onloadedmetadataCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeLoadedmetadata");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnloadedmetadata(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("loadedmetadata", this.#onloadedmetadataCallback);
    }

    /**
     */
    deactivateOnloadedmetadata() {
        this.#htmlMediaElement.removeEventListener("loadedmetadata", this.#onloadedmetadataCallback);
    }

    // #endregion


    // #region stalled event

    /**
     */
    #onstalledCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeStalled");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnstalled(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("stalled", this.#onstalledCallback);
    }

    /**
     */
    deactivateOnstalled() {
        this.#htmlMediaElement.removeEventListener("stalled", this.#onstalledCallback);
    }

    // #endregion


    // #region suspend event

    /**
     */
    #onsuspendCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeSuspend");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnsuspend(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("suspend", this.#onsuspendCallback);
    }

    /**
     */
    deactivateOnsuspend() {
        this.#htmlMediaElement.removeEventListener("suspend", this.#onsuspendCallback);
    }

    // #endregion


    // #region waiting event

    /**
     */
    #onwaitingCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeWaiting");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnwaiting(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("waiting", this.#onwaitingCallback);
    }

    /**
     */
    deactivateOnwaiting() {
        this.#htmlMediaElement.removeEventListener("waiting", this.#onwaitingCallback);
    }

    // #endregion


    // #region abort event

    /**
     */
    #onabortCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeAbort");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnabort(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("abort", this.#onabortCallback);
    }

    /**
     */
    deactivateOnabort() {
        this.#htmlMediaElement.removeEventListener("abort", this.#onabortCallback);
    }

    // #endregion


    // #region emptied event

    /**
     */
    #onemptiedCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeEmptied");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnemptied(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("emptied", this.#onemptiedCallback);
    }

    /**
     */
    deactivateOnemptied() {
        this.#htmlMediaElement.removeEventListener("emptied", this.#onemptiedCallback);
    }

    // #endregion


    // Timing

    // #region play event

    /**
     */
    #onplayCallback = () => this.#eventTrigger.invokeMethodAsync("InvokePlay");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnplay(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("play", this.#onplayCallback);
    }

    /**
     */
    deactivateOnplay() {
        this.#htmlMediaElement.removeEventListener("play", this.#onplayCallback);
    }

    // #endregion


    // #region pause event

    /**
     */
    #onpauseCallback = () => this.#eventTrigger.invokeMethodAsync("InvokePause");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnpause(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("pause", this.#onpauseCallback);
    }

    /**
     */
    deactivateOnpause() {
        this.#htmlMediaElement.removeEventListener("pause", this.#onpauseCallback);
    }

    // #endregion


    // #region ended event

    /**
     */
    #onendedCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeEnded");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnended(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("ended", this.#onendedCallback);
    }

    /**
     */
    deactivateOnended() {
        this.#htmlMediaElement.removeEventListener("ended", this.#onendedCallback);
    }

    // #endregion


    // #region seeking event

    /**
     */
    #onseekingCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeSeeking");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnseeking(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("seeking", this.#onseekingCallback);
    }

    /**
     */
    deactivateOnseeking() {
        this.#htmlMediaElement.removeEventListener("seeking", this.#onseekingCallback);
    }

    // #endregion


    // #region seeked event

    /**
     */
    #onseekedCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeSeeked");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnseeked(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("seeked", this.#onseekedCallback);
    }

    /**
     */
    deactivateOnseeked() {
        this.#htmlMediaElement.removeEventListener("seeked", this.#onseekedCallback);
    }

    // #endregion


    // #region timeupdate event

    /**
     */
    #ontimeupdateCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeTimeupdate");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOntimeupdate(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("timeupdate", this.#ontimeupdateCallback);
    }

    /**
     */
    deactivateOntimeupdate() {
        this.#htmlMediaElement.removeEventListener("timeupdate", this.#ontimeupdateCallback);
    }

    // #endregion


    // Setting

    // #region volumechange event

    /**
     */
    #onvolumechangeCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeVolumechange");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnvolumechange(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("volumechange", this.#onvolumechangeCallback);
    }

    /**
     */
    deactivateOnvolumechange() {
        this.#htmlMediaElement.removeEventListener("volumechange", this.#onvolumechangeCallback);
    }

    // #endregion


    // #region ratechange event

    /**
     */
    #onratechangeCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeRatechange");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnratechange(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("ratechange", this.#onratechangeCallback);
    }

    /**
     */
    deactivateOnratechange() {
        this.#htmlMediaElement.removeEventListener("ratechange", this.#onratechangeCallback);
    }

    // #endregion


    // #region durationchange event

    /**
     */
    #ondurationchangeCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeDurationchange");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOndurationchange(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#htmlMediaElement.addEventListener("durationchange", this.#ondurationchangeCallback);
    }

    /**
     */
    deactivateOndurationchange() {
        this.#htmlMediaElement.removeEventListener("durationchange", this.#ondurationchangeCallback);
    }

    // #endregion
}
