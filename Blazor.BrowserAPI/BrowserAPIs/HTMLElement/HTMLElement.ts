import { HTMLDialogElementAPI } from "../HTMLDialogElement/HTMLDialogElement";
import { HTMLMediaElementAPI } from "../HTMLMediaElement/HTMLMediaElement";
import { FileAPI } from "../FileSystem/File/File";
import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class HTMLElementAPI {
    #htmlElement: HTMLElement;
    get htmlElement(): HTMLElement {
        return this.#htmlElement;
    }

    constructor(htmlElement: HTMLElement) {
        this.#htmlElement = htmlElement;
    }

    static create(htmlElement: HTMLElement): HTMLElementAPI {
        return new HTMLElementAPI(htmlElement);
    }


    toHTMLDialogElement(): HTMLDialogElementAPI {
        return new HTMLDialogElementAPI(<HTMLDialogElement>this.#htmlElement);
    }

    toHTMLMediaElement(): HTMLMediaElementAPI {
        return new HTMLMediaElementAPI(<HTMLMediaElement>this.#htmlElement);
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

    togglePopover(force: boolean | null): boolean {
        return <boolean><unknown>this.#htmlElement.togglePopover(force ?? undefined);
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


    getTextContent(): string {
        // textContent of HTMLElements are always not null
        return <string>this.#htmlElement.textContent;
    }

    setTextContent(value: string): void {
        this.#htmlElement.textContent = value;
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
            return [DotNet.createJSObjectReference(new HTMLElementAPI(result))];
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

    isDefaultNamespace(namespace: string | null): boolean {
        return this.#htmlElement.isDefaultNamespace(namespace);
    }

    lookupPrefix(namespace: string | null): string | null {
        return this.#htmlElement.lookupPrefix(namespace);
    }

    lookupNamespaceURI(prefix: string | null): string | null {
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

    scroll(left: number, top: number, behavior: ScrollBehavior | null): void {
        if (!behavior)
            this.#htmlElement.scroll(left, top);
        else
            this.#htmlElement.scroll({ left, top, behavior });
    }

    scrollTo(left: number, top: number, behavior: ScrollBehavior | null): void {
        this.scroll(left, top, behavior);
    }

    scrollBy(deltaX: number, deltaY: number, behavior: ScrollBehavior | null): void {
        if (!behavior)
            this.#htmlElement.scrollBy(deltaX, deltaY);
        else
            this.#htmlElement.scrollBy({ left: deltaX, top: deltaY, behavior });
    }

    scrollIntoView(block: ScrollLogicalPosition = "start", inline: ScrollLogicalPosition = "nearest", behavior: ScrollBehavior = "auto"): void {
        this.#htmlElement.scrollIntoView({ block, inline, behavior });
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
        return [...this.#htmlElement.getElementsByClassName(className)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    getElementsByTagName(qualifiedName: string): HTMLElementAPI[] {
        return [... this.#htmlElement.getElementsByTagName(qualifiedName)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    getElementsByTagNameNS(namespace: string, qualifiedName: string): HTMLElementAPI[] {
        return [... this.#htmlElement.getElementsByTagNameNS(namespace, qualifiedName)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    querySelector(selectors: string): [HTMLElementAPI] | [null] {
        const result = this.#htmlElement.querySelector(selectors);
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    querySelectorAll(selectors: string): HTMLElementAPI[] {
        return [... this.#htmlElement.querySelectorAll(selectors)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    closest(selectors: string): [HTMLElementAPI] | [null] {
        const result = this.#htmlElement.closest(selectors);
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
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
    static #deconstructTouchList(touchList: TouchList): { identifier: number, clientX: number, clientY: number, pageX: number, pageY: number, screenX: number, screenY: number, radiusX: number, radiusY: number, rotationAngle: number, force: number }[] {
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


    // HTMLElement - change event

    #onchange = () => BlazorInvoke.method(this.#eventTrigger, "InvokeChange");

    activateOnchange(): void {
        this.#htmlElement.addEventListener("change", this.#onchange);
    }

    deactivateOnchange(): void {
        this.#htmlElement.removeEventListener("change", this.#onchange);
    }


    // HTMLElement - command event

    #oncommand = (commandEvent: { source: HTMLButtonElement, command: string }) => BlazorInvoke.method(this.#eventTrigger, "InvokeCommand", DotNet.createJSObjectReference(new HTMLElementAPI(commandEvent.source)), commandEvent.command);

    activateOncommand(): void {
        this.#htmlElement.addEventListener("command", <(commandEvent: Event) => void><unknown>this.#oncommand);
    }

    deactivateOncommand(): void {
        this.#htmlElement.removeEventListener("command", <(commandEvent: Event) => void><unknown>this.#oncommand);
    }


    // HTMLElement - load event

    #onload = () => BlazorInvoke.method(this.#eventTrigger, "InvokeLoad");

    activateOnload(): void {
        this.#htmlElement.addEventListener("load", this.#onload);
    }

    deactivateOnload(): void {
        this.#htmlElement.removeEventListener("load", this.#onload);
    }


    // HTMLElement - error event

    #onerror = (error: Event) => BlazorInvoke.method(this.#eventTrigger, "InvokeError", error);

    activateOnerror(): void {
        this.#htmlElement.addEventListener("error", this.#onerror);
    }

    deactivateOnerror(): void {
        this.#htmlElement.removeEventListener("error", this.#onerror);
    }


    // HTMLElement - drag event

    #ondrag = (dragEvent: DragEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDrag", ... HTMLElementAPI.#deconstructDataTransfer(dragEvent.dataTransfer));

    activateOndrag(): void {
        this.#htmlElement.addEventListener("drag", this.#ondrag);
    }

    deactivateOndrag(): void {
        this.#htmlElement.removeEventListener("drag", this.#ondrag);
    }


    // HTMLElement - dragstart event

    #ondragstart = (dragEvent: DragEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDragStart", ...HTMLElementAPI.#deconstructDataTransfer(dragEvent.dataTransfer));

    activateOndragstart(): void {
        this.#htmlElement.addEventListener("dragstart", this.#ondragstart);
    }

    deactivateOndragstart(): void {
        this.#htmlElement.removeEventListener("dragstart", this.#ondragstart);
    }


    // HTMLElement - dragend event

    #ondragend = (dragEvent: DragEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDragEnd", ...HTMLElementAPI.#deconstructDataTransfer(dragEvent.dataTransfer));

    activateOndragend(): void {
        this.#htmlElement.addEventListener("dragend", this.#ondragend);
    }

    deactivateOndragend(): void {
        this.#htmlElement.removeEventListener("dragend", this.#ondragend);
    }


    // HTMLElement - dragenter event

    #ondragenter = (dragEvent: DragEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDragEnter", ...HTMLElementAPI.#deconstructDataTransfer(dragEvent.dataTransfer));

    activateOndragenter(): void {
        this.#htmlElement.addEventListener("dragenter", this.#ondragenter);
    }

    deactivateOndragenter(): void {
        this.#htmlElement.removeEventListener("dragenter", this.#ondragenter);
    }


    // HTMLElement - dragleave event

    #ondragleave = (dragEvent: DragEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDragLeave", ...HTMLElementAPI.#deconstructDataTransfer(dragEvent.dataTransfer));

    activateOndragleave(): void {
        this.#htmlElement.addEventListener("dragleave", this.#ondragleave);
    }

    deactivateOndragleave(): void {
        this.#htmlElement.removeEventListener("dragleave", this.#ondragleave);
    }


    // HTMLElement - dragover event

    #ondragover = (dragEvent: DragEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDragOver", ...HTMLElementAPI.#deconstructDataTransfer(dragEvent.dataTransfer));

    activateOndragover(): void {
        this.#htmlElement.addEventListener("dragover", this.#ondragover);
    }

    deactivateOndragover(): void {
        this.#htmlElement.removeEventListener("dragover", this.#ondragover);
    }


    // HTMLElement - drop event

    #ondrop = (dragEvent: DragEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeDrop", ...HTMLElementAPI.#deconstructDataTransfer(dragEvent.dataTransfer));

    activateOndrop(): void {
        this.#htmlElement.addEventListener("drop", this.#ondrop);
    }

    deactivateOndrop(): void {
        this.#htmlElement.removeEventListener("drop", this.#ondrop);
    }


    // HTMLElement - toggle

    #ontoggle = (toggleEvent: ToggleEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeToggle", toggleEvent.oldState, toggleEvent.newState);

    activateOntoggle(): void {
        this.#htmlElement.addEventListener("toggle", this.#ontoggle);
    }

    deactivateOntoggle(): void {
        this.#htmlElement.removeEventListener("toggle", this.#ontoggle);
    }


    // HTMLElement - beforetoggle

    #onbeforetoggle = (toggleEvent: ToggleEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeBeforeToggle", toggleEvent.oldState, toggleEvent.newState);

    activateOnbeforetoggle(): void {
        this.#htmlElement.addEventListener("beforetoggle", this.#onbeforetoggle);
    }

    deactivateOnbeforetoggle(): void {
        this.#htmlElement.removeEventListener("beforetoggle", this.#onbeforetoggle);
    }



    // Element - input event

    #oninput = (inputEvent: InputEvent | Event) => BlazorInvoke.method(this.#eventTrigger, "InvokeInput", ...HTMLElementAPI.#deconstructInputEvent(inputEvent));

    activateOninput(): void {
        this.#htmlElement.addEventListener("input", this.#oninput);
    }

    deactivateOninput(): void {
        this.#htmlElement.removeEventListener("input", this.#oninput);
    }


    // Element - beforeinput event

    #onbeforeinput = (inputEvent: InputEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeBeforeInput", ...HTMLElementAPI.#deconstructInputEvent(inputEvent));

    activateOnbeforeinput(): void {
        this.#htmlElement.addEventListener("beforeinput", this.#onbeforeinput);
    }

    deactivateOnbeforeinput(): void {
        this.#htmlElement.removeEventListener("beforeinput", this.#onbeforeinput);
    }


    // Element - contentvisibilityautostatechange event

    #oncontentvisibilityautostatechange = (event: { skipped: boolean; }) => BlazorInvoke.method(this.#eventTrigger, "InvokeContentVisibilityAutoStateChange", event.skipped);

    activateOncontentvisibilityautostatechange(): void {
        this.#htmlElement.addEventListener("contentvisibilityautostatechange", <() => {}>this.#oncontentvisibilityautostatechange);
    }

    deactivateOncontentvisibilityautostatechange(): void {
        this.#htmlElement.removeEventListener("contentvisibilityautostatechange", <() => {}>this.#oncontentvisibilityautostatechange);
    }


    // Element - beforematch event

    #onbeforematch = () => BlazorInvoke.method(this.#eventTrigger, "InvokeBeforeMatch");

    activateOnbeforematch(): void {
        this.#htmlElement.addEventListener("beforematch", this.#onbeforematch);
    }

    deactivateOnbeforematch(): void {
        this.#htmlElement.removeEventListener("beforematch", this.#onbeforematch);
    }


    // Element - securitypolicyviolation event

    #onsecuritypolicyviolation = (violationEvent: SecurityPolicyViolationEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeSecurityPolicyViolation", {
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

    activateOnsecuritypolicyviolation(): void {
        this.#htmlElement.addEventListener("securitypolicyviolation", this.#onsecuritypolicyviolation);
    }

    deactivateOnsecuritypolicyviolation(): void {
        this.#htmlElement.removeEventListener("securitypolicyviolation", this.#onsecuritypolicyviolation);
    }


    // Node - selectstart event

    #onselectstart = () => BlazorInvoke.method(this.#eventTrigger, "InvokeSelectStart");

    activateOnselectstart(): void {
        this.#htmlElement.addEventListener("selectstart", this.#onselectstart);
    }

    deactivateOnselectstart(): void {
        this.#htmlElement.removeEventListener("selectstart", this.#onselectstart);
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
        this.#htmlElement.addEventListener("keydown", this.#onkeydown);
    }

    deactivateOnkeydown(): void {
        this.#htmlElement.removeEventListener("keydown", this.#onkeydown);
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
        this.#htmlElement.addEventListener("keyup", this.#onkeyup);
    }

    deactivateOnkeyup(): void {
        this.#htmlElement.removeEventListener("keyup", this.#onkeyup);
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
        this.#htmlElement.addEventListener("click", this.#onclick);
    }

    deactivateOnclick(): void {
        this.#htmlElement.removeEventListener("click", this.#onclick);
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
        this.#htmlElement.addEventListener("dblclick", this.#ondblclick);
    }

    deactivateOndblclick(): void {
        this.#htmlElement.removeEventListener("dblclick", this.#ondblclick);
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
        this.#htmlElement.addEventListener("auxclick", this.#onauxclick);
    }

    deactivateOnauxclick(): void {
        this.#htmlElement.removeEventListener("auxclick", this.#onauxclick);
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
        this.#htmlElement.addEventListener("contextmenu", this.#oncontextmenu);
    }

    deactivateOncontextmenu(): void {
        this.#htmlElement.removeEventListener("contextmenu", this.#oncontextmenu);
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
        this.#htmlElement.addEventListener("mousedown", this.#onmousedown);
    }

    deactivateOnmousedown(): void {
        this.#htmlElement.removeEventListener("mousedown", this.#onmousedown);
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
        this.#htmlElement.addEventListener("mouseup", this.#onmouseup);
    }

    deactivateOnmouseup(): void {
        this.#htmlElement.removeEventListener("mouseup", this.#onmouseup);
    }


    // Element - wheel event

    #onwheel = (wheelEvent: WheelEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeWheel", {
        deltaX: wheelEvent.deltaX,
        deltaY: wheelEvent.deltaY,
        deltaZ: wheelEvent.deltaZ,
        deltaMode: wheelEvent.deltaMode
    });

    activateOnwheel(): void {
        this.#htmlElement.addEventListener("wheel", this.#onwheel, { passive: true });
    }

    deactivateOnwheel(): void {
        this.#htmlElement.removeEventListener("wheel", this.#onwheel);
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
        this.#htmlElement.addEventListener("mousemove", this.#onmousemove);
    }

    deactivateOnmousemove(): void {
        this.#htmlElement.removeEventListener("mousemove", this.#onmousemove);
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
        this.#htmlElement.addEventListener("mouseover", this.#onmouseover);
    }

    deactivateOnmouseover(): void {
        this.#htmlElement.removeEventListener("mouseover", this.#onmouseover);
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
        this.#htmlElement.addEventListener("mouseout", this.#onmouseout);
    }

    deactivateOnmouseout(): void {
        this.#htmlElement.removeEventListener("mouseout", this.#onmouseout);
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
        this.#htmlElement.addEventListener("mouseenter", this.#onmouseenter);
    }

    deactivateOnmouseenter(): void {
        this.#htmlElement.removeEventListener("mouseenter", this.#onmouseenter);
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
        this.#htmlElement.addEventListener("mouseleave", this.#onmouseleave);
    }

    deactivateOnmouseleave(): void {
        this.#htmlElement.removeEventListener("mouseleave", this.#onmouseleave);
    }



    // Element - touchstart event

    #ontouchstart = (touchEvent: TouchEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTouchStart", {
        touches: HTMLElementAPI.#deconstructTouchList(touchEvent.touches),
        targetTouches: HTMLElementAPI.#deconstructTouchList(touchEvent.targetTouches),
        changedTouches: HTMLElementAPI.#deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    activateOntouchstart(): void {
        this.#htmlElement.addEventListener("touchstart", this.#ontouchstart);
    }

    deactivateOntouchstart(): void {
        this.#htmlElement.removeEventListener("touchstart", this.#ontouchstart);
    }


    // Element - touchend event

    #ontouchend = (touchEvent: TouchEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTouchEnd", {
        touches: HTMLElementAPI.#deconstructTouchList(touchEvent.touches),
        targetTouches: HTMLElementAPI.#deconstructTouchList(touchEvent.targetTouches),
        changedTouches: HTMLElementAPI.#deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    activateOntouchend(): void {
        this.#htmlElement.addEventListener("touchend", this.#ontouchend);
    }

    deactivateOntouchend(): void {
        this.#htmlElement.removeEventListener("touchend", this.#ontouchend);
    }


    // Element - touchmove event

    #ontouchmove = (touchEvent: TouchEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTouchMove", {
        touches: HTMLElementAPI.#deconstructTouchList(touchEvent.touches),
        targetTouches: HTMLElementAPI.#deconstructTouchList(touchEvent.targetTouches),
        changedTouches: HTMLElementAPI.#deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    activateOntouchmove(): void {
        this.#htmlElement.addEventListener("touchmove", this.#ontouchmove);
    }

    deactivateOntouchmove(): void {
        this.#htmlElement.removeEventListener("touchmove", this.#ontouchmove);
    }


    // Element - touchcancel event

    #ontouchcancel = (touchEvent: TouchEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTouchCancel", {
        touches: HTMLElementAPI.#deconstructTouchList(touchEvent.touches),
        targetTouches: HTMLElementAPI.#deconstructTouchList(touchEvent.targetTouches),
        changedTouches: HTMLElementAPI.#deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    activateOntouchcancel(): void {
        this.#htmlElement.addEventListener("touchcancel", this.#ontouchcancel);
    }

    deactivateOntouchcancel(): void {
        this.#htmlElement.removeEventListener("touchcancel", this.#ontouchcancel);
    }



    // Element - pointerdown event

    #onpointerdown = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number }) => BlazorInvoke.method(this.#eventTrigger, "InvokePointerDown", {
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
        this.#htmlElement.addEventListener("pointerdown", this.#onpointerdown);
    }

    deactivateOnpointerdown(): void {
        this.#htmlElement.removeEventListener("pointerdown", this.#onpointerdown);
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
        this.#htmlElement.addEventListener("pointerup", this.#onpointerup);
    }

    deactivateOnpointerup(): void {
        this.#htmlElement.removeEventListener("pointerup", this.#onpointerup);
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
        this.#htmlElement.addEventListener("pointermove", this.#onpointermove);
    }

    deactivateOnpointermove(): void {
        this.#htmlElement.removeEventListener("pointermove", this.#onpointermove);
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
        this.#htmlElement.addEventListener("pointerover", this.#onpointerover);
    }

    deactivateOnpointerover(): void {
        this.#htmlElement.removeEventListener("pointerover", this.#onpointerover);
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
        this.#htmlElement.addEventListener("pointerout", this.#onpointerout);
    }

    deactivateOnpointerout(): void {
        this.#htmlElement.removeEventListener("pointerout", this.#onpointerout);
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
        this.#htmlElement.addEventListener("pointerenter", this.#onpointerenter);
    }

    deactivateOnpointerenter(): void {
        this.#htmlElement.removeEventListener("pointerenter", this.#onpointerenter);
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
        this.#htmlElement.addEventListener("pointerleave", this.#onpointerleave);
    }

    deactivateOnpointerleave(): void {
        this.#htmlElement.removeEventListener("pointerleave", this.#onpointerleave);
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
        this.#htmlElement.addEventListener("pointercancel", this.#onpointercancel);
    }

    deactivateOnpointercancel(): void {
        this.#htmlElement.removeEventListener("pointercancel", this.#onpointercancel);
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
        this.#htmlElement.addEventListener("pointerrawupdate", this.#onpointerrawupdate);
    }

    deactivateOnpointerrawupdate(): void {
        this.#htmlElement.removeEventListener("pointerrawupdate", this.#onpointerrawupdate);
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
        this.#htmlElement.addEventListener("gotpointercapture", this.#ongotpointercapture);
    }

    deactivateOngotpointercapture(): void {
        this.#htmlElement.removeEventListener("gotpointercapture", this.#ongotpointercapture);
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
        this.#htmlElement.addEventListener("lostpointercapture", this.#onlostpointercapture);
    }

    deactivateOnlostpointercapture(): void {
        this.#htmlElement.removeEventListener("lostpointercapture", this.#onlostpointercapture);
    }



    // Element - scroll event

    #onscroll = () => BlazorInvoke.method(this.#eventTrigger, "InvokeScroll");

    activateOnscroll(): void {
        this.#htmlElement.addEventListener("scroll", this.#onscroll);
    }

    deactivateOnscroll(): void {
        this.#htmlElement.removeEventListener("scroll", this.#onscroll);
    }


    // Element - scrollend event

    #onscrollend = () => BlazorInvoke.method(this.#eventTrigger, "InvokeScrollEnd");

    activateOnscrollend(): void {
        this.#htmlElement.addEventListener("scrollend", this.#onscrollend);
    }

    deactivateOnscrollend(): void {
        this.#htmlElement.removeEventListener("scrollend", this.#onscrollend);
    }



    // Element - focus event

    #onfocus = () => BlazorInvoke.method(this.#eventTrigger, "InvokeFocus");

    activateOnfocus(): void {
        this.#htmlElement.addEventListener("focus", this.#onfocus);
    }

    deactivateOnfocus(): void {
        this.#htmlElement.removeEventListener("focus", this.#onfocus);
    }


    // Element - focusin event

    #onfocusin = () => BlazorInvoke.method(this.#eventTrigger, "InvokeFocusIn");

    activateOnfocusin(): void {
        this.#htmlElement.addEventListener("focusin", this.#onfocusin);
    }

    deactivateOnfocusin(): void {
        this.#htmlElement.removeEventListener("focusin", this.#onfocusin);
    }


    // Element - blur event

    #onblur = () => BlazorInvoke.method(this.#eventTrigger, "InvokeBlur");

    activateOnblur(): void {
        this.#htmlElement.addEventListener("blur", this.#onblur);
    }

    deactivateOnblur(): void {
        this.#htmlElement.removeEventListener("blur", this.#onblur);
    }


    // Element - focusout event

    #onfocusout = () => BlazorInvoke.method(this.#eventTrigger, "InvokeFocusOut");

    activateOnfocusout(): void {
        this.#htmlElement.addEventListener("focusout", this.#onfocusout);
    }

    deactivateOnfocusout(): void {
        this.#htmlElement.removeEventListener("focusout", this.#onfocusout);
    }



    // Element - copy event

    #oncopy = () => BlazorInvoke.method(this.#eventTrigger, "InvokeCopy");

    activateOncopy(): void {
        this.#htmlElement.addEventListener("copy", this.#oncopy);
    }

    deactivateOncopy(): void {
        this.#htmlElement.removeEventListener("copy", this.#oncopy);
    }


    // Element - paste event

    #onpaste = () => BlazorInvoke.method(this.#eventTrigger, "InvokePaste");

    activateOnpaste(): void {
        this.#htmlElement.addEventListener("paste", this.#onpaste);
    }

    deactivateOnpaste(): void {
        this.#htmlElement.removeEventListener("paste", this.#onpaste);
    }


    // Element - cut event

    #oncut = () => BlazorInvoke.method(this.#eventTrigger, "InvokeCut");

    activateOncut(): void {
        this.#htmlElement.addEventListener("cut", this.#oncut);
    }

    deactivateOncut(): void {
        this.#htmlElement.removeEventListener("cut", this.#oncut);
    }



    // Element - transitionstart event

    #ontransitionstart = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTransitionStart", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    activateOntransitionstart(): void {
        this.#htmlElement.addEventListener("transitionstart", this.#ontransitionstart);
    }

    deactivateOntransitionstart(): void {
        this.#htmlElement.removeEventListener("transitionstart", this.#ontransitionstart);
    }


    // Element - transitionend event

    #ontransitionend = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTransitionEnd", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)

    activateOntransitionend(): void {
        this.#htmlElement.addEventListener("transitionend", this.#ontransitionend);
    }

    deactivateOntransitionend(): void {
        this.#htmlElement.removeEventListener("transitionend", this.#ontransitionend);
    }


    // Element - transitionrun event

    #ontransitionrun = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTransitionRun", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)

    activateOntransitionrun(): void {
        this.#htmlElement.addEventListener("transitionrun", this.#ontransitionrun);
    }

    deactivateOntransitionrun(): void {
        this.#htmlElement.removeEventListener("transitionrun", this.#ontransitionrun);
    }


    // Element - transitioncancel event

    #ontransitioncancel = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeTransitionCancel", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)

    activateOntransitioncancel(): void {
        this.#htmlElement.addEventListener("transitioncancel", this.#ontransitioncancel);
    }

    deactivateOntransitioncancel(): void {
        this.#htmlElement.removeEventListener("transitioncancel", this.#ontransitioncancel);
    }



    // Element - animationstart event

    #onanimationstart = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeAnimationStart", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)

    activateOnanimationstart(): void {
        this.#htmlElement.addEventListener("animationstart", this.#onanimationstart);
    }

    deactivateOnanimationstart(): void {
        this.#htmlElement.removeEventListener("animationstart", this.#onanimationstart);
    }


    // Element - animationend event

    #onanimationend = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeAnimationEnd", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)

    activateOnanimationend(): void {
        this.#htmlElement.addEventListener("animationend", this.#onanimationend);
    }

    deactivateOnanimationend(): void {
        this.#htmlElement.removeEventListener("animationend", this.#onanimationend);
    }


    // Element - animationiteration event

    #onanimationiteration = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeAnimationIteration", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)

    activateOnanimationiteration(): void {
        this.#htmlElement.addEventListener("animationiteration", this.#onanimationiteration);
    }

    deactivateOnanimationiteration(): void {
        this.#htmlElement.removeEventListener("animationiteration", this.#onanimationiteration);
    }


    // Element - animationcancel event

    #onanimationcancel = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.#eventTrigger, "InvokeAnimationCancel", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)

    activateOnanimationcancel(): void {
        this.#htmlElement.addEventListener("animationcancel", this.#onanimationcancel);
    }

    deactivateOnanimationcancel(): void {
        this.#htmlElement.removeEventListener("animationcancel", this.#onanimationcancel);
    }



    // Element - fullscreenchange event

    #onfullscreenchange = () => BlazorInvoke.method(this.#eventTrigger, "InvokeFullscreenChange");

    activateOnfullscreenchange(): void {
        this.#htmlElement.addEventListener("fullscreenchange", this.#onfullscreenchange);
    }

    deactivateOnfullscreenchange(): void {
        this.#htmlElement.removeEventListener("fullscreenchange", this.#onfullscreenchange);
    }


    // Element - fullscreenerror event

    #onfullscreenerror = () => BlazorInvoke.method(this.#eventTrigger, "InvokeFullscreenError");

    activateOnfullscreenerror(): void {
        this.#htmlElement.addEventListener("fullscreenerror", this.#onfullscreenerror);
    }

    deactivateOnfullscreenerror(): void {
        this.#htmlElement.removeEventListener("fullscreenerror", this.#onfullscreenerror);
    }
}
