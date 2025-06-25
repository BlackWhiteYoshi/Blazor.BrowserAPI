import { ServiceWorkerRegistrationAPI } from "../ServiceWorkerRegistration/ServiceWorkerRegistration";
import { ServiceWorkerAPI } from "../ServiceWorker/ServiceWorker";

export class ServiceWorkerContainerAPI {
    static async register(filePath: string): Promise<boolean> {
        if (!("serviceWorker" in navigator))
            return false;

        await navigator.serviceWorker.register(filePath);
        return true;
    }

    static async registerWithWorkerRegistration(filePath: string): Promise<ServiceWorkerRegistrationAPI> {
        if (!("serviceWorker" in navigator))
            return Promise.reject("Service workers are not supported.");

        const serviceWorkerRegistration = await navigator.serviceWorker.register(filePath);
        return new ServiceWorkerRegistrationAPI(serviceWorkerRegistration);
    }


    static controller(): ServiceWorkerAPI | null {
        return ServiceWorkerAPI.create(navigator.serviceWorker.controller);
    }

    static async ready(): Promise<ServiceWorkerRegistrationAPI> {
        const serviceWorkerRegistration = await navigator.serviceWorker.ready;
        return new ServiceWorkerRegistrationAPI(serviceWorkerRegistration);
    }


    static async getRegistration(clientUrl: string | URL): Promise<ServiceWorkerRegistrationAPI | undefined> {
        const serviceWorkerRegistration = await navigator.serviceWorker.getRegistration(clientUrl);
        if (serviceWorkerRegistration === undefined)
            return undefined;

        return new ServiceWorkerRegistrationAPI(serviceWorkerRegistration);
    }

    static async getRegistrations(): Promise<ServiceWorkerRegistrationAPI[]> {
        const serviceWorkerRegistrations = await navigator.serviceWorker.getRegistrations();
        return serviceWorkerRegistrations.map((serviceWorkerRegistration) => DotNet.createJSObjectReference(new ServiceWorkerRegistrationAPI(serviceWorkerRegistration)));
    }

    static startMessages() {
        navigator.serviceWorker.startMessages();
    }


    // events

    static #eventTrigger: DotNet.DotNetObject;
    static #isEventTriggerSync: boolean;

    static initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // #region controllerchange event

    static #oncontrollerchangeCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeControllerChange") : this.#eventTrigger.invokeMethodAsync("InvokeControllerChange");

    static activateOncontrollerchange() {
        navigator.serviceWorker.addEventListener("controllerchange", this.#oncontrollerchangeCallback);
    }

    static deactivateOncontrollerchange() {
        navigator.serviceWorker.removeEventListener("controllerchange", this.#oncontrollerchangeCallback);
    }


    // #endregion


    // #region message event

    static #onmessageCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeMessage") : this.#eventTrigger.invokeMethodAsync("InvokeMessage");

    static activateOnMessage() {
        navigator.serviceWorker.addEventListener("message", this.#onmessageCallback);
    }

    static deactivateOnMessage() {
        navigator.serviceWorker.removeEventListener("message", this.#onmessageCallback);
    }

    // #endregion
}
