import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export abstract class SensorAPI {
    protected sensor: Sensor;

    public constructor(sensor: Sensor) {
        this.sensor = sensor;
    }


    public getActivated(): boolean {
        return this.sensor.activated;
    }

    public getHasReading(): boolean {
        return this.sensor.hasReading;
    }

    public getTimestamp(): number {
        return this.sensor.timestamp ?? 0;
    }


    public start(): void {
        this.sensor.start();
    }

    public stop(): void {
        this.sensor.stop();
    }



    // events


    private eventTrigger: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // error event

    private onerror = (event: Event) => BlazorInvoke.method(this.eventTrigger, "InvokeError", event);

    public activateOnerror(): void {
        this.sensor.addEventListener("error", this.onerror);
    }

    public deactivateOnerror(): void {
        this.sensor.removeEventListener("error", this.onerror);
    }


    // activate event

    private onactivate = () => BlazorInvoke.method(this.eventTrigger, "InvokeActivate");

    public activateOnactivate(): void {
        this.sensor.addEventListener("activate", this.onactivate);
    }

    public deactivateOnactivate(): void {
        this.sensor.removeEventListener("activate", this.onactivate);
    }


    // reading event

    private onreading = () => BlazorInvoke.method(this.eventTrigger, "InvokeReading");

    public activateOnreading(): void {
        this.sensor.addEventListener("reading", this.onreading);
    }

    public deactivateOnreading(): void {
        this.sensor.removeEventListener("reading", this.onreading);
    }



    // window events


    private static eventTriggerWindow: DotNet.DotNetObject;

    public static initEventsWindow(eventTrigger: DotNet.DotNetObject): void {
        SensorAPI.eventTriggerWindow = eventTrigger;
    }


    // devicemotion event

    private static ondevicemotion(event: DeviceMotionEvent): void {
        BlazorInvoke.method(SensorAPI.eventTriggerWindow, "InvokeDeviceMotion", {
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

    public static activateOndevicemotion(): void {
        window.addEventListener("devicemotion", SensorAPI.ondevicemotion);
    }

    public static deactivateOndevicemotion(): void {
        window.removeEventListener("devicemotion", SensorAPI.ondevicemotion);
    }


    // deviceorientation event

    private static ondeviceorientation(event: DeviceOrientationEvent): void {
        BlazorInvoke.method(SensorAPI.eventTriggerWindow, "InvokeDeviceOrientation", {
            absolute: event.absolute,
            alpha: event.alpha,
            beta: event.beta,
            gamma: event.gamma
        });
    }

    public static activateOndeviceorientation(): void {
        window.addEventListener("deviceorientation", SensorAPI.ondeviceorientation);
    }

    public static deactivateOndeviceorientation(): void {
        window.removeEventListener("deviceorientation", SensorAPI.ondeviceorientation);
    }


    // deviceorientationabsolute event

    private static ondeviceorientationabsolute(event: DeviceOrientationEvent): void {
        BlazorInvoke.method(SensorAPI.eventTriggerWindow, "InvokeDeviceOrientationAbsolute", {
            absolute: event.absolute,
            alpha: event.alpha,
            beta: event.beta,
            gamma: event.gamma
        });
    }

    public static activateOndeviceorientationabsolute(): void {
        window.addEventListener("deviceorientationabsolute", SensorAPI.ondeviceorientationabsolute);
    }

    public static deactivateOndeviceorientationabsolute(): void {
        window.removeEventListener("deviceorientationabsolute", SensorAPI.ondeviceorientationabsolute);
    }
}
