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


    getAttributeStyleMap(): Record<string, string> {
        const attributeStyleMap = this.#htmlElement.attributeStyleMap;

        const result: Record<string, string> = {};
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


    getDataset(): Record<string, string> {
        return <Record<string, string>>this.#htmlElement.dataset;
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



    // Node/Element

    getAttributes(): Record<string, string> {
        const attributes = this.#htmlElement.attributes;

        const result: Record<string, string> = {};
        for (const attribute of attributes)
            result[attribute.name] = attribute.value;
        return result;
    }


    getClassList(): string[] {
        return [... this.#htmlElement.classList];
    }


    getClassName(): string {
        return this.#htmlElement.className;
    }

    setClassName(value: string): void {
        this.#htmlElement.className = value;
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


    getCurrentCSSZoom(): number {
        return (<HTMLElement & { currentCSSZoom: number; }>this.#htmlElement).currentCSSZoom;
    }


    getId(): string {
        return this.#htmlElement.id;
    }

    setId(value: string): void {
        this.#htmlElement.id = value;
    }


    getIsConnected(): boolean {
        return this.#htmlElement.isConnected;
    }


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


    getPart(): string[] {
        return [... this.#htmlElement.part];
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


    getSlot(): string {
        return this.#htmlElement.slot;
    }

    setSlot(value: string): void {
        this.#htmlElement.slot = value;
    }


    getLocalName(): string {
        return this.#htmlElement.localName;
    }

    getNamespaceURI(): string | null {
        return this.#htmlElement.namespaceURI;
    }

    getPrefix(): string | null {
        return this.#htmlElement.prefix;
    }

    getBaseURI(): string {
        return this.#htmlElement.baseURI;
    }

    getTagName(): string {
        return this.#htmlElement.tagName;
    }

    getNodeName(): string {
        return this.#htmlElement.nodeName;
    }

    getNodeType(): number {
        return this.#htmlElement.nodeType;
    }


    // Node/Element properties - Tree-nodes

    getChildElementCount(): number {
        return this.#htmlElement.childElementCount;
    }

    getChildren(): HTMLElementAPI[] {
        return [... this.#htmlElement.children].map((child: HTMLElement) => DotNet.createJSObjectReference(new HTMLElementAPI(child)));
    }

    getFirstElementChild(): [HTMLElementAPI] | [null] {
        const result = this.#htmlElement.firstElementChild;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    getLastElementChild(): [HTMLElementAPI] | [null] {
        const result = this.#htmlElement.lastElementChild;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    getPreviousElementSibling(): [HTMLElementAPI] | [null] {
        const result = this.#htmlElement.previousElementSibling;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    getNextElementSibling(): [HTMLElementAPI] | [null] {
        const result = this.#htmlElement.nextElementSibling;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    getParentElement(): [HTMLElementAPI] | [null] {
        const result = this.#htmlElement.parentElement;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }


    // Node/Element properties - ARIA

    getAriaAtomic(): string | null {
        return this.#htmlElement.ariaAtomic;
    }

    setAriaAtomic(value: string | null): void {
        this.#htmlElement.ariaAtomic = value;
    }


    getAriaAutoComplete(): string | null {
        return this.#htmlElement.ariaAutoComplete;
    }

    setAriaAutoComplete(value: string | null): void {
        this.#htmlElement.ariaAutoComplete = value;
    }


    getAriaBrailleLabel(): string | null {
        return (<HTMLElement & { ariaBrailleLabel: string | null; }>this.#htmlElement).ariaBrailleLabel;
    }

    setAriaBrailleLabel(value: string | null): void {
        (<HTMLElement & { ariaBrailleLabel: string | null; }>this.#htmlElement).ariaBrailleLabel = value;
    }


    getAriaBrailleRoleDescription(): string | null {
        return (<HTMLElement & { ariaBrailleRoleDescription: string | null; }>this.#htmlElement).ariaBrailleRoleDescription;
    }

    setAriaBrailleRoleDescription(value: string | null): void {
        (<HTMLElement & { ariaBrailleRoleDescription: string | null; }>this.#htmlElement).ariaBrailleRoleDescription = value;
    }


    getAriaBusy(): string | null {
        return this.#htmlElement.ariaBusy;
    }

    setAriaBusy(value: string | null): void {
        this.#htmlElement.ariaBusy = value;
    }


    getAriaChecked(): string | null {
        return this.#htmlElement.ariaChecked;
    }

    setAriaChecked(value: string | null): void {
        this.#htmlElement.ariaChecked = value;
    }


    getAriaColCount(): string | null {
        return this.#htmlElement.ariaColCount;
    }

    setAriaColCount(value: string | null): void {
        this.#htmlElement.ariaColCount = value;
    }


    getAriaColIndex(): string | null {
        return this.#htmlElement.ariaColIndex;
    }

    setAriaColIndex(value: string | null): void {
        this.#htmlElement.ariaColIndex = value;
    }


    getAriaColIndexText(): string | null {
        return (<HTMLElement & { ariaColIndexText: string | null; }>this.#htmlElement).ariaColIndexText;
    }

    setAriaColIndexText(value: string | null): void {
        (<HTMLElement & { ariaColIndexText: string | null; }>this.#htmlElement).ariaColIndexText = value;
    }


    getAriaColSpan(): string | null {
        return this.#htmlElement.ariaColSpan;
    }

    setAriaColSpan(value: string | null): void {
        this.#htmlElement.ariaColSpan = value;
    }


    getAriaCurrent(): string | null {
        return this.#htmlElement.ariaCurrent;
    }

    setAriaCurrent(value: string | null): void {
        this.#htmlElement.ariaCurrent = value;
    }


    getAriaDescription(): string | null {
        return (<HTMLElement & { ariaDescription: string | null; }>this.#htmlElement).ariaDescription;
    }

    setAriaDescription(value: string | null): void {
        (<HTMLElement & { ariaDescription: string | null; }>this.#htmlElement).ariaDescription = value;
    }


    getAriaDisabled(): string | null {
        return this.#htmlElement.ariaDisabled;
    }

    setAriaDisabled(value: string | null): void {
        this.#htmlElement.ariaDisabled = value;
    }


    getAriaExpanded(): string | null {
        return this.#htmlElement.ariaExpanded;
    }

    setAriaExpanded(value: string | null): void {
        this.#htmlElement.ariaExpanded = value;
    }


    getAriaHasPopup(): string | null {
        return this.#htmlElement.ariaHasPopup;
    }

    setAriaHasPopup(value: string | null): void {
        this.#htmlElement.ariaHasPopup = value;
    }


    getAriaHidden(): string | null {
        return this.#htmlElement.ariaHidden;
    }

    setAriaHidden(value: string | null): void {
        this.#htmlElement.ariaHidden = value;
    }


    getAriaInvalid(): string | null {
        return this.#htmlElement.ariaInvalid;
    }

    setAriaInvalid(value: string | null): void {
        this.#htmlElement.ariaInvalid = value;
    }


    getAriaKeyShortcuts(): string | null {
        return this.#htmlElement.ariaKeyShortcuts;
    }

    setAriaKeyShortcuts(value: string | null): void {
        this.#htmlElement.ariaKeyShortcuts = value;
    }


    getAriaLabel(): string | null {
        return this.#htmlElement.ariaLabel;
    }

    setAriaLabel(value: string | null): void {
        this.#htmlElement.ariaLabel = value;
    }


    getAriaLevel(): string | null {
        return this.#htmlElement.ariaLevel;
    }

    setAriaLevel(value: string | null): void {
        this.#htmlElement.ariaLevel = value;
    }


    getAriaLive(): string | null {
        return this.#htmlElement.ariaLive;
    }

    setAriaLive(value: string | null): void {
        this.#htmlElement.ariaLive = value;
    }


    getAriaModal(): string | null {
        return this.#htmlElement.ariaModal;
    }

    setAriaModal(value: string | null): void {
        this.#htmlElement.ariaModal = value;
    }


    getAriaMultiline(): string | null {
        return (<HTMLElement & { ariaMultiline: string | null; }>this.#htmlElement).ariaMultiline;
    }

    setAriaMultiline(value: string | null): void {
        (<HTMLElement & { ariaMultiline: string | null; }>this.#htmlElement).ariaMultiline = value;
    }


    getAriaMultiSelectable(): string | null {
        return this.#htmlElement.ariaMultiSelectable;
    }

    setAriaMultiSelectable(value: string | null): void {
        this.#htmlElement.ariaMultiSelectable = value;
    }


    getAriaOrientation(): string | null {
        return this.#htmlElement.ariaOrientation;
    }

    setAriaOrientation(value: string | null): void {
        this.#htmlElement.ariaOrientation = value;
    }


    getAriaPlaceholder(): string | null {
        return this.#htmlElement.ariaPlaceholder;
    }

    setAriaPlaceholder(value: string | null): void {
        this.#htmlElement.ariaPlaceholder = value;
    }


    getAriaPosInSet(): string | null {
        return this.#htmlElement.ariaPosInSet;
    }

    setAriaPosInSet(value: string | null): void {
        this.#htmlElement.ariaPosInSet = value;
    }


    getAriaPressed(): string | null {
        return this.#htmlElement.ariaPressed;
    }

    setAriaPressed(value: string | null): void {
        this.#htmlElement.ariaPressed = value;
    }


    getAriaReadOnly(): string | null {
        return this.#htmlElement.ariaReadOnly;
    }

    setAriaReadOnly(value: string | null): void {
        this.#htmlElement.ariaReadOnly = value;
    }


    getAriaRequired(): string | null {
        return this.#htmlElement.ariaRequired;
    }

    setAriaRequired(value: string | null): void {
        this.#htmlElement.ariaRequired = value;
    }


    getAriaRoleDescription(): string | null {
        return this.#htmlElement.ariaRoleDescription;
    }

    setAriaRoleDescription(value: string | null): void {
        this.#htmlElement.ariaRoleDescription = value;
    }


    getAriaRowCount(): string | null {
        return this.#htmlElement.ariaRowCount;
    }

    setAriaRowCount(value: string | null): void {
        this.#htmlElement.ariaRowCount = value;
    }


    getAriaRowIndex(): string | null {
        return this.#htmlElement.ariaRowIndex;
    }

    setAriaRowIndex(value: string | null): void {
        this.#htmlElement.ariaRowIndex = value;
    }


    getAriaRowIndexText(): string | null {
        return (<HTMLElement & { ariaRowIndexText: string | null; }>this.#htmlElement).ariaRowIndexText;
    }

    setAriaRowIndexText(value: string | null): void {
        (<HTMLElement & { ariaRowIndexText: string | null; }>this.#htmlElement).ariaRowIndexText = value;
    }


    getAriaRowSpan(): string | null {
        return this.#htmlElement.ariaRowSpan;
    }

    setAriaRowSpan(value: string | null): void {
        this.#htmlElement.ariaRowSpan = value;
    }


    getAriaSelected(): string | null {
        return this.#htmlElement.ariaSelected;
    }

    setAriaSelected(value: string | null): void {
        this.#htmlElement.ariaSelected = value;
    }


    getAriaSetSize(): string | null {
        return this.#htmlElement.ariaSetSize;
    }

    setAriaSetSize(value: string | null): void {
        this.#htmlElement.ariaSetSize = value;
    }


    getAriaSort(): string | null {
        return this.#htmlElement.ariaSort;
    }

    setAriaSort(value: string | null): void {
        this.#htmlElement.ariaSort = value;
    }


    getAriaValueMax(): string | null {
        return this.#htmlElement.ariaValueMax;
    }

    setAriaValueMax(value: string | null): void {
        this.#htmlElement.ariaValueMax = value;
    }


    getAriaValueMin(): string | null {
        return this.#htmlElement.ariaValueMin;
    }

    setAriaValueMin(value: string | null): void {
        this.#htmlElement.ariaValueMin = value;
    }


    getAriaValueNow(): string | null {
        return this.#htmlElement.ariaValueNow;
    }

    setAriaValueNow(value: string | null): void {
        this.#htmlElement.ariaValueNow = value;
    }


    getAriaValueText(): string | null {
        return this.#htmlElement.ariaValueText;
    }

    setAriaValueText(value: string | null): void {
        this.#htmlElement.ariaValueText = value;
    }


    getRole(): string | null {
        return this.#htmlElement.role;
    }

    setRole(value: string | null): void {
        this.#htmlElement.role = value;
    }


    // Node/Element methods

    checkVisibility(contentVisibilityAuto: boolean, opacityProperty: boolean, visibilityProperty: boolean): boolean {
        return this.#htmlElement.checkVisibility(<CheckVisibilityOptions>{ contentVisibilityAuto, opacityProperty, visibilityProperty });
    }

    closest(selectors: string): [HTMLElementAPI] | [null] {
        const result = this.#htmlElement.closest(selectors);
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    computedStyleMap(): Record<string, string> {
        const computedStyleMap = this.#htmlElement.computedStyleMap().entries();

        const result: Record<string, string> = {};
        for (const [name, value] of computedStyleMap)
            result[name] = value.toString();
        return result;
    }

    getBoundingClientRect(): DOMRect {
        return this.#htmlElement.getBoundingClientRect();
    }

    getClientRects(): DOMRect[] {
        return [... this.#htmlElement.getClientRects()];
    }

    matches(selectors: string): boolean {
        return this.#htmlElement.matches(selectors);
    }

    requestFullscreen(navigationUI: "hide" | "show" | "auto" = "auto"): Promise<void> {
        return this.#htmlElement.requestFullscreen({ navigationUI });
    }

    requestPointerLock(unadjustedMovement: boolean): Promise<void> {
        return (<(options: { unadjustedMovement: boolean; }) => Promise<void>><unknown>this.#htmlElement.requestPointerLock)({ unadjustedMovement });
    }

    isDefaultNamespace(namespace: string): boolean {
        return this.#htmlElement.isDefaultNamespace(namespace);
    }

    lookupPrefix(namespace: string): string | null {
        return this.#htmlElement.lookupPrefix(namespace);
    }

    lookupNamespaceURI(prefix: string): string | null {
        return this.#htmlElement.lookupNamespaceURI(prefix);
    }

    normalize(): void {
        this.#htmlElement.normalize();
    }


    // Node/Element methods - Pointer Capture

    setPointerCapture(pointerId: number): void {
        this.#htmlElement.setPointerCapture(pointerId);
    }

    releasePointerCapture(pointerId: number): void {
        this.#htmlElement.releasePointerCapture(pointerId);
    }

    hasPointerCapture(pointerId: number): boolean {
        return this.#htmlElement.hasPointerCapture(pointerId);
    }


    // Node/Element methods - Scroll

    scroll(left: number, top: number): void {
        this.#htmlElement.scroll(left, top);
    }

    scrollBy(x: number, y: number): void {
        this.#htmlElement.scrollBy(x, y);
    }

    scrollIntoView(block: ScrollLogicalPosition = "start", inline: ScrollLogicalPosition = "nearest", behavior: ScrollBehavior = "auto"): void {
        this.#htmlElement.scrollIntoView({ block, inline, behavior });
    }

    scrollTo(x: number, y: number, behavior: ScrollBehavior | null): void {
        if (behavior === null)
            this.#htmlElement.scrollTo(x, y);
        else
            this.#htmlElement.scrollTo({ left: x, top: y, behavior })
    }


    // Node/Element methods - Attribute

    getAttribute(qualifiedName: string): string | null {
        return this.#htmlElement.getAttribute(qualifiedName);
    }

    getAttributeNS(namespace: string, qualifiedName: string): string | null {
        return this.#htmlElement.getAttributeNS(namespace, qualifiedName);
    }

    getAttributeNames(): string[] {
        return this.#htmlElement.getAttributeNames();
    }

    setAttribute(qualifiedName: string, value: string): void {
        this.#htmlElement.setAttribute(qualifiedName, value);
    }

    setAttributeNS(namespace: string, qualifiedName: string, value: string): void {
        this.#htmlElement.setAttributeNS(namespace, qualifiedName, value);
    }

    toggleAttribute(qualifiedName: string, force: boolean | null): boolean {
        return this.#htmlElement.toggleAttribute(qualifiedName, force ?? undefined);
    }

    removeAttribute(qualifiedName: string): void {
        this.#htmlElement.removeAttribute(qualifiedName);
    }

    removeAttributeNS(namespace: string, qualifiedName: string): void {
        this.#htmlElement.removeAttributeNS(namespace, qualifiedName);
    }

    hasAttribute(qualifiedName: string): boolean {
        return this.#htmlElement.hasAttribute(qualifiedName);
    }

    hasAttributeNS(namespace: string, qualifiedName: string): boolean {
        return this.#htmlElement.hasAttributeNS(namespace, qualifiedName);
    }

    hasAttributes(): boolean {
        return this.#htmlElement.hasAttributes();
    }


    // Node/Element methods - Tree-nodes

    getElementsByClassName(className: string): HTMLElementAPI[] {
        return [...this.#htmlElement.getElementsByClassName(className)].map(element => new HTMLElementAPI(<HTMLElement>element));
    }

    getElementsByTagName(qualifiedName: string): HTMLElementAPI[] {
        return [... this.#htmlElement.getElementsByTagName(qualifiedName)].map(element => new HTMLElementAPI(<HTMLElement>element));
    }

    getElementsByTagNameNS(namespace: string, qualifiedName: string): HTMLElementAPI[] {
        return [... this.#htmlElement.getElementsByTagNameNS(namespace, qualifiedName)].map(element => new HTMLElementAPI(<HTMLElement>element));
    }

    querySelector(selectors: string): [HTMLElementAPI] | [null] {
        const result = this.#htmlElement.querySelector(selectors);
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    querySelectorAll(selectors: string): HTMLElementAPI[] {
        return [... this.#htmlElement.querySelectorAll(selectors)].map(element => new HTMLElementAPI(<HTMLElement>element));
    }


    before_string(nodes: string[]): void {
        this.#htmlElement.before(...nodes);
    }

    before_htmlElement(nodes: HTMLElementAPI[]): void {
        this.#htmlElement.before(...nodes.map(htmlElementAPI => htmlElementAPI.#htmlElement));
    }

    after_string(nodes: string[]): void {
        this.#htmlElement.after(...nodes);
    }

    after_htmlElement(nodes: HTMLElementAPI[]): void {
        this.#htmlElement.after(...nodes.map(htmlElementAPI => htmlElementAPI.#htmlElement));
    }


    prepend_string(nodes: string[]): void {
        this.#htmlElement.prepend(...nodes);
    }

    prepend_htmlElement(nodes: HTMLElementAPI[]): void {
        this.#htmlElement.prepend(...nodes.map(htmlElementAPI => htmlElementAPI.#htmlElement));
    }

    appendChild(node: HTMLElementAPI): void {
        this.#htmlElement.appendChild(node.#htmlElement);
    }

    append_string(nodes: string[]): void {
        this.#htmlElement.append(...nodes);
    }

    append_htmlElement(nodes: HTMLElementAPI[]): void {
        this.#htmlElement.append(...nodes.map(htmlElementAPI => htmlElementAPI.#htmlElement));
    }

    insertAdjacentElement(position: InsertPosition, htmlElement: HTMLElementAPI): boolean {
        const result = this.#htmlElement.insertAdjacentElement(position, htmlElement.#htmlElement);
        if (result)
            return true;
        else
            return false;
    }

    insertAdjacentHTML(position: InsertPosition, html: string): void {
        this.#htmlElement.insertAdjacentHTML(position, html);
    }

    insertAdjacentText(position: InsertPosition, data: string): void {
        this.#htmlElement.insertAdjacentText(position, data);
    }


    removeChild(node: HTMLElementAPI): void {
        this.#htmlElement.removeChild(node.#htmlElement);
    }

    remove(): void {
        this.#htmlElement.remove();
    }

    replaceChild(newChild: HTMLElementAPI, oldChild: HTMLElementAPI): void {
        this.#htmlElement.replaceChild(newChild.#htmlElement, oldChild.#htmlElement);
    }

    replaceChildIndex(newChild: HTMLElementAPI, oldChildIndex: number): void {
        this.#htmlElement.replaceChild(newChild.#htmlElement, this.#htmlElement.children[oldChildIndex]);
    }

    replaceWith_string(nodes: string[]): void {
        this.#htmlElement.replaceWith(...nodes);
    }

    replaceWith_htmlElement(nodes: HTMLElementAPI[]): void {
        this.#htmlElement.replaceWith(...nodes.map(htmlElementAPI => htmlElementAPI.#htmlElement));
    }

    replaceChildren_string(nodes: string[]): void {
        this.#htmlElement.replaceChildren(...nodes);
    }

    replaceChildren_htmlElement(nodes: HTMLElementAPI[]): void {
        this.#htmlElement.replaceChildren(...nodes.map(htmlElementAPI => htmlElementAPI.#htmlElement));
    }


    cloneNode(deep: boolean): HTMLElementAPI {
        const result = this.#htmlElement.cloneNode(deep);
        return new HTMLElementAPI(<HTMLElement>result);
    }

    isSameNode(other: HTMLElementAPI): boolean {
        return this.#htmlElement.isSameNode(other.#htmlElement);
    }

    isEqualNode(other: HTMLElementAPI): boolean {
        return this.#htmlElement.isEqualNode(other.#htmlElement);
    }

    contains(other: HTMLElementAPI): boolean {
        return this.#htmlElement.contains(other.#htmlElement);
    }

    compareDocumentPosition(other: HTMLElementAPI): number {
        return this.#htmlElement.compareDocumentPosition(other.#htmlElement);
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
