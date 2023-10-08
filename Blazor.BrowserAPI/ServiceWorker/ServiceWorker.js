/**
 * 
 * @param {string} filePath
 * @returns {boolean}
 */
export function serviceWorkerRegister(filePath) {
    if (!("serviceWorker" in navigator))
        return false;
    
    navigator.serviceWorker.register(filePath);
    return true;
}

/**
 * 
 * @param {string} filePath
 * @returns {Promise<ServiceWorkerRegistration>}
 */
export function serviceWorkerRegisterWithWorkerRegistration(filePath) {
    if (!("serviceWorker" in navigator))
        return Promise.reject("Service workers are not supported.");

    return navigator.serviceWorker.register(filePath);
}


/**
 * 
 * @returns {ServiceWorker | null}
 */
export function serviceWorkerController() {
    return navigator.serviceWorker.controller;
}

/**
 * 
 * @returns {Promise<ServiceWorkerRegistration>}
 */
export function serviceWorkerReady() {
    return navigator.serviceWorker.ready;
}


/**
 * 
 * @param {import("../blazor").DotNet.DotNetObject} controllerChangeTrigger
 */
export function serviceWorkerActivateOncontrollerchange(controllerChangeTrigger) {
    navigator.serviceWorker.oncontrollerchange = () => controllerChangeTrigger.invokeMethodAsync("Trigger");
}

/**
 * 
 */
export function serviceWorkerDeactivateOncontrollerchange() {
    navigator.serviceWorker.oncontrollerchange = null;
}


/**
 * 
 * @param {import("../blazor").DotNet.DotNetObject} messageTrigger
 */
export function serviceWorkerActivateOnMessage(messageTrigger) {
    navigator.serviceWorker.onmessage = () => messageTrigger.invokeMethodAsync("Trigger");
}

/**
 * 
 */
export function serviceWorkerDeactivateOnMessage() {
    navigator.serviceWorker.onmessage = null;
}


/**
 * 
 * @param {string | URL} clientUrl
 * @returns {Promise<ServiceWorkerRegistration | undefined>}
 */
export function serviceWorkerGetRegistration(clientUrl) {
    navigator.serviceWorker.getRegistration(clientUrl);
}

/**
 * 
 * @returns {Promise<readonly ServiceWorkerRegistration[]>}
 */
export function serviceWorkerGetRegistrations() {
    navigator.serviceWorker.getRegistrations();
}

/**
 * 
 */
export function serviceWorkeStartMessages() {
    navigator.serviceWorker.startMessages();
}
