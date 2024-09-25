import { DotNet } from "../../blazor";


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

    /** @type {import("../../blazor").DotNet.DotNetObject} */
    #eventTrigger;

    /** @type {boolean} */
    #isEventTriggerSync;


    // #region transitionstart event

    /**
     * @param {TransitionEvent} transitionEvent
     */
    #ontransitionstartCallback = (transitionEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeTransitionstart", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeTransitionstart", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOntransitionstart(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlElement.addEventListener("transitionstart", this.#ontransitionstartCallback);
    }

    /**
     */
    deactivateOntransitionstart() {
        this.#htmlElement.removeEventListener("transitionstart", this.#ontransitionstartCallback);
    }

    // #endregion


    // #region transitionend event

    /**
     * @param {TransitionEvent} transitionEvent
     */
    #ontransitionendCallback = (transitionEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeTransitionend", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeTransitionend", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOntransitionend(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlElement.addEventListener("transitionend", this.#ontransitionendCallback);
    }

    /**
     */
    deactivateOntransitionend() {
        this.#htmlElement.removeEventListener("transitionend", this.#ontransitionendCallback);
    }

    // #endregion


    // #region transitionrun event

    /**
     * @param {TransitionEvent} transitionEvent
     */
    #ontransitionrunCallback = (transitionEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeTransitionrun", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeTransitionrun", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOntransitionrun(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlElement.addEventListener("transitionrun", this.#ontransitionrunCallback);
    }

    /**
     */
    deactivateOntransitionrun() {
        this.#htmlElement.removeEventListener("transitionrun", this.#ontransitionrunCallback);
    }

    // #endregion


    // #region transitioncancel event

    /**
     * @param {TransitionEvent} transitionEvent
     */
    #ontransitioncancelCallback = (transitionEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeTransitioncancel", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeTransitioncancel", transitionEvent.propertyName, transitionEvent.elapsedTime, transitionEvent.pseudoElement);

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOntransitioncancel(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlElement.addEventListener("transitioncancel", this.#ontransitioncancelCallback);
    }

    /**
     */
    deactivateOntransitioncancel() {
        this.#htmlElement.removeEventListener("transitioncancel", this.#ontransitioncancelCallback);
    }

    // #endregion



    // #region animationstart event

    /**
     * @param {AnimationEvent} animationEvent
     */
    #onanimationstartCallback = (animationEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeAnimationstart", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeAnimationstart", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnanimationstart(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlElement.addEventListener("animationstart", this.#onanimationstartCallback);
    }

    /**
     */
    deactivateOnanimationstart() {
        this.#htmlElement.removeEventListener("animationstart", this.#onanimationstartCallback);
    }

    // #endregion


    // #region animationend event

    /**
     * @param {AnimationEvent} animationEvent
     */
    #onanimationendCallback = (animationEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeAnimationend", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeAnimationend", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnanimationend(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlElement.addEventListener("animationend", this.#onanimationendCallback);
    }

    /**
     */
    deactivateOnanimationend() {
        this.#htmlElement.removeEventListener("animationend", this.#onanimationendCallback);
    }

    // #endregion


    // #region animationiteration event

    /**
     * @param {AnimationEvent} animationEvent
     */
    #onanimationiterationCallback = (animationEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeAnimationiteration", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeAnimationiteration", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnanimationiteration(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlElement.addEventListener("animationiteration", this.#onanimationiterationCallback);
    }

    /**
     */
    deactivateOnanimationiteration() {
        this.#htmlElement.removeEventListener("animationiteration", this.#onanimationiterationCallback);
    }

    // #endregion


    // #region animationcancel event

    /**
     * @param {AnimationEvent} animationEvent
     */
    #onanimationcancelCallback = (animationEvent) => this.#isEventTriggerSync
        ? this.#eventTrigger.invokeMethod("InvokeAnimationcancel", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement)
        : this.#eventTrigger.invokeMethodAsync("InvokeAnimationcancel", animationEvent.animationName, animationEvent.elapsedTime, animationEvent.pseudoElement);

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} eventTrigger
     * @param {boolean} isEventTriggerSync
     */
    activateOnanimationcancel(eventTrigger, isEventTriggerSync) {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
        this.#htmlElement.addEventListener("animationcancel", this.#onanimationcancelCallback);
    }

    /**
     */
    deactivateOnanimationcancel() {
        this.#htmlElement.removeEventListener("animationcancel", this.#onanimationcancelCallback);
    }

    // #endregion
}
