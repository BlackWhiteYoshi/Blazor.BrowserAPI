import { HTMLElementAPI } from "../HTMLElement/HTMLElement";
import { blazorInvokeMethod } from "../../Extensions/blazorExtensions";

export class WindowAPI {
    // Properties

    static getInnerWidth(): number {
        return window.innerWidth;
    }

    static getInnerHeight(): number {
        return window.innerHeight;
    }

    static getOuterWidth(): number {
        return window.outerWidth;
    }

    static getOuterHeight(): number {
        return window.outerHeight;
    }

    static getDevicePixelRatio(): number {
        return window.devicePixelRatio;
    }


    static getScrollX(): number {
        return window.scrollX;
    }

    static getScrollY(): number {
        return window.scrollY;
    }

    static getScreenX(): number {
        return window.screenX;
    }

    static getScreenY(): number {
        return window.screenY;
    }


    static getOrigin(): string {
        return window.origin;
    }

    static getName(): string {
        return window.name;
    }

    static setName(value: string): void {
        window.name = value;
    }


    static getClosed(): boolean {
        return window.closed;
    }

    static getCredentialless(): boolean {
        return (<Window & typeof globalThis & { credentialless: boolean; }>window).credentialless;
    }

    static getCrossOriginIsolated(): boolean {
        return window.crossOriginIsolated;
    }

    static getIsSecureContext(): boolean {
        return window.isSecureContext;
    }

    static getOriginAgentCluster(): boolean {
        return (<Window & typeof globalThis & { originAgentCluster: boolean; }>window).originAgentCluster;
    }

    static getMenubar(): boolean {
        return window.menubar.visible;
    }


    static getFrameElement(): [HTMLElementAPI] | [null] {
        const result = window.frameElement;
        if (result)
            return [new HTMLElementAPI(<HTMLElement>frameElement)];
        else
            return [null];
    }
}
