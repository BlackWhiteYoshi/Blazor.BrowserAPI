import { ServiceWorkerWrapper } from "../ServiceWorker/ServiceWorker.js";
import { createServiceWorker } from "../ServiceWorker/ServiceWorker.js";


/**
 * @param {ServiceWorkerRegistration} serviceWorkerRegistration
 * @returns {ServiceWorkerRegistrationWrapper}
 */
export function createServiceWorkerRegistration(serviceWorkerRegistration) {
    return new ServiceWorkerRegistrationWrapper(serviceWorkerRegistration);
}


export class ServiceWorkerRegistrationWrapper {
    /** @type {ServiceWorkerRegistration} */
    #serviceWorkerRegistration;

    /**
     * @param {ServiceWorkerRegistration} serviceWorkerRegistration
     */
    constructor(serviceWorkerRegistration) {
        this.#serviceWorkerRegistration = serviceWorkerRegistration;
    }


    /**
     * @returns {ServiceWorkerWrapper | null}
     */
    active() {
        return createServiceWorker(this.#serviceWorkerRegistration.active);
    }

    /**
     * @returns {ServiceWorkerWrapper | null}
     */
    installing() {
        return createServiceWorker(this.#serviceWorkerRegistration.installing);
    }

    /**
     * @returns {ServiceWorkerWrapper | null}
     */
    waiting() {
        return createServiceWorker(this.#serviceWorkerRegistration.waiting);
    }


    /**
     * @returns {string}
     */
    scope() {
        return this.#serviceWorkerRegistration.scope;
    }

    /**
     * @returns {string}
     */
    updateViaCache() {
        return this.#serviceWorkerRegistration.updateViaCache;
    }


    /**
     * @returns {Promise<boolean>}
     */
    unregister() {
        return this.#serviceWorkerRegistration.unregister();
    }

    /**
     * @returns {Promise<ServiceWorkerRegistrationWrapper>}
     */
    async update() {
        // wrong return type definition for update(): expected ServiceWorkerRegistration, actually void
        const updatedServiceWorkerRegistration = /** @type {ServiceWorkerRegistration} */ (/** @type {unknown} */ (await this.#serviceWorkerRegistration.update()));
        return createServiceWorkerRegistration(updatedServiceWorkerRegistration);
    }


    // events

    /** @type {import("../../../blazor").DotNet.DotNetObject} */
    #eventTrigger;

    /** @type {boolean} */
    #isEventTriggerSync;


    // #region updatefound event

    /**
     */
    #onupdatefoundCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeUpdateFound") : this.#eventTrigger.invokeMethodAsync("InvokeUpdateFound");

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnupdatefound(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#serviceWorkerRegistration.addEventListener("updatefound", this.#onupdatefoundCallback);
    }

    /**
     */
    deactivateOnupdatefound() {
        this.#serviceWorkerRegistration.removeEventListener("updatefound", this.#onupdatefoundCallback);
    }

    // #endregion
}
