import { ServiceWorkerAPI } from "../ServiceWorker/ServiceWorker";
import { DotNet } from "../../../blazor";

export class ServiceWorkerRegistrationAPI {
    #serviceWorkerRegistration: ServiceWorkerRegistration;

    constructor(serviceWorkerRegistration: ServiceWorkerRegistration) {
        this.#serviceWorkerRegistration = serviceWorkerRegistration;
    }


    active(): ServiceWorkerAPI | null {
        return ServiceWorkerAPI.create(this.#serviceWorkerRegistration.active);
    }

    installing(): ServiceWorkerAPI | null {
        return ServiceWorkerAPI.create(this.#serviceWorkerRegistration.installing);
    }

    waiting(): ServiceWorkerAPI | null {
        return ServiceWorkerAPI.create(this.#serviceWorkerRegistration.waiting);
    }


    scope(): string {
        return this.#serviceWorkerRegistration.scope;
    }

    updateViaCache(): string {
        return this.#serviceWorkerRegistration.updateViaCache;
    }


    unregister(): Promise<boolean> {
        return this.#serviceWorkerRegistration.unregister();
    }

    async update(): Promise<ServiceWorkerRegistrationAPI> {
        // wrong return type definition for update(): expected ServiceWorkerRegistration, actually void
        const updatedServiceWorkerRegistration = await this.#serviceWorkerRegistration.update() as unknown as ServiceWorkerRegistration;
        return new ServiceWorkerRegistrationAPI(updatedServiceWorkerRegistration);
    }


    // events

    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // #region updatefound event

    #onupdatefoundCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeUpdateFound") : this.#eventTrigger.invokeMethodAsync("InvokeUpdateFound");

    activateOnupdatefound() {
        this.#serviceWorkerRegistration.addEventListener("updatefound", this.#onupdatefoundCallback);
    }

    deactivateOnupdatefound() {
        this.#serviceWorkerRegistration.removeEventListener("updatefound", this.#onupdatefoundCallback);
    }

    // #endregion
}
