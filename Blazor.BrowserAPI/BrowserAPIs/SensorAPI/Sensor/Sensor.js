/**
 * @abstract
 */
export class SensorWrapper {
    /**
     * @protected
     * @type {Sensor}
     * */
    sensor;

    /**
     * @param {Sensor} sensor
     */
    constructor(sensor) {
        this.sensor = sensor;
    }


    /**
     * @returns {boolean}
     */
    getActivated() {
        return this.sensor.activated;
    }

    /**
     * @returns {boolean}
     */
    getHasReading() {
        return this.sensor.hasReading;
    }

    /**
     * @returns {number}
     */
    getTimestamp() {
        return this.sensor.timestamp ?? 0;
    }


    /**
     */
    start() {
        this.sensor.start();
    }

    /**
     */
    stop() {
        this.sensor.stop();
    }


    // events

    /** @type {import("../../../blazor").DotNet.DotNetObject} */
    #eventTrigger;

    /** @type {boolean} */
    #isEventTriggerSync;


    // #region error event

    /**
     * @param {Event} event
     */
    #onerrorCallback = (event) => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeError", event) : this.#eventTrigger.invokeMethodAsync("InvokeError", event);

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnerror(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.sensor.addEventListener("error", this.#onerrorCallback);
    }

    /**
     */
    deactivateOnerror() {
        this.sensor.removeEventListener("error", this.#onerrorCallback);
    }

    // #endregion


    // #region error event

    /**
     */
    #onactivateCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeActivate") : this.#eventTrigger.invokeMethodAsync("InvokeActivate");

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnactivate(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.sensor.addEventListener("activate", this.#onactivateCallback);
    }

    /**
     */
    deactivateOnactivate() {
        this.sensor.removeEventListener("activate", this.#onactivateCallback);
    }

    // #endregion


    // #region error event

    /**
     */
    #onreadingCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeReading") : this.#eventTrigger.invokeMethodAsync("InvokeReading");

    /**
     * @param {import("../../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnreading(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.sensor.addEventListener("reading", this.#onreadingCallback);
    }

    /**
     */
    deactivateOnreading() {
        this.sensor.removeEventListener("reading", this.#onreadingCallback);
    }

    // #endregion
}
