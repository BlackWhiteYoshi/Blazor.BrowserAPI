import { HTMLElementAPI } from "../HTMLElement/HTMLElement";
import { FileAPI } from "../FileSystem/File/File";
import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class WindowAPI {
    private window: Window;

    public constructor(window: Window) {
        this.window = window;
    }


    // properties

    public static getInnerWidth(instance: WindowAPI | null): number {
        return (instance ? instance.window : window).innerWidth;
    }

    public static getInnerHeight(instance: WindowAPI | null): number {
        return (instance ? instance.window : window).innerHeight;
    }

    public static getOuterWidth(instance: WindowAPI | null): number {
        return (instance ? instance.window : window).outerWidth;
    }

    public static getOuterHeight(instance: WindowAPI | null): number {
        return (instance ? instance.window : window).outerHeight;
    }

    public static getDevicePixelRatio(instance: WindowAPI | null): number {
        return (instance ? instance.window : window).devicePixelRatio;
    }


    public static getScrollX(instance: WindowAPI | null): number {
        return (instance ? instance.window : window).scrollX;
    }

    public static getScrollY(instance: WindowAPI | null): number {
        return (instance ? instance.window : window).scrollY;
    }

    public static getScreenX(instance: WindowAPI | null): number {
        return (instance ? instance.window : window).screenX;
    }

    public static getScreenY(instance: WindowAPI | null): number {
        return (instance ? instance.window : window).screenY;
    }


    public static getOrigin(instance: WindowAPI | null): string {
        return (instance ? instance.window : window).origin;
    }

    public static getName(instance: WindowAPI | null): string {
        return (instance ? instance.window : window).name;
    }

    public static setName(instance: WindowAPI | null, value: string): void {
        (instance ? instance.window : window).name = value;
    }


    public static getClosed(instance: WindowAPI | null): boolean {
        return (instance ? instance.window : window).closed;
    }

    public static getCredentialless(instance: WindowAPI | null): boolean {
        return (<Window & typeof globalThis & { credentialless: boolean; }>(instance ? instance.window : window)).credentialless;
    }

    public static getCrossOriginIsolated(instance: WindowAPI | null): boolean {
        return (instance ? instance.window : window).crossOriginIsolated;
    }

    public static getIsSecureContext(instance: WindowAPI | null): boolean {
        return (instance ? instance.window : window).isSecureContext;
    }

    public static getOriginAgentCluster(instance: WindowAPI | null): boolean {
        return (<Window & typeof globalThis & { originAgentCluster: boolean; }>(instance ? instance.window : window)).originAgentCluster;
    }

    public static getMenubar(instance: WindowAPI | null): boolean {
        return (instance ? instance.window : window).menubar.visible;
    }


    public static getFrameElement(instance: WindowAPI | null): [HTMLElementAPI] | [null] {
        const result = (instance ? instance.window : window).frameElement;
        if (result)
            return [new HTMLElementAPI(<HTMLElement>frameElement)];
        else
            return [null];
    }


    // methods

    public static open(instance: WindowAPI | null, url?: string | URL, target?: string, features?: string): [WindowAPI] | [null] {
        const result = (instance ? instance.window : window).open(url, target, features);
        if (result)
            return [DotNet.createJSObjectReference(new WindowAPI(result))];
        else
            return [null];
    }

    public static close(instance: WindowAPI | null): void {
        (instance ? instance.window : window).close();
    }

    public static stop(instance: WindowAPI | null): void {
        (instance ? instance.window : window).stop();
    }

    public static focus(instance: WindowAPI | null): void {
        (instance ? instance.window : window).focus();
    }

    public static print(instance: WindowAPI | null): void {
        (instance ? instance.window : window).print();
    }

    public static reportError(instance: WindowAPI | null, error: any): void {
        (instance ? instance.window : window).reportError(error);
    }

    public static prompt(instance: WindowAPI | null, message: string | null, defaultValue: string | null): string | null {
        return (instance ? instance.window : window).prompt(message ?? undefined, defaultValue ?? undefined);
    }

    public static confirm(instance: WindowAPI | null, message: string | null): boolean {
        return (instance ? instance.window : window).confirm(message ?? undefined);
    }

    public static alert(instance: WindowAPI | null, message: string | null): void {
        (instance ? instance.window : window).alert(message ?? undefined);
    }


    public static moveBy(instance: WindowAPI | null, deltaX: number, deltaY: number): void {
        (instance ? instance.window : window).moveBy(deltaX, deltaY);
    }

    public static moveTo(instance: WindowAPI | null, x: number, y: number): void {
        (instance ? instance.window : window).moveTo(x, y);
    }

    public static resizeBy(instance: WindowAPI | null, xDelta: number, yDelta: number): void {
        (instance ? instance.window : window).resizeBy(xDelta, yDelta);
    }

    public static resizeTo(instance: WindowAPI | null, width: number, height: number): void {
        (instance ? instance.window : window).resizeTo(width, height);
    }

    public static scroll(instance: WindowAPI | null, left: number, top: number, behavior: ScrollBehavior | null): void {
        if (!behavior)
            (instance ? instance.window : window).scroll(left, top);
        else
            (instance ? instance.window : window).scroll({ left, top, behavior });
    }

    public static scrollTo(instance: WindowAPI | null, left: number, top: number, behavior: ScrollBehavior | null): void {
        WindowAPI.scroll(instance, left, top, behavior);
    }

    public static scrollBy(instance: WindowAPI | null, deltaX: number, deltaY: number, behavior: ScrollBehavior | null): void {
        if (!behavior)
            (instance ? instance.window : window).scrollBy(deltaX, deltaY);
        else
            (instance ? instance.window : window).scrollBy({ left: deltaX, top: deltaY, behavior });
    }


    public static setTimeout(instance: WindowAPI | null, callback: DotNet.DotNetObject, delay: number): number {
        return (instance ? instance.window : window).setTimeout(() => BlazorInvoke.method(callback, "Handler"), delay);
    }

    public static clearTimeout(instance: WindowAPI | null, id: number): void {
        (instance ? instance.window : window).clearTimeout(id);
    }

    public static setInterval(instance: WindowAPI | null, callback: DotNet.DotNetObject, delay: number): number {
        return (instance ? instance.window : window).setInterval(() => BlazorInvoke.method(callback, "Handler"), delay);
    }

    public static clearInterval(instance: WindowAPI | null, id: number): void {
        (instance ? instance.window : window).clearInterval(id);
    }

    public static requestAnimationFrame(instance: WindowAPI | null, callback: DotNet.DotNetObject): number {
        return (instance ? instance.window : window).requestAnimationFrame((timestamp: number) => BlazorInvoke.method(callback, "Handler", timestamp));
    }

    public static cancelAnimationFrame(instance: WindowAPI | null, handle: number): void {
        (instance ? instance.window : window).cancelAnimationFrame(handle);
    }

    public static requestIdleCallback(instance: WindowAPI | null, callback: DotNet.DotNetObject, timeout: number | null): number {
        return (instance ? instance.window : window).requestIdleCallback(() => BlazorInvoke.method(callback, "Handler"), { timeout: timeout ?? undefined });
    }

    public static cancelIdleCallback(instance: WindowAPI | null, handle: number): void {
        (instance ? instance.window : window).cancelIdleCallback(handle);
    }

    public static queueMicrotask(instance: WindowAPI | null, callback: DotNet.DotNetObject): void {
        (instance ? instance.window : window).queueMicrotask(() => BlazorInvoke.method(callback, "Handler"));
    }


    public static atob(instance: WindowAPI | null, base64: string): string {
        return (instance ? instance.window : window).atob(base64);
    }

    public static btoa(instance: WindowAPI | null, ascii: string): string {
        return (instance ? instance.window : window).btoa(ascii);
    }

    public static postMessage(instance: WindowAPI | null, message: any, targetOrigin: string): void {
        (instance ? instance.window : window).postMessage(message, targetOrigin);
    }

    public static structuredClone<T>(instance: WindowAPI | null, value: T): T {
        return (instance ? instance.window : window).structuredClone(value);
    }


    // events


    private eventTrigger: DotNet.DotNetObject;

    public static createInstanceAndInitEvents(eventTrigger: DotNet.DotNetObject): WindowAPI {
        const instance = new WindowAPI(window);
        instance.eventTrigger = eventTrigger;
        return instance;
    }

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    /** Util function for input events. If the parameter is of type "InputEvent", it gets deconstructed. If it is of type "Event", inputType is null. */
    private static deconstructInputEvent(event: InputEvent | Event): [string | null, string | null, boolean] {
        if (event instanceof InputEvent)
            return [event.data, event.inputType, event.isComposing];
        else
            return [null, null, false];
    }

    /** Util function for drag events. The event parameter is of type "DragEvent" and that has a property "dataTransfer", it gets deconstructed and returned. */
    private static deconstructDataTransfer(data: DataTransfer | null): [string, string, readonly string[], FileAPI[]] {
        if (data !== null)
            return [data.dropEffect, data.effectAllowed, data.types, [...data.files].map(file => DotNet.createJSObjectReference(new FileAPI(file)))];
        else
            return ["", "", [], []];
    }

    /** Util function for touch events. The "TouchEvent" has some properties of type "TouchList", it gets converted to an array with serializable objects. */
    private static deconstructTouchList(touchList: TouchList): { identifier: number, clientX: number, clientY: number, pageX: number, pageY: number, screenX: number, screenY: number, radiusX: number, radiusY: number, rotationAngle: number, force: number; }[] {
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

    private onerror = (error: Event) => BlazorInvoke.method(this.eventTrigger, "InvokeError", error);

    public activateOnerror(): void {
        this.window.addEventListener("error", this.onerror);
    }

    public deactivateOnerror(): void {
        this.window.removeEventListener("error", this.onerror);
    }


    // Window - languagechange event

    private onlanguagechange = () => BlazorInvoke.method(this.eventTrigger, "InvokeLanguageChange");

    public activateOnlanguagechange(): void {
        this.window.addEventListener("languagechange", this.onlanguagechange);
    }

    public deactivateOnlanguagechange(): void {
        this.window.removeEventListener("languagechange", this.onlanguagechange);
    }


    // Window - resize event

    private onresize = () => BlazorInvoke.method(this.eventTrigger, "InvokeResize");

    public activateOnresize(): void {
        this.window.addEventListener("resize", this.onresize);
    }

    public deactivateOnresize(): void {
        this.window.removeEventListener("resize", this.onresize);
    }


    // Window - storage event

    private onstorage = (event: StorageEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeStorage", {
        url: event.url,
        key: event.key,
        newValue: event.newValue,
        oldValue: event.oldValue
    });

    public activateOnstorage(): void {
        this.window.addEventListener("storage", this.onstorage);
    }

    public deactivateOnstorage(): void {
        this.window.removeEventListener("storage", this.onstorage);
    }


    // Window - focus event

    private onfocus = () => BlazorInvoke.method(this.eventTrigger, "InvokeFocus");

    public activateOnfocus(): void {
        this.window.addEventListener("focus", this.onfocus);
    }

    public deactivateOnfocus(): void {
        this.window.removeEventListener("focus", this.onfocus);
    }


    // Window - blur event

    private onblur = () => BlazorInvoke.method(this.eventTrigger, "InvokeBlur");

    public activateOnblur(): void {
        this.window.addEventListener("blur", this.onblur);
    }

    public deactivateOnblur(): void {
        this.window.removeEventListener("blur", this.onblur);
    }


    // load event

    private onload = () => BlazorInvoke.method(this.eventTrigger, "InvokeLoad");

    public activateOnload(): void {
        window.addEventListener("load", this.onload);
    }

    public deactivateOnload(): void {
        window.removeEventListener("load", this.onload);
    }


    // beforeunload event

    private onbeforeunload = () => BlazorInvoke.method(this.eventTrigger, "InvokeBeforeUnload");

    public activateOnbeforeunload(): void {
        window.addEventListener("beforeunload", this.onbeforeunload);
    }

    public deactivateOnbeforeunload(): void {
        window.removeEventListener("beforeunload", this.onbeforeunload);
    }


    // appinstalled event

    private onappinstalled = () => BlazorInvoke.method(this.eventTrigger, "InvokeAppInstalled");

    public activateOnappinstalled(): void {
        window.addEventListener("appinstalled", this.onappinstalled);
    }

    public deactivateOnappinstalled(): void {
        window.removeEventListener("appinstalled", this.onappinstalled);
    }


    // beforeinstallprompt event

    private onbeforeinstallprompt = () => BlazorInvoke.method(this.eventTrigger, "InvokeBeforeInstallPrompt");

    public activateOnbeforeinstallprompt(): void {
        window.addEventListener("beforeinstallprompt", this.onbeforeinstallprompt);
    }

    public deactivateOnbeforeinstallprompt(): void {
        window.removeEventListener("beforeinstallprompt", this.onbeforeinstallprompt);
    }


    // message event

    private onmessage = (event: MessageEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeMessage", event.data, event.origin, event.lastEventId);

    public activateOnmessage(): void {
        window.addEventListener("message", this.onmessage);
    }

    public deactivateOnmessage(): void {
        window.removeEventListener("message", this.onmessage);
    }


    // messageerror event

    private onmessageerror = (event: MessageEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeMessageError", event.data, event.origin, event.lastEventId);

    public activateOnmessageerror(): void {
        window.addEventListener("messageerror", this.onmessageerror);
    }

    public deactivateOnmessageerror(): void {
        window.removeEventListener("messageerror", this.onmessageerror);
    }


    // afterprint event

    private onafterprint = () => BlazorInvoke.method(this.eventTrigger, "InvokeAfterPrint");

    public activateOnafterprint(): void {
        window.addEventListener("afterprint", this.onafterprint);
    }

    public deactivateOnafterprint(): void {
        window.removeEventListener("afterprint", this.onafterprint);
    }


    // beforeprint event

    private onbeforeprint = () => BlazorInvoke.method(this.eventTrigger, "InvokeBeforePrint");

    public activateOnbeforeprint(): void {
        window.addEventListener("beforeprint", this.onbeforeprint);
    }

    public deactivateOnbeforeprint(): void {
        window.removeEventListener("beforeprint", this.onbeforeprint);
    }


    // rejectionhandled event

    private onrejectionhandled = (event: PromiseRejectionEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeRejectionHandled", event.reason ?? null);

    public activateOnrejectionhandled(): void {
        window.addEventListener("rejectionhandled", this.onrejectionhandled);
    }

    public deactivateOnrejectionhandled(): void {
        window.removeEventListener("rejectionhandled", this.onrejectionhandled);
    }


    // unhandledrejection event

    private onunhandledrejection = (event: PromiseRejectionEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeUnhandledRejection", event.reason ?? null);

    public activateOnunhandledrejection(): void {
        window.addEventListener("unhandledrejection", this.onunhandledrejection);
    }

    public deactivateOnunhandledrejection(): void {
        window.removeEventListener("unhandledrejection", this.onunhandledrejection);
    }


    // bubble events


    // HTMLElement - scroll event

    private onscroll = () => BlazorInvoke.method(this.eventTrigger, "InvokeScroll");

    public activateOnscroll(): void {
        window.addEventListener("scroll", this.onscroll);
    }

    public deactivateOnscroll(): void {
        window.removeEventListener("scroll", this.onscroll);
    }


    // HTMLElement - scrollend event

    private onscrollend = () => BlazorInvoke.method(this.eventTrigger, "InvokeScrollEnd");

    public activateOnscrollend(): void {
        window.addEventListener("scrollend", this.onscrollend);
    }

    public deactivateOnscrollend(): void {
        window.removeEventListener("scrollend", this.onscrollend);
    }


    // HTMLElement - change event

    private onchange = () => BlazorInvoke.method(this.eventTrigger, "InvokeChange");

    public activateOnchange(): void {
        window.addEventListener("change", this.onchange);
    }

    public deactivateOnchange(): void {
        window.removeEventListener("change", this.onchange);
    }


    // HTMLElement - drag event

    private ondrag = (dragEvent: DragEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDrag", ...WindowAPI.deconstructDataTransfer(dragEvent.dataTransfer));

    public activateOndrag(): void {
        window.addEventListener("drag", this.ondrag);
    }

    public deactivateOndrag(): void {
        window.removeEventListener("drag", this.ondrag);
    }


    // HTMLElement - dragstart event

    private ondragstart = (dragEvent: DragEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDragStart", ...WindowAPI.deconstructDataTransfer(dragEvent.dataTransfer));

    public activateOndragstart(): void {
        window.addEventListener("dragstart", this.ondragstart);
    }

    public deactivateOndragstart(): void {
        window.removeEventListener("dragstart", this.ondragstart);
    }


    // HTMLElement - dragend event

    private ondragend = (dragEvent: DragEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDragEnd", ...WindowAPI.deconstructDataTransfer(dragEvent.dataTransfer));

    public activateOndragend(): void {
        window.addEventListener("dragend", this.ondragend);
    }

    public deactivateOndragend(): void {
        window.removeEventListener("dragend", this.ondragend);
    }


    // HTMLElement - dragenter event

    private ondragenter = (dragEvent: DragEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDragEnter", ...WindowAPI.deconstructDataTransfer(dragEvent.dataTransfer));

    public activateOndragenter(): void {
        window.addEventListener("dragenter", this.ondragenter);
    }

    public deactivateOndragenter(): void {
        window.removeEventListener("dragenter", this.ondragenter);
    }


    // HTMLElement - dragleave event

    private ondragleave = (dragEvent: DragEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDragLeave", ...WindowAPI.deconstructDataTransfer(dragEvent.dataTransfer));

    public activateOndragleave(): void {
        window.addEventListener("dragleave", this.ondragleave);
    }

    public deactivateOndragleave(): void {
        window.removeEventListener("dragleave", this.ondragleave);
    }


    // HTMLElement - dragover event

    private ondragover = (dragEvent: DragEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDragOver", ...WindowAPI.deconstructDataTransfer(dragEvent.dataTransfer));

    public activateOndragover(): void {
        window.addEventListener("dragover", this.ondragover);
    }

    public deactivateOndragover(): void {
        window.removeEventListener("dragover", this.ondragover);
    }


    // HTMLElement - drop event

    private ondrop = (dragEvent: DragEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDrop", ...WindowAPI.deconstructDataTransfer(dragEvent.dataTransfer));

    public activateOndrop(): void {
        window.addEventListener("drop", this.ondrop);
    }

    public deactivateOndrop(): void {
        window.removeEventListener("drop", this.ondrop);
    }


    // HTMLElement - toggle

    private ontoggle = (toggleEvent: ToggleEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeToggle", toggleEvent.oldState, toggleEvent.newState);

    public activateOntoggle(): void {
        window.addEventListener("toggle", this.ontoggle);
    }

    public deactivateOntoggle(): void {
        window.removeEventListener("toggle", this.ontoggle);
    }


    // HTMLElement - beforetoggle

    private onbeforetoggle = (toggleEvent: ToggleEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeBeforeToggle", toggleEvent.oldState, toggleEvent.newState);

    public activateOnbeforetoggle(): void {
        window.addEventListener("beforetoggle", this.onbeforetoggle);
    }

    public deactivateOnbeforetoggle(): void {
        window.removeEventListener("beforetoggle", this.onbeforetoggle);
    }



    // Element - input event

    private oninput = (inputEvent: InputEvent | Event) => BlazorInvoke.method(this.eventTrigger, "InvokeInput", ...WindowAPI.deconstructInputEvent(inputEvent));

    public activateOninput(): void {
        window.addEventListener("input", this.oninput);
    }

    public deactivateOninput(): void {
        window.removeEventListener("input", this.oninput);
    }


    // Element - beforeinput event

    private onbeforeinput = (inputEvent: InputEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeBeforeInput", ...WindowAPI.deconstructInputEvent(inputEvent));

    public activateOnbeforeinput(): void {
        window.addEventListener("beforeinput", this.onbeforeinput);
    }

    public deactivateOnbeforeinput(): void {
        window.removeEventListener("beforeinput", this.onbeforeinput);
    }


    // Element - beforematch event

    private onbeforematch = () => BlazorInvoke.method(this.eventTrigger, "InvokeBeforeMatch");

    public activateOnbeforematch(): void {
        window.addEventListener("beforematch", this.onbeforematch);
    }

    public deactivateOnbeforematch(): void {
        window.removeEventListener("beforematch", this.onbeforematch);
    }



    // Element - keydown event

    private onkeydown = (keyboardEvent: KeyboardEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeKeyDown", {
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

    public activateOnkeydown(): void {
        window.addEventListener("keydown", this.onkeydown);
    }

    public deactivateOnkeydown(): void {
        window.removeEventListener("keydown", this.onkeydown);
    }


    // Element - keyup event

    private onkeyup = (keyboardEvent: KeyboardEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeKeyUp", {
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

    public activateOnkeyup(): void {
        window.addEventListener("keyup", this.onkeyup);
    }

    public deactivateOnkeyup(): void {
        window.removeEventListener("keyup", this.onkeyup);
    }



    // Element - click event

    private onclick = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeClick", {
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

    public activateOnclick(): void {
        window.addEventListener("click", this.onclick);
    }

    public deactivateOnclick(): void {
        window.removeEventListener("click", this.onclick);
    }


    // Element - dblclick event

    private ondblclick = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDblClick", {
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

    public activateOndblclick(): void {
        window.addEventListener("dblclick", this.ondblclick);
    }

    public deactivateOndblclick(): void {
        window.removeEventListener("dblclick", this.ondblclick);
    }


    // Element - auxclick event

    private onauxclick = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeAuxClick", {
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

    public activateOnauxclick(): void {
        window.addEventListener("auxclick", this.onauxclick);
    }

    public deactivateOnauxclick(): void {
        window.removeEventListener("auxclick", this.onauxclick);
    }


    // Element - contextmenu event

    private oncontextmenu = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeContextMenu", {
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

    public activateOncontextmenu(): void {
        window.addEventListener("contextmenu", this.oncontextmenu);
    }

    public deactivateOncontextmenu(): void {
        window.removeEventListener("contextmenu", this.oncontextmenu);
    }


    // Element - mousedown event

    private onmousedown = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeMouseDown", {
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

    public activateOnmousedown(): void {
        window.addEventListener("mousedown", this.onmousedown);
    }

    public deactivateOnmousedown(): void {
        window.removeEventListener("mousedown", this.onmousedown);
    }


    // Element - mouseup event

    private onmouseup = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeMouseUp", {
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

    public activateOnmouseup(): void {
        window.addEventListener("mouseup", this.onmouseup);
    }

    public deactivateOnmouseup(): void {
        window.removeEventListener("mouseup", this.onmouseup);
    }


    // Element - wheel event

    private onwheel = (wheelEvent: WheelEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeWheel", {
        deltaX: wheelEvent.deltaX,
        deltaY: wheelEvent.deltaY,
        deltaZ: wheelEvent.deltaZ,
        deltaMode: wheelEvent.deltaMode
    });

    public activateOnwheel(): void {
        window.addEventListener("wheel", this.onwheel, { passive: true });
    }

    public deactivateOnwheel(): void {
        window.removeEventListener("wheel", this.onwheel);
    }


    // Element - mousemove event

    private onmousemove = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeMouseMove", {
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

    public activateOnmousemove(): void {
        window.addEventListener("mousemove", this.onmousemove);
    }

    public deactivateOnmousemove(): void {
        window.removeEventListener("mousemove", this.onmousemove);
    }


    // Element - mouseover event

    private onmouseover = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeMouseOver", {
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

    public activateOnmouseover(): void {
        window.addEventListener("mouseover", this.onmouseover);
    }

    public deactivateOnmouseover(): void {
        window.removeEventListener("mouseover", this.onmouseover);
    }


    // Element - mouseout event

    private onmouseout = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeMouseOut", {
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

    public activateOnmouseout(): void {
        window.addEventListener("mouseout", this.onmouseout);
    }

    public deactivateOnmouseout(): void {
        window.removeEventListener("mouseout", this.onmouseout);
    }


    // Element - mouseenter event

    private onmouseenter = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeMouseEnter", {
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

    public activateOnmouseenter(): void {
        window.addEventListener("mouseenter", this.onmouseenter);
    }

    public deactivateOnmouseenter(): void {
        window.removeEventListener("mouseenter", this.onmouseenter);
    }


    // Element - mouseleave event

    private onmouseleave = (mouseEvent: MouseEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeMouseLeave", {
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

    public activateOnmouseleave(): void {
        window.addEventListener("mouseleave", this.onmouseleave);
    }

    public deactivateOnmouseleave(): void {
        window.removeEventListener("mouseleave", this.onmouseleave);
    }



    // Element - touchstart event

    private ontouchstart = (touchEvent: TouchEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTouchStart", {
        touches: WindowAPI.deconstructTouchList(touchEvent.touches),
        targetTouches: WindowAPI.deconstructTouchList(touchEvent.targetTouches),
        changedTouches: WindowAPI.deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    public activateOntouchstart(): void {
        window.addEventListener("touchstart", this.ontouchstart);
    }

    public deactivateOntouchstart(): void {
        window.removeEventListener("touchstart", this.ontouchstart);
    }


    // Element - touchend event

    private ontouchend = (touchEvent: TouchEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTouchEnd", {
        touches: WindowAPI.deconstructTouchList(touchEvent.touches),
        targetTouches: WindowAPI.deconstructTouchList(touchEvent.targetTouches),
        changedTouches: WindowAPI.deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    public activateOntouchend(): void {
        window.addEventListener("touchend", this.ontouchend);
    }

    public deactivateOntouchend(): void {
        window.removeEventListener("touchend", this.ontouchend);
    }


    // Element - touchmove event

    private ontouchmove = (touchEvent: TouchEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTouchMove", {
        touches: WindowAPI.deconstructTouchList(touchEvent.touches),
        targetTouches: WindowAPI.deconstructTouchList(touchEvent.targetTouches),
        changedTouches: WindowAPI.deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    public activateOntouchmove(): void {
        window.addEventListener("touchmove", this.ontouchmove);
    }

    public deactivateOntouchmove(): void {
        window.removeEventListener("touchmove", this.ontouchmove);
    }


    // Element - touchcancel event

    private ontouchcancel = (touchEvent: TouchEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTouchCancel", {
        touches: WindowAPI.deconstructTouchList(touchEvent.touches),
        targetTouches: WindowAPI.deconstructTouchList(touchEvent.targetTouches),
        changedTouches: WindowAPI.deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    public activateOntouchcancel(): void {
        window.addEventListener("touchcancel", this.ontouchcancel);
    }

    public deactivateOntouchcancel(): void {
        window.removeEventListener("touchcancel", this.ontouchcancel);
    }



    // Element - pointerdown event

    private onpointerdown = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.eventTrigger, "InvokePointerDown", {
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

    public activateOnpointerdown(): void {
        window.addEventListener("pointerdown", this.onpointerdown);
    }

    public deactivateOnpointerdown(): void {
        window.removeEventListener("pointerdown", this.onpointerdown);
    }


    // Element - pointerup event

    private onpointerup = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.eventTrigger, "InvokePointerUp", {
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

    public activateOnpointerup(): void {
        window.addEventListener("pointerup", this.onpointerup);
    }

    public deactivateOnpointerup(): void {
        window.removeEventListener("pointerup", this.onpointerup);
    }


    // Element - pointermove event

    private onpointermove = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.eventTrigger, "InvokePointerMove", {
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

    public activateOnpointermove(): void {
        window.addEventListener("pointermove", this.onpointermove);
    }

    public deactivateOnpointermove(): void {
        window.removeEventListener("pointermove", this.onpointermove);
    }


    // Element - pointerover event

    private onpointerover = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.eventTrigger, "InvokePointerOver", {
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

    public activateOnpointerover(): void {
        window.addEventListener("pointerover", this.onpointerover);
    }

    public deactivateOnpointerover(): void {
        window.removeEventListener("pointerover", this.onpointerover);
    }


    // Element - pointerout event

    private onpointerout = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.eventTrigger, "InvokePointerOut", {
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

    public activateOnpointerout(): void {
        window.addEventListener("pointerout", this.onpointerout);
    }

    public deactivateOnpointerout(): void {
        window.removeEventListener("pointerout", this.onpointerout);
    }


    // Element - pointerenter event

    private onpointerenter = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.eventTrigger, "InvokePointerEnter", {
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

    public activateOnpointerenter(): void {
        window.addEventListener("pointerenter", this.onpointerenter);
    }

    public deactivateOnpointerenter(): void {
        window.removeEventListener("pointerenter", this.onpointerenter);
    }


    // Element - pointerleave event

    private onpointerleave = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.eventTrigger, "InvokePointerLeave", {
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

    public activateOnpointerleave(): void {
        window.addEventListener("pointerleave", this.onpointerleave);
    }

    public deactivateOnpointerleave(): void {
        window.removeEventListener("pointerleave", this.onpointerleave);
    }


    // Element - pointercancel event

    private onpointercancel = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.eventTrigger, "InvokePointerCancel", {
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

    public activateOnpointercancel(): void {
        window.addEventListener("pointercancel", this.onpointercancel);
    }

    public deactivateOnpointercancel(): void {
        window.removeEventListener("pointercancel", this.onpointercancel);
    }


    // Element - pointerrawupdate event

    private onpointerrawupdate = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.eventTrigger, "InvokePointerRawUpdate", {
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

    public activateOnpointerrawupdate(): void {
        window.addEventListener("pointerrawupdate", this.onpointerrawupdate);
    }

    public deactivateOnpointerrawupdate(): void {
        window.removeEventListener("pointerrawupdate", this.onpointerrawupdate);
    }


    // Element - gotpointercapture event

    private ongotpointercapture = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.eventTrigger, "InvokeGotPointerCapture", {
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

    public activateOngotpointercapture(): void {
        window.addEventListener("gotpointercapture", this.ongotpointercapture);
    }

    public deactivateOngotpointercapture(): void {
        window.removeEventListener("gotpointercapture", this.ongotpointercapture);
    }


    // Element - lostpointercapture event

    private onlostpointercapture = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) => BlazorInvoke.method(this.eventTrigger, "InvokeLostPointerCapture", {
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

    public activateOnlostpointercapture(): void {
        window.addEventListener("lostpointercapture", this.onlostpointercapture);
    }

    public deactivateOnlostpointercapture(): void {
        window.removeEventListener("lostpointercapture", this.onlostpointercapture);
    }



    // Element - focusin event

    private onfocusin = () => BlazorInvoke.method(this.eventTrigger, "InvokeFocusIn");

    public activateOnfocusin(): void {
        window.addEventListener("focusin", this.onfocusin);
    }

    public deactivateOnfocusin(): void {
        window.removeEventListener("focusin", this.onfocusin);
    }


    // Element - focusout event

    private onfocusout = () => BlazorInvoke.method(this.eventTrigger, "InvokeFocusOut");

    public activateOnfocusout(): void {
        window.addEventListener("focusout", this.onfocusout);
    }

    public deactivateOnfocusout(): void {
        window.removeEventListener("focusout", this.onfocusout);
    }



    // Element - copy event

    private oncopy = () => BlazorInvoke.method(this.eventTrigger, "InvokeCopy");

    public activateOncopy(): void {
        window.addEventListener("copy", this.oncopy);
    }

    public deactivateOncopy(): void {
        window.removeEventListener("copy", this.oncopy);
    }


    // Element - paste event

    private onpaste = () => BlazorInvoke.method(this.eventTrigger, "InvokePaste");

    public activateOnpaste(): void {
        window.addEventListener("paste", this.onpaste);
    }

    public deactivateOnpaste(): void {
        window.removeEventListener("paste", this.onpaste);
    }


    // Element - cut event

    private oncut = () => BlazorInvoke.method(this.eventTrigger, "InvokeCut");

    public activateOncut(): void {
        window.addEventListener("cut", this.oncut);
    }

    public deactivateOncut(): void {
        window.removeEventListener("cut", this.oncut);
    }



    // Element - transitionstart event

    private ontransitionstart = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTransitionStart", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    public activateOntransitionstart(): void {
        window.addEventListener("transitionstart", this.ontransitionstart);
    }

    public deactivateOntransitionstart(): void {
        window.removeEventListener("transitionstart", this.ontransitionstart);
    }


    // Element - transitionend event

    private ontransitionend = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTransitionEnd", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    public activateOntransitionend(): void {
        window.addEventListener("transitionend", this.ontransitionend);
    }

    public deactivateOntransitionend(): void {
        window.removeEventListener("transitionend", this.ontransitionend);
    }


    // Element - transitionrun event

    private ontransitionrun = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTransitionRun", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    public activateOntransitionrun(): void {
        window.addEventListener("transitionrun", this.ontransitionrun);
    }

    public deactivateOntransitionrun(): void {
        window.removeEventListener("transitionrun", this.ontransitionrun);
    }


    // Element - transitioncancel event

    private ontransitioncancel = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTransitionCancel", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    public activateOntransitioncancel(): void {
        window.addEventListener("transitioncancel", this.ontransitioncancel);
    }

    public deactivateOntransitioncancel(): void {
        window.removeEventListener("transitioncancel", this.ontransitioncancel);
    }



    // Element - animationstart event

    private onanimationstart = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeAnimationStart", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    public activateOnanimationstart(): void {
        window.addEventListener("animationstart", this.onanimationstart);
    }

    public deactivateOnanimationstart(): void {
        window.removeEventListener("animationstart", this.onanimationstart);
    }


    // Element - animationend event

    private onanimationend = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeAnimationEnd", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    public activateOnanimationend(): void {
        window.addEventListener("animationend", this.onanimationend);
    }

    public deactivateOnanimationend(): void {
        window.removeEventListener("animationend", this.onanimationend);
    }


    // Element - animationiteration event

    private onanimationiteration = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeAnimationIteration", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    public activateOnanimationiteration(): void {
        window.addEventListener("animationiteration", this.onanimationiteration);
    }

    public deactivateOnanimationiteration(): void {
        window.removeEventListener("animationiteration", this.onanimationiteration);
    }


    // Element - animationcancel event

    private onanimationcancel = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeAnimationCancel", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    public activateOnanimationcancel(): void {
        window.addEventListener("animationcancel", this.onanimationcancel);
    }

    public deactivateOnanimationcancel(): void {
        window.removeEventListener("animationcancel", this.onanimationcancel);
    }



    // HTMLMediaElement - canplay event

    private oncanplay = () => BlazorInvoke.method(this.eventTrigger, "InvokeCanPlay");

    public activateOncanplay(): void {
        window.addEventListener("canplay", this.oncanplay);
    }

    public deactivateOncanplay(): void {
        window.removeEventListener("canplay", this.oncanplay);
    }


    // HTMLMediaElement - canplaythrough event

    private oncanplaythrough = () => BlazorInvoke.method(this.eventTrigger, "InvokeCanPlayThrough");

    public activateOncanplaythrough(): void {
        window.addEventListener("canplaythrough", this.oncanplaythrough);
    }

    public deactivateOncanplaythrough(): void {
        window.removeEventListener("canplaythrough", this.oncanplaythrough);
    }


    // HTMLMediaElement - playing event

    private onplaying = () => BlazorInvoke.method(this.eventTrigger, "InvokePlaying");

    public activateOnplaying(): void {
        window.addEventListener("playing", this.onplaying);
    }

    public deactivateOnplaying(): void {
        window.removeEventListener("playing", this.onplaying);
    }


    // Data

    // HTMLMediaElement - loadstart event

    private onloadstart = () => BlazorInvoke.method(this.eventTrigger, "InvokeLoadStart");

    public activateOnloadstart(): void {
        window.addEventListener("loadstart", this.onloadstart);
    }

    public deactivateOnloadstart(): void {
        window.removeEventListener("loadstart", this.onloadstart);
    }


    // HTMLMediaElement - progress event

    private onprogress = () => BlazorInvoke.method(this.eventTrigger, "InvokeProgress");

    public activateOnprogress(): void {
        window.addEventListener("progress", this.onprogress);
    }

    public deactivateOnprogress(): void {
        window.removeEventListener("progress", this.onprogress);
    }


    // HTMLMediaElement - loadeddata event

    private onloadeddata = () => BlazorInvoke.method(this.eventTrigger, "InvokeLoadedData");

    public activateOnloadeddata(): void {
        window.addEventListener("loadeddata", this.onloadeddata);
    }

    public deactivateOnloadeddata(): void {
        window.removeEventListener("loadeddata", this.onloadeddata);
    }


    // HTMLMediaElement - loadedmetadata event

    private onloadedmetadata = () => BlazorInvoke.method(this.eventTrigger, "InvokeLoadedMetadata");

    public activateOnloadedmetadata(): void {
        window.addEventListener("loadedmetadata", this.onloadedmetadata);
    }

    public deactivateOnloadedmetadata(): void {
        window.removeEventListener("loadedmetadata", this.onloadedmetadata);
    }


    // HTMLMediaElement - stalled event

    private onstalled = () => BlazorInvoke.method(this.eventTrigger, "InvokeStalled");

    public activateOnstalled(): void {
        window.addEventListener("stalled", this.onstalled);
    }

    public deactivateOnstalled(): void {
        window.removeEventListener("stalled", this.onstalled);
    }


    // HTMLMediaElement - suspend event

    private onsuspend = () => BlazorInvoke.method(this.eventTrigger, "InvokeSuspend");

    public activateOnsuspend(): void {
        window.addEventListener("suspend", this.onsuspend);
    }

    public deactivateOnsuspend(): void {
        window.removeEventListener("suspend", this.onsuspend);
    }


    // HTMLMediaElement - waiting event

    private onwaiting = () => BlazorInvoke.method(this.eventTrigger, "InvokeWaiting");

    public activateOnwaiting(): void {
        window.addEventListener("waiting", this.onwaiting);
    }

    public deactivateOnwaiting(): void {
        window.removeEventListener("waiting", this.onwaiting);
    }


    // HTMLMediaElement - abort event

    private onabort = () => BlazorInvoke.method(this.eventTrigger, "InvokeAbort");

    public activateOnabort(): void {
        window.addEventListener("abort", this.onabort);
    }

    public deactivateOnabort(): void {
        window.removeEventListener("abort", this.onabort);
    }


    // HTMLMediaElement - emptied event

    private onemptied = () => BlazorInvoke.method(this.eventTrigger, "InvokeEmptied");

    public activateOnemptied(): void {
        window.addEventListener("emptied", this.onemptied);
    }

    public deactivateOnemptied(): void {
        window.removeEventListener("emptied", this.onemptied);
    }


    // Timing

    // HTMLMediaElement - play event

    private onplay = () => BlazorInvoke.method(this.eventTrigger, "InvokePlay");

    public activateOnplay(): void {
        window.addEventListener("play", this.onplay);
    }

    public deactivateOnplay(): void {
        window.removeEventListener("play", this.onplay);
    }


    // HTMLMediaElement - pause event

    private onpause = () => BlazorInvoke.method(this.eventTrigger, "InvokePause");

    public activateOnpause(): void {
        window.addEventListener("pause", this.onpause);
    }

    public deactivateOnpause(): void {
        window.removeEventListener("pause", this.onpause);
    }


    // HTMLMediaElement - ended event

    private onended = () => BlazorInvoke.method(this.eventTrigger, "InvokeEnded");

    public activateOnended(): void {
        window.addEventListener("ended", this.onended);
    }

    public deactivateOnended(): void {
        window.removeEventListener("ended", this.onended);
    }


    // HTMLMediaElement - seeking event

    private onseeking = () => BlazorInvoke.method(this.eventTrigger, "InvokeSeeking");

    public activateOnseeking(): void {
        window.addEventListener("seeking", this.onseeking);
    }

    public deactivateOnseeking(): void {
        window.removeEventListener("seeking", this.onseeking);
    }


    // HTMLMediaElement - seeked event

    private onseeked = () => BlazorInvoke.method(this.eventTrigger, "InvokeSeeked");

    public activateOnseeked(): void {
        window.addEventListener("seeked", this.onseeked);
    }

    public deactivateOnseeked(): void {
        window.removeEventListener("seeked", this.onseeked);
    }


    // HTMLMediaElement - timeupdate event

    private ontimeupdate = () => BlazorInvoke.method(this.eventTrigger, "InvokeTimeUpdate");

    public activateOntimeupdate(): void {
        window.addEventListener("timeupdate", this.ontimeupdate);
    }

    public deactivateOntimeupdate(): void {
        window.removeEventListener("timeupdate", this.ontimeupdate);
    }


    // Setting

    // HTMLMediaElement - volumechange event

    private onvolumechange = () => BlazorInvoke.method(this.eventTrigger, "InvokeVolumeChange");

    public activateOnvolumechange(): void {
        window.addEventListener("volumechange", this.onvolumechange);
    }

    public deactivateOnvolumechange(): void {
        window.removeEventListener("volumechange", this.onvolumechange);
    }


    // HTMLMediaElement - ratechange event

    private onratechange = () => BlazorInvoke.method(this.eventTrigger, "InvokeRateChange");

    public activateOnratechange(): void {
        window.addEventListener("ratechange", this.onratechange);
    }

    public deactivateOnratechange(): void {
        window.removeEventListener("ratechange", this.onratechange);
    }


    // HTMLMediaElement - durationchange event

    private ondurationchange = () => BlazorInvoke.method(this.eventTrigger, "InvokeDurationChange");

    public activateOndurationchange(): void {
        window.addEventListener("durationchange", this.ondurationchange);
    }

    public deactivateOndurationchange(): void {
        window.removeEventListener("durationchange", this.ondurationchange);
    }



    // HTMLDialogElement - close event

    private onclose = () => BlazorInvoke.method(this.eventTrigger, "InvokeClose");

    public activateOnclose(): void {
        window.addEventListener("close", this.onclose);
    }

    public deactivateOnclose(): void {
        window.removeEventListener("close", this.onclose);
    }


    // HTMLDialogElement - cancel event

    private oncancel = () => BlazorInvoke.method(this.eventTrigger, "InvokeCancel");

    public activateOncancel(): void {
        window.addEventListener("cancel", this.oncancel);
    }

    public deactivateOncancel(): void {
        window.removeEventListener("cancel", this.oncancel);
    }
}
