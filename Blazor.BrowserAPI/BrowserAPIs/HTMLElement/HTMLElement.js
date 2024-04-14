import { DotNet } from "../blazor";


/**
 * @param {HTMLElement} htmlElement
 * @returns {HTMLElementWrapper}
 */
export function createHTMLElement(htmlElement) {
    return new HTMLElementWrapper(htmlElement);
}


export class HTMLElementWrapper {
    /** @type {HTMLElement} */
    #htmlElement;

    /**
     * @param {HTMLElement} htmlElement
     */
    constructor(htmlElement) {
        this.#htmlElement = htmlElement;
    }


    // HTMLElement

    /**
     * @returns {string}
     */
    getInnerText() {
        return this.#htmlElement.innerText;
    }

    /**
     * @param {string} value
     */
    setInnerText(value) {
        this.#htmlElement.innerText = value;
    }

    /**
     * @returns {string}
     */
    getOuterText() {
        return this.#htmlElement.outerText;
    }

    /**
     * @param {string} value
     */
    setOuterText(value) {
        this.#htmlElement.outerText = value;
    }

    /**
     * @returns {string}
     */
    getInlineStyle() {
        return this.#htmlElement.style.cssText;
    }

    /**
     * @param {string} value
     */
    setInlineStyle(value) {
        this.#htmlElement.style.cssText = value;
    }


    /**
     * @returns {number}
     */
    getOffsetWidth() {
        return this.#htmlElement.offsetWidth;
    }

    /**
     * @returns {number}
     */
    getOffsetHeight() {
        return this.#htmlElement.offsetHeight;
    }

    /**
     * @returns {number}
     */
    getOffsetLeft() {
        return this.#htmlElement.offsetLeft;
    }

    /**
     * @returns {number}
     */
    getOffsetTop() {
        return this.#htmlElement.offsetTop;
    }

    /**
     * @returns {Element | null}
     */
    getOffsetParent() {
        return this.#htmlElement.offsetParent;
    }


    /**
     * @returns {boolean}
     */
    hasFocus() {
        return this.#htmlElement === document.activeElement;
    }


    /**
     */
    click() {
        this.#htmlElement.click();
    }

    /**
     * @param {boolean} [preventScroll]
     */
    focus(preventScroll = false) {
        this.#htmlElement.focus({ preventScroll });
    }

    /**
     */
    blur() {
        this.#htmlElement.blur();
    }

    /**
     */
    showPopover() {
        this.#htmlElement.showPopover();
    }

    /**
     */
    hidePopover() {
        this.#htmlElement.hidePopover();
    }

