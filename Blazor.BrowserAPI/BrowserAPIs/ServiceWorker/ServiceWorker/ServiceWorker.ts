import { blazorInvokeMethod } from "../../../Extensions/blazorExtensions";

export class ServiceWorkerAPI {
    #serviceWorker: ServiceWorker;

    constructor(serviceWorker: ServiceWorker) {
        this.#serviceWorker = serviceWorker;
    }

    static create(serviceWorker: ServiceWorker | null): ServiceWorkerAPI | null {
        if (serviceWorker === null)
            return null;

        return new ServiceWorkerAPI(serviceWorker);
    }


    scriptURL(): string {
        return this.#serviceWorker.scriptURL;
    }

    state(): string {
        return this.#serviceWorker.state;
    }

    postMessage(message: any) {
        return this.#serviceWorker.postMessage(message);
    }


    // events


    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // statechange event

    #onstatechangeCallback = (event: Event) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeStateChange", (event.target as ServiceWorker).state);

    activateOnstatechange() {
        this.#serviceWorker.addEventListener("statechange", this.#onstatechangeCallback);
    }

    deactivateOnstatechange() {
        this.#serviceWorker.removeEventListener("statechange", this.#onstatechangeCallback);
    }


    // error event

    #onerrorCallback = (event: ErrorEvent) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeError", event);

    activateOnerror() {
        this.#serviceWorker.addEventListener("error", this.#onerrorCallback);
    }

    deactivateOnerror() {
        this.#serviceWorker.removeEventListener("error", this.#onerrorCallback);
    }
}
