import { HTMLElementAPI } from "../HTMLElement/HTMLElement";
import { FileAPI } from "../FileSystem/File/File";
import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class DocumentAPI {
    // properties - HTMLElement reference

    static getDocumentElement(): HTMLElementAPI {
        return new HTMLElementAPI(document.documentElement);
    }

    static getHead(): HTMLElementAPI {
        return new HTMLElementAPI(document.head);
    }

    static getBody(): HTMLElementAPI {
        return new HTMLElementAPI(document.body);
    }

    static setBody(value: HTMLElementAPI): void {
        document.body = value.htmlElement;
    }

    static getScrollingElement(): [HTMLElementAPI] | [null] {
        const result = document.scrollingElement;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    // properties - HTMLElement collection

    static getEmbeds(): HTMLElementAPI[] {
        return [...document.embeds].map(embedElement => DotNet.createJSObjectReference(new HTMLElementAPI(embedElement)));
    }

    static getForms(): HTMLElementAPI[] {
        return [...document.forms].map(formElement => DotNet.createJSObjectReference(new HTMLElementAPI(formElement)));
    }

    static getImages(): HTMLElementAPI[] {
        return [...document.images].map(imageElement => DotNet.createJSObjectReference(new HTMLElementAPI(imageElement)));
    }

    static getLinks(): HTMLElementAPI[] {
        return [...document.links].map(linkElement => DotNet.createJSObjectReference(new HTMLElementAPI(linkElement)));
    }

    static getPlugins(): HTMLElementAPI[] {
        return [...document.plugins].map(pluginElement => DotNet.createJSObjectReference(new HTMLElementAPI(pluginElement)));
    }

    static getScripts(): HTMLElementAPI[] {
        return [...document.scripts].map(scriptElement => DotNet.createJSObjectReference(new HTMLElementAPI(scriptElement)));
    }

    // properties - HTMLElement situational

    static getActiveElement(): [HTMLElementAPI] | [null] {
        const result = document.activeElement;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    static getCurrentScript(): [HTMLElementAPI] | [null] {
        const result = document.currentScript;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    static getFullscreenElement(): [HTMLElementAPI] | [null] {
        const result = document.fullscreenElement;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    static getPictureInPictureElement(): [HTMLElementAPI] | [null] {
        const result = document.pictureInPictureElement;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    static getPointerLockElement(): [HTMLElementAPI] | [null] {
        const result = document.pointerLockElement;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    // properties

    static getCharacterSet(): string {
        return document.characterSet;
    }

    static getCompatMode(): string {
        return document.compatMode;
    }

    static getContentType(): string {
        return document.contentType;
    }

    static getDesignMode(): string {
        return document.designMode;
    }

    static setDesignMode(value: string): void {
        document.designMode = value;
    }

    static getDir(): string {
        return document.dir;
    }

    static setDir(value: string): void {
        document.dir = value;
    }

    static getDocumentURI(): string {
        return document.documentURI;
    }

    static getFullscreenEnabled(): boolean {
        return document.fullscreenEnabled;
    }

    static getHidden(): boolean {
        return document.hidden;
    }

    static getLastModified(): string {
        return document.lastModified;
    }

    static getPictureInPictureEnabled(): boolean {
        return document.pictureInPictureEnabled;
    }

    static getReadyState(): DocumentReadyState {
        return document.readyState;
    }

    static getReferrer(): string {
        return document.referrer;
    }

    static getTitle(): string {
        return document.title;
    }

    static setTitle(value: string): void {
        document.title = value;
    }

    static getURL(): string {
        return document.URL;
    }

    static getVisibilityState(): string {
        return document.visibilityState;
    }

    // properties - Node

    static getBaseURI(): string {
        return document.baseURI;
    }


    // methods - DOM

    static createElement(tagName: string): HTMLElementAPI {
        return new HTMLElementAPI(document.createElement(tagName));
    }

    static createElementNS(namespaceURI: string, qualifiedName: string): HTMLElementAPI {
        return new HTMLElementAPI(<HTMLElement>document.createElementNS(namespaceURI, qualifiedName));
    }

    static getElementById(elementId: string): [HTMLElementAPI] | [null] {
        const result = document.getElementById(elementId);
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(result))];
        else
            return [null];
    }

    static getElementsByClassName(classNames: string): HTMLElementAPI[] {
        return [...document.getElementsByClassName(classNames)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    static getElementsByTagName(qualifiedName: string): HTMLElementAPI[] {
        return [...document.getElementsByTagName(qualifiedName)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    static getElementsByTagNameNS(namespaceURL: string, localName: string): HTMLElementAPI[] {
        return [...document.getElementsByTagNameNS(namespaceURL, localName)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    static getElementsByName(elementName: string): HTMLElementAPI[] {
        return [...document.getElementsByName(elementName)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    static querySelector(selectors: string): [HTMLElementAPI] | [null] {
        const result = document.querySelector(selectors);
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    static querySelectorAll(selectors: string): HTMLElementAPI[] {
        return [...document.querySelectorAll(selectors)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    static elementFromPoint(x: number, y: number): [HTMLElementAPI] | [null] {
        const result = document.elementFromPoint(x, y);
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    static elementsFromPoint(x: number, y: number): HTMLElementAPI[] {
        return [...document.elementsFromPoint(x, y)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    static replaceChildren(children: HTMLElementAPI[]): void {
        document.replaceChildren(...children.map(wrapper => wrapper.htmlElement));
    }

    // methods - StorageAccess

    static requestStorageAccess(all: boolean, cookies: boolean, sessionStorage: boolean, localStorage: boolean, indexedDB: boolean, locks: boolean, caches: boolean, getDirectory: boolean, estimate: boolean, createObjectURL: boolean, revokeObjectURL: boolean, BroadcastChannel: boolean, SharedWorker: boolean): Promise<void> {
        return (<Document & { requestStorageAccess(types: { all: boolean, cookies: boolean, sessionStorage: boolean, localStorage: boolean, indexedDB: boolean, locks: boolean, caches: boolean, getDirectory: boolean, estimate: boolean, createObjectURL: boolean, revokeObjectURL: boolean, BroadcastChannel: boolean, SharedWorker: boolean; }): Promise<void>; }>document)
            .requestStorageAccess({ all, cookies, sessionStorage, localStorage, indexedDB, locks, caches, getDirectory, estimate, createObjectURL, revokeObjectURL, BroadcastChannel, SharedWorker });
    }

    static requestStorageAccessFor(requestedOrigin: string): Promise<void> {
        return (<Document & { requestStorageAccessFor(requestedOrigin: string): Promise<void>; }>document).requestStorageAccessFor(requestedOrigin);
    }

    static hasStorageAccess(): Promise<boolean> {
        return document.hasStorageAccess();
    }

    // methods - exit

    static exitFullscreen(): Promise<void> {
        return document.exitFullscreen();
    }

    static exitPictureInPicture(): Promise<void> {
        return document.exitPictureInPicture();
    }

    static exitPointerLock(): void {
        document.exitPointerLock();
    }

    // methods

    static hasFocus(): boolean {
        return document.hasFocus();
    }

    // methods - Node

    static compareDocumentPosition(other: HTMLElementAPI): number {
        return document.compareDocumentPosition(other.htmlElement);
    }

    static contains(other: HTMLElementAPI): boolean {
        return document.contains(other.htmlElement);
    }

    static isDefaultNamespace(namespace: string | null): boolean {
        return document.isDefaultNamespace(namespace);
    }

    static lookupPrefix(namespace: string | null): string | null {
        return document.lookupPrefix(namespace);
    }

    static lookupNamespaceURI(prefix: string | null): string | null {
        return document.lookupNamespaceURI(prefix);
    }

    static normalize(): void {
        document.normalize();
    }


    // events


    static #eventTrigger: DotNet.DotNetObject;

    static initEvents(eventTrigger: DotNet.DotNetObject): void {
        DocumentAPI.#eventTrigger = eventTrigger;
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


    // securitypolicyviolation event

    static #onsecuritypolicyviolation(violationEvent: SecurityPolicyViolationEvent) {
        BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeSecurityPolicyViolation", {
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

    static activateOnsecuritypolicyviolation(): void {
        document.addEventListener("securitypolicyviolation", DocumentAPI.#onsecuritypolicyviolation);
    }

    static deactivateOnsecuritypolicyviolation(): void {
        document.removeEventListener("securitypolicyviolation", DocumentAPI.#onsecuritypolicyviolation);
    }


    // visibilitychange event

    static #onvisibilitychange() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeVisibilityChange");
    }

    static activateOnvisibilitychange(): void {
        document.addEventListener("visibilitychange", DocumentAPI.#onvisibilitychange);
    }

    static deactivateOnvisibilitychange(): void {
        document.removeEventListener("visibilitychange", DocumentAPI.#onvisibilitychange);
    }


    // fullscreenchange event

    static #onfullscreenchange() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeFullscreenChange");
    }

    static activateOnfullscreenchange(): void {
        document.addEventListener("fullscreenchange", DocumentAPI.#onfullscreenchange);
    }

    static deactivateOnfullscreenchange(): void {
        document.removeEventListener("fullscreenchange", DocumentAPI.#onfullscreenchange);
    }


    // fullscreenerror event

    static #onfullscreenerror() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeFullscreenError");
    }

    static activateOnfullscreenerror(): void {
        document.addEventListener("fullscreenerror", DocumentAPI.#onfullscreenerror);
    }

    static deactivateOnfullscreenerror(): void {
        document.removeEventListener("fullscreenerror", DocumentAPI.#onfullscreenerror);
    }


    // DOMContentLoaded event

    static #onDOMContentLoaded() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeDOMContentLoaded");
    }

    static activateOnDOMContentLoaded(): void {
        document.addEventListener("DOMContentLoaded", DocumentAPI.#onDOMContentLoaded);
    }

    static deactivateOnDOMContentLoaded(): void {
        document.removeEventListener("DOMContentLoaded", DocumentAPI.#onDOMContentLoaded);
    }


    // readystatechange event

    static #onreadystatechange() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeReadyStateChange");
    }

    static activateOnreadystatechange(): void {
        document.addEventListener("readystatechange", DocumentAPI.#onreadystatechange);
    }

    static deactivateOnreadystatechange(): void {
        document.removeEventListener("readystatechange", DocumentAPI.#onreadystatechange);
    }


    // pointerlockchange event

    static #onpointerlockchange() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePointerLockChange");
    }

    static activateOnpointerlockchange(): void {
        document.addEventListener("pointerlockchange", DocumentAPI.#onpointerlockchange);
    }

    static deactivateOnpointerlockchange(): void {
        document.removeEventListener("pointerlockchange", DocumentAPI.#onpointerlockchange);
    }


    // pointerlockerror event

    static #onpointerlockerror() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePointerLockError");
    }

    static activateOnpointerlockerror(): void {
        document.addEventListener("pointerlockerror", DocumentAPI.#onpointerlockerror);
    }

    static deactivateOnpointerlockerror(): void {
        document.removeEventListener("pointerlockerror", DocumentAPI.#onpointerlockerror);
    }


    // scroll event

    static #onscroll() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeScroll");
    }

    static activateOnscroll(): void {
        document.addEventListener("scroll", DocumentAPI.#onscroll);
    }

    static deactivateOnscroll(): void {
        document.removeEventListener("scroll", DocumentAPI.#onscroll);
    }


    // scrollend event

    static #onscrollend() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeScrollEnd");
    }

    static activateOnscrollend(): void {
        document.addEventListener("scrollend", DocumentAPI.#onscrollend);
    }

    static deactivateOnscrollend(): void {
        document.removeEventListener("scrollend", DocumentAPI.#onscrollend);
    }


    // selectionchange event

    static #onselectionchange() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeSelectionChange");
    }

    static activateOnselectionchange(): void {
        document.addEventListener("selectionchange", DocumentAPI.#onselectionchange);
    }

    static deactivateOnselectionchange(): void {
        document.removeEventListener("selectionchange", DocumentAPI.#onselectionchange);
    }


    // Node - selectstart event

    static #onselectstart() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeSelectStart");
    }

    static activateOnselectstart(): void {
        document.addEventListener("selectstart", DocumentAPI.#onselectstart);
    }

    static deactivateOnselectstart(): void {
        document.removeEventListener("selectstart", DocumentAPI.#onselectstart);
    }


    // bubble events

    // HTMLElement - change event

    static #onchange() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeChange");
    }

    static activateOnchange(): void {
        document.addEventListener("change", DocumentAPI.#onchange);
    }

    static deactivateOnchange(): void {
        document.removeEventListener("change", DocumentAPI.#onchange);
    }


    // HTMLElement - load event

    static #onload() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeLoad");
    }

    static activateOnload(): void {
        document.addEventListener("load", DocumentAPI.#onload);
    }

    static deactivateOnload(): void {
        document.removeEventListener("load", DocumentAPI.#onload);
    }


    // HTMLElement - error event

    static #onerror(error: Event) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeError", error);
    }

    static activateOnerror(): void {
        document.addEventListener("error", DocumentAPI.#onerror);
    }

    static deactivateOnerror(): void {
        document.removeEventListener("error", DocumentAPI.#onerror);
    }


    // HTMLElement - drag event

    static #ondrag(dragEvent: DragEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeDrag", ...DocumentAPI.#deconstructDataTransfer(dragEvent.dataTransfer));
    }

    static activateOndrag(): void {
        document.addEventListener("drag", DocumentAPI.#ondrag);
    }

    static deactivateOndrag(): void {
        document.removeEventListener("drag", DocumentAPI.#ondrag);
    }


    // HTMLElement - dragstart event

    static #ondragstart(dragEvent: DragEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeDragStart", ...DocumentAPI.#deconstructDataTransfer(dragEvent.dataTransfer));
    }

    static activateOndragstart(): void {
        document.addEventListener("dragstart", DocumentAPI.#ondragstart);
    }

    static deactivateOndragstart(): void {
        document.removeEventListener("dragstart", DocumentAPI.#ondragstart);
    }


    // HTMLElement - dragend event

    static #ondragend(dragEvent: DragEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeDragEnd", ...DocumentAPI.#deconstructDataTransfer(dragEvent.dataTransfer));
    }

    static activateOndragend(): void {
        document.addEventListener("dragend", DocumentAPI.#ondragend);
    }

    static deactivateOndragend(): void {
        document.removeEventListener("dragend", DocumentAPI.#ondragend);
    }


    // HTMLElement - dragenter event

    static #ondragenter(dragEvent: DragEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeDragEnter", ...DocumentAPI.#deconstructDataTransfer(dragEvent.dataTransfer));
    }

    static activateOndragenter(): void {
        document.addEventListener("dragenter", DocumentAPI.#ondragenter);
    }

    static deactivateOndragenter(): void {
        document.removeEventListener("dragenter", DocumentAPI.#ondragenter);
    }


    // HTMLElement - dragleave event

    static #ondragleave(dragEvent: DragEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeDragLeave", ...DocumentAPI.#deconstructDataTransfer(dragEvent.dataTransfer));
    }

    static activateOndragleave(): void {
        document.addEventListener("dragleave", DocumentAPI.#ondragleave);
    }

    static deactivateOndragleave(): void {
        document.removeEventListener("dragleave", DocumentAPI.#ondragleave);
    }


    // HTMLElement - dragover event

    static #ondragover(dragEvent: DragEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeDragOver", ...DocumentAPI.#deconstructDataTransfer(dragEvent.dataTransfer));
    }

    static activateOndragover(): void {
        document.addEventListener("dragover", DocumentAPI.#ondragover);
    }

    static deactivateOndragover(): void {
        document.removeEventListener("dragover", DocumentAPI.#ondragover);
    }


    // HTMLElement - drop event

    static #ondrop(dragEvent: DragEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeDrop", ...DocumentAPI.#deconstructDataTransfer(dragEvent.dataTransfer));
    }

    static activateOndrop(): void {
        document.addEventListener("drop", DocumentAPI.#ondrop);
    }

    static deactivateOndrop(): void {
        document.removeEventListener("drop", DocumentAPI.#ondrop);
    }


    // HTMLElement - toggle

    static #ontoggle(toggleEvent: ToggleEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeToggle", toggleEvent.oldState, toggleEvent.newState);
    }

    static activateOntoggle(): void {
        document.addEventListener("toggle", DocumentAPI.#ontoggle);
    }

    static deactivateOntoggle(): void {
        document.removeEventListener("toggle", DocumentAPI.#ontoggle);
    }


    // HTMLElement - beforetoggle

    static #onbeforetoggle(toggleEvent: ToggleEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeBeforeToggle", toggleEvent.oldState, toggleEvent.newState);
    }

    static activateOnbeforetoggle(): void {
        document.addEventListener("beforetoggle", DocumentAPI.#onbeforetoggle);
    }

    static deactivateOnbeforetoggle(): void {
        document.removeEventListener("beforetoggle", DocumentAPI.#onbeforetoggle);
    }



    // Element - input event

    static #oninput(inputEvent: InputEvent | Event) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeInput", ...DocumentAPI.#deconstructInputEvent(inputEvent));
    }

    static activateOninput(): void {
        document.addEventListener("input", DocumentAPI.#oninput);
    }

    static deactivateOninput(): void {
        document.removeEventListener("input", DocumentAPI.#oninput);
    }


    // Element - beforeinput event

    static #onbeforeinput(inputEvent: InputEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeBeforeInput", ...DocumentAPI.#deconstructInputEvent(inputEvent));
    }

    static activateOnbeforeinput(): void {
        document.addEventListener("beforeinput", DocumentAPI.#onbeforeinput);
    }

    static deactivateOnbeforeinput(): void {
        document.removeEventListener("beforeinput", DocumentAPI.#onbeforeinput);
    }


    // Element - beforematch event

    static #onbeforematch() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeBeforeMatch");
    }

    static activateOnbeforematch(): void {
        document.addEventListener("beforematch", DocumentAPI.#onbeforematch);
    }

    static deactivateOnbeforematch(): void {
        document.removeEventListener("beforematch", DocumentAPI.#onbeforematch);
    }



    // Element - keydown event

    static #onkeydown(keyboardEvent: KeyboardEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeKeyDown", {
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

    static activateOnkeydown(): void {
        document.addEventListener("keydown", DocumentAPI.#onkeydown);
    }

    static deactivateOnkeydown(): void {
        document.removeEventListener("keydown", DocumentAPI.#onkeydown);
    }


    // Element - keyup event

    static #onkeyup(keyboardEvent: KeyboardEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeKeyUp", {
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

    static activateOnkeyup(): void {
        document.addEventListener("keyup", DocumentAPI.#onkeyup);
    }

    static deactivateOnkeyup(): void {
        document.removeEventListener("keyup", DocumentAPI.#onkeyup);
    }



    // Element - click event

    static #onclick(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeClick", {
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

    static activateOnclick(): void {
        document.addEventListener("click", DocumentAPI.#onclick);
    }

    static deactivateOnclick(): void {
        document.removeEventListener("click", DocumentAPI.#onclick);
    }


    // Element - dblclick event

    static #ondblclick(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeDblClick", {
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

    static activateOndblclick(): void {
        document.addEventListener("dblclick", DocumentAPI.#ondblclick);
    }

    static deactivateOndblclick(): void {
        document.removeEventListener("dblclick", DocumentAPI.#ondblclick);
    }


    // Element - auxclick event

    static #onauxclick(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeAuxClick", {
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

    static activateOnauxclick(): void {
        document.addEventListener("auxclick", DocumentAPI.#onauxclick);
    }

    static deactivateOnauxclick(): void {
        document.removeEventListener("auxclick", DocumentAPI.#onauxclick);
    }


    // Element - contextmenu event

    static #oncontextmenu(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeContextMenu", {
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

    static activateOncontextmenu(): void {
        document.addEventListener("contextmenu", DocumentAPI.#oncontextmenu);
    }

    static deactivateOncontextmenu(): void {
        document.removeEventListener("contextmenu", DocumentAPI.#oncontextmenu);
    }


    // Element - mousedown event

    static #onmousedown(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeMouseDown", {
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

    static activateOnmousedown(): void {
        document.addEventListener("mousedown", DocumentAPI.#onmousedown);
    }

    static deactivateOnmousedown(): void {
        document.removeEventListener("mousedown", DocumentAPI.#onmousedown);
    }


    // Element - mouseup event

    static #onmouseup(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeMouseUp", {
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

    static activateOnmouseup(): void {
        document.addEventListener("mouseup", DocumentAPI.#onmouseup);
    }

    static deactivateOnmouseup(): void {
        document.removeEventListener("mouseup", DocumentAPI.#onmouseup);
    }


    // Element - wheel event

    static #onwheel(wheelEvent: WheelEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeWheel", {
            deltaX: wheelEvent.deltaX,
            deltaY: wheelEvent.deltaY,
            deltaZ: wheelEvent.deltaZ,
            deltaMode: wheelEvent.deltaMode
        });
    }

    static activateOnwheel(): void {
        document.addEventListener("wheel", DocumentAPI.#onwheel, { passive: true });
    }

    static deactivateOnwheel(): void {
        document.removeEventListener("wheel", DocumentAPI.#onwheel);
    }


    // Element - mousemove event

    static #onmousemove(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeMouseMove", {
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

    static activateOnmousemove(): void {
        document.addEventListener("mousemove", DocumentAPI.#onmousemove);
    }

    static deactivateOnmousemove(): void {
        document.removeEventListener("mousemove", DocumentAPI.#onmousemove);
    }


    // Element - mouseover event

    static #onmouseover(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeMouseOver", {
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

    static activateOnmouseover(): void {
        document.addEventListener("mouseover", DocumentAPI.#onmouseover);
    }

    static deactivateOnmouseover(): void {
        document.removeEventListener("mouseover", DocumentAPI.#onmouseover);
    }


    // Element - mouseout event

    static #onmouseout(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeMouseOut", {
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

    static activateOnmouseout(): void {
        document.addEventListener("mouseout", DocumentAPI.#onmouseout);
    }

    static deactivateOnmouseout(): void {
        document.removeEventListener("mouseout", DocumentAPI.#onmouseout);
    }


    // Element - mouseenter event

    static #onmouseenter(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeMouseEnter", {
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

    static activateOnmouseenter(): void {
        document.addEventListener("mouseenter", DocumentAPI.#onmouseenter);
    }

    static deactivateOnmouseenter(): void {
        document.removeEventListener("mouseenter", DocumentAPI.#onmouseenter);
    }


    // Element - mouseleave event

    static #onmouseleave(mouseEvent: MouseEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeMouseLeave", {
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

    static activateOnmouseleave(): void {
        document.addEventListener("mouseleave", DocumentAPI.#onmouseleave);
    }

    static deactivateOnmouseleave(): void {
        document.removeEventListener("mouseleave", DocumentAPI.#onmouseleave);
    }



    // Element - touchstart event

    static #ontouchstart(touchEvent: TouchEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeTouchStart", {
            touches: DocumentAPI.#deconstructTouchList(touchEvent.touches),
            targetTouches: DocumentAPI.#deconstructTouchList(touchEvent.targetTouches),
            changedTouches: DocumentAPI.#deconstructTouchList(touchEvent.changedTouches),
            ctrlKey: touchEvent.ctrlKey,
            shiftKey: touchEvent.shiftKey,
            altKey: touchEvent.altKey,
            metaKey: touchEvent.metaKey
        });
    }

    static activateOntouchstart(): void {
        document.addEventListener("touchstart", DocumentAPI.#ontouchstart);
    }

    static deactivateOntouchstart(): void {
        document.removeEventListener("touchstart", DocumentAPI.#ontouchstart);
    }


    // Element - touchend event

    static #ontouchend(touchEvent: TouchEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeTouchEnd", {
            touches: DocumentAPI.#deconstructTouchList(touchEvent.touches),
            targetTouches: DocumentAPI.#deconstructTouchList(touchEvent.targetTouches),
            changedTouches: DocumentAPI.#deconstructTouchList(touchEvent.changedTouches),
            ctrlKey: touchEvent.ctrlKey,
            shiftKey: touchEvent.shiftKey,
            altKey: touchEvent.altKey,
            metaKey: touchEvent.metaKey
        });
    }

    static activateOntouchend(): void {
        document.addEventListener("touchend", DocumentAPI.#ontouchend);
    }

    static deactivateOntouchend(): void {
        document.removeEventListener("touchend", DocumentAPI.#ontouchend);
    }


    // Element - touchmove event

    static #ontouchmove(touchEvent: TouchEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeTouchMove", {
            touches: DocumentAPI.#deconstructTouchList(touchEvent.touches),
            targetTouches: DocumentAPI.#deconstructTouchList(touchEvent.targetTouches),
            changedTouches: DocumentAPI.#deconstructTouchList(touchEvent.changedTouches),
            ctrlKey: touchEvent.ctrlKey,
            shiftKey: touchEvent.shiftKey,
            altKey: touchEvent.altKey,
            metaKey: touchEvent.metaKey
        });
    }

    static activateOntouchmove(): void {
        document.addEventListener("touchmove", DocumentAPI.#ontouchmove);
    }

    static deactivateOntouchmove(): void {
        document.removeEventListener("touchmove", DocumentAPI.#ontouchmove);
    }


    // Element - touchcancel event

    static #ontouchcancel(touchEvent: TouchEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeTouchCancel", {
            touches: DocumentAPI.#deconstructTouchList(touchEvent.touches),
            targetTouches: DocumentAPI.#deconstructTouchList(touchEvent.targetTouches),
            changedTouches: DocumentAPI.#deconstructTouchList(touchEvent.changedTouches),
            ctrlKey: touchEvent.ctrlKey,
            shiftKey: touchEvent.shiftKey,
            altKey: touchEvent.altKey,
            metaKey: touchEvent.metaKey
        });
    }

    static activateOntouchcancel(): void {
        document.addEventListener("touchcancel", DocumentAPI.#ontouchcancel);
    }

    static deactivateOntouchcancel(): void {
        document.removeEventListener("touchcancel", DocumentAPI.#ontouchcancel);
    }



    // Element - pointerdown event

    static #onpointerdown(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePointerDown", {
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

    static activateOnpointerdown(): void {
        document.addEventListener("pointerdown", DocumentAPI.#onpointerdown);
    }

    static deactivateOnpointerdown(): void {
        document.removeEventListener("pointerdown", DocumentAPI.#onpointerdown);
    }


    // Element - pointerup event

    static #onpointerup(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePointerUp", {
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

    static activateOnpointerup(): void {
        document.addEventListener("pointerup", DocumentAPI.#onpointerup);
    }

    static deactivateOnpointerup(): void {
        document.removeEventListener("pointerup", DocumentAPI.#onpointerup);
    }


    // Element - pointermove event

    static #onpointermove(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePointerMove", {
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

    static activateOnpointermove(): void {
        document.addEventListener("pointermove", DocumentAPI.#onpointermove);
    }

    static deactivateOnpointermove(): void {
        document.removeEventListener("pointermove", DocumentAPI.#onpointermove);
    }


    // Element - pointerover event

    static #onpointerover(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePointerOver", {
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

    static activateOnpointerover(): void {
        document.addEventListener("pointerover", DocumentAPI.#onpointerover);
    }

    static deactivateOnpointerover(): void {
        document.removeEventListener("pointerover", DocumentAPI.#onpointerover);
    }


    // Element - pointerout event

    static #onpointerout(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePointerOut", {
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

    static activateOnpointerout(): void {
        document.addEventListener("pointerout", DocumentAPI.#onpointerout);
    }

    static deactivateOnpointerout(): void {
        document.removeEventListener("pointerout", DocumentAPI.#onpointerout);
    }


    // Element - pointerenter event

    static #onpointerenter(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePointerEnter", {
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

    static activateOnpointerenter(): void {
        document.addEventListener("pointerenter", DocumentAPI.#onpointerenter);
    }

    static deactivateOnpointerenter(): void {
        document.removeEventListener("pointerenter", DocumentAPI.#onpointerenter);
    }


    // Element - pointerleave event

    static #onpointerleave(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePointerLeave", {
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

    static activateOnpointerleave(): void {
        document.addEventListener("pointerleave", DocumentAPI.#onpointerleave);
    }

    static deactivateOnpointerleave(): void {
        document.removeEventListener("pointerleave", DocumentAPI.#onpointerleave);
    }


    // Element - pointercancel event

    static #onpointercancel(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePointerCancel", {
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

    static activateOnpointercancel(): void {
        document.addEventListener("pointercancel", DocumentAPI.#onpointercancel);
    }

    static deactivateOnpointercancel(): void {
        document.removeEventListener("pointercancel", DocumentAPI.#onpointercancel);
    }


    // Element - pointerrawupdate event

    static #onpointerrawupdate(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePointerRawUpdate", {
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

    static activateOnpointerrawupdate(): void {
        document.addEventListener("pointerrawupdate", DocumentAPI.#onpointerrawupdate);
    }

    static deactivateOnpointerrawupdate(): void {
        document.removeEventListener("pointerrawupdate", DocumentAPI.#onpointerrawupdate);
    }


    // Element - gotpointercapture event

    static #ongotpointercapture(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeGotPointerCapture", {
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

    static activateOngotpointercapture(): void {
        document.addEventListener("gotpointercapture", DocumentAPI.#ongotpointercapture);
    }

    static deactivateOngotpointercapture(): void {
        document.removeEventListener("gotpointercapture", DocumentAPI.#ongotpointercapture);
    }


    // Element - lostpointercapture event

    static #onlostpointercapture(pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number; }) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeLostPointerCapture", {
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

    static activateOnlostpointercapture(): void {
        document.addEventListener("lostpointercapture", DocumentAPI.#onlostpointercapture);
    }

    static deactivateOnlostpointercapture(): void {
        document.removeEventListener("lostpointercapture", DocumentAPI.#onlostpointercapture);
    }



    // Element - focus event

    static #onfocus() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeFocus");
    }

    static activateOnfocus(): void {
        document.addEventListener("focus", DocumentAPI.#onfocus);
    }

    static deactivateOnfocus(): void {
        document.removeEventListener("focus", DocumentAPI.#onfocus);
    }


    // Element - focusin event

    static #onfocusin() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeFocusIn");
    }

    static activateOnfocusin(): void {
        document.addEventListener("focusin", DocumentAPI.#onfocusin);
    }

    static deactivateOnfocusin(): void {
        document.removeEventListener("focusin", DocumentAPI.#onfocusin);
    }


    // Element - blur event

    static #onblur() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeBlur");
    }

    static activateOnblur(): void {
        document.addEventListener("blur", DocumentAPI.#onblur);
    }

    static deactivateOnblur(): void {
        document.removeEventListener("blur", DocumentAPI.#onblur);
    }


    // Element - focusout event

    static #onfocusout() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeFocusOut");
    }

    static activateOnfocusout(): void {
        document.addEventListener("focusout", DocumentAPI.#onfocusout);
    }

    static deactivateOnfocusout(): void {
        document.removeEventListener("focusout", DocumentAPI.#onfocusout);
    }



    // Element - copy event

    static #oncopy() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeCopy");
    }

    static activateOncopy(): void {
        document.addEventListener("copy", DocumentAPI.#oncopy);
    }

    static deactivateOncopy(): void {
        document.removeEventListener("copy", DocumentAPI.#oncopy);
    }


    // Element - paste event

    static #onpaste() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePaste");
    }

    static activateOnpaste(): void {
        document.addEventListener("paste", DocumentAPI.#onpaste);
    }

    static deactivateOnpaste(): void {
        document.removeEventListener("paste", DocumentAPI.#onpaste);
    }


    // Element - cut event

    static #oncut() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeCut");
    }

    static activateOncut(): void {
        document.addEventListener("cut", DocumentAPI.#oncut);
    }

    static deactivateOncut(): void {
        document.removeEventListener("cut", DocumentAPI.#oncut);
    }



    // Element - transitionstart event

    static #ontransitionstart(transitionEvent: TransitionEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeTransitionStart", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);
    }

    static activateOntransitionstart(): void {
        document.addEventListener("transitionstart", DocumentAPI.#ontransitionstart);
    }

    static deactivateOntransitionstart(): void {
        document.removeEventListener("transitionstart", DocumentAPI.#ontransitionstart);
    }


    // Element - transitionend event

    static #ontransitionend(transitionEvent: TransitionEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeTransitionEnd", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);
    }

    static activateOntransitionend(): void {
        document.addEventListener("transitionend", DocumentAPI.#ontransitionend);
    }

    static deactivateOntransitionend(): void {
        document.removeEventListener("transitionend", DocumentAPI.#ontransitionend);
    }


    // Element - transitionrun event

    static #ontransitionrun(transitionEvent: TransitionEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeTransitionRun", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);
    }

    static activateOntransitionrun(): void {
        document.addEventListener("transitionrun", DocumentAPI.#ontransitionrun);
    }

    static deactivateOntransitionrun(): void {
        document.removeEventListener("transitionrun", DocumentAPI.#ontransitionrun);
    }


    // Element - transitioncancel event

    static #ontransitioncancel(transitionEvent: TransitionEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeTransitionCancel", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);
    }

    static activateOntransitioncancel(): void {
        document.addEventListener("transitioncancel", DocumentAPI.#ontransitioncancel);
    }

    static deactivateOntransitioncancel(): void {
        document.removeEventListener("transitioncancel", DocumentAPI.#ontransitioncancel);
    }



    // Element - animationstart event

    static #onanimationstart(animationEvent: AnimationEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeAnimationStart", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);
    }

    static activateOnanimationstart(): void {
        document.addEventListener("animationstart", DocumentAPI.#onanimationstart);
    }

    static deactivateOnanimationstart(): void {
        document.removeEventListener("animationstart", DocumentAPI.#onanimationstart);
    }


    // Element - animationend event

    static #onanimationend(animationEvent: AnimationEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeAnimationEnd", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);
    }

    static activateOnanimationend(): void {
        document.addEventListener("animationend", DocumentAPI.#onanimationend);
    }

    static deactivateOnanimationend(): void {
        document.removeEventListener("animationend", DocumentAPI.#onanimationend);
    }


    // Element - animationiteration event

    static #onanimationiteration(animationEvent: AnimationEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeAnimationIteration", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);
    }

    static activateOnanimationiteration(): void {
        document.addEventListener("animationiteration", DocumentAPI.#onanimationiteration);
    }

    static deactivateOnanimationiteration(): void {
        document.removeEventListener("animationiteration", DocumentAPI.#onanimationiteration);
    }


    // Element - animationcancel event

    static #onanimationcancel(animationEvent: AnimationEvent) {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeAnimationCancel", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);
    }

    static activateOnanimationcancel(): void {
        document.addEventListener("animationcancel", DocumentAPI.#onanimationcancel);
    }

    static deactivateOnanimationcancel(): void {
        document.removeEventListener("animationcancel", DocumentAPI.#onanimationcancel);
    }



    // HTMLMediaElement - canplay event

    static #oncanplay() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeCanPlay");
    }

    static activateOncanplay(): void {
        document.addEventListener("canplay", DocumentAPI.#oncanplay);
    }

    static deactivateOncanplay(): void {
        document.removeEventListener("canplay", DocumentAPI.#oncanplay);
    }


    // HTMLMediaElement - canplaythrough event

    static #oncanplaythrough() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeCanPlayThrough");
    }

    static activateOncanplaythrough(): void {
        document.addEventListener("canplaythrough", DocumentAPI.#oncanplaythrough);
    }

    static deactivateOncanplaythrough(): void {
        document.removeEventListener("canplaythrough", DocumentAPI.#oncanplaythrough);
    }


    // HTMLMediaElement - playing event

    static #onplaying() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePlaying");
    }

    static activateOnplaying(): void {
        document.addEventListener("playing", DocumentAPI.#onplaying);
    }

    static deactivateOnplaying(): void {
        document.removeEventListener("playing", DocumentAPI.#onplaying);
    }


    // Data

    // HTMLMediaElement - loadstart event

    static #onloadstart() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeLoadStart");
    }

    static activateOnloadstart(): void {
        document.addEventListener("loadstart", DocumentAPI.#onloadstart);
    }

    static deactivateOnloadstart(): void {
        document.removeEventListener("loadstart", DocumentAPI.#onloadstart);
    }


    // HTMLMediaElement - progress event

    static #onprogress() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeProgress");
    }

    static activateOnprogress(): void {
        document.addEventListener("progress", DocumentAPI.#onprogress);
    }

    static deactivateOnprogress(): void {
        document.removeEventListener("progress", DocumentAPI.#onprogress);
    }


    // HTMLMediaElement - loadeddata event

    static #onloadeddata() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeLoadedData");
    }

    static activateOnloadeddata(): void {
        document.addEventListener("loadeddata", DocumentAPI.#onloadeddata);
    }

    static deactivateOnloadeddata(): void {
        document.removeEventListener("loadeddata", DocumentAPI.#onloadeddata);
    }


    // HTMLMediaElement - loadedmetadata event

    static #onloadedmetadata() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeLoadedMetadata");
    }

    static activateOnloadedmetadata(): void {
        document.addEventListener("loadedmetadata", DocumentAPI.#onloadedmetadata);
    }

    static deactivateOnloadedmetadata(): void {
        document.removeEventListener("loadedmetadata", DocumentAPI.#onloadedmetadata);
    }


    // HTMLMediaElement - stalled event

    static #onstalled() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeStalled");
    }

    static activateOnstalled(): void {
        document.addEventListener("stalled", DocumentAPI.#onstalled);
    }

    static deactivateOnstalled(): void {
        document.removeEventListener("stalled", DocumentAPI.#onstalled);
    }


    // HTMLMediaElement - suspend event

    static #onsuspend() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeSuspend");
    }

    static activateOnsuspend(): void {
        document.addEventListener("suspend", DocumentAPI.#onsuspend);
    }

    static deactivateOnsuspend(): void {
        document.removeEventListener("suspend", DocumentAPI.#onsuspend);
    }


    // HTMLMediaElement - waiting event

    static #onwaiting() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeWaiting");
    }

    static activateOnwaiting(): void {
        document.addEventListener("waiting", DocumentAPI.#onwaiting);
    }

    static deactivateOnwaiting(): void {
        document.removeEventListener("waiting", DocumentAPI.#onwaiting);
    }


    // HTMLMediaElement - abort event

    static #onabort() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeAbort");
    }

    static activateOnabort(): void {
        document.addEventListener("abort", DocumentAPI.#onabort);
    }

    static deactivateOnabort(): void {
        document.removeEventListener("abort", DocumentAPI.#onabort);
    }


    // HTMLMediaElement - emptied event

    static #onemptied() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeEmptied");
    }

    static activateOnemptied(): void {
        document.addEventListener("emptied", DocumentAPI.#onemptied);
    }

    static deactivateOnemptied(): void {
        document.removeEventListener("emptied", DocumentAPI.#onemptied);
    }


    // Timing

    // HTMLMediaElement - play event

    static #onplay() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePlay");
    }

    static activateOnplay(): void {
        document.addEventListener("play", DocumentAPI.#onplay);
    }

    static deactivateOnplay(): void {
        document.removeEventListener("play", DocumentAPI.#onplay);
    }


    // HTMLMediaElement - pause event

    static #onpause() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokePause");
    }

    static activateOnpause(): void {
        document.addEventListener("pause", DocumentAPI.#onpause);
    }

    static deactivateOnpause(): void {
        document.removeEventListener("pause", DocumentAPI.#onpause);
    }


    // HTMLMediaElement - ended event

    static #onended() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeEnded");
    }

    static activateOnended(): void {
        document.addEventListener("ended", DocumentAPI.#onended);
    }

    static deactivateOnended(): void {
        document.removeEventListener("ended", DocumentAPI.#onended);
    }


    // HTMLMediaElement - seeking event

    static #onseeking() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeSeeking");
    }

    static activateOnseeking(): void {
        document.addEventListener("seeking", DocumentAPI.#onseeking);
    }

    static deactivateOnseeking(): void {
        document.removeEventListener("seeking", DocumentAPI.#onseeking);
    }


    // HTMLMediaElement - seeked event

    static #onseeked() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeSeeked");
    }

    static activateOnseeked(): void {
        document.addEventListener("seeked", DocumentAPI.#onseeked);
    }

    static deactivateOnseeked(): void {
        document.removeEventListener("seeked", DocumentAPI.#onseeked);
    }


    // HTMLMediaElement - timeupdate event

    static #ontimeupdate() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeTimeUpdate");
    }

    static activateOntimeupdate(): void {
        document.addEventListener("timeupdate", DocumentAPI.#ontimeupdate);
    }

    static deactivateOntimeupdate(): void {
        document.removeEventListener("timeupdate", DocumentAPI.#ontimeupdate);
    }


    // Setting

    // HTMLMediaElement - volumechange event

    static #onvolumechange() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeVolumeChange");
    }

    static activateOnvolumechange(): void {
        document.addEventListener("volumechange", DocumentAPI.#onvolumechange);
    }

    static deactivateOnvolumechange(): void {
        document.removeEventListener("volumechange", DocumentAPI.#onvolumechange);
    }


    // HTMLMediaElement - ratechange event

    static #onratechange() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeRateChange");
    }

    static activateOnratechange(): void {
        document.addEventListener("ratechange", DocumentAPI.#onratechange);
    }

    static deactivateOnratechange(): void {
        document.removeEventListener("ratechange", DocumentAPI.#onratechange);
    }


    // HTMLMediaElement - durationchange event

    static #ondurationchange() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeDurationChange");
    }

    static activateOndurationchange(): void {
        document.addEventListener("durationchange", DocumentAPI.#ondurationchange);
    }

    static deactivateOndurationchange(): void {
        document.removeEventListener("durationchange", DocumentAPI.#ondurationchange);
    }


    // Video

    // HTMLMediaElement - resize event

    static #onresize() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeResize");
    }

    static activateOnresize(): void {
        document.addEventListener("resize", DocumentAPI.#onresize);
    }

    static deactivateOnresize(): void {
        document.removeEventListener("resize", DocumentAPI.#onresize);
    }



    // HTMLDialogElement - close event

    static #onclose() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeClose");
    }

    static activateOnclose(): void {
        document.addEventListener("close", DocumentAPI.#onclose);
    }

    static deactivateOnclose(): void {
        document.removeEventListener("close", DocumentAPI.#onclose);
    }


    // HTMLDialogElement - cancel event

    static #oncancel() {
        return BlazorInvoke.method(DocumentAPI.#eventTrigger, "InvokeCancel");
    }

    static activateOncancel(): void {
        document.addEventListener("cancel", DocumentAPI.#oncancel);
    }

    static deactivateOncancel(): void {
        document.removeEventListener("cancel", DocumentAPI.#oncancel);
    }
}
