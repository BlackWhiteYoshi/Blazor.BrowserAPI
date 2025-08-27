import { blazorInvokeMethod } from "../../../Extensions/blazorExtensions";

export class PictureInPictureWindowAPI {
    #pictureInPictureWindow: PictureInPictureWindow;

    constructor(pictureInPictureWindow: PictureInPictureWindow) {
        this.#pictureInPictureWindow = pictureInPictureWindow;
    }


    getWidth(): number {
        return this.#pictureInPictureWindow.width;
    }

    getHeight(): number {
        return this.#pictureInPictureWindow.height;
    }


    // events

    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean): void {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // resize event

    #onresize = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeResize");

    activateOnresize(): void {
        this.#pictureInPictureWindow.addEventListener("resize", this.#onresize);
    }

    deactivateOnresize(): void {
        this.#pictureInPictureWindow.removeEventListener("resize", this.#onresize);
    }
}
