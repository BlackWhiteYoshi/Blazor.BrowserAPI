import { DotNet } from "../../../blazor";

export abstract class SensorAPI {
    protected sensor: Sensor;

    constructor(sensor: Sensor) {
        this.sensor = sensor;
    }


    getActivated(): boolean {
        return this.sensor.activated;
    }

    getHasReading(): boolean {
        return this.sensor.hasReading;
    }

    getTimestamp(): number {
        return this.sensor.timestamp ?? 0;
    }


    start() {
        this.sensor.start();
    }

    stop() {
        this.sensor.stop();
    }


    // events

    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // #region error event

    #onerrorCallback = (event: Event) => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeError", event) : this.#eventTrigger.invokeMethodAsync("InvokeError", event);

    activateOnerror() {
        this.sensor.addEventListener("error", this.#onerrorCallback);
    }

    deactivateOnerror() {
        this.sensor.removeEventListener("error", this.#onerrorCallback);
    }

    // #endregion


    // #region error event

    #onactivateCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeActivate") : this.#eventTrigger.invokeMethodAsync("InvokeActivate");

    activateOnactivate() {
        this.sensor.addEventListener("activate", this.#onactivateCallback);
    }

    deactivateOnactivate() {
        this.sensor.removeEventListener("activate", this.#onactivateCallback);
    }

    // #endregion


    // #region error event

    #onreadingCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeReading") : this.#eventTrigger.invokeMethodAsync("InvokeReading");

    activateOnreading() {
        this.sensor.addEventListener("reading", this.#onreadingCallback);
    }

    deactivateOnreading() {
        this.sensor.removeEventListener("reading", this.#onreadingCallback);
    }

    // #endregion
}
