/**
 * 
 * @param {ServiceWorkerRegistration} serviceWorkerRegistration
 * @returns {ServiceWorker | null}
 */
export function serviceWorkerRegistrationActive(serviceWorkerRegistration) {
    return serviceWorkerRegistration.active;
}

/**
 * 
 * @param {ServiceWorkerRegistration} serviceWorkerRegistration
 * @returns {ServiceWorker | null}
 */
export function serviceWorkerRegistrationInstalling(serviceWorkerRegistration) {
    return serviceWorkerRegistration.installing;
}

/**
 * 
 * @param {ServiceWorkerRegistration} serviceWorkerRegistration
 * @returns {ServiceWorker | null}
 */
export function serviceWorkerRegistrationWaiting(serviceWorkerRegistration) {
    return serviceWorkerRegistration.waiting;
}


/**
 * 
 * @param {ServiceWorkerRegistration} serviceWorkerRegistration
 * @returns {string}
 */
export function serviceWorkerRegistrationScope(serviceWorkerRegistration) {
    return serviceWorkerRegistration.scope;
}

/**
 * 
 * @param {ServiceWorkerRegistration} serviceWorkerRegistration
 * @returns {string}
 */
export function serviceWorkerRegistrationUpdateViaCache(serviceWorkerRegistration) {
    return serviceWorkerRegistration.updateViaCache;
}


/**
 * 
 * @param {ServiceWorkerRegistration} serviceWorkerRegistration
 * @returns {Promise<boolean>}
 */
export function serviceWorkerRegistrationUnregister(serviceWorkerRegistration) {
    return serviceWorkerRegistration.unregister();
}

/**
 * 
 * @param {ServiceWorkerRegistration} serviceWorkerRegistration
 * @returns {ServiceWorkerRegistration}
 */
export function serviceWorkerRegistrationUpdate(serviceWorkerRegistration) {
    return serviceWorkerRegistration.update();
}


/**
 * 
 * @param {ServiceWorkerRegistration} serviceWorkerRegistration
 * @param {import("../blazor").DotNet.DotNetObject} updateFoundTrigger
 */
export function serviceWorkerRegistrationActivateOnupdatefound(serviceWorkerRegistration, updateFoundTrigger) {
    serviceWorkerRegistration.onupdatefound = () => updateFoundTrigger.invokeMethodAsync("Trigger");
}

/**
 * 
 * @param {ServiceWorkerRegistration} serviceWorkerRegistration
 */
export function serviceWorkerRegistrationDeactivateOnupdatefound(serviceWorkerRegistration) {
    serviceWorkerRegistration.onupdatefound = null;
}
