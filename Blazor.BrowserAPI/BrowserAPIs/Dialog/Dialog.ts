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


    // #region cancel event

    #oncancelCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeCancel") : this.#eventTrigger.invokeMethodAsync("InvokeCancel");

    activateOncancel() {
        this.#dialog.addEventListener("cancel", this.#oncancelCallback);
    }

    deactivateOncancel() {
        this.#dialog.removeEventListener("cancel", this.#oncancelCallback);
    }

    // #endregion


    // #region close event

    #oncloseCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeClose") : this.#eventTrigger.invokeMethodAsync("InvokeClose");

    activateOnclose() {
        this.#dialog.addEventListener("close", this.#oncloseCallback);
    }

    deactivateOnclose() {
        this.#dialog.removeEventListener("close", this.#oncloseCallback);
    }

    // #endregion
}
