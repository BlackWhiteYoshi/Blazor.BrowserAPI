import { ServiceWorkerAPI } from "../ServiceWorker/ServiceWorker";
import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class ServiceWorkerRegistrationAPI {
    private serviceWorkerRegistration: ServiceWorkerRegistration;

    public constructor(serviceWorkerRegistration: ServiceWorkerRegistration) {
        this.serviceWorkerRegistration = serviceWorkerRegistration;
    }


    public getActive(): [ServiceWorkerAPI] | [null] {
        const serviceWorker = this.serviceWorkerRegistration.active;
        if (serviceWorker)
            return [DotNet.createJSObjectReference(new ServiceWorkerAPI(serviceWorker))];
        else
            return [null];
    }

    public getInstalling(): [ServiceWorkerAPI] | [null] {
        const serviceWorker = this.serviceWorkerRegistration.installing;
        if (serviceWorker)
            return [DotNet.createJSObjectReference(new ServiceWorkerAPI(serviceWorker))];
        else
            return [null];
    }

    public getWaiting(): [ServiceWorkerAPI] | [null] {
        const serviceWorker = this.serviceWorkerRegistration.waiting;
        if (serviceWorker)
            return [DotNet.createJSObjectReference(new ServiceWorkerAPI(serviceWorker))];
        else
            return [null];
    }


    public getScope(): string {
        return this.serviceWorkerRegistration.scope;
    }

    public getUpdateViaCache(): string {
        return this.serviceWorkerRegistration.updateViaCache;
    }


    public unregister(): Promise<boolean> {
        return this.serviceWorkerRegistration.unregister();
    }

    public async update(): Promise<ServiceWorkerRegistrationAPI> {
        // wrong return type definition for update(): expected ServiceWorkerRegistration, actually void
        const updatedServiceWorkerRegistration = <ServiceWorkerRegistration><unknown>await this.serviceWorkerRegistration.update();
        return new ServiceWorkerRegistrationAPI(updatedServiceWorkerRegistration);
    }


    // events


    private eventTrigger: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // updatefound event

    private onupdatefound = () => BlazorInvoke.method(this.eventTrigger, "InvokeUpdateFound");

    public activateOnupdatefound(): void {
        this.serviceWorkerRegistration.addEventListener("updatefound", this.onupdatefound);
    }

    public deactivateOnupdatefound(): void {
        this.serviceWorkerRegistration.removeEventListener("updatefound", this.onupdatefound);
    }
}
