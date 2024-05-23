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

    // Ready

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnerror(eventTrigger) {
        this.#htmlMediaElement.onerror = () => eventTrigger.invokeMethodAsync("InvokeError", /** @type {MediaError} */(this.#htmlMediaElement.error).code, /** @type {MediaError} */(this.#htmlMediaElement.error).message);
        if (this.#htmlMediaElement.error !== null)
            eventTrigger.invokeMethodAsync("InvokeError", this.#htmlMediaElement.error.code, this.#htmlMediaElement.error.message);
    }
    /**
     */
    deactivateOnerror() {
        this.#htmlMediaElement.onerror = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOncanplay(eventTrigger) {
        this.#htmlMediaElement.oncanplay = () => eventTrigger.invokeMethodAsync("InvokeCanplay");
    }
    /**
     */
    deactivateOncanplay() {
        this.#htmlMediaElement.oncanplay = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOncanplaythrough(eventTrigger) {
        this.#htmlMediaElement.oncanplaythrough = () => eventTrigger.invokeMethodAsync("InvokeCanplaythrough");
    }
    /**
     */
    deactivateOncanplaythrough() {
        this.#htmlMediaElement.oncanplaythrough = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnplaying(eventTrigger) {
        this.#htmlMediaElement.onplaying = () => eventTrigger.invokeMethodAsync("InvokePlaying");
    }
    /**
     */
    deactivateOnplaying() {
        this.#htmlMediaElement.onplaying = null;
    }


    // Data

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnloadstart(eventTrigger) {
        this.#htmlMediaElement.onloadstart = () => eventTrigger.invokeMethodAsync("InvokeLoadstart");
    }
    /**
     */
    deactivateOnloadstart() {
        this.#htmlMediaElement.onloadstart = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnprogress(eventTrigger) {
        this.#htmlMediaElement.onprogress = () => eventTrigger.invokeMethodAsync("InvokeProgress");
    }
    /**
     */
    deactivateOnprogress() {
        this.#htmlMediaElement.onprogress = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnloadeddata(eventTrigger) {
        this.#htmlMediaElement.onloadeddata = () => eventTrigger.invokeMethodAsync("InvokeLoadeddata");
    }
    /**
     */
    deactivateOnloadeddata() {
        this.#htmlMediaElement.onloadeddata = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnloadedmetadata(eventTrigger) {
        this.#htmlMediaElement.onloadedmetadata = () => eventTrigger.invokeMethodAsync("InvokeLoadedmetadata");
    }
    /**
     */
    deactivateOnloadedmetadata() {
        this.#htmlMediaElement.onloadedmetadata = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnstalled(eventTrigger) {
        this.#htmlMediaElement.onstalled = () => eventTrigger.invokeMethodAsync("InvokeStalled");
    }
    /**
     */
    deactivateOnstalled() {
        this.#htmlMediaElement.onstalled = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnsuspend(eventTrigger) {
        this.#htmlMediaElement.onsuspend = () => eventTrigger.invokeMethodAsync("InvokeSuspend");
    }
    /**
     */
    deactivateOnsuspend() {
        this.#htmlMediaElement.onsuspend = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnwaiting(eventTrigger) {
        this.#htmlMediaElement.onwaiting = () => eventTrigger.invokeMethodAsync("InvokeWaiting");
    }
    /**
     */
    deactivateOnwaiting() {
        this.#htmlMediaElement.onwaiting = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnabort(eventTrigger) {
        this.#htmlMediaElement.onabort = () => eventTrigger.invokeMethodAsync("InvokeAbort");
    }
    /**
     */
    deactivateOnabort() {
        this.#htmlMediaElement.onabort = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnemptied(eventTrigger) {
        this.#htmlMediaElement.onemptied = () => eventTrigger.invokeMethodAsync("InvokeEmptied");
    }
    /**
     */
    deactivateOnemptied() {
        this.#htmlMediaElement.onemptied = null;
    }


    // Timing

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnplay(eventTrigger) {
        this.#htmlMediaElement.onplay = () => eventTrigger.invokeMethodAsync("InvokePlay");
    }
    /**
     */
    deactivateOnplay() {
        this.#htmlMediaElement.onplay = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnpause(eventTrigger) {
        this.#htmlMediaElement.onpause = () => eventTrigger.invokeMethodAsync("InvokePause");
    }
    /**
     */
    deactivateOnpause() {
        this.#htmlMediaElement.onpause = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnended(eventTrigger) {
        this.#htmlMediaElement.onended = () => eventTrigger.invokeMethodAsync("InvokeEnded");
    }
    /**
     */
    deactivateOnended() {
        this.#htmlMediaElement.onended = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnseeking(eventTrigger) {
        this.#htmlMediaElement.onseeking = () => eventTrigger.invokeMethodAsync("InvokeSeeking");
    }
    /**
     */
    deactivateOnseeking() {
        this.#htmlMediaElement.onseeking = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnseeked(eventTrigger) {
        this.#htmlMediaElement.onseeked = () => eventTrigger.invokeMethodAsync("InvokeSeeked");
    }
    /**
     */
    deactivateOnseeked() {
        this.#htmlMediaElement.onseeked = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOntimeupdate(eventTrigger) {
        this.#htmlMediaElement.ontimeupdate = () => eventTrigger.invokeMethodAsync("InvokeTimeupdate");
    }
    /**
     */
    deactivateOntimeupdate() {
        this.#htmlMediaElement.ontimeupdate = null;
    }


    // Setting

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnvolumechange(eventTrigger) {
        this.#htmlMediaElement.onvolumechange = () => eventTrigger.invokeMethodAsync("InvokeVolumechange");
    }
    /**
     */
    deactivateOnvolumechange() {
        this.#htmlMediaElement.onvolumechange = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnratechange(eventTrigger) {
        this.#htmlMediaElement.onratechange = () => eventTrigger.invokeMethodAsync("InvokeRatechange");
    }
    /**
     */
    deactivateOnratechange() {
        this.#htmlMediaElement.onratechange = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOndurationchange(eventTrigger) {
        this.#htmlMediaElement.ondurationchange = () => eventTrigger.invokeMethodAsync("InvokeDurationchange");
    }
    /**
     */
    deactivateOndurationchange() {
        this.#htmlMediaElement.ondurationchange = null;
    }
}
