import { HTMLElementAPI } from "../HTMLElement/HTMLElement";
import { FileAPI } from "../FileSystem/File/File";
import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class DocumentAPI {
    // properties - HTMLElement reference

    public static getDocumentElement(): HTMLElementAPI {
        return new HTMLElementAPI(document.documentElement);
    }

    public static getHead(): HTMLElementAPI {
        return new HTMLElementAPI(document.head);
    }

    public static getBody(): HTMLElementAPI {
        return new HTMLElementAPI(document.body);
    }

    public static setBody(value: HTMLElementAPI): void {
        document.body = value.htmlElement;
    }

    public static getScrollingElement(): [HTMLElementAPI] | [null] {
        const result = document.scrollingElement;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    // properties - HTMLElement collection

    public static getEmbeds(): HTMLElementAPI[] {
        return [...document.embeds].map(embedElement => DotNet.createJSObjectReference(new HTMLElementAPI(embedElement)));
    }

    public static getForms(): HTMLElementAPI[] {
        return [...document.forms].map(formElement => DotNet.createJSObjectReference(new HTMLElementAPI(formElement)));
    }

    public static getImages(): HTMLElementAPI[] {
        return [...document.images].map(imageElement => DotNet.createJSObjectReference(new HTMLElementAPI(imageElement)));
    }

    public static getLinks(): HTMLElementAPI[] {
        return [...document.links].map(linkElement => DotNet.createJSObjectReference(new HTMLElementAPI(linkElement)));
    }

    public static getPlugins(): HTMLElementAPI[] {
        return [...document.plugins].map(pluginElement => DotNet.createJSObjectReference(new HTMLElementAPI(pluginElement)));
    }

    public static getScripts(): HTMLElementAPI[] {
        return [...document.scripts].map(scriptElement => DotNet.createJSObjectReference(new HTMLElementAPI(scriptElement)));
    }

    // properties - HTMLElement situational

    public static getActiveElement(): [HTMLElementAPI] | [null] {
        const result = document.activeElement;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    public static getCurrentScript(): [HTMLElementAPI] | [null] {
        const result = document.currentScript;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    public static getFullscreenElement(): [HTMLElementAPI] | [null] {
        const result = document.fullscreenElement;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    public static getPictureInPictureElement(): [HTMLElementAPI] | [null] {
        const result = document.pictureInPictureElement;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    public static getPointerLockElement(): [HTMLElementAPI] | [null] {
        const result = document.pointerLockElement;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    // properties

    public static getCharacterSet(): string {
        return document.characterSet;
    }

    public static getCompatMode(): string {
        return document.compatMode;
    }

    public static getContentType(): string {
        return document.contentType;
    }

    public static getDesignMode(): string {
        return document.designMode;
    }

    public static setDesignMode(value: string): void {
        document.designMode = value;
    }

    public static getDir(): string {
        return document.dir;
    }

    public static setDir(value: string): void {
        document.dir = value;
    }

    public static getDocumentURI(): string {
        return document.documentURI;
    }

    public static getFullscreenEnabled(): boolean {
        return document.fullscreenEnabled;
    }

    public static getHidden(): boolean {
        return document.hidden;
    }

    public static getLastModified(): string {
        return document.lastModified;
    }

    public static getPictureInPictureEnabled(): boolean {
        return document.pictureInPictureEnabled;
    }

    public static getReadyState(): DocumentReadyState {
        return document.readyState;
    }

    public static getReferrer(): string {
        return document.referrer;
    }

    public static getTitle(): string {
        return document.title;
    }

    public static setTitle(value: string): void {
        document.title = value;
    }

    public static getURL(): string {
        return document.URL;
    }

    public static getVisibilityState(): string {
        return document.visibilityState;
    }

    // properties - Node

    public static getBaseURI(): string {
        return document.baseURI;
    }


    // methods - DOM

    public static createElement(tagName: string): HTMLElementAPI {
        return new HTMLElementAPI(document.createElement(tagName));
    }

    public static createElementNS(namespaceURI: string, qualifiedName: string): HTMLElementAPI {
        return new HTMLElementAPI(<HTMLElement>document.createElementNS(namespaceURI, qualifiedName));
    }

    public static getElementById(elementId: string): [HTMLElementAPI] | [null] {
        const result = document.getElementById(elementId);
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(result))];
        else
            return [null];
    }

    public static getElementsByClassName(classNames: string): HTMLElementAPI[] {
        return [...document.getElementsByClassName(classNames)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    public static getElementsByTagName(qualifiedName: string): HTMLElementAPI[] {
        return [...document.getElementsByTagName(qualifiedName)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    public static getElementsByTagNameNS(namespaceURL: string, localName: string): HTMLElementAPI[] {
        return [...document.getElementsByTagNameNS(namespaceURL, localName)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    public static getElementsByName(elementName: string): HTMLElementAPI[] {
        return [...document.getElementsByName(elementName)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    public static querySelector(selectors: string): [HTMLElementAPI] | [null] {
        const result = document.querySelector(selectors);
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    public static querySelectorAll(selectors: string): HTMLElementAPI[] {
        return [...document.querySelectorAll(selectors)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    public static elementFromPoint(x: number, y: number): [HTMLElementAPI] | [null] {
        const result = document.elementFromPoint(x, y);
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    public static elementsFromPoint(x: number, y: number): HTMLElementAPI[] {
        return [...document.elementsFromPoint(x, y)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    public static replaceChildren(children: HTMLElementAPI[]): void {
        document.replaceChildren(...children.map(wrapper => wrapper.htmlElement));
    }

    // methods - StorageAccess

    public static requestStorageAccess(all: boolean, cookies: boolean, sessionStorage: boolean, localStorage: boolean, indexedDB: boolean, locks: boolean, caches: boolean, getDirectory: boolean, estimate: boolean, createObjectURL: boolean, revokeObjectURL: boolean, BroadcastChannel: boolean, SharedWorker: boolean): Promise<void> {
        return (<Document & { requestStorageAccess(types: { all: boolean, cookies: boolean, sessionStorage: boolean, localStorage: boolean, indexedDB: boolean, locks: boolean, caches: boolean, getDirectory: boolean, estimate: boolean, createObjectURL: boolean, revokeObjectURL: boolean, BroadcastChannel: boolean, SharedWorker: boolean; }): Promise<void>; }>document)
            .requestStorageAccess({ all, cookies, sessionStorage, localStorage, indexedDB, locks, caches, getDirectory, estimate, createObjectURL, revokeObjectURL, BroadcastChannel, SharedWorker });
    }

    public static requestStorageAccessFor(requestedOrigin: string): Promise<void> {
        return (<Document & { requestStorageAccessFor(requestedOrigin: string): Promise<void>; }>document).requestStorageAccessFor(requestedOrigin);
    }

    public static hasStorageAccess(): Promise<boolean> {
        return document.hasStorageAccess();
    }

    // methods - exit

    public static exitFullscreen(): Promise<void> {
        return document.exitFullscreen();
    }

    public static exitPictureInPicture(): Promise<void> {
        return document.exitPictureInPicture();
    }

    public static exitPointerLock(): void {
        document.exitPointerLock();
    }

    // methods

    public static hasFocus(): boolean {
        return document.hasFocus();
    }

    // methods - Node

    public static compareDocumentPosition(other: HTMLElementAPI): number {
        return document.compareDocumentPosition(other.htmlElement);
    }

    public static contains(other: HTMLElementAPI): boolean {
        return document.contains(other.htmlElement);
    }

    public static isDefaultNamespace(namespace: string | null): boolean {
        return document.isDefaultNamespace(namespace);
    }

    public static lookupPrefix(namespace: string | null): string | null {
        return document.lookupPrefix(namespace);
    }

    public static lookupNamespaceURI(prefix: string | null): string | null {
        return document.lookupNamespaceURI(prefix);
    }

    public static normalize(): void {
        document.normalize();
    }


    // events


    private static eventTrigger: DotNet.DotNetObject;

    public static initEvents(eventTrigger: DotNet.DotNetObject): void {
        DocumentAPI.eventTrigger = eventTrigger;
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


    // securitypolicyviolation event

    private static onsecuritypolicyviolation(violationEvent: SecurityPolicyViolationEvent) {
        BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeSecurityPolicyViolation", {
            blockedURI: violationEvent.blockedURI,
            effectiveDirective: violationEvent.effectiveDirective,
            documentURI: violationEvent.documentURI,
            lineNumber: violationEvent.lineNumber,
            columnNumber: violationEvent.columnNumber,
            originalPolicy: violationEvent.originalPolicy,
            referrer: violationEvent.referrer,
            sourceFile: violationEvent.sourceFile,
            sample: violationEvent.sample,
            statusCode: violationEvent.statusCode,
            disposition: violationEvent.disposition
        });
    }

    public static activateOnsecuritypolicyviolation(): void {
        document.addEventListener("securitypolicyviolation", DocumentAPI.onsecuritypolicyviolation);
    }

    public static deactivateOnsecuritypolicyviolation(): void {
        document.removeEventListener("securitypolicyviolation", DocumentAPI.onsecuritypolicyviolation);
    }


    // visibilitychange event

    private static onvisibilitychange() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeVisibilityChange");
    }

    public static activateOnvisibilitychange(): void {
        document.addEventListener("visibilitychange", DocumentAPI.onvisibilitychange);
    }

    public static deactivateOnvisibilitychange(): void {
        document.removeEventListener("visibilitychange", DocumentAPI.onvisibilitychange);
    }


    // fullscreenchange event

    private static onfullscreenchange() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeFullscreenChange");
    }

    public static activateOnfullscreenchange(): void {
        document.addEventListener("fullscreenchange", DocumentAPI.onfullscreenchange);
    }

    public static deactivateOnfullscreenchange(): void {
        document.removeEventListener("fullscreenchange", DocumentAPI.onfullscreenchange);
    }


    // fullscreenerror event

    private static onfullscreenerror() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeFullscreenError");
    }

    public static activateOnfullscreenerror(): void {
        document.addEventListener("fullscreenerror", DocumentAPI.onfullscreenerror);
    }

    public static deactivateOnfullscreenerror(): void {
        document.removeEventListener("fullscreenerror", DocumentAPI.onfullscreenerror);
    }


    // DOMContentLoaded event

    private static onDOMContentLoaded() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeDOMContentLoaded");
    }

    public static activateOnDOMContentLoaded(): void {
        document.addEventListener("DOMContentLoaded", DocumentAPI.onDOMContentLoaded);
    }

    public static deactivateOnDOMContentLoaded(): void {
        document.removeEventListener("DOMContentLoaded", DocumentAPI.onDOMContentLoaded);
    }


    // readystatechange event

    private static onreadystatechange() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeReadyStateChange");
    }

    public static activateOnreadystatechange(): void {
        document.addEventListener("readystatechange", DocumentAPI.onreadystatechange);
    }

    public static deactivateOnreadystatechange(): void {
        document.removeEventListener("readystatechange", DocumentAPI.onreadystatechange);
    }


    // pointerlockchange event

    private static onpointerlockchange() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePointerLockChange");
    }

    public static activateOnpointerlockchange(): void {
        document.addEventListener("pointerlockchange", DocumentAPI.onpointerlockchange);
    }

    public static deactivateOnpointerlockchange(): void {
        document.removeEventListener("pointerlockchange", DocumentAPI.onpointerlockchange);
    }


    // pointerlockerror event

    private static onpointerlockerror() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePointerLockError");
    }

    public static activateOnpointerlockerror(): void {
        document.addEventListener("pointerlockerror", DocumentAPI.onpointerlockerror);
    }

    public static deactivateOnpointerlockerror(): void {
        document.removeEventListener("pointerlockerror", DocumentAPI.onpointerlockerror);
    }


    // scroll event

    private static onscroll() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeScroll");
    }

    public static activateOnscroll(): void {
        document.addEventListener("scroll", DocumentAPI.onscroll);
    }

    public static deactivateOnscroll(): void {
        document.removeEventListener("scroll", DocumentAPI.onscroll);
    }


    // scrollend event

    private static onscrollend() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeScrollEnd");
    }

    public static activateOnscrollend(): void {
        document.addEventListener("scrollend", DocumentAPI.onscrollend);
    }

    public static deactivateOnscrollend(): void {
        document.removeEventListener("scrollend", DocumentAPI.onscrollend);
    }


    // selectionchange event

    private static onselectionchange() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeSelectionChange");
    }

    public static activateOnselectionchange(): void {
        document.addEventListener("selectionchange", DocumentAPI.onselectionchange);
    }

    public static deactivateOnselectionchange(): void {
        document.removeEventListener("selectionchange", DocumentAPI.onselectionchange);
    }


    // Node - selectstart event

    private static onselectstart() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeSelectStart");
    }

    public static activateOnselectstart(): void {
        document.addEventListener("selectstart", DocumentAPI.onselectstart);
    }

    public static deactivateOnselectstart(): void {
        document.removeEventListener("selectstart", DocumentAPI.onselectstart);
    }


    // bubble events

    // HTMLElement - change event

    private static onchange() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeChange");
    }

    public static activateOnchange(): void {
        document.addEventListener("change", DocumentAPI.onchange);
    }

    public static deactivateOnchange(): void {
        document.removeEventListener("change", DocumentAPI.onchange);
    }


    // HTMLElement - load event

    private static onload() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeLoad");
    }

    public static activateOnload(): void {
        document.addEventListener("load", DocumentAPI.onload);
    }

    public static deactivateOnload(): void {
        document.removeEventListener("load", DocumentAPI.onload);
    }


    // HTMLElement - error event

    private static onerror(error: Event) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeError", error);
    }

    public static activateOnerror(): void {
        document.addEventListener("error", DocumentAPI.onerror);
    }

    public static deactivateOnerror(): void {
        document.removeEventListener("error", DocumentAPI.onerror);
    }


    // HTMLElement - drag event

    private static ondrag(dragEvent: DragEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeDrag", ...DocumentAPI.deconstructDataTransfer(dragEvent.dataTransfer));
    }

    public static activateOndrag(): void {
        document.addEventListener("drag", DocumentAPI.ondrag);
    }

    public static deactivateOndrag(): void {
        document.removeEventListener("drag", DocumentAPI.ondrag);
    }


    // HTMLElement - dragstart event

    private static ondragstart(dragEvent: DragEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeDragStart", ...DocumentAPI.deconstructDataTransfer(dragEvent.dataTransfer));
    }

    public static activateOndragstart(): void {
        document.addEventListener("dragstart", DocumentAPI.ondragstart);
    }

    public static deactivateOndragstart(): void {
        document.removeEventListener("dragstart", DocumentAPI.ondragstart);
    }


    // HTMLElement - dragend event

    private static ondragend(dragEvent: DragEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeDragEnd", ...DocumentAPI.deconstructDataTransfer(dragEvent.dataTransfer));
    }

    public static activateOndragend(): void {
        document.addEventListener("dragend", DocumentAPI.ondragend);
    }

    public static deactivateOndragend(): void {
        document.removeEventListener("dragend", DocumentAPI.ondragend);
    }


    // HTMLElement - dragenter event

    private static ondragenter(dragEvent: DragEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeDragEnter", ...DocumentAPI.deconstructDataTransfer(dragEvent.dataTransfer));
    }

    public static activateOndragenter(): void {
        document.addEventListener("dragenter", DocumentAPI.ondragenter);
    }

    public static deactivateOndragenter(): void {
        document.removeEventListener("dragenter", DocumentAPI.ondragenter);
    }


    // HTMLElement - dragleave event

    private static ondragleave(dragEvent: DragEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeDragLeave", ...DocumentAPI.deconstructDataTransfer(dragEvent.dataTransfer));
    }

    public static activateOndragleave(): void {
        document.addEventListener("dragleave", DocumentAPI.ondragleave);
    }

    public static deactivateOndragleave(): void {
        document.removeEventListener("dragleave", DocumentAPI.ondragleave);
    }


    // HTMLElement - dragover event

    private static ondragover(dragEvent: DragEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeDragOver", ...DocumentAPI.deconstructDataTransfer(dragEvent.dataTransfer));
    }

    public static activateOndragover(): void {
        document.addEventListener("dragover", DocumentAPI.ondragover);
    }

    public static deactivateOndragover(): void {
        document.removeEventListener("dragover", DocumentAPI.ondragover);
    }


    // HTMLElement - drop event

    private static ondrop(dragEvent: DragEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeDrop", ...DocumentAPI.deconstructDataTransfer(dragEvent.dataTransfer));
    }

    public static activateOndrop(): void {
        document.addEventListener("drop", DocumentAPI.ondrop);
    }

    public static deactivateOndrop(): void {
        document.removeEventListener("drop", DocumentAPI.ondrop);
    }


    // HTMLElement - toggle

    private static ontoggle(toggleEvent: ToggleEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeToggle", toggleEvent.oldState, toggleEvent.newState);
    }

    public static activateOntoggle(): void {
        document.addEventListener("toggle", DocumentAPI.ontoggle);
    }

    public static deactivateOntoggle(): void {
        document.removeEventListener("toggle", DocumentAPI.ontoggle);
    }


    // HTMLElement - beforetoggle

    private static onbeforetoggle(toggleEvent: ToggleEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeBeforeToggle", toggleEvent.oldState, toggleEvent.newState);
    }

    public static activateOnbeforetoggle(): void {
        document.addEventListener("beforetoggle", DocumentAPI.onbeforetoggle);
    }

    public static deactivateOnbeforetoggle(): void {
        document.removeEventListener("beforetoggle", DocumentAPI.onbeforetoggle);
    }



    // Element - input event

    private static oninput(inputEvent: InputEvent | Event) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeInput", ...DocumentAPI.deconstructInputEvent(inputEvent));
    }

    public static activateOninput(): void {
        document.addEventListener("input", DocumentAPI.oninput);
    }

    public static deactivateOninput(): void {
        document.removeEventListener("input", DocumentAPI.oninput);
    }


    // Element - beforeinput event

    private static onbeforeinput(inputEvent: InputEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeBeforeInput", ...DocumentAPI.deconstructInputEvent(inputEvent));
    }

    public static activateOnbeforeinput(): void {
        document.addEventListener("beforeinput", DocumentAPI.onbeforeinput);
    }

    public static deactivateOnbeforeinput(): void {
        document.removeEventListener("beforeinput", DocumentAPI.onbeforeinput);
    }


    // Element - beforematch event

    private static onbeforematch() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeBeforeMatch");
    }

    public static activateOnbeforematch(): void {
        document.addEventListener("beforematch", DocumentAPI.onbeforematch);
    }

    public static deactivateOnbeforematch(): void {
        document.removeEventListener("beforematch", DocumentAPI.onbeforematch);
    }



    // Element - keydown event

    private static onkeydown(keyboardEvent: KeyboardEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeKeyDown", {
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
    }

    public static activateOnkeydown(): void {
        document.addEventListener("keydown", DocumentAPI.onkeydown);
    }

    public static deactivateOnkeydown(): void {
        document.removeEventListener("keydown", DocumentAPI.onkeydown);
    }


    // Element - keyup event

    private static onkeyup(keyboardEvent: KeyboardEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeKeyUp", {
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
    }

    public static activateOnkeyup(): void {
        document.addEventListener("keyup", DocumentAPI.onkeyup);
    }

    public static deactivateOnkeyup(): void {
        document.removeEventListener("keyup", DocumentAPI.onkeyup);
    }



    // Element - click event

    private static onclick(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeClick", {
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
    }

    public static activateOnclick(): void {
        document.addEventListener("click", DocumentAPI.onclick);
    }

    public static deactivateOnclick(): void {
        document.removeEventListener("click", DocumentAPI.onclick);
    }


    // Element - dblclick event

    private static ondblclick(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeDblClick", {
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
    }

    public static activateOndblclick(): void {
        document.addEventListener("dblclick", DocumentAPI.ondblclick);
    }

    public static deactivateOndblclick(): void {
        document.removeEventListener("dblclick", DocumentAPI.ondblclick);
    }


    // Element - auxclick event

    private static onauxclick(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeAuxClick", {
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
    }

    public static activateOnauxclick(): void {
        document.addEventListener("auxclick", DocumentAPI.onauxclick);
    }

    public static deactivateOnauxclick(): void {
        document.removeEventListener("auxclick", DocumentAPI.onauxclick);
    }


    // Element - contextmenu event

    private static oncontextmenu(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeContextMenu", {
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
    }

    public static activateOncontextmenu(): void {
        document.addEventListener("contextmenu", DocumentAPI.oncontextmenu);
    }

    public static deactivateOncontextmenu(): void {
        document.removeEventListener("contextmenu", DocumentAPI.oncontextmenu);
    }


    // Element - mousedown event

    private static onmousedown(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeMouseDown", {
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
    }

    public static activateOnmousedown(): void {
        document.addEventListener("mousedown", DocumentAPI.onmousedown);
    }

    public static deactivateOnmousedown(): void {
        document.removeEventListener("mousedown", DocumentAPI.onmousedown);
    }


    // Element - mouseup event

    private static onmouseup(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeMouseUp", {
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
    }

    public static activateOnmouseup(): void {
        document.addEventListener("mouseup", DocumentAPI.onmouseup);
    }

    public static deactivateOnmouseup(): void {
        document.removeEventListener("mouseup", DocumentAPI.onmouseup);
    }


    // Element - wheel event

    private static onwheel(wheelEvent: WheelEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeWheel", {
            deltaX: wheelEvent.deltaX,
            deltaY: wheelEvent.deltaY,
            deltaZ: wheelEvent.deltaZ,
            deltaMode: wheelEvent.deltaMode
        });
    }

    public static activateOnwheel(): void {
        document.addEventListener("wheel", DocumentAPI.onwheel, { passive: true });
    }

    public static deactivateOnwheel(): void {
        document.removeEventListener("wheel", DocumentAPI.onwheel);
    }


    // Element - mousemove event

    private static onmousemove(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeMouseMove", {
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
    }

    public static activateOnmousemove(): void {
        document.addEventListener("mousemove", DocumentAPI.onmousemove);
    }

    public static deactivateOnmousemove(): void {
        document.removeEventListener("mousemove", DocumentAPI.onmousemove);
    }


    // Element - mouseover event

    private static onmouseover(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeMouseOver", {
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
    }

    public static activateOnmouseover(): void {
        document.addEventListener("mouseover", DocumentAPI.onmouseover);
    }

    public static deactivateOnmouseover(): void {
        document.removeEventListener("mouseover", DocumentAPI.onmouseover);
    }


    // Element - mouseout event

    private static onmouseout(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeMouseOut", {
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
    }

    public static activateOnmouseout(): void {
        document.addEventListener("mouseout", DocumentAPI.onmouseout);
    }

    public static deactivateOnmouseout(): void {
        document.removeEventListener("mouseout", DocumentAPI.onmouseout);
    }


    // Element - mouseenter event

    private static onmouseenter(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeMouseEnter", {
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
    }

    public static activateOnmouseenter(): void {
        document.addEventListener("mouseenter", DocumentAPI.onmouseenter);
    }

    public static deactivateOnmouseenter(): void {
        document.removeEventListener("mouseenter", DocumentAPI.onmouseenter);
    }


    // Element - mouseleave event

    private static onmouseleave(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeMouseLeave", {
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
    }

    public static activateOnmouseleave(): void {
        document.addEventListener("mouseleave", DocumentAPI.onmouseleave);
    }

    public static deactivateOnmouseleave(): void {
        document.removeEventListener("mouseleave", DocumentAPI.onmouseleave);
    }



    // Element - touchstart event

    private static ontouchstart(touchEvent: TouchEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeTouchStart", {
            touches: DocumentAPI.deconstructTouchList(touchEvent.touches),
            targetTouches: DocumentAPI.deconstructTouchList(touchEvent.targetTouches),
            changedTouches: DocumentAPI.deconstructTouchList(touchEvent.changedTouches),
            ctrlKey: touchEvent.ctrlKey,
            shiftKey: touchEvent.shiftKey,
            altKey: touchEvent.altKey,
            metaKey: touchEvent.metaKey
        });
    }

    public static activateOntouchstart(): void {
        document.addEventListener("touchstart", DocumentAPI.ontouchstart);
    }

    public static deactivateOntouchstart(): void {
        document.removeEventListener("touchstart", DocumentAPI.ontouchstart);
    }


    // Element - touchend event

    private static ontouchend(touchEvent: TouchEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeTouchEnd", {
            touches: DocumentAPI.deconstructTouchList(touchEvent.touches),
            targetTouches: DocumentAPI.deconstructTouchList(touchEvent.targetTouches),
            changedTouches: DocumentAPI.deconstructTouchList(touchEvent.changedTouches),
            ctrlKey: touchEvent.ctrlKey,
            shiftKey: touchEvent.shiftKey,
            altKey: touchEvent.altKey,
            metaKey: touchEvent.metaKey
        });
    }

    public static activateOntouchend(): void {
        document.addEventListener("touchend", DocumentAPI.ontouchend);
    }

    public static deactivateOntouchend(): void {
        document.removeEventListener("touchend", DocumentAPI.ontouchend);
    }


    // Element - touchmove event

    private static ontouchmove(touchEvent: TouchEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeTouchMove", {
            touches: DocumentAPI.deconstructTouchList(touchEvent.touches),
            targetTouches: DocumentAPI.deconstructTouchList(touchEvent.targetTouches),
            changedTouches: DocumentAPI.deconstructTouchList(touchEvent.changedTouches),
            ctrlKey: touchEvent.ctrlKey,
            shiftKey: touchEvent.shiftKey,
            altKey: touchEvent.altKey,
            metaKey: touchEvent.metaKey
        });
    }

    public static activateOntouchmove(): void {
        document.addEventListener("touchmove", DocumentAPI.ontouchmove);
    }

    public static deactivateOntouchmove(): void {
        document.removeEventListener("touchmove", DocumentAPI.ontouchmove);
    }


    // Element - touchcancel event

    private static ontouchcancel(touchEvent: TouchEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeTouchCancel", {
            touches: DocumentAPI.deconstructTouchList(touchEvent.touches),
            targetTouches: DocumentAPI.deconstructTouchList(touchEvent.targetTouches),
            changedTouches: DocumentAPI.deconstructTouchList(touchEvent.changedTouches),
            ctrlKey: touchEvent.ctrlKey,
            shiftKey: touchEvent.shiftKey,
            altKey: touchEvent.altKey,
            metaKey: touchEvent.metaKey
        });
    }

    public static activateOntouchcancel(): void {
        document.addEventListener("touchcancel", DocumentAPI.ontouchcancel);
    }

    public static deactivateOntouchcancel(): void {
        document.removeEventListener("touchcancel", DocumentAPI.ontouchcancel);
    }



    // Element - pointerdown event

    private static onpointerdown(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePointerDown", {
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
    }

    public static activateOnpointerdown(): void {
        document.addEventListener("pointerdown", DocumentAPI.onpointerdown);
    }

    public static deactivateOnpointerdown(): void {
        document.removeEventListener("pointerdown", DocumentAPI.onpointerdown);
    }


    // Element - pointerup event

    private static onpointerup(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePointerUp", {
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
    }

    public static activateOnpointerup(): void {
        document.addEventListener("pointerup", DocumentAPI.onpointerup);
    }

    public static deactivateOnpointerup(): void {
        document.removeEventListener("pointerup", DocumentAPI.onpointerup);
    }


    // Element - pointermove event

    private static onpointermove(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePointerMove", {
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
    }

    public static activateOnpointermove(): void {
        document.addEventListener("pointermove", DocumentAPI.onpointermove);
    }

    public static deactivateOnpointermove(): void {
        document.removeEventListener("pointermove", DocumentAPI.onpointermove);
    }


    // Element - pointerover event

    private static onpointerover(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePointerOver", {
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
    }

    public static activateOnpointerover(): void {
        document.addEventListener("pointerover", DocumentAPI.onpointerover);
    }

    public static deactivateOnpointerover(): void {
        document.removeEventListener("pointerover", DocumentAPI.onpointerover);
    }


    // Element - pointerout event

    private static onpointerout(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePointerOut", {
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
    }

    public static activateOnpointerout(): void {
        document.addEventListener("pointerout", DocumentAPI.onpointerout);
    }

    public static deactivateOnpointerout(): void {
        document.removeEventListener("pointerout", DocumentAPI.onpointerout);
    }


    // Element - pointerenter event

    private static onpointerenter(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePointerEnter", {
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
    }

    public static activateOnpointerenter(): void {
        document.addEventListener("pointerenter", DocumentAPI.onpointerenter);
    }

    public static deactivateOnpointerenter(): void {
        document.removeEventListener("pointerenter", DocumentAPI.onpointerenter);
    }


    // Element - pointerleave event

    private static onpointerleave(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePointerLeave", {
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
    }

    public static activateOnpointerleave(): void {
        document.addEventListener("pointerleave", DocumentAPI.onpointerleave);
    }

    public static deactivateOnpointerleave(): void {
        document.removeEventListener("pointerleave", DocumentAPI.onpointerleave);
    }


    // Element - pointercancel event

    private static onpointercancel(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePointerCancel", {
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
    }

    public static activateOnpointercancel(): void {
        document.addEventListener("pointercancel", DocumentAPI.onpointercancel);
    }

    public static deactivateOnpointercancel(): void {
        document.removeEventListener("pointercancel", DocumentAPI.onpointercancel);
    }


    // Element - pointerrawupdate event

    private static onpointerrawupdate(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePointerRawUpdate", {
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
    }

    public static activateOnpointerrawupdate(): void {
        document.addEventListener("pointerrawupdate", DocumentAPI.onpointerrawupdate);
    }

    public static deactivateOnpointerrawupdate(): void {
        document.removeEventListener("pointerrawupdate", DocumentAPI.onpointerrawupdate);
    }


    // Element - gotpointercapture event

    private static ongotpointercapture(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeGotPointerCapture", {
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
    }

    public static activateOngotpointercapture(): void {
        document.addEventListener("gotpointercapture", DocumentAPI.ongotpointercapture);
    }

    public static deactivateOngotpointercapture(): void {
        document.removeEventListener("gotpointercapture", DocumentAPI.ongotpointercapture);
    }


    // Element - lostpointercapture event

    private static onlostpointercapture(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeLostPointerCapture", {
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
    }

    public static activateOnlostpointercapture(): void {
        document.addEventListener("lostpointercapture", DocumentAPI.onlostpointercapture);
    }

    public static deactivateOnlostpointercapture(): void {
        document.removeEventListener("lostpointercapture", DocumentAPI.onlostpointercapture);
    }



    // Element - focus event

    private static onfocus() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeFocus");
    }

    public static activateOnfocus(): void {
        document.addEventListener("focus", DocumentAPI.onfocus);
    }

    public static deactivateOnfocus(): void {
        document.removeEventListener("focus", DocumentAPI.onfocus);
    }


    // Element - focusin event

    private static onfocusin() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeFocusIn");
    }

    public static activateOnfocusin(): void {
        document.addEventListener("focusin", DocumentAPI.onfocusin);
    }

    public static deactivateOnfocusin(): void {
        document.removeEventListener("focusin", DocumentAPI.onfocusin);
    }


    // Element - blur event

    private static onblur() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeBlur");
    }

    public static activateOnblur(): void {
        document.addEventListener("blur", DocumentAPI.onblur);
    }

    public static deactivateOnblur(): void {
        document.removeEventListener("blur", DocumentAPI.onblur);
    }


    // Element - focusout event

    private static onfocusout() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeFocusOut");
    }

    public static activateOnfocusout(): void {
        document.addEventListener("focusout", DocumentAPI.onfocusout);
    }

    public static deactivateOnfocusout(): void {
        document.removeEventListener("focusout", DocumentAPI.onfocusout);
    }



    // Element - copy event

    private static oncopy() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeCopy");
    }

    public static activateOncopy(): void {
        document.addEventListener("copy", DocumentAPI.oncopy);
    }

    public static deactivateOncopy(): void {
        document.removeEventListener("copy", DocumentAPI.oncopy);
    }


    // Element - paste event

    private static onpaste() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePaste");
    }

    public static activateOnpaste(): void {
        document.addEventListener("paste", DocumentAPI.onpaste);
    }

    public static deactivateOnpaste(): void {
        document.removeEventListener("paste", DocumentAPI.onpaste);
    }


    // Element - cut event

    private static oncut() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeCut");
    }

    public static activateOncut(): void {
        document.addEventListener("cut", DocumentAPI.oncut);
    }

    public static deactivateOncut(): void {
        document.removeEventListener("cut", DocumentAPI.oncut);
    }



    // Element - transitionstart event

    private static ontransitionstart(transitionEvent: TransitionEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeTransitionStart", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);
    }

    public static activateOntransitionstart(): void {
        document.addEventListener("transitionstart", DocumentAPI.ontransitionstart);
    }

    public static deactivateOntransitionstart(): void {
        document.removeEventListener("transitionstart", DocumentAPI.ontransitionstart);
    }


    // Element - transitionend event

    private static ontransitionend(transitionEvent: TransitionEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeTransitionEnd", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);
    }

    public static activateOntransitionend(): void {
        document.addEventListener("transitionend", DocumentAPI.ontransitionend);
    }

    public static deactivateOntransitionend(): void {
        document.removeEventListener("transitionend", DocumentAPI.ontransitionend);
    }


    // Element - transitionrun event

    private static ontransitionrun(transitionEvent: TransitionEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeTransitionRun", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);
    }

    public static activateOntransitionrun(): void {
        document.addEventListener("transitionrun", DocumentAPI.ontransitionrun);
    }

    public static deactivateOntransitionrun(): void {
        document.removeEventListener("transitionrun", DocumentAPI.ontransitionrun);
    }


    // Element - transitioncancel event

    private static ontransitioncancel(transitionEvent: TransitionEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeTransitionCancel", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);
    }

    public static activateOntransitioncancel(): void {
        document.addEventListener("transitioncancel", DocumentAPI.ontransitioncancel);
    }

    public static deactivateOntransitioncancel(): void {
        document.removeEventListener("transitioncancel", DocumentAPI.ontransitioncancel);
    }



    // Element - animationstart event

    private static onanimationstart(animationEvent: AnimationEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeAnimationStart", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);
    }

    public static activateOnanimationstart(): void {
        document.addEventListener("animationstart", DocumentAPI.onanimationstart);
    }

    public static deactivateOnanimationstart(): void {
        document.removeEventListener("animationstart", DocumentAPI.onanimationstart);
    }


    // Element - animationend event

    private static onanimationend(animationEvent: AnimationEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeAnimationEnd", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);
    }

    public static activateOnanimationend(): void {
        document.addEventListener("animationend", DocumentAPI.onanimationend);
    }

    public static deactivateOnanimationend(): void {
        document.removeEventListener("animationend", DocumentAPI.onanimationend);
    }


    // Element - animationiteration event

    private static onanimationiteration(animationEvent: AnimationEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeAnimationIteration", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);
    }

    public static activateOnanimationiteration(): void {
        document.addEventListener("animationiteration", DocumentAPI.onanimationiteration);
    }

    public static deactivateOnanimationiteration(): void {
        document.removeEventListener("animationiteration", DocumentAPI.onanimationiteration);
    }


    // Element - animationcancel event

    private static onanimationcancel(animationEvent: AnimationEvent) {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeAnimationCancel", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);
    }

    public static activateOnanimationcancel(): void {
        document.addEventListener("animationcancel", DocumentAPI.onanimationcancel);
    }

    public static deactivateOnanimationcancel(): void {
        document.removeEventListener("animationcancel", DocumentAPI.onanimationcancel);
    }



    // HTMLMediaElement - canplay event

    private static oncanplay() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeCanPlay");
    }

    public static activateOncanplay(): void {
        document.addEventListener("canplay", DocumentAPI.oncanplay);
    }

    public static deactivateOncanplay(): void {
        document.removeEventListener("canplay", DocumentAPI.oncanplay);
    }


    // HTMLMediaElement - canplaythrough event

    private static oncanplaythrough() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeCanPlayThrough");
    }

    public static activateOncanplaythrough(): void {
        document.addEventListener("canplaythrough", DocumentAPI.oncanplaythrough);
    }

    public static deactivateOncanplaythrough(): void {
        document.removeEventListener("canplaythrough", DocumentAPI.oncanplaythrough);
    }


    // HTMLMediaElement - playing event

    private static onplaying() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePlaying");
    }

    public static activateOnplaying(): void {
        document.addEventListener("playing", DocumentAPI.onplaying);
    }

    public static deactivateOnplaying(): void {
        document.removeEventListener("playing", DocumentAPI.onplaying);
    }


    // Data

    // HTMLMediaElement - loadstart event

    private static onloadstart() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeLoadStart");
    }

    public static activateOnloadstart(): void {
        document.addEventListener("loadstart", DocumentAPI.onloadstart);
    }

    public static deactivateOnloadstart(): void {
        document.removeEventListener("loadstart", DocumentAPI.onloadstart);
    }


    // HTMLMediaElement - progress event

    private static onprogress() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeProgress");
    }

    public static activateOnprogress(): void {
        document.addEventListener("progress", DocumentAPI.onprogress);
    }

    public static deactivateOnprogress(): void {
        document.removeEventListener("progress", DocumentAPI.onprogress);
    }


    // HTMLMediaElement - loadeddata event

    private static onloadeddata() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeLoadedData");
    }

    public static activateOnloadeddata(): void {
        document.addEventListener("loadeddata", DocumentAPI.onloadeddata);
    }

    public static deactivateOnloadeddata(): void {
        document.removeEventListener("loadeddata", DocumentAPI.onloadeddata);
    }


    // HTMLMediaElement - loadedmetadata event

    private static onloadedmetadata() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeLoadedMetadata");
    }

    public static activateOnloadedmetadata(): void {
        document.addEventListener("loadedmetadata", DocumentAPI.onloadedmetadata);
    }

    public static deactivateOnloadedmetadata(): void {
        document.removeEventListener("loadedmetadata", DocumentAPI.onloadedmetadata);
    }


    // HTMLMediaElement - stalled event

    private static onstalled() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeStalled");
    }

    public static activateOnstalled(): void {
        document.addEventListener("stalled", DocumentAPI.onstalled);
    }

    public static deactivateOnstalled(): void {
        document.removeEventListener("stalled", DocumentAPI.onstalled);
    }


    // HTMLMediaElement - suspend event

    private static onsuspend() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeSuspend");
    }

    public static activateOnsuspend(): void {
        document.addEventListener("suspend", DocumentAPI.onsuspend);
    }

    public static deactivateOnsuspend(): void {
        document.removeEventListener("suspend", DocumentAPI.onsuspend);
    }


    // HTMLMediaElement - waiting event

    private static onwaiting() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeWaiting");
    }

    public static activateOnwaiting(): void {
        document.addEventListener("waiting", DocumentAPI.onwaiting);
    }

    public static deactivateOnwaiting(): void {
        document.removeEventListener("waiting", DocumentAPI.onwaiting);
    }


    // HTMLMediaElement - abort event

    private static onabort() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeAbort");
    }

    public static activateOnabort(): void {
        document.addEventListener("abort", DocumentAPI.onabort);
    }

    public static deactivateOnabort(): void {
        document.removeEventListener("abort", DocumentAPI.onabort);
    }


    // HTMLMediaElement - emptied event

    private static onemptied() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeEmptied");
    }

    public static activateOnemptied(): void {
        document.addEventListener("emptied", DocumentAPI.onemptied);
    }

    public static deactivateOnemptied(): void {
        document.removeEventListener("emptied", DocumentAPI.onemptied);
    }


    // Timing

    // HTMLMediaElement - play event

    private static onplay() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePlay");
    }

    public static activateOnplay(): void {
        document.addEventListener("play", DocumentAPI.onplay);
    }

    public static deactivateOnplay(): void {
        document.removeEventListener("play", DocumentAPI.onplay);
    }


    // HTMLMediaElement - pause event

    private static onpause() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokePause");
    }

    public static activateOnpause(): void {
        document.addEventListener("pause", DocumentAPI.onpause);
    }

    public static deactivateOnpause(): void {
        document.removeEventListener("pause", DocumentAPI.onpause);
    }


    // HTMLMediaElement - ended event

    private static onended() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeEnded");
    }

    public static activateOnended(): void {
        document.addEventListener("ended", DocumentAPI.onended);
    }

    public static deactivateOnended(): void {
        document.removeEventListener("ended", DocumentAPI.onended);
    }


    // HTMLMediaElement - seeking event

    private static onseeking() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeSeeking");
    }

    public static activateOnseeking(): void {
        document.addEventListener("seeking", DocumentAPI.onseeking);
    }

    public static deactivateOnseeking(): void {
        document.removeEventListener("seeking", DocumentAPI.onseeking);
    }


    // HTMLMediaElement - seeked event

    private static onseeked() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeSeeked");
    }

    public static activateOnseeked(): void {
        document.addEventListener("seeked", DocumentAPI.onseeked);
    }

    public static deactivateOnseeked(): void {
        document.removeEventListener("seeked", DocumentAPI.onseeked);
    }


    // HTMLMediaElement - timeupdate event

    private static ontimeupdate() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeTimeUpdate");
    }

    public static activateOntimeupdate(): void {
        document.addEventListener("timeupdate", DocumentAPI.ontimeupdate);
    }

    public static deactivateOntimeupdate(): void {
        document.removeEventListener("timeupdate", DocumentAPI.ontimeupdate);
    }


    // Setting

    // HTMLMediaElement - volumechange event

    private static onvolumechange() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeVolumeChange");
    }

    public static activateOnvolumechange(): void {
        document.addEventListener("volumechange", DocumentAPI.onvolumechange);
    }

    public static deactivateOnvolumechange(): void {
        document.removeEventListener("volumechange", DocumentAPI.onvolumechange);
    }


    // HTMLMediaElement - ratechange event

    private static onratechange() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeRateChange");
    }

    public static activateOnratechange(): void {
        document.addEventListener("ratechange", DocumentAPI.onratechange);
    }

    public static deactivateOnratechange(): void {
        document.removeEventListener("ratechange", DocumentAPI.onratechange);
    }


    // HTMLMediaElement - durationchange event

    private static ondurationchange() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeDurationChange");
    }

    public static activateOndurationchange(): void {
        document.addEventListener("durationchange", DocumentAPI.ondurationchange);
    }

    public static deactivateOndurationchange(): void {
        document.removeEventListener("durationchange", DocumentAPI.ondurationchange);
    }


    // Video

    // HTMLMediaElement - resize event

    private static onresize() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeResize");
    }

    public static activateOnresize(): void {
        document.addEventListener("resize", DocumentAPI.onresize);
    }

    public static deactivateOnresize(): void {
        document.removeEventListener("resize", DocumentAPI.onresize);
    }



    // HTMLDialogElement - close event

    private static onclose() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeClose");
    }

    public static activateOnclose(): void {
        document.addEventListener("close", DocumentAPI.onclose);
    }

    public static deactivateOnclose(): void {
        document.removeEventListener("close", DocumentAPI.onclose);
    }


    // HTMLDialogElement - cancel event

    private static oncancel() {
        return BlazorInvoke.method(DocumentAPI.eventTrigger, "InvokeCancel");
    }

    public static activateOncancel(): void {
        document.addEventListener("cancel", DocumentAPI.oncancel);
    }

    public static deactivateOncancel(): void {
        document.removeEventListener("cancel", DocumentAPI.oncancel);
    }
}
