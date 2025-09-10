import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class PermissionStatusAPI {
    #permissionStatus: PermissionStatus;

    constructor(permissionStatus: PermissionStatus) {
        this.#permissionStatus = permissionStatus;
    }

    getName(): string {
        return this.#permissionStatus.name;
    }

    getState(): "denied" | "granted" | "prompt" {
        return this.#permissionStatus.state;
    }


    // events


    #eventTrigger: DotNet.DotNetObject;

    initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.#eventTrigger = eventTrigger;
    }


    // change event

    #onchange = () => BlazorInvoke.method(this.#eventTrigger, "InvokeChange");

    activateOnchange(): void {
        this.#permissionStatus.addEventListener("change", this.#onchange);
    }

    deactivateOnstatechange(): void {
        this.#permissionStatus.removeEventListener("change", this.#onchange);
    }
}
