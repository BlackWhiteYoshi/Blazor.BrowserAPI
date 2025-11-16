import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class HistoryAPI {
    public static getLength(): number {
        return history.length;
    }

    public static getScrollRestoration(): string {
        return history.scrollRestoration;
    }

    public static setScrollRestoration(value: "auto" | "manual"): void {
        history.scrollRestoration = value;
    }

    public static getState(): any {
        return history.state;
    }


    public static forward(): void {
        history.forward();
    }

    public static back(): void {
        history.back();
    }

    public static go(delta: number): void {
        history.go(delta);
    }

    public static pushState(data: any, title: string, url: string): void {
        history.pushState(data, title, url ?? undefined);
    }

    public static replaceState(data: any, title: string, url: string): void {
        history.replaceState(data, title, url ?? undefined);
    }


    // events


    private static eventTrigger: DotNet.DotNetObject;

    public static initEvents(eventTrigger: DotNet.DotNetObject): void {
        HistoryAPI.eventTrigger = eventTrigger;
    }


    // pagereveal event

    private static onpagereveal() {
        return BlazorInvoke.method(HistoryAPI.eventTrigger, "InvokePageReveal");
    }

    public static activateOnpagereveal(): void {
        window.addEventListener("pagereveal", HistoryAPI.onpagereveal);
    }

    public static deactivateOnpagereveal(): void {
        window.removeEventListener("pagereveal", HistoryAPI.onpagereveal);
    }


    // pageswap event

    private static onpageswap() {
        return BlazorInvoke.method(HistoryAPI.eventTrigger, "InvokePageSwap");
    }

    public static activateOnpageswap(): void {
        window.addEventListener("pageswap", HistoryAPI.onpageswap);
    }

    public static deactivateOnpageswap(): void {
        window.removeEventListener("pageswap", HistoryAPI.onpageswap);
    }


    // pageshow event

    private static onpageshow(pageTransitionEvent: PageTransitionEvent) {
        return BlazorInvoke.method(HistoryAPI.eventTrigger, "InvokePageShow", pageTransitionEvent.persisted);
    }

    public static activateOnpageshow(): void {
        window.addEventListener("pageshow", HistoryAPI.onpageshow);
    }

    public static deactivateOnpageshow(): void {
        window.removeEventListener("pageshow", HistoryAPI.onpageshow);
    }


    // pagehide event

    private static onpagehide(pageTransitionEvent: PageTransitionEvent) {
        return BlazorInvoke.method(HistoryAPI.eventTrigger, "InvokePageHide", pageTransitionEvent.persisted);
    }

    public static activateOnpagehide(): void {
        window.addEventListener("pagehide", HistoryAPI.onpagehide);
    }

    public static deactivateOnpagehide(): void {
        window.removeEventListener("pagehide", HistoryAPI.onpagehide);
    }


    // popstate event

    private static onpopstate(popStateEvent: PopStateEvent) {
        return BlazorInvoke.method(HistoryAPI.eventTrigger, "InvokePopState", popStateEvent.state);
    }

    public static activateOnpopstate(): void {
        window.addEventListener("popstate", HistoryAPI.onpopstate);
    }

    public static deactivateOnpopstate(): void {
        window.removeEventListener("popstate", HistoryAPI.onpopstate);
    }


    // hashchange event

    private static onhashchange(hashChangeEvent: HashChangeEvent) {
        return BlazorInvoke.method(HistoryAPI.eventTrigger, "InvokeHashChange", hashChangeEvent.newURL, hashChangeEvent.oldURL);
    }

    public static activateOnhashchange(): void {
        window.addEventListener("hashchange", HistoryAPI.onhashchange);
    }

    public static deactivateOnhashchange(): void {
        window.removeEventListener("hashchange", HistoryAPI.onhashchange);
    }
}
