import { blazorInvokeMethod } from "../../Extensions/blazorExtensions";

export class DialogAPI {
    #dialog: HTMLDialogElement;

    constructor(dialog: HTMLDialogElement) {
        this.#dialog = dialog;
    }

    static create(dialog: HTMLDialogElement): DialogAPI {
        return new DialogAPI(dialog);
    }


    getOpen(): boolean {
        return this.#dialog.open;
    }

    setOpen(value: boolean): void {
        this.#dialog.open = value;
    }


    getReturnValue(): string {
        return this.#dialog.returnValue;
    }

    setReturnValue(returnValue: string): void {
        this.#dialog.returnValue = returnValue;
    }


    close(returnValue: string | undefined): void {
        this.#dialog.close(returnValue);
    }


    show(): void {
        this.#dialog.show();
    }

    showModal(): void {
        this.#dialog.showModal();
    }


    // events


    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean): void {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // cancel event

    #oncancel = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeCancel");

    activateOncancel(): void {
        this.#dialog.addEventListener("cancel", this.#oncancel);
    }

    deactivateOncancel(): void {
        this.#dialog.removeEventListener("cancel", this.#oncancel);
    }


    // close event

    #onclose = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeClose");

    activateOnclose(): void {
        this.#dialog.addEventListener("close", this.#onclose);
    }

    deactivateOnclose(): void {
        this.#dialog.removeEventListener("close", this.#onclose);
    }
}
