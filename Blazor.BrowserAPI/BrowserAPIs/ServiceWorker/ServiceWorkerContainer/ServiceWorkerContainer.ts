import { ServiceWorkerRegistrationAPI } from "../ServiceWorkerRegistration/ServiceWorkerRegistration";
import { ServiceWorkerAPI } from "../ServiceWorker/ServiceWorker";
import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class ServiceWorkerContainerAPI {
    public static async register(filePath: string): Promise<void> {
        await navigator.serviceWorker.register(filePath);
    }

    public static async registerWithWorkerRegistration(filePath: string): Promise<ServiceWorkerRegistrationAPI> {
        const serviceWorkerRegistration = await navigator.serviceWorker.register(filePath);
        return new ServiceWorkerRegistrationAPI(serviceWorkerRegistration);
    }


    public static getController(): [ServiceWorkerAPI] | [null] {
        const serviceWorker = navigator.serviceWorker.controller;
        if (serviceWorker)
            return [DotNet.createJSObjectReference(new ServiceWorkerAPI(serviceWorker))];
        else
            return [null];
    }

    public static async getReady(): Promise<ServiceWorkerRegistrationAPI> {
        const serviceWorkerRegistration = await navigator.serviceWorker.ready;
        return new ServiceWorkerRegistrationAPI(serviceWorkerRegistration);
    }


    public static async getRegistration(clientUrl: string): Promise<[ServiceWorkerRegistrationAPI] | [null]> {
        const serviceWorkerRegistration = await navigator.serviceWorker.getRegistration(clientUrl);
        if (serviceWorkerRegistration)
            return [DotNet.createJSObjectReference(new ServiceWorkerRegistrationAPI(serviceWorkerRegistration))];
        else
            return [null];
    }

    public static async getRegistrations(): Promise<ServiceWorkerRegistrationAPI[]> {
        const serviceWorkerRegistrations = await navigator.serviceWorker.getRegistrations();
        return serviceWorkerRegistrations.map(serviceWorkerRegistration => DotNet.createJSObjectReference(new ServiceWorkerRegistrationAPI(serviceWorkerRegistration)));
    }

    public static startMessages(): void {
        navigator.serviceWorker.startMessages();
    }


    // events


    private static eventTrigger: DotNet.DotNetObject;

    public static initEvents(eventTrigger: DotNet.DotNetObject): void {
        ServiceWorkerContainerAPI.eventTrigger = eventTrigger;
    }


    // controllerchange event

    private static oncontrollerchange() {
        return BlazorInvoke.method(ServiceWorkerContainerAPI.eventTrigger, "InvokeControllerChange");
    }

    public static activateOncontrollerchange(): void {
        navigator.serviceWorker.addEventListener("controllerchange", ServiceWorkerContainerAPI.oncontrollerchange);
    }

    public static deactivateOncontrollerchange(): void {
        navigator.serviceWorker.removeEventListener("controllerchange", ServiceWorkerContainerAPI.oncontrollerchange);
    }


    // message event

    private static onmessage(event: MessageEvent) {
        return BlazorInvoke.method(ServiceWorkerContainerAPI.eventTrigger, "InvokeMessage", event.data);
    }

    public static activateOnMessage(): void {
        navigator.serviceWorker.addEventListener("message", ServiceWorkerContainerAPI.onmessage);
    }

    public static deactivateOnMessage(): void {
        navigator.serviceWorker.removeEventListener("message", ServiceWorkerContainerAPI.onmessage);
    }
}
