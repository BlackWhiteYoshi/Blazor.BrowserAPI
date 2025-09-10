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
}
