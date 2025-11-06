import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class PermissionStatusAPI {
    private permissionStatus: PermissionStatus;

    public constructor(permissionStatus: PermissionStatus) {
        this.permissionStatus = permissionStatus;
    }

    public getName(): string {
        return this.permissionStatus.name;
    }

    public getState(): "denied" | "granted" | "prompt" {
        return this.permissionStatus.state;
    }


    // events


    private eventTrigger: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // change event

    private onchange = () => BlazorInvoke.method(this.eventTrigger, "InvokeChange");

    public activateOnchange(): void {
        this.permissionStatus.addEventListener("change", this.onchange);
    }

    public deactivateOnstatechange(): void {
        this.permissionStatus.removeEventListener("change", this.onchange);
    }
}
