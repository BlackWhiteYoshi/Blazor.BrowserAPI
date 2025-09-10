import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

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

    initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.#eventTrigger = eventTrigger;
    }


    // error event

    #onerror = (event: Event) => BlazorInvoke.method(this.#eventTrigger, "InvokeError", event);

    activateOnerror(): void {
        this.sensor.addEventListener("error", this.#onerror);
    }

    deactivateOnerror(): void {
        this.sensor.removeEventListener("error", this.#onerror);
    }


    // activate event

    #onactivate = () => BlazorInvoke.method(this.#eventTrigger, "InvokeActivate");

    activateOnactivate(): void {
        this.sensor.addEventListener("activate", this.#onactivate);
    }

    deactivateOnactivate(): void {
        this.sensor.removeEventListener("activate", this.#onactivate);
    }


    // reading event

    #onreading = () => BlazorInvoke.method(this.#eventTrigger, "InvokeReading");

    activateOnreading(): void {
        this.sensor.addEventListener("reading", this.#onreading);
    }

    deactivateOnreading(): void {
        this.sensor.removeEventListener("reading", this.#onreading);
    }
}
