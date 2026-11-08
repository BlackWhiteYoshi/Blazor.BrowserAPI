import { HTMLElementAPI } from "../HTMLElement/HTMLElement";
import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class HTMLDialogElementAPI {
    private dialog: HTMLDialogElement;

    public constructor(dialog: HTMLDialogElement) {
        this.dialog = dialog;
    }

    public static create(dialog: HTMLDialogElement): HTMLDialogElementAPI {
        return new HTMLDialogElementAPI(dialog);
    }


    public toHTMLElement(): HTMLElementAPI {
        return new HTMLElementAPI(this.dialog);
    }


    public getClosedBy(): string {
        return (<HTMLDialogElement & { closedBy: string }>this.dialog).closedBy;
    }

    public setClosedBy(value: string): void {
        (<HTMLDialogElement & { closedBy: string; }>this.dialog).closedBy = value;
    }


    public getOpen(): boolean {
        return this.dialog.open;
    }

    public setOpen(value: boolean): void {
        this.dialog.open = value;
    }


    public getReturnValue(): string {
        return this.dialog.returnValue;
    }

    public setReturnValue(value: string): void {
        this.dialog.returnValue = value;
    }


    public close(returnValue: string | null): void {
        if (returnValue === null)
            this.dialog.close();
        else
            this.dialog.close(returnValue);
    }

    public requestClose(returnValue: string | null): void {
        if (returnValue === null)
            (<HTMLDialogElement & { requestClose(returnValue?: string): void }>this.dialog).requestClose();
        else
            (<HTMLDialogElement & { requestClose(returnValue?: string): void }>this.dialog).requestClose(returnValue);
    }


    public show(): void {
        this.dialog.show();
    }

    public showModal(): void {
        this.dialog.showModal();
    }


    // events


    private eventTrigger!: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // close event

    private onclose = () => BlazorInvoke.method(this.eventTrigger, "InvokeClose");

    public activateOnclose(): void {
        this.dialog.addEventListener("close", this.onclose);
    }

    public deactivateOnclose(): void {
        this.dialog.removeEventListener("close", this.onclose);
    }


    // cancel event

    private oncancel = () => BlazorInvoke.method(this.eventTrigger, "InvokeCancel");

    public activateOncancel(): void {
        this.dialog.addEventListener("cancel", this.oncancel);
    }

    public deactivateOncancel(): void {
        this.dialog.removeEventListener("cancel", this.oncancel);
    }
}
