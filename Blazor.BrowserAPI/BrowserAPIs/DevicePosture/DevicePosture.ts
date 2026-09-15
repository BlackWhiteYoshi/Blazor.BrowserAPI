import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class DevicePostureAPI {
    public static getType(): string {
        return navigator.devicePosture.type;
    }


    // events


    private static eventTrigger: DotNet.DotNetObject;

    public static initEvents(eventTrigger: DotNet.DotNetObject): void {
        DevicePostureAPI.eventTrigger = eventTrigger;
    }


    // change event

    private static onchange() {
        return BlazorInvoke.method(DevicePostureAPI.eventTrigger, "InvokeChange");
    }

    public static activateOnchange(): void {
        navigator.devicePosture.addEventListener("change", DevicePostureAPI.onchange);
    }

    public static deactivateOncontrollerchange(): void {
        navigator.devicePosture.removeEventListener("change", DevicePostureAPI.onchange);
    }
}
