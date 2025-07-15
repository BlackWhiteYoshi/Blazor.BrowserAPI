import { blazorInvokeMethod } from "../../../Extensions/blazorExtensions";

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
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean): void {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // change event

    #onchange = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeChange");

    activateOnchange(): void {
        this.#permissionStatus.addEventListener("change", this.#onchange);
    }

    deactivateOnstatechange(): void {
        this.#permissionStatus.removeEventListener("change", this.#onchange);
    }
}