    /**
     * @param {boolean} [force]
     * @returns {boolean}
     */
    togglePopover(force) {
        return /** @type {boolean} */ (/** @type {unknown} */ (this.#htmlElement.togglePopover(force)));
    }


    // Element


    /**
     * @returns {string}
     */
    getInnerHTML() {
        return this.#htmlElement.innerHTML;
    }

    /**
     * @param {string} value
     */
    setInnerHTML(value) {
        this.#htmlElement.innerHTML = value;
    }

    /**
     * @returns {string}
     */
    getOuterHTML() {
        return this.#htmlElement.outerHTML;
    }

    /**
     * @param {string} value
     */
    setOuterHTML(value) {
        this.#htmlElement.outerHTML = value;
    }

    /**
     * returns something like { "key1": "value1", "key2": "value2", "key3": "value3", ... }
     * @returns {any}
     */
    getAttributes() {
        const attributes = this.#htmlElement.attributes;

        let result = {};
        for (let i = 0; i < attributes.length; i++)
            Object.assign(result, { [attributes[i].name]: attributes[i].value });

        return result;
    }

    /**
     * @returns {number}
     */
    getChildElementCount() {
        return this.#htmlElement.childElementCount;
    }

    /**
     * returns something like JSObjectReference<HTMLElement>[]
     * @returns {any[]}
     */
    getChildren() {
        return [... this.#htmlElement.children].map((/** @type {HTMLElement} */ child) => DotNet.createJSObjectReference(createHTMLElement(child)));
    }

    /**
     * @returns {string}
     */
    getClassName() {
        return this.#htmlElement.className;
    }

    /**
     * @param {string} value
     */
    setClassName(value) {
        this.#htmlElement.className = value;
    }

    /**
     * @returns {string[]}
     */
    getClassList() {
        return [... this.#htmlElement.classList];
    }


    /**
     * @returns {number}
     */
    getClientWidth() {
        return this.#htmlElement.clientWidth;
    }

    /**
     * @returns {number}
     */
    getClientHeight() {
        return this.#htmlElement.clientHeight;
    }

    /**
     * @returns {number}
     */
    getClientLeft() {
        return this.#htmlElement.clientLeft;
    }

    /**
     * @returns {number}
     */
    getClientTop() {
        return this.#htmlElement.clientTop;
    }


    /**
     * @returns {number}
     */
    getScrollWidth() {
        return this.#htmlElement.scrollWidth;
    }

    /**
     * @returns {number}
     */
    getScrollHeight() {
        return this.#htmlElement.scrollHeight;
    }

    /**
     * @returns {number}
     */
    getScrollLeft() {
        return this.#htmlElement.scrollLeft;
    }

    /**
     * @param {number} value
     */
    setScrollLeft(value) {
        this.#htmlElement.scrollLeft = value;
    }

    /**
     * @returns {number}
     */
    getScrollTop() {
        return this.#htmlElement.scrollTop;
    }

    /**
     * @param {number} value
     */
    setScrollTop(value) {
        this.#htmlElement.scrollTop = value;
    }


    /**
     * @returns {DOMRect}
     */
    getBoundingClientRect() {
        return this.#htmlElement.getBoundingClientRect();
    }

    /**
     * @returns {DOMRect[]}
     */
    getClientRects() {
        return [... this.#htmlElement.getClientRects()];
    }


    /**
     * @param {string} name
     * @returns {boolean}
     */
    hasAttribute(name) {
        return this.#htmlElement.hasAttribute(name);
    }

    /**
     * @returns {boolean}
     */
    hasAttributes() {
        return this.#htmlElement.hasAttributes();
    }


    /**
     * @param {number} pointerId
     */
    setPointerCapture(pointerId) {
        this.#htmlElement.setPointerCapture(pointerId);
    }

    /**
     * @param {number} pointerId
     */
    releasePointerCapture(pointerId) {
        this.#htmlElement.releasePointerCapture(pointerId);
    }

    /**
     * @param {number} pointerId
     * @returns {boolean}
     */
    hasPointerCapture(pointerId) {
        return this.#htmlElement.hasPointerCapture(pointerId);
    }


    /**
     * @param {number} left
     * @param {number} top
     */
    scroll(left, top) {
        this.#htmlElement.scroll(left, top);
    }

    /**
     * @param {number} x
     * @param {number} y
     */
    scrollBy(x, y) {
        this.#htmlElement.scrollBy(x, y);
    }

    /**
     * @param {"start" | "center" | "end" | "nearest"} [block]
     * @param {"start" | "center" | "end" | "nearest"} [inline]
     * @param {"instant" | "smooth" | "auto"} [behavior]
     */
    scrollIntoView(block = "start", inline = "nearest", behavior = "auto") {
        this.#htmlElement.scrollIntoView({ block, inline, behavior });
    }


    /**
     * @param {"hide" | "show" | "auto"} navigationUI
     * @returns {Promise<void>}
     */
    requestFullscreen(navigationUI = "auto") {
        return this.#htmlElement.requestFullscreen({ navigationUI });
    }



    // events

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} animationstartTrigger
     */
    activateOnanimationstart(animationstartTrigger) {
        this.#htmlElement.onanimationstart = (animationEvent) => animationstartTrigger.invokeMethodAsync("Trigger", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);
    }

    /**
     */
    deactivateOnanimationstart() {
        this.#htmlElement.onanimationstart = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} animationendTrigger
     */
    activateOnanimationend(animationendTrigger) {
        this.#htmlElement.onanimationend = (animationEvent) => animationendTrigger.invokeMethodAsync("Trigger", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);
    }

    /**
     */
    deactivateOnanimationend() {
        this.#htmlElement.onanimationend = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} animationiterationTrigger
     */
    activateOnanimationiteration(animationiterationTrigger) {
        this.#htmlElement.onanimationiteration = (animationEvent) => animationiterationTrigger.invokeMethodAsync("Trigger", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);
    }

    /**
     */
    deactivateOnanimationiteration() {
        this.#htmlElement.onanimationiteration = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} animationcancelTrigger
     */
    activateOnanimationcancel(animationcancelTrigger) {
        this.#htmlElement.onanimationcancel = (animationEvent) => animationcancelTrigger.invokeMethodAsync("Trigger", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);
    }

    /**
     */
    deactivateOnanimationcancel() {
        this.#htmlElement.onanimationcancel = null;
    }


    /**
     * @param {import("../../blazor").DotNet.DotNetObject} transitionstartTrigger
     */
    activateOntransitionstart(transitionstartTrigger) {
        this.#htmlElement.ontransitionstart = (transitionEvent) => transitionstartTrigger.invokeMethodAsync("Trigger", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);
    }

    /**
     */
    deactivateOntransitionstart() {
        this.#htmlElement.ontransitionstart = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} transitionendTrigger
     */
    activateOntransitionend(transitionendTrigger) {
        this.#htmlElement.ontransitionend = (transitionEvent) => transitionendTrigger.invokeMethodAsync("Trigger", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);
    }

    /**
     */
    deactivateOntransitionend() {
        this.#htmlElement.ontransitionend = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} transitionrunTrigger
     */
    activateOntransitionrun(transitionrunTrigger) {
        this.#htmlElement.ontransitionrun = (transitionEvent) => transitionrunTrigger.invokeMethodAsync("Trigger", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);
    }

    /**
     */
    deactivateOntransitionrun() {
        this.#htmlElement.ontransitionrun = null;
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} transitioncancelTrigger
     */
    activateOntransitioncancel(transitioncancelTrigger) {
        this.#htmlElement.ontransitioncancel = (transitionEvent) => transitioncancelTrigger.invokeMethodAsync("Trigger", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);
    }

    /**
     */
    deactivateOntransitioncancel() {
        this.#htmlElement.ontransitioncancel = null;
    }
}
