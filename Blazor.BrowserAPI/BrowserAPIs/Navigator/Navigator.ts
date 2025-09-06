import { FileAPI } from "../FileSystem/File/File";
import { HTMLMediaElementAPI } from "../HTMLMediaElement/HTMLMediaElement";

export class NavigatorAPI {
    static getLanguage(): string {
        return navigator.language;
    }

    static getLanguages(): readonly string[] {
        return navigator.languages;
    }


    static getUserAgent(): string {
        return navigator.userAgent;
    }

    static getWebdriver(): boolean {
        return navigator.webdriver;
    }


    static getUserActivationIsActive(): boolean {
        return navigator.userActivation.isActive;
    }

    static getUserActivationHasBeenActive(): boolean {
        return navigator.userActivation.hasBeenActive;
    }


    static getCookieEnabled(): boolean {
        return navigator.cookieEnabled;
    }

    static getPdfViewerEnabled(): boolean {
        return navigator.pdfViewerEnabled;
    }


    static getMaxTouchPoints(): number {
        return navigator.maxTouchPoints;
    }

    static getHardwareConcurrency(): number {
        return navigator.hardwareConcurrency;
    }

    static getDeviceMemory(): number {
        return (<Navigator & { deviceMemory: number; }>navigator).deviceMemory;
    }



    static canShare(url: string | null, text: string | null, title: string | null, fileAPIs: FileAPI[] | null): boolean {
        return navigator.canShare({ url: url ?? undefined, text: text ?? undefined, title: title ?? undefined, files: fileAPIs ? fileAPIs.map(fileAPI => fileAPI.file) : undefined });
    }

    static share(url: string | null, text: string | null, title: string | null, fileAPIs: FileAPI[] | null): Promise<void> {
        return navigator.share({ url: url ?? undefined, text: text ?? undefined, title: title ?? undefined, files: fileAPIs ? fileAPIs.map(fileAPI => fileAPI.file) : undefined });
    }


    static setAppBadge(contents: number | null): Promise<void> {
        return navigator.setAppBadge(contents ?? undefined);
    }

    static clearAppBadge(): Promise<void> {
        return navigator.clearAppBadge();
    }


    static registerProtocolHandler(scheme: string, url: string): void {
        return navigator.registerProtocolHandler(scheme, url);
    }

    static unregisterProtocolHandler(scheme: string, url: string): void {
        return (<Navigator & { unregisterProtocolHandler(scheme: string, url: string): void; }>navigator).unregisterProtocolHandler(scheme, url);
    }


    static sendBeacon_String(url: string, data: string | null): boolean {
        return navigator.sendBeacon(url, data ?? undefined);
    }

    static sendBeacon_Bytes(url: string, data: Uint8Array): boolean {
        return navigator.sendBeacon(url, data.buffer);
    }

    static vibrate(pattern: number[]): boolean {
        return navigator.vibrate(pattern);
    }


    static getAutoplayPolicy_String(type: string): string {
        return (<Navigator & { getAutoplayPolicy(type: string): string; }>navigator).getAutoplayPolicy(type);
    }

    static getAutoplayPolicy_Element(element: HTMLMediaElementAPI): string {
        return (<Navigator & { getAutoplayPolicy(element: HTMLMediaElement): string; }>navigator).getAutoplayPolicy(element.htmlMediaElement);
    }

    static getInstalledRelatedApps(): Promise<{ id?: string, platform: string, url?: string, version?: string; }[]> {
        return (<Navigator & { getInstalledRelatedApps(): Promise<{ id?: string, platform: string, url?: string, version?: string; }[]>; }>navigator).getInstalledRelatedApps();
    }
}
