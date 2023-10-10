/**
 * 
 * @param {string} filePath
 * @returns {boolean}
 */
export async function serviceWorkerContainerRegister(filePath) {
    if (!("serviceWorker" in navigator))
        return false;
    
    await navigator.serviceWorker.register(filePath);
    return true;
}

/**
 * 
 * @param {string} filePath
 * @returns {Promise<ServiceWorkerRegistration>}
 */
export function serviceWorkerContainerRegisterWithWorkerRegistration(filePath) {
    if (!("serviceWorker" in navigator))
        return Promise.reject("Service workers are not supported.");

    return navigator.serviceWorker.register(filePath);
}


/**
 * 
 * @returns {ServiceWorker | null}
 */
export function serviceWorkerContainerController() {
    return navigator.serviceWorker.controller;
}

/**
 * 
 * @returns {Promise<ServiceWorkerRegistration>}
 */
export function serviceWorkerContainerReady() {
    return navigator.serviceWorker.ready;
}


/**
 * 
 * @param {string | URL} clientUrl
 * @returns {Promise<ServiceWorkerRegistration | undefined>}
 */
export function serviceWorkerContainerGetRegistration(clientUrl) {
    navigator.serviceWorker.getRegistration(clientUrl);
}

/**
 * 
 * @returns {Promise<readonly ServiceWorkerRegistration[]>}
 */
export function serviceWorkerContainerGetRegistrations() {
    navigator.serviceWorker.getRegistrations();
}

/**
 * 
 */
export function serviceWorkerContainerStartMessages() {
    navigator.serviceWorker.startMessages();
}


/**
 * 
 * @param {import("../blazor").DotNet.DotNetObject} controllerChangeTrigger
 */
export function serviceWorkerContainerActivateOncontrollerchange(controllerChangeTrigger) {
    navigator.serviceWorker.oncontrollerchange = () => controllerChangeTrigger.invokeMethodAsync("Trigger");
}

/**
 * 
 */
export function serviceWorkerContainerDeactivateOncontrollerchange() {
    navigator.serviceWorker.oncontrollerchange = null;
}


/**
 * 
 * @param {import("../blazor").DotNet.DotNetObject} messageTrigger
 */
export function serviceWorkerContainerActivateOnMessage(messageTrigger) {
    navigator.serviceWorker.onmessage = () => messageTrigger.invokeMethodAsync("Trigger");
}

/**
 * 
 */
export function serviceWorkerContainerDeactivateOnMessage() {
    navigator.serviceWorker.onmessage = null;
}
