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


    start(): void {
        this.sensor.start();
    }

    stop(): void {
        this.sensor.stop();
    }


    // events


    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean): void {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // error event

    #onerror = (event: Event) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeError", event);

    activateOnerror(): void {
        this.sensor.addEventListener("error", this.#onerror);
    }

    deactivateOnerror(): void {
        this.sensor.removeEventListener("error", this.#onerror);
    }


    // activate event

    #onactivate = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeActivate");

    activateOnactivate(): void {
        this.sensor.addEventListener("activate", this.#onactivate);
    }

    deactivateOnactivate(): void {
        this.sensor.removeEventListener("activate", this.#onactivate);
    }


    // reading event

    #onreading = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeReading");

    activateOnreading(): void {
        this.sensor.addEventListener("reading", this.#onreading);
    }

    deactivateOnreading(): void {
        this.sensor.removeEventListener("reading", this.#onreading);
    }
}
