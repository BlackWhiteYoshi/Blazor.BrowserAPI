import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

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

    initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.#eventTrigger = eventTrigger;
    }


    // resize event

    #onresize = () => BlazorInvoke.method(this.#eventTrigger, "InvokeResize");

    activateOnresize(): void {
        this.#pictureInPictureWindow.addEventListener("resize", this.#onresize);
    }

    deactivateOnresize(): void {
        this.#pictureInPictureWindow.removeEventListener("resize", this.#onresize);
    }
}
