/**
 * @param {ServiceWorker | null} serviceWorker
 * @returns {ServiceWorkerWrapper | null}
 */
export function createServiceWorker(serviceWorker) {
    if (serviceWorker === null)
        return null;

    return new ServiceWorkerWrapper(serviceWorker);
}


export class ServiceWorkerWrapper {
    /** @type {ServiceWorker} */
    #serviceWorker;

    /**
     * @param {ServiceWorker} serviceWorker
     */
    constructor(serviceWorker) {
        this.#serviceWorker = serviceWorker;
    }


    /**
     * @returns {string}
     */
    scriptURL() {
        return this.#serviceWorker.scriptURL;
    }

    /**
     * @returns {string}
     */
    state() {
        return this.#serviceWorker.state;
    }

    /**
     * @param {any} message
     */
    postMessage(message) {
        return this.#serviceWorker.postMessage(message);
    }


    // events

    /** @type {import("../../../blazor").DotNet.DotNetObject} */
    #eventTrigger;

    /** @type {boolean} */
    #isEventTriggerSync;


    // #region statechange event

    /**
     * @param {Event} event
     */
    #onstatechangeCallback = (event) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeStateChange", /** @type {ServiceWorker} */(event.target).state)
        : this.#eventTrigger.invokeMethodAsync("InvokeStateChange", /** @type {ServiceWorker} */(event.target).state);

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnstatechange(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#serviceWorker.addEventListener("statechange", this.#onstatechangeCallback);
    }

    /**
     */
    deactivateOnstatechange() {
        this.#serviceWorker.removeEventListener("statechange", this.#onstatechangeCallback);
    }

    // #endregion


    // #region error event

    /**
     * @param {ErrorEvent} event
     */
    #onerrorCallback = (event) => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeError", event) : this.#eventTrigger.invokeMethodAsync("InvokeError", event);

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnerror(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#serviceWorker.addEventListener("error", this.#onerrorCallback);
    }

    /**
     */
    deactivateOnerror() {
        this.#serviceWorker.removeEventListener("error", this.#onerrorCallback);
    }

    // #endregion
}
