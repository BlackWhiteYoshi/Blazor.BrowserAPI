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

    setOpen(value: boolean) {
        this.#dialog.open = value;
    }


    getReturnValue(): string {
        return this.#dialog.returnValue;
    }

    setReturnValue(returnValue: string) {
        this.#dialog.returnValue = returnValue;
    }


    close(returnValue: string | undefined) {
        this.#dialog.close(returnValue);
    }


    show() {
        this.#dialog.show();
    }

    showModal() {
        this.#dialog.showModal();
    }


    // events


    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // cancel event

    #oncancelCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeCancel");

    activateOncancel() {
        this.#dialog.addEventListener("cancel", this.#oncancelCallback);
    }

    deactivateOncancel() {
        this.#dialog.removeEventListener("cancel", this.#oncancelCallback);
    }


    // close event

    #oncloseCallback = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeClose");

    activateOnclose() {
        this.#dialog.addEventListener("close", this.#oncloseCallback);
    }

    deactivateOnclose() {
        this.#dialog.removeEventListener("close", this.#oncloseCallback);
    }
}
