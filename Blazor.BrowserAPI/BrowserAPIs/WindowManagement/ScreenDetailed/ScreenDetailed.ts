import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class ScreenDetailedAPI {
    private screenDetailed: ScreenDetailed;

    public constructor(screenDetailed: ScreenDetailed) {
        this.screenDetailed = screenDetailed;
    }


    public getLeft(): number {
        return this.screenDetailed.left;
    }

    public getTop(): number {
        return this.screenDetailed.top;
    }

    public getAvailLeft(): number {
        return this.screenDetailed.availLeft;
    }

    public getAvailTop(): number {
        return this.screenDetailed.availTop;
    }


    public getLabel(): string {
        return this.screenDetailed.label;
    }

    public getDevicePixelRatio(): number {
        return this.screenDetailed.devicePixelRatio;
    }

    public getIsPrimary(): boolean {
        return this.screenDetailed.isPrimary;
    }

    public getIsInternal(): boolean {
        return this.screenDetailed.isInternal;
    }


    // Screen

    public getWidth(): number {
        return this.screenDetailed.width;
    }

    public getHeight(): number {
        return this.screenDetailed.height;
    }

    public getAvailWidth(): number {
        return this.screenDetailed.availWidth;
    }

    public getAvailHeight(): number {
        return this.screenDetailed.availHeight;
    }

    public getColorDepth(): number {
        return this.screenDetailed.colorDepth;
    }

    public getPixelDepth(): number {
        return this.screenDetailed.pixelDepth;
    }

    public getIsExtended(): boolean {
        return this.screenDetailed.isExtended;
    }


    // Screen orientation

    public getOrientationType(): string {
        return this.screenDetailed.orientation.type;
    }

    public getOrientationAngle(): number {
        return this.screenDetailed.orientation.angle;
    }

    public lockOrientation(orientation: string): Promise<void> {
        return this.screenDetailed.orientation.lock(orientation);
    }

    public unlockOrientation(): void {
        this.screenDetailed.orientation.unlock();
    }


    // Screen events


    private eventTrigger: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // change event

    private onchange = () => BlazorInvoke.method(this.eventTrigger, "InvokeChange");

    public activateOnchange(): void {
        this.screenDetailed.addEventListener("change", this.onchange);
    }

    public deactivateOnchange(): void {
        this.screenDetailed.removeEventListener("change", this.onchange);
    }


    // orientationchange event

    private onorientationchange = () => BlazorInvoke.method(this.eventTrigger, "InvokeOrientationChange");

    public activateOnorientationchange(): void {
        this.screenDetailed.orientation.addEventListener("change", this.onorientationchange);
    }

    public deactivateOnorientationchange(): void {
        this.screenDetailed.orientation.removeEventListener("change", this.onorientationchange);
    }
}
