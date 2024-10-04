export class DialogAPI {
    /** @type {HTMLDialogElement} */
    #dialog;

    /**
     * @param {HTMLDialogElement} dialog
     */
    constructor(dialog) {
        this.#dialog = dialog;
    }

    /**
     * @param {HTMLDialogElement} dialog
     * @returns {DialogAPI}
     */
    static create(dialog) {
        return new DialogAPI(dialog);
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

    /** @type {boolean} */
    #isEventTriggerSync;


    // #region cancel event

    /**
     */
    #oncancelCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeCancel") : this.#eventTrigger.invokeMethodAsync("InvokeCancel");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOncancel(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
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
    #oncloseCallback = () => this.#isEventTriggerSync ? this.#eventTrigger.invokeMethod("InvokeClose") : this.#eventTrigger.invokeMethodAsync("InvokeClose");

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnclose(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#dialog.addEventListener("close", this.#oncloseCallback);
    }

    /**
     */
    deactivateOnclose() {
        this.#dialog.removeEventListener("close", this.#oncloseCallback);
    }

    // #endregion
}
