import { ServiceWorkerRegistrationWrapper } from "../ServiceWorkerRegistration/ServiceWorkerRegistration.js";
import { createServiceWorkerRegistration } from "../ServiceWorkerRegistration/ServiceWorkerRegistration.js";
import { ServiceWorkerWrapper } from "../ServiceWorker/ServiceWorker.js";
import { createServiceWorker } from "../ServiceWorker/ServiceWorker.js";
import { DotNet } from "../../../blazor";


/**
 * @param {string} filePath
 * @returns {Promise<boolean>}
 */
export async function serviceWorkerContainerRegister(filePath) {
    if (!("serviceWorker" in navigator))
        return false;

    await navigator.serviceWorker.register(filePath);
    return true;
}

/**
 * @param {string} filePath
 * @returns {Promise<ServiceWorkerRegistrationWrapper>}
 */
export async function serviceWorkerContainerRegisterWithWorkerRegistration(filePath) {
    if (!("serviceWorker" in navigator))
        return Promise.reject("Service workers are not supported.");

    const serviceWorkerRegistration = await navigator.serviceWorker.register(filePath);
    return createServiceWorkerRegistration(serviceWorkerRegistration);
}


/**
 * @returns {ServiceWorkerWrapper | null}
 */
export function serviceWorkerContainerController() {
    return createServiceWorker(navigator.serviceWorker.controller);
}

/**
 * @returns {Promise<ServiceWorkerRegistrationWrapper>}
 */
export async function serviceWorkerContainerReady() {
    const serviceWorkerRegistration = await navigator.serviceWorker.ready;
    return createServiceWorkerRegistration(serviceWorkerRegistration);
}


/**
 * @param {string | URL} clientUrl
 * @returns {Promise<ServiceWorkerRegistrationWrapper | undefined>}
 */
export async function serviceWorkerContainerGetRegistration(clientUrl) {
    const serviceWorkerRegistration = await navigator.serviceWorker.getRegistration(clientUrl);
    if (serviceWorkerRegistration === undefined)
        return undefined;

    return createServiceWorkerRegistration(serviceWorkerRegistration);
}

/**
 * returns something like Promise<JSObjectReference<ServiceWorkerRegistrationWrapper>[]>
 * @returns {Promise<any[]>}
 */
export async function serviceWorkerContainerGetRegistrations() {
    const serviceWorkerRegistrations = await navigator.serviceWorker.getRegistrations();
    return serviceWorkerRegistrations.map((serviceWorkerRegistration) => DotNet.createJSObjectReference(createServiceWorkerRegistration(serviceWorkerRegistration)));
}

/**
 */
export function serviceWorkerContainerStartMessages() {
    navigator.serviceWorker.startMessages();
}


// events

/** @type {import("../../../blazor").DotNet.DotNetObject} */
let serviceWorkerContainerEventTrigger;

/** @type {boolean} */
let serviceWorkerContainerIsEventTriggerSync;


// #region controllerchange event

/**
 */
const serviceWorkerContainerOncontrollerchangeCallback = () => serviceWorkerContainerIsEventTriggerSync ? serviceWorkerContainerEventTrigger.invokeMethod("InvokeControllerChange") : serviceWorkerContainerEventTrigger.invokeMethodAsync("InvokeControllerChange");

/**
 * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
 * @param {boolean} isEventTriggerSync
 */
export function serviceWorkerContainerActivateOncontrollerchange(eventTrigger, isEventTriggerSync) {
    serviceWorkerContainerEventTrigger = eventTrigger;
    serviceWorkerContainerIsEventTriggerSync = isEventTriggerSync;
    navigator.serviceWorker.addEventListener("controllerchange", serviceWorkerContainerOncontrollerchangeCallback);
}

/**
 */
export function serviceWorkerContainerDeactivateOncontrollerchange() {
    navigator.serviceWorker.removeEventListener("controllerchange", serviceWorkerContainerOncontrollerchangeCallback);
}


// #endregion


// #region message event

/**
 */
const serviceWorkerContainerOnmessageCallback = () => serviceWorkerContainerIsEventTriggerSync ? serviceWorkerContainerEventTrigger.invokeMethod("InvokeMessage") : serviceWorkerContainerEventTrigger.invokeMethodAsync("InvokeMessage");

/**
 * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
 * @param {boolean} isEventTriggerSync
 */
export function serviceWorkerContainerActivateOnMessage(eventTrigger, isEventTriggerSync) {
    serviceWorkerContainerEventTrigger = eventTrigger;
    serviceWorkerContainerIsEventTriggerSync = isEventTriggerSync;
    navigator.serviceWorker.addEventListener("message", serviceWorkerContainerOnmessageCallback);
}

/**
 */
export function serviceWorkerContainerDeactivateOnMessage() {
    navigator.serviceWorker.removeEventListener("message", serviceWorkerContainerOnmessageCallback);
}

// #endregion
