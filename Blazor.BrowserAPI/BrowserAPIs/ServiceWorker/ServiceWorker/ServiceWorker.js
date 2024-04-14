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


    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} stateChangeTrigger
     */
    activateOnstatechange(stateChangeTrigger) {
        this.#serviceWorker.onstatechange = (event) => stateChangeTrigger.invokeMethodAsync("Trigger", /** @type {ServiceWorker} */(event.target).state);
    }

    /**
     */
    deactivateOnstatechange() {
        this.#serviceWorker.onstatechange = null;
    }


    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} errorTrigger
     */
    activateOnerror(errorTrigger) {
        this.#serviceWorker.onerror = (event) => errorTrigger.invokeMethodAsync("Trigger", event);
    }

    /**
     */
    deactivateOnerror() {
        this.#serviceWorker.onerror = null;
    }
}
