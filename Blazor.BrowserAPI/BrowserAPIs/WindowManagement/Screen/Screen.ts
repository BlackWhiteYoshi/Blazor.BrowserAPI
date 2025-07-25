import { blazorInvokeMethod } from "../../../Extensions/blazorExtensions";

export class ScreenAPI {
    static getWidth(): number {
        return window.screen.width;
    }

    static getHeight(): number {
        return window.screen.height;
    }

    static getAvailWidth(): number {
        return window.screen.availWidth;
    }

    static getAvailHeight(): number {
        return window.screen.availHeight;
    }

    static getColorDepth(): number {
        return window.screen.colorDepth;
    }

    static getPixelDepth(): number {
        return window.screen.pixelDepth;
    }

    static getIsExtended(): boolean {
        return window.screen.isExtended;
    }


    // orientation

    static getOrientationType(): string {
        return window.screen.orientation.type;
    }

    static getOrientationAngle(): number {
        return window.screen.orientation.angle;
    }

    static lockOrientation(orientation: string): Promise<void> {
        return window.screen.orientation.lock(orientation);
    }

    static unlockOrientation(): void {
        window.screen.orientation.unlock();
    }


    // events


    static #eventTrigger: DotNet.DotNetObject;
    static #isEventTriggerSync: boolean;

    static initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean): void {
        ScreenAPI.#eventTrigger = eventTrigger;
        ScreenAPI.#isEventTriggerSync = isEventTriggerSync;
    }


    // change event

    static #onchange() {
        return blazorInvokeMethod(ScreenAPI.#eventTrigger, ScreenAPI.#isEventTriggerSync, "InvokeChange");
    }

    static activateOnchange(): void {
        window.screen.addEventListener("change", ScreenAPI.#onchange);
    }

    static deactivateOnchange(): void {
        window.screen.removeEventListener("change", ScreenAPI.#onchange);
    }


    // orientationchange event

    static #onorientationchange() {
        return blazorInvokeMethod(ScreenAPI.#eventTrigger, ScreenAPI.#isEventTriggerSync, "InvokeOrientationChange");
    }

    static activateOnorientationchange(): void {
        window.screen.orientation.addEventListener("change", ScreenAPI.#onorientationchange);
    }

    static deactivateOnorientationchange(): void {
        window.screen.orientation.removeEventListener("change", ScreenAPI.#onorientationchange);
    }
}
