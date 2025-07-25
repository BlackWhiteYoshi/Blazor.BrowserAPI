import { ServiceWorkerRegistrationAPI } from "../ServiceWorkerRegistration/ServiceWorkerRegistration";
import { ServiceWorkerAPI } from "../ServiceWorker/ServiceWorker";
import { blazorInvokeMethod } from "../../../Extensions/blazorExtensions";

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
    static #isEventTriggerSync: boolean;

    static initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean): void {
        ServiceWorkerContainerAPI.#eventTrigger = eventTrigger;
        ServiceWorkerContainerAPI.#isEventTriggerSync = isEventTriggerSync;
    }


    // controllerchange event

    static #oncontrollerchange() {
        return blazorInvokeMethod(ServiceWorkerContainerAPI.#eventTrigger, ServiceWorkerContainerAPI.#isEventTriggerSync, "InvokeControllerChange");
    }

    static activateOncontrollerchange(): void {
        navigator.serviceWorker.addEventListener("controllerchange", ServiceWorkerContainerAPI.#oncontrollerchange);
    }

    static deactivateOncontrollerchange(): void {
        navigator.serviceWorker.removeEventListener("controllerchange", ServiceWorkerContainerAPI.#oncontrollerchange);
    }


    // message event

    static #onmessage(event: MessageEvent) {
        return blazorInvokeMethod(ServiceWorkerContainerAPI.#eventTrigger, ServiceWorkerContainerAPI.#isEventTriggerSync, "InvokeMessage", event.data);
    }

    static activateOnMessage(): void {
        navigator.serviceWorker.addEventListener("message", ServiceWorkerContainerAPI.#onmessage);
    }

    static deactivateOnMessage(): void {
        navigator.serviceWorker.removeEventListener("message", ServiceWorkerContainerAPI.#onmessage);
    }
}
