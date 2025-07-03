import { blazorInvokeMethod } from "../../../Extensions/blazorExtensions";

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


    // error event

    #onerrorCallback = (event: Event) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeError", event);

    activateOnerror() {
        this.sensor.addEventListener("error", this.#onerrorCallback);
    }

    deactivateOnerror() {
        this.sensor.removeEventListener("error", this.#onerrorCallback);
    }


    // activate event

    #onactivateCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeActivate");

    activateOnactivate() {
        this.sensor.addEventListener("activate", this.#onactivateCallback);
    }

    deactivateOnactivate() {
        this.sensor.removeEventListener("activate", this.#onactivateCallback);
    }


    // reading event

    #onreadingCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeReading");

    activateOnreading() {
        this.sensor.addEventListener("reading", this.#onreadingCallback);
    }

    deactivateOnreading() {
        this.sensor.removeEventListener("reading", this.#onreadingCallback);
    }
}
