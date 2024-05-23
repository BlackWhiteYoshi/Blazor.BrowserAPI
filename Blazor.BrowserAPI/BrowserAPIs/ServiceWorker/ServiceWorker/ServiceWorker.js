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

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnstatechange(eventTrigger) {
        this.#serviceWorker.onstatechange = (event) => eventTrigger.invokeMethodAsync("InvokeStateChange", /** @type {ServiceWorker} */(event.target).state);
    }
    /**
     */
    deactivateOnstatechange() {
        this.#serviceWorker.onstatechange = null;
    }

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnerror(eventTrigger) {
        this.#serviceWorker.onerror = (event) => eventTrigger.invokeMethodAsync("InvokeError", event);
    }
    /**
     */
    deactivateOnerror() {
        this.#serviceWorker.onerror = null;
    }
}
