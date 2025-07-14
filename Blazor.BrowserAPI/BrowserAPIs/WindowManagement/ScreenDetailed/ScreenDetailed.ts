import { blazorInvokeMethod } from "../../../Extensions/blazorExtensions";

export class ScreenDetailedAPI {
    #screenDetailed: ScreenDetailed;

    constructor(screenDetailed: ScreenDetailed) {
        this.#screenDetailed = screenDetailed;
    }


    getLeft(): number {
        return this.#screenDetailed.left;
    }

    getTop(): number {
        return this.#screenDetailed.top;
    }

    getAvailLeft(): number {
        return this.#screenDetailed.availLeft;
    }

    getAvailTop(): number {
        return this.#screenDetailed.availTop;
    }


    getLabel(): string {
        return this.#screenDetailed.label;
    }

    getDevicePixelRatio(): number {
        return this.#screenDetailed.devicePixelRatio;
    }

    getIsPrimary(): boolean {
        return this.#screenDetailed.isPrimary;
    }

    getIsInternal(): boolean {
        return this.#screenDetailed.isInternal;
    }


    // Screen

    getWidth(): number {
        return this.#screenDetailed.width;
    }

    getHeight(): number {
        return this.#screenDetailed.height;
    }

    getAvailWidth(): number {
        return this.#screenDetailed.availWidth;
    }

    getAvailHeight(): number {
        return this.#screenDetailed.availHeight;
    }

    getColorDepth(): number {
        return this.#screenDetailed.colorDepth;
    }

    getPixelDepth(): number {
        return this.#screenDetailed.pixelDepth;
    }

    getIsExtended(): boolean {
        return this.#screenDetailed.isExtended;
    }


    // Screen orientation

    getOrientationType(): string {
        return this.#screenDetailed.orientation.type;
    }

    getOrientationAngle(): number {
        return this.#screenDetailed.orientation.angle;
    }

    lockOrientation(orientation: string): Promise<void> {
        return this.#screenDetailed.orientation.lock(orientation);
    }

    unlockOrientation() {
        this.#screenDetailed.orientation.unlock();
    }


    // Screen events


    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // change event

    #onchange = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeChange");

    activateOnchange() {
        this.#screenDetailed.addEventListener("change", this.#onchange);
    }

    deactivateOnchange() {
        this.#screenDetailed.removeEventListener("change", this.#onchange);
    }


    // orientationchange event

    #onorientationchange = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeOrientationChange");

    activateOnorientationchange() {
        this.#screenDetailed.orientation.addEventListener("change", this.#onorientationchange);
    }

    deactivateOnorientationchange() {
        this.#screenDetailed.orientation.removeEventListener("change", this.#onorientationchange);
    }
}
