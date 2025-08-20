using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>HTMLElement</i> interface represents any HTML element. Some elements directly implement this interface, while others implement it via an interface that inherits it.
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="DisposeAsync"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class HTMLElement(Task<IJSObjectReference> htmlElementTask) : HTMLElementBase(htmlElementTask), IHTMLElement {
    [AutoInterfaceVisibilityInternal]
    Task<IJSObjectReference> IHTMLElement.HTMLElementTask => htmlElementTask;

    /// <summary>
    /// Releases the JS instance for this HTML element.
    /// </summary>
    /// <returns></returns>
    public async ValueTask DisposeAsync() {
        DisposeEventTrigger();
        await (await htmlElementTask).DisposeTrySync();
    }


    #region HTMLElement

    /// <summary>
    /// Sets the keystroke which a user can press to jump to a given element.
    /// </summary>
    /// <remarks>
    /// Note: The HTMLElement.accessKey property is seldom used because of its multiple conflicts with already present key bindings in browsers.
    /// To work around this, browsers implement accesskey behavior if the keys are pressed with other "qualifying" keys (such as Alt + accesskey).
    /// </remarks>
    public ValueTask<string> AccessKey => GetAccessKey(default);

    /// <inheritdoc cref="AccessKey" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetAccessKey(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getAccessKey", cancellationToken);

    /// <inheritdoc cref="AccessKey" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAccessKey(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAccessKey", cancellationToken, [value]);

    /// <summary>
    /// Returns a string containing the element's browser-assigned access key (if any); otherwise it returns an empty string.
    /// </summary>
    public ValueTask<string> AccessKeyLabel => GetAccessKeyLabel(default);

    /// <inheritdoc cref="AccessKeyLabel" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetAccessKeyLabel(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getAccessKeyLabel", cancellationToken);


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
    public ValueTask<Dictionary<string, string>> AttributeStyleMap => GetAttributeStyleMap(default);

    /// <inheritdoc cref="AttributeStyleMap" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<Dictionary<string, string>> GetAttributeStyleMap(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<Dictionary<string, string>>("getAttributeStyleMap", cancellationToken);

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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAttributeStyleMap(string name, string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAttributeStyleMap", cancellationToken, [name, value]);

    /// <summary>
    /// Removes the given css property.
    /// </summary>
    /// <param name="name">css property name</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask RemoveAttributeStyleMap(string name, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("removeAttributeStyleMap", cancellationToken, [name]);


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
    public ValueTask<string> Autocapitalize => GetAutocapitalize(default);

    /// <inheritdoc cref="Autocapitalize" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetAutocapitalize(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getAutocapitalize", cancellationToken);

    /// <inheritdoc cref="Autocapitalize" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAutocapitalize(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAutocapitalize", cancellationToken, [value]);


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
    public ValueTask<bool> Autofocus => GetAutofocus(default);

    /// <inheritdoc cref="Autofocus" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetAutofocus(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<bool>("getAutofocus", cancellationToken);

    /// <inheritdoc cref="Autofocus" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAutofocus(bool value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAutofocus", cancellationToken, [value]);


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
    public ValueTask<string> ContentEditable => GetContentEditable(default);

    /// <inheritdoc cref="ContentEditable" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetContentEditable(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getContentEditable", cancellationToken);

    /// <inheritdoc cref="ContentEditable" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetContentEditable(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setContentEditable", cancellationToken, [value]);


    /// <summary>
    /// <para>Provides read/write access to custom data attributes (data-*) on elements. It exposes a map of strings (DOMStringMap) with an entry for each data-* attribute.</para>
    /// <para>
    /// The property name of a custom data attribute is the same as the HTML attribute without the data- prefix.
    /// Single dashes (-) are removed, and the next ASCII character after a removed dash is capitalized to form the property's camel-cased name.
    /// </para>
    /// <para>For writing or removing elements use <see cref="SetDataset"/> or <see cref="RemoveDataset"/>.</para>
    /// </summary>
    public ValueTask<Dictionary<string, string>> Dataset => GetDataset(default);

    /// <inheritdoc cref="Dataset" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<Dictionary<string, string>> GetDataset(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<Dictionary<string, string>>("getDataset", cancellationToken);

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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetDataset(string name, string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setDataset", cancellationToken, [name, value]);

    /// <summary>
    /// Removes the given data-attribute.
    /// </summary>
    /// <param name="name">data-attribute name</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask RemoveDataset(string name, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("removeDataset", cancellationToken, [name]);


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
    public ValueTask<string> Dir => GetDir(default);

    /// <inheritdoc cref="Dir" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetDir(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getDir", cancellationToken);

    /// <inheritdoc cref="Dir" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetDir(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setDir", cancellationToken, [value]);


    /// <summary>
    /// A boolean value indicating if the element can be dragged. It reflects the value of the draggable HTML global attribute.
    /// </summary>
    public ValueTask<bool> Draggable => GetDraggable(default);

    /// <inheritdoc cref="Draggable" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetDraggable(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<bool>("getDraggable", cancellationToken);

    /// <inheritdoc cref="Draggable" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetDraggable(bool value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setDraggable", cancellationToken, [value]);


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
    public ValueTask<string> EnterKeyHint => GetEnterKeyHint(default);

    /// <inheritdoc cref="EnterKeyHint" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetEnterKeyHint(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getEnterKeyHint", cancellationToken);

    /// <inheritdoc cref="EnterKeyHint" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetEnterKeyHint(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setEnterKeyHint", cancellationToken, [value]);


    /// <summary>
    /// Reflects the value of the element's hidden attribute.<br />
    /// true - The element is hidden.<br />
    /// false - The element is not hidden. This is the default value for the attribute.
    /// </summary>
    public ValueTask<bool> Hidden => GetHidden(default);

    /// <inheritdoc cref="Hidden" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetHidden(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<bool>("getHidden", cancellationToken);

    /// <inheritdoc cref="Hidden" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetHidden(bool value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setHidden", cancellationToken, [value]);


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
    public ValueTask<bool> Inert => GetInert(default);

    /// <inheritdoc cref="Inert" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetInert(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<bool>("getInert", cancellationToken);

    /// <inheritdoc cref="Inert" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetInert(bool value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setInert", cancellationToken, [value]);


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
    public ValueTask<string> InnerText => GetInnerText(default);

    /// <inheritdoc cref="InnerText" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetInnerText(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getInnerText", cancellationToken);

    /// <inheritdoc cref="InnerText" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetInnerText(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setInnerText", cancellationToken, [value]);


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
    public ValueTask<string> InputMode => GetInputMode(default);

    /// <inheritdoc cref="InputMode" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetInputMode(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getInputMode", cancellationToken);

    /// <inheritdoc cref="InputMode" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetInputMode(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setInputMode", cancellationToken, [value]);


    /// <summary>
    /// It is true if the contents of the element are editable; otherwise it returns false.
    /// </summary>
    public ValueTask<bool> IsContentEditable => GetIsContentEditable(default);

    /// <inheritdoc cref="IsContentEditable" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetIsContentEditable(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<bool>("getIsContentEditable", cancellationToken);


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
    public ValueTask<string> Lang => GetLang(default);

    /// <inheritdoc cref="Lang" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetLang(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getLang", cancellationToken);

    /// <inheritdoc cref="Lang" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetLang(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setLang", cancellationToken, [value]);


    /// <summary>
    /// <para>Returns the cryptographic number used once that is used by Content Security Policy to determine whether a given fetch will be allowed to proceed.</para>
    /// <para>In later implementations, elements only expose their nonce attribute to scripts (and not to side-channels like CSS attribute selectors).</para>
    /// </summary>
    public ValueTask<string> Nonce => GetNonce(default);

    /// <inheritdoc cref="Nonce" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetNonce(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getNonce", cancellationToken);

    /// <inheritdoc cref="Nonce" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetNonce(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setNonce", cancellationToken, [value]);


    /// <summary>
    /// <para>Returns the layout width of an element as an integer.</para>
    /// <para>
    /// Typically, offsetWidth is a measurement in pixels of the element's CSS width, including any borders, padding, and vertical scrollbars (if rendered).
    /// It does not include the width of pseudo-elements such as ::before or ::after.
    /// </para>
    /// <para>If the element is hidden (for example, by setting style.display on the element or one of its ancestors to "none"), then 0 is returned.</para>
    /// <para>Note: This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    public ValueTask<int> OffsetWidth => GetOffsetWidth(default);

    /// <inheritdoc cref="OffsetWidth" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetOffsetWidth(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<int>("getOffsetWidth", cancellationToken);


    /// <summary>
    /// <para>Returns the height of an element, including vertical padding and borders, as an integer.</para>
    /// <para>
    /// Typically, offsetHeight is a measurement in pixels of the element's CSS height, including any borders, padding, and horizontal scrollbars (if rendered).
    /// It does not include the height of pseudo-elements such as ::before or ::after. For the document body object, the measurement includes total linear content height instead of the element's CSS height.Floated elements extending below other linear content are ignored.
    /// </para>
    /// <para>If the element is hidden(for example, by setting style.display on the element or one of its ancestors to "none"), then 0 is returned.</para>
    /// <para>Note: This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    public ValueTask<int> OffsetHeight => GetOffsetHeight(default);

    /// <inheritdoc cref="OffsetHeight" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetOffsetHeight(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<int>("getOffsetHeight", cancellationToken);


    /// <summary>
    /// <para>Returns the number of pixels that the upper left corner of the current element is offset to the left within the HTMLElement.offsetParent node.</para>
    /// <para>For block-level elements, offsetTop, offsetLeft, offsetWidth, and offsetHeight describe the border box of an element relative to the offsetParent.</para>
    /// <para>
    /// However, for inline-level elements (such as span) that can wrap from one line to the next, offsetTop and offsetLeft describe the positions of the first border box
    /// (use Element.getClientRects() to get its width and height), while offsetWidth and offsetHeight describe the dimensions of the bounding border box(use Element.getBoundingClientRect() to get its position).
    /// Therefore, a box with the left, top, width and height of offsetLeft, offsetTop, offsetWidth and offsetHeight will not be a bounding box for a span with wrapped text.
    /// </para>
    /// </summary>
    public ValueTask<int> OffsetLeft => GetOffsetLeft(default);

    /// <inheritdoc cref="OffsetLeft" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetOffsetLeft(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<int>("getOffsetLeft", cancellationToken);


    /// <summary>
    /// Returns the distance from the outer border of the current element (including its margin) to the top padding edge of the offsetParent, the closest positioned ancestor element.
    /// </summary>
    public ValueTask<int> OffsetTop => GetOffsetTop(default);

    /// <inheritdoc cref="OffsetTop" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetOffsetTop(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<int>("getOffsetTop", cancellationToken);


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
    public ValueTask<IHTMLElement?> OffsetParent => GetOffsetParent(default);

    /// <inheritdoc cref="OffsetParent" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> GetOffsetParent(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await (await htmlElementTask).InvokeTrySync<IJSObjectReference?[]>("getOffsetParent", cancellationToken);
        if (singleReference[0] is IJSObjectReference htmlElementParent)
            return new HTMLElement(Task.FromResult(htmlElementParent));
        else
            return null;
    }


    /// <summary>
    /// <para>
    /// Returns the same value as HTMLElement.innerText.
    /// When used as a setter it replaces the whole current node with the given text (this differs from innerText, which replaces the content inside the current node).
    /// </para>
    /// <para>See <see cref="InnerText">HTMLElement.innerText</see> for more information and examples showing how both properties are used as getters.</para>
    /// </summary>
    public ValueTask<string> OuterText => GetOuterText(default);

    /// <inheritdoc cref="OuterText" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetOuterText(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getOuterText", cancellationToken);

    /// <inheritdoc cref="OuterText" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetOuterText(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setOuterText", cancellationToken, [value]);


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
    public ValueTask<string?> Popover => GetPopover(default);

    /// <inheritdoc cref="Popover" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetPopover(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getPopover", cancellationToken);

    /// <inheritdoc cref="Popover" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetPopover(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setPopover", cancellationToken, [value]);


    /// <summary>
    /// Represents a boolean value that controls the spell-checking hint. It is available on all HTML elements, though it doesn't affect all of them.
    /// It reflects the value of the spellcheck HTML global attribute.
    /// </summary>
    public ValueTask<bool> Spellcheck => GetSpellcheck(default);

    /// <inheritdoc cref="Spellcheck" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetSpellcheck(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<bool>("getSpellcheck", cancellationToken);

    /// <inheritdoc cref="Spellcheck" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetSpellcheck(bool value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setSpellcheck", cancellationToken, [value]);


    /// <summary>
    /// <para>JS-property: style.cssText</para>
    /// <para>Returns or sets the text of the element's inline style declaration only.</para>
    /// <para>To be able to set a stylesheet rule dynamically, see <see href="https://developer.mozilla.org/en-US/docs/Web/API/CSS_Object_Model/Using_dynamic_styling_information">Using dynamic styling information</see>.</para>
    /// <para>Not to be confused with stylesheet style-rule <see href="https://developer.mozilla.org/en-US/docs/Web/API/CSSRule/cssText">CSSRule.cssText</see>.</para>
    /// </summary>
    public ValueTask<string> Style => GetStyle(default);

    /// <inheritdoc cref="Style" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetStyle(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getStyle", cancellationToken);

    /// <inheritdoc cref="Style" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetStyle(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setStyle", cancellationToken, [value]);


    /// <summary>
    /// <para>
    /// Represents the tab order of the current element. Tab order is as follows:<br />
    /// 1. Elements with a positive tabIndex. Elements that have identical tabIndex values should be navigated in the order they appear. Navigation proceeds from the lowest tabIndex to the highest tabIndex.<br />
    /// 2. Elements that do not support the tabIndex attribute or support it and assign tabIndex to 0, in the order they appear.<br />
    /// Elements that are disabled do not participate in the tabbing order.
    /// </para>
    /// <para>Values don't need to be sequential, nor must they begin with any particular value. They may even be negative, though each browser trims very large values.</para>
    /// </summary>
    public ValueTask<long> TabIndex => GetTabIndex(default);

    /// <inheritdoc cref="TabIndex" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<long> GetTabIndex(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<long>("getTabIndex", cancellationToken);

    /// <inheritdoc cref="TabIndex" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetTabIndex(long value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setTabIndex", cancellationToken, [value]);


    /// <summary>
    /// Represents the title of the element: the text usually displayed in a 'tooltip' popup when the mouse is over the node.
    /// </summary>
    public ValueTask<string> Title => GetTitle(default);

    /// <inheritdoc cref="Title" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetTitle(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getTitle", cancellationToken);

    /// <inheritdoc cref="Title" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetTitle(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setTitle", cancellationToken, [value]);


    /// <summary>
    /// Indicates whether an element's attribute values and the values of its Text node children are to be translated when the page is localized, or whether to leave them unchanged.
    /// It reflects the value of the translate HTML global attribute.
    /// </summary>
    public ValueTask<bool> Translate => GetTranslate(default);

    /// <inheritdoc cref="Translate" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetTranslate(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<bool>("getTranslate", cancellationToken);

    /// <inheritdoc cref="Translate" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetTranslate(bool value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setTranslate", cancellationToken, [value]);


    // extra

    /// <summary>
    /// <para>htmlElement === document.activeElement;</para>
    /// <para>If true, the htmlElement has focus, otherwise false.</para>
    /// </summary>
    public ValueTask<bool> HasFocus => GetHasFocus(default);

    /// <inheritdoc cref="HasFocus" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetHasFocus(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<bool>("hasFocus", cancellationToken);


    // methods

    /// <summary>
    /// <para>Simulates a mouse click on an element.</para>
    /// <para>
    /// When click() is used with supported elements(such as an &lt;input&gt;), it fires the element's click event.
    /// This event then bubbles up to elements higher in the document tree (or event chain) and fires their click events.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Click(CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("click", cancellationToken);

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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Focus(bool preventScroll = false, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("focus", cancellationToken, [preventScroll]);

    /// <summary>
    /// Removes keyboard focus from the current element.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Blur(CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("blur", cancellationToken);

    /// <summary>
    /// <para>Shows a popover element (i.e. one that has a valid popover attribute) by adding it to the top layer.</para>
    /// <para>
    /// When <i>showPopover()</i> is called on an element with the popover attribute that is currently hidden, a beforetoggle event will be fired, followed by the popover showing, and then the toggle event firing.
    /// If the element is already showing, an error will be thrown.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ShowPopover(CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("showPopover", cancellationToken);

    /// <summary>
    /// <para>Hides a popover element (i.e. one that has a valid popover attribute) by removing it from the top layer and styling it with display: none.</para>
    /// <para>
    /// When <i>hidePopover()</i> is called on a showing element with the popover attribute, a beforetoggle event will be fired, followed by the popover being hidden, and then the toggle event firing.
    /// If the element is already hidden, an error is thrown.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask HidePopover(CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("hidePopover", cancellationToken);

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
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// <para>true if the popup is open after the call, and false otherwise.</para>
    /// <para>None(undefined) may be returned in older browser versions(see browser compatibility).</para>
    /// </returns>
    public async ValueTask<bool> TogglePopover(CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeTrySync<bool>("togglePopover", cancellationToken);

    /// <inheritdoc cref="TogglePopover(CancellationToken)" />
    /// <param name="force">
    /// <para>A boolean, which causes togglePopover() to behave like showPopover() or hidePopover(), except that it doesn't throw an exception if the popover is already in the target state.</para>
    /// <para>- If set to true, the popover is shown if it was initially hidden.If it was initially shown, nothing happens.</para>
    /// <para>- If set to false, the popover is hidden if it was initially shown. If it was initially hidden, nothing happens.</para>
    /// </param>
    /// <param name="cancellationToken"></param>
    public async ValueTask<bool> TogglePopover(bool force, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeTrySync<bool>("togglePopover", cancellationToken, [force]);


    // events

    private protected override void InvokeCommand(IJSObjectReference source, string command) => _onCommand?.Invoke(new HTMLElement(Task.FromResult(source)), command);
    private Action<IHTMLElement, string>? _onCommand;
    /// <summary>
    /// <para>
    /// Fires on an element that is controlled via a button with valid commandForElement and command values, whenever the button is interacted with (e.g., it is clicked).
    /// </para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - IHTMLElement <i>source</i>: An HTMLButtonElement representing the button that caused this invocation.<br />
    /// - string <i>command</i>: Representing the command value of the source button.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Note: Dispose the given IHTMLElement object when you are done with it.
    /// </remarks>
    public event Action<IHTMLElement, string> OnCommand {
        add {
            if (_onCommand == null)
                _ = ActivateJSEvent("activateOncommand").Preserve();
            _onCommand += value;
        }
        remove {
            _onCommand -= value;
            if (_onCommand == null)
                _ = DeactivateJSEvent("deactivateOncommand").Preserve();
        }
    }


    private protected override void InvokeDrag(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => _onDrag?.Invoke(new DragEvent(dropEffect, effectAllowed, types, WrapFiles(files)));
    private Action<DragEvent>? _onDrag;
    /// <summary>
    /// <para>
    /// Is fired every few hundred milliseconds as an element or text selection is being dragged by the user.<br />
    /// This event is cancelable and may bubble up to the Document and Window objects.
    /// </para>
    /// <para>The parameter holds the content of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/DragEvent/dataTransfer">DragEvent.dataTransfer</see> property,</para>
    /// </summary>
    public event Action<DragEvent> OnDrag {
        add {
            if (_onDrag == null)
                _ = ActivateJSEvent("activateOndrag").Preserve();
            _onDrag += value;
        }
        remove {
            _onDrag -= value;
            if (_onDrag == null)
                _ = DeactivateJSEvent("deactivateOndrag").Preserve();
        }
    }

    private protected override void InvokeDragStart(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => _onDragStart?.Invoke(new DragEvent(dropEffect, effectAllowed, types, WrapFiles(files)));
    private Action<DragEvent>? _onDragStart;
    /// <summary>
    /// <para>
    /// Is fired when the user starts dragging an element or text selection.<br />
    /// This event is cancelable and may bubble up to the Document and Window objects.
    /// </para>
    /// <para>The parameter holds the content of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/DragEvent/dataTransfer">DragEvent.dataTransfer</see> property,</para>
    /// </summary>
    public event Action<DragEvent> OnDragStart {
        add {
            if (_onDragStart == null)
                _ = ActivateJSEvent("activateOndragstart").Preserve();
            _onDragStart += value;
        }
        remove {
            _onDragStart -= value;
            if (_onDragStart == null)
                _ = DeactivateJSEvent("deactivateOndragstart").Preserve();
        }
    }

    private protected override void InvokeDragEnd(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => _onDragEnd?.Invoke(new DragEvent(dropEffect, effectAllowed, types, WrapFiles(files)));
    private Action<DragEvent>? _onDragEnd;
    /// <summary>
    /// <para>
    /// Is fired when a drag operation ends (by releasing a mouse button or hitting the escape key).<br />
    /// This event is cancelable and may bubble up to the Document and Window objects.
    /// </para>
    /// <para>The parameter holds the content of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/DragEvent/dataTransfer">DragEvent.dataTransfer</see> property,</para>
    /// </summary>
    public event Action<DragEvent> OnDragEnd {
        add {
            if (_onDragEnd == null)
                _ = ActivateJSEvent("activateOndragend").Preserve();
            _onDragEnd += value;
        }
        remove {
            _onDragEnd -= value;
            if (_onDragEnd == null)
                _ = DeactivateJSEvent("deactivateOndragend").Preserve();
        }
    }

    private protected override void InvokeDragEnter(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => _onDragEnter?.Invoke(new DragEvent(dropEffect, effectAllowed, types, WrapFiles(files)));
    private Action<DragEvent>? _onDragEnter;
    /// <summary>
    /// <para>
    /// Is fired when a dragged element or text selection enters a valid drop target.
    /// The target object is the immediate user selection (the element directly indicated by the user as the drop target), or the &lt;body&gt; element.<br />
    /// This event is cancelable and may bubble up to the Document and Window objects.
    /// </para>
    /// <para>The parameter holds the content of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/DragEvent/dataTransfer">DragEvent.dataTransfer</see> property,</para>
    /// </summary>
    public event Action<DragEvent> OnDragEnter {
        add {
            if (_onDragEnter == null)
                _ = ActivateJSEvent("activateOndragenter").Preserve();
            _onDragEnter += value;
        }
        remove {
            _onDragEnter -= value;
            if (_onDragEnter == null)
                _ = DeactivateJSEvent("deactivateOndragenter").Preserve();
        }
    }

    private protected override void InvokeDragLeave(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => _onDragLeave?.Invoke(new DragEvent(dropEffect, effectAllowed, types, WrapFiles(files)));
    private Action<DragEvent>? _onDragLeave;
    /// <summary>
    /// <para>
    /// Is fired when a dragged element or text selection leaves a valid drop target.<br />
    /// This event is not cancelable and may bubble up to the Document and Window objects.
    /// </para>
    /// <para>The parameter holds the content of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/DragEvent/dataTransfer">DragEvent.dataTransfer</see> property,</para>
    /// </summary>
    public event Action<DragEvent> OnDragLeave {
        add {
            if (_onDragLeave == null)
                _ = ActivateJSEvent("activateOndragleave").Preserve();
            _onDragLeave += value;
        }
        remove {
            _onDragLeave -= value;
            if (_onDragLeave == null)
                _ = DeactivateJSEvent("deactivateOndragleave").Preserve();
        }
    }

    private protected override void InvokeDragOver(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => _onDragOver?.Invoke(new DragEvent(dropEffect, effectAllowed, types, WrapFiles(files)));
    private Action<DragEvent>? _onDragOver;
    /// <summary>
    /// <para>
    /// Is fired when an element or text selection is being dragged over a valid drop target (every few hundred milliseconds).<br />
    /// This event is cancelable and may bubble up to the Document and Window objects.
    /// </para>
    /// <para>The parameter holds the content of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/DragEvent/dataTransfer">DragEvent.dataTransfer</see> property,</para>
    /// </summary>
    public event Action<DragEvent> OnDragOver {
        add {
            if (_onDragOver == null)
                _ = ActivateJSEvent("activateOndragover").Preserve();
            _onDragOver += value;
        }
        remove {
            _onDragOver -= value;
            if (_onDragOver == null)
                _ = DeactivateJSEvent("deactivateOndragover").Preserve();
        }
    }

    private protected override void InvokeDrop(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => _onDrop?.Invoke(new DragEvent(dropEffect, effectAllowed, types, WrapFiles(files)));
    private Action<DragEvent>? _onDrop;
    /// <summary>
    /// <para>
    /// Is fired when an element or text selection is dropped on a valid drop target.
    /// To ensure that the drop event always fires as expected, you should always include a preventDefault() call in the part of your code which handles the dragover event.<br />
    /// This event is cancelable and may bubble up to the Document and Window objects.
    /// </para>
    /// <para>The parameter holds the content of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/DragEvent/dataTransfer">DragEvent.dataTransfer</see> property,</para>
    /// </summary>
    public event Action<DragEvent> OnDrop {
        add {
            if (_onDrop == null)
                _ = ActivateJSEvent("activateOndrop").Preserve();
            _onDrop += value;
        }
        remove {
            _onDrop -= value;
            if (_onDrop == null)
                _ = DeactivateJSEvent("deactivateOndrop").Preserve();
        }
    }

    private static IFile[] WrapFiles(IJSObjectReference[] files) {
        File[] result = new File[files.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new File(files[i]);
        return result;
    }

    #endregion


    #region Node/Element

    /// <summary>
    /// Returns a live collection of all attribute nodes registered to the specified node.
    /// It is a NamedNodeMap, not an Array, so it has no Array methods and the Attr nodes' indexes may differ among browsers.
    /// To be more specific, attributes is a key/value pair of strings that represents any information regarding that attribute.
    /// </summary>
    public ValueTask<Dictionary<string, string>> Attributes => GetAttributes(default);

    /// <inheritdoc cref="Attributes" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<Dictionary<string, string>> GetAttributes(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<Dictionary<string, string>>("getAttributes", cancellationToken);


    /// <summary>
    /// <para>Returns a live DOMTokenList collection of the class attributes of the element. This can then be used to manipulate the class list.</para>
    /// <üara>Using classList is a convenient alternative to accessing an element's list of classes as a space-delimited string via <i>element.className</i>.</üara>
    /// </summary>
    public ValueTask<string[]> ClassList => GetClassList(default);

    /// <inheritdoc cref="ClassList" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string[]> GetClassList(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string[]>("getClassList", cancellationToken);


    /// <summary>
    /// Gets/Sets the value of the class attribute of the specified element.
    /// </summary>
    public ValueTask<string> ClassName => GetClassName(default);

    /// <inheritdoc cref="ClassName" />
    /// <param name="cancellationToken"></param>
    /// <returns>A string variable representing the class or space-separated classes of the current element.</returns>
    public async ValueTask<string> GetClassName(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getClassName", cancellationToken);

    /// <inheritdoc cref="ClassName" />
    /// <param name="value">A string variable representing the class or space-separated classes of the current element.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetClassName(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setClassName", cancellationToken, [value]);


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
    public ValueTask<int> ClientWidth => GetClientWidth(default);

    /// <inheritdoc cref="ClientWidth" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetClientWidth(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<int>("getClientWidth", cancellationToken);

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
    public ValueTask<int> ClientHeight => GetClientHeight(default);

    /// <inheritdoc cref="ClientHeight" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetClientHeight(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<int>("getClientHeight", cancellationToken);

    /// <summary>
    /// <para>
    /// The width of the left border of an element in pixels.
    /// It includes the width of the vertical scrollbar if the text direction of the element is right-to-left and if there is an overflow causing a left vertical scrollbar to be rendered.
    /// clientLeft does not include the left margin or the left padding. clientLeft is read-only.
    /// </para>
    /// <para>Note: This property will round the value to an integer.If you need a fractional value, use element.getBoundingClientRect().</para>
    /// <para>Note: When an element has display: inline, clientLeft returns 0 regardless of the element's border.</para>
    /// </summary>
    public ValueTask<int> ClientLeft => GetClientLeft(default);

    /// <inheritdoc cref="ClientLeft" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetClientLeft(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<int>("getClientLeft", cancellationToken);

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
    public ValueTask<int> ClientTop => GetClientTop(default);

    /// <inheritdoc cref="ClientTop" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetClientTop(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<int>("getClientTop", cancellationToken);


    /// <summary>
    /// <para>Provides the "effective" CSS zoom of an element, taking into account the zoom applied to the element and all its parent elements.</para>
    /// <para>
    /// The value calculated by multiplying the CSS zoom values of the element and all of its parents.
    /// For example, if three elements with zoom values of 2, 1.5, and 3, are nested within each other, the most deeply nested element will have a currentCSSZoom value of 9.
    /// If the element doesn't have a CSS box, for example because display: none is set on the element or one of its parents, then the currentCSSZoom is set to 1.
    /// </para>
    /// <para>
    /// Note that some methods, such as Element.getBoundingClientRect(), return dimensions and position that are relative to the viewport, and hence include the effects of CSS zoom.
    /// Other properties and methods return values that are relative to the element itself, and do not include the effects of zooming.
    /// These include, for example, client* properties such as Element.clientHeight, scroll*() methods like Element.scroll(), and offset* properties such as HTMLElement.offsetHeight.
    /// The currentCSSZoom property can be used to scale these values to adjust for the effects of zooming.
    /// </para>
    /// </summary>
    public ValueTask<double> CurrentCSSZoom => GetCurrentCSSZoom(default);

    /// <inheritdoc cref="CurrentCSSZoom" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<double> GetCurrentCSSZoom(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<double>("getCurrentCSSZoom", cancellationToken);


    /// <summary>
    /// <para>Represents the element's identifier, reflecting the id global attribute.</para>
    /// <para>If the id value is not the empty string, it must be unique in a document.</para>
    /// <para>The id is often used with getElementById() to retrieve a particular element. Another common case is to use an element's ID as a selector when styling the document with CSS.</para>
    /// </summary>
    public ValueTask<string> Id => GetId(default);

    /// <inheritdoc cref="Id" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetId(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getId", cancellationToken);

    /// <inheritdoc cref="Id" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetId(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setId", cancellationToken, [value]);


    /// <summary>
    /// A boolean indicating whether the node is connected (directly or indirectly) to a Document object.
    /// </summary>
    public ValueTask<bool> IsConnected => GetIsConnected(default);

    /// <inheritdoc cref="IsConnected" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetIsConnected(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<bool>("getIsConnected", cancellationToken);


    /// <summary>
    /// <para>Gets/Sets the HTML or XML markup contained within the element.</para>
    /// <para>To insert the HTML into the document rather than replace the contents of an element, use the method insertAdjacentHTML().</para>
    /// </summary>
    public ValueTask<string> InnerHTML => GetInnerHTML(default);

    /// <inheritdoc cref="InnerHTML" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetInnerHTML(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getInnerHTML", cancellationToken);

    /// <inheritdoc cref="InnerHTML" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetInnerHTML(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setInnerHTML", cancellationToken, [value]);


    /// <summary>
    /// <para>
    /// Gets the serialized HTML fragment describing the element including its descendants.
    /// It can also be set to replace the element with nodes parsed from the given string.
    /// </para>
    /// <para>To only obtain the HTML representation of the contents of an element, or to replace the contents of an element, use the innerHTML property instead.</para>
    /// </summary>
    public ValueTask<string> OuterHTML => GetOuterHTML(default);

    /// <inheritdoc cref="OuterHTML" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetOuterHTML(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getOuterHTML", cancellationToken);

    /// <inheritdoc cref="OuterHTML" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetOuterHTML(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setOuterHTML", cancellationToken, [value]);


    /// <summary>
    /// Represents the part identifier(s) of the element (i.e., set using the part attribute), returned as a DOMTokenList. These can be used to style parts of a shadow DOM, via the ::part pseudo-element.
    /// </summary>
    public ValueTask<string[]> Part => GetPart(default);

    /// <inheritdoc cref="Part" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string[]> GetPart(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string[]>("getPart", cancellationToken);


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
    public ValueTask<int> ScrollWidth => GetScrollWidth(default);

    /// <inheritdoc cref="ScrollWidth" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetScrollWidth(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<int>("getScrollWidth", cancellationToken);

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
    public ValueTask<int> ScrollHeight => GetScrollHeight(default);

    /// <inheritdoc cref="ScrollHeight" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetScrollHeight(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<int>("getScrollHeight", cancellationToken);

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
    public ValueTask<int> ScrollLeft => GetScrollLeft(default);

    /// <inheritdoc cref="ScrollLeft" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetScrollLeft(CancellationToken cancellationToken) => (int)await (await htmlElementTask).InvokeTrySync<double>("getScrollLeft", cancellationToken);

    /// <inheritdoc cref="ScrollLeft" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetScrollLeft(int value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setScrollLeft", cancellationToken, [value]);

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
    public ValueTask<int> ScrollTop => GetScrollTop(default);

    /// <inheritdoc cref="ScrollTop" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetScrollTop(CancellationToken cancellationToken) => (int)await (await htmlElementTask).InvokeTrySync<double>("getScrollTop", cancellationToken);

    /// <inheritdoc cref="ScrollTop" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetScrollTop(int value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setScrollTop", cancellationToken, [value]);


    /// <summary>
    /// Returns the name of the shadow DOM slot the element is inserted in.<br />
    /// A slot is a placeholder inside a web component that users can fill with their own markup (see Using templates and slots for more information).
    /// </summary>
    public ValueTask<string> Slot => GetSlot(default);

    /// <inheritdoc cref="Slot" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetSlot(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getSlot", cancellationToken);

    /// <inheritdoc cref="Slot" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetSlot(string value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setSlot", cancellationToken, [value]);


    /// <summary>
    /// The local part of the qualified name of an element.
    /// </summary>
    public ValueTask<string> LocalName => GetLocalName(default);

    /// <inheritdoc cref="LocalName" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetLocalName(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getLocalName", cancellationToken);

    /// <summary>
    /// The namespace URI of the element, or null if the element is not in a namespace.
    /// </summary>
    public ValueTask<string?> NamespaceURI => GetNamespaceURI(default);

    /// <inheritdoc cref="NamespaceURI" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetNamespaceURI(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getNamespaceURI", cancellationToken);

    /// <summary>
    /// The namespace prefix of the specified element, or null if no prefix is specified.
    /// </summary>
    public ValueTask<string?> Prefix => GetPrefix(default);

    /// <inheritdoc cref="Prefix" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetPrefix(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getPrefix", cancellationToken);

    /// <summary>
    /// <para>The absolute base URL of the document containing the node.</para>
    /// <para>
    /// The base URL is used to resolve relative URLs when the browser needs to obtain an absolute URL,
    /// for example when processing the HTML &lt;img&gt; element's src attribute or the xlink:href Deprecated or href attributes in SVG.
    /// </para>
    /// <para>Although this property is read-only, its value is determined by an algorithm each time the property is accessed, and may change if the conditions changed.</para>
    /// <para>
    /// The base URL is determined as follows:<br />
    /// 1. By default, the base URL is the location of the document (as determined by window.location).<br />
    /// 2. If it is an HTML Document and there is a &lt;Base&gt; element in the document, the href value of the first Base element with such an attribute is used instead.
    /// </para>
    /// </summary>
    public ValueTask<string> BaseURI => GetBaseURI(default);

    /// <inheritdoc cref="BaseURI" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetBaseURI(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getBaseURI", cancellationToken);

    /// <summary>
    /// <para>The tag name of the element on which it's called.</para>
    /// <para>
    /// For example, if the element is an &lt;img&gt;, its tagName property is IMG (for HTML documents; it may be cased differently for XML/XHTML documents).
    /// Note: You can use the localName property to access the Element's local name — which for the case in the example is img (lowercase).
    /// </para>
    /// </summary>
    public ValueTask<string> TagName => GetTagName(default);

    /// <inheritdoc cref="TagName" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetTagName(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getTagName", cancellationToken);

    /// <summary>
    /// <para>The name of the current node as a string.</para>
    /// <para>
    /// Values for the different types of nodes are:<br />
    /// - Attr: The value of Attr.name, that is the qualified name of the attribute<br />
    /// - CDATASection: The string "#cdata-section"<br />
    /// - Comment: The string "#comment"<br />
    /// - Document: The string "#document"<br />
    /// - DocumentFragment: The string "#document-fragment"<br />
    /// - DocumentType: The value of DocumentType.name<br />
    /// - Element: The value of Element.tagName, that is the uppercase name of the element tag if an HTML element, or the lowercase element tag if an XML element (like a SVG or MathML element)<br />
    /// - ProcessingInstruction: The value of ProcessingInstruction.target<br />
    /// - Text: The string "#text"
    /// </para>
    /// </summary>
    public ValueTask<string> NodeName => GetNodeName(default);

    /// <inheritdoc cref="NodeName" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetNodeName(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string>("getNodeName", cancellationToken);

    /// <summary>
    /// <para>An integer that identifies what the node is. It distinguishes different kind of nodes from each other, such as elements, text and comments.</para>
    /// <para>
    /// Possible values are:<br />
    /// - 1: ELEMENT_NODE - An Element node like &lt;p&gt; or &lt;div&gt;.<br />
    /// - 2: ATTRIBUTE_NODE - An Attribute of an Element.<br />
    /// - 3: TEXT_NODE - The actual Text inside an Element or Attr.<br />
    /// - 4: CDATA_SECTION_NODE - A CDATASection, such as &lt;!CDATA[[ … ]]&gt;<br />
    /// - 7: PROCESSING_INSTRUCTION_NODE - A ProcessingInstruction of an XML document, such as &lt;?xml-stylesheet … ?&gt;.<br />
    /// - 8: COMMENT_NODE - A Comment node, such as &lt;!-- … --&gt;.<br />
    /// - 9: DOCUMENT_NODE - A Document node.<br />
    /// - 10: DOCUMENT_TYPE_NODE - A DocumentType node, such as &lt;!doctype html&gt;.<br />
    /// - 11: DOCUMENT_FRAGMENT_NODE - A DocumentFragment node.
    /// </para>
    /// <para>
    /// The following constants have been deprecated and are not in use anymore:<br />
    /// - 5: ENTITY_REFERENCE_NODE<br />
    /// - 6: ENTITY_NODE<br />
    /// - 12: NOTATION_NODE
    /// </para>
    /// </summary>
    public ValueTask<int> NodeType => GetNodeType(default);

    /// <inheritdoc cref="NodeType" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetNodeType(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<int>("getNodeType", cancellationToken);


    // properties - Tree-nodes

    /// <summary>
    /// Returns the number of child elements of this element.
    /// </summary>
    public ValueTask<int> ChildElementCount => GetChildElementCount(default);

    /// <inheritdoc cref="ChildElementCount" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetChildElementCount(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<int>("getChildElementCount", cancellationToken);


    /// <summary>
    /// <para>Returns a live HTMLCollection which contains all of the child elements of the element upon which it was called.</para>
    /// <üara>Element.children includes only element nodes.To get all child nodes, including non-element nodes like text and comment nodes, use Node.childNodes.</üara>
    /// </summary>
    public ValueTask<IHTMLElement[]> Children => GetChildren(default);

    /// <inheritdoc cref="Children" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement[]> GetChildren(CancellationToken cancellationToken) {
        IJSObjectReference[] children = await (await htmlElementTask).InvokeTrySync<IJSObjectReference[]>("getChildren", cancellationToken);

        HTMLElement[] result = new HTMLElement[children.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElement(Task.FromResult(children[i]));
        return result;
    }


    /// <summary>
    /// <para>Returns an element's first child Element, or null if there are no child elements.</para>
    /// <para>It includes only element nodes.</para>
    /// </summary>
    public ValueTask<IHTMLElement?> FirstElementChild => GetFirstElementChild(default);

    /// <inheritdoc cref="FirstElementChild" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> GetFirstElementChild(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await (await htmlElementTask).InvokeTrySync<IJSObjectReference?[]>("getFirstElementChild", cancellationToken);
        if (singleReference[0] is IJSObjectReference child)
            return new HTMLElement(Task.FromResult(child));
        else
            return null;
    }


    /// <summary>
    /// <para>Returns an element's last child Element, or null if there are no child elements.</para>
    /// <para>It includes only element nodes.</para>
    /// </summary>
    public ValueTask<IHTMLElement?> LastElementChild => GetLastElementChild(default);

    /// <inheritdoc cref="LastElementChild" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> GetLastElementChild(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await (await htmlElementTask).InvokeTrySync<IJSObjectReference?[]>("getLastElementChild", cancellationToken);
        if (singleReference[0] is IJSObjectReference child)
            return new HTMLElement(Task.FromResult(child));
        else
            return null;
    }


    /// <summary>
    /// Returns the Element immediately prior to the specified one in its parent's children list, or null if the specified element is the first one in the list.
    /// </summary>
    public ValueTask<IHTMLElement?> PreviousElementSibling => GetPreviousElementSibling(default);

    /// <inheritdoc cref="PreviousElementSibling" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> GetPreviousElementSibling(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await (await htmlElementTask).InvokeTrySync<IJSObjectReference?[]>("getPreviousElementSibling", cancellationToken);
        if (singleReference[0] is IJSObjectReference sibling)
            return new HTMLElement(Task.FromResult(sibling));
        else
            return null;
    }


    /// <summary>
    /// Returns the element immediately following the specified one in its parent's children list, or null if the specified element is the last one in the list.
    /// </summary>
    public ValueTask<IHTMLElement?> NextElementSibling => GetNextElementSibling(default);

    /// <inheritdoc cref="NextElementSibling" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> GetNextElementSibling(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await (await htmlElementTask).InvokeTrySync<IJSObjectReference?[]>("getNextElementSibling", cancellationToken);
        if (singleReference[0] is IJSObjectReference sibling)
            return new HTMLElement(Task.FromResult(sibling));
        else
            return null;
    }


    /// <summary>
    /// Returns the DOM node's parent Element, or null if the node either has no parent,or its parent isn't a DOM Element.
    /// </summary>
    public ValueTask<IHTMLElement?> ParentElement => GetParentElement(default);

    /// <inheritdoc cref="ParentElement" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> GetParentElement(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await (await htmlElementTask).InvokeTrySync<IJSObjectReference?[]>("getParentElement", cancellationToken);
        if (singleReference[0] is IJSObjectReference parent)
            return new HTMLElement(Task.FromResult(parent));
        else
            return null;
    }


    // properties - ARIA

    /// <summary>
    /// <para>Reflects the value of the aria-atomic attribute, which indicates whether assistive technologies will present all, or only parts of, the changed region based on the change notifications defined by the aria-relevant attribute.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "false": Assistive technologies will present only the changed node or nodes.<br />
    /// - "true": Assistive technologies will present the entire changed region as a whole, including the author-defined label if one exists.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaAtomic => GetAriaAtomic(default);

    /// <inheritdoc cref="AriaAtomic" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaAtomic(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaAtomic", cancellationToken);

    /// <inheritdoc cref="AriaAtomic" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaAtomic(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaAtomic", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-autocomplete attribute, which indicates whether inputting text could trigger display of one or more predictions of the user's intended value for a combobox, searchbox, or textbox and specifies how predictions would be presented if they were made.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "inline": When a user is providing input, text suggesting one way to complete the provided input may be dynamically inserted after the caret.<br />
    /// - "list": When a user is providing input, an element containing a collection of values that could complete the provided input may be displayed.<br />
    /// - "both": When a user is providing input, an element containing a collection of values that could complete the provided input may be displayed. If displayed, one value in the collection is automatically selected, and the text needed to complete the automatically selected value appears after the caret in the input.<br />
    /// - "none": When a user is providing input, there is no display of an automatic suggestion that attempts to predict how the user intends to complete the input.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaAutoComplete => GetAriaAutoComplete(default);

    /// <inheritdoc cref="AriaAutoComplete" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaAutoComplete(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaAutoComplete", cancellationToken);

    /// <inheritdoc cref="AriaAutoComplete" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaAutoComplete(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaAutoComplete", cancellationToken, [value]);


    /// <summary>
    /// Reflects the value of the aria-braillelabel attribute, which defines the ARIA braille label of the element.
    /// This element label may be used by assistive technologies that can present content in braille, but should only be set if a braille-specific label would improve the user experience.
    /// The aria-braillelabel contains additional information about when the property should be set.
    /// </summary>
    public ValueTask<string?> AriaBrailleLabel => GetAriaBrailleLabel(default);

    /// <inheritdoc cref="AriaBrailleLabel" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaBrailleLabel(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaBrailleLabel", cancellationToken);

    /// <inheritdoc cref="AriaBrailleLabel" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaBrailleLabel(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaBrailleLabel", cancellationToken, [value]);


    /// <summary>
    /// Reflects the value of the aria-brailleroledescription attribute, which defines the ARIA braille role description of the element.
    /// This property may be used to provide an abbreviated version of the aria-roledescription value.
    /// It should only be used if aria-roledescription is present and in the rare case where it is too verbose for braille.
    /// The aria-brailleroledescription contains additional information about when the property should be set.
    /// </summary>
    public ValueTask<string?> AriaBrailleRoleDescription => GetAriaBrailleRoleDescription(default);

    /// <inheritdoc cref="AriaBrailleRoleDescription" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaBrailleRoleDescription(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaBrailleRoleDescription", cancellationToken);

    /// <inheritdoc cref="AriaBrailleRoleDescription" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaBrailleRoleDescription(string? value, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeVoidTrySync("setAriaBrailleRoleDescription", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-busy attribute, which indicates whether an element is being modified, as assistive technologies may want to wait until the modifications are complete before exposing them to the user.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "true": The element is being updated.<br />
    /// - "false": There are no expected updates for the element.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaBusy => GetAriaBusy(default);

    /// <inheritdoc cref="AriaBusy" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaBusy(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaBusy", cancellationToken);

    /// <inheritdoc cref="AriaBusy" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaBusy(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaBusy", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-checked attribute, which indicates the current "checked" state of checkboxes, radio buttons, and other widgets that have a checked state.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "true": The element is checked.<br />
    /// - "mixed": Indicates a mixed mode value for a tri-state checkbox or menuitemcheckbox.<br />
    /// - "false": There are no expected updates for the element.<br />
    /// - "undefined": The element does not support being checked.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaChecked => GetAriaChecked(default);

    /// <inheritdoc cref="AriaChecked" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaChecked(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaChecked", cancellationToken);

    /// <inheritdoc cref="AriaChecked" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaChecked(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaChecked", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-colcount attribute, which defines the number of columns in a table, grid, or treegrid.</para>
    /// <para>Value is a string which contains an integer.</para>
    /// </summary>
    public ValueTask<string?> AriaColCount => GetAriaColCount(default);

    /// <inheritdoc cref="AriaColCount" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaColCount(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaColCount", cancellationToken);

    /// <inheritdoc cref="AriaColCount" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaColCount(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaColCount", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-colindex attribute, which defines an element's column index or position with respect to the total number of columns within a table, grid, or treegrid.</para>
    /// <para>Value is a string which contains an integer.</para>
    /// </summary>
    public ValueTask<string?> AriaColIndex => GetAriaColIndex(default);

    /// <inheritdoc cref="AriaColIndex" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaColIndex(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaColIndex", cancellationToken);

    /// <inheritdoc cref="AriaColIndex" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaColIndex(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaColIndex", cancellationToken, [value]);


    /// <summary>
    /// Reflects the value of the aria-colindextext attribute, which defines a human readable text alternative of aria-colindex.
    /// </summary>
    public ValueTask<string?> AriaColIndexText => GetAriaColIndexText(default);

    /// <inheritdoc cref="AriaColIndexText" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaColIndexText(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaColIndexText", cancellationToken);

    /// <inheritdoc cref="AriaColIndexText" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaColIndexText(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaColIndexText", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-colspan attribute, which defines the number of columns spanned by a cell or gridcell within a table, grid, or treegrid.</para>
    /// <para>Value is a string which contains an integer.</para>
    /// </summary>
    public ValueTask<string?> AriaColSpan => GetAriaColSpan(default);

    /// <inheritdoc cref="AriaColSpan" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaColSpan(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaColSpan", cancellationToken);

    /// <inheritdoc cref="AriaColSpan" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaColSpan(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaColSpan", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-current attribute, which indicates the element that represents the current item within a container or set of related elements.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "page": Represents the current page within a set of pages.<br />
    /// - "step": Represents the current step within a process.<br />
    /// - "location": Represents the current location, for example the current page in a breadcrumbs hierarchy.<br />
    /// - "date": Represents the current date within a collection of dates.<br />
    /// - "time": Represents the current time within a set of times.<br />
    /// - "true": Represents the current item within a set.<br />
    /// - "false": Does not represent the current item within a set.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaCurrent => GetAriaCurrent(default);

    /// <inheritdoc cref="AriaCurrent" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaCurrent(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaCurrent", cancellationToken);

    /// <inheritdoc cref="AriaCurrent" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaCurrent(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaCurrent", cancellationToken, [value]);


    /// <summary>
    /// Reflects the value of the aria-description attribute, which defines a string value that describes or annotates the current element.
    /// </summary>
    public ValueTask<string?> AriaDescription => GetAriaDescription(default);

    /// <inheritdoc cref="AriaDescription" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaDescription(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaDescription", cancellationToken);

    /// <inheritdoc cref="AriaDescription" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaDescription(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaDescription", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-disabled attribute, which indicates that the element is perceivable but disabled, so it is not editable or otherwise operable.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "true": The element and all focusable descendants are disabled, but perceivable, and their values cannot be changed by the user.<br />
    /// - "false": The element is enabled.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaDisabled => GetAriaDisabled(default);

    /// <inheritdoc cref="AriaDisabled" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaDisabled(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaDisabled", cancellationToken);

    /// <inheritdoc cref="AriaDisabled" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaDisabled(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaDisabled", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-expanded attribute, which indicates whether a grouping element owned or controlled by this element is expanded or collapsed.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "true": The grouping element this element owns or controls is expanded.<br />
    /// - "false": The grouping element this element owns or controls is collapsed.<br />
    /// - "undefined": The element does not own or control a grouping element that is expandable.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaExpanded => GetAriaExpanded(default);

    /// <inheritdoc cref="AriaExpanded" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaExpanded(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaExpanded", cancellationToken);

    /// <inheritdoc cref="AriaExpanded" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaExpanded(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaExpanded", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-haspopup attribute, which indicates the availability and type of interactive popup element, such as menu or dialog, that can be triggered by an element.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "false": The element does not have a popup.<br />
    /// - "true": The element has a popup that is a menu.<br />
    /// - "menu":The element has a popup that is a menu. <br />
    /// - "listbox": The element has a popup that is a listbox.<br />
    /// - "tree": The element has a popup that is a tree.<br />
    /// - "grid": The element has a popup that is a grid.<br />
    /// - "dialog": The element has a popup that is a dialog.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaHasPopup => GetAriaHasPopup(default);

    /// <inheritdoc cref="AriaHasPopup" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaHasPopup(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaHasPopup", cancellationToken);

    /// <inheritdoc cref="AriaHasPopup" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaHasPopup(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaHasPopup", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-hidden) attribute, which indicates whether the element is exposed to an accessibility API.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "true": The element is hidden from the accessibility API.<br />
    /// - "false": The element is exposed to the accessibility API as if it were rendered.<br />
    /// - "undefined": The element's hidden state is determined by the user agent based on whether it is rendered.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaHidden => GetAriaHidden(default);

    /// <inheritdoc cref="Hidden" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaHidden(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaHidden", cancellationToken);

    /// <inheritdoc cref="AriaHidden" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaHidden(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaHidden", cancellationToken, [value]);


    /// <summary>
    /// <para>
    /// Reflects the value of the aria-invalid attribute.
    /// Relevant for the application, checkbox, combobox, gridcell, listbox, radiogroup, slider, spinbutton, textbox, and tree roles,
    /// it indicates to the accessibility API whether the entered value does not conform to the format expected by the application.
    /// </para>
    /// <para>
    /// If the attribute is not present, or is set to the empty string, assistive technology will treat the value as if it were set to false.
    /// If the attribute is present but set to a value other than false, grammar, spelling or the empty string (""), assistive technology treats the value as true.
    /// The property reflects the attribute value as set, not as handled by assistive technology.
    /// </para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "true": The element is invalid.<br />
    /// - "false": The element is not in an invalid state.<br />
    /// - "grammar": The element is in an invalid state because grammatical error was detected.<br />
    /// - "spelling": The element is in an invalid state because spelling error was detected.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaInvalid => GetAriaInvalid(default);

    /// <inheritdoc cref="AriaInvalid" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaInvalid(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaInvalid", cancellationToken);

    /// <inheritdoc cref="AriaInvalid" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaInvalid(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaInvalid", cancellationToken, [value]);


    /// <summary>
    /// Reflects the value of the aria-keyshortcuts attribute, which indicates keyboard shortcuts that an author has implemented to activate or give focus to an element.
    /// </summary>
    public ValueTask<string?> AriaKeyShortcuts => GetAriaKeyShortcuts(default);

    /// <inheritdoc cref="AriaKeyShortcuts" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaKeyShortcuts(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaKeyShortcuts", cancellationToken);

    /// <inheritdoc cref="AriaKeyShortcuts" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaKeyShortcuts(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaKeyShortcuts", cancellationToken, [value]);


    /// <summary>
    /// Reflects the value of the aria-label attribute, which defines a string value that labels the current element.
    /// </summary>
    public ValueTask<string?> AriaLabel => GetAriaLabel(default);

    /// <inheritdoc cref="AriaLabel" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaLabel(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaLabel", cancellationToken);

    /// <inheritdoc cref="AriaLabel" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaLabel(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaLabel", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-level attribute, which defines the hierarchical level of an element within a structure.</para>
    /// <para>Note: Where possible use an HTML h1 or other correct heading level as these have built in semantics and do not require ARIA attributes.</para>
    /// <para>Value is a string containing an integer.</para>
    /// </summary>
    public ValueTask<string?> AriaLevel => GetAriaLevel(default);

    /// <inheritdoc cref="AriaLevel" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaLevel(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaLevel", cancellationToken);

    /// <inheritdoc cref="AriaLevel" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaLevel(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaLevel", cancellationToken, [value]);


    /// <summary>
    /// <para>
    /// Reflects the value of the aria-live attribute, which indicates that an element will be updated,
    /// and describes the types of updates the user agents, assistive technologies, and user can expect from the live region.
    /// </para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "assertive": Indicates that updates to the region have the highest priority and should be presented to the user immediately.<br />
    /// - "off": Indicates that updates to the region should not be presented to the user unless the user is currently focused on that region.<br />
    /// - "polite": Indicates that updates to the region should be presented at the next graceful opportunity, such as at the end of speaking the current sentence or when the user pauses typing.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaLive => GetAriaLive(default);

    /// <inheritdoc cref="AriaLive" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaLive(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaLive", cancellationToken);

    /// <inheritdoc cref="AriaLive" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaLive(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaLive", cancellationToken, [value]);


    /// <summary>
    /// <para>
    /// Reflects the value of the aria-modal attribute, which indicates whether an element is modal when displayed.
    /// Applying the aria-modal property to an element with role="dialog" replaces the technique of using aria-hidden on the background for informing assistive technologies that content outside a dialog is inert.
    /// </para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "true": The element is modal.<br />
    /// - "false": The element is not modal.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaModal => GetAriaModal(default);

    /// <inheritdoc cref="AriaModal" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaModal(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaModal", cancellationToken);

    /// <inheritdoc cref="AriaModal" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaModal(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaModal", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-multiline attribute, which indicates whether a text box accepts multiple lines of input or only a single line.</para>
    /// <para>Note: Where possible use an HTML &lt;input&gt; element with type="text" or a &lt;textarea&gt; as these have built in semantics and do not require ARIA attributes.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "true": This is a multi-line text box.<br />
    /// - "false": This is a single-line text box.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaMultiline => GetAriaMultiline(default);

    /// <inheritdoc cref="AriaMultiline" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaMultiline(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaMultiline", cancellationToken);

    /// <inheritdoc cref="AriaMultiline" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaMultiline(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaMultiline", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-multiselectable attribute, which indicates that the user may select more than one item from the current selectable descendants.</para>
    /// <para>Note: Where possible use an HTML &lt;select&gt; element as this has built in semantics and does not require ARIA attributes.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "true": More than one item may be selected at a time.<br />
    /// - "false": Only one item may be selected.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaMultiSelectable => GetAriaMultiSelectable(default);

    /// <inheritdoc cref="AriaMultiSelectable" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaMultiSelectable(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaMultiSelectable", cancellationToken);

    /// <inheritdoc cref="AriaMultiSelectable" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaMultiSelectable(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaMultiSelectable", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-orientation attribute, which indicates whether the element's orientation is horizontal, vertical, or unknown/ambiguous.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "horizontal": The element is horizontal.<br />
    /// - "vertical": The element is vertical.<br />
    /// - "undefined": The element's orientation is unknown.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaOrientation => GetAriaOrientation(default);

    /// <inheritdoc cref="AriaOrientation" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaOrientation(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaOrientation", cancellationToken);

    /// <inheritdoc cref="AriaOrientation" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaOrientation(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaOrientation", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-placeholder attribute, which defines a short hint intended to aid the user with data entry when the control has no value.</para>
    /// <para>Note: Where possible use an HTML &lt;input&gt; element with type="text" or a &lt;textarea&gt; as these have built in semantics and do not require ARIA attributes.</para>
    /// </summary>
    public ValueTask<string?> AriaPlaceholder => GetAriaPlaceholder(default);

    /// <inheritdoc cref="AriaPlaceholder" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaPlaceholder(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaPlaceholder", cancellationToken);

    /// <inheritdoc cref="AriaPlaceholder" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaPlaceholder(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaPlaceholder", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-posinset attribute, which defines an element's number or position in the current set of listitems or treeitems.</para>
    /// <para>Value is a string containing an integer.</para>
    /// </summary>
    public ValueTask<string?> AriaPosInSet => GetAriaPosInSet(default);

    /// <inheritdoc cref="AriaPosInSet" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaPosInSet(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaPosInSet", cancellationToken);

    /// <inheritdoc cref="AriaPosInSet" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaPosInSet(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaPosInSet", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-pressed attribute, which indicates the current "pressed" state of toggle buttons.</para>
    /// <para>Note: Where possible use an HTML &lt;input&gt; element with type="button" or the &lt;button&gt; element as these have built in semantics and do not require ARIA attributes.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "true": The element is pressed.<br />
    /// - "false": The element supports being pressed but is not currently pressed.<br />
    /// - "mixed": Indicates a mixed mode value for a tri-state toggle button.<br />
    /// - "undefined": The element does not support being pressed.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaPressed => GetAriaPressed(default);

    /// <inheritdoc cref="AriaPressed" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaPressed(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaPressed", cancellationToken);

    /// <inheritdoc cref="AriaPressed" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaPressed(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaPressed", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-readonly attribute, which indicates that the element is not editable, but is otherwise operable.</para>
    /// <para>Note: Where possible use an HTML &lt;input&gt; element with type="text" or a &lt;textarea&gt; as these have built in semantics and do not require ARIA attributes.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "true": The user cannot change the value of the element.<br />
    /// - "false": The user can set the value of the element.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaReadOnly => GetAriaReadOnly(default);

    /// <inheritdoc cref="AriaReadOnly" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaReadOnly(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaReadOnly", cancellationToken);

    /// <inheritdoc cref="AriaReadOnly" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaReadOnly(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaReadOnly", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-required attribute, which indicates that user input is required on the element before a form may be submitted.</para>
    /// <para>Note: Where possible use an HTML &lt;input&gt; element with type="text" or a &lt;textarea&gt; as these have built in semantics and do not require ARIA attributes.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "true": Users need to provide input on an element before a form is submitted.<br />
    /// - "false": User input is not necessary to submit the form.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaRequired => GetAriaRequired(default);

    /// <inheritdoc cref="AriaRequired" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaRequired(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaRequired", cancellationToken);

    /// <inheritdoc cref="AriaRequired" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaRequired(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaRequired", cancellationToken, [value]);


    /// <summary>
    /// Rreflects the value of the aria-roledescription attribute, which defines a human-readable, author-localized description for the role of an element.
    /// </summary>
    public ValueTask<string?> AriaRoleDescription => GetAriaRoleDescription(default);

    /// <inheritdoc cref="AriaRoleDescription" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaRoleDescription(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaRoleDescription", cancellationToken);

    /// <inheritdoc cref="AriaRoleDescription" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaRoleDescription(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaRoleDescription", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-rowcount attribute, which defines the total number of rows in a table, grid, or treegrid.</para>
    /// <para>Value is a string which contains an integer.</para>
    /// </summary>
    public ValueTask<string?> AriaRowCount => GetAriaRowCount(default);

    /// <inheritdoc cref="AriaRowCount" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaRowCount(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaRowCount", cancellationToken);

    /// <inheritdoc cref="AriaRowCount" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaRowCount(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaRowCount", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-rowindex attribute, which defines an element's row index or position with respect to the total number of rows within a table, grid, or treegrid.</para>
    /// <para>Value is a string which contains an integer.</para>
    /// </summary>
    public ValueTask<string?> AriaRowIndex => GetAriaRowIndex(default);

    /// <inheritdoc cref="AriaRowIndex" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaRowIndex(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaRowIndex", cancellationToken);

    /// <inheritdoc cref="AriaRowIndex" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaRowIndex(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaRowIndex", cancellationToken, [value]);


    /// <summary>
    /// Reflects the value of the aria-rowindextext attribute, which defines a human readable text alternative of aria-rowindex.
    /// </summary>
    public ValueTask<string?> AriaRowIndexText => GetAriaRowIndexText(default);

    /// <inheritdoc cref="AriaRowIndexText" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaRowIndexText(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaRowIndexText", cancellationToken);

    /// <inheritdoc cref="AriaRowIndexText" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaRowIndexText(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaRowIndexText", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-rowspan attribute, which defines the number of rows spanned by a cell or gridcell within a table, grid, or treegrid.</para>
    /// <para>Value is a string which contains an integer.</para>
    /// </summary>
    public ValueTask<string?> AriaRowSpan => GetAriaRowSpan(default);

    /// <inheritdoc cref="AriaRowSpan" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaRowSpan(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaRowSpan", cancellationToken);

    /// <inheritdoc cref="AriaRowSpan" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaRowSpan(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaRowSpan", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-selected attribute, which indicates the current "selected" state of elements that have a selected state.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "true": The item is selected.<br />
    /// - "false": The item is not selected.<br />
    /// - "undefined": The item is not selectable.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaSelected => GetAriaSelected(default);

    /// <inheritdoc cref="AriaSelected" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaSelected(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaSelected", cancellationToken);

    /// <inheritdoc cref="AriaSelected" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaSelected(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaSelected", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-setsize attribute, which defines the number of items in the current set of listitems or treeitems.</para>
    /// <para>Value is a string containing an integer.</para>
    /// </summary>
    public ValueTask<string?> AriaSetSize => GetAriaSetSize(default);

    /// <inheritdoc cref="AriaSetSize" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaSetSize(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaSetSize", cancellationToken);

    /// <inheritdoc cref="AriaSetSize" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaSetSize(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaSetSize", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-sort attribute, which indicates if items in a table or grid are sorted in ascending or descending order.</para>
    /// <para>
    /// Value is one of the following values:<br />
    /// - "ascending": Items are sorted in ascending order by this column.<br />
    /// - "descending": Items are sorted in descending order by this column.<br />
    /// - "none": There is no defined sort applied to the column.<br />
    /// - "other": A sort algorithm other than ascending or descending has been applied.
    /// </para>
    /// </summary>
    public ValueTask<string?> AriaSort => GetAriaSort(default);

    /// <inheritdoc cref="AriaSort" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaSort(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaSort", cancellationToken);

    /// <inheritdoc cref="AriaSort" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaSort(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaSort", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-valuemax attribute, which defines the maximum allowed value for a range widget.</para>
    /// <para>Value is a string which contains a number.</para>
    /// </summary>
    public ValueTask<string?> AriaValueMax => GetAriaValueMax(default);

    /// <inheritdoc cref="AriaValueMax" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaValueMax(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaValueMax", cancellationToken);

    /// <inheritdoc cref="AriaValueMax" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaValueMax(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaValueMax", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-valuemin attribute, which defines the minimum allowed value for a range widget.</para>
    /// <para>Value is a string which contains a number.</para>
    /// </summary>
    public ValueTask<string?> AriaValueMin => GetAriaValueMin(default);

    /// <inheritdoc cref="AriaValueMin" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaValueMin(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaValueMin", cancellationToken);

    /// <inheritdoc cref="AriaValueMin" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaValueMin(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaValueMin", cancellationToken, [value]);


    /// <summary>
    /// <para>Reflects the value of the aria-valuenow attribute, which defines the current value for a range widget.</para>
    /// <para>Value is a string which contains a number.</para>
    /// </summary>
    public ValueTask<string?> AriaValueNow => GetAriaValueNow(default);

    /// <inheritdoc cref="AriaValueNow" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaValueNow(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaValueNow", cancellationToken);

    /// <inheritdoc cref="AriaValueNow" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaValueNow(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaValueNow", cancellationToken, [value]);


    /// <summary>
    /// Reflects the value of the aria-valuetext attribute, which defines the human-readable text alternative of aria-valuenow for a range widget.
    /// </summary>
    public ValueTask<string?> AriaValueText => GetAriaValueText(default);

    /// <inheritdoc cref="AriaValueText" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAriaValueText(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getAriaValueText", cancellationToken);

    /// <inheritdoc cref="AriaValueText" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAriaValueText(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setAriaValueText", cancellationToken, [value]);


    /// <summary>
    /// <para>Returns the explicitly set WAI-ARIA role for the element.</para>
    /// <para>
    /// All HTML elements have an implicit ARIA role, even if that role is generic.
    /// This semantic association allows tools to present and support interaction with the object in a manner that is consistent with user expectations about other objects of that type.
    /// The role attribute is used to explicitly set the element's ARIA role, overriding the implicit role.
    /// For example, a &lt;ul&gt;, which has an implicit list role, might have role="treegrid" explicitly set.
    /// The role property reflects the explicitly set value of the role attribute—in this case treegrid; it does not return the element's implicit list role unless explicitly set.
    /// </para>
    /// <para>The full list of defined ARIA roles can be found on the <see href="https://developer.mozilla.org/en-US/docs/Web/Accessibility/ARIA/Reference/Roles">ARIA roles</see> reference page.</para>
    /// </summary>
    public ValueTask<string?> Role => GetRole(default);

    /// <inheritdoc cref="Role" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetRole(CancellationToken cancellationToken) => await (await htmlElementTask).InvokeTrySync<string?>("getRole", cancellationToken);

    /// <inheritdoc cref="Role" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetRole(string? value, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setRole", cancellationToken, [value]);


    // methods

    /// <summary>
    /// <para>
    /// Checks whether the element is visible. The method returns false in either of the following situations:<br />
    /// - The element doesn't have an associated box, for example because the CSS display property is set to 'none' or 'contents'.<br />
    /// - The element is not being rendered because the element or an ancestor element sets the 'content-visibility' property to 'hidden'.
    /// </para>
    /// <para>
    /// The optional parameter enables additional checks to test for other interpretations of what "visible" means.
    /// For example, you can further check whether an element has an opacity of 0, if the value of the element visibility property makes it invisible,
    /// or if the element content-visibility property has a value of auto and its rendering is currently being skipped.
    /// </para>
    /// </summary>
    /// <param name="contentVisibilityAuto">true to check if the element content-visibility property has (or inherits) the value auto, and it is currently skipping its rendering. false by default.</param>
    /// <param name="opacityProperty">true to check if the element opacity property has (or inherits) a value of 0. false by default.</param>
    /// <param name="visibilityProperty">true to check if the element is invisible due to the value of its visibility property. false by default.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> CheckVisibility(bool contentVisibilityAuto = false, bool opacityProperty = false, bool visibilityProperty = false, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeTrySync<bool>("checkVisibility", cancellationToken, [contentVisibilityAuto, opacityProperty, visibilityProperty]);

    /// <summary>
    /// Returns a StylePropertyMapReadOnly interface which provides a read-only representation of a CSS declaration block that is an alternative to CSSStyleDeclaration.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<Dictionary<string, string>> ComputedStyleMap(CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeTrySync<Dictionary<string, string>>("computedStyleMap", cancellationToken);

    /// <summary>
    /// Returns a DOMRect object providing information about the size of an element and its position relative to the viewport.
    /// </summary>
    /// <param name="cancellationToken"></param>
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
    public async ValueTask<DOMRect> GetBoundingClientRect(CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeTrySync<DOMRect>("getBoundingClientRect", cancellationToken);

    /// <summary>
    /// <para>Returns a collection of DOMRect objects that indicate the bounding rectangles for each CSS border box in a client.</para>
    /// <para>Most elements only have one border box each, but a multiline inline-level element(such as a multiline &lt;span&gt; element, by default) has a border box around each line.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
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
    public async ValueTask<DOMRect[]> GetClientRects(CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeTrySync<DOMRect[]>("getClientRects", cancellationToken);

    /// <summary>
    /// Tests whether the element would be selected by the specified CSS selector.
    /// </summary>
    /// <param name="selectors">A string containing valid CSS selectors to test the Element against.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> Matches(string selectors, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeTrySync<bool>("matches", cancellationToken, [selectors]);

    // public async ValueTask RequestFullscreen(...)  is in HTMLElementBase

    // public async ValueTask RequestPointerLock(...)  is in HTMLElementBase

    /// <summary>
    /// Accepts a namespace URI as an argument. It returns a boolean value that is true if the namespace is the default namespace on the given node and false if not.
    /// </summary>
    /// <param name="namespaceURI">A string representing the namespace against which the element will be checked.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> IsDefaultNamespace(string? namespaceURI, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeTrySync<bool>("isDefaultNamespace", cancellationToken, [namespaceURI]);

    /// <summary>
    /// <para>Returns a string containing the prefix for a given namespace URI, if present, and null if not. When multiple prefixes are possible, the first prefix is returned.</para>
    /// <para>If the node is a <i>DocumentType</i> or a <i>DocumentFragment</i>, it returns null.</para>
    /// </summary>
    /// <param name="namespace">A string containing the namespace to look the prefix up.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> LookupPrefix(string? @namespace, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeTrySync<string?>("lookupPrefix", cancellationToken, [@namespace]);

    /// <summary>
    /// <para>
    /// Takes a prefix as parameter and returns the namespace URI associated with it on the given node if found (and null if not).
    /// This method's existence allows Node objects to be passed as a namespace resolver to <i>XPathEvaluator.createExpression()</i> and <i>XPathEvaluator.evaluate()</i>.
    /// </para>
    /// <para>
    /// It returns a string containing the namespace URI corresponding to the prefix.<br />
    /// - Always returns null if the node is a DocumentFragment, DocumentType, Document with no documentElement, or Attr with no associated element.<br />
    /// - If prefix is "xml", the return value is always "http://www.w3.org/XML/1998/namespace".<br />
    /// - If prefix is "xmlns", the return value is always "http://www.w3.org/2000/xmlns/".<br />
    /// - If the prefix is null, the return value is the default namespace URI.<br />
    /// - If the prefix is not found, the return value is null.
    /// </para>
    /// </summary>
    /// <param name="prefix">The prefix to look for.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> LookupNamespaceURI(string? prefix, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeTrySync<string?>("lookupNamespaceURI", cancellationToken, [prefix]);

    /// <summary>
    /// Puts the specified node and all of its sub-tree into a normalized form. In a normalized sub-tree, no text nodes in the sub-tree are empty and there are no adjacent text nodes.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Normalize(CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("normalize", cancellationToken);


    // methods - Pointer Capture

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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetPointerCapture(long pointerId, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("setPointerCapture", cancellationToken, [pointerId]);

    /// <summary>
    /// <para>Releases (stops) pointer capture that was previously set for a specific (PointerEvent) pointer.</para>
    /// <para>See the <see cref="SetPointerCapture(long, CancellationToken)"/> method for a description of pointer capture and how to set it for a particular element.</para>
    /// </summary>
    /// <param name="pointerId">The pointerId of a PointerEvent object.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ReleasePointerCapture(long pointerId, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("releasePointerCapture", cancellationToken, [pointerId]);

    /// <summary>
    /// Checks whether the element on which it is invoked has pointer capture for the pointer identified by the given pointer ID.
    /// </summary>
    /// <param name="pointerId">The pointerId of a PointerEvent object.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> HasPointerCapture(long pointerId, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeTrySync<bool>("hasPointerCapture", cancellationToken, [pointerId]);


    // methods - Scroll

    /// <summary>
    /// Scrolls the element to a particular set of coordinates inside a given element.
    /// </summary>
    /// <param name="left">Specifies the number of pixels along the X axis to scroll the window or element.</param>
    /// <param name="top">Specifies the number of pixels along the Y axis to scroll the window or element.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Scroll(int left, int top, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("scroll", cancellationToken, [left, top]);

    /// <summary>
    /// Scrolls to a particular set of coordinates inside a given element.
    /// </summary>
    /// <param name="x">The pixel along the horizontal axis of the element that you want displayed in the upper left.</param>
    /// <param name="y">The pixel along the vertical axis of the element that you want displayed in the upper left.</param>
    /// <param name="behavior">
    /// Determines whether scrolling is instant or animates smoothly. This option is a string which must take one of the following values:<br />
    /// - "smooth": scrolling should animate smoothly<br />
    /// - "instant": scrolling should happen instantly in a single jump<br />
    /// - "auto": scroll behavior is determined by the computed value of scroll-behavior
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ScrollTo(int x, int y, string? behavior = null, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeVoidTrySync("scrollTo", cancellationToken, [x, y, behavior]);

    /// <summary>
    /// Scrolls an element by the given amount.
    /// </summary>
    /// <param name="x">Specifies the number of pixels along the X axis to scroll the window or element.</param>
    /// <param name="y">Specifies the number of pixels along the Y axis to scroll the window or element.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ScrollBy(int x, int y, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("scrollBy", cancellationToken, [x, y]);

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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ScrollIntoView(string block = "start", string inline = "nearest", string behavior = "auto", CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeVoidTrySync("scrollIntoView", cancellationToken, [block, inline, behavior]);


    // methods - Attribute

    /// <summary>
    /// Returns the value of a specified attribute on the element. If the given attribute does not exist, the value returned will be null.
    /// </summary>
    /// <param name="qualifiedName">The name of the attribute whose value you want to get.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAttribute(string qualifiedName, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeTrySync<string?>("getAttribute", cancellationToken, [qualifiedName]);

    /// <summary>
    /// <para>
    /// Returns the string value of the attribute with the specified namespace and name.
    /// If the named attribute does not exist, the value returned will either be null or "" (the empty string); see Notes for details.
    /// </para>
    /// <para>If you are working with HTML documents and you don't need to specify the requested attribute as being part of a specific namespace, use the <see cref="GetAttribute"/> method instead.</para>
    /// </summary>
    /// <remarks>
    /// Note: Earlier versions of the DOM specification had this method described as returning an empty string for non-existent attributes, but it was not typically implemented this way since null makes more sense.
    /// The DOM4 specification now says this method should return null for non-existent attributes.
    /// </remarks>
    /// <param name="namespace">The namespace in which to look for the specified attribute.</param>
    /// <param name="qualifiedName">The name of the attribute to look for.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string?> GetAttributeNS(string @namespace, string qualifiedName, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeTrySync<string?>("getAttributeNS", cancellationToken, [@namespace, qualifiedName]);

    /// <summary>
    /// <para>Returns the attribute names of the element as an Array of strings. If the element has no attributes it returns an empty array.</para>
    /// <para>Using <i>getAttributeNames()</i> along with <see cref="GetAttribute"/>, is a memory-efficient and performant alternative to <see cref="Attributes"/>.</para>
    /// <para>
    /// The names returned by <i>getAttributeNames()</i> are qualified attribute names,
    /// meaning that attributes with a namespace prefix have their names returned with that namespace prefix (not the actual namespace), followed by a colon, followed by the attribute name (for example, xlink:href),
    /// while any attributes which have no namespace prefix have their names returned as-is (for example, href).
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string[]> GetAttributeNames(CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeTrySync<string[]>("getAttributeNames", cancellationToken);

    /// <summary>
    /// <para>Sets the value of an attribute on the specified element. If the attribute already exists, the value is updated; otherwise a new attribute is added with the specified name and value.</para>
    /// <para>To get the current value of an attribute, use <see cref="GetAttribute"/>; to remove an attribute, call <see cref="RemoveAttribute"/>.</para>
    /// <para>Boolean attributes are considered to be true if they're present on the element at all. You should set value to the empty string ("") or the attribute's name, with no leading or trailing whitespace.</para>
    /// <para>
    /// Since the specified value gets converted into a string, specifying null doesn't necessarily do what you expect.
    /// Instead of removing the attribute or setting its value to be null, it instead sets the attribute's value to the string "null".
    /// If you wish to remove an attribute, call <see cref="RemoveAttribute"/>.
    /// </para>
    /// </summary>
    /// <param name="qualifiedName">
    /// A string specifying the name of the attribute whose value is to be set.
    /// The attribute name is automatically converted to all lower-case when setAttribute() is called on an HTML element in an HTML document.
    /// </param>
    /// <param name="value">A string containing the value to assign to the attribute. Any non-string value specified is converted automatically into a string.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAttribute(string qualifiedName, string value, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeVoidTrySync("setAttribute", cancellationToken, [qualifiedName, value]);

    /// <summary>
    /// <para>Adds a new attribute or changes the value of an attribute with the given namespace and name.</para>
    /// <para>f you are working with HTML documents and you don't need to specify the requested attribute as being part of a specific namespace, use the <see cref="SetAttribute"/> method instead.</para>
    /// </summary>
    /// <param name="namespace">A string specifying the namespace of the attribute.</param>
    /// <param name="qualifiedName">A string identifying the attribute by its qualified name; that is, a namespace prefix followed by a colon followed by a local name.</param>
    /// <param name="value">The desired string value of the new attribute.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetAttributeNS(string @namespace, string qualifiedName, string value, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeVoidTrySync("setAttributeNS", cancellationToken, [@namespace, qualifiedName, value]);

    /// <summary>
    /// Toggles a Boolean attribute (removing it if it is present and adding it if it is not present) on the given element.
    /// </summary>
    /// <param name="qualifiedName">
    /// A string specifying the name of the attribute to be toggled.
    /// The attribute name is automatically converted to all lower-case when toggleAttribute() is called on an HTML element in an HTML document.
    /// </param>
    /// <param name="force">
    /// A boolean value which has the following effects:<br />
    /// - if not specified at all, the toggleAttribute method "toggles" the attribute named name — removing it if it is present, or else adding it if it is not present<br />
    /// - if true, the toggleAttribute method adds an attribute named name<br />
    /// - if false, the toggleAttribute method removes the attribute named name
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> ToggleAttribute(string qualifiedName, bool? force = null, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeTrySync<bool>("toggleAttribute", cancellationToken, [qualifiedName, force]);

    /// <summary>
    /// Removes the attribute with the specified name from the element.
    /// </summary>
    /// <param name="qualifiedName">A string specifying the name of the attribute to remove from the element. If the specified attribute does not exist, removeAttribute() returns without generating an error.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask RemoveAttribute(string qualifiedName, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("removeAttribute", cancellationToken, [qualifiedName]);

    /// <summary>
    /// <para>Removes the specified attribute with the specified namespace from an element.</para>
    /// <para>If you are working with HTML and you don't need to specify the requested attribute as being part of a specific namespace, use the <see cref="RemoveAttribute"/> method instead.</para>
    /// </summary>
    /// <param name="namespace">A string that contains the namespace of the attribute.</param>
    /// <param name="qualifiedName">A string that names the attribute to be removed from the current node.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask RemoveAttributeNS(string @namespace, string qualifiedName, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeVoidTrySync("removeAttributeNS", cancellationToken, [@namespace, qualifiedName]);

    /// <summary>
    /// Returns a Boolean value indicating whether the specified element has the specified attribute or not.
    /// </summary>
    /// <param name="qualifiedName">A string representing the name of the attribute.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> HasAttribute(string qualifiedName, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeTrySync<bool>("hasAttribute", cancellationToken, [qualifiedName]);

    /// <summary>
    /// <para>Returns a boolean value indicating whether the current element has the specified attribute with the specified namespace.</para>
    /// <para>If you are working with HTML documents and you don't need to specify the requested attribute as being part of a specific namespace, use the <see cref="HasAttribute"/> method instead.</para>
    /// </summary>
    /// <param name="namespace">A string specifying the namespace of the attribute.</param>
    /// <param name="qualifiedName">The name of the attribute.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> HasAttributeNS(string @namespace, string qualifiedName, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeTrySync<bool>("hasAttributeNS", cancellationToken, [@namespace, qualifiedName]);

    /// <summary>
    /// Returns a boolean value indicating whether the current element has any attributes or not.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> HasAttributes(CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeTrySync<bool>("hasAttributes", cancellationToken);


    // methods - Tree-nodes

    /// <summary>
    /// <para>Returns an array which contains every descendant element which has the specified class name or names.</para>
    /// <para>The method getElementsByClassName() on the Document interface works essentially the same way, except it acts on the entire document, starting at the document root.</para>
    /// </summary>
    /// <param name="className">A string containing one or more class names to match on, separated by whitespace.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement[]> GetElementsByClassName(string className, CancellationToken cancellationToken = default) {
        IJSObjectReference[] htmlElements = await (await htmlElementTask).InvokeTrySync<IJSObjectReference[]>("getElementsByClassName", cancellationToken, [className]);

        HTMLElement[] result = new HTMLElement[htmlElements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElement(Task.FromResult(htmlElements[i]));
        return result;
    }

    /// <summary>
    /// <para>Returns an array of elements with the given tag name. All descendants of the specified element are searched, but not the element itself.</para>
    /// <para>
    /// When called on an HTML element in an HTML document, getElementsByTagName lower-cases the argument before searching for it.
    /// This is undesirable when trying to match camel-cased SVG elements (such as &lt;linearGradient&gt;) in an HTML document.
    /// Instead, use <see cref="GetElementsByTagNameNS"/>, which preserves the capitalization of the tag name.
    /// </para>
    /// <para>Element.getElementsByTagName is similar to Document.getElementsByTagName(), except that it only searches for elements that are descendants of the specified element.</para>
    /// </summary>
    /// <param name="qualifiedName">The qualified name to look for. The special string "*" represents all elements. For compatibility with XHTML, lower-case should be used.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement[]> GetElementsByTagName(string qualifiedName, CancellationToken cancellationToken = default) {
        IJSObjectReference[] htmlElements = await (await htmlElementTask).InvokeTrySync<IJSObjectReference[]>("getElementsByTagName", cancellationToken, [qualifiedName]);

        HTMLElement[] result = new HTMLElement[htmlElements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElement(Task.FromResult(htmlElements[i]));
        return result;
    }

    /// <summary>
    /// Returns an array of elements with the given tag name belonging to the given namespace.
    /// It is similar to Document.getElementsByTagNameNS, except that its search is restricted to descendants of the specified element.
    /// </summary>
    /// <param name="namespace">
    /// The namespace URI of elements to look for (see Element.namespaceURI and Attr.namespaceURI).
    /// For example, if you need to look for XHTML elements, use the XHTML namespace URI, http://www.w3.org/1999/xhtml.
    /// </param>
    /// <param name="qualifiedName">Either the local name of elements to look for or the special value "*", which matches all elements (see Element.localName and Attr.localName).</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement[]> GetElementsByTagNameNS(string @namespace, string qualifiedName, CancellationToken cancellationToken = default) {
        IJSObjectReference[] htmlElements = await (await htmlElementTask).InvokeTrySync<IJSObjectReference[]>("getElementsByTagNameNS", cancellationToken, [@namespace, qualifiedName]);

        HTMLElement[] result = new HTMLElement[htmlElements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElement(Task.FromResult(htmlElements[i]));
        return result;
    }

    /// <summary>
    /// Returns the first element that is a descendant of the element on which it is invoked that matches the specified group of selectors.
    /// </summary>
    /// <param name="selectors">
    /// <para>A string containing one or more selectors to match. This string must be a valid CSS selector string; if it isn't, a SyntaxError exception is thrown.</para>
    /// <para>
    /// Note that the HTML specification does not require attribute values to be valid CSS identifiers.
    /// If a class or id attribute value is not a valid CSS identifier, then you must escape it before using it in a selector,
    /// either by calling CSS.escape() on the value, or using one of the techniques described in Escaping characters.
    /// </para>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> QuerySelector(string selectors, CancellationToken cancellationToken = default) {
        IJSObjectReference?[] singleReference = await (await htmlElementTask).InvokeTrySync<IJSObjectReference[]>("querySelector", cancellationToken, [selectors]);
        if (singleReference[0] is IJSObjectReference htmlElement)
            return new HTMLElement(Task.FromResult(htmlElement));
        else
            return null;
    }

    /// <summary>
    /// Returns an array representing a list of elements matching the specified group of selectors which are descendants of the element on which the method was called.
    /// </summary>
    /// <param name="selectors">
    /// <para>A string containing one or more selectors to match. This string must be a valid CSS selector string; if it isn't, a SyntaxError exception is thrown.</para>
    /// <para>
    /// Note that the HTML specification does not require attribute values to be valid CSS identifiers.
    /// If a class or id attribute value is not a valid CSS identifier, then you must escape it before using it in a selector,
    /// either by calling CSS.escape() on the value, or using one of the techniques described in Escaping characters.
    /// See <see href="https://developer.mozilla.org/en-US/docs/Web/API/Element/querySelector#escaping_attribute_values">Escaping attribute values</see> for an example.
    /// </para>
    /// <para>
    /// The selectors are applied to the entire document, not just the particular element on which querySelectorAll() is called.
    /// To restrict the selector to the element on which querySelectorAll() is called, include the :scope pseudo-class at the start of the selector.
    /// See the <see href="https://developer.mozilla.org/en-US/docs/Web/API/Element/querySelectorAll#selector_scope">selector scope</see> example.
    /// </para>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement[]> QuerySelectorAll(string selectors, CancellationToken cancellationToken = default) {
        IJSObjectReference[] htmlElements = await (await htmlElementTask).InvokeTrySync<IJSObjectReference[]>("querySelectorAll", cancellationToken, [selectors]);

        HTMLElement[] result = new HTMLElement[htmlElements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElement(Task.FromResult(htmlElements[i]));
        return result;
    }

    /// <summary>
    /// Traverses the element and its parents (heading toward the document root) until it finds a node that matches the specified CSS selector.
    /// </summary>
    /// <param name="selectors">A string of valid CSS selectors to match the Element and its ancestors against.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> Closest(string selectors, CancellationToken cancellationToken = default) {
        IJSObjectReference?[] singleReference = await (await htmlElementTask).InvokeTrySync<IJSObjectReference?[]>("closest", cancellationToken, [selectors]);
        if (singleReference[0] is IJSObjectReference closest)
            return new HTMLElement(Task.FromResult(closest));
        else
            return null;
    }


    /// <summary>
    /// Inserts a set of strings in the children list of this Element's parent, just before this Element. Strings are inserted as equivalent Text nodes.
    /// </summary>
    /// <param name="nodes">A set of strings to insert.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Before(string[] nodes, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("before_string", cancellationToken, [nodes]);

    /// <summary>
    /// Inserts a set of Node objects in the children list of this Element's parent, just before this Element.
    /// </summary>
    /// <param name="nodes">A set of Node objects to insert.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Before(IHTMLElement[] nodes, CancellationToken cancellationToken = default) {
        IJSObjectReference[] nodesJS = new IJSObjectReference[nodes.Length];
        for (int i = 0; i < nodesJS.Length; i++)
            nodesJS[i] = await nodes[i].HTMLElementTask;

        await (await htmlElementTask).InvokeVoidTrySync("before_htmlElement", cancellationToken, [nodesJS]);
    }

    /// <summary>
    /// Inserts a set of strings in the children list of the Element's parent, just after the Element. Strings are inserted as equivalent Text nodes.
    /// </summary>
    /// <param name="nodes">A set of strings to insert.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask After(string[] nodes, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("after_string", cancellationToken, [nodes]);

    /// <summary>
    /// Inserts a set of Node objects in the children list of the Element's parent, just after the Element.
    /// </summary>
    /// <param name="nodes">A set of Node objects to insert.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask After(IHTMLElement[] nodes, CancellationToken cancellationToken = default) {
        IJSObjectReference[] nodesJS = new IJSObjectReference[nodes.Length];
        for (int i = 0; i < nodesJS.Length; i++)
            nodesJS[i] = await nodes[i].HTMLElementTask;

        await (await htmlElementTask).InvokeVoidTrySync("after_htmlElement", cancellationToken, [nodesJS]);
    }


    /// <summary>
    /// Inserts a set of strings before the first child of the Element. Strings are inserted as equivalent Text nodes.
    /// </summary>
    /// <param name="nodes">A set of strings to insert.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Prepend(string[] nodes, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("prepend_string", cancellationToken, [nodes]);

    /// <summary>
    /// Inserts a set of Node objects before the first child of the Element.
    /// </summary>
    /// <param name="nodes">A set of Node objects to insert.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Prepend(IHTMLElement[] nodes, CancellationToken cancellationToken = default) {
        IJSObjectReference[] nodesJS = new IJSObjectReference[nodes.Length];
        for (int i = 0; i < nodesJS.Length; i++)
            nodesJS[i] = await nodes[i].HTMLElementTask;

        await (await htmlElementTask).InvokeVoidTrySync("prepend_htmlElement", cancellationToken, [nodesJS]);
    }

    /// <summary>
    /// <para>Adds a node to the end of the list of children of a specified parent node.</para>
    /// <para>Note: If the given child is a reference to an existing node in the document, appendChild() moves it from its current position to the new position.</para>
    /// <para>If the given child is a DocumentFragment, the entire contents of the DocumentFragment are moved into the child list of the specified parent node.</para>
    /// <para>appendChild() returns the newly appended node, or if the child is a DocumentFragment, the emptied fragment.</para>
    /// <para>Note: Unlike this method, the Element.append() method supports multiple arguments and appending strings. You can prefer using it if your node is an element.</para>
    /// </summary>
    /// <param name="node">The node to append to the given parent node</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask AppendChild(IHTMLElement node, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("appendChild", cancellationToken, [await node.HTMLElementTask]);

    /// <summary>
    /// Inserts a set of strings after the last child of the Element. Strings are inserted as equivalent Text nodes.
    /// </summary>
    /// <param name="nodes">A set of strings to insert.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Append(string[] nodes, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("append_string", cancellationToken, [nodes]);

    /// <summary>
    /// Inserts a set of Node objects after the last child of the Element.
    /// </summary>
    /// <param name="nodes">A set of Node objects to insert.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Append(IHTMLElement[] nodes, CancellationToken cancellationToken = default) {
        IJSObjectReference[] nodesJS = new IJSObjectReference[nodes.Length];
        for (int i = 0; i < nodesJS.Length; i++)
            nodesJS[i] = await nodes[i].HTMLElementTask;

        await (await htmlElementTask).InvokeVoidTrySync("append_htmlElement", cancellationToken, [nodesJS]);
    }

    /// <summary>
    /// Inserts a given element node at a given position relative to the element it is invoked upon.
    /// </summary>
    /// <param name="position">
    /// A string representing the position relative to the targetElement; must match (case-insensitively) one of the following strings:<br />
    /// - "beforebegin": Before the targetElement itself.<br />
    /// - "afterbegin": Just inside the targetElement, before its first child.<br />
    /// - "beforeend": Just inside the targetElement, after its last child.<br />
    /// - "afterend": After the targetElement itself.
    /// </param>
    /// <param name="htmlElement">The element to be inserted into the tree.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>true if element was inserted, false if the insertion failed.</returns>
    public async ValueTask<bool> InsertAdjacentElement(string position, IHTMLElement htmlElement, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeTrySync<bool>("insertAdjacentElement", cancellationToken, [position, await htmlElement.HTMLElementTask]);

    /// <summary>
    /// Parses the specified input as HTML or XML and inserts the resulting nodes into the DOM tree at a specified position.
    /// </summary>
    /// <remarks>
    /// Warning: This method parses its input as HTML or XML, writing the result into the DOM.
    /// APIs like this are known as injection sinks, and are potentially a vector for cross-site-scripting (XSS) attacks, if the input originally came from an attacker.
    /// </remarks>
    /// <param name="position">
    /// A string representing the position relative to the element. Must be one of the following strings:<br />
    /// - "beforebegin": Before the element. Only valid if the element is in the DOM tree and has a parent element.<br />
    /// - "afterbegin": Just inside the element, before its first child.<br />
    /// - "beforeend": Just inside the element, after its last child.<br />
    /// - "afterend": After the element. Only valid if the element is in the DOM tree and has a parent element.
    /// </param>
    /// <param name="html">A TrustedHTML instance or string defining the HTML or XML to be parsed.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask InsertAdjacentHTML(string position, string html, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeVoidTrySync("insertAdjacentHTML", cancellationToken, [position, html]);

    /// <summary>
    /// Given a relative position and a string, inserts a new text node at the given position relative to the element it is called from.
    /// </summary>
    /// <param name="position">
    /// A string representing the position relative to the element the method is called from; must be one of the following strings:<br />
    /// - "beforebegin": Before the element itself.<br />
    /// - "afterbegin": Just inside the element, before its first child.<br />
    /// - "beforeend": Just inside the element, after its last child.<br />
    /// - "afterend": After the element itself.
    /// </param>
    /// <param name="data">A string from which to create a new text node to insert at the given position where relative to the element the method is called from.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask InsertAdjacentText(string position, string data, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeVoidTrySync("insertAdjacentText", cancellationToken, [position, data]);


    /// <summary>
    /// Removes a child node from the DOM.
    /// </summary>
    /// <remarks>
    /// Note: As long as a reference is kept on the removed child, it still exists in memory, but is no longer part of the DOM. It can still be reused later in the code.
    /// If the return value of removeChild() is not stored, and no other reference is kept, it will be automatically deleted from memory after a short time.
    /// </remarks>
    /// <param name="node">A Node that is the child node to be removed from the DOM.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask RemoveChild(IHTMLElement node, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("removeChild", cancellationToken, [await node.HTMLElementTask]);

    /// <summary>
    /// Removes the element from its parent node.
    /// If it has no parent node, calling remove() does nothing.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Remove(CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("remove", cancellationToken);

    /// <summary>
    /// Replaces a child node within the given (parent) node.
    /// </summary>
    /// <remarks>
    /// Note: The parameter order, new before old, is unusual. <see cref="ReplaceWith(IHTMLElement[], CancellationToken)"/>, applying only to nodes that are elements, may be easier to read and use.
    /// </remarks>
    /// <param name="newChild">
    /// <para>The new node to replace oldChild.</para>
    /// <para>Warning: If the new node is already present somewhere else in the DOM, it is first removed from that position.</para>
    /// </param>
    /// <param name="oldChild">The child to be replaced.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ReplaceChild(IHTMLElement newChild, IHTMLElement oldChild, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeVoidTrySync("replaceChild", cancellationToken, [await newChild.HTMLElementTask, await oldChild.HTMLElementTask]);

    /// <summary>
    /// Replaces a child node within the given (parent) node.
    /// </summary>
    /// <param name="newChild">
    /// <para>The new node to replace oldChild.</para>
    /// <para>Warning: If the new node is already present somewhere else in the DOM, it is first removed from that position.</para>
    /// </param>
    /// <param name="oldChildIndex">The zero based index of the child to be replaced.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ReplaceChild(IHTMLElement newChild, int oldChildIndex, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeVoidTrySync("replaceChildIndex", cancellationToken, [await newChild.HTMLElementTask, oldChildIndex]);

    /// <summary>
    /// Replaces this Element in the children list of its parent with a set of strings. Strings are inserted as equivalent Text nodes.
    /// </summary>
    /// <param name="nodes">A set of strings to replace.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ReplaceWith(string[] nodes, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("replaceWith_string", cancellationToken, [nodes]);

    /// <summary>
    /// Replaces this Element in the children list of its parent with a set of Node objects.
    /// </summary>
    /// <param name="nodes">A set of Node objects to replace.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ReplaceWith(IHTMLElement[] nodes, CancellationToken cancellationToken = default) {
        IJSObjectReference[] nodesJS = new IJSObjectReference[nodes.Length];
        for (int i = 0; i < nodesJS.Length; i++)
            nodesJS[i] = await nodes[i].HTMLElementTask;

        await (await htmlElementTask).InvokeVoidTrySync("replaceWith_htmlElement", cancellationToken, [nodesJS]);
    }

    /// <summary>
    /// Replaces the existing children of a Node with a specified new set of children.
    /// </summary>
    /// <remarks>It also provides a very convenient mechanism for emptying a node of all its children. You call it on the parent node with an empty array.</remarks>
    /// <param name="nodes">A set of strings to replace the Element's existing children with.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ReplaceChildren(string[] nodes, CancellationToken cancellationToken = default) => await (await htmlElementTask).InvokeVoidTrySync("replaceChildren_string", cancellationToken, [nodes]);

    /// <summary>
    /// Replaces the existing children of a Node with a specified new set of children.
    /// </summary>
    /// <remarks>It also provides a very convenient mechanism for emptying a node of all its children. You call it on the parent node with an empty array.</remarks>
    /// <param name="nodes">A set of Node objects to replace the Element's existing children with.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ReplaceChildren(IHTMLElement[] nodes, CancellationToken cancellationToken = default) {
        IJSObjectReference[] nodesJS = new IJSObjectReference[nodes.Length];
        for (int i = 0; i < nodesJS.Length; i++)
            nodesJS[i] = await nodes[i].HTMLElementTask;

        await (await htmlElementTask).InvokeVoidTrySync("replaceChildren_htmlElement", cancellationToken, [nodesJS]);
    }


    /// <summary>
    /// <para>Returns a duplicate of the node on which this method was called. Its parameter controls if the subtree contained in a node is also cloned or not.</para>
    /// <para>
    /// Cloning a node copies all of its attributes and their values, including intrinsic (inline) listeners.
    /// It does not copy event listeners added using addEventListener() or those assigned to element properties (e.g., node.onclick = someFunction).
    /// Additionally, for a &lt;canvas&gt; element, the painted image is not copied.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Warning: cloneNode() may lead to duplicate element IDs in a document!
    /// If the original node has an id attribute, and the clone will be placed in the same document, then you should modify the clone's ID to be unique.
    /// Also, name attributes may need to be modified, depending on whether duplicate names are expected.</remarks>
    /// <param name="deep">
    /// <para>If true, then the node and its whole subtree, including text that may be in child Text nodes, is also copied.</para>
    /// <para>If false, only the node will be cloned. The subtree, including any text that the node contains, is not cloned.</para>
    /// <para>Note that deep has no effect on void elements, such as the &lt;img&gt; and &lt;input&gt; elements.</para>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement> CloneNode(bool deep = false, CancellationToken cancellationToken = default) {
        Task<IJSObjectReference> clonedElement = (await htmlElementTask).InvokeTrySync<IJSObjectReference>("cloneNode", cancellationToken, [deep]).AsTask();
        return new HTMLElement(clonedElement);
    }

    /// <summary>
    /// Is a legacy alias the for the === strict equality operator. That is, it tests whether two nodes are the same (in other words, whether they reference the same object).
    /// </summary>
    /// <param name="other">The Node to test against.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> IsSameNode(IHTMLElement other, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeTrySync<bool>("isSameNode", cancellationToken, [await other.HTMLElementTask]);

    /// <summary>
    /// Tests whether two nodes are equal.
    /// Two nodes are equal when they have the same type, defining characteristics (for elements, this would be their ID, number of children, and so forth), its attributes match, and so on.
    /// The specific set of data points that must match varies depending on the types of the nodes.
    /// </summary>
    /// <param name="other">The Node to compare equality with.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> IsEqualNode(IHTMLElement other, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeTrySync<bool>("isEqualNode", cancellationToken, [await other.HTMLElementTask]);

    /// <summary>
    /// Returns a boolean value indicating whether a node is a descendant of a given node, that is the node itself, one of its direct children (childNodes), one of the children's direct children, and so on.
    /// </summary>
    /// <remarks>Note: A node is contained inside itself.</remarks>
    /// <param name="other">The Node to test with.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> Contains(IHTMLElement other, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeTrySync<bool>("contains", cancellationToken, [await other.HTMLElementTask]);

    /// <summary>
    /// <para>Reports the position of its argument node relative to the node on which it is called.</para>
    /// <para>
    /// It returns an integer value representing otherNode's position relative to node as a bitmask combining the following constant properties of Node:<br />
    /// - 1 (Node.DOCUMENT_POSITION_DISCONNECTED): Both nodes are in different documents or different trees in the same document.<br />
    /// - 2 (Node.DOCUMENT_POSITION_PRECEDING): otherNode precedes the node in either a pre-order depth-first traversal of a tree containing both (e.g., as an ancestor or previous sibling or a descendant of a previous sibling or previous sibling of an ancestor) or (if they are disconnected) in an arbitrary but consistent ordering.<br />
    /// - 4 (Node.DOCUMENT_POSITION_FOLLOWING): otherNode follows the node in either a pre-order depth-first traversal of a tree containing both (e.g., as a descendant or following sibling or a descendant of a following sibling or following sibling of an ancestor) or (if they are disconnected) in an arbitrary but consistent ordering.<br />
    /// - 8 (Node.DOCUMENT_POSITION_CONTAINS): otherNode is an ancestor of the node.<br />
    /// - 16 (Node.DOCUMENT_POSITION_CONTAINED_BY): otherNode is a descendant of the node.<br />
    /// - 32 (Node.DOCUMENT_POSITION_IMPLEMENTATION_SPECIFIC): The result relies upon arbitrary and/or implementation-specific behavior and is not guaranteed to be portable.
    /// </para>
    /// <para>
    /// Zero or more bits can be set, depending on which scenarios apply.
    /// For example, if otherNode is located earlier in the document and contains the node on which compareDocumentPosition() was called,
    /// then both the DOCUMENT_POSITION_CONTAINS and DOCUMENT_POSITION_PRECEDING bits would be set, producing a value of 10 (0x0A).
    /// </para>
    /// </summary>
    /// <param name="other">The Node for which position should be reported, relative to the node.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> CompareDocumentPosition(IHTMLElement other, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeTrySync<int>("compareDocumentPosition", cancellationToken, [await other.HTMLElementTask]);

    #endregion
}
