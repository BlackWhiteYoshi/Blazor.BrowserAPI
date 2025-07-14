import { blazorInvokeMethod } from "../../../Extensions/blazorExtensions";

export class ServiceWorkerAPI {
    #serviceWorker: ServiceWorker;

    constructor(serviceWorker: ServiceWorker) {
        this.#serviceWorker = serviceWorker;
    }


    getScriptURL(): string {
        return this.#serviceWorker.scriptURL;
    }

    getState(): string {
        return this.#serviceWorker.state;
    }

    postMessage(message: any): void {
        return this.#serviceWorker.postMessage(message);
    }


    // events


    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean): void {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // statechange event

    #onstatechange = (event: Event) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeStateChange", (event.target as ServiceWorker).state);

    activateOnstatechange(): void {
        this.#serviceWorker.addEventListener("statechange", this.#onstatechange);
    }

    deactivateOnstatechange(): void {
        this.#serviceWorker.removeEventListener("statechange", this.#onstatechange);
    }


    // error event

    #onerror = (event: ErrorEvent) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeError", event);

    activateOnerror(): void {
        this.#serviceWorker.addEventListener("error", this.#onerror);
    }

    deactivateOnerror(): void {
        this.#serviceWorker.removeEventListener("error", this.#onerror);
    }
}
