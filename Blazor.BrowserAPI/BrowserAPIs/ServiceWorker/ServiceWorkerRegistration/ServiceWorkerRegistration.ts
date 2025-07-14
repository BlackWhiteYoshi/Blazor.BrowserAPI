import { ServiceWorkerAPI } from "../ServiceWorker/ServiceWorker";
import { blazorInvokeMethod } from "../../../Extensions/blazorExtensions";

export class ServiceWorkerRegistrationAPI {
    #serviceWorkerRegistration: ServiceWorkerRegistration;

    constructor(serviceWorkerRegistration: ServiceWorkerRegistration) {
        this.#serviceWorkerRegistration = serviceWorkerRegistration;
    }


    getActive(): [ServiceWorkerAPI] | [null] {
        const serviceWorker = this.#serviceWorkerRegistration.active;
        if (serviceWorker)
            return [DotNet.createJSObjectReference(new ServiceWorkerAPI(serviceWorker))];
        else
            return [null];
    }

    getInstalling(): [ServiceWorkerAPI] | [null] {
        const serviceWorker = this.#serviceWorkerRegistration.installing;
        if (serviceWorker)
            return [DotNet.createJSObjectReference(new ServiceWorkerAPI(serviceWorker))];
        else
            return [null];
    }

    getWaiting(): [ServiceWorkerAPI] | [null] {
        const serviceWorker = this.#serviceWorkerRegistration.waiting;
        if (serviceWorker)
            return [DotNet.createJSObjectReference(new ServiceWorkerAPI(serviceWorker))];
        else
            return [null];
    }


    getScope(): string {
        return this.#serviceWorkerRegistration.scope;
    }

    getUpdateViaCache(): string {
        return this.#serviceWorkerRegistration.updateViaCache;
    }


    unregister(): Promise<boolean> {
        return this.#serviceWorkerRegistration.unregister();
    }

    async update(): Promise<ServiceWorkerRegistrationAPI> {
        // wrong return type definition for update(): expected ServiceWorkerRegistration, actually void
        const updatedServiceWorkerRegistration = <ServiceWorkerRegistration><unknown>await this.#serviceWorkerRegistration.update();
        return new ServiceWorkerRegistrationAPI(updatedServiceWorkerRegistration);
    }


    // events


    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean): void {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // updatefound event

    #onupdatefound = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeUpdateFound");

    activateOnupdatefound(): void {
        this.#serviceWorkerRegistration.addEventListener("updatefound", this.#onupdatefound);
    }

    deactivateOnupdatefound(): void {
        this.#serviceWorkerRegistration.removeEventListener("updatefound", this.#onupdatefound);
    }
}
