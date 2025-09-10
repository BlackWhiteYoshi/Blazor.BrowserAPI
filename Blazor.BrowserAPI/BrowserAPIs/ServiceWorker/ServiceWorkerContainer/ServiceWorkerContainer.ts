import { ServiceWorkerRegistrationAPI } from "../ServiceWorkerRegistration/ServiceWorkerRegistration";
import { ServiceWorkerAPI } from "../ServiceWorker/ServiceWorker";
import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class ServiceWorkerContainerAPI {
    static async register(filePath: string): Promise<void> {
        await navigator.serviceWorker.register(filePath);
    }

    static async registerWithWorkerRegistration(filePath: string): Promise<ServiceWorkerRegistrationAPI> {
        const serviceWorkerRegistration = await navigator.serviceWorker.register(filePath);
        return new ServiceWorkerRegistrationAPI(serviceWorkerRegistration);
    }


    static getController(): [ServiceWorkerAPI] | [null] {
        const serviceWorker = navigator.serviceWorker.controller;
        if (serviceWorker)
            return [DotNet.createJSObjectReference(new ServiceWorkerAPI(serviceWorker))];
        else
            return [null];
    }

    static async getReady(): Promise<ServiceWorkerRegistrationAPI> {
        const serviceWorkerRegistration = await navigator.serviceWorker.ready;
        return new ServiceWorkerRegistrationAPI(serviceWorkerRegistration);
    }


    static async getRegistration(clientUrl: string): Promise<[ServiceWorkerRegistrationAPI] | [null]> {
        const serviceWorkerRegistration = await navigator.serviceWorker.getRegistration(clientUrl);
        if (serviceWorkerRegistration)
            return [DotNet.createJSObjectReference(new ServiceWorkerRegistrationAPI(serviceWorkerRegistration))];
        else
            return [null];
    }

    static async getRegistrations(): Promise<ServiceWorkerRegistrationAPI[]> {
        const serviceWorkerRegistrations = await navigator.serviceWorker.getRegistrations();
        return serviceWorkerRegistrations.map(serviceWorkerRegistration => DotNet.createJSObjectReference(new ServiceWorkerRegistrationAPI(serviceWorkerRegistration)));
    }

    static startMessages(): void {
        navigator.serviceWorker.startMessages();
    }


    // events


    static #eventTrigger: DotNet.DotNetObject;

    static initEvents(eventTrigger: DotNet.DotNetObject): void {
        ServiceWorkerContainerAPI.#eventTrigger = eventTrigger;
    }


    // controllerchange event

    static #oncontrollerchange() {
        return BlazorInvoke.method(ServiceWorkerContainerAPI.#eventTrigger, "InvokeControllerChange");
    }

    static activateOncontrollerchange(): void {
        navigator.serviceWorker.addEventListener("controllerchange", ServiceWorkerContainerAPI.#oncontrollerchange);
    }

    static deactivateOncontrollerchange(): void {
        navigator.serviceWorker.removeEventListener("controllerchange", ServiceWorkerContainerAPI.#oncontrollerchange);
    }


    // message event

    static #onmessage(event: MessageEvent) {
        return BlazorInvoke.method(ServiceWorkerContainerAPI.#eventTrigger, "InvokeMessage", event.data);
    }

    static activateOnMessage(): void {
        navigator.serviceWorker.addEventListener("message", ServiceWorkerContainerAPI.#onmessage);
    }

    static deactivateOnMessage(): void {
        navigator.serviceWorker.removeEventListener("message", ServiceWorkerContainerAPI.#onmessage);
    }
}
