/**
 * 
 * @param {ServiceWorker} serviceWorker
 * @returns {string}
 */
export function serviceWorkerScriptURL(serviceWorker) {
    return serviceWorker.scriptURL;
}

/**
 * 
 * @param {ServiceWorker} serviceWorker
 * @returns {string}
 */
export function serviceWorkerState(serviceWorker) {
    return serviceWorker.state;
}

/**
 * 
 * @param {ServiceWorker} serviceWorker
 * @param {any} message
 */
export function serviceWorkerPostMessage(serviceWorker, message) {
    return serviceWorker.postMessage(message);
}


/**
 * 
 * @param {ServiceWorker} serviceWorker
 * @param {import("../blazor").DotNet.DotNetObject} stateChangeTrigger
 */
export function serviceWorkerActivateOnstatechange(serviceWorker, stateChangeTrigger) {
    serviceWorker.onstatechange = (event) => stateChangeTrigger.invokeMethodAsync("Trigger", event.target.state);
}

/**
 * 
 * @param {ServiceWorker} serviceWorker
 */
export function serviceWorkerDeactivateOnstatechange(serviceWorker) {
    serviceWorker.onstatechange = null;
}


/**
 * 
 * @param {ServiceWorker} serviceWorker
 * @param {import("../blazor").DotNet.DotNetObject} errorTrigger
 */
export function serviceWorkerActivateOnerror(serviceWorker, errorTrigger) {
    serviceWorker.onerror = (event) => errorTrigger.invokeMethodAsync("Trigger", event);
}

/**
 * 
 * @param {ServiceWorker} serviceWorker
 */
export function serviceWorkerDeactivateOnerror(serviceWorker) {
    serviceWorker.onerror = null;
}
