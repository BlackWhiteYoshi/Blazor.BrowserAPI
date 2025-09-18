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



    // window events


    static #eventTriggerWindow: DotNet.DotNetObject;

    static initEventsWindow(eventTrigger: DotNet.DotNetObject): void {
        SensorAPI.#eventTriggerWindow = eventTrigger;
    }


    // devicemotion event

    static #ondevicemotion(event: DeviceMotionEvent): void {
        BlazorInvoke.method(SensorAPI.#eventTriggerWindow, "InvokeDeviceMotion", {
            accelerationX: event.acceleration?.x ?? null,
            accelerationY: event.acceleration?.y ?? null,
            accelerationZ: event.acceleration?.z ?? null,
            accelerationIncludingGravityX: event.accelerationIncludingGravity?.x ?? null,
            accelerationIncludingGravityY: event.accelerationIncludingGravity?.y ?? null,
            accelerationIncludingGravityZ: event.accelerationIncludingGravity?.z ?? null,
            rotationRateAlpha: event.rotationRate?.alpha ?? null,
            rotationRateBeta: event.rotationRate?.beta ?? null,
            rotationRateGamma: event.rotationRate?.gamma ?? null,
            interval: event.interval
        });
    }

    static activateOndevicemotion(): void {
        window.addEventListener("devicemotion", SensorAPI.#ondevicemotion);
    }

    static deactivateOndevicemotion(): void {
        window.removeEventListener("devicemotion", SensorAPI.#ondevicemotion);
    }


    // deviceorientation event

    static #ondeviceorientation(event: DeviceOrientationEvent): void {
        BlazorInvoke.method(SensorAPI.#eventTriggerWindow, "InvokeDeviceOrientation", {
            absolute: event.absolute,
            alpha: event.alpha,
            beta: event.beta,
            gamma: event.gamma
        });
    }

    static activateOndeviceorientation(): void {
        window.addEventListener("deviceorientation", SensorAPI.#ondeviceorientation);
    }

    static deactivateOndeviceorientation(): void {
        window.removeEventListener("deviceorientation", SensorAPI.#ondeviceorientation);
    }


    // deviceorientationabsolute event

    static #ondeviceorientationabsolute(event: DeviceOrientationEvent): void {
        BlazorInvoke.method(SensorAPI.#eventTriggerWindow, "InvokeDeviceOrientationAbsolute", {
            absolute: event.absolute,
            alpha: event.alpha,
            beta: event.beta,
            gamma: event.gamma
        });
    }

    static activateOndeviceorientationabsolute(): void {
        window.addEventListener("deviceorientationabsolute", SensorAPI.#ondeviceorientationabsolute);
    }

    static deactivateOndeviceorientationabsolute(): void {
        window.removeEventListener("deviceorientationabsolute", SensorAPI.#ondeviceorientationabsolute);
    }
}
