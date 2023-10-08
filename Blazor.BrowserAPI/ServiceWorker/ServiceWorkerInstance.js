/**
 * 
 * @param {ServiceWorker} serviceWorker
 * @returns {string}
 */
export function serviceWorkerInstanceScriptURL(serviceWorker) {
    return serviceWorker.scriptURL;
}

/**
 * 
 * @param {ServiceWorker} serviceWorker
 * @returns {string}
 */
export function serviceWorkerInstanceState(serviceWorker) {
    return serviceWorker.state;
}

/**
 * 
 * @param {ServiceWorker} serviceWorker
 * @param {any} message
 */
export function serviceWorkerInstancePostMessage(serviceWorker, message) {
    return serviceWorker.postMessage(message);
}


/**
 * 
 * @param {ServiceWorker} serviceWorker
 * @param {import("../blazor").DotNet.DotNetObject} stateChangeTrigger
 */
export function serviceWorkerInstanceActivateOnstatechange(serviceWorker, stateChangeTrigger) {
    serviceWorker.onstatechange = (event) => stateChangeTrigger.invokeMethodAsync("Trigger", event.target.state);
}

/**
 * 
 * @param {ServiceWorker} serviceWorker
 */
export function serviceWorkerInstanceDeactivateOnstatechange(serviceWorker) {
    serviceWorker.onstatechange = null;
}


/**
 * 
 * @param {ServiceWorker} serviceWorker
 * @param {import("../blazor").DotNet.DotNetObject} errorTrigger
 */
export function serviceWorkerInstanceActivateOnerror(serviceWorker, errorTrigger) {
    serviceWorker.onerror = (event) => errorTrigger.invokeMethodAsync("Trigger", event);
}

/**
 * 
 * @param {ServiceWorker} serviceWorker
 */
export function serviceWorkerInstanceDeactivateOnerror(serviceWorker) {
    serviceWorker.onerror = null;
}
