import { ServiceWorkerRegistrationAPI } from "../ServiceWorkerRegistration/ServiceWorkerRegistration.js";
import { ServiceWorkerAPI } from "../ServiceWorker/ServiceWorker.js";
import { DotNet } from "../../../blazor";

export class ServiceWorkerContainerAPI {
    /**
     * @param {string} filePath
     * @returns {Promise<boolean>}
     */
    static async register(filePath) {
        if (!("serviceWorker" in navigator))
            return false;

        await navigator.serviceWorker.register(filePath);
        return true;
    }

    /**
     * @param {string} filePath
     * @returns {Promise<ServiceWorkerRegistrationAPI>}
     */
    static async registerWithWorkerRegistration(filePath) {
        if (!("serviceWorker" in navigator))
            return Promise.reject("Service workers are not supported.");

        const serviceWorkerRegistration = await navigator.serviceWorker.register(filePath);
        return new ServiceWorkerRegistrationAPI(serviceWorkerRegistration);
    }


    /**
     * @returns {ServiceWorkerAPI | null}
     */
    static controller() {
        return ServiceWorkerAPI.create(navigator.serviceWorker.controller);
    }

    /**
     * @returns {Promise<ServiceWorkerRegistrationAPI>}
     */
    static async ready() {
        const serviceWorkerRegistration = await navigator.serviceWorker.ready;
        return new ServiceWorkerRegistrationAPI(serviceWorkerRegistration);
    }


    /**
     * @param {string | URL} clientUrl
     * @returns {Promise<ServiceWorkerRegistrationAPI | undefined>}
     */
    static async getRegistration(clientUrl) {
        const serviceWorkerRegistration = await navigator.serviceWorker.getRegistration(clientUrl);
        if (serviceWorkerRegistration === undefined)
            return undefined;

        return new ServiceWorkerRegistrationAPI(serviceWorkerRegistration);
    }

    /**
     * returns something like Promise<JSObjectReference<ServiceWorkerRegistrationWrapper>[]>
     * @returns {Promise<any[]>}
     */
    static async getRegistrations() {
        const serviceWorkerRegistrations = await navigator.serviceWorker.getRegistrations();
        return serviceWorkerRegistrations.map((serviceWorkerRegistration) => DotNet.createJSObjectReference(new ServiceWorkerRegistrationAPI(serviceWorkerRegistration)));
    }

    /**
     */
    static startMessages() {
        navigator.serviceWorker.startMessages();
    }


    // events

    /** @type {import("../../../blazor").DotNet.DotNetObject} */
    static #eventTrigger;

    /** @type {boolean} */
    static #isEventTriggerSync;


    // #region controllerchange event

    /**
     */
    static #oncontrollerchangeCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeControllerChange") : this.#eventTrigger.invokeMethodAsync("InvokeControllerChange");

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    static activateOncontrollerchange(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        navigator.serviceWorker.addEventListener("controllerchange", this.#oncontrollerchangeCallback);
    }

    /**
     */
    static deactivateOncontrollerchange() {
        navigator.serviceWorker.removeEventListener("controllerchange", this.#oncontrollerchangeCallback);
    }


    // #endregion


    // #region message event

    /**
     */
    static #onmessageCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeMessage") : this.#eventTrigger.invokeMethodAsync("InvokeMessage");

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    static activateOnMessage(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        navigator.serviceWorker.addEventListener("message", this.#onmessageCallback);
    }

    /**
     */
    static deactivateOnMessage() {
        navigator.serviceWorker.removeEventListener("message", this.#onmessageCallback);
    }

    // #endregion
}
