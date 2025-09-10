import { HTMLElementAPI } from "../HTMLElement/HTMLElement";
import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class HTMLDialogElementAPI {
    #dialog: HTMLDialogElement;

    constructor(dialog: HTMLDialogElement) {
        this.#dialog = dialog;
    }

    static create(dialog: HTMLDialogElement): HTMLDialogElementAPI {
        return new HTMLDialogElementAPI(dialog);
    }


    toHTMLElement(): HTMLElementAPI {
        return new HTMLElementAPI(this.#dialog);
    }


    getClosedBy(): string {
        return (<HTMLDialogElement & { closedBy: string }>this.#dialog).closedBy;
    }

    setClosedBy(value: string): void {
        (<HTMLDialogElement & { closedBy: string; }>this.#dialog).closedBy = value;
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

    setReturnValue(value: string): void {
        this.#dialog.returnValue = value;
    }


    close(returnValue: string | null): void {
        this.#dialog.close(returnValue ?? undefined);
    }

    requestClose(returnValue: string | null): void {
        (<HTMLDialogElement & { requestClose(returnValue?: string): void }>this.#dialog).requestClose(returnValue ?? undefined);
    }


    show(): void {
        this.#dialog.show();
    }

    showModal(): void {
        this.#dialog.showModal();
    }


    // events


    #eventTrigger: DotNet.DotNetObject;

    initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.#eventTrigger = eventTrigger;
    }


    // close event

    #onclose = () => BlazorInvoke.method(this.#eventTrigger, "InvokeClose");

    activateOnclose(): void {
        this.#dialog.addEventListener("close", this.#onclose);
    }

    deactivateOnclose(): void {
        this.#dialog.removeEventListener("close", this.#onclose);
    }


    // cancel event

    #oncancel = () => BlazorInvoke.method(this.#eventTrigger, "InvokeCancel");

    activateOncancel(): void {
        this.#dialog.addEventListener("cancel", this.#oncancel);
    }

    deactivateOncancel(): void {
        this.#dialog.removeEventListener("cancel", this.#oncancel);
    }
}
