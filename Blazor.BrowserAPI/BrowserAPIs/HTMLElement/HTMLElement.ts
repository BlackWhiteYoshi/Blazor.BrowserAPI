import { blazorInvokeMethod } from "../../Extensions/blazorExtensions";

export class HTMLElementAPI {
    #htmlElement: HTMLElement;

    constructor(htmlElement: HTMLElement) {
        this.#htmlElement = htmlElement;
    }

    static create(htmlElement: HTMLElement): HTMLElementAPI {
        return new HTMLElementAPI(htmlElement);
    }


    // HTMLElement

    getAccessKey(): string {
        return this.#htmlElement.accessKey;
    }

    setAccessKey(value: string): void {
        this.#htmlElement.accessKey = value;
    }

    getAccessKeyLabel(): string {
        return this.#htmlElement.accessKeyLabel;
    }


    getAttributeStyleMap(): { [name: string]: string; } {
        const attributeStyleMap = this.#htmlElement.attributeStyleMap;

        const result: { [name: string]: string; } = {};
        for (const [name, value] of attributeStyleMap.entries())
            result[name] = value.toString();
        return result;
    }

    setAttributeStyleMap(name: string, value: string): void {
        this.#htmlElement.attributeStyleMap.set(name, value);
    }

    removeAttributeStyleMap(name: string): void {
        this.#htmlElement.attributeStyleMap.delete(name);
    }


    getAutocapitalize(): string {
        return this.#htmlElement.autocapitalize;
    }

    setAutocapitalize(value: string): void {
        this.#htmlElement.autocapitalize = value;
    }


    getAutofocus(): boolean {
        return this.#htmlElement.autofocus;
    }

    setAutofocus(value: boolean): void {
        this.#htmlElement.autofocus = value;
    }


    getContentEditable(): string {
        return this.#htmlElement.contentEditable;
    }

    setContentEditable(value: string): void {
        this.#htmlElement.contentEditable = value;
    }


    getDataset(): { [name: string]: string; } {
        return <{ [name: string]: string; }>this.#htmlElement.dataset;
    }

    setDataset(name: string, value: string): void {
        this.#htmlElement.dataset[name] = value;
    }

    removeDataset(name: string): void {
        delete this.#htmlElement.dataset[name];
    }


    getDir(): string {
        return this.#htmlElement.dir;
    }

    setDir(value: string): void {
        this.#htmlElement.dir = value;
    }


    getDraggable(): boolean {
        return this.#htmlElement.draggable;
    }

    setDraggable(value: boolean): void {
        this.#htmlElement.draggable = value;
    }


    getEnterKeyHint(): string {
        return this.#htmlElement.enterKeyHint;
    }

    setEnterKeyHint(value: string): void {
        this.#htmlElement.enterKeyHint = value;
    }


    getHidden(): boolean {
        return this.#htmlElement.hidden;
    }

    setHidden(value: boolean): void {
        this.#htmlElement.hidden = value;
    }


    getInert(): boolean {
        return this.#htmlElement.inert;
    }

    setInert(value: boolean): void {
        this.#htmlElement.inert = value;
    }


    getInnerText(): string {
        return this.#htmlElement.innerText;
    }

    setInnerText(value: string): void {
        this.#htmlElement.innerText = value;
    }


    getInputMode(): string {
        return this.#htmlElement.inputMode;
    }

    setInputMode(value: string): void {
        this.#htmlElement.inputMode = value;
    }


    getIsContentEditable(): boolean {
        return this.#htmlElement.isContentEditable;
    }


    getLang(): string {
        return this.#htmlElement.lang;
    }

    setLang(value: string): void {
        this.#htmlElement.lang = value;
    }


    getNonce(): string {
        return this.#htmlElement.nonce ?? "";
    }

    setNonce(value: string): void {
        this.#htmlElement.nonce = value;
    }


    getOffsetWidth(): number {
        return this.#htmlElement.offsetWidth;
    }

    getOffsetHeight(): number {
        return this.#htmlElement.offsetHeight;
    }

    getOffsetLeft(): number {
        return this.#htmlElement.offsetLeft;
    }

    getOffsetTop(): number {
        return this.#htmlElement.offsetTop;
    }

