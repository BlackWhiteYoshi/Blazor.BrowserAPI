import { HTMLElementAPI } from "../HTMLElement/HTMLElement";

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


    // methods



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





    // TODO event selectstart
}
