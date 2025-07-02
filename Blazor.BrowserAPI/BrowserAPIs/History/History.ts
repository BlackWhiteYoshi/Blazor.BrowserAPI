export class HistoryAPI {
    static getLength(): number {
        return history.length;
    }

    static getScrollRestoration(): string {
        return history.scrollRestoration;
    }

    static setScrollRestoration(value: "auto" | "manual") {
        history.scrollRestoration = value;
    }

    static getState(): any {
        return history.state;
    }


    static forward() {
        history.forward();
    }

    static back() {
        history.back();
    }

    static go(delta: number) {
        history.go(delta);
    }

    static pushState(data: any, title: string, url: string) {
        history.pushState(data, title, url ?? undefined);
        
    }

    static replaceState(data: any, title: string, url: string) {
        history.replaceState(data, title, url ?? undefined);
    }


    // events


    static #eventTrigger: DotNet.DotNetObject;
    static #isEventTriggerSync: boolean;

    static initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        HistoryAPI.#eventTrigger = eventTrigger;
        HistoryAPI.#isEventTriggerSync = isEventTriggerSync;
    }


    // popstate event

    static #onpopstate(popStateEvent: PopStateEvent) {
        if (HistoryAPI.#isEventTriggerSync)
            HistoryAPI.#eventTrigger.invokeMethod("InvokePopState", popStateEvent.state);
        else
            HistoryAPI.#eventTrigger.invokeMethodAsync("InvokePopState", popStateEvent.state);
    }

    static activateOnpopstate() {
        window.addEventListener("popstate", HistoryAPI.#onpopstate);
    }

    static deactivateOnpopstate() {
        window.removeEventListener("popstate", HistoryAPI.#onpopstate);
    }
}