    getOffsetParent(): [HTMLElementAPI] | [null] {
        if (this.#htmlElement.offsetParent instanceof HTMLElement)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(this.#htmlElement.offsetParent))];
        else
            return [null];
    }


    getOuterText(): string {
        return this.#htmlElement.outerText;
    }

    setOuterText(value: string): void {
        this.#htmlElement.outerText = value;
    }


    getPopover(): string | null {
        return this.#htmlElement.popover;
    }

    setPopover(value: string | null): void {
        this.#htmlElement.popover = value;
    }


    getSpellcheck(): boolean {
        return this.#htmlElement.spellcheck;
    }

    setSpellcheck(value: boolean): void {
        this.#htmlElement.spellcheck = value;
    }


    getStyle(): string {
        return this.#htmlElement.style.cssText;
    }

    setStyle(value: string): void {
        this.#htmlElement.style.cssText = value;
    }


    getTabIndex(): number {
        return this.#htmlElement.tabIndex;
    }

    setTabIndex(value: number): void {
        this.#htmlElement.tabIndex = value;
    }


    getTitle(): string {
        return this.#htmlElement.title;
    }

    setTitle(value: string): void {
        this.#htmlElement.title = value;
    }


    getTranslate(): boolean {
        return this.#htmlElement.translate;
    }

    setTranslate(value: boolean): void {
        this.#htmlElement.translate = value;
    }


    // HTMLElement extra

    hasFocus(): boolean {
        return this.#htmlElement === document.activeElement;
    }


    // HTMLElement methods

    click(): void {
        this.#htmlElement.click();
    }

    focus(preventScroll: boolean = false): void {
        this.#htmlElement.focus({ preventScroll });
    }

    blur(): void {
        this.#htmlElement.blur();
    }

    showPopover(): void {
        this.#htmlElement.showPopover();
    }

    hidePopover(): void {
        this.#htmlElement.hidePopover();
    }

    togglePopover(force?: boolean): boolean {
        return <boolean><unknown>this.#htmlElement.togglePopover(force);
    }



    // Element


    getInnerHTML(): string {
        return this.#htmlElement.innerHTML;
    }

    setInnerHTML(value: string): void {
        this.#htmlElement.innerHTML = value;
    }

    getOuterHTML(): string {
        return this.#htmlElement.outerHTML;
    }

    setOuterHTML(value: string): void {
        this.#htmlElement.outerHTML = value;
    }


    getAttributes(): Record<string, string> {
        return Object.fromEntries([... this.#htmlElement.attributes].map(attribute => [attribute.name, attribute.value]));
    }

    getChildElementCount(): number {
        return this.#htmlElement.childElementCount;
    }

    getChildren(): HTMLElementAPI[] {
        return [... this.#htmlElement.children].map((child: HTMLElement) => DotNet.createJSObjectReference(new HTMLElementAPI(child)));
    }


    getClassName(): string {
        return this.#htmlElement.className;
    }

    setClassName(value: string): void {
        this.#htmlElement.className = value;
    }

    getClassList(): string[] {
        return [... this.#htmlElement.classList];
    }


    getClientWidth(): number {
        return this.#htmlElement.clientWidth;
    }

    getClientHeight(): number {
        return this.#htmlElement.clientHeight;
    }

    getClientLeft(): number {
        return this.#htmlElement.clientLeft;
    }

    getClientTop(): number {
        return this.#htmlElement.clientTop;
    }


    getScrollWidth(): number {
        return this.#htmlElement.scrollWidth;
    }

    getScrollHeight(): number {
        return this.#htmlElement.scrollHeight;
    }

    getScrollLeft(): number {
        return this.#htmlElement.scrollLeft;
    }

    setScrollLeft(value: number): void {
        this.#htmlElement.scrollLeft = value;
    }

    getScrollTop(): number {
        return this.#htmlElement.scrollTop;
    }

    setScrollTop(value: number): void {
        this.#htmlElement.scrollTop = value;
    }


    // Element methods

    getBoundingClientRect(): DOMRect {
        return this.#htmlElement.getBoundingClientRect();
    }

    getClientRects(): DOMRect[] {
        return [... this.#htmlElement.getClientRects()];
    }


    hasAttribute(name: string): boolean {
        return this.#htmlElement.hasAttribute(name);
    }

    hasAttributes(): boolean {
        return this.#htmlElement.hasAttributes();
    }


    setPointerCapture(pointerId: number): void {
        this.#htmlElement.setPointerCapture(pointerId);
    }

    releasePointerCapture(pointerId: number): void {
        this.#htmlElement.releasePointerCapture(pointerId);
    }

    hasPointerCapture(pointerId: number): boolean {
        return this.#htmlElement.hasPointerCapture(pointerId);
    }


    scroll(left: number, top: number): void {
        this.#htmlElement.scroll(left, top);
    }

    scrollBy(x: number, y: number): void {
        this.#htmlElement.scrollBy(x, y);
    }

    scrollIntoView(block: "start" | "center" | "end" | "nearest" = "start", inline: "start" | "center" | "end" | "nearest" = "nearest", behavior: "instant" | "smooth" | "auto" = "auto"): void {
        this.#htmlElement.scrollIntoView({ block, inline, behavior });
    }


    requestFullscreen(navigationUI: "hide" | "show" | "auto" = "auto"): Promise<void> {
        return this.#htmlElement.requestFullscreen({ navigationUI });
    }



    // events


    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean): void {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // transitionstart event

    #ontransitionstart = (transitionEvent: TransitionEvent) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeTransitionstart", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    activateOntransitionstart(): void {
        this.#htmlElement.addEventListener("transitionstart", this.#ontransitionstart);
    }

    deactivateOntransitionstart(): void {
        this.#htmlElement.removeEventListener("transitionstart", this.#ontransitionstart);
    }


    // transitionend event

    #ontransitionend = (transitionEvent: TransitionEvent) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeTransitionend", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)
    
    activateOntransitionend(): void {
        this.#htmlElement.addEventListener("transitionend", this.#ontransitionend);
    }

    deactivateOntransitionend(): void {
        this.#htmlElement.removeEventListener("transitionend", this.#ontransitionend);
    }


    // transitionrun event

    #ontransitionrun = (transitionEvent: TransitionEvent) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeTransitionrun", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)
    
    activateOntransitionrun(): void {
        this.#htmlElement.addEventListener("transitionrun", this.#ontransitionrun);
    }

    deactivateOntransitionrun(): void {
        this.#htmlElement.removeEventListener("transitionrun", this.#ontransitionrun);
    }


    // transitioncancel event

    #ontransitioncancel = (transitionEvent: TransitionEvent) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeTransitioncancel", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)
    
    activateOntransitioncancel(): void {
        this.#htmlElement.addEventListener("transitioncancel", this.#ontransitioncancel);
    }

    deactivateOntransitioncancel(): void {
        this.#htmlElement.removeEventListener("transitioncancel", this.#ontransitioncancel);
    }



    // animationstart event

    #onanimationstart = (animationEvent: AnimationEvent) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeAnimationstart", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)
    
    activateOnanimationstart(): void {
        this.#htmlElement.addEventListener("animationstart", this.#onanimationstart);
    }

    deactivateOnanimationstart(): void {
        this.#htmlElement.removeEventListener("animationstart", this.#onanimationstart);
    }


    // animationend event

    #onanimationend = (animationEvent: AnimationEvent) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeAnimationend", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)
    
    activateOnanimationend(): void {
        this.#htmlElement.addEventListener("animationend", this.#onanimationend);
    }

    deactivateOnanimationend(): void {
        this.#htmlElement.removeEventListener("animationend", this.#onanimationend);
    }


    // animationiteration event

    #onanimationiteration = (animationEvent: AnimationEvent) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeAnimationiteration", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)
    
    activateOnanimationiteration(): void {
        this.#htmlElement.addEventListener("animationiteration", this.#onanimationiteration);
    }

    deactivateOnanimationiteration(): void {
        this.#htmlElement.removeEventListener("animationiteration", this.#onanimationiteration);
    }


    // animationcancel event

    #onanimationcancel = (animationEvent: AnimationEvent) => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeAnimationcancel", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)
    
    activateOnanimationcancel(): void {
        this.#htmlElement.addEventListener("animationcancel", this.#onanimationcancel);
    }

    deactivateOnanimationcancel(): void {
        this.#htmlElement.removeEventListener("animationcancel", this.#onanimationcancel);
    }
}
