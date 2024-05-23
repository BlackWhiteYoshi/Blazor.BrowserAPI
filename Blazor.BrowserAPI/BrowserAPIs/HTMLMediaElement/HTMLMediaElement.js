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
     * @param {import("../../blazor").DotNet.DotNetObject} errorTrigger
     */
    activateOnerror(errorTrigger) {
        this.#htmlMediaElement.onerror = () => errorTrigger.invokeMethodAsync("Trigger", /** @type {MediaError} */(this.#htmlMediaElement.error).code, /** @type {MediaError} */(this.#htmlMediaElement.error).message);
        if (this.#htmlMediaElement.error !== null)
            errorTrigger.invokeMethodAsync("Trigger", this.#htmlMediaElement.error.code, this.#htmlMediaElement.error.message);
    }
    /**
     */
    deactivateOnerror() {
        this.#htmlMediaElement.onerror = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} canplayTrigger
     */
    activateOncanplay(canplayTrigger) {
        this.#htmlMediaElement.oncanplay = () => canplayTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOncanplay() {
        this.#htmlMediaElement.oncanplay = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} canplaythroughTrigger
     */
    activateOncanplaythrough(canplaythroughTrigger) {
        this.#htmlMediaElement.oncanplaythrough = () => canplaythroughTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOncanplaythrough() {
        this.#htmlMediaElement.oncanplaythrough = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} playingTrigger
     */
    activateOnplaying(playingTrigger) {
        this.#htmlMediaElement.onplaying = () => playingTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnplaying() {
        this.#htmlMediaElement.onplaying = null;
    }


    // Data

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} loadstartTrigger
     */
    activateOnloadstart(loadstartTrigger) {
        this.#htmlMediaElement.onloadstart = () => loadstartTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnloadstart() {
        this.#htmlMediaElement.onloadstart = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} progressTrigger
     */
    activateOnprogress(progressTrigger) {
        this.#htmlMediaElement.onprogress = () => progressTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnprogress() {
        this.#htmlMediaElement.onprogress = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} loadeddataTrigger
     */
    activateOnloadeddata(loadeddataTrigger) {
        this.#htmlMediaElement.onloadeddata = () => loadeddataTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnloadeddata() {
        this.#htmlMediaElement.onloadeddata = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} loadedmetadataTrigger
     */
    activateOnloadedmetadata(loadedmetadataTrigger) {
        this.#htmlMediaElement.onloadedmetadata = () => loadedmetadataTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnloadedmetadata() {
        this.#htmlMediaElement.onloadedmetadata = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} stalledTrigger
     */
    activateOnstalled(stalledTrigger) {
        this.#htmlMediaElement.onstalled = () => stalledTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnstalled() {
        this.#htmlMediaElement.onstalled = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} suspendTrigger
     */
    activateOnsuspend(suspendTrigger) {
        this.#htmlMediaElement.onsuspend = () => suspendTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnsuspend() {
        this.#htmlMediaElement.onsuspend = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} waitingTrigger
     */
    activateOnwaiting(waitingTrigger) {
        this.#htmlMediaElement.onwaiting = () => waitingTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnwaiting() {
        this.#htmlMediaElement.onwaiting = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} abortTrigger
     */
    activateOnabort(abortTrigger) {
        this.#htmlMediaElement.onabort = () => abortTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnabort() {
        this.#htmlMediaElement.onabort = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} emptiedTrigger
     */
    activateOnemptied(emptiedTrigger) {
        this.#htmlMediaElement.onemptied = () => emptiedTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnemptied() {
        this.#htmlMediaElement.onemptied = null;
    }


    // Timing

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} playTrigger
     */
    activateOnplay(playTrigger) {
        this.#htmlMediaElement.onplay = () => playTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnplay() {
        this.#htmlMediaElement.onplay = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} pauseTrigger
     */
    activateOnpause(pauseTrigger) {
        this.#htmlMediaElement.onpause = () => pauseTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnpause() {
        this.#htmlMediaElement.onpause = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} endedTrigger
     */
    activateOnended(endedTrigger) {
        this.#htmlMediaElement.onended = () => endedTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnended() {
        this.#htmlMediaElement.onended = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} seekingTrigger
     */
    activateOnseeking(seekingTrigger) {
        this.#htmlMediaElement.onseeking = () => seekingTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnseeking() {
        this.#htmlMediaElement.onseeking = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} seekedTrigger
     */
    activateOnseeked(seekedTrigger) {
        this.#htmlMediaElement.onseeked = () => seekedTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnseeked() {
        this.#htmlMediaElement.onseeked = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} timeupdateTrigger
     */
    activateOntimeupdate(timeupdateTrigger) {
        this.#htmlMediaElement.ontimeupdate = () => timeupdateTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOntimeupdate() {
        this.#htmlMediaElement.ontimeupdate = null;
    }


    // Setting

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} volumechangeTrigger
     */
    activateOnvolumechange(volumechangeTrigger) {
        this.#htmlMediaElement.onvolumechange = () => volumechangeTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnvolumechange() {
        this.#htmlMediaElement.onvolumechange = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} ratechangeTrigger
     */
    activateOnratechange(ratechangeTrigger) {
        this.#htmlMediaElement.onratechange = () => ratechangeTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOnratechange() {
        this.#htmlMediaElement.onratechange = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} durationchangeTrigger
     */
    activateOndurationchange(durationchangeTrigger) {
        this.#htmlMediaElement.ondurationchange = () => durationchangeTrigger.invokeMethodAsync("Trigger");
    }
    /**
     */
    deactivateOndurationchange() {
        this.#htmlMediaElement.ondurationchange = null;
    }
}
