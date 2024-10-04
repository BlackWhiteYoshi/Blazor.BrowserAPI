import { ServiceWorkerAPI } from "../ServiceWorker/ServiceWorker.js";

export class ServiceWorkerRegistrationAPI {
    /** @type {ServiceWorkerRegistration} */
    #serviceWorkerRegistration;

    /**
     * @param {ServiceWorkerRegistration} serviceWorkerRegistration
     */
    constructor(serviceWorkerRegistration) {
        this.#serviceWorkerRegistration = serviceWorkerRegistration;
    }


    /**
     * @returns {ServiceWorkerAPI | null}
     */
    active() {
        return ServiceWorkerAPI.create(this.#serviceWorkerRegistration.active);
    }

    /**
     * @returns {ServiceWorkerAPI | null}
     */
    installing() {
        return ServiceWorkerAPI.create(this.#serviceWorkerRegistration.installing);
    }

    /**
     * @returns {ServiceWorkerAPI | null}
     */
    waiting() {
        return ServiceWorkerAPI.create(this.#serviceWorkerRegistration.waiting);
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
     * @returns {Promise<ServiceWorkerRegistrationAPI>}
     */
    async update() {
        // wrong return type definition for update(): expected ServiceWorkerRegistration, actually void
        const updatedServiceWorkerRegistration = /** @type {ServiceWorkerRegistration} */ (/** @type {unknown} */ (await this.#serviceWorkerRegistration.update()));
        return new ServiceWorkerRegistrationAPI(updatedServiceWorkerRegistration);
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
