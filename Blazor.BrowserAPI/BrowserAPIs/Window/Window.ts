import { HTMLElementAPI } from "../HTMLElement/HTMLElement";
import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class WindowAPI {
    // Properties

    static getInnerWidth(instance: Window | null): number {
        return (instance ?? window).innerWidth;
    }

    static getInnerHeight(instance: Window | null): number {
        return (instance ?? window).innerHeight;
    }

    static getOuterWidth(instance: Window | null): number {
        return (instance ?? window).outerWidth;
    }

    static getOuterHeight(instance: Window | null): number {
        return (instance ?? window).outerHeight;
    }

    static getDevicePixelRatio(instance: Window | null): number {
        return (instance ?? window).devicePixelRatio;
    }


    static getScrollX(instance: Window | null): number {
        return (instance ?? window).scrollX;
    }

    static getScrollY(instance: Window | null): number {
        return (instance ?? window).scrollY;
    }

    static getScreenX(instance: Window | null): number {
        return (instance ?? window).screenX;
    }

    static getScreenY(instance: Window | null): number {
        return (instance ?? window).screenY;
    }


    static getOrigin(instance: Window | null): string {
        return (instance ?? window).origin;
    }

    static getName(instance: Window | null): string {
        return (instance ?? window).name;
    }

    static setName(instance: Window | null, value: string): void {
        (instance ?? window).name = value;
    }


    static getClosed(instance: Window | null): boolean {
        return (instance ?? window).closed;
    }

    static getCredentialless(instance: Window | null): boolean {
        return (<Window & typeof globalThis & { credentialless: boolean; }>(instance ?? window)).credentialless;
    }

    static getCrossOriginIsolated(instance: Window | null): boolean {
        return (instance ?? window).crossOriginIsolated;
    }

    static getIsSecureContext(instance: Window | null): boolean {
        return (instance ?? window).isSecureContext;
    }

    static getOriginAgentCluster(instance: Window | null): boolean {
        return (<Window & typeof globalThis & { originAgentCluster: boolean; }>(instance ?? window)).originAgentCluster;
    }

    static getMenubar(instance: Window | null): boolean {
        return (instance ?? window).menubar.visible;
    }


    static getFrameElement(instance: Window | null): [HTMLElementAPI] | [null] {
        const result = (instance ?? window).frameElement;
        if (result)
            return [new HTMLElementAPI(<HTMLElement>frameElement)];
        else
            return [null];
    }


    // Methods

    static open(instance: Window | null, url?: string | URL, target?: string, features?: string): [Window] | [null] {
        const result = (instance ?? window).open(url, target, features);
        if (result)
            return [DotNet.createJSObjectReference(result)];
        else
            return [null];
    }

    static close(instance: Window | null): void {
        (instance ?? window).close();
    }

    static stop(instance: Window | null): void {
        (instance ?? window).stop();
    }

    static focus(instance: Window | null): void {
        (instance ?? window).focus();
    }

    static print(instance: Window | null): void {
        (instance ?? window).print();
    }

    static reportError(instance: Window | null, error: any): void {
        (instance ?? window).reportError(error);
    }

    static prompt(instance: Window | null, message: string | null, defaultValue: string | null): string | null {
        return (instance ?? window).prompt(message ?? undefined, defaultValue ?? undefined);
    }

    static confirm(instance: Window | null, message: string | null): boolean {
        return (instance ?? window).confirm(message ?? undefined);
    }

    static alert(instance: Window | null, message: string | null): void {
        (instance ?? window).alert(message ?? undefined);
    }


    static moveBy(instance: Window | null, deltaX: number, deltaY: number): void {
        (instance ?? window).moveBy(deltaX, deltaY);
    }

    static moveTo(instance: Window | null, x: number, y: number): void {
        (instance ?? window).moveTo(x, y);
    }

    static resizeBy(instance: Window | null, xDelta: number, yDelta: number): void {
        (instance ?? window).resizeBy(xDelta, yDelta);
    }

    static resizeTo(instance: Window | null, width: number, height: number): void {
        (instance ?? window).resizeTo(width, height);
    }

    static scroll(instance: Window | null, left: number, top: number, behavior: ScrollBehavior | null): void {
        if (!behavior)
            (instance ?? window).scroll(left, top);
        else
            (instance ?? window).scroll({ left, top, behavior });
    }

    static scrollTo(instance: Window | null, left: number, top: number, behavior: ScrollBehavior | null): void {
        WindowAPI.scroll(instance, left, top, behavior);
    }

    static scrollBy(instance: Window | null, deltaX: number, deltaY: number, behavior: ScrollBehavior | null): void {
        if (!behavior)
            (instance ?? window).scrollBy(deltaX, deltaY);
        else
            (instance ?? window).scrollBy({ left: deltaX, top: deltaY, behavior });
    }


    static setTimeout(instance: Window | null, callback: DotNet.DotNetObject, delay: number): number {
        return (instance ?? window).setTimeout(() => BlazorInvoke.method(callback, "Handler"), delay);
    }

    static clearTimeout(instance: Window | null, id: number): void {
        (instance ?? window).clearTimeout(id);
    }

    static setInterval(instance: Window | null, callback: DotNet.DotNetObject, delay: number): number {
        return (instance ?? window).setInterval(() => BlazorInvoke.method(callback, "Handler"), delay);
    }

    static clearInterval(instance: Window | null, id: number): void {
        (instance ?? window).clearInterval(id);
    }

    static requestAnimationFrame(instance: Window | null, callback: DotNet.DotNetObject): number {
        return (instance ?? window).requestAnimationFrame((timestamp: number) => BlazorInvoke.method(callback, "Handler", timestamp));
    }

    static cancelAnimationFrame(instance: Window | null, handle: number): void {
        (instance ?? window).cancelAnimationFrame(handle);
    }

    static requestIdleCallback(instance: Window | null, callback: DotNet.DotNetObject, timeout: number | null): number {
        return (instance ?? window).requestIdleCallback(() => BlazorInvoke.method(callback, "Handler"), { timeout: timeout ?? undefined });
    }

    static cancelIdleCallback(instance: Window | null, handle: number): void {
        (instance ?? window).cancelIdleCallback(handle);
    }

    static queueMicrotask(instance: Window | null, callback: DotNet.DotNetObject): void {
        (instance ?? window).queueMicrotask(() => BlazorInvoke.method(callback, "Handler"));
    }


    static atob(instance: Window | null, base64: string): string {
        return (instance ?? window).atob(base64);
    }

    static btoa(instance: Window | null, ascii: string): string {
        return (instance ?? window).btoa(ascii);
    }

    static postMessage(instance: Window | null, message: any, targetOrigin: string): void {
        (instance ?? window).postMessage(message, targetOrigin);
    }

    static structuredClone<T>(instance: Window | null, value: T): T {
        return (instance ?? window).structuredClone(value);
    }
}
