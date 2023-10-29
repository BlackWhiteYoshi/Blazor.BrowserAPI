// @ts-check


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


    /**
     * @param {import("../blazor").DotNet.DotNetObject} cancelTrigger
     */
    activateOncancel(cancelTrigger) {
        this.#dialog.oncancel = () => cancelTrigger.invokeMethodAsync("Trigger");
    }

    /**
     */
    deactivateOncancel() {
        this.#dialog.oncancel = null;
    }


    /**
     * @param {import("../blazor").DotNet.DotNetObject} closeTrigger
     */
    activateOnclose(closeTrigger) {
        this.#dialog.onclose = () => closeTrigger.invokeMethodAsync("Trigger");
    }

    /**
     */
    deactivateOnclose() {
        this.#dialog.onclose = null;
    }
}
