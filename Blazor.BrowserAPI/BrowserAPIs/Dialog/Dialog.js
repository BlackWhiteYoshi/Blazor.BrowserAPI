/**
 * @param {HTMLDialogElement} dialog
 * @returns {DialogWrapper}
 */
export function createDialog(dialog) {
    return new DialogWrapper(dialog);
}


export class DialogWrapper {
    /** @type {HTMLDialogElement} */
    #dialog;

    /**
     * @param {HTMLDialogElement} dialog
     */
    constructor(dialog) {
        this.#dialog = dialog;
    }


    /**
     * @returns {boolean}
     */
    getOpen() {
        return this.#dialog.open;
    }

    /**
     * @param {boolean} value
     */
    setOpen(value) {
        this.#dialog.open = value;
    }


    /**
     * @returns {string}
     */
    getReturnValue() {
        return this.#dialog.returnValue;
    }

    /**
     * @param {string} returnValue
     */
    setReturnValue(returnValue) {
        this.#dialog.returnValue = returnValue;
    }


    /**
     * @param {string | undefined} returnValue
     */
    close(returnValue) {
        this.#dialog.close(returnValue);
    }


    /**
     */
    show() {
        this.#dialog.show();
    }

    /**
     */
    showModal() {
        this.#dialog.showModal();
    }


    // events

    /** @type {import("../../blazor").DotNet.DotNetObject} */
    #eventTrigger;


    // #region cancel event

    /**
     */
    #oncancelCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeCancel");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOncancel(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#dialog.addEventListener("cancel", this.#oncancelCallback);
    }

    /**
     */
    deactivateOncancel() {
        this.#dialog.removeEventListener("cancel", this.#oncancelCallback);
    }

    // #endregion


    // #region close event

    /**
     */
    #oncloseCallback = () => this.#eventTrigger.invokeMethodAsync("InvokeClose");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     */
    activateOnclose(eventTrigger) {
        this.#eventTrigger = eventTrigger;
        this.#dialog.addEventListener("close", this.#oncloseCallback);
    }

    /**
     */
    deactivateOnclose() {
        this.#dialog.removeEventListener("close", this.#oncloseCallback);
    }

    // #endregion
}
