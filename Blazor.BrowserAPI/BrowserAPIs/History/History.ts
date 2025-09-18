import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class HistoryAPI {
    static getLength(): number {
        return history.length;
    }

    static getScrollRestoration(): string {
        return history.scrollRestoration;
    }

    static setScrollRestoration(value: "auto" | "manual"): void {
        history.scrollRestoration = value;
    }

    static getState(): any {
        return history.state;
    }


    static forward(): void {
        history.forward();
    }

    static back(): void {
        history.back();
    }

    static go(delta: number): void {
        history.go(delta);
    }

    static pushState(data: any, title: string, url: string): void {
        history.pushState(data, title, url ?? undefined);
    }

    static replaceState(data: any, title: string, url: string): void {
        history.replaceState(data, title, url ?? undefined);
    }


    // events


    static #eventTrigger: DotNet.DotNetObject;

    static initEvents(eventTrigger: DotNet.DotNetObject): void {
        HistoryAPI.#eventTrigger = eventTrigger;
    }


    // pagereveal event

    static #onpagereveal() {
        return BlazorInvoke.method(HistoryAPI.#eventTrigger, "InvokePageReveal");
    }

    static activateOnpagereveal(): void {
        window.addEventListener("pagereveal", HistoryAPI.#onpagereveal);
    }

    static deactivateOnpagereveal(): void {
        window.removeEventListener("pagereveal", HistoryAPI.#onpagereveal);
    }


    // pageswap event

    static #onpageswap() {
        return BlazorInvoke.method(HistoryAPI.#eventTrigger, "InvokePageSwap");
    }

    static activateOnpageswap(): void {
        window.addEventListener("pageswap", HistoryAPI.#onpageswap);
    }

    static deactivateOnpageswap(): void {
        window.removeEventListener("pageswap", HistoryAPI.#onpageswap);
    }


    // pageshow event

    static #onpageshow(pageTransitionEvent: PageTransitionEvent) {
        return BlazorInvoke.method(HistoryAPI.#eventTrigger, "InvokePageShow", pageTransitionEvent.persisted);
    }

    static activateOnpageshow(): void {
        window.addEventListener("pageshow", HistoryAPI.#onpageshow);
    }

    static deactivateOnpageshow(): void {
        window.removeEventListener("pageshow", HistoryAPI.#onpageshow);
    }


    // pagehide event

    static #onpagehide(pageTransitionEvent: PageTransitionEvent) {
        return BlazorInvoke.method(HistoryAPI.#eventTrigger, "InvokePageHide", pageTransitionEvent.persisted);
    }

    static activateOnpagehide(): void {
        window.addEventListener("pagehide", HistoryAPI.#onpagehide);
    }

    static deactivateOnpagehide(): void {
        window.removeEventListener("pagehide", HistoryAPI.#onpagehide);
    }


    // popstate event

    static #onpopstate(popStateEvent: PopStateEvent) {
        return BlazorInvoke.method(HistoryAPI.#eventTrigger, "InvokePopState", popStateEvent.state);
    }

    static activateOnpopstate(): void {
        window.addEventListener("popstate", HistoryAPI.#onpopstate);
    }

    static deactivateOnpopstate(): void {
        window.removeEventListener("popstate", HistoryAPI.#onpopstate);
    }


    // hashchange event

    static #onhashchange(hashChangeEvent: HashChangeEvent) {
        return BlazorInvoke.method(HistoryAPI.#eventTrigger, "InvokeHashChange", hashChangeEvent.newURL, hashChangeEvent.oldURL);
    }

    static activateOnhashchange(): void {
        window.addEventListener("hashchange", HistoryAPI.#onhashchange);
    }

    static deactivateOnhashchange(): void {
        window.removeEventListener("hashchange", HistoryAPI.#onhashchange);
    }
}
