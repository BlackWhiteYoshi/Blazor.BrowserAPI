import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

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

    initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.#eventTrigger = eventTrigger;
    }


    // statechange event

    #onstatechange = (event: Event) => BlazorInvoke.method(this.#eventTrigger, "InvokeStateChange", (event.target as ServiceWorker).state);

    activateOnstatechange(): void {
        this.#serviceWorker.addEventListener("statechange", this.#onstatechange);
    }

    deactivateOnstatechange(): void {
        this.#serviceWorker.removeEventListener("statechange", this.#onstatechange);
    }


    // error event

    #onerror = (event: ErrorEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeError", event);

    activateOnerror(): void {
        this.#serviceWorker.addEventListener("error", this.#onerror);
    }

    deactivateOnerror(): void {
        this.#serviceWorker.removeEventListener("error", this.#onerror);
    }
}
