import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class ScreenAPI {
    public static getWidth(): number {
        return window.screen.width;
    }

    public static getHeight(): number {
        return window.screen.height;
    }

    public static getAvailWidth(): number {
        return window.screen.availWidth;
    }

    public static getAvailHeight(): number {
        return window.screen.availHeight;
    }

    public static getColorDepth(): number {
        return window.screen.colorDepth;
    }

    public static getPixelDepth(): number {
        return window.screen.pixelDepth;
    }

    public static getIsExtended(): boolean {
        return window.screen.isExtended;
    }


    // orientation

    public static getOrientationType(): string {
        return window.screen.orientation.type;
    }

    public static getOrientationAngle(): number {
        return window.screen.orientation.angle;
    }

    public static lockOrientation(orientation: string): Promise<void> {
        return window.screen.orientation.lock(orientation);
    }

    public static unlockOrientation(): void {
        window.screen.orientation.unlock();
    }


    // events


    private static eventTrigger: DotNet.DotNetObject;

    public static initEvents(eventTrigger: DotNet.DotNetObject): void {
        ScreenAPI.eventTrigger = eventTrigger;
    }


    // change event

    private static onchange() {
        return BlazorInvoke.method(ScreenAPI.eventTrigger, "InvokeChange");
    }

    public static activateOnchange(): void {
        window.screen.addEventListener("change", ScreenAPI.onchange);
    }

    public static deactivateOnchange(): void {
        window.screen.removeEventListener("change", ScreenAPI.onchange);
    }


    // orientationchange event

    private static onorientationchange() {
        return BlazorInvoke.method(ScreenAPI.eventTrigger, "InvokeOrientationChange");
    }

    public static activateOnorientationchange(): void {
        window.screen.orientation.addEventListener("change", ScreenAPI.onorientationchange);
    }

    public static deactivateOnorientationchange(): void {
        window.screen.orientation.removeEventListener("change", ScreenAPI.onorientationchange);
    }
}
