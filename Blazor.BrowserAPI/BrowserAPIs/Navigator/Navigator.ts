import { FileAPI } from "../FileSystem/File/File";
import { HTMLMediaElementAPI } from "../HTMLMediaElement/HTMLMediaElement";

export class NavigatorAPI {
    public static getLanguage(): string {
        return navigator.language;
    }

    public static getLanguages(): readonly string[] {
        return navigator.languages;
    }


    public static getUserAgent(): string {
        return navigator.userAgent;
    }

    public static getWebdriver(): boolean {
        return navigator.webdriver;
    }


    public static getUserActivationIsActive(): boolean {
        return navigator.userActivation.isActive;
    }

    public static getUserActivationHasBeenActive(): boolean {
        return navigator.userActivation.hasBeenActive;
    }


    public static getCookieEnabled(): boolean {
        return navigator.cookieEnabled;
    }

    public static getPdfViewerEnabled(): boolean {
        return navigator.pdfViewerEnabled;
    }


    public static getMaxTouchPoints(): number {
        return navigator.maxTouchPoints;
    }

    public static getHardwareConcurrency(): number {
        return navigator.hardwareConcurrency;
    }

    public static getDeviceMemory(): number {
        return (<Navigator & { deviceMemory: number; }>navigator).deviceMemory;
    }



    public static canShare(url: string | null, text: string | null, title: string | null, fileAPIs: FileAPI[] | null): boolean {
        const shareData: ShareData = {
            ...(url !== null && { url }),
            ...(text !== null && { text }),
            ...(title !== null && { title }),
            ...(fileAPIs !== null && { files: fileAPIs.map(fileAPI => fileAPI.file) }),
        };
        if (Object.keys(shareData).length === 0)
            return navigator.canShare();
        else
            return navigator.canShare(shareData);
    }

    public static share(url: string | null, text: string | null, title: string | null, fileAPIs: FileAPI[] | null): Promise<void> {
        const shareData: ShareData = {
            ...(url !== null && { url }),
            ...(text !== null && { text }),
            ...(title !== null && { title }),
            ...(fileAPIs !== null && { files: fileAPIs.map(fileAPI => fileAPI.file) }),
        };
        if (Object.keys(shareData).length === 0)
            return navigator.share();
        else
            return navigator.share(shareData);
    }


    public static setAppBadge(contents: number | null): Promise<void> {
        if (contents === null)
            return navigator.setAppBadge();
        else
            return navigator.setAppBadge(contents);
    }

    public static clearAppBadge(): Promise<void> {
        return navigator.clearAppBadge();
    }


    public static registerProtocolHandler(scheme: string, url: string): void {
        return navigator.registerProtocolHandler(scheme, url);
    }

    public static unregisterProtocolHandler(scheme: string, url: string): void {
        return (<Navigator & { unregisterProtocolHandler(scheme: string, url: string): void; }>navigator).unregisterProtocolHandler(scheme, url);
    }


    public static sendBeacon_String(url: string, data: string | null): boolean {
        if (data === null)
            return navigator.sendBeacon(url);
        else
            return navigator.sendBeacon(url, data);
    }

    public static sendBeacon_Bytes(url: string, data: Uint8Array): boolean {
        return navigator.sendBeacon(url, <ArrayBuffer>data.buffer);
    }

    public static vibrate(pattern: number[]): boolean {
        return navigator.vibrate(pattern);
    }


    public static getAutoplayPolicy_String(type: string): string {
        return (<Navigator & { getAutoplayPolicy(type: string): string; }>navigator).getAutoplayPolicy(type);
    }

    public static getAutoplayPolicy_Element(element: HTMLMediaElementAPI): string {
        return (<Navigator & { getAutoplayPolicy(element: HTMLMediaElement): string; }>navigator).getAutoplayPolicy(element.htmlMediaElement);
    }

    public static getInstalledRelatedApps(): Promise<{ id?: string, platform: string, url?: string, version?: string; }[]> {
        return (<Navigator & { getInstalledRelatedApps(): Promise<{ id?: string, platform: string, url?: string, version?: string; }[]>; }>navigator).getInstalledRelatedApps();
    }
}
