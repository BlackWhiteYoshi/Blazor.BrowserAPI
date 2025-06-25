export class HTMLElementAPI {
    #htmlElement: HTMLElement;

    constructor(htmlElement: HTMLElement) {
        this.#htmlElement = htmlElement;
    }

    static create(htmlElement: HTMLElement): HTMLElementAPI {
        return new HTMLElementAPI(htmlElement);
    }


    // HTMLElement

    getInnerText(): string {
        return this.#htmlElement.innerText;
    }

    setInnerText(value: string) {
        this.#htmlElement.innerText = value;
    }

    getOuterText(): string {
        return this.#htmlElement.outerText;
    }

    setOuterText(value: string) {
        this.#htmlElement.outerText = value;
    }

    getInlineStyle(): string {
        return this.#htmlElement.style.cssText;
    }

    setInlineStyle(value: string) {
        this.#htmlElement.style.cssText = value;
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

    getOffsetParent(): Element | null {
        return this.#htmlElement.offsetParent;
    }


    hasFocus(): boolean {
        return this.#htmlElement === document.activeElement;
    }


    click() {
        this.#htmlElement.click();
    }

    focus(preventScroll: boolean = false) {
        this.#htmlElement.focus({ preventScroll });
    }

    blur() {
        this.#htmlElement.blur();
    }

    showPopover() {
        this.#htmlElement.showPopover();
    }

    hidePopover() {
        this.#htmlElement.hidePopover();
    }

    togglePopover(force?: boolean): boolean {
        return this.#htmlElement.togglePopover(force) as unknown as boolean;
    }


    // Element


    getInnerHTML(): string {
        return this.#htmlElement.innerHTML;
    }

    setInnerHTML(value: string) {
        this.#htmlElement.innerHTML = value;
    }

    getOuterHTML(): string {
        return this.#htmlElement.outerHTML;
    }

    setOuterHTML(value: string) {
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

    setClassName(value: string) {
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

    setScrollLeft(value: number) {
        this.#htmlElement.scrollLeft = value;
    }

    getScrollTop(): number {
        return this.#htmlElement.scrollTop;
    }

    setScrollTop(value: number) {
        this.#htmlElement.scrollTop = value;
    }


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


    setPointerCapture(pointerId: number) {
        this.#htmlElement.setPointerCapture(pointerId);
    }

    releasePointerCapture(pointerId: number) {
        this.#htmlElement.releasePointerCapture(pointerId);
    }

    hasPointerCapture(pointerId: number): boolean {
        return this.#htmlElement.hasPointerCapture(pointerId);
    }


    scroll(left: number, top: number) {
        this.#htmlElement.scroll(left, top);
    }

    scrollBy(x: number, y: number) {
        this.#htmlElement.scrollBy(x, y);
    }

    scrollIntoView(block: "start" | "center" | "end" | "nearest" = "start", inline: "start" | "center" | "end" | "nearest" = "nearest", behavior: "instant" | "smooth" | "auto" = "auto") {
        this.#htmlElement.scrollIntoView({ block, inline, behavior });
    }


    requestFullscreen(navigationUI: "hide" | "show" | "auto" = "auto"): Promise<void> {
        return this.#htmlElement.requestFullscreen({ navigationUI });
    }



    // events

    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // #region transitionstart event

    #ontransitionstartCallback = (transitionEvent: TransitionEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeTransitionstart", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeTransitionstart", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    activateOntransitionstart() {
        this.#htmlElement.addEventListener("transitionstart", this.#ontransitionstartCallback);
    }

    deactivateOntransitionstart() {
        this.#htmlElement.removeEventListener("transitionstart", this.#ontransitionstartCallback);
    }

    // #endregion


    // #region transitionend event

    #ontransitionendCallback = (transitionEvent: TransitionEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeTransitionend", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeTransitionend", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    activateOntransitionend() {
        this.#htmlElement.addEventListener("transitionend", this.#ontransitionendCallback);
    }

    deactivateOntransitionend() {
        this.#htmlElement.removeEventListener("transitionend", this.#ontransitionendCallback);
    }

    // #endregion


    // #region transitionrun event

    #ontransitionrunCallback = (transitionEvent: TransitionEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeTransitionrun", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeTransitionrun", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    activateOntransitionrun() {
        this.#htmlElement.addEventListener("transitionrun", this.#ontransitionrunCallback);
    }

    deactivateOntransitionrun() {
        this.#htmlElement.removeEventListener("transitionrun", this.#ontransitionrunCallback);
    }

    // #endregion


    // #region transitioncancel event

    #ontransitioncancelCallback = (transitionEvent: TransitionEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeTransitioncancel", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeTransitioncancel", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    activateOntransitioncancel() {
        this.#htmlElement.addEventListener("transitioncancel", this.#ontransitioncancelCallback);
    }

    deactivateOntransitioncancel() {
        this.#htmlElement.removeEventListener("transitioncancel", this.#ontransitioncancelCallback);
    }

    // #endregion



    // #region animationstart event

    #onanimationstartCallback = (animationEvent: AnimationEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeAnimationstart", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeAnimationstart", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    activateOnanimationstart() {
        this.#htmlElement.addEventListener("animationstart", this.#onanimationstartCallback);
    }

    deactivateOnanimationstart() {
        this.#htmlElement.removeEventListener("animationstart", this.#onanimationstartCallback);
    }

    // #endregion


    // #region animationend event

    #onanimationendCallback = (animationEvent: AnimationEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeAnimationend", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeAnimationend", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    activateOnanimationend() {
        this.#htmlElement.addEventListener("animationend", this.#onanimationendCallback);
    }

    deactivateOnanimationend() {
        this.#htmlElement.removeEventListener("animationend", this.#onanimationendCallback);
    }

    // #endregion


    // #region animationiteration event

    #onanimationiterationCallback = (animationEvent: AnimationEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeAnimationiteration", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeAnimationiteration", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    activateOnanimationiteration() {
        this.#htmlElement.addEventListener("animationiteration", this.#onanimationiterationCallback);
    }

    deactivateOnanimationiteration() {
        this.#htmlElement.removeEventListener("animationiteration", this.#onanimationiterationCallback);
    }

    // #endregion


    // #region animationcancel event

    #onanimationcancelCallback = (animationEvent: AnimationEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeAnimationcancel", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeAnimationcancel", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    activateOnanimationcancel() {
        this.#htmlElement.addEventListener("animationcancel", this.#onanimationcancelCallback);
    }

    deactivateOnanimationcancel() {
        this.#htmlElement.removeEventListener("animationcancel", this.#onanimationcancelCallback);
    }

    // #endregion
}
