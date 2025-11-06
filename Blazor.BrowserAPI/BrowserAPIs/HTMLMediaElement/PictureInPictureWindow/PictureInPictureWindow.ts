import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class PictureInPictureWindowAPI {
    private pictureInPictureWindow: PictureInPictureWindow;

    public constructor(pictureInPictureWindow: PictureInPictureWindow) {
        this.pictureInPictureWindow = pictureInPictureWindow;
    }


    public getWidth(): number {
        return this.pictureInPictureWindow.width;
    }

    public getHeight(): number {
        return this.pictureInPictureWindow.height;
    }


    // events

    private eventTrigger: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // resize event

    private onresize = () => BlazorInvoke.method(this.eventTrigger, "InvokeResize");

    public activateOnresize(): void {
        this.pictureInPictureWindow.addEventListener("resize", this.onresize);
    }

    public deactivateOnresize(): void {
        this.pictureInPictureWindow.removeEventListener("resize", this.onresize);
    }
}
