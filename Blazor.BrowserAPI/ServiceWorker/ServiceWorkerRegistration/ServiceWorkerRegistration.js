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
    /**
     * @type {ServiceWorkerRegistration}
     */
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
     * @returns {ServiceWorker | null}
     */
    installing() {
        return createServiceWorker(this.#serviceWorkerRegistration.installing);
    }

    /**
     * @returns {ServiceWorker | null}
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
     * @returns {ServiceWorkerRegistrationWrapper}
     */
    async update() {
        /**
         * @type {ServiceWorkerRegistration}
         */
        const updatedServiceWorkerRegistration = await this.#serviceWorkerRegistration.update();
        return createServiceWorkerRegistration(updatedServiceWorkerRegistration);
    }


    /**
     * @param {import("../blazor").DotNet.DotNetObject} updateFoundTrigger
     */
    activateOnupdatefound(updateFoundTrigger) {
        this.#serviceWorkerRegistration.onupdatefound = () => updateFoundTrigger.invokeMethodAsync("Trigger");
    }

    /**
     */
    deactivateOnupdatefound() {
        this.#serviceWorkerRegistration.onupdatefound = null;
    }
}
