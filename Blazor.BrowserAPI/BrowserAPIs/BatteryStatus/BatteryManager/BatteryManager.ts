import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class BatteryManagerAPI {
    private batteryManager: BatteryManager;

    public constructor(batteryManager: BatteryManager) {
        this.batteryManager = batteryManager;
    }


    public getCharging(): boolean {
        return this.batteryManager.charging;
    }

    public getChargingTime(): number {
        return this.batteryManager.chargingTime;
    }

    public getDischargingTime(): number {
        return this.batteryManager.dischargingTime;
    }

    public getLevel(): number {
        return this.batteryManager.level;
    }


    // events


    private eventTrigger!: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // chargingchange event

    private onchargingchange = () => BlazorInvoke.method(this.eventTrigger, "InvokeChargingChange");

    public activateOnchargingchange(): void {
        this.batteryManager.addEventListener("chargingchange", this.onchargingchange);
    }

    public deactivateOnchargingchange(): void {
        this.batteryManager.removeEventListener("chargingchange", this.onchargingchange);
    }


    // chargingtimechange event

    private onchargingtimechange = () => BlazorInvoke.method(this.eventTrigger, "InvokeChargingTimeChange");

    public activateOnchargingtimechange(): void {
        this.batteryManager.addEventListener("chargingtimechange", this.onchargingtimechange);
    }

    public deactivateOnchargingtimechange(): void {
        this.batteryManager.removeEventListener("chargingtimechange", this.onchargingtimechange);
    }


    // dischargingtimechange event

    private ondischargingtimechange = () => BlazorInvoke.method(this.eventTrigger, "InvokeDischargingTimeChange");

    public activateOndischargingtimechange(): void {
        this.batteryManager.addEventListener("dischargingtimechange", this.ondischargingtimechange);
    }

    public deactivateOndischargingtimechange(): void {
        this.batteryManager.removeEventListener("dischargingtimechange", this.ondischargingtimechange);
    }


    // levelchange event

    private onlevelchange = () => BlazorInvoke.method(this.eventTrigger, "InvokeLevelChange");

    public activateOnlevelchange(): void {
        this.batteryManager.addEventListener("levelchange", this.onlevelchange);
    }

    public deactivateOnlevelchange(): void {
        this.batteryManager.removeEventListener("levelchange", this.onlevelchange);
    }
}
