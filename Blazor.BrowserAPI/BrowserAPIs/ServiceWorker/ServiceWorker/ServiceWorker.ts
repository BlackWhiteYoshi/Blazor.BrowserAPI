import { DotNet } from "../../../blazor";

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


    // #region statechange event

    #onstatechangeCallback = (event: Event) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeStateChange", (event.target as ServiceWorker).state)
        : this.#eventTrigger.invokeMethodAsync("InvokeStateChange", (event.target as ServiceWorker).state);

    activateOnstatechange() {
        this.#serviceWorker.addEventListener("statechange", this.#onstatechangeCallback);
    }

    deactivateOnstatechange() {
        this.#serviceWorker.removeEventListener("statechange", this.#onstatechangeCallback);
    }

    // #endregion


    // #region error event

    #onerrorCallback = (event: ErrorEvent) => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeError", event) : this.#eventTrigger.invokeMethodAsync("InvokeError", event);

    activateOnerror() {
        this.#serviceWorker.addEventListener("error", this.#onerrorCallback);
    }

    deactivateOnerror() {
        this.#serviceWorker.removeEventListener("error", this.#onerrorCallback);
    }

    // #endregion
}
