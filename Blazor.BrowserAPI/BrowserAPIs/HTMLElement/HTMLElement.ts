import { HTMLDialogElementAPI } from "../HTMLDialogElement/HTMLDialogElement";
import { HTMLMediaElementAPI } from "../HTMLMediaElement/HTMLMediaElement";
import { FileAPI } from "../FileSystem/File/File";
import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class HTMLElementAPI {
    private _htmlElement: HTMLElement;
    public get htmlElement(): HTMLElement {
        return this._htmlElement;
    }

    public constructor(htmlElement: HTMLElement) {
        this._htmlElement = htmlElement;
    }

    public static create(htmlElement: HTMLElement): HTMLElementAPI {
        return new HTMLElementAPI(htmlElement);
    }


    public toHTMLDialogElement(): HTMLDialogElementAPI {
        return new HTMLDialogElementAPI(<HTMLDialogElement>this.htmlElement);
    }

    public toHTMLMediaElement(): HTMLMediaElementAPI {
        return new HTMLMediaElementAPI(<HTMLMediaElement>this.htmlElement);
    }


    // HTMLElement

    public getAccessKey(): string {
        return this.htmlElement.accessKey;
    }

    public setAccessKey(value: string): void {
        this.htmlElement.accessKey = value;
    }

    public getAccessKeyLabel(): string {
        return this.htmlElement.accessKeyLabel;
    }


    public getAttributeStyleMap(): Record<string, string> {
        const attributeStyleMap = this.htmlElement.attributeStyleMap;

        const result: Record<string, string> = {};
        for (const [name, value] of attributeStyleMap.entries())
            result[name] = value.toString();
        return result;
    }

    public setAttributeStyleMap(name: string, value: string): void {
        this.htmlElement.attributeStyleMap.set(name, value);
    }

    public removeAttributeStyleMap(name: string): void {
        this.htmlElement.attributeStyleMap.delete(name);
    }


    public getAutocapitalize(): string {
        return this.htmlElement.autocapitalize;
    }

    public setAutocapitalize(value: string): void {
        this.htmlElement.autocapitalize = value;
    }


    public getAutofocus(): boolean {
        return this.htmlElement.autofocus;
    }

    public setAutofocus(value: boolean): void {
        this.htmlElement.autofocus = value;
    }


    public getContentEditable(): string {
        return this.htmlElement.contentEditable;
    }

    public setContentEditable(value: string): void {
        this.htmlElement.contentEditable = value;
    }


    public getDataset(): Record<string, string> {
        return <Record<string, string>>this.htmlElement.dataset;
    }

    public setDataset(name: string, value: string): void {
        this.htmlElement.dataset[name] = value;
    }

    public removeDataset(name: string): void {
        delete this.htmlElement.dataset[name];
    }


    public getDir(): string {
        return this.htmlElement.dir;
    }

    public setDir(value: string): void {
        this.htmlElement.dir = value;
    }


    public getDraggable(): boolean {
        return this.htmlElement.draggable;
    }

    public setDraggable(value: boolean): void {
        this.htmlElement.draggable = value;
    }


    public getEnterKeyHint(): string {
        return this.htmlElement.enterKeyHint;
    }

    public setEnterKeyHint(value: string): void {
        this.htmlElement.enterKeyHint = value;
    }


    public getHidden(): boolean {
        return this.htmlElement.hidden;
    }

    public setHidden(value: boolean): void {
        this.htmlElement.hidden = value;
    }


    public getInert(): boolean {
        return this.htmlElement.inert;
    }

    public setInert(value: boolean): void {
        this.htmlElement.inert = value;
    }


    public getInnerText(): string {
        return this.htmlElement.innerText;
    }

    public setInnerText(value: string): void {
        this.htmlElement.innerText = value;
    }


    public getInputMode(): string {
        return this.htmlElement.inputMode;
    }

    public setInputMode(value: string): void {
        this.htmlElement.inputMode = value;
    }


    public getIsContentEditable(): boolean {
        return this.htmlElement.isContentEditable;
    }


    public getLang(): string {
        return this.htmlElement.lang;
    }

    public setLang(value: string): void {
        this.htmlElement.lang = value;
    }


    public getNonce(): string {
        return this.htmlElement.nonce ?? "";
    }

    public setNonce(value: string): void {
        this.htmlElement.nonce = value;
    }


    public getOffsetWidth(): number {
        return this.htmlElement.offsetWidth;
    }

    public getOffsetHeight(): number {
        return this.htmlElement.offsetHeight;
    }

    public getOffsetLeft(): number {
        return this.htmlElement.offsetLeft;
    }

    public getOffsetTop(): number {
        return this.htmlElement.offsetTop;
    }

    public getOffsetParent(): [HTMLElementAPI] | [null] {
        if (this.htmlElement.offsetParent instanceof HTMLElement)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(this.htmlElement.offsetParent))];
        else
            return [null];
    }


    public getOuterText(): string {
        return this.htmlElement.outerText;
    }

    public setOuterText(value: string): void {
        this.htmlElement.outerText = value;
    }


    public getPopover(): string | null {
        return this.htmlElement.popover;
    }

    public setPopover(value: string | null): void {
        this.htmlElement.popover = value;
    }


    public getSpellcheck(): boolean {
        return this.htmlElement.spellcheck;
    }

    public setSpellcheck(value: boolean): void {
        this.htmlElement.spellcheck = value;
    }


    public getStyle(): string {
        return this.htmlElement.style.cssText;
    }

    public setStyle(value: string): void {
        this.htmlElement.style.cssText = value;
    }


    public getTabIndex(): number {
        return this.htmlElement.tabIndex;
    }

    public setTabIndex(value: number): void {
        this.htmlElement.tabIndex = value;
    }


    public getTitle(): string {
        return this.htmlElement.title;
    }

    public setTitle(value: string): void {
        this.htmlElement.title = value;
    }


    public getTranslate(): boolean {
        return this.htmlElement.translate;
    }

    public setTranslate(value: boolean): void {
        this.htmlElement.translate = value;
    }


    // HTMLElement extra

    public hasFocus(): boolean {
        return this.htmlElement === document.activeElement;
    }


    // HTMLElement methods

    public click(): void {
        this.htmlElement.click();
    }

    public focus(preventScroll: boolean = false): void {
        this.htmlElement.focus({ preventScroll });
    }

    public blur(): void {
        this.htmlElement.blur();
    }

    public showPopover(): void {
        this.htmlElement.showPopover();
    }

    public hidePopover(): void {
        this.htmlElement.hidePopover();
    }

    public togglePopover(force: boolean | null): boolean {
        return <boolean><unknown>this.htmlElement.togglePopover(force ?? undefined);
    }



    // Node/Element

    public getAttributes(): Record<string, string> {
        const attributes = this.htmlElement.attributes;

        const result: Record<string, string> = {};
        for (const attribute of attributes)
            result[attribute.name] = attribute.value;
        return result;
    }


    public getClassList(): string[] {
        return [... this.htmlElement.classList];
    }


    public getClassName(): string {
        return this.htmlElement.className;
    }

    public setClassName(value: string): void {
        this.htmlElement.className = value;
    }


    public getClientWidth(): number {
        return this.htmlElement.clientWidth;
    }

    public getClientHeight(): number {
        return this.htmlElement.clientHeight;
    }

    public getClientLeft(): number {
        return this.htmlElement.clientLeft;
    }

    public getClientTop(): number {
        return this.htmlElement.clientTop;
    }


    public getCurrentCSSZoom(): number {
        return (<HTMLElement & { currentCSSZoom: number; }>this.htmlElement).currentCSSZoom;
    }


    public getId(): string {
        return this.htmlElement.id;
    }

    public setId(value: string): void {
        this.htmlElement.id = value;
    }


    public getIsConnected(): boolean {
        return this.htmlElement.isConnected;
    }


    public getInnerHTML(): string {
        return this.htmlElement.innerHTML;
    }

    public setInnerHTML(value: string): void {
        this.htmlElement.innerHTML = value;
    }


    public getOuterHTML(): string {
        return this.htmlElement.outerHTML;
    }

    public setOuterHTML(value: string): void {
        this.htmlElement.outerHTML = value;
    }


    public getPart(): string[] {
        return [... this.htmlElement.part];
    }


    public getScrollWidth(): number {
        return this.htmlElement.scrollWidth;
    }

    public getScrollHeight(): number {
        return this.htmlElement.scrollHeight;
    }

    public getScrollLeft(): number {
        return this.htmlElement.scrollLeft;
    }

    public setScrollLeft(value: number): void {
        this.htmlElement.scrollLeft = value;
    }

    public getScrollTop(): number {
        return this.htmlElement.scrollTop;
    }

    public setScrollTop(value: number): void {
        this.htmlElement.scrollTop = value;
    }


    public getSlot(): string {
        return this.htmlElement.slot;
    }

    public setSlot(value: string): void {
        this.htmlElement.slot = value;
    }


    public getTextContent(): string {
        // textContent of HTMLElements are always not null
        return <string>this.htmlElement.textContent;
    }

    public setTextContent(value: string): void {
        this.htmlElement.textContent = value;
    }


    public getLocalName(): string {
        return this.htmlElement.localName;
    }

    public getNamespaceURI(): string | null {
        return this.htmlElement.namespaceURI;
    }

    public getPrefix(): string | null {
        return this.htmlElement.prefix;
    }


    public getBaseURI(): string {
        return this.htmlElement.baseURI;
    }

    public getTagName(): string {
        return this.htmlElement.tagName;
    }

    public getNodeName(): string {
        return this.htmlElement.nodeName;
    }

    public getNodeType(): number {
        return this.htmlElement.nodeType;
    }


    // Node/Element properties - Tree-nodes

    public getChildElementCount(): number {
        return this.htmlElement.childElementCount;
    }

    public getChildren(): HTMLElementAPI[] {
        return [... this.htmlElement.children].map((child: HTMLElement) => DotNet.createJSObjectReference(new HTMLElementAPI(child)));
    }

    public getFirstElementChild(): [HTMLElementAPI] | [null] {
        const result = this.htmlElement.firstElementChild;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    public getLastElementChild(): [HTMLElementAPI] | [null] {
        const result = this.htmlElement.lastElementChild;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    public getPreviousElementSibling(): [HTMLElementAPI] | [null] {
        const result = this.htmlElement.previousElementSibling;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    public getNextElementSibling(): [HTMLElementAPI] | [null] {
        const result = this.htmlElement.nextElementSibling;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    public getParentElement(): [HTMLElementAPI] | [null] {
        const result = this.htmlElement.parentElement;
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(result))];
        else
            return [null];
    }


    // Node/Element properties - ARIA

    public getAriaAtomic(): string | null {
        return this.htmlElement.ariaAtomic;
    }

    public setAriaAtomic(value: string | null): void {
        this.htmlElement.ariaAtomic = value;
    }


    public getAriaAutoComplete(): string | null {
        return this.htmlElement.ariaAutoComplete;
    }

    public setAriaAutoComplete(value: string | null): void {
        this.htmlElement.ariaAutoComplete = value;
    }


    public getAriaBrailleLabel(): string | null {
        return (<HTMLElement & { ariaBrailleLabel: string | null; }>this.htmlElement).ariaBrailleLabel;
    }

    public setAriaBrailleLabel(value: string | null): void {
        (<HTMLElement & { ariaBrailleLabel: string | null; }>this.htmlElement).ariaBrailleLabel = value;
    }


    public getAriaBrailleRoleDescription(): string | null {
        return (<HTMLElement & { ariaBrailleRoleDescription: string | null; }>this.htmlElement).ariaBrailleRoleDescription;
    }

    public setAriaBrailleRoleDescription(value: string | null): void {
        (<HTMLElement & { ariaBrailleRoleDescription: string | null; }>this.htmlElement).ariaBrailleRoleDescription = value;
    }


    public getAriaBusy(): string | null {
        return this.htmlElement.ariaBusy;
    }

    public setAriaBusy(value: string | null): void {
        this.htmlElement.ariaBusy = value;
    }


    public getAriaChecked(): string | null {
        return this.htmlElement.ariaChecked;
    }

    public setAriaChecked(value: string | null): void {
        this.htmlElement.ariaChecked = value;
    }


    public getAriaColCount(): string | null {
        return this.htmlElement.ariaColCount;
    }

    public setAriaColCount(value: string | null): void {
        this.htmlElement.ariaColCount = value;
    }


    public getAriaColIndex(): string | null {
        return this.htmlElement.ariaColIndex;
    }

    public setAriaColIndex(value: string | null): void {
        this.htmlElement.ariaColIndex = value;
    }


    public getAriaColIndexText(): string | null {
        return (<HTMLElement & { ariaColIndexText: string | null; }>this.htmlElement).ariaColIndexText;
    }

    public setAriaColIndexText(value: string | null): void {
        (<HTMLElement & { ariaColIndexText: string | null; }>this.htmlElement).ariaColIndexText = value;
    }


    public getAriaColSpan(): string | null {
        return this.htmlElement.ariaColSpan;
    }

    public setAriaColSpan(value: string | null): void {
        this.htmlElement.ariaColSpan = value;
    }


    public getAriaCurrent(): string | null {
        return this.htmlElement.ariaCurrent;
    }

    public setAriaCurrent(value: string | null): void {
        this.htmlElement.ariaCurrent = value;
    }


    public getAriaDescription(): string | null {
        return (<HTMLElement & { ariaDescription: string | null; }>this.htmlElement).ariaDescription;
    }

    public setAriaDescription(value: string | null): void {
        (<HTMLElement & { ariaDescription: string | null; }>this.htmlElement).ariaDescription = value;
    }


    public getAriaDisabled(): string | null {
        return this.htmlElement.ariaDisabled;
    }

    public setAriaDisabled(value: string | null): void {
        this.htmlElement.ariaDisabled = value;
    }


    public getAriaExpanded(): string | null {
        return this.htmlElement.ariaExpanded;
    }

    public setAriaExpanded(value: string | null): void {
        this.htmlElement.ariaExpanded = value;
    }


    public getAriaHasPopup(): string | null {
        return this.htmlElement.ariaHasPopup;
    }

    public setAriaHasPopup(value: string | null): void {
        this.htmlElement.ariaHasPopup = value;
    }


    public getAriaHidden(): string | null {
        return this.htmlElement.ariaHidden;
    }

    public setAriaHidden(value: string | null): void {
        this.htmlElement.ariaHidden = value;
    }


    public getAriaInvalid(): string | null {
        return this.htmlElement.ariaInvalid;
    }

    public setAriaInvalid(value: string | null): void {
        this.htmlElement.ariaInvalid = value;
    }


    public getAriaKeyShortcuts(): string | null {
        return this.htmlElement.ariaKeyShortcuts;
    }

    public setAriaKeyShortcuts(value: string | null): void {
        this.htmlElement.ariaKeyShortcuts = value;
    }


    public getAriaLabel(): string | null {
        return this.htmlElement.ariaLabel;
    }

    public setAriaLabel(value: string | null): void {
        this.htmlElement.ariaLabel = value;
    }


    public getAriaLevel(): string | null {
        return this.htmlElement.ariaLevel;
    }

    public setAriaLevel(value: string | null): void {
        this.htmlElement.ariaLevel = value;
    }


    public getAriaLive(): string | null {
        return this.htmlElement.ariaLive;
    }

    public setAriaLive(value: string | null): void {
        this.htmlElement.ariaLive = value;
    }


    public getAriaModal(): string | null {
        return this.htmlElement.ariaModal;
    }

    public setAriaModal(value: string | null): void {
        this.htmlElement.ariaModal = value;
    }


    public getAriaMultiline(): string | null {
        return (<HTMLElement & { ariaMultiline: string | null; }>this.htmlElement).ariaMultiline;
    }

    public setAriaMultiline(value: string | null): void {
        (<HTMLElement & { ariaMultiline: string | null; }>this.htmlElement).ariaMultiline = value;
    }


    public getAriaMultiSelectable(): string | null {
        return this.htmlElement.ariaMultiSelectable;
    }

    public setAriaMultiSelectable(value: string | null): void {
        this.htmlElement.ariaMultiSelectable = value;
    }


    public getAriaOrientation(): string | null {
        return this.htmlElement.ariaOrientation;
    }

    public setAriaOrientation(value: string | null): void {
        this.htmlElement.ariaOrientation = value;
    }


    public getAriaPlaceholder(): string | null {
        return this.htmlElement.ariaPlaceholder;
    }

    public setAriaPlaceholder(value: string | null): void {
        this.htmlElement.ariaPlaceholder = value;
    }


    public getAriaPosInSet(): string | null {
        return this.htmlElement.ariaPosInSet;
    }

    public setAriaPosInSet(value: string | null): void {
        this.htmlElement.ariaPosInSet = value;
    }


    public getAriaPressed(): string | null {
        return this.htmlElement.ariaPressed;
    }

    public setAriaPressed(value: string | null): void {
        this.htmlElement.ariaPressed = value;
    }


    public getAriaReadOnly(): string | null {
        return this.htmlElement.ariaReadOnly;
    }

    public setAriaReadOnly(value: string | null): void {
        this.htmlElement.ariaReadOnly = value;
    }


    public getAriaRequired(): string | null {
        return this.htmlElement.ariaRequired;
    }

    public setAriaRequired(value: string | null): void {
        this.htmlElement.ariaRequired = value;
    }


    public getAriaRoleDescription(): string | null {
        return this.htmlElement.ariaRoleDescription;
    }

    public setAriaRoleDescription(value: string | null): void {
        this.htmlElement.ariaRoleDescription = value;
    }


    public getAriaRowCount(): string | null {
        return this.htmlElement.ariaRowCount;
    }

    public setAriaRowCount(value: string | null): void {
        this.htmlElement.ariaRowCount = value;
    }


    public getAriaRowIndex(): string | null {
        return this.htmlElement.ariaRowIndex;
    }

    public setAriaRowIndex(value: string | null): void {
        this.htmlElement.ariaRowIndex = value;
    }


    public getAriaRowIndexText(): string | null {
        return (<HTMLElement & { ariaRowIndexText: string | null; }>this.htmlElement).ariaRowIndexText;
    }

    public setAriaRowIndexText(value: string | null): void {
        (<HTMLElement & { ariaRowIndexText: string | null; }>this.htmlElement).ariaRowIndexText = value;
    }


    public getAriaRowSpan(): string | null {
        return this.htmlElement.ariaRowSpan;
    }

    public setAriaRowSpan(value: string | null): void {
        this.htmlElement.ariaRowSpan = value;
    }


    public getAriaSelected(): string | null {
        return this.htmlElement.ariaSelected;
    }

    public setAriaSelected(value: string | null): void {
        this.htmlElement.ariaSelected = value;
    }


    public getAriaSetSize(): string | null {
        return this.htmlElement.ariaSetSize;
    }

    public setAriaSetSize(value: string | null): void {
        this.htmlElement.ariaSetSize = value;
    }


    public getAriaSort(): string | null {
        return this.htmlElement.ariaSort;
    }

    public setAriaSort(value: string | null): void {
        this.htmlElement.ariaSort = value;
    }


    public getAriaValueMax(): string | null {
        return this.htmlElement.ariaValueMax;
    }

    public setAriaValueMax(value: string | null): void {
        this.htmlElement.ariaValueMax = value;
    }


    public getAriaValueMin(): string | null {
        return this.htmlElement.ariaValueMin;
    }

    public setAriaValueMin(value: string | null): void {
        this.htmlElement.ariaValueMin = value;
    }


    public getAriaValueNow(): string | null {
        return this.htmlElement.ariaValueNow;
    }

    public setAriaValueNow(value: string | null): void {
        this.htmlElement.ariaValueNow = value;
    }


    public getAriaValueText(): string | null {
        return this.htmlElement.ariaValueText;
    }

    public setAriaValueText(value: string | null): void {
        this.htmlElement.ariaValueText = value;
    }


    public getRole(): string | null {
        return this.htmlElement.role;
    }

    public setRole(value: string | null): void {
        this.htmlElement.role = value;
    }


    // Node/Element methods

    public checkVisibility(contentVisibilityAuto: boolean, opacityProperty: boolean, visibilityProperty: boolean): boolean {
        return this.htmlElement.checkVisibility(<CheckVisibilityOptions>{ contentVisibilityAuto, opacityProperty, visibilityProperty });
    }

    public computedStyleMap(): Record<string, string> {
        const computedStyleMap = this.htmlElement.computedStyleMap().entries();

        const result: Record<string, string> = {};
        for (const [name, value] of computedStyleMap)
            result[name] = value.toString();
        return result;
    }

    public getBoundingClientRect(): DOMRect {
        return this.htmlElement.getBoundingClientRect();
    }

    public getClientRects(): DOMRect[] {
        return [... this.htmlElement.getClientRects()];
    }

    public matches(selectors: string): boolean {
        return this.htmlElement.matches(selectors);
    }

    public requestFullscreen(navigationUI: "hide" | "show" | "auto" = "auto"): Promise<void> {
        return this.htmlElement.requestFullscreen({ navigationUI });
    }

    public requestPointerLock(unadjustedMovement: boolean): Promise<void> {
        return (<(options: { unadjustedMovement: boolean; }) => Promise<void>><unknown>this.htmlElement.requestPointerLock)({ unadjustedMovement });
    }

    public isDefaultNamespace(namespace: string | null): boolean {
        return this.htmlElement.isDefaultNamespace(namespace);
    }

    public lookupPrefix(namespace: string | null): string | null {
        return this.htmlElement.lookupPrefix(namespace);
    }

    public lookupNamespaceURI(prefix: string | null): string | null {
        return this.htmlElement.lookupNamespaceURI(prefix);
    }

    public normalize(): void {
        this.htmlElement.normalize();
    }


    // Node/Element methods - Pointer Capture

    public setPointerCapture(pointerId: number): void {
        this.htmlElement.setPointerCapture(pointerId);
    }

    public releasePointerCapture(pointerId: number): void {
        this.htmlElement.releasePointerCapture(pointerId);
    }

    public hasPointerCapture(pointerId: number): boolean {
        return this.htmlElement.hasPointerCapture(pointerId);
    }


    // Node/Element methods - Scroll

    public scroll(left: number, top: number, behavior: ScrollBehavior | null): void {
        if (!behavior)
            this.htmlElement.scroll(left, top);
        else
            this.htmlElement.scroll({ left, top, behavior });
    }

    public scrollTo(left: number, top: number, behavior: ScrollBehavior | null): void {
        this.scroll(left, top, behavior);
    }

    public scrollBy(deltaX: number, deltaY: number, behavior: ScrollBehavior | null): void {
        if (!behavior)
            this.htmlElement.scrollBy(deltaX, deltaY);
        else
            this.htmlElement.scrollBy({ left: deltaX, top: deltaY, behavior });
    }

    public scrollIntoView(block: ScrollLogicalPosition = "start", inline: ScrollLogicalPosition = "nearest", behavior: ScrollBehavior = "auto"): void {
        this.htmlElement.scrollIntoView({ block, inline, behavior });
    }


    // Node/Element methods - Attribute

    public getAttribute(qualifiedName: string): string | null {
        return this.htmlElement.getAttribute(qualifiedName);
    }

    public getAttributeNS(namespace: string, qualifiedName: string): string | null {
        return this.htmlElement.getAttributeNS(namespace, qualifiedName);
    }

    public getAttributeNames(): string[] {
        return this.htmlElement.getAttributeNames();
    }

    public setAttribute(qualifiedName: string, value: string): void {
        this.htmlElement.setAttribute(qualifiedName, value);
    }

    public setAttributeNS(namespace: string, qualifiedName: string, value: string): void {
        this.htmlElement.setAttributeNS(namespace, qualifiedName, value);
    }

    public toggleAttribute(qualifiedName: string, force: boolean | null): boolean {
        return this.htmlElement.toggleAttribute(qualifiedName, force ?? undefined);
    }

    public removeAttribute(qualifiedName: string): void {
        this.htmlElement.removeAttribute(qualifiedName);
    }

    public removeAttributeNS(namespace: string, qualifiedName: string): void {
        this.htmlElement.removeAttributeNS(namespace, qualifiedName);
    }

    public hasAttribute(qualifiedName: string): boolean {
        return this.htmlElement.hasAttribute(qualifiedName);
    }

    public hasAttributeNS(namespace: string, qualifiedName: string): boolean {
        return this.htmlElement.hasAttributeNS(namespace, qualifiedName);
    }

    public hasAttributes(): boolean {
        return this.htmlElement.hasAttributes();
    }


    // Node/Element methods - Tree-nodes

    public getElementsByClassName(className: string): HTMLElementAPI[] {
        return [...this.htmlElement.getElementsByClassName(className)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    public getElementsByTagName(qualifiedName: string): HTMLElementAPI[] {
        return [... this.htmlElement.getElementsByTagName(qualifiedName)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    public getElementsByTagNameNS(namespace: string, qualifiedName: string): HTMLElementAPI[] {
        return [... this.htmlElement.getElementsByTagNameNS(namespace, qualifiedName)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    public querySelector(selectors: string): [HTMLElementAPI] | [null] {
        const result = this.htmlElement.querySelector(selectors);
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }

    public querySelectorAll(selectors: string): HTMLElementAPI[] {
        return [... this.htmlElement.querySelectorAll(selectors)].map(element => DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>element)));
    }

    public closest(selectors: string): [HTMLElementAPI] | [null] {
        const result = this.htmlElement.closest(selectors);
        if (result)
            return [DotNet.createJSObjectReference(new HTMLElementAPI(<HTMLElement>result))];
        else
            return [null];
    }


    public before_string(nodes: string[]): void {
        this.htmlElement.before(...nodes);
    }

    public before_htmlElement(nodes: HTMLElementAPI[]): void {
        this.htmlElement.before(...nodes.map(htmlElementAPI => htmlElementAPI.htmlElement));
    }

    public after_string(nodes: string[]): void {
        this.htmlElement.after(...nodes);
    }

    public after_htmlElement(nodes: HTMLElementAPI[]): void {
        this.htmlElement.after(...nodes.map(htmlElementAPI => htmlElementAPI.htmlElement));
    }


    public prepend_string(nodes: string[]): void {
        this.htmlElement.prepend(...nodes);
    }

    public prepend_htmlElement(nodes: HTMLElementAPI[]): void {
        this.htmlElement.prepend(...nodes.map(htmlElementAPI => htmlElementAPI.htmlElement));
    }

    public appendChild(node: HTMLElementAPI): void {
        this.htmlElement.appendChild(node.htmlElement);
    }

    public append_string(nodes: string[]): void {
        this.htmlElement.append(...nodes);
    }

    public append_htmlElement(nodes: HTMLElementAPI[]): void {
        this.htmlElement.append(...nodes.map(htmlElementAPI => htmlElementAPI.htmlElement));
    }

    public insertAdjacentElement(position: InsertPosition, htmlElement: HTMLElementAPI): boolean {
        const result = this.htmlElement.insertAdjacentElement(position, htmlElement.htmlElement);
        if (result)
            return true;
        else
            return false;
    }

    public insertAdjacentHTML(position: InsertPosition, html: string): void {
        this.htmlElement.insertAdjacentHTML(position, html);
    }

    public insertAdjacentText(position: InsertPosition, data: string): void {
        this.htmlElement.insertAdjacentText(position, data);
    }


    public removeChild(node: HTMLElementAPI): void {
        this.htmlElement.removeChild(node.htmlElement);
    }

    public remove(): void {
        this.htmlElement.remove();
    }

    public replaceChild(newChild: HTMLElementAPI, oldChild: HTMLElementAPI): void {
        this.htmlElement.replaceChild(newChild.htmlElement, oldChild.htmlElement);
    }

    public replaceChildIndex(newChild: HTMLElementAPI, oldChildIndex: number): void {
        this.htmlElement.replaceChild(newChild.htmlElement, this.htmlElement.children[oldChildIndex]);
    }

    public replaceWith_string(nodes: string[]): void {
        this.htmlElement.replaceWith(...nodes);
    }

    public replaceWith_htmlElement(nodes: HTMLElementAPI[]): void {
        this.htmlElement.replaceWith(...nodes.map(htmlElementAPI => htmlElementAPI.htmlElement));
    }

    public replaceChildren_string(nodes: string[]): void {
        this.htmlElement.replaceChildren(...nodes);
    }

    public replaceChildren_htmlElement(nodes: HTMLElementAPI[]): void {
        this.htmlElement.replaceChildren(...nodes.map(htmlElementAPI => htmlElementAPI.htmlElement));
    }


    public cloneNode(deep: boolean): HTMLElementAPI {
        const result = this.htmlElement.cloneNode(deep);
        return new HTMLElementAPI(<HTMLElement>result);
    }

    public isSameNode(other: HTMLElementAPI): boolean {
        return this.htmlElement.isSameNode(other.htmlElement);
    }

    public isEqualNode(other: HTMLElementAPI): boolean {
        return this.htmlElement.isEqualNode(other.htmlElement);
    }

    public contains(other: HTMLElementAPI): boolean {
        return this.htmlElement.contains(other.htmlElement);
    }

    public compareDocumentPosition(other: HTMLElementAPI): number {
        return this.htmlElement.compareDocumentPosition(other.htmlElement);
    }


    // events


    private eventTrigger: DotNet.DotNetObject;

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
    private static deconstructTouchList(touchList: TouchList): { identifier: number, clientX: number, clientY: number, pageX: number, pageY: number, screenX: number, screenY: number, radiusX: number, radiusY: number, rotationAngle: number, force: number }[] {
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

    private onchange = () => BlazorInvoke.method(this.eventTrigger, "InvokeChange");

    public activateOnchange(): void {
        this.htmlElement.addEventListener("change", this.onchange);
    }

    public deactivateOnchange(): void {
        this.htmlElement.removeEventListener("change", this.onchange);
    }


    // HTMLElement - command event

    private oncommand = (commandEvent: { source: HTMLButtonElement, command: string }) => BlazorInvoke.method(this.eventTrigger, "InvokeCommand", DotNet.createJSObjectReference(new HTMLElementAPI(commandEvent.source)), commandEvent.command);

    public activateOncommand(): void {
        this.htmlElement.addEventListener("command", <(commandEvent: Event) => void><unknown>this.oncommand);
    }

    public deactivateOncommand(): void {
        this.htmlElement.removeEventListener("command", <(commandEvent: Event) => void><unknown>this.oncommand);
    }


    // HTMLElement - load event

    private onload = () => BlazorInvoke.method(this.eventTrigger, "InvokeLoad");

    public activateOnload(): void {
        this.htmlElement.addEventListener("load", this.onload);
    }

    public deactivateOnload(): void {
        this.htmlElement.removeEventListener("load", this.onload);
    }


    // HTMLElement - error event

    private onerror = (error: Event) => BlazorInvoke.method(this.eventTrigger, "InvokeError", error);

    public activateOnerror(): void {
        this.htmlElement.addEventListener("error", this.onerror);
    }

    public deactivateOnerror(): void {
        this.htmlElement.removeEventListener("error", this.onerror);
    }


    // HTMLElement - drag event

    private ondrag = (dragEvent: DragEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDrag", ... HTMLElementAPI.deconstructDataTransfer(dragEvent.dataTransfer));

    public activateOndrag(): void {
        this.htmlElement.addEventListener("drag", this.ondrag);
    }

    public deactivateOndrag(): void {
        this.htmlElement.removeEventListener("drag", this.ondrag);
    }


    // HTMLElement - dragstart event

    private ondragstart = (dragEvent: DragEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDragStart", ...HTMLElementAPI.deconstructDataTransfer(dragEvent.dataTransfer));

    public activateOndragstart(): void {
        this.htmlElement.addEventListener("dragstart", this.ondragstart);
    }

    public deactivateOndragstart(): void {
        this.htmlElement.removeEventListener("dragstart", this.ondragstart);
    }


    // HTMLElement - dragend event

    private ondragend = (dragEvent: DragEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDragEnd", ...HTMLElementAPI.deconstructDataTransfer(dragEvent.dataTransfer));

    public activateOndragend(): void {
        this.htmlElement.addEventListener("dragend", this.ondragend);
    }

    public deactivateOndragend(): void {
        this.htmlElement.removeEventListener("dragend", this.ondragend);
    }


    // HTMLElement - dragenter event

    private ondragenter = (dragEvent: DragEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDragEnter", ...HTMLElementAPI.deconstructDataTransfer(dragEvent.dataTransfer));

    public activateOndragenter(): void {
        this.htmlElement.addEventListener("dragenter", this.ondragenter);
    }

    public deactivateOndragenter(): void {
        this.htmlElement.removeEventListener("dragenter", this.ondragenter);
    }


    // HTMLElement - dragleave event

    private ondragleave = (dragEvent: DragEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDragLeave", ...HTMLElementAPI.deconstructDataTransfer(dragEvent.dataTransfer));

    public activateOndragleave(): void {
        this.htmlElement.addEventListener("dragleave", this.ondragleave);
    }

    public deactivateOndragleave(): void {
        this.htmlElement.removeEventListener("dragleave", this.ondragleave);
    }


    // HTMLElement - dragover event

    private ondragover = (dragEvent: DragEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDragOver", ...HTMLElementAPI.deconstructDataTransfer(dragEvent.dataTransfer));

    public activateOndragover(): void {
        this.htmlElement.addEventListener("dragover", this.ondragover);
    }

    public deactivateOndragover(): void {
        this.htmlElement.removeEventListener("dragover", this.ondragover);
    }


    // HTMLElement - drop event

    private ondrop = (dragEvent: DragEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeDrop", ...HTMLElementAPI.deconstructDataTransfer(dragEvent.dataTransfer));

    public activateOndrop(): void {
        this.htmlElement.addEventListener("drop", this.ondrop);
    }

    public deactivateOndrop(): void {
        this.htmlElement.removeEventListener("drop", this.ondrop);
    }


    // HTMLElement - toggle

    private ontoggle = (toggleEvent: ToggleEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeToggle", toggleEvent.oldState, toggleEvent.newState);

    public activateOntoggle(): void {
        this.htmlElement.addEventListener("toggle", this.ontoggle);
    }

    public deactivateOntoggle(): void {
        this.htmlElement.removeEventListener("toggle", this.ontoggle);
    }


    // HTMLElement - beforetoggle

    private onbeforetoggle = (toggleEvent: ToggleEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeBeforeToggle", toggleEvent.oldState, toggleEvent.newState);

    public activateOnbeforetoggle(): void {
        this.htmlElement.addEventListener("beforetoggle", this.onbeforetoggle);
    }

    public deactivateOnbeforetoggle(): void {
        this.htmlElement.removeEventListener("beforetoggle", this.onbeforetoggle);
    }



    // Element - input event

    private oninput = (inputEvent: InputEvent | Event) => BlazorInvoke.method(this.eventTrigger, "InvokeInput", ...HTMLElementAPI.deconstructInputEvent(inputEvent));

    public activateOninput(): void {
        this.htmlElement.addEventListener("input", this.oninput);
    }

    public deactivateOninput(): void {
        this.htmlElement.removeEventListener("input", this.oninput);
    }


    // Element - beforeinput event

    private onbeforeinput = (inputEvent: InputEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeBeforeInput", ...HTMLElementAPI.deconstructInputEvent(inputEvent));

    public activateOnbeforeinput(): void {
        this.htmlElement.addEventListener("beforeinput", this.onbeforeinput);
    }

    public deactivateOnbeforeinput(): void {
        this.htmlElement.removeEventListener("beforeinput", this.onbeforeinput);
    }


    // Element - contentvisibilityautostatechange event

    private oncontentvisibilityautostatechange = (event: { skipped: boolean; }) => BlazorInvoke.method(this.eventTrigger, "InvokeContentVisibilityAutoStateChange", event.skipped);

    public activateOncontentvisibilityautostatechange(): void {
        this.htmlElement.addEventListener("contentvisibilityautostatechange", <() => {}>this.oncontentvisibilityautostatechange);
    }

    public deactivateOncontentvisibilityautostatechange(): void {
        this.htmlElement.removeEventListener("contentvisibilityautostatechange", <() => {}>this.oncontentvisibilityautostatechange);
    }


    // Element - beforematch event

    private onbeforematch = () => BlazorInvoke.method(this.eventTrigger, "InvokeBeforeMatch");

    public activateOnbeforematch(): void {
        this.htmlElement.addEventListener("beforematch", this.onbeforematch);
    }

    public deactivateOnbeforematch(): void {
        this.htmlElement.removeEventListener("beforematch", this.onbeforematch);
    }


    // Element - securitypolicyviolation event

    private onsecuritypolicyviolation = (violationEvent: SecurityPolicyViolationEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeSecurityPolicyViolation", {
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

    public activateOnsecuritypolicyviolation(): void {
        this.htmlElement.addEventListener("securitypolicyviolation", this.onsecuritypolicyviolation);
    }

    public deactivateOnsecuritypolicyviolation(): void {
        this.htmlElement.removeEventListener("securitypolicyviolation", this.onsecuritypolicyviolation);
    }


    // Node - selectstart event

    private onselectstart = () => BlazorInvoke.method(this.eventTrigger, "InvokeSelectStart");

    public activateOnselectstart(): void {
        this.htmlElement.addEventListener("selectstart", this.onselectstart);
    }

    public deactivateOnselectstart(): void {
        this.htmlElement.removeEventListener("selectstart", this.onselectstart);
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
        this.htmlElement.addEventListener("keydown", this.onkeydown);
    }

    public deactivateOnkeydown(): void {
        this.htmlElement.removeEventListener("keydown", this.onkeydown);
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
        this.htmlElement.addEventListener("keyup", this.onkeyup);
    }

    public deactivateOnkeyup(): void {
        this.htmlElement.removeEventListener("keyup", this.onkeyup);
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
        this.htmlElement.addEventListener("click", this.onclick);
    }

    public deactivateOnclick(): void {
        this.htmlElement.removeEventListener("click", this.onclick);
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
        this.htmlElement.addEventListener("dblclick", this.ondblclick);
    }

    public deactivateOndblclick(): void {
        this.htmlElement.removeEventListener("dblclick", this.ondblclick);
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
        this.htmlElement.addEventListener("auxclick", this.onauxclick);
    }

    public deactivateOnauxclick(): void {
        this.htmlElement.removeEventListener("auxclick", this.onauxclick);
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
        this.htmlElement.addEventListener("contextmenu", this.oncontextmenu);
    }

    public deactivateOncontextmenu(): void {
        this.htmlElement.removeEventListener("contextmenu", this.oncontextmenu);
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
        this.htmlElement.addEventListener("mousedown", this.onmousedown);
    }

    public deactivateOnmousedown(): void {
        this.htmlElement.removeEventListener("mousedown", this.onmousedown);
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
        this.htmlElement.addEventListener("mouseup", this.onmouseup);
    }

    public deactivateOnmouseup(): void {
        this.htmlElement.removeEventListener("mouseup", this.onmouseup);
    }


    // Element - wheel event

    private onwheel = (wheelEvent: WheelEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeWheel", {
        deltaX: wheelEvent.deltaX,
        deltaY: wheelEvent.deltaY,
        deltaZ: wheelEvent.deltaZ,
        deltaMode: wheelEvent.deltaMode
    });

    public activateOnwheel(): void {
        this.htmlElement.addEventListener("wheel", this.onwheel, { passive: true });
    }

    public deactivateOnwheel(): void {
        this.htmlElement.removeEventListener("wheel", this.onwheel);
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
        this.htmlElement.addEventListener("mousemove", this.onmousemove);
    }

    public deactivateOnmousemove(): void {
        this.htmlElement.removeEventListener("mousemove", this.onmousemove);
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
        this.htmlElement.addEventListener("mouseover", this.onmouseover);
    }

    public deactivateOnmouseover(): void {
        this.htmlElement.removeEventListener("mouseover", this.onmouseover);
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
        this.htmlElement.addEventListener("mouseout", this.onmouseout);
    }

    public deactivateOnmouseout(): void {
        this.htmlElement.removeEventListener("mouseout", this.onmouseout);
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
        this.htmlElement.addEventListener("mouseenter", this.onmouseenter);
    }

    public deactivateOnmouseenter(): void {
        this.htmlElement.removeEventListener("mouseenter", this.onmouseenter);
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
        this.htmlElement.addEventListener("mouseleave", this.onmouseleave);
    }

    public deactivateOnmouseleave(): void {
        this.htmlElement.removeEventListener("mouseleave", this.onmouseleave);
    }



    // Element - touchstart event

    private ontouchstart = (touchEvent: TouchEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTouchStart", {
        touches: HTMLElementAPI.deconstructTouchList(touchEvent.touches),
        targetTouches: HTMLElementAPI.deconstructTouchList(touchEvent.targetTouches),
        changedTouches: HTMLElementAPI.deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    public activateOntouchstart(): void {
        this.htmlElement.addEventListener("touchstart", this.ontouchstart);
    }

    public deactivateOntouchstart(): void {
        this.htmlElement.removeEventListener("touchstart", this.ontouchstart);
    }


    // Element - touchend event

    private ontouchend = (touchEvent: TouchEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTouchEnd", {
        touches: HTMLElementAPI.deconstructTouchList(touchEvent.touches),
        targetTouches: HTMLElementAPI.deconstructTouchList(touchEvent.targetTouches),
        changedTouches: HTMLElementAPI.deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    public activateOntouchend(): void {
        this.htmlElement.addEventListener("touchend", this.ontouchend);
    }

    public deactivateOntouchend(): void {
        this.htmlElement.removeEventListener("touchend", this.ontouchend);
    }


    // Element - touchmove event

    private ontouchmove = (touchEvent: TouchEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTouchMove", {
        touches: HTMLElementAPI.deconstructTouchList(touchEvent.touches),
        targetTouches: HTMLElementAPI.deconstructTouchList(touchEvent.targetTouches),
        changedTouches: HTMLElementAPI.deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    public activateOntouchmove(): void {
        this.htmlElement.addEventListener("touchmove", this.ontouchmove);
    }

    public deactivateOntouchmove(): void {
        this.htmlElement.removeEventListener("touchmove", this.ontouchmove);
    }


    // Element - touchcancel event

    private ontouchcancel = (touchEvent: TouchEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTouchCancel", {
        touches: HTMLElementAPI.deconstructTouchList(touchEvent.touches),
        targetTouches: HTMLElementAPI.deconstructTouchList(touchEvent.targetTouches),
        changedTouches: HTMLElementAPI.deconstructTouchList(touchEvent.changedTouches),
        ctrlKey: touchEvent.ctrlKey,
        shiftKey: touchEvent.shiftKey,
        altKey: touchEvent.altKey,
        metaKey: touchEvent.metaKey
    });

    public activateOntouchcancel(): void {
        this.htmlElement.addEventListener("touchcancel", this.ontouchcancel);
    }

    public deactivateOntouchcancel(): void {
        this.htmlElement.removeEventListener("touchcancel", this.ontouchcancel);
    }



    // Element - pointerdown event

    private onpointerdown = (pointerEvent: PointerEvent & { persistentDeviceId: number | undefined, altitudeAngle: number, azimuthAngle: number }) => BlazorInvoke.method(this.eventTrigger, "InvokePointerDown", {
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
        this.htmlElement.addEventListener("pointerdown", this.onpointerdown);
    }

    public deactivateOnpointerdown(): void {
        this.htmlElement.removeEventListener("pointerdown", this.onpointerdown);
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
        this.htmlElement.addEventListener("pointerup", this.onpointerup);
    }

    public deactivateOnpointerup(): void {
        this.htmlElement.removeEventListener("pointerup", this.onpointerup);
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
        this.htmlElement.addEventListener("pointermove", this.onpointermove);
    }

    public deactivateOnpointermove(): void {
        this.htmlElement.removeEventListener("pointermove", this.onpointermove);
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
        this.htmlElement.addEventListener("pointerover", this.onpointerover);
    }

    public deactivateOnpointerover(): void {
        this.htmlElement.removeEventListener("pointerover", this.onpointerover);
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
        this.htmlElement.addEventListener("pointerout", this.onpointerout);
    }

    public deactivateOnpointerout(): void {
        this.htmlElement.removeEventListener("pointerout", this.onpointerout);
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
        this.htmlElement.addEventListener("pointerenter", this.onpointerenter);
    }

    public deactivateOnpointerenter(): void {
        this.htmlElement.removeEventListener("pointerenter", this.onpointerenter);
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
        this.htmlElement.addEventListener("pointerleave", this.onpointerleave);
    }

    public deactivateOnpointerleave(): void {
        this.htmlElement.removeEventListener("pointerleave", this.onpointerleave);
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
        this.htmlElement.addEventListener("pointercancel", this.onpointercancel);
    }

    public deactivateOnpointercancel(): void {
        this.htmlElement.removeEventListener("pointercancel", this.onpointercancel);
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
        this.htmlElement.addEventListener("pointerrawupdate", this.onpointerrawupdate);
    }

    public deactivateOnpointerrawupdate(): void {
        this.htmlElement.removeEventListener("pointerrawupdate", this.onpointerrawupdate);
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
        this.htmlElement.addEventListener("gotpointercapture", this.ongotpointercapture);
    }

    public deactivateOngotpointercapture(): void {
        this.htmlElement.removeEventListener("gotpointercapture", this.ongotpointercapture);
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
        this.htmlElement.addEventListener("lostpointercapture", this.onlostpointercapture);
    }

    public deactivateOnlostpointercapture(): void {
        this.htmlElement.removeEventListener("lostpointercapture", this.onlostpointercapture);
    }



    // Element - scroll event

    private onscroll = () => BlazorInvoke.method(this.eventTrigger, "InvokeScroll");

    public activateOnscroll(): void {
        this.htmlElement.addEventListener("scroll", this.onscroll);
    }

    public deactivateOnscroll(): void {
        this.htmlElement.removeEventListener("scroll", this.onscroll);
    }


    // Element - scrollend event

    private onscrollend = () => BlazorInvoke.method(this.eventTrigger, "InvokeScrollEnd");

    public activateOnscrollend(): void {
        this.htmlElement.addEventListener("scrollend", this.onscrollend);
    }

    public deactivateOnscrollend(): void {
        this.htmlElement.removeEventListener("scrollend", this.onscrollend);
    }



    // Element - focus event

    private onfocus = () => BlazorInvoke.method(this.eventTrigger, "InvokeFocus");

    public activateOnfocus(): void {
        this.htmlElement.addEventListener("focus", this.onfocus);
    }

    public deactivateOnfocus(): void {
        this.htmlElement.removeEventListener("focus", this.onfocus);
    }


    // Element - focusin event

    private onfocusin = () => BlazorInvoke.method(this.eventTrigger, "InvokeFocusIn");

    public activateOnfocusin(): void {
        this.htmlElement.addEventListener("focusin", this.onfocusin);
    }

    public deactivateOnfocusin(): void {
        this.htmlElement.removeEventListener("focusin", this.onfocusin);
    }


    // Element - blur event

    private onblur = () => BlazorInvoke.method(this.eventTrigger, "InvokeBlur");

    public activateOnblur(): void {
        this.htmlElement.addEventListener("blur", this.onblur);
    }

    public deactivateOnblur(): void {
        this.htmlElement.removeEventListener("blur", this.onblur);
    }


    // Element - focusout event

    private onfocusout = () => BlazorInvoke.method(this.eventTrigger, "InvokeFocusOut");

    public activateOnfocusout(): void {
        this.htmlElement.addEventListener("focusout", this.onfocusout);
    }

    public deactivateOnfocusout(): void {
        this.htmlElement.removeEventListener("focusout", this.onfocusout);
    }



    // Element - copy event

    private oncopy = () => BlazorInvoke.method(this.eventTrigger, "InvokeCopy");

    public activateOncopy(): void {
        this.htmlElement.addEventListener("copy", this.oncopy);
    }

    public deactivateOncopy(): void {
        this.htmlElement.removeEventListener("copy", this.oncopy);
    }


    // Element - paste event

    private onpaste = () => BlazorInvoke.method(this.eventTrigger, "InvokePaste");

    public activateOnpaste(): void {
        this.htmlElement.addEventListener("paste", this.onpaste);
    }

    public deactivateOnpaste(): void {
        this.htmlElement.removeEventListener("paste", this.onpaste);
    }


    // Element - cut event

    private oncut = () => BlazorInvoke.method(this.eventTrigger, "InvokeCut");

    public activateOncut(): void {
        this.htmlElement.addEventListener("cut", this.oncut);
    }

    public deactivateOncut(): void {
        this.htmlElement.removeEventListener("cut", this.oncut);
    }



    // Element - transitionstart event

    private ontransitionstart = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTransitionStart", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    public activateOntransitionstart(): void {
        this.htmlElement.addEventListener("transitionstart", this.ontransitionstart);
    }

    public deactivateOntransitionstart(): void {
        this.htmlElement.removeEventListener("transitionstart", this.ontransitionstart);
    }


    // Element - transitionend event

    private ontransitionend = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTransitionEnd", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)

    public activateOntransitionend(): void {
        this.htmlElement.addEventListener("transitionend", this.ontransitionend);
    }

    public deactivateOntransitionend(): void {
        this.htmlElement.removeEventListener("transitionend", this.ontransitionend);
    }


    // Element - transitionrun event

    private ontransitionrun = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTransitionRun", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)

    public activateOntransitionrun(): void {
        this.htmlElement.addEventListener("transitionrun", this.ontransitionrun);
    }

    public deactivateOntransitionrun(): void {
        this.htmlElement.removeEventListener("transitionrun", this.ontransitionrun);
    }


    // Element - transitioncancel event

    private ontransitioncancel = (transitionEvent: TransitionEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeTransitionCancel", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)

    public activateOntransitioncancel(): void {
        this.htmlElement.addEventListener("transitioncancel", this.ontransitioncancel);
    }

    public deactivateOntransitioncancel(): void {
        this.htmlElement.removeEventListener("transitioncancel", this.ontransitioncancel);
    }



    // Element - animationstart event

    private onanimationstart = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeAnimationStart", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)

    public activateOnanimationstart(): void {
        this.htmlElement.addEventListener("animationstart", this.onanimationstart);
    }

    public deactivateOnanimationstart(): void {
        this.htmlElement.removeEventListener("animationstart", this.onanimationstart);
    }


    // Element - animationend event

    private onanimationend = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeAnimationEnd", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)

    public activateOnanimationend(): void {
        this.htmlElement.addEventListener("animationend", this.onanimationend);
    }

    public deactivateOnanimationend(): void {
        this.htmlElement.removeEventListener("animationend", this.onanimationend);
    }


    // Element - animationiteration event

    private onanimationiteration = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeAnimationIteration", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)

    public activateOnanimationiteration(): void {
        this.htmlElement.addEventListener("animationiteration", this.onanimationiteration);
    }

    public deactivateOnanimationiteration(): void {
        this.htmlElement.removeEventListener("animationiteration", this.onanimationiteration);
    }


    // Element - animationcancel event

    private onanimationcancel = (animationEvent: AnimationEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeAnimationCancel", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)

    public activateOnanimationcancel(): void {
        this.htmlElement.addEventListener("animationcancel", this.onanimationcancel);
    }

    public deactivateOnanimationcancel(): void {
        this.htmlElement.removeEventListener("animationcancel", this.onanimationcancel);
    }



    // Element - fullscreenchange event

    private onfullscreenchange = () => BlazorInvoke.method(this.eventTrigger, "InvokeFullscreenChange");

    public activateOnfullscreenchange(): void {
        this.htmlElement.addEventListener("fullscreenchange", this.onfullscreenchange);
    }

    public deactivateOnfullscreenchange(): void {
        this.htmlElement.removeEventListener("fullscreenchange", this.onfullscreenchange);
    }


    // Element - fullscreenerror event

    private onfullscreenerror = () => BlazorInvoke.method(this.eventTrigger, "InvokeFullscreenError");

    public activateOnfullscreenerror(): void {
        this.htmlElement.addEventListener("fullscreenerror", this.onfullscreenerror);
    }

    public deactivateOnfullscreenerror(): void {
        this.htmlElement.removeEventListener("fullscreenerror", this.onfullscreenerror);
    }
}
