using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>HTMLElement</i> interface represents any HTML element. Some elements directly implement this interface, while others implement it via an interface that inherits it.
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="Dispose"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class HTMLElementInProcess(IJSInProcessObjectReference htmlElementJS) : HTMLElementBase(Task.FromResult<IJSObjectReference>(htmlElementJS)), IHTMLElementInProcess {
    /// <summary>
    /// Releases the JS instance for this HTML element.
    /// </summary>
    public void Dispose() {
        DisposeEventTrigger();
        htmlElementJS.Dispose();
    }


    #region HTMLElement

    /// <summary>
    /// Sets the keystroke which a user can press to jump to a given element.
    /// </summary>
    /// <remarks>
    /// Note: The HTMLElement.accessKey property is seldom used because of its multiple conflicts with already present key bindings in browsers.
    /// To work around this, browsers implement accesskey behavior if the keys are pressed with other "qualifying" keys (such as Alt + accesskey).
    /// </remarks>
    public string AccessKey {
        get => htmlElementJS.Invoke<string>("getAccessKey");
        set => htmlElementJS.InvokeVoid("setAccessKey", [value]);
    }

    /// <summary>
    /// Returns a string containing the element's browser-assigned access key (if any); otherwise it returns an empty string.
    /// </summary>
    public string AccessKeyLabel => htmlElementJS.Invoke<string>("getAccessKeyLabel");


    /// <summary>
    /// <para>
    /// Returns a live StylePropertyMap object that contains a list of style properties of the element that are defined in the element's inline style attribute,
    /// or assigned using the style property of the HTMLElement interface via script.
    /// </para>
    /// <para>Shorthand properties are expanded. If you set "border-top: 1px solid black", the longhand properties ("border-top-color", "border-top-style", and "border-top-width") are set instead.</para>
    /// <para>
    /// The main difference between <see cref="Style">style</see> property and <i>attributeStyleMap</i> is that, the <see cref="Style">style</see> property gets/sets all styles as a string,
    /// while <i>attributeStyleMap</i> handles styles in a Dictionary&lt;string, string&gt;.
    /// </para>
    /// <para>Though this property itself is not writable, you can write and remove inline styles through <see cref="SetAttributeStyleMap"/> and <see cref="RemoveAttributeStyleMap"/>.</para>
    /// </summary>
    public Dictionary<string, string> AttributeStyleMap => htmlElementJS.Invoke<Dictionary<string, string>>("getAttributeStyleMap");

    /// <summary>
    /// <para>Sets the given css property name to the given value.</para>
    /// <para>
    /// If the name does not exist, it will be added.<br />
    /// If the name does already exist, the value will be updated.<br />
    /// To remove a css property, use <see cref="RemoveAttributeStyleMap"/>.
    /// </para>
    /// </summary>
    /// <param name="name">name of the css property</param>
    /// <param name="value">value for the given css property</param>
    public void SetAttributeStyleMap(string name, string value) => htmlElementJS.InvokeVoid("setAttributeStyleMap", [name, value]);

    /// <summary>
    /// Removes the given css property.
    /// </summary>
    /// <param name="name">css property name</param>
    public void RemoveAttributeStyleMap(string name) => htmlElementJS.InvokeVoid("removeAttributeStyleMap", [name]);


    /// <summary>
    /// <para>
    /// Represents the element's capitalization behavior for user input. It is available on all HTML elements, though it doesn't affect all of them, including:<br />
    /// - &lt;input&lt; and &lt;textarea&lt; elements.<br />
    /// - Any element with <i>contenteditable</i> set on it.
    /// </para>
    /// <para>
    /// The value is a string that represents the element's capitalization behavior for user input. Valid values are as follows:<br />
    /// - "none" or "off": No autocapitalization should be applied, that is, all letters should default to lowercase.<br />
    /// - "sentences" or "on": The first letter of each sentence should default to a capital letter; all other letters should default to lowercase.<br />
    /// - "words": The first letter of each word should default to a capital letter; all other letters should default to lowercase.<br />
    /// - "characters": All letters should default to uppercase.
    /// </para>
    /// <para>
    /// <i>autocapitalize</i> doesn't affect behavior when typing on a physical keyboard.
    /// It affects the behavior of other input mechanisms such as virtual keyboards on mobile devices and voice input.
    /// This can assist users by making data entry quicker and easier, for example by automatically capitalizing the first letter of each sentence.
    /// </para>
    /// <para>It reflects the value of the autocapitalize HTML global attribute.</para>
    /// </summary>
    public string Autocapitalize {
        get => htmlElementJS.Invoke<string>("getAutocapitalize");
        set => htmlElementJS.InvokeVoid("setAutocapitalize", [value]);
    }

    /// <summary>
    /// <para>
    /// Represents a boolean value reflecting the autofocus HTML global attribute, which indicates whether the control should be focused when the page loads,
    /// or when dialog or popover become shown if specified in an element inside &lt;dialog&gt; elements or elements whose popover attribute is set.
    /// </para>
    /// <para>
    /// Only one form-associated element inside a document, or a &lt;dialog&gt; element, or an element whose popover attribute is set, can have this attribute specified.
    /// If there are several, the first element with the attribute set inserted, usually the first such element on the page, gets the initial focus.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Note: Setting this property doesn't set the focus to the associated element:
    /// it merely tells the browser to focus to it when the element is inserted in the document.
    /// Setting it after the insertion, that is most of the time after the document load, has no visible effect.
    /// </remarks>
    public bool Autofocus {
        get => htmlElementJS.Invoke<bool>("getAutofocus");
        set => htmlElementJS.InvokeVoid("setAutofocus", [value]);
    }

    /// <summary>
    /// <para>
    /// Specifies whether or not the element is editable. This enumerated attribute can have the following values:<br />
    /// - "true" indicates that the element is contenteditable.<br />
    /// - "false" indicates that the element cannot be edited.<br />
    /// - "plaintext-only" indicates that the element's raw text is editable, but rich text formatting is disabled.
    /// </para>
    /// <para>You can use the <see cref="IsContentEditable"/> property to test the computed boolean value of this property.</para>
    /// <para>If the attribute is missing or its value is invalid, its value is inherited from its parent element: so the element is editable (or not) based on the parent element.</para>
    /// </summary>
    public string ContentEditable {
        get => htmlElementJS.Invoke<string>("getContentEditable");
        set => htmlElementJS.InvokeVoid("setContentEditable", [value]);
    }


    /// <summary>
    /// <para>Provides read/write access to custom data attributes (data-*) on elements. It exposes a map of strings (DOMStringMap) with an entry for each data-* attribute.</para>
    /// <para>
    /// The property name of a custom data attribute is the same as the HTML attribute without the data- prefix.
    /// Single dashes (-) are removed, and the next ASCII character after a removed dash is capitalized to form the property's camel-cased name.
    /// </para>
    /// <para>For writing or removing elements use <see cref="SetDataset"/> or <see cref="RemoveDataset"/>.</para>
    /// </summary>
    public Dictionary<string, string> Dataset => htmlElementJS.Invoke<Dictionary<string, string>>("getDataset");

    /// <summary>
    /// <para>Sets the given data-attribute to the given value.</para>
    /// <para>
    /// If the name does not exist, it will be added.<br />
    /// If the name does already exist, the value will be updated.<br />
    /// To remove a data-attribute, use <see cref="RemoveDataset"/>.
    /// </para>
    /// </summary>
    /// <param name="name">name of the data-attribute without data- prefix</param>
    /// <param name="value">value for the given data-attribute</param>
    public void SetDataset(string name, string value) => htmlElementJS.InvokeVoid("setDataset", [name, value]);

    /// <summary>
    /// Removes the given data-attribute.
    /// </summary>
    /// <param name="name">data-attribute name</param>
    public void RemoveDataset(string name) => htmlElementJS.InvokeVoid("removeDataset", [name]);


    /// <summary>
    /// <para>
    /// Indicates the text writing directionality of the content of the current element. Possible values are<br />
    /// - "ltr": Left-to-right writing direction.<br />
    /// - "rtl": Right-to-left writing direction.<br />
    /// - "auto": The direction of the element must be determined based on the contents of the element.<br />
    /// - "": The default value; the directionality is inherited from the parent element.
    /// </para>
    /// <para>
    /// Note that if the dir attribute is unspecified, the element itself may still inherit directionality from its parent.
    /// However, that inherited directionality is not reflected by this property's value.
    /// </para>
    /// <para>
    /// The text writing directionality of an element is which direction that text goes (for support of different language systems).
    /// Arabic languages and Hebrew are typical languages using the RTL directionality.
    /// </para>
    /// </summary>
    public string Dir {
        get => htmlElementJS.Invoke<string>("getDir");
        set => htmlElementJS.InvokeVoid("setDir", [value]);
    }

    /// <summary>
    /// A boolean value indicating if the element can be dragged. It reflects the value of the draggable HTML global attribute.
    /// </summary>
    public bool Draggable {
        get => htmlElementJS.Invoke<bool>("getDraggable");
        set => htmlElementJS.InvokeVoid("setDraggable", [value]);
    }

    /// <summary>
    /// <para>
    /// An enumerated property defining what action label (or icon) to present for the enter key on virtual keyboards.
    /// It reflects the enterkeyhint HTML global attribute and is an enumerated property, only accepting the following values as a string:<br />
    /// - "enter": Typically indicating inserting a new line.<br />
    /// - "done": Typically meaning there is nothing more to input and the input method editor (IME) will be closed.<br />
    /// - "go": Typically meaning to take the user to the target of the text they typed.<br />
    /// - "next": Typically taking the user to the next field that will accept text.<br />
    /// - "previous": Typically taking the user to the previous field that will accept text.<br />
    /// - "search": Typically taking the user to the results of searching for the text they have typed.<br />
    /// - "send": Typically delivering the text to its target.
    /// </para>
    /// <para>If no <i>enterKeyHint</i> value has been specified or if it was set to a different value than the allowed ones, it will return an empty string.</para>
    /// </summary>
    public string EnterKeyHint {
        get => htmlElementJS.Invoke<string>("getEnterKeyHint");
        set => htmlElementJS.InvokeVoid("setEnterKeyHint", [value]);
    }

    /// <summary>
    /// Reflects the value of the element's hidden attribute.<br />
    /// true - The element is hidden.<br />
    /// false - The element is not hidden. This is the default value for the attribute.
    /// </summary>
    public bool Hidden {
        get => htmlElementJS.Invoke<bool>("getHidden");
        set => htmlElementJS.InvokeVoid("setHidden", [value]);
    }

    /// <summary>
    /// <para>
    /// Reflects the value of the element's inert attribute.
    /// It is a boolean value that, when present, makes the browser "ignore" user input events for the element, including focus events and events from assistive technologies.
    /// The browser may also ignore page search and text selection in the element.
    /// This can be useful when building UIs such as modals where you would want to "trap" the focus inside the modal when it's visible.
    /// </para>
    /// <para>
    /// Note that if the inert attribute is unspecified, the element itself may still inherit inertness from its parent.
    /// However, that inherited inertness is not reflected by this property's value.
    /// </para>
    /// </summary>
    public bool Inert {
        get => htmlElementJS.Invoke<bool>("getInert");
        set => htmlElementJS.InvokeVoid("setInert", [value]);
    }

    /// <summary>
    /// <para>Represents the rendered text content of a node and its descendants.</para>
    /// <para>
    /// As a getter, it approximates the text the user would get if they highlighted the contents of the element with the cursor and then copied it to the clipboard.
    /// As a setter this will replace the element's children with the given value, converting any line breaks into &lt;br&gt; elements.
    /// </para>
    /// <para>
    /// Note: innerText is easily confused with Node.textContent, but there are important differences between the two.
    /// Basically, innerText is aware of the rendered appearance of text, while textContent is not.
    /// </para>
    /// </summary>
    public string InnerText {
        get => htmlElementJS.Invoke<string>("getInnerText");
        set => htmlElementJS.InvokeVoid("setInnerText", [value]);
    }

    /// <summary>
    /// <para>
    /// Reflects the value of the element's inputmode attribute.<br />
    /// It provides a hint about the type of data that might be entered by the user while editing the element or its contents. This allows the browser to display an appropriate virtual keyboard.<br />
    /// It is used primarily on &lt;input&gt; elements, but is usable on any element in <see cref="ContentEditable">contenteditable</see> mode.
    /// </para>
    /// <para>
    /// This attribute may have one of the following values:<br />
    /// - "decimal": Fractional numeric input keyboard that contains the digits and decimal separator for the user's locale (typically . or ,).<br />
    /// - "email": A virtual keyboard optimized for entering email addresses. Typically includes the @character as well as other optimizations.<br />
    /// - "none": No virtual keyboard. This is used when the page implements its own keyboard input control.<br />
    /// - "numeric": Numeric input keyboard that only requires the digits 0–9. Devices may or may not show a minus key.<br />
    /// - "search": A virtual keyboard optimized for search input. For instance, the return/submit key may be labeled "Search".<br />
    /// - "tel": A telephone keypad input that includes the digits 0–9, the asterisk (*), and the pound (#) key.<br />
    /// - "text": Standard input keyboard for the user's current locale.<br />
    /// - "url": A keypad optimized for entering URLs. This may have the / key more prominent, for example.
    /// </para>
    /// </summary>
    public string InputMode {
        get => htmlElementJS.Invoke<string>("getInputMode");
        set => htmlElementJS.InvokeVoid("setInputMode", [value]);
    }

    /// <summary>
    /// It is true if the contents of the element are editable; otherwise it returns false.
    /// </summary>
    public bool IsContentEditable => htmlElementJS.Invoke<bool>("getIsContentEditable");

    /// <summary>
    /// <para>
    /// Indicates the base language of an element's attribute values and text content, in the form of a RFC 5646: BCP 47 language identifier tag.
    /// It reflects the element's lang attribute; the xml:lang attribute does not affect this property.
    /// </para>
    /// <para>
    /// Note that if the lang attribute is unspecified, the element itself may still inherit the language from its parent.
    /// However, that inherited language is not reflected by this property's value.
    /// </para>
    /// <para>Common examples include "en" for English, "ja" for Japanese, "es" for Spanish and so on. If unspecified, the value is an empty string.</para>
    /// </summary>
    public string Lang {
        get => htmlElementJS.Invoke<string>("getLang");
        set => htmlElementJS.InvokeVoid("setLang", [value]);
    }

    /// <summary>
    /// <para>Returns the cryptographic number used once that is used by Content Security Policy to determine whether a given fetch will be allowed to proceed.</para>
    /// <para>In later implementations, elements only expose their nonce attribute to scripts (and not to side-channels like CSS attribute selectors).</para>
    /// </summary>
    public string Nonce {
        get => htmlElementJS.Invoke<string>("getNonce");
        set => htmlElementJS.InvokeVoid("setNonce", [value]);
    }


    /// <summary>
    /// <para>Returns the layout width of an element as an integer.</para>
    /// <para>
    /// Typically, offsetWidth is a measurement in pixels of the element's CSS width, including any borders, padding, and vertical scrollbars (if rendered).
    /// It does not include the width of pseudo-elements such as ::before or ::after.
    /// </para>
    /// <para>If the element is hidden (for example, by setting style.display on the element or one of its ancestors to "none"), then 0 is returned.</para>
    /// <para>Note: This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    public int OffsetWidth => htmlElementJS.Invoke<int>("getOffsetWidth");

    /// <summary>
    /// <para>Returns the height of an element, including vertical padding and borders, as an integer.</para>
    /// <para>
    /// Typically, offsetHeight is a measurement in pixels of the element's CSS height, including any borders, padding, and horizontal scrollbars (if rendered).
    /// It does not include the height of pseudo-elements such as ::before or ::after. For the document body object, the measurement includes total linear content height instead of the element's CSS height.Floated elements extending below other linear content are ignored.
    /// </para>
    /// <para>If the element is hidden(for example, by setting style.display on the element or one of its ancestors to "none"), then 0 is returned.</para>
    /// <para>Note: This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    public int OffsetHeight => htmlElementJS.Invoke<int>("getOffsetHeight");

    /// <summary>
    /// <para>Returns the number of pixels that the upper left corner of the current element is offset to the left within the HTMLElement.offsetParent node.</para>
    /// <para>For block-level elements, offsetTop, offsetLeft, offsetWidth, and offsetHeight describe the border box of an element relative to the offsetParent.</para>
    /// <para>
    /// However, for inline-level elements (such as span) that can wrap from one line to the next, offsetTop and offsetLeft describe the positions of the first border box
    /// (use Element.getClientRects() to get its width and height), while offsetWidth and offsetHeight describe the dimensions of the bounding border box(use Element.getBoundingClientRect() to get its position).
    /// Therefore, a box with the left, top, width and height of offsetLeft, offsetTop, offsetWidth and offsetHeight will not be a bounding box for a span with wrapped text.
    /// </para>
    /// </summary>
    public int OffsetLeft => htmlElementJS.Invoke<int>("getOffsetLeft");

    /// <summary>
    /// Returns the distance from the outer border of the current element (including its margin) to the top padding edge of the offsetParent,
    /// the closest positioned ancestor element.
    /// </summary>
    public int OffsetTop => htmlElementJS.Invoke<int>("getOffsetTop");

    /// <summary>
    /// <para>Returns a reference to the element which is the closest (nearest in the containment hierarchy) positioned ancestor element.</para>
    /// <para>
    /// A positioned ancestor is either:<br />
    /// - an element with a non-static position, or<br />
    /// - td, th, table in case the element itself is static positioned.<br />
    /// If there is no positioned ancestor element, the body is returned.
    /// </para>
    /// <para>
    /// Note: <i>offsetParent</i> returns null in the following situations:<br />
    /// - The element or any ancestor has the display property set to none.<br />
    /// - The element has the position property set to fixed (Firefox returns &lt;body&gt;).<br />
    /// - The element is &lt;body&gt; or &lt;html&gt;.
    /// </para>
    /// <para><i>offsetParent</i> is useful because offsetTop and offsetLeft are relative to its padding edge.</para>
    /// </summary>
    public IHTMLElementInProcess? OffsetParent {
        get {
            IJSInProcessObjectReference?[] singleReference = htmlElementJS.Invoke<IJSInProcessObjectReference?[]>("getOffsetParent");
            if (singleReference[0] is IJSInProcessObjectReference htmlElement)
                return new HTMLElementInProcess(htmlElement);
            else
                return null;
        }
    }


    /// <summary>
    /// <para>
    /// Returns the same value as HTMLElement.innerText.
    /// When used as a setter it replaces the whole current node with the given text (this differs from innerText, which replaces the content inside the current node).
    /// </para>
    /// <para>See <see cref="InnerText">HTMLElement.innerText</see> for more information and examples showing how both properties are used as getters.</para>
    /// </summary>
    public string OuterText {
        get => htmlElementJS.Invoke<string>("getOuterText");
        set => htmlElementJS.InvokeVoid("setOuterText", [value]);
    }

    /// <summary>
    /// <para>Gets/Sets an element's popover state via JavaScript ("auto", "hint", or "manual"), and can be used for feature detection. It reflects the value of the popover global HTML attribute.</para>
    /// <para>
    /// Possible values are:<br />
    /// - "auto": auto popovers can be "light dismissed" — this means that you can hide the popover by clicking outside it or pressing the Esc key.
    /// Usually, only one auto popover can be shown at a time — showing a second popover when one is already shown will hide the first one.
    /// The exception to this rule is when you have nested auto popovers.
    /// See Nested popovers for more details.<br />
    /// - "hint": hint popovers do not close auto popovers when they are displayed, but will close other hint popovers.
    /// They can be light dismissed and will respond to close requests.
    /// Usually they are shown and hidden in response to non-click JavaScript events such as mouseover/mouseout and focus/blur.
    /// Clicking a button to open a hint popover would cause an open auto popover to light-dismiss.<br />
    /// - "manual": manual popovers cannot be "light dismissed" and are not automatically closed.
    /// Popovers must explicitly be displayed and closed using declarative show/hide/toggle buttons or JavaScript.
    /// Multiple independent manual popovers can be shown simultaneously.
    /// </para>
    /// </summary>
    public string? Popover {
        get => htmlElementJS.Invoke<string?>("getPopover");
        set => htmlElementJS.InvokeVoid("setPopover", [value]);
    }

    /// <summary>
    /// Represents a boolean value that controls the spell-checking hint. It is available on all HTML elements, though it doesn't affect all of them.
    /// It reflects the value of the spellcheck HTML global attribute.
    /// </summary>
    public bool Spellcheck {
        get => htmlElementJS.Invoke<bool>("getSpellcheck");
        set => htmlElementJS.InvokeVoid("setSpellcheck", [value]);
    }

    /// <summary>
    /// <para>JS-property: style.cssText</para>
    /// <para>Returns or sets the text of the element's inline style declaration only.</para>
    /// <para>To be able to set a stylesheet rule dynamically, see <see href="https://developer.mozilla.org/en-US/docs/Web/API/CSS_Object_Model/Using_dynamic_styling_information">Using dynamic styling information</see>.</para>
    /// <para>Not to be confused with stylesheet style-rule <see href="https://developer.mozilla.org/en-US/docs/Web/API/CSSRule/cssText">CSSRule.cssText</see>.</para>
    /// </summary>
    public string Style {
        get => htmlElementJS.Invoke<string>("getStyle");
        set => htmlElementJS.InvokeVoid("setStyle", [value]);
    }

    /// <summary>
    /// <para>
    /// Represents the tab order of the current element. Tab order is as follows:<br />
    /// 1. Elements with a positive tabIndex. Elements that have identical tabIndex values should be navigated in the order they appear. Navigation proceeds from the lowest tabIndex to the highest tabIndex.<br />
    /// 2. Elements that do not support the tabIndex attribute or support it and assign tabIndex to 0, in the order they appear.<br />
    /// Elements that are disabled do not participate in the tabbing order.
    /// </para>
    /// <para>Values don't need to be sequential, nor must they begin with any particular value. They may even be negative, though each browser trims very large values.</para>
    /// </summary>
    public long TabIndex {
        get => htmlElementJS.Invoke<long>("getTabIndex");
        set => htmlElementJS.InvokeVoid("setTabIndex", [value]);
    }

    /// <summary>
    /// Represents the title of the element: the text usually displayed in a 'tooltip' popup when the mouse is over the node.
    /// </summary>
    public string Title {
        get => htmlElementJS.Invoke<string>("getTitle");
        set => htmlElementJS.InvokeVoid("setTitle", [value]);
    }

    /// <summary>
    /// Indicates whether an element's attribute values and the values of its Text node children are to be translated when the page is localized, or whether to leave them unchanged.
    /// It reflects the value of the translate HTML global attribute.
    /// </summary>
    public bool Translate {
        get => htmlElementJS.Invoke<bool>("getTranslate");
        set => htmlElementJS.InvokeVoid("setTranslate", [value]);
    }


    // extra

    /// <summary>
    /// <para>htmlElement === document.activeElement;</para>
    /// <para>If true, the htmlElement has focus, otherwise false.</para>
    /// </summary>
    public bool HasFocus => htmlElementJS.Invoke<bool>("hasFocus");


    // methods

    /// <summary>
    /// <para>Simulates a mouse click on an element.</para>
    /// <para>
    /// When click() is used with supported elements(such as an &lt;input&gt;), it fires the element's click event.
    /// This event then bubbles up to elements higher in the document tree (or event chain) and fires their click events.
    /// </para>
    /// </summary>
    public void Click() => htmlElementJS.InvokeVoid("click");

    /// <summary>
    /// <para>Sets focus on the specified element, if it can be focused. The focused element is the element that will receive keyboard and similar events by default.</para>
    /// <para>
    /// By default the browser will scroll the element into view after focusing it, and it may also provide visible indication of the focused element(typically by displaying a "focus ring" around the element).
    /// Parameter options are provided to disable the default scrolling and force visible indication on elements.
    /// </para>
    /// </summary>
    /// <param name="preventScroll">
    /// A boolean value indicating whether or not the browser should scroll the document to bring the newly-focused element into view.
    /// A value of false for preventScroll (the default) means that the browser will scroll the element into view after focusing it.
    /// If preventScroll is set to true, no scrolling will occur.
    /// </param>
    public void Focus(bool preventScroll = false) => htmlElementJS.InvokeVoid("focus", [preventScroll]);

    /// <summary>
    /// Removes keyboard focus from the current element.
    /// </summary>
    public void Blur() => htmlElementJS.InvokeVoid("blur");

    /// <summary>
    /// <para>Shows a popover element (i.e. one that has a valid popover attribute) by adding it to the top layer.</para>
    /// <para>
    /// When <i>showPopover()</i> is called on an element with the popover attribute that is currently hidden, a beforetoggle event will be fired, followed by the popover showing, and then the toggle event firing.
    /// If the element is already showing, an error will be thrown.
    /// </para>
    /// </summary>
    public void ShowPopover() => htmlElementJS.InvokeVoid("showPopover");

    /// <summary>
    /// <para>Hides a popover element (i.e. one that has a valid popover attribute) by removing it from the top layer and styling it with display: none.</para>
    /// <para>
    /// When <i>hidePopover()</i> is called on a showing element with the popover attribute, a beforetoggle event will be fired, followed by the popover being hidden, and then the toggle event firing.
    /// If the element is already hidden, an error is thrown.
    /// </para>
    /// </summary>
    public void HidePopover() => htmlElementJS.InvokeVoid("hidePopover");

    /// <summary>
    /// <para>Toggles a popover element (i.e. one that has a valid popover attribute) between the hidden and showing states.</para>
    /// <para>
    /// When <i>togglePopover()</i> is called on an element with the popover attribute:<br />
    /// 1. A beforetoggle event is fired.<br />
    /// 2. The popover toggles between hidden and showing:<br />
    /// - i. If it was initially showing, it toggles to hidden.<br />
    /// - ii. If it was initially hidden, it toggles to showing.<br />
    /// 3. A toggle event is fired.
    /// </para>
    /// </summary>
    /// <returns>
    /// <para>true if the popup is open after the call, and false otherwise.</para>
    /// <para>None(undefined) may be returned in older browser versions(see browser compatibility).</para>
    /// </returns>
    public bool TogglePopover() => htmlElementJS.Invoke<bool>("togglePopover");

    /// <inheritdoc cref="TogglePopover()" />
    /// <param name="force">
    /// <para>A boolean, which causes togglePopover() to behave like showPopover() or hidePopover(), except that it doesn't throw an exception if the popover is already in the target state.</para>
    /// <para>- If set to true, the popover is shown if it was initially hidden.If it was initially shown, nothing happens.</para>
    /// <para>- If set to false, the popover is hidden if it was initially shown. If it was initially hidden, nothing happens.</para>
    /// </param>
    public bool TogglePopover(bool force) => htmlElementJS.Invoke<bool>("togglePopover", [force]);

    #endregion


    #region Element

    /// <summary>
    /// <para>Gets/Sets the HTML or XML markup contained within the element.</para>
    /// <para>To insert the HTML into the document rather than replace the contents of an element, use the method insertAdjacentHTML().</para>
    /// </summary>
    public string InnerHTML {
        get => htmlElementJS.Invoke<string>("getInnerHTML");
        set => htmlElementJS.InvokeVoid("setInnerHTML", [value]);
    }

    /// <summary>
    /// <para>
    /// Gets the serialized HTML fragment describing the element including its descendants.
    /// It can also be set to replace the element with nodes parsed from the given string.
    /// </para>
    /// <para>To only obtain the HTML representation of the contents of an element, or to replace the contents of an element, use the innerHTML property instead.</para>
    /// </summary>
    public string OuterHTML {
        get => htmlElementJS.Invoke<string>("getOuterHTML");
        set => htmlElementJS.InvokeVoid("setOuterHTML", [value]);
    }

    /// <summary>
    /// Returns a live collection of all attribute nodes registered to the specified node.
    /// It is a NamedNodeMap, not an Array, so it has no Array methods and the Attr nodes' indexes may differ among browsers.
    /// To be more specific, attributes is a key/value pair of strings that represents any information regarding that attribute.
    /// </summary>
    public Dictionary<string, string> Attributes => htmlElementJS.Invoke<Dictionary<string, string>>("getAttributes");

    /// <summary>
    /// Returns the number of child elements of this element.
    /// </summary>
    public int ChildElementCount => htmlElementJS.Invoke<int>("getChildElementCount");

    /// <summary>
    /// <para>Returns a live HTMLCollection which contains all of the child elements of the element upon which it was called.</para>
    /// <üara>Element.children includes only element nodes.To get all child nodes, including non-element nodes like text and comment nodes, use Node.childNodes.</üara>
    /// </summary>
    public IHTMLElementInProcess[] Children {
        get {
            IJSInProcessObjectReference[] children = htmlElementJS.Invoke<IJSInProcessObjectReference[]>("getChildren");

            HTMLElementInProcess[] result = new HTMLElementInProcess[children.Length];
            for (int i = 0; i < result.Length; i++)
                result[i] = new HTMLElementInProcess(children[i]);
            return result;
        }
    }

    /// <summary>
    /// <para>Gets/Sets the value of the class attribute of the specified element.</para>
    /// <para>Returns A string variable representing the class or space-separated classes of the current element.</para>
    /// </summary>
    public string ClassName {
        get => htmlElementJS.Invoke<string>("getClassName");
        set => htmlElementJS.InvokeVoid("setClassName", [value]);
    }

    /// <summary>
    /// <para>Returns a live DOMTokenList collection of the class attributes of the element. This can then be used to manipulate the class list.</para>
    /// <üara>Using classList is a convenient alternative to accessing an element's list of classes as a space-delimited string via <i>element.className</i>.</üara>
    /// </summary>
    public string[] ClassList => htmlElementJS.Invoke<string[]>("getClassList");


    /// <summary>
    /// <para>
    /// Is zero for inline elements and elements with no CSS; otherwise, it's the inner width of an element in pixels.
    /// It includes padding but excludes borders, margins, and vertical scrollbars (if present).
    /// </para>
    /// <para>
    /// When clientWidth is used on the root element(the &lt;html&gt; element), (or on &lt;body&gt; if the document is in quirks mode), the viewport's width (excluding any scrollbar) is returned.
    /// <see href="https://www.w3.org/TR/2016/WD-cssom-view-1-20160317/#dom-element-clientwidth">This is a special case of clientWidth</see>.
    /// </para>
    /// <para>Note: This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    public int ClientWidth => htmlElementJS.Invoke<int>("getClientWidth");

    /// <summary>
    /// <para>
    /// Is zero for elements with no CSS or inline layout boxes; otherwise, it's the inner height of an element in pixels.
    /// It includes padding but excludes borders, margins, and horizontal scrollbars (if present).
    /// </para>
    /// <para>clientHeight can be calculated as: CSS height + CSS padding - height of horizontal scrollbar(if present).</para>
    /// <para>
    /// When clientHeight is used on the root element(the &lt;html&gt; element), (or on &lt;body&gt; if the document is in quirks mode), the viewport's height (excluding any scrollbar) is returned.
    /// <see href="https://www.w3.org/TR/2016/WD-cssom-view-1-20160317/#dom-element-clientheight">This is a special case of clientHeight</see>.
    /// </para>
    /// <para>Note: This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    public int ClientHeight => htmlElementJS.Invoke<int>("getClientHeight");

    /// <summary>
    /// <para>
    /// The width of the left border of an element in pixels.
    /// It includes the width of the vertical scrollbar if the text direction of the element is right-to-left and if there is an overflow causing a left vertical scrollbar to be rendered.
    /// clientLeft does not include the left margin or the left padding. clientLeft is read-only.
    /// </para>
    /// <para>Note: This property will round the value to an integer.If you need a fractional value, use element.getBoundingClientRect().</para>
    /// <para>Note: When an element has display: inline, clientLeft returns 0 regardless of the element's border.</para>
    /// </summary>
    public int ClientLeft => htmlElementJS.Invoke<int>("getClientLeft");

    /// <summary>
    /// <para>The width of the top border of an element in pixels. It is a read-only, integer property of element.</para>
    /// <para>
    /// As it happens, all that lies between the two locations (offsetTop and client area top) is the element's border.
    /// This is because the offsetTop indicates the location of the top of the border (not the margin) while the client area starts immediately below the border, (client area includes padding.)
    /// Therefore, the clientTop value will always equal the integer portion of the .getComputedStyle() value for "border-top-width". (Actually might be Math.round(parseFloat()).)
    /// For example, if the computed "border-top-width" is zero, then clientTop is also zero.
    /// </para>
    /// <para>Note: This property will round the value to an integer.If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    public int ClientTop => htmlElementJS.Invoke<int>("getClientTop");


    /// <summary>
    /// <para>Is a measurement of the width of an element's content, including content not visible on the screen due to overflow.</para>
    /// <para>
    /// The scrollWidth value is equal to the minimum width the element would require in order to fit all the content in the viewport without using a horizontal scrollbar.
    /// The width is measured in the same way as clientWidth: it includes the element's padding, but not its border, margin or vertical scrollbar (if present).
    /// It can also include the width of pseudo-elements such as ::before or ::after.
    /// If the element's content can fit without a need for horizontal scrollbar, its scrollWidth is equal to clientWidth.
    /// </para>
    /// <para>Note: This property will round the value to an integer.If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    public int ScrollWidth => htmlElementJS.Invoke<int>("getScrollWidth");

    /// <summary>
    /// <para>Is a measurement of the height of an element's content, including content not visible on the screen due to overflow.</para>
    /// <para>
    /// The user's viewport is an element with four regions labeled padding-top, border-top, border-bottom, padding-bottom.
    /// The scroll height goes from the container's padding top to the end of the padding bottom, well beyond the top and bottom of the viewport.
    /// </para>
    /// <para>
    /// The scrollHeight value is equal to the minimum height the element would require in order to fit all the content in the viewport without using a vertical scrollbar.
    /// The height is measured in the same way as clientHeight: it includes the element's padding, but not its border, margin or horizontal scrollbar (if present).
    /// It can also include the height of pseudo-elements such as ::before or ::after.
    /// If the element's content can fit without a need for vertical scrollbar, its scrollHeight is equal to clientHeight.
    /// </para>
    /// <para>Note: This property will round the value to an integer.If you need a fractional value, use Element.getBoundingClientRect().</para>
    /// </summary>
    public int ScrollHeight => htmlElementJS.Invoke<int>("getScrollHeight");

    /// <summary>
    /// <para>Gets/Sets the number of pixels that an element's content is scrolled from its left edge.</para>
    /// <para>
    /// If the element's direction is rtl (right-to-left), then scrollLeft is 0 when the scrollbar is at its rightmost position (at the start of the scrolled content),
    /// and then increasingly negative as you scroll towards the end of the content.
    /// </para>
    /// <para>
    /// It can be specified as any integer value.However:<br />
    /// - If the element can't be scrolled (e.g., it has no overflow), scrollLeft is set to 0.<br />
    /// - If specified as a value less than 0 (greater than 0 for right-to-left elements), scrollLeft is set to 0.<br />
    /// - If specified as a value greater than the maximum that the content can be scrolled, scrollLeft is set to the maximum.
    /// </para>
    /// <para>Warning: On systems using display scaling, scrollLeft may give you a decimal value. (It will be rounded down to the next integer.)</para>
    /// </summary>
    public int ScrollLeft {
        get => (int)htmlElementJS.Invoke<double>("getScrollLeft");
        set => htmlElementJS.InvokeVoid("setScrollLeft", [value]);
    }

    /// <summary>
    /// <para>Gets/Sets the number of pixels that an element's content is scrolled vertically.</para>
    /// <para>
    /// An element's scrollTop value is a measurement of the distance from the element's top to its topmost visible content.
    /// When an element's content does not generate a vertical scrollbar, then its scrollTop value is 0.
    /// </para>
    /// <para>
    /// scrollTop can be set to any integer value, with certain caveats:<br />
    /// - If the element can't be scrolled (e.g. it has no overflow or if the element has a property of "non-scrollable"), scrollTop is 0.<br />
    /// - scrollTop doesn't respond to negative values; instead, it sets itself back to 0.<br />
    /// - If set to a value greater than the maximum available for the element, scrollTop settles itself to the maximum value.
    /// </para>
    /// <para>
    /// When scrollTop is used on the root element (the &lt;html&gt; element), the scrollY of the window is returned.
    /// <see href="https://www.w3.org/TR/2016/WD-cssom-view-1-20160317/#dom-element-scrolltop">This is a special case of scrollTop</see>.
    /// </para>
    /// <para>Warning: On systems using display scaling, scrollTop may give you a decimal value. (It will be rounded down to the next integer.)</para>
    /// </summary>
    public int ScrollTop {
        get => (int)htmlElementJS.Invoke<double>("getScrollTop");
        set => htmlElementJS.InvokeVoid("setScrollTop", [value]);
    }


    // methods

    /// <summary>
    /// Returns a DOMRect object providing information about the size of an element and its position relative to the viewport.
    /// </summary>
    /// <returns>
    /// <para>
    /// The returned value is a DOMRect object which is the smallest rectangle which contains the entire element, including its padding and border-width.
    /// The left, top, right, bottom, x, y, width, and height properties describe the position and size of the overall rectangle in pixels.
    /// Properties other than width and height are relative to the top-left of the viewport.
    /// </para>
    /// <para>
    /// The width and height properties of the DOMRect object returned by the method include the padding and border-width, not only the content width/height.
    /// In the standard box model, this would be equal to the width or height property of the element + padding + border-width.
    /// But if box-sizing: border-box is set for the element this would be directly equal to its width or height.
    /// </para>
    /// <para>The returned value can be thought of as the union of the rectangles returned by getClientRects() for the element, i.e., the CSS border-boxes associated with the element.</para>
    /// <para>
    /// Empty border-boxes are completely ignored.
    /// If all the element's border-boxes are empty, then a rectangle is returned with a width and height of zero
    /// and where the top and left are the top-left of the border-box for the first CSS box (in content order) for the element.
    /// </para>
    /// <para>
    /// The amount of scrolling that has been done of the viewport area (or any other scrollable element) is taken into account when computing the bounding rectangle.
    /// This means that the rectangle's boundary edges (top, right, bottom, left) change their values every time the scrolling position changes (because their values are relative to the viewport and not absolute).
    /// </para>
    /// <para>
    /// If you need the bounding rectangle relative to the top-left corner of the document, just add the current scrolling position to the top and left properties
    /// (these can be obtained using window.scrollY and window.scrollX) to get a bounding rectangle which is independent from the current scrolling position.
    /// </para>
    /// </returns>
    public DOMRect GetBoundingClientRect() => htmlElementJS.Invoke<DOMRect>("getBoundingClientRect");

    /// <summary>
    /// <para>Returns a collection of DOMRect objects that indicate the bounding rectangles for each CSS border box in a client.</para>
    /// <para>Most elements only have one border box each, but a multiline inline-level element(such as a multiline &lt;span&gt; element, by default) has a border box around each line.</para>
    /// </summary>
    /// <returns>
    /// <para>
    /// The returned value is a collection of DOMRect objects, one for each CSS border box associated with the element.
    /// Each DOMRect object describes the border box, in pixels, with the top-left relative to the top-left of the viewport.
    /// For tables with captions, the caption is included even though it's outside the border box of the table.
    /// When called on SVG elements other than an outer-&lt;svg&gt;, the "viewport" that the resulting rectangles are relative to is the viewport that the element's outer-&lt;svg&gt; establishes
    /// (and to be clear, the rectangles are also transformed by the outer-&lt;svg&gt;'s viewBox transform, if any).
    /// </para>
    /// <para>The amount of scrolling that has been done of the viewport area(or any other scrollable element) is taken into account when computing the rectangles.</para>
    /// <para>The returned rectangles do not include the bounds of any child elements that might happen to overflow.</para>
    /// <para>For HTML&lt;area&gt; elements, SVG elements that do not render anything themselves, display:none elements, and generally any elements that are not directly rendered, an empty list is returned.</para>
    /// <para>Rectangles are returned even for CSS boxes that have empty border-boxes.The left, top, right, and bottom coordinates can still be meaningful.</para>
    /// <para>Fractional pixel offsets are possible.</para>
    /// </returns>
    public DOMRect[] GetClientRects() => htmlElementJS.Invoke<DOMRect[]>("getClientRects");


    /// <summary>
    /// Returns a Boolean value indicating whether the specified element has the specified attribute or not.
    /// </summary>
    /// <param name="name">A string representing the name of the attribute.</param>
    /// <returns></returns>
    public bool HasAttribute(string name) => htmlElementJS.Invoke<bool>("hasAttribute", [name]);

    /// <summary>
    /// Returns a boolean value indicating whether the current element has any attributes or not.
    /// </summary>
    /// <returns></returns>
    public bool HasAttributes() => htmlElementJS.Invoke<bool>("hasAttributes");


    /// <summary>
    /// <para>
    /// Is used to designate a specific element as the capture target of future pointer events.
    /// Subsequent events for the pointer will be targeted at the capture element until capture is released (via Element.releasePointerCapture() or the pointerup event is fired).
    /// </para>
    /// <para>
    /// Note: Pointer capture will cause the target to capture all subsequent pointer events as if they were occurring over the capturing target.
    /// Accordingly, pointerover, pointerenter, pointerleave, and pointerout will not fire as long as this capture is set.
    /// For touchscreen browsers that allow direct manipulation, an implicit pointer capture will be called on the element when a pointerdown event triggers.
    /// The capture can be released manually by calling element.releasePointerCapture on the target element, or it will be implicitly released after a pointerup or pointercancel event.
    /// </para>
    /// <para>
    /// Pointer capture allows events for a particular pointer event (PointerEvent) to be re-targeted to a particular element instead of the normal(or hit test) target at a pointer's location.
    /// This can be used to ensure that an element continues to receive pointer events even if the pointer device's contact moves off the element(such as by scrolling or panning).
    /// </para>
    /// </summary>
    /// <param name="pointerId">The pointerId of a PointerEvent object.</param>
    public void SetPointerCapture(long pointerId) => htmlElementJS.InvokeVoid("setPointerCapture", [pointerId]);

    /// <summary>
    /// <para>Releases (stops) pointer capture that was previously set for a specific (PointerEvent) pointer.</para>
    /// <para>See the <see cref="SetPointerCapture(long)"/> method for a description of pointer capture and how to set it for a particular element.</para>
    /// </summary>
    /// <param name="pointerId">The pointerId of a PointerEvent object.</param>
    public void ReleasePointerCapture(long pointerId) => htmlElementJS.InvokeVoid("releasePointerCapture", [pointerId]);

    /// <summary>
    /// Checks whether the element on which it is invoked has pointer capture for the pointer identified by the given pointer ID.
    /// </summary>
    /// <param name="pointerId">The pointerId of a PointerEvent object.</param>
    /// <returns></returns>
    public bool HasPointerCapture(long pointerId) => htmlElementJS.Invoke<bool>("hasPointerCapture", [pointerId]);


    /// <summary>
    /// Scrolls the element to a particular set of coordinates inside a given element.
    /// </summary>
    /// <param name="left">Specifies the number of pixels along the X axis to scroll the window or element.</param>
    /// <param name="top">Specifies the number of pixels along the Y axis to scroll the window or element.</param>
    public void Scroll(int left, int top) => htmlElementJS.InvokeVoid("scroll", [left, top]);

    /// <summary>
    /// Scrolls an element by the given amount.
    /// </summary>
    /// <param name="x">Specifies the number of pixels along the X axis to scroll the window or element.</param>
    /// <param name="y">Specifies the number of pixels along the Y axis to scroll the window or element.</param>
    public void ScrollBy(int x, int y) => htmlElementJS.InvokeVoid("scrollBy", [x, y]);

    /// <summary>
    /// Scrolls the element's ancestor containers such that the element on which <i>scrollIntoView()</i> is called is visible to the user.
    /// </summary>
    /// <param name="block">Defines vertical alignment. One of "start", "center", "end", or "nearest". Defaults to "start".</param>
    /// <param name="inline">Defines horizontal alignment. One of "start", "center", "end", or "nearest". Defaults to "nearest".</param>
    /// <param name="behavior">
    /// Determines whether scrolling is instant or animates smoothly.This option is a string which must take one of the following values:<br />
    /// - "smooth": scrolling should animate smoothly<br />
    /// - "instant": scrolling should happen instantly in a single jump<br />
    /// - "auto": scroll behavior is determined by the computed value of scroll-behavior<br />
    /// Defaults to "auto".
    /// </param>
    public void ScrollIntoView(string block = "start", string inline = "nearest", string behavior = "auto") => htmlElementJS.InvokeVoid("scrollIntoView", [block, inline, behavior]);

    #endregion
}
