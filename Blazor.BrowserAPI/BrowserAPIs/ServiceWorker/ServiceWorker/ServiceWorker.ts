import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class ServiceWorkerAPI {
    private serviceWorker: ServiceWorker;

    public constructor(serviceWorker: ServiceWorker) {
        this.serviceWorker = serviceWorker;
    }


    public getScriptURL(): string {
        return this.serviceWorker.scriptURL;
    }

    public getState(): string {
        return this.serviceWorker.state;
    }

    public postMessage(message: any): void {
        return this.serviceWorker.postMessage(message);
    }


    // events


    private eventTrigger: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // statechange event

    private onstatechange = (event: Event) => BlazorInvoke.method(this.eventTrigger, "InvokeStateChange", (event.target as ServiceWorker).state);

    public activateOnstatechange(): void {
        this.serviceWorker.addEventListener("statechange", this.onstatechange);
    }

    public deactivateOnstatechange(): void {
        this.serviceWorker.removeEventListener("statechange", this.onstatechange);
    }


    // error event

    private onerror = (event: ErrorEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeError", event);

    public activateOnerror(): void {
        this.serviceWorker.addEventListener("error", this.onerror);
    }

    public deactivateOnerror(): void {
        this.serviceWorker.removeEventListener("error", this.onerror);
    }
}
