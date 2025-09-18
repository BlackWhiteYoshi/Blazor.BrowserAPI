import { HTMLElementAPI } from "../HTMLElement/HTMLElement";
import { FileAPI } from "../FileSystem/File/File";
import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class WindowAPI {
    #window: Window;

    constructor(window: Window) {
        this.#window = window;
    }


    // properties

    static getInnerWidth(instance: WindowAPI | null): number {
        return (instance ? instance.#window : window).innerWidth;
    }

    static getInnerHeight(instance: WindowAPI | null): number {
        return (instance ? instance.#window : window).innerHeight;
    }

    static getOuterWidth(instance: WindowAPI | null): number {
        return (instance ? instance.#window : window).outerWidth;
    }

    static getOuterHeight(instance: WindowAPI | null): number {
        return (instance ? instance.#window : window).outerHeight;
    }

    static getDevicePixelRatio(instance: WindowAPI | null): number {
        return (instance ? instance.#window : window).devicePixelRatio;
    }


    static getScrollX(instance: WindowAPI | null): number {
        return (instance ? instance.#window : window).scrollX;
    }

    static getScrollY(instance: WindowAPI | null): number {
        return (instance ? instance.#window : window).scrollY;
    }

    static getScreenX(instance: WindowAPI | null): number {
        return (instance ? instance.#window : window).screenX;
    }

    static getScreenY(instance: WindowAPI | null): number {
        return (instance ? instance.#window : window).screenY;
    }


    static getOrigin(instance: WindowAPI | null): string {
        return (instance ? instance.#window : window).origin;
    }

    static getName(instance: WindowAPI | null): string {
        return (instance ? instance.#window : window).name;
    }

    static setName(instance: WindowAPI | null, value: string): void {
        (instance ? instance.#window : window).name = value;
    }


    static getClosed(instance: WindowAPI | null): boolean {
        return (instance ? instance.#window : window).closed;
    }

    static getCredentialless(instance: WindowAPI | null): boolean {
        return (<Window & typeof globalThis & { credentialless: boolean; }>(instance ? instance.#window : window)).credentialless;
    }

    static getCrossOriginIsolated(instance: WindowAPI | null): boolean {
        return (instance ? instance.#window : window).crossOriginIsolated;
    }

    static getIsSecureContext(instance: WindowAPI | null): boolean {
        return (instance ? instance.#window : window).isSecureContext;
    }

    static getOriginAgentCluster(instance: WindowAPI | null): boolean {
        return (<Window & typeof globalThis & { originAgentCluster: boolean; }>(instance ? instance.#window : window)).originAgentCluster;
    }

    static getMenubar(instance: WindowAPI | null): boolean {
        return (instance ? instance.#window : window).menubar.visible;
    }


    static getFrameElement(instance: WindowAPI | null): [HTMLElementAPI] | [null] {
        const result = (instance ? instance.#window : window).frameElement;
        if (result)
            return [new HTMLElementAPI(<HTMLElement>frameElement)];
        else
            return [null];
    }


    // methods

    static open(instance: WindowAPI | null, url?: string | URL, target?: string, features?: string): [WindowAPI] | [null] {
        const result = (instance ? instance.#window : window).open(url, target, features);
        if (result)
            return [DotNet.createJSObjectReference(new WindowAPI(result))];
        else
            return [null];
    }

    static close(instance: WindowAPI | null): void {
        (instance ? instance.#window : window).close();
    }

    static stop(instance: WindowAPI | null): void {
        (instance ? instance.#window : window).stop();
    }

    static focus(instance: WindowAPI | null): void {
        (instance ? instance.#window : window).focus();
    }

    static print(instance: WindowAPI | null): void {
        (instance ? instance.#window : window).print();
    }

    static reportError(instance: WindowAPI | null, error: any): void {
        (instance ? instance.#window : window).reportError(error);
    }

    static prompt(instance: WindowAPI | null, message: string | null, defaultValue: string | null): string | null {
        return (instance ? instance.#window : window).prompt(message ?? undefined, defaultValue ?? undefined);
    }

    static confirm(instance: WindowAPI | null, message: string | null): boolean {
        return (instance ? instance.#window : window).confirm(message ?? undefined);
    }

    static alert(instance: WindowAPI | null, message: string | null): void {
        (instance ? instance.#window : window).alert(message ?? undefined);
    }


    static moveBy(instance: WindowAPI | null, deltaX: number, deltaY: number): void {
        (instance ? instance.#window : window).moveBy(deltaX, deltaY);
    }

    static moveTo(instance: WindowAPI | null, x: number, y: number): void {
        (instance ? instance.#window : window).moveTo(x, y);
    }

    static resizeBy(instance: WindowAPI | null, xDelta: number, yDelta: number): void {
        (instance ? instance.#window : window).resizeBy(xDelta, yDelta);
    }

    static resizeTo(instance: WindowAPI | null, width: number, height: number): void {
        (instance ? instance.#window : window).resizeTo(width, height);
    }

    static scroll(instance: WindowAPI | null, left: number, top: number, behavior: ScrollBehavior | null): void {
        if (!behavior)
            (instance ? instance.#window : window).scroll(left, top);
        else
            (instance ? instance.#window : window).scroll({ left, top, behavior });
    }

    static scrollTo(instance: WindowAPI | null, left: number, top: number, behavior: ScrollBehavior | null): void {
        WindowAPI.scroll(instance, left, top, behavior);
    }

    static scrollBy(instance: WindowAPI | null, deltaX: number, deltaY: number, behavior: ScrollBehavior | null): void {
        if (!behavior)
            (instance ? instance.#window : window).scrollBy(deltaX, deltaY);
        else
            (instance ? instance.#window : window).scrollBy({ left: deltaX, top: deltaY, behavior });
    }


    static setTimeout(instance: WindowAPI | null, callback: DotNet.DotNetObject, delay: number): number {
        return (instance ? instance.#window : window).setTimeout(() => BlazorInvoke.method(callback, "Handler"), delay);
    }

    static clearTimeout(instance: WindowAPI | null, id: number): void {
        (instance ? instance.#window : window).clearTimeout(id);
    }

    static setInterval(instance: WindowAPI | null, callback: DotNet.DotNetObject, delay: number): number {
        return (instance ? instance.#window : window).setInterval(() => BlazorInvoke.method(callback, "Handler"), delay);
    }

    static clearInterval(instance: WindowAPI | null, id: number): void {
        (instance ? instance.#window : window).clearInterval(id);
    }

    static requestAnimationFrame(instance: WindowAPI | null, callback: DotNet.DotNetObject): number {
        return (instance ? instance.#window : window).requestAnimationFrame((timestamp: number) => BlazorInvoke.method(callback, "Handler", timestamp));
    }

    static cancelAnimationFrame(instance: WindowAPI | null, handle: number): void {
        (instance ? instance.#window : window).cancelAnimationFrame(handle);
    }

    static requestIdleCallback(instance: WindowAPI | null, callback: DotNet.DotNetObject, timeout: number | null): number {
        return (instance ? instance.#window : window).requestIdleCallback(() => BlazorInvoke.method(callback, "Handler"), { timeout: timeout ?? undefined });
    }

    static cancelIdleCallback(instance: WindowAPI | null, handle: number): void {
        (instance ? instance.#window : window).cancelIdleCallback(handle);
    }

    static queueMicrotask(instance: WindowAPI | null, callback: DotNet.DotNetObject): void {
        (instance ? instance.#window : window).queueMicrotask(() => BlazorInvoke.method(callback, "Handler"));
    }


    static atob(instance: WindowAPI | null, base64: string): string {
        return (instance ? instance.#window : window).atob(base64);
    }

    static btoa(instance: WindowAPI | null, ascii: string): string {
        return (instance ? instance.#window : window).btoa(ascii);
    }

    static postMessage(instance: WindowAPI | null, message: any, targetOrigin: string): void {
        (instance ? instance.#window : window).postMessage(message, targetOrigin);
    }

    static structuredClone<T>(instance: WindowAPI | null, value: T): T {
        return (instance ? instance.#window : window).structuredClone(value);
    }


    // events


    #eventTrigger: DotNet.DotNetObject;

    static createInstanceAndInitEvents(eventTrigger: DotNet.DotNetObject): WindowAPI {
        const instance = new WindowAPI(window);
        instance.#eventTrigger = eventTrigger;
        return instance;
    }

    initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.#eventTrigger = eventTrigger;
    }


    /** Util function for input events. If the parameter is of type "InputEvent", it gets deconstructed. If it is of type "Event", inputType is null. */
    static #deconstructInputEvent(event: InputEvent | Event): [string | null, string | null, boolean] {
        if (event instanceof InputEvent)
            return [event.data, event.inputType, event.isComposing];
        else
            return [null, null, false];
    }

    /** Util function for drag events. The event parameter is of type "DragEvent" and that has a property "dataTransfer", it gets deconstructed and returned. */
    static #deconstructDataTransfer(data: DataTransfer | null): [string, string, readonly string[], FileAPI[]] {
        if (data !== null)
            return [data.dropEffect, data.effectAllowed, data.types, [...data.files].map(file => DotNet.createJSObjectReference(new FileAPI(file)))];
        else
            return ["", "", [], []];
    }

    /** Util function for touch events. The "TouchEvent" has some properties of type "TouchList", it gets converted to an array with serializable objects. */
    static #deconstructTouchList(touchList: TouchList): { identifier: number, clientX: number, clientY: number, pageX: number, pageY: number, screenX: number, screenY: number, radiusX: number, radiusY: number, rotationAngle: number, force: number; }[] {
        const result = new Array(touchList.length);
        for (let i = 0; i < result.length; i++)
            result[i] = {
                identifier: touchList[i].identifier,
                clientX: touchList[i].clientX,
                clientY: touchList[i].clientY,
                pageX: touchList[i].pageX,
                pageY: touchList[i].pageY,
                screenX: touchList[i].screenX,
                screenY: touchList[i].screenY,
                radiusX: touchList[i].radiusX,
                radiusY: touchList[i].radiusY,
                rotationAngle: touchList[i].rotationAngle,
                force: touchList[i].force
            };

        return result;
    }


    // Window - error event

    #onerror = (error: Event) => BlazorInvoke.method(this.#eventTrigger, "InvokeError", error);

    activateOnerror(): void {
        this.#window.addEventListener("error", this.#onerror);
    }

    deactivateOnerror(): void {
        this.#window.removeEventListener("error", this.#onerror);
    }


    // Window - languagechange event

    #onlanguagechange = () => BlazorInvoke.method(this.#eventTrigger, "InvokeLanguageChange");

    activateOnlanguagechange(): void {
        this.#window.addEventListener("languagechange", this.#onlanguagechange);
    }

    deactivateOnlanguagechange(): void {
        this.#window.removeEventListener("languagechange", this.#onlanguagechange);
    }


    // Window - resize event

    #onresize = () => BlazorInvoke.method(this.#eventTrigger, "InvokeResize");

    activateOnresize(): void {
        this.#window.addEventListener("resize", this.#onresize);
    }

    deactivateOnresize(): void {
        this.#window.removeEventListener("resize", this.#onresize);
    }


    // Window - storage event

    #onstorage = (event: StorageEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeStorage", {
        url: event.url,
        key: event.key,
        newValue: event.newValue,
        oldValue: event.oldValue
    });

    activateOnstorage(): void {
        this.#window.addEventListener("storage", this.#onstorage);
    }

    deactivateOnstorage(): void {
        this.#window.removeEventListener("storage", this.#onstorage);
    }


    // Window - focus event

    #onfocus = () => BlazorInvoke.method(this.#eventTrigger, "InvokeFocus");

    activateOnfocus(): void {
        this.#window.addEventListener("focus", this.#onfocus);
    }

    deactivateOnfocus(): void {
        this.#window.removeEventListener("focus", this.#onfocus);
    }


    // Window - blur event

    #onblur = () => BlazorInvoke.method(this.#eventTrigger, "InvokeBlur");

    activateOnblur(): void {
        this.#window.addEventListener("blur", this.#onblur);
    }

    deactivateOnblur(): void {
        this.#window.removeEventListener("blur", this.#onblur);
    }


    // load event

    #onload = () => BlazorInvoke.method(this.#eventTrigger, "InvokeLoad");

    activateOnload(): void {
        window.addEventListener("load", this.#onload);
    }

    deactivateOnload(): void {
        window.removeEventListener("load", this.#onload);
    }


    // beforeunload event

    #onbeforeunload = () => BlazorInvoke.method(this.#eventTrigger, "InvokeBeforeUnload");

    activateOnbeforeunload(): void {
        window.addEventListener("beforeunload", this.#onbeforeunload);
    }

    deactivateOnbeforeunload(): void {
        window.removeEventListener("beforeunload", this.#onbeforeunload);
    }


    // appinstalled event

    #onappinstalled = () => BlazorInvoke.method(this.#eventTrigger, "InvokeAppInstalled");

    activateOnappinstalled(): void {
        window.addEventListener("appinstalled", this.#onappinstalled);
    }

    deactivateOnappinstalled(): void {
        window.removeEventListener("appinstalled", this.#onappinstalled);
    }


    // beforeinstallprompt event

    #onbeforeinstallprompt = () => BlazorInvoke.method(this.#eventTrigger, "InvokeBeforeInstallPrompt");

    activateOnbeforeinstallprompt(): void {
        window.addEventListener("beforeinstallprompt", this.#onbeforeinstallprompt);
    }

    deactivateOnbeforeinstallprompt(): void {
        window.removeEventListener("beforeinstallprompt", this.#onbeforeinstallprompt);
    }


    // message event

    #onmessage = (event: MessageEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeMessage", event.data, event.origin, event.lastEventId);

    activateOnmessage(): void {
        window.addEventListener("message", this.#onmessage);
    }

    deactivateOnmessage(): void {
        window.removeEventListener("message", this.#onmessage);
    }


    // messageerror event

    #onmessageerror = (event: MessageEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeMessageError", event.data, event.origin, event.lastEventId);

    activateOnmessageerror(): void {
        window.addEventListener("messageerror", this.#onmessageerror);
    }

    deactivateOnmessageerror(): void {
        window.removeEventListener("messageerror", this.#onmessageerror);
    }


    // afterprint event

    #onafterprint = () => BlazorInvoke.method(this.#eventTrigger, "InvokeAfterPrint");

    activateOnafterprint(): void {
        window.addEventListener("afterprint", this.#onafterprint);
    }

    deactivateOnafterprint(): void {
        window.removeEventListener("afterprint", this.#onafterprint);
    }


    // beforeprint event

    #onbeforeprint = () => BlazorInvoke.method(this.#eventTrigger, "InvokeBeforePrint");

    activateOnbeforeprint(): void {
        window.addEventListener("beforeprint", this.#onbeforeprint);
    }

    deactivateOnbeforeprint(): void {
        window.removeEventListener("beforeprint", this.#onbeforeprint);
    }


    // rejectionhandled event

    #onrejectionhandled = (event: PromiseRejectionEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeRejectionHandled", event.reason ?? null);

    activateOnrejectionhandled(): void {
        window.addEventListener("rejectionhandled", this.#onrejectionhandled);
    }

    deactivateOnrejectionhandled(): void {
        window.removeEventListener("rejectionhandled", this.#onrejectionhandled);
    }


    // unhandledrejection event

    #onunhandledrejection = (event: PromiseRejectionEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeUnhandledRejection", event.reason ?? null);

    activateOnunhandledrejection(): void {
        window.addEventListener("unhandledrejection", this.#onunhandledrejection);
    }

    deactivateOnunhandledrejection(): void {
        window.removeEventListener("unhandledrejection", this.#onunhandledrejection);
    }


    // bubble events


    // HTMLElement - scroll event

    #onscroll = () => BlazorInvoke.method(this.#eventTrigger, "InvokeScroll");

    activateOnscroll(): void {
        window.addEventListener("scroll", this.#onscroll);
    }

    deactivateOnscroll(): void {
        window.removeEventListener("scroll", this.#onscroll);
    }


    // HTMLElement - scrollend event

    #onscrollend = () => BlazorInvoke.method(this.#eventTrigger, "InvokeScrollEnd");

    activateOnscrollend(): void {
        window.addEventListener("scrollend", this.#onscrollend);
    }

    deactivateOnscrollend(): void {
        window.removeEventListener("scrollend", this.#onscrollend);
    }


    // HTMLElement - change event

    #onchange = () => BlazorInvoke.method(this.#eventTrigger, "InvokeChange");

    activateOnchange(): void {
        window.addEventListener("change", this.#onchange);
    }

    deactivateOnchange(): void {
        window.removeEventListener("change", this.#onchange);
    }


    // HTMLElement - drag event

    #ondrag = (dragEvent: DragEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDrag", ...WindowAPI.#deconstructDataTransfer(dragEvent.dataTransfer));

    activateOndrag(): void {
        window.addEventListener("drag", this.#ondrag);
    }

    deactivateOndrag(): void {
        window.removeEventListener("drag", this.#ondrag);
    }


    // HTMLElement - dragstart event

    #ondragstart = (dragEvent: DragEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDragStart", ...WindowAPI.#deconstructDataTransfer(dragEvent.dataTransfer));

    activateOndragstart(): void {
        window.addEventListener("dragstart", this.#ondragstart);
    }

    deactivateOndragstart(): void {
        window.removeEventListener("dragstart", this.#ondragstart);
    }


    // HTMLElement - dragend event

    #ondragend = (dragEvent: DragEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDragEnd", ...WindowAPI.#deconstructDataTransfer(dragEvent.dataTransfer));

    activateOndragend(): void {
        window.addEventListener("dragend", this.#ondragend);
    }

    deactivateOndragend(): void {
        window.removeEventListener("dragend", this.#ondragend);
    }


    // HTMLElement - dragenter event

    #ondragenter = (dragEvent: DragEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDragEnter", ...WindowAPI.#deconstructDataTransfer(dragEvent.dataTransfer));

    activateOndragenter(): void {
        window.addEventListener("dragenter", this.#ondragenter);
    }

    deactivateOndragenter(): void {
        window.removeEventListener("dragenter", this.#ondragenter);
    }


    // HTMLElement - dragleave event

    #ondragleave = (dragEvent: DragEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDragLeave", ...WindowAPI.#deconstructDataTransfer(dragEvent.dataTransfer));

    activateOndragleave(): void {
        window.addEventListener("dragleave", this.#ondragleave);
    }

    deactivateOndragleave(): void {
        window.removeEventListener("dragleave", this.#ondragleave);
    }


    // HTMLElement - dragover event

    #ondragover = (dragEvent: DragEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDragOver", ...WindowAPI.#deconstructDataTransfer(dragEvent.dataTransfer));

    activateOndragover(): void {
        window.addEventListener("dragover", this.#ondragover);
    }

    deactivateOndragover(): void {
        window.removeEventListener("dragover", this.#ondragover);
    }


    // HTMLElement - drop event

    #ondrop = (dragEvent: DragEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDrop", ...WindowAPI.#deconstructDataTransfer(dragEvent.dataTransfer));

    activateOndrop(): void {
        window.addEventListener("drop", this.#ondrop);
    }

    deactivateOndrop(): void {
        window.removeEventListener("drop", this.#ondrop);
    }


    // HTMLElement - toggle

    #ontoggle = (toggleEvent: ToggleEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeToggle", toggleEvent.oldState, toggleEvent.newState);

    activateOntoggle(): void {
        window.addEventListener("toggle", this.#ontoggle);
    }

    deactivateOntoggle(): void {
        window.removeEventListener("toggle", this.#ontoggle);
    }


    // HTMLElement - beforetoggle

    #onbeforetoggle = (toggleEvent: ToggleEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeBeforeToggle", toggleEvent.oldState, toggleEvent.newState);

    activateOnbeforetoggle(): void {
        window.addEventListener("beforetoggle", this.#onbeforetoggle);
    }

    deactivateOnbeforetoggle(): void {
        window.removeEventListener("beforetoggle", this.#onbeforetoggle);
    }



    // Element - input event

    #oninput = (inputEvent: InputEvent | Event) => BlazorInvoke.method(this.#eventTrigger, "InvokeInput", ...WindowAPI.#deconstructInputEvent(inputEvent));

    activateOninput(): void {
        window.addEventListener("input", this.#oninput);
    }

    deactivateOninput(): void {
        window.removeEventListener("input", this.#oninput);
    }


    // Element - beforeinput event

    #onbeforeinput = (inputEvent: InputEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeBeforeInput", ...WindowAPI.#deconstructInputEvent(inputEvent));

    activateOnbeforeinput(): void {
        window.addEventListener("beforeinput", this.#onbeforeinput);
    }

    deactivateOnbeforeinput(): void {
        window.removeEventListener("beforeinput", this.#onbeforeinput);
    }


    // Element - beforematch event

    #onbeforematch = () => BlazorInvoke.method(this.#eventTrigger, "InvokeBeforeMatch");

    activateOnbeforematch(): void {
        window.addEventListener("beforematch", this.#onbeforematch);
    }

    deactivateOnbeforematch(): void {
        window.removeEventListener("beforematch", this.#onbeforematch);
    }



    // Element - keydown event

    #onkeydown = (keyboardEvent: KeyboardEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeKeyDown", {
        key: keyboardEvent.key,
        code: keyboardEvent.code,
        location: keyboardEvent.location,
        ctrlKey: keyboardEvent.ctrlKey,
        shiftKey: keyboardEvent.shiftKey,
        altKey: keyboardEvent.altKey,
        metaKey: keyboardEvent.metaKey,
        repeat: keyboardEvent.repeat,
        isComposing: keyboardEvent.isComposing
    });

    activateOnkeydown(): void {
        window.addEventListener("keydown", this.#onkeydown);
    }

    deactivateOnkeydown(): void {
        window.removeEventListener("keydown", this.#onkeydown);
    }


    // Element - keyup event

    #onkeyup = (keyboardEvent: KeyboardEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeKeyUp", {
        key: keyboardEvent.key,
        code: keyboardEvent.code,
        location: keyboardEvent.location,
        ctrlKey: keyboardEvent.ctrlKey,
        shiftKey: keyboardEvent.shiftKey,
        altKey: keyboardEvent.altKey,
        metaKey: keyboardEvent.metaKey,
        repeat: keyboardEvent.repeat,
        isComposing: keyboardEvent.isComposing
    });

    activateOnkeyup(): void {
        window.addEventListener("keyup", this.#onkeyup);
    }

    deactivateOnkeyup(): void {
        window.removeEventListener("keyup", this.#onkeyup);
    }



    // Element - click event

    #onclick = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeClick", {
        button: mouseEvent.button,
        buttons: mouseEvent.buttons,
        movementX: mouseEvent.movementX,
        movementY: mouseEvent.movementY,
        clientX: mouseEvent.clientX,
        clientY: mouseEvent.clientY,
        offsetX: mouseEvent.offsetX,
        offsetY: mouseEvent.offsetY,
        pageX: mouseEvent.pageX,
        pageY: mouseEvent.pageY,
        screenX: mouseEvent.screenX,
        screenY: mouseEvent.screenY,
        ctrlKey: mouseEvent.ctrlKey,
        shiftKey: mouseEvent.shiftKey,
        altKey: mouseEvent.altKey,
        metaKey: mouseEvent.metaKey
    });

    activateOnclick(): void {
        window.addEventListener("click", this.#onclick);
    }

    deactivateOnclick(): void {
        window.removeEventListener("click", this.#onclick);
    }


    // Element - dblclick event

    #ondblclick = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDblClick", {
        button: mouseEvent.button,
        buttons: mouseEvent.buttons,
        movementX: mouseEvent.movementX,
        movementY: mouseEvent.movementY,
        clientX: mouseEvent.clientX,
        clientY: mouseEvent.clientY,
        offsetX: mouseEvent.offsetX,
        offsetY: mouseEvent.offsetY,
        pageX: mouseEvent.pageX,
        pageY: mouseEvent.pageY,
        screenX: mouseEvent.screenX,
        screenY: mouseEvent.screenY,
        ctrlKey: mouseEvent.ctrlKey,
        shiftKey: mouseEvent.shiftKey,
        altKey: mouseEvent.altKey,
        metaKey: mouseEvent.metaKey
    });

    activateOndblclick(): void {
        window.addEventListener("dblclick", this.#ondblclick);
    }

    deactivateOndblclick(): void {
        window.removeEventListener("dblclick", this.#ondblclick);
    }


    // Element - auxclick event

    #onauxclick = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeAuxClick", {
        button: mouseEvent.button,
        buttons: mouseEvent.buttons,
        movementX: mouseEvent.movementX,
        movementY: mouseEvent.movementY,
        clientX: mouseEvent.clientX,
        clientY: mouseEvent.clientY,
        offsetX: mouseEvent.offsetX,
        offsetY: mouseEvent.offsetY,
        pageX: mouseEvent.pageX,
        pageY: mouseEvent.pageY,
        screenX: mouseEvent.screenX,
        screenY: mouseEvent.screenY,
        ctrlKey: mouseEvent.ctrlKey,
        shiftKey: mouseEvent.shiftKey,
        altKey: mouseEvent.altKey,
        metaKey: mouseEvent.metaKey
    });

    activateOnauxclick(): void {
        window.addEventListener("auxclick", this.#onauxclick);
    }

    deactivateOnauxclick(): void {
        window.removeEventListener("auxclick", this.#onauxclick);
    }


    // Element - contextmenu event

    #oncontextmenu = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeContextMenu", {
        button: mouseEvent.button,
        buttons: mouseEvent.buttons,
        movementX: mouseEvent.movementX,
        movementY: mouseEvent.movementY,
        clientX: mouseEvent.clientX,
        clientY: mouseEvent.clientY,
        offsetX: mouseEvent.offsetX,
        offsetY: mouseEvent.offsetY,
        pageX: mouseEvent.pageX,
        pageY: mouseEvent.pageY,
        screenX: mouseEvent.screenX,
        screenY: mouseEvent.screenY,
        ctrlKey: mouseEvent.ctrlKey,
        shiftKey: mouseEvent.shiftKey,
        altKey: mouseEvent.altKey,
        metaKey: mouseEvent.metaKey
    });

    activateOncontextmenu(): void {
        window.addEventListener("contextmenu", this.#oncontextmenu);
    }

    deactivateOncontextmenu(): void {
        window.removeEventListener("contextmenu", this.#oncontextmenu);
    }


    // Element - mousedown event

    #onmousedown = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeMouseDown", {
        button: mouseEvent.button,
        buttons: mouseEvent.buttons,
        movementX: mouseEvent.movementX,
        movementY: mouseEvent.movementY,
        clientX: mouseEvent.clientX,
        clientY: mouseEvent.clientY,
        offsetX: mouseEvent.offsetX,
        offsetY: mouseEvent.offsetY,
        pageX: mouseEvent.pageX,
        pageY: mouseEvent.pageY,
        screenX: mouseEvent.screenX,
        screenY: mouseEvent.screenY,
        ctrlKey: mouseEvent.ctrlKey,
        shiftKey: mouseEvent.shiftKey,
        altKey: mouseEvent.altKey,
        metaKey: mouseEvent.metaKey
    });

    activateOnmousedown(): void {
        window.addEventListener("mousedown", this.#onmousedown);
    }

    deactivateOnmousedown(): void {
        window.removeEventListener("mousedown", this.#onmousedown);
    }


    // Element - mouseup event

    #onmouseup = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeMouseUp", {
        button: mouseEvent.button,
        buttons: mouseEvent.buttons,
        movementX: mouseEvent.movementX,
        movementY: mouseEvent.movementY,
        clientX: mouseEvent.clientX,
        clientY: mouseEvent.clientY,
        offsetX: mouseEvent.offsetX,
        offsetY: mouseEvent.offsetY,
        pageX: mouseEvent.pageX,
        pageY: mouseEvent.pageY,
        screenX: mouseEvent.screenX,
        screenY: mouseEvent.screenY,
        ctrlKey: mouseEvent.ctrlKey,
        shiftKey: mouseEvent.shiftKey,
        altKey: mouseEvent.altKey,
        metaKey: mouseEvent.metaKey
    });

    activateOnmouseup(): void {
        window.addEventListener("mouseup", this.#onmouseup);
    }

    deactivateOnmouseup(): void {
        window.removeEventListener("mouseup", this.#onmouseup);
    }


    // Element - wheel event

    #onwheel = (wheelEvent: WheelEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeWheel", {
        deltaX: wheelEvent.deltaX,
        deltaY: wheelEvent.deltaY,
        deltaZ: wheelEvent.deltaZ,
        deltaMode: wheelEvent.deltaMode
    });

    activateOnwheel(): void {
        window.addEventListener("wheel", this.#onwheel, { passive: true });
    }

    deactivateOnwheel(): void {
        window.removeEventListener("wheel", this.#onwheel);
    }


    // Element - mousemove event

    #onmousemove = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeMouseMove", {
        button: mouseEvent.button,
        buttons: mouseEvent.buttons,
        movementX: mouseEvent.movementX,
        movementY: mouseEvent.movementY,
        clientX: mouseEvent.clientX,
        clientY: mouseEvent.clientY,
        offsetX: mouseEvent.offsetX,
        offsetY: mouseEvent.offsetY,
        pageX: mouseEvent.pageX,
        pageY: mouseEvent.pageY,
        screenX: mouseEvent.screenX,
        screenY: mouseEvent.screenY,
        ctrlKey: mouseEvent.ctrlKey,
        shiftKey: mouseEvent.shiftKey,
        altKey: mouseEvent.altKey,
        metaKey: mouseEvent.metaKey
    });

    activateOnmousemove(): void {
        window.addEventListener("mousemove", this.#onmousemove);
    }

    deactivateOnmousemove(): void {
        window.removeEventListener("mousemove", this.#onmousemove);
    }


    // Element - mouseover event

    #onmouseover = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeMouseOver", {
        button: mouseEvent.button,
        buttons: mouseEvent.buttons,
        movementX: mouseEvent.movementX,
        movementY: mouseEvent.movementY,
        clientX: mouseEvent.clientX,
        clientY: mouseEvent.clientY,
        offsetX: mouseEvent.offsetX,
        offsetY: mouseEvent.offsetY,
        pageX: mouseEvent.pageX,
        pageY: mouseEvent.pageY,
        screenX: mouseEvent.screenX,
        screenY: mouseEvent.screenY,
        ctrlKey: mouseEvent.ctrlKey,
        shiftKey: mouseEvent.shiftKey,
        altKey: mouseEvent.altKey,
        metaKey: mouseEvent.metaKey
    });

    activateOnmouseover(): void {
        window.addEventListener("mouseover", this.#onmouseover);
    }

    deactivateOnmouseover(): void {
        window.removeEventListener("mouseover", this.#onmouseover);
    }


    // Element - mouseout event

    #onmouseout = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeMouseOut", {
        button: mouseEvent.button,
        buttons: mouseEvent.buttons,
        movementX: mouseEvent.movementX,
        movementY: mouseEvent.movementY,
        clientX: mouseEvent.clientX,
        clientY: mouseEvent.clientY,
        offsetX: mouseEvent.offsetX,
        offsetY: mouseEvent.offsetY,
        pageX: mouseEvent.pageX,
        pageY: mouseEvent.pageY,
        screenX: mouseEvent.screenX,
        screenY: mouseEvent.screenY,
        ctrlKey: mouseEvent.ctrlKey,
        shiftKey: mouseEvent.shiftKey,
        altKey: mouseEvent.altKey,
        metaKey: mouseEvent.metaKey
    });

    activateOnmouseout(): void {
        window.addEventListener("mouseout", this.#onmouseout);
    }

    deactivateOnmouseout(): void {
        window.removeEventListener("mouseout", this.#onmouseout);
    }


    // Element - mouseenter event

    #onmouseenter = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeMouseEnter", {
        button: mouseEvent.button,
        buttons: mouseEvent.buttons,
        movementX: mouseEvent.movementX,
        movementY: mouseEvent.movementY,
        clientX: mouseEvent.clientX,
        clientY: mouseEvent.clientY,
        offsetX: mouseEvent.offsetX,
        offsetY: mouseEvent.offsetY,
        pageX: mouseEvent.pageX,
        pageY: mouseEvent.pageY,
        screenX: mouseEvent.screenX,
        screenY: mouseEvent.screenY,
        ctrlKey: mouseEvent.ctrlKey,
        shiftKey: mouseEvent.shiftKey,
        altKey: mouseEvent.altKey,
        metaKey: mouseEvent.metaKey
    });

    activateOnmouseenter(): void {
        window.addEventListener("mouseenter", this.#onmouseenter);
    }

    deactivateOnmouseenter(): void {
        window.removeEventListener("mouseenter", this.#onmouseenter);
    }


    // Element - mouseleave event

    #onmouseleave = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeMouseLeave", {
        button: mouseEvent.button,
        buttons: mouseEvent.buttons,
        movementX: mouseEvent.movementX,
        movementY: mouseEvent.movementY,
        clientX: mouseEvent.clientX,
        clientY: mouseEvent.clientY,
        offsetX: mouseEvent.offsetX,
        offsetY: mouseEvent.offsetY,
        pageX: mouseEvent.pageX,
        pageY: mouseEvent.pageY,
        screenX: mouseEvent.screenX,
        screenY: mouseEvent.screenY,
        ctrlKey: mouseEvent.ctrlKey,
        shiftKey: mouseEvent.shiftKey,
        altKey: mouseEvent.altKey,
        metaKey: mouseEvent.metaKey
    });

    activateOnmouseleave(): void {
        window.addEventListener("mouseleave", this.#onmouseleave);
    }

    deactivateOnmouseleave(): void {
        window.removeEventListener("mouseleave", this.#onmouseleave);
    }



    // Element - touchstart event

    #ontouchstart = (touchEvent: TouchEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTouchStart", {
        touches: WindowAPI.#deconstructTouchList(touchEvent.touches),
        targetTouches: WindowAPI.#deconstructTouchList(touchEvent.targetTouches),
        changedTouches: WindowAPI.#deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    activateOntouchstart(): void {
        window.addEventListener("touchstart", this.#ontouchstart);
    }

    deactivateOntouchstart(): void {
        window.removeEventListener("touchstart", this.#ontouchstart);
    }


    // Element - touchend event

    #ontouchend = (touchEvent: TouchEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTouchEnd", {
        touches: WindowAPI.#deconstructTouchList(touchEvent.touches),
        targetTouches: WindowAPI.#deconstructTouchList(touchEvent.targetTouches),
        changedTouches: WindowAPI.#deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    activateOntouchend(): void {
        window.addEventListener("touchend", this.#ontouchend);
    }

    deactivateOntouchend(): void {
        window.removeEventListener("touchend", this.#ontouchend);
    }


    // Element - touchmove event

    #ontouchmove = (touchEvent: TouchEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTouchMove", {
        touches: WindowAPI.#deconstructTouchList(touchEvent.touches),
        targetTouches: WindowAPI.#deconstructTouchList(touchEvent.targetTouches),
        changedTouches: WindowAPI.#deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    activateOntouchmove(): void {
        window.addEventListener("touchmove", this.#ontouchmove);
    }

    deactivateOntouchmove(): void {
        window.removeEventListener("touchmove", this.#ontouchmove);
    }


    // Element - touchcancel event

    #ontouchcancel = (touchEvent: TouchEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTouchCancel", {
        touches: WindowAPI.#deconstructTouchList(touchEvent.touches),
        targetTouches: WindowAPI.#deconstructTouchList(touchEvent.targetTouches),
        changedTouches: WindowAPI.#deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    activateOntouchcancel(): void {
        window.addEventListener("touchcancel", this.#ontouchcancel);
    }

    deactivateOntouchcancel(): void {
        window.removeEventListener("touchcancel", this.#ontouchcancel);
    }



    // Element - pointerdown event

    #onpointerdown = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.#eventTrigger, "InvokePointerDown", {
        pointerId: pointerEvent.pointerId,
        persistentDeviceId: pointerEvent.persistentDeviceId ?? 0,
        pointerType: pointerEvent.pointerType ?? "",
        width: pointerEvent.width,
        height: pointerEvent.height,
        pressure: pointerEvent.pressure,
        tangentialPressure: pointerEvent.tangentialPressure,
        twist: pointerEvent.twist,
        tiltX: pointerEvent.tiltX,
        tiltY: pointerEvent.tiltY,
        altitudeAngle: pointerEvent.altitudeAngle,
        azimuthAngle: pointerEvent.azimuthAngle,
        isPrimary: pointerEvent.isPrimary,
        button: pointerEvent.button,
        buttons: pointerEvent.buttons,
        movementX: pointerEvent.movementX,
        movementY: pointerEvent.movementY,
        clientX: pointerEvent.clientX,
        clientY: pointerEvent.clientY,
        offsetX: pointerEvent.offsetX,
        offsetY: pointerEvent.offsetY,
        pageX: pointerEvent.pageX,
        pageY: pointerEvent.pageY,
        screenX: pointerEvent.screenX,
        screenY: pointerEvent.screenY,
        ctrlKey: pointerEvent.ctrlKey,
        shiftKey: pointerEvent.shiftKey,
        altKey: pointerEvent.altKey,
        metaKey: pointerEvent.metaKey
    });

    activateOnpointerdown(): void {
        window.addEventListener("pointerdown", this.#onpointerdown);
    }

    deactivateOnpointerdown(): void {
        window.removeEventListener("pointerdown", this.#onpointerdown);
    }


    // Element - pointerup event

    #onpointerup = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.#eventTrigger, "InvokePointerUp", {
        pointerId: pointerEvent.pointerId,
        persistentDeviceId: pointerEvent.persistentDeviceId ?? 0,
        pointerType: pointerEvent.pointerType ?? "",
        width: pointerEvent.width,
        height: pointerEvent.height,
        pressure: pointerEvent.pressure,
        tangentialPressure: pointerEvent.tangentialPressure,
        twist: pointerEvent.twist,
        tiltX: pointerEvent.tiltX,
        tiltY: pointerEvent.tiltY,
        altitudeAngle: pointerEvent.altitudeAngle,
        azimuthAngle: pointerEvent.azimuthAngle,
        isPrimary: pointerEvent.isPrimary,
        button: pointerEvent.button,
        buttons: pointerEvent.buttons,
        movementX: pointerEvent.movementX,
        movementY: pointerEvent.movementY,
        clientX: pointerEvent.clientX,
        clientY: pointerEvent.clientY,
        offsetX: pointerEvent.offsetX,
        offsetY: pointerEvent.offsetY,
        pageX: pointerEvent.pageX,
        pageY: pointerEvent.pageY,
        screenX: pointerEvent.screenX,
        screenY: pointerEvent.screenY,
        ctrlKey: pointerEvent.ctrlKey,
        shiftKey: pointerEvent.shiftKey,
        altKey: pointerEvent.altKey,
        metaKey: pointerEvent.metaKey
    });

    activateOnpointerup(): void {
        window.addEventListener("pointerup", this.#onpointerup);
    }

    deactivateOnpointerup(): void {
        window.removeEventListener("pointerup", this.#onpointerup);
    }


    // Element - pointermove event

    #onpointermove = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.#eventTrigger, "InvokePointerMove", {
        pointerId: pointerEvent.pointerId,
        persistentDeviceId: pointerEvent.persistentDeviceId ?? 0,
        pointerType: pointerEvent.pointerType ?? "",
        width: pointerEvent.width,
        height: pointerEvent.height,
        pressure: pointerEvent.pressure,
        tangentialPressure: pointerEvent.tangentialPressure,
        twist: pointerEvent.twist,
        tiltX: pointerEvent.tiltX,
        tiltY: pointerEvent.tiltY,
        altitudeAngle: pointerEvent.altitudeAngle,
        azimuthAngle: pointerEvent.azimuthAngle,
        isPrimary: pointerEvent.isPrimary,
        button: pointerEvent.button,
        buttons: pointerEvent.buttons,
        movementX: pointerEvent.movementX,
        movementY: pointerEvent.movementY,
        clientX: pointerEvent.clientX,
        clientY: pointerEvent.clientY,
        offsetX: pointerEvent.offsetX,
        offsetY: pointerEvent.offsetY,
        pageX: pointerEvent.pageX,
        pageY: pointerEvent.pageY,
        screenX: pointerEvent.screenX,
        screenY: pointerEvent.screenY,
        ctrlKey: pointerEvent.ctrlKey,
        shiftKey: pointerEvent.shiftKey,
        altKey: pointerEvent.altKey,
        metaKey: pointerEvent.metaKey
    });

    activateOnpointermove(): void {
        window.addEventListener("pointermove", this.#onpointermove);
    }

    deactivateOnpointermove(): void {
        window.removeEventListener("pointermove", this.#onpointermove);
    }


    // Element - pointerover event

    #onpointerover = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.#eventTrigger, "InvokePointerOver", {
        pointerId: pointerEvent.pointerId,
        persistentDeviceId: pointerEvent.persistentDeviceId ?? 0,
        pointerType: pointerEvent.pointerType ?? "",
        width: pointerEvent.width,
        height: pointerEvent.height,
        pressure: pointerEvent.pressure,
        tangentialPressure: pointerEvent.tangentialPressure,
        twist: pointerEvent.twist,
        tiltX: pointerEvent.tiltX,
        tiltY: pointerEvent.tiltY,
        altitudeAngle: pointerEvent.altitudeAngle,
        azimuthAngle: pointerEvent.azimuthAngle,
        isPrimary: pointerEvent.isPrimary,
        button: pointerEvent.button,
        buttons: pointerEvent.buttons,
        movementX: pointerEvent.movementX,
        movementY: pointerEvent.movementY,
        clientX: pointerEvent.clientX,
        clientY: pointerEvent.clientY,
        offsetX: pointerEvent.offsetX,
        offsetY: pointerEvent.offsetY,
        pageX: pointerEvent.pageX,
        pageY: pointerEvent.pageY,
        screenX: pointerEvent.screenX,
        screenY: pointerEvent.screenY,
        ctrlKey: pointerEvent.ctrlKey,
        shiftKey: pointerEvent.shiftKey,
        altKey: pointerEvent.altKey,
        metaKey: pointerEvent.metaKey
    });

    activateOnpointerover(): void {
        window.addEventListener("pointerover", this.#onpointerover);
    }

    deactivateOnpointerover(): void {
        window.removeEventListener("pointerover", this.#onpointerover);
    }


    // Element - pointerout event

    #onpointerout = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.#eventTrigger, "InvokePointerOut", {
        pointerId: pointerEvent.pointerId,
        persistentDeviceId: pointerEvent.persistentDeviceId ?? 0,
        pointerType: pointerEvent.pointerType ?? "",
        width: pointerEvent.width,
        height: pointerEvent.height,
        pressure: pointerEvent.pressure,
        tangentialPressure: pointerEvent.tangentialPressure,
        twist: pointerEvent.twist,
        tiltX: pointerEvent.tiltX,
        tiltY: pointerEvent.tiltY,
        altitudeAngle: pointerEvent.altitudeAngle,
        azimuthAngle: pointerEvent.azimuthAngle,
        isPrimary: pointerEvent.isPrimary,
        button: pointerEvent.button,
        buttons: pointerEvent.buttons,
        movementX: pointerEvent.movementX,
        movementY: pointerEvent.movementY,
        clientX: pointerEvent.clientX,
        clientY: pointerEvent.clientY,
        offsetX: pointerEvent.offsetX,
        offsetY: pointerEvent.offsetY,
        pageX: pointerEvent.pageX,
        pageY: pointerEvent.pageY,
        screenX: pointerEvent.screenX,
        screenY: pointerEvent.screenY,
        ctrlKey: pointerEvent.ctrlKey,
        shiftKey: pointerEvent.shiftKey,
        altKey: pointerEvent.altKey,
        metaKey: pointerEvent.metaKey
    });

    activateOnpointerout(): void {
        window.addEventListener("pointerout", this.#onpointerout);
    }

    deactivateOnpointerout(): void {
        window.removeEventListener("pointerout", this.#onpointerout);
    }


    // Element - pointerenter event

    #onpointerenter = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.#eventTrigger, "InvokePointerEnter", {
        pointerId: pointerEvent.pointerId,
        persistentDeviceId: pointerEvent.persistentDeviceId ?? 0,
        pointerType: pointerEvent.pointerType ?? "",
        width: pointerEvent.width,
        height: pointerEvent.height,
        pressure: pointerEvent.pressure,
        tangentialPressure: pointerEvent.tangentialPressure,
        twist: pointerEvent.twist,
        tiltX: pointerEvent.tiltX,
        tiltY: pointerEvent.tiltY,
        altitudeAngle: pointerEvent.altitudeAngle,
        azimuthAngle: pointerEvent.azimuthAngle,
        isPrimary: pointerEvent.isPrimary,
        button: pointerEvent.button,
        buttons: pointerEvent.buttons,
        movementX: pointerEvent.movementX,
        movementY: pointerEvent.movementY,
        clientX: pointerEvent.clientX,
        clientY: pointerEvent.clientY,
        offsetX: pointerEvent.offsetX,
        offsetY: pointerEvent.offsetY,
        pageX: pointerEvent.pageX,
        pageY: pointerEvent.pageY,
        screenX: pointerEvent.screenX,
        screenY: pointerEvent.screenY,
        ctrlKey: pointerEvent.ctrlKey,
        shiftKey: pointerEvent.shiftKey,
        altKey: pointerEvent.altKey,
        metaKey: pointerEvent.metaKey
    });

    activateOnpointerenter(): void {
        window.addEventListener("pointerenter", this.#onpointerenter);
    }

    deactivateOnpointerenter(): void {
        window.removeEventListener("pointerenter", this.#onpointerenter);
    }


    // Element - pointerleave event

    #onpointerleave = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.#eventTrigger, "InvokePointerLeave", {
        pointerId: pointerEvent.pointerId,
        persistentDeviceId: pointerEvent.persistentDeviceId ?? 0,
        pointerType: pointerEvent.pointerType ?? "",
        width: pointerEvent.width,
        height: pointerEvent.height,
        pressure: pointerEvent.pressure,
        tangentialPressure: pointerEvent.tangentialPressure,
        twist: pointerEvent.twist,
        tiltX: pointerEvent.tiltX,
        tiltY: pointerEvent.tiltY,
        altitudeAngle: pointerEvent.altitudeAngle,
        azimuthAngle: pointerEvent.azimuthAngle,
        isPrimary: pointerEvent.isPrimary,
        button: pointerEvent.button,
        buttons: pointerEvent.buttons,
        movementX: pointerEvent.movementX,
        movementY: pointerEvent.movementY,
        clientX: pointerEvent.clientX,
        clientY: pointerEvent.clientY,
        offsetX: pointerEvent.offsetX,
        offsetY: pointerEvent.offsetY,
        pageX: pointerEvent.pageX,
        pageY: pointerEvent.pageY,
        screenX: pointerEvent.screenX,
        screenY: pointerEvent.screenY,
        ctrlKey: pointerEvent.ctrlKey,
        shiftKey: pointerEvent.shiftKey,
        altKey: pointerEvent.altKey,
        metaKey: pointerEvent.metaKey
    });

    activateOnpointerleave(): void {
        window.addEventListener("pointerleave", this.#onpointerleave);
    }

    deactivateOnpointerleave(): void {
        window.removeEventListener("pointerleave", this.#onpointerleave);
    }


    // Element - pointercancel event

    #onpointercancel = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.#eventTrigger, "InvokePointerCancel", {
        pointerId: pointerEvent.pointerId,
        persistentDeviceId: pointerEvent.persistentDeviceId ?? 0,
        pointerType: pointerEvent.pointerType ?? "",
        width: pointerEvent.width,
        height: pointerEvent.height,
        pressure: pointerEvent.pressure,
        tangentialPressure: pointerEvent.tangentialPressure,
        twist: pointerEvent.twist,
        tiltX: pointerEvent.tiltX,
        tiltY: pointerEvent.tiltY,
        altitudeAngle: pointerEvent.altitudeAngle,
        azimuthAngle: pointerEvent.azimuthAngle,
        isPrimary: pointerEvent.isPrimary,
        button: pointerEvent.button,
        buttons: pointerEvent.buttons,
        movementX: pointerEvent.movementX,
        movementY: pointerEvent.movementY,
        clientX: pointerEvent.clientX,
        clientY: pointerEvent.clientY,
        offsetX: pointerEvent.offsetX,
        offsetY: pointerEvent.offsetY,
        pageX: pointerEvent.pageX,
        pageY: pointerEvent.pageY,
        screenX: pointerEvent.screenX,
        screenY: pointerEvent.screenY,
        ctrlKey: pointerEvent.ctrlKey,
        shiftKey: pointerEvent.shiftKey,
        altKey: pointerEvent.altKey,
        metaKey: pointerEvent.metaKey
    });

    activateOnpointercancel(): void {
        window.addEventListener("pointercancel", this.#onpointercancel);
    }

    deactivateOnpointercancel(): void {
        window.removeEventListener("pointercancel", this.#onpointercancel);
    }


    // Element - pointerrawupdate event

    #onpointerrawupdate = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.#eventTrigger, "InvokePointerRawUpdate", {
        pointerId: pointerEvent.pointerId,
        persistentDeviceId: pointerEvent.persistentDeviceId ?? 0,
        pointerType: pointerEvent.pointerType ?? "",
        width: pointerEvent.width,
        height: pointerEvent.height,
        pressure: pointerEvent.pressure,
        tangentialPressure: pointerEvent.tangentialPressure,
        twist: pointerEvent.twist,
        tiltX: pointerEvent.tiltX,
        tiltY: pointerEvent.tiltY,
        altitudeAngle: pointerEvent.altitudeAngle,
        azimuthAngle: pointerEvent.azimuthAngle,
        isPrimary: pointerEvent.isPrimary,
        button: pointerEvent.button,
        buttons: pointerEvent.buttons,
        movementX: pointerEvent.movementX,
        movementY: pointerEvent.movementY,
        clientX: pointerEvent.clientX,
        clientY: pointerEvent.clientY,
        offsetX: pointerEvent.offsetX,
        offsetY: pointerEvent.offsetY,
        pageX: pointerEvent.pageX,
        pageY: pointerEvent.pageY,
        screenX: pointerEvent.screenX,
        screenY: pointerEvent.screenY,
        ctrlKey: pointerEvent.ctrlKey,
        shiftKey: pointerEvent.shiftKey,
        altKey: pointerEvent.altKey,
        metaKey: pointerEvent.metaKey
    });

    activateOnpointerrawupdate(): void {
        window.addEventListener("pointerrawupdate", this.#onpointerrawupdate);
    }

    deactivateOnpointerrawupdate(): void {
        window.removeEventListener("pointerrawupdate", this.#onpointerrawupdate);
    }


    // Element - gotpointercapture event

    #ongotpointercapture = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.#eventTrigger, "InvokeGotPointerCapture", {
        pointerId: pointerEvent.pointerId,
        persistentDeviceId: pointerEvent.persistentDeviceId ?? 0,
        pointerType: pointerEvent.pointerType ?? "",
        width: pointerEvent.width,
        height: pointerEvent.height,
        pressure: pointerEvent.pressure,
        tangentialPressure: pointerEvent.tangentialPressure,
        twist: pointerEvent.twist,
        tiltX: pointerEvent.tiltX,
        tiltY: pointerEvent.tiltY,
        altitudeAngle: pointerEvent.altitudeAngle,
        azimuthAngle: pointerEvent.azimuthAngle,
        isPrimary: pointerEvent.isPrimary,
        button: pointerEvent.button,
        buttons: pointerEvent.buttons,
        movementX: pointerEvent.movementX,
        movementY: pointerEvent.movementY,
        clientX: pointerEvent.clientX,
        clientY: pointerEvent.clientY,
        offsetX: pointerEvent.offsetX,
        offsetY: pointerEvent.offsetY,
        pageX: pointerEvent.pageX,
        pageY: pointerEvent.pageY,
        screenX: pointerEvent.screenX,
        screenY: pointerEvent.screenY,
        ctrlKey: pointerEvent.ctrlKey,
        shiftKey: pointerEvent.shiftKey,
        altKey: pointerEvent.altKey,
        metaKey: pointerEvent.metaKey
    });

    activateOngotpointercapture(): void {
        window.addEventListener("gotpointercapture", this.#ongotpointercapture);
    }

    deactivateOngotpointercapture(): void {
        window.removeEventListener("gotpointercapture", this.#ongotpointercapture);
    }


    // Element - lostpointercapture event

    #onlostpointercapture = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.#eventTrigger, "InvokeLostPointerCapture", {
        pointerId: pointerEvent.pointerId,
        persistentDeviceId: pointerEvent.persistentDeviceId ?? 0,
        pointerType: pointerEvent.pointerType ?? "",
        width: pointerEvent.width,
        height: pointerEvent.height,
        pressure: pointerEvent.pressure,
        tangentialPressure: pointerEvent.tangentialPressure,
        twist: pointerEvent.twist,
        tiltX: pointerEvent.tiltX,
        tiltY: pointerEvent.tiltY,
        altitudeAngle: pointerEvent.altitudeAngle,
        azimuthAngle: pointerEvent.azimuthAngle,
        isPrimary: pointerEvent.isPrimary,
        button: pointerEvent.button,
        buttons: pointerEvent.buttons,
        movementX: pointerEvent.movementX,
        movementY: pointerEvent.movementY,
        clientX: pointerEvent.clientX,
        clientY: pointerEvent.clientY,
        offsetX: pointerEvent.offsetX,
        offsetY: pointerEvent.offsetY,
        pageX: pointerEvent.pageX,
        pageY: pointerEvent.pageY,
        screenX: pointerEvent.screenX,
        screenY: pointerEvent.screenY,
        ctrlKey: pointerEvent.ctrlKey,
        shiftKey: pointerEvent.shiftKey,
        altKey: pointerEvent.altKey,
        metaKey: pointerEvent.metaKey
    });

    activateOnlostpointercapture(): void {
        window.addEventListener("lostpointercapture", this.#onlostpointercapture);
    }

    deactivateOnlostpointercapture(): void {
        window.removeEventListener("lostpointercapture", this.#onlostpointercapture);
    }



    // Element - focusin event

    #onfocusin = () => BlazorInvoke.method(this.#eventTrigger, "InvokeFocusIn");

    activateOnfocusin(): void {
        window.addEventListener("focusin", this.#onfocusin);
    }

    deactivateOnfocusin(): void {
        window.removeEventListener("focusin", this.#onfocusin);
    }


    // Element - focusout event

    #onfocusout = () => BlazorInvoke.method(this.#eventTrigger, "InvokeFocusOut");

    activateOnfocusout(): void {
        window.addEventListener("focusout", this.#onfocusout);
    }

    deactivateOnfocusout(): void {
        window.removeEventListener("focusout", this.#onfocusout);
    }



    // Element - copy event

    #oncopy = () => BlazorInvoke.method(this.#eventTrigger, "InvokeCopy");

    activateOncopy(): void {
        window.addEventListener("copy", this.#oncopy);
    }

    deactivateOncopy(): void {
        window.removeEventListener("copy", this.#oncopy);
    }


    // Element - paste event

    #onpaste = () => BlazorInvoke.method(this.#eventTrigger, "InvokePaste");

    activateOnpaste(): void {
        window.addEventListener("paste", this.#onpaste);
    }

    deactivateOnpaste(): void {
        window.removeEventListener("paste", this.#onpaste);
    }


    // Element - cut event

    #oncut = () => BlazorInvoke.method(this.#eventTrigger, "InvokeCut");

    activateOncut(): void {
        window.addEventListener("cut", this.#oncut);
    }

    deactivateOncut(): void {
        window.removeEventListener("cut", this.#oncut);
    }



    // Element - transitionstart event

    #ontransitionstart = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTransitionStart", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    activateOntransitionstart(): void {
        window.addEventListener("transitionstart", this.#ontransitionstart);
    }

    deactivateOntransitionstart(): void {
        window.removeEventListener("transitionstart", this.#ontransitionstart);
    }


    // Element - transitionend event

    #ontransitionend = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTransitionEnd", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    activateOntransitionend(): void {
        window.addEventListener("transitionend", this.#ontransitionend);
    }

    deactivateOntransitionend(): void {
        window.removeEventListener("transitionend", this.#ontransitionend);
    }


    // Element - transitionrun event

    #ontransitionrun = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTransitionRun", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    activateOntransitionrun(): void {
        window.addEventListener("transitionrun", this.#ontransitionrun);
    }

    deactivateOntransitionrun(): void {
        window.removeEventListener("transitionrun", this.#ontransitionrun);
    }


    // Element - transitioncancel event

    #ontransitioncancel = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTransitionCancel", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    activateOntransitioncancel(): void {
        window.addEventListener("transitioncancel", this.#ontransitioncancel);
    }

    deactivateOntransitioncancel(): void {
        window.removeEventListener("transitioncancel", this.#ontransitioncancel);
    }



    // Element - animationstart event

    #onanimationstart = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeAnimationStart", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    activateOnanimationstart(): void {
        window.addEventListener("animationstart", this.#onanimationstart);
    }

    deactivateOnanimationstart(): void {
        window.removeEventListener("animationstart", this.#onanimationstart);
    }


    // Element - animationend event

    #onanimationend = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeAnimationEnd", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    activateOnanimationend(): void {
        window.addEventListener("animationend", this.#onanimationend);
    }

    deactivateOnanimationend(): void {
        window.removeEventListener("animationend", this.#onanimationend);
    }


    // Element - animationiteration event

    #onanimationiteration = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeAnimationIteration", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    activateOnanimationiteration(): void {
        window.addEventListener("animationiteration", this.#onanimationiteration);
    }

    deactivateOnanimationiteration(): void {
        window.removeEventListener("animationiteration", this.#onanimationiteration);
    }


    // Element - animationcancel event

    #onanimationcancel = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeAnimationCancel", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    activateOnanimationcancel(): void {
        window.addEventListener("animationcancel", this.#onanimationcancel);
    }

    deactivateOnanimationcancel(): void {
        window.removeEventListener("animationcancel", this.#onanimationcancel);
    }



    // HTMLMediaElement - canplay event

    #oncanplay = () => BlazorInvoke.method(this.#eventTrigger, "InvokeCanPlay");

    activateOncanplay(): void {
        window.addEventListener("canplay", this.#oncanplay);
    }

    deactivateOncanplay(): void {
        window.removeEventListener("canplay", this.#oncanplay);
    }


    // HTMLMediaElement - canplaythrough event

    #oncanplaythrough = () => BlazorInvoke.method(this.#eventTrigger, "InvokeCanPlayThrough");

    activateOncanplaythrough(): void {
        window.addEventListener("canplaythrough", this.#oncanplaythrough);
    }

    deactivateOncanplaythrough(): void {
        window.removeEventListener("canplaythrough", this.#oncanplaythrough);
    }


    // HTMLMediaElement - playing event

    #onplaying = () => BlazorInvoke.method(this.#eventTrigger, "InvokePlaying");

    activateOnplaying(): void {
        window.addEventListener("playing", this.#onplaying);
    }

    deactivateOnplaying(): void {
        window.removeEventListener("playing", this.#onplaying);
    }


    // Data

    // HTMLMediaElement - loadstart event

    #onloadstart = () => BlazorInvoke.method(this.#eventTrigger, "InvokeLoadStart");

    activateOnloadstart(): void {
        window.addEventListener("loadstart", this.#onloadstart);
    }

    deactivateOnloadstart(): void {
        window.removeEventListener("loadstart", this.#onloadstart);
    }


    // HTMLMediaElement - progress event

    #onprogress = () => BlazorInvoke.method(this.#eventTrigger, "InvokeProgress");

    activateOnprogress(): void {
        window.addEventListener("progress", this.#onprogress);
    }

    deactivateOnprogress(): void {
        window.removeEventListener("progress", this.#onprogress);
    }


    // HTMLMediaElement - loadeddata event

    #onloadeddata = () => BlazorInvoke.method(this.#eventTrigger, "InvokeLoadedData");

    activateOnloadeddata(): void {
        window.addEventListener("loadeddata", this.#onloadeddata);
    }

    deactivateOnloadeddata(): void {
        window.removeEventListener("loadeddata", this.#onloadeddata);
    }


    // HTMLMediaElement - loadedmetadata event

    #onloadedmetadata = () => BlazorInvoke.method(this.#eventTrigger, "InvokeLoadedMetadata");

    activateOnloadedmetadata(): void {
        window.addEventListener("loadedmetadata", this.#onloadedmetadata);
    }

    deactivateOnloadedmetadata(): void {
        window.removeEventListener("loadedmetadata", this.#onloadedmetadata);
    }


    // HTMLMediaElement - stalled event

    #onstalled = () => BlazorInvoke.method(this.#eventTrigger, "InvokeStalled");

    activateOnstalled(): void {
        window.addEventListener("stalled", this.#onstalled);
    }

    deactivateOnstalled(): void {
        window.removeEventListener("stalled", this.#onstalled);
    }


    // HTMLMediaElement - suspend event

    #onsuspend = () => BlazorInvoke.method(this.#eventTrigger, "InvokeSuspend");

    activateOnsuspend(): void {
        window.addEventListener("suspend", this.#onsuspend);
    }

    deactivateOnsuspend(): void {
        window.removeEventListener("suspend", this.#onsuspend);
    }


    // HTMLMediaElement - waiting event

    #onwaiting = () => BlazorInvoke.method(this.#eventTrigger, "InvokeWaiting");

    activateOnwaiting(): void {
        window.addEventListener("waiting", this.#onwaiting);
    }

    deactivateOnwaiting(): void {
        window.removeEventListener("waiting", this.#onwaiting);
    }


    // HTMLMediaElement - abort event

    #onabort = () => BlazorInvoke.method(this.#eventTrigger, "InvokeAbort");

    activateOnabort(): void {
        window.addEventListener("abort", this.#onabort);
    }

    deactivateOnabort(): void {
        window.removeEventListener("abort", this.#onabort);
    }


    // HTMLMediaElement - emptied event

    #onemptied = () => BlazorInvoke.method(this.#eventTrigger, "InvokeEmptied");

    activateOnemptied(): void {
        window.addEventListener("emptied", this.#onemptied);
    }

    deactivateOnemptied(): void {
        window.removeEventListener("emptied", this.#onemptied);
    }


    // Timing

    // HTMLMediaElement - play event

    #onplay = () => BlazorInvoke.method(this.#eventTrigger, "InvokePlay");

    activateOnplay(): void {
        window.addEventListener("play", this.#onplay);
    }

    deactivateOnplay(): void {
        window.removeEventListener("play", this.#onplay);
    }


    // HTMLMediaElement - pause event

    #onpause = () => BlazorInvoke.method(this.#eventTrigger, "InvokePause");

    activateOnpause(): void {
        window.addEventListener("pause", this.#onpause);
    }

    deactivateOnpause(): void {
        window.removeEventListener("pause", this.#onpause);
    }


    // HTMLMediaElement - ended event

    #onended = () => BlazorInvoke.method(this.#eventTrigger, "InvokeEnded");

    activateOnended(): void {
        window.addEventListener("ended", this.#onended);
    }

    deactivateOnended(): void {
        window.removeEventListener("ended", this.#onended);
    }


    // HTMLMediaElement - seeking event

    #onseeking = () => BlazorInvoke.method(this.#eventTrigger, "InvokeSeeking");

    activateOnseeking(): void {
        window.addEventListener("seeking", this.#onseeking);
    }

    deactivateOnseeking(): void {
        window.removeEventListener("seeking", this.#onseeking);
    }


    // HTMLMediaElement - seeked event

    #onseeked = () => BlazorInvoke.method(this.#eventTrigger, "InvokeSeeked");

    activateOnseeked(): void {
        window.addEventListener("seeked", this.#onseeked);
    }

    deactivateOnseeked(): void {
        window.removeEventListener("seeked", this.#onseeked);
    }


    // HTMLMediaElement - timeupdate event

    #ontimeupdate = () => BlazorInvoke.method(this.#eventTrigger, "InvokeTimeUpdate");

    activateOntimeupdate(): void {
        window.addEventListener("timeupdate", this.#ontimeupdate);
    }

    deactivateOntimeupdate(): void {
        window.removeEventListener("timeupdate", this.#ontimeupdate);
    }


    // Setting

    // HTMLMediaElement - volumechange event

    #onvolumechange = () => BlazorInvoke.method(this.#eventTrigger, "InvokeVolumeChange");

    activateOnvolumechange(): void {
        window.addEventListener("volumechange", this.#onvolumechange);
    }

    deactivateOnvolumechange(): void {
        window.removeEventListener("volumechange", this.#onvolumechange);
    }


    // HTMLMediaElement - ratechange event

    #onratechange = () => BlazorInvoke.method(this.#eventTrigger, "InvokeRateChange");

    activateOnratechange(): void {
        window.addEventListener("ratechange", this.#onratechange);
    }

    deactivateOnratechange(): void {
        window.removeEventListener("ratechange", this.#onratechange);
    }


    // HTMLMediaElement - durationchange event

    #ondurationchange = () => BlazorInvoke.method(this.#eventTrigger, "InvokeDurationChange");

    activateOndurationchange(): void {
        window.addEventListener("durationchange", this.#ondurationchange);
    }

    deactivateOndurationchange(): void {
        window.removeEventListener("durationchange", this.#ondurationchange);
    }



    // HTMLDialogElement - close event

    #onclose = () => BlazorInvoke.method(this.#eventTrigger, "InvokeClose");

    activateOnclose(): void {
        window.addEventListener("close", this.#onclose);
    }

    deactivateOnclose(): void {
        window.removeEventListener("close", this.#onclose);
    }


    // HTMLDialogElement - cancel event

    #oncancel = () => BlazorInvoke.method(this.#eventTrigger, "InvokeCancel");

    activateOncancel(): void {
        window.addEventListener("cancel", this.#oncancel);
    }

    deactivateOncancel(): void {
        window.removeEventListener("cancel", this.#oncancel);
    }
}
