using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

/// <summary>
/// <para>The <i>HTMLElement</i> interface represents any HTML element. Some elements directly implement this interface, while others implement it via an interface that inherits it.</para>
/// <para>Objects of this class must disposed manually, so do not forget to call <see cref="DisposeAsync"/> when you are done with it.</para>
/// </summary>
[AutoInterface(Modifier = "public partial", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
internal sealed class HTMLElement(Task<IJSObjectReference> htmlElementTask) : HTMLElementBase, IHTMLElement {
    protected override Task<IJSObjectReference> HTMLElementTask { get; } = htmlElementTask;

    [IgnoreAutoInterface]
    public async ValueTask DisposeAsync() => await (await HTMLElementTask).DisposeTrySync();


    #region HTMLElement

    /// <summary>
    /// <para>The <i>innerText</i> property of the HTMLElement interface represents the rendered text content of a node and its descendants.</para>
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

    /// <summary>
    /// <para>The <i>innerText</i> property of the HTMLElement interface represents the rendered text content of a node and its descendants.</para>
    /// <para>
    /// As a getter, it approximates the text the user would get if they highlighted the contents of the element with the cursor and then copied it to the clipboard.
    /// As a setter this will replace the element's children with the given value, converting any line breaks into &lt;br&gt; elements.
    /// </para>
    /// <para>
    /// Note: innerText is easily confused with Node.textContent, but there are important differences between the two.
    /// Basically, innerText is aware of the rendered appearance of text, while textContent is not.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetInnerText(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<string>("getInnerText", cancellationToken);

    /// <summary>
    /// <para>The <i>innerText</i> property of the HTMLElement interface represents the rendered text content of a node and its descendants.</para>
    /// <para>
    /// As a getter, it approximates the text the user would get if they highlighted the contents of the element with the cursor and then copied it to the clipboard.
    /// As a setter this will replace the element's children with the given value, converting any line breaks into &lt;br&gt; elements.
    /// </para>
    /// <para>
    /// Note: innerText is easily confused with Node.textContent, but there are important differences between the two.
    /// Basically, innerText is aware of the rendered appearance of text, while textContent is not.
    /// </para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetInnerText(string value, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("setInnerText", cancellationToken, [value]);


    /// <summary>
    /// <para>
    /// The <i>outerText</i> property of the HTMLElement interface returns the same value as HTMLElement.innerText.
    /// When used as a setter it replaces the whole current node with the given text (this differs from innerText, which replaces the content inside the current node).
    /// </para>
    /// <para>See <see cref="InnerText">HTMLElement.innerText</see> for more information and examples showing how both properties are used as getters.</para>
    /// </summary>
    public ValueTask<string> OuterText => GetOuterText(default);

    /// <summary>
    /// <para>
    /// The <i>outerText</i> property of the HTMLElement interface returns the same value as HTMLElement.innerText.
    /// When used as a setter it replaces the whole current node with the given text (this differs from innerText, which replaces the content inside the current node).
    /// </para>
    /// <para>See <see cref="InnerText">HTMLElement.innerText</see> for more information and examples showing how both properties are used as getters.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetOuterText(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<string>("getOuterText", cancellationToken);

    /// <summary>
    /// <para>
    /// The <i>outerText</i> property of the HTMLElement interface returns the same value as HTMLElement.innerText.
    /// When used as a setter it replaces the whole current node with the given text (this differs from innerText, which replaces the content inside the current node).
    /// </para>
    /// <para>See <see cref="InnerText">HTMLElement.innerText</see> for more information and examples showing how both properties are used as getters.</para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetOuterText(string value, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("setOuterText", cancellationToken, [value]);


    /// <summary>
    /// <para>JS-property: style.cssText</para>
    /// <para>The <i>cssText</i> property of the CSSStyleDeclaration interface returns or sets the text of the element's inline style declaration only.</para>
    /// <para>To be able to set a stylesheet rule dynamically, see <see href="https://developer.mozilla.org/en-US/docs/Web/API/CSS_Object_Model/Using_dynamic_styling_information">Using dynamic styling information</see>.</para>
    /// <para>Not to be confused with stylesheet style-rule <see href="https://developer.mozilla.org/en-US/docs/Web/API/CSSRule/cssText">CSSRule.cssText</see>.</para>
    /// </summary>
    public ValueTask<string> Style => GetStyle(default);

    /// <summary>
    /// <para>JS-property: style.cssText</para>
    /// <para>The <i>cssText</i> property of the CSSStyleDeclaration interface returns or sets the text of the element's inline style declaration only.</para>
    /// <para>To be able to set a stylesheet rule dynamically, see <see href="https://developer.mozilla.org/en-US/docs/Web/API/CSS_Object_Model/Using_dynamic_styling_information">Using dynamic styling information</see>.</para>
    /// <para>Not to be confused with stylesheet style-rule <see href="https://developer.mozilla.org/en-US/docs/Web/API/CSSRule/cssText">CSSRule.cssText</see>.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetStyle(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<string>("getInlineStyle", cancellationToken);

    /// <summary>
    /// <para>JS-property: style.cssText</para>
    /// <para>The <i>cssText</i> property of the CSSStyleDeclaration interface returns or sets the text of the element's inline style declaration only.</para>
    /// <para>To be able to set a stylesheet rule dynamically, see <see href="https://developer.mozilla.org/en-US/docs/Web/API/CSS_Object_Model/Using_dynamic_styling_information">Using dynamic styling information</see>.</para>
    /// <para>Not to be confused with stylesheet style-rule <see href="https://developer.mozilla.org/en-US/docs/Web/API/CSSRule/cssText">CSSRule.cssText</see>.</para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetStyle(string value, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("setInlineStyle", cancellationToken, [value]);



    /// <summary>
    /// <para>The <i>HTMLElement.offsetWidth</i> read-only property returns the layout width of an element as an integer.</para>
    /// <para>
    /// Typically, offsetWidth is a measurement in pixels of the element's CSS width, including any borders, padding, and vertical scrollbars (if rendered).
    /// It does not include the width of pseudo-elements such as ::before or ::after.
    /// </para>
    /// <para>If the element is hidden (for example, by setting style.display on the element or one of its ancestors to "none"), then 0 is returned.</para>
    /// <para>Note: This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    public ValueTask<int> OffsetWidth => GetOffsetWidth(default);

    /// <summary>
    /// <para>The <i>HTMLElement.offsetWidth</i> read-only property returns the layout width of an element as an integer.</para>
    /// <para>
    /// Typically, offsetWidth is a measurement in pixels of the element's CSS width, including any borders, padding, and vertical scrollbars (if rendered).
    /// It does not include the width of pseudo-elements such as ::before or ::after.
    /// </para>
    /// <para>If the element is hidden (for example, by setting style.display on the element or one of its ancestors to "none"), then 0 is returned.</para>
    /// <para>Note: This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetOffsetWidth(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<int>("getOffsetWidth", cancellationToken);


    /// <summary>
    /// <para>The <i>HTMLElement.offsetHeight</i> read-only property returns the height of an element, including vertical padding and borders, as an integer.</para>
    /// <para>
    /// Typically, offsetHeight is a measurement in pixels of the element's CSS height, including any borders, padding, and horizontal scrollbars (if rendered).
    /// It does not include the height of pseudo-elements such as ::before or ::after. For the document body object, the measurement includes total linear content height instead of the element's CSS height.Floated elements extending below other linear content are ignored.
    /// </para>
    /// <para>If the element is hidden(for example, by setting style.display on the element or one of its ancestors to "none"), then 0 is returned.</para>
    /// <para>Note: This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    public ValueTask<int> OffsetHeight => GetOffsetHeight(default);

    /// <summary>
    /// <para>The <i>HTMLElement.offsetHeight</i> read-only property returns the height of an element, including vertical padding and borders, as an integer.</para>
    /// <para>
    /// Typically, offsetHeight is a measurement in pixels of the element's CSS height, including any borders, padding, and horizontal scrollbars (if rendered).
    /// It does not include the height of pseudo-elements such as ::before or ::after. For the document body object, the measurement includes total linear content height instead of the element's CSS height.Floated elements extending below other linear content are ignored.
    /// </para>
    /// <para>If the element is hidden(for example, by setting style.display on the element or one of its ancestors to "none"), then 0 is returned.</para>
    /// <para>Note: This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetOffsetHeight(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<int>("getOffsetHeight", cancellationToken);


    /// <summary>
    /// <para>The <i>HTMLElement.offsetLeft</i> read-only property returns the number of pixels that the upper left corner of the current element is offset to the left within the HTMLElement.offsetParent node.</para>
    /// <para>For block-level elements, offsetTop, offsetLeft, offsetWidth, and offsetHeight describe the border box of an element relative to the offsetParent.</para>
    /// <para>
    /// However, for inline-level elements (such as span) that can wrap from one line to the next, offsetTop and offsetLeft describe the positions of the first border box
    /// (use Element.getClientRects() to get its width and height), while offsetWidth and offsetHeight describe the dimensions of the bounding border box(use Element.getBoundingClientRect() to get its position).
    /// Therefore, a box with the left, top, width and height of offsetLeft, offsetTop, offsetWidth and offsetHeight will not be a bounding box for a span with wrapped text.
    /// </para>
    /// </summary>
    public ValueTask<int> OffsetLeft => GetOffsetLeft(default);

    /// <summary>
    /// <para>The <i>HTMLElement.offsetLeft</i> read-only property returns the number of pixels that the upper left corner of the current element is offset to the left within the HTMLElement.offsetParent node.</para>
    /// <para>For block-level elements, offsetTop, offsetLeft, offsetWidth, and offsetHeight describe the border box of an element relative to the offsetParent.</para>
    /// <para>
    /// However, for inline-level elements (such as span) that can wrap from one line to the next, offsetTop and offsetLeft describe the positions of the first border box
    /// (use Element.getClientRects() to get its width and height), while offsetWidth and offsetHeight describe the dimensions of the bounding border box(use Element.getBoundingClientRect() to get its position).
    /// Therefore, a box with the left, top, width and height of offsetLeft, offsetTop, offsetWidth and offsetHeight will not be a bounding box for a span with wrapped text.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetOffsetLeft(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<int>("getOffsetLeft", cancellationToken);


    /// <summary>
    /// The <i>HTMLElement.offsetTop</i> read-only property returns the distance from the outer border of the current element (including its margin) to the top padding edge of the offsetParent,
    /// the closest positioned ancestor element.
    /// </summary>
    public ValueTask<int> OffsetTop => GetOffsetTop(default);

    /// <summary>
    /// The <i>HTMLElement.offsetTop</i> read-only property returns the distance from the outer border of the current element (including its margin) to the top padding edge of the offsetParent,
    /// the closest positioned ancestor element.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetOffsetTop(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<int>("getOffsetTop", cancellationToken);


    /// <summary>
    /// <para>The <i>HTMLElement.offsetParent</i> read-only property returns a reference to the element which is the closest (nearest in the containment hierarchy) positioned ancestor element.</para>
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

    /// <summary>
    /// <para>The <i>HTMLElement.offsetParent</i> read-only property returns a reference to the element which is the closest (nearest in the containment hierarchy) positioned ancestor element.</para>
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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> GetOffsetParent(CancellationToken cancellationToken) {
        try {
            Task<IJSObjectReference> htmlElementTask = (await HTMLElementTask).InvokeTrySync<IJSObjectReference>("getOffsetParent", cancellationToken).AsTask();
            await htmlElementTask;
            return new HTMLElement(htmlElementTask);
        }
        catch (JSException) {
            return null;
        }
    }



    /// <summary>
    /// <para>htmlElement === document.activeElement;</para>
    /// <para>If true, the htmlElement has focus, otherwise false.</para>
    /// </summary>
    public ValueTask<bool> HasFocus => GetHasFocus(default);

    /// <summary>
    /// <para>htmlElement === document.activeElement;</para>
    /// <para>If true, the htmlElement has focus, otherwise false.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> GetHasFocus(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<bool>("hasFocus", cancellationToken);


    /// <summary>
    /// <para>The <i>HTMLElement.click()</i> method simulates a mouse click on an element.</para>
    /// <para>
    /// When click() is used with supported elements(such as an &lt;input&gt;), it fires the element's click event.
    /// This event then bubbles up to elements higher in the document tree (or event chain) and fires their click events.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Click(CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("click", cancellationToken);

    /// <summary>
    /// <para>
    /// The <i>HTMLElement.focus()</i> method sets focus on the specified element, if it can be focused.
    /// The focused element is the element that will receive keyboard and similar events by default.
    /// </para>
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
    public async ValueTask Focus(bool preventScroll = false, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("focus", cancellationToken, [preventScroll]);

    /// <summary>
    /// The <i>HTMLElement.blur()</i> method removes keyboard focus from the current element.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Blur(CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("blur", cancellationToken);

    /// <summary>
    /// <para>The <i>showPopover()</i> method of the HTMLElement interface shows a popover element (i.e. one that has a valid popover attribute) by adding it to the top layer.</para>
    /// <para>
    /// When <i>showPopover()</i> is called on an element with the popover attribute that is currently hidden, a beforetoggle event will be fired, followed by the popover showing, and then the toggle event firing.
    /// If the element is already showing, an error will be thrown.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ShowPopover(CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("showPopover", cancellationToken);

    /// <summary>
    /// <para>The <i>hidePopover()</i> method of the HTMLElement interface hides a popover element (i.e. one that has a valid popover attribute) by removing it from the top layer and styling it with display: none.</para>
    /// <para>
    /// When <i>hidePopover()</i> is called on a showing element with the popover attribute, a beforetoggle event will be fired, followed by the popover being hidden, and then the toggle event firing.
    /// If the element is already hidden, an error is thrown.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask HidePopover(CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("hidePopover", cancellationToken);

    /// <summary>
    /// <para>The <i>togglePopover()</i> method of the HTMLElement interface toggles a popover element (i.e. one that has a valid popover attribute) between the hidden and showing states.</para>
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
    public async ValueTask<bool> TogglePopover(CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeTrySync<bool>("togglePopover", cancellationToken);

    /// <summary>
    /// <para>The <i>togglePopover()</i> method of the HTMLElement interface toggles a popover element (i.e. one that has a valid popover attribute) between the hidden and showing states.</para>
    /// <para>
    /// When <i>togglePopover()</i> is called on an element with the popover attribute:<br />
    /// 1. A beforetoggle event is fired.<br />
    /// 2. The popover toggles between hidden and showing:<br />
    /// - i. If it was initially showing, it toggles to hidden.<br />
    /// - ii. If it was initially hidden, it toggles to showing.<br />
    /// 3. A toggle event is fired.
    /// </para>
    /// </summary>
    /// <param name="force">
    /// <para>A boolean, which causes togglePopover() to behave like showPopover() or hidePopover(), except that it doesn't throw an exception if the popover is already in the target state.</para>
    /// <para>- If set to true, the popover is shown if it was initially hidden.If it was initially shown, nothing happens.</para>
    /// <para>- If set to false, the popover is hidden if it was initially shown. If it was initially hidden, nothing happens.</para>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// <para>true if the popup is open after the call, and false otherwise.</para>
    /// <para>None(undefined) may be returned in older browser versions(see browser compatibility).</para>
    /// </returns>
    public async ValueTask<bool> TogglePopover(bool force, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeTrySync<bool>("togglePopover", cancellationToken, [force]);

    #endregion


    #region Element

    /// <summary>
    /// <para>The Element property <i>innerHTML</i> gets or sets the HTML or XML markup contained within the element.</para>
    /// <para>To insert the HTML into the document rather than replace the contents of an element, use the method insertAdjacentHTML().</para>
    /// </summary>
    public ValueTask<string> InnerHTML => GetInnerHTML(default);

    /// <summary>
    /// <para>The Element property <i>innerHTML</i> gets or sets the HTML or XML markup contained within the element.</para>
    /// <para>To insert the HTML into the document rather than replace the contents of an element, use the method insertAdjacentHTML().</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetInnerHTML(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<string>("getInnerHTML", cancellationToken);

    /// <summary>
    /// <para>The Element property <i>innerHTML</i> gets or sets the HTML or XML markup contained within the element.</para>
    /// <para>To insert the HTML into the document rather than replace the contents of an element, use the method insertAdjacentHTML().</para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetInnerHTML(string value, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("setInnerHTML", cancellationToken, [value]);


    /// <summary>
    /// <para>
    /// The <i>outerHTML</i> attribute of the Element DOM interface gets the serialized HTML fragment describing the element including its descendants.
    /// It can also be set to replace the element with nodes parsed from the given string.
    /// </para>
    /// <para>To only obtain the HTML representation of the contents of an element, or to replace the contents of an element, use the innerHTML property instead.</para>
    /// </summary>
    public ValueTask<string> OuterHTML => GetOuterHTML(default);

    /// <summary>
    /// <para>
    /// The <i>outerHTML</i> attribute of the Element DOM interface gets the serialized HTML fragment describing the element including its descendants.
    /// It can also be set to replace the element with nodes parsed from the given string.
    /// </para>
    /// <para>To only obtain the HTML representation of the contents of an element, or to replace the contents of an element, use the innerHTML property instead.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetOuterHTML(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<string>("getOuterHTML", cancellationToken);

    /// <summary>
    /// <para>
    /// The <i>outerHTML</i> attribute of the Element DOM interface gets the serialized HTML fragment describing the element including its descendants.
    /// It can also be set to replace the element with nodes parsed from the given string.
    /// </para>
    /// <para>To only obtain the HTML representation of the contents of an element, or to replace the contents of an element, use the innerHTML property instead.</para>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetOuterHTML(string value, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("setOuterHTML", cancellationToken, [value]);


    /// <summary>
    /// The <i>Element.attributes</i> property returns a live collection of all attribute nodes registered to the specified node.
    /// It is a NamedNodeMap, not an Array, so it has no Array methods and the Attr nodes' indexes may differ among browsers.
    /// To be more specific, attributes is a key/value pair of strings that represents any information regarding that attribute.
    /// </summary>
    public ValueTask<Dictionary<string, string>> Attributes => GetAttributes(default);

    /// <summary>
    /// The <i>Element.attributes</i> property returns a live collection of all attribute nodes registered to the specified node.
    /// It is a NamedNodeMap, not an Array, so it has no Array methods and the Attr nodes' indexes may differ among browsers.
    /// To be more specific, attributes is a key/value pair of strings that represents any information regarding that attribute.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<Dictionary<string, string>> GetAttributes(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<Dictionary<string, string>>("getAttributes", cancellationToken);


    /// <summary>
    /// The <i>Element.childElementCount</i> read-only property returns the number of child elements of this element.
    /// </summary>
    public ValueTask<int> ChildElementCount => GetChildElementCount(default);

    /// <summary>
    /// The <i>Element.childElementCount</i> read-only property returns the number of child elements of this element.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetChildElementCount(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<int>("getChildElementCount", cancellationToken);


    /// <summary>
    /// <para>The read-only <i>children</i> property returns a live HTMLCollection which contains all of the child elements of the element upon which it was called.</para>
    /// <üara>Element.children includes only element nodes.To get all child nodes, including non-element nodes like text and comment nodes, use Node.childNodes.</üara>
    /// </summary>
    public ValueTask<IHTMLElement[]> Children => GetChildren(default);

    /// <summary>
    /// <para>The read-only <i>children</i> property returns a live HTMLCollection which contains all of the child elements of the element upon which it was called.</para>
    /// <üara>Element.children includes only element nodes.To get all child nodes, including non-element nodes like text and comment nodes, use Node.childNodes.</üara>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement[]> GetChildren(CancellationToken cancellationToken) {
        IJSObjectReference[] children = await (await HTMLElementTask).InvokeTrySync<IJSObjectReference[]>("getChildren", cancellationToken);

        HTMLElement[] result = new HTMLElement[children.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElement(Task.FromResult(children[i]));
        return result;
    }


    /// <summary>
    /// The <i>className</i> property of the Element interface gets and sets the value of the class attribute of the specified element.
    /// </summary>
    public ValueTask<string> ClassName => GetClassName(default);

    /// <summary>
    /// The <i>className</i> property of the Element interface gets and sets the value of the class attribute of the specified element.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>A string variable representing the class or space-separated classes of the current element.</returns>
    public async ValueTask<string> GetClassName(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<string>("getClassName", cancellationToken);

    /// <summary>
    /// The <i>className</i> property of the Element interface gets and sets the value of the class attribute of the specified element.
    /// </summary>
    /// <param name="value">A string variable representing the class or space-separated classes of the current element.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetClassName(string value, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("setClassName", cancellationToken, [value]);


    /// <summary>
    /// <para>The <i>Element.classList</i> is a read-only property that returns a live DOMTokenList collection of the class attributes of the element. This can then be used to manipulate the class list.</para>
    /// <üara>Using classList is a convenient alternative to accessing an element's list of classes as a space-delimited string via <i>element.className</i>.</üara>
    /// </summary>
    public ValueTask<string[]> ClassList => GetClassList(default);

    /// <summary>
    /// <para>The <i>Element.classList</i> is a read-only property that returns a live DOMTokenList collection of the class attributes of the element. This can then be used to manipulate the class list.</para>
    /// <üara>Using classList is a convenient alternative to accessing an element's list of classes as a space-delimited string via <i>element.className</i>.</üara>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string[]> GetClassList(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<string[]>("getClassList", cancellationToken);



    /// <summary>
    /// <para>
    /// The <i>Element.clientWidth</i> property is zero for inline elements and elements with no CSS; otherwise, it's the inner width of an element in pixels.
    /// It includes padding but excludes borders, margins, and vertical scrollbars (if present).
    /// </para>
    /// <para>
    /// When clientWidth is used on the root element(the &lt;html&gt; element), (or on &lt;body&gt; if the document is in quirks mode), the viewport's width (excluding any scrollbar) is returned.
    /// <see href="https://www.w3.org/TR/2016/WD-cssom-view-1-20160317/#dom-element-clientwidth">This is a special case of clientWidth</see>.
    /// </para>
    /// <para>Note: This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    public ValueTask<int> ClientWidth => GetClientWidth(default);

    /// <summary>
    /// <para>
    /// The <i>Element.clientWidth</i> property is zero for inline elements and elements with no CSS; otherwise, it's the inner width of an element in pixels.
    /// It includes padding but excludes borders, margins, and vertical scrollbars (if present).
    /// </para>
    /// <para>
    /// When clientWidth is used on the root element(the &lt;html&gt; element), (or on &lt;body&gt; if the document is in quirks mode), the viewport's width (excluding any scrollbar) is returned.
    /// <see href="https://www.w3.org/TR/2016/WD-cssom-view-1-20160317/#dom-element-clientwidth">This is a special case of clientWidth</see>.
    /// </para>
    /// <para>Note: This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetClientWidth(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<int>("getClientWidth", cancellationToken);


    /// <summary>
    /// <para>
    /// The <i>Element.clientHeight</i> read-only property is zero for elements with no CSS or inline layout boxes; otherwise, it's the inner height of an element in pixels.
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

    /// <summary>
    /// <para>
    /// The <i>Element.clientHeight</i> read-only property is zero for elements with no CSS or inline layout boxes; otherwise, it's the inner height of an element in pixels.
    /// It includes padding but excludes borders, margins, and horizontal scrollbars (if present).
    /// </para>
    /// <para>clientHeight can be calculated as: CSS height + CSS padding - height of horizontal scrollbar(if present).</para>
    /// <para>
    /// When clientHeight is used on the root element(the &lt;html&gt; element), (or on &lt;body&gt; if the document is in quirks mode), the viewport's height (excluding any scrollbar) is returned.
    /// <see href="https://www.w3.org/TR/2016/WD-cssom-view-1-20160317/#dom-element-clientheight">This is a special case of clientHeight</see>.
    /// </para>
    /// <para>Note: This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetClientHeight(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<int>("getClientHeight", cancellationToken);


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

    /// <summary>
    /// <para>
    /// The width of the left border of an element in pixels.
    /// It includes the width of the vertical scrollbar if the text direction of the element is right-to-left and if there is an overflow causing a left vertical scrollbar to be rendered.
    /// clientLeft does not include the left margin or the left padding. clientLeft is read-only.
    /// </para>
    /// <para>Note: This property will round the value to an integer.If you need a fractional value, use element.getBoundingClientRect().</para>
    /// <para>Note: When an element has display: inline, clientLeft returns 0 regardless of the element's border.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetClientLeft(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<int>("getClientLeft", cancellationToken);


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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetClientTop(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<int>("getClientTop", cancellationToken);



    /// <summary>
    /// <para>The <i>Element.scrollWidth</i> read-only property is a measurement of the width of an element's content, including content not visible on the screen due to overflow.</para>
    /// <para>
    /// The scrollWidth value is equal to the minimum width the element would require in order to fit all the content in the viewport without using a horizontal scrollbar.
    /// The width is measured in the same way as clientWidth: it includes the element's padding, but not its border, margin or vertical scrollbar (if present).
    /// It can also include the width of pseudo-elements such as ::before or ::after.
    /// If the element's content can fit without a need for horizontal scrollbar, its scrollWidth is equal to clientWidth.
    /// </para>
    /// <para>Note: This property will round the value to an integer.If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    public ValueTask<int> ScrollWidth => GetScrollWidth(default);

    /// <summary>
    /// <para>The <i>Element.scrollWidth</i> read-only property is a measurement of the width of an element's content, including content not visible on the screen due to overflow.</para>
    /// <para>
    /// The scrollWidth value is equal to the minimum width the element would require in order to fit all the content in the viewport without using a horizontal scrollbar.
    /// The width is measured in the same way as clientWidth: it includes the element's padding, but not its border, margin or vertical scrollbar (if present).
    /// It can also include the width of pseudo-elements such as ::before or ::after.
    /// If the element's content can fit without a need for horizontal scrollbar, its scrollWidth is equal to clientWidth.
    /// </para>
    /// <para>Note: This property will round the value to an integer.If you need a fractional value, use element.getBoundingClientRect().</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetScrollWidth(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<int>("getScrollWidth", cancellationToken);


    /// <summary>
    /// <para>The <i>Element.scrollHeight</i> read-only property is a measurement of the height of an element's content, including content not visible on the screen due to overflow.</para>
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

    /// <summary>
    /// <para>The <i>Element.scrollHeight</i> read-only property is a measurement of the height of an element's content, including content not visible on the screen due to overflow.</para>
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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetScrollHeight(CancellationToken cancellationToken) => await (await HTMLElementTask).InvokeTrySync<int>("getScrollHeight", cancellationToken);


    /// <summary>
    /// <para>The <i>Element.scrollLeft</i> property gets or sets the number of pixels that an element's content is scrolled from its left edge.</para>
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

    /// <summary>
    /// <para>The <i>Element.scrollLeft</i> property gets or sets the number of pixels that an element's content is scrolled from its left edge.</para>
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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetScrollLeft(CancellationToken cancellationToken) => (int)await (await HTMLElementTask).InvokeTrySync<double>("getScrollLeft", cancellationToken);

    /// <summary>
    /// <para>The <i>Element.scrollLeft</i> property gets or sets the number of pixels that an element's content is scrolled from its left edge.</para>
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
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetScrollLeft(int value, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("setScrollLeft", cancellationToken, [value]);


    /// <summary>
    /// <para>The <i>Element.scrollTop</i> property gets or sets the number of pixels that an element's content is scrolled vertically.</para>
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

    /// <summary>
    /// <para>The <i>Element.scrollTop</i> property gets or sets the number of pixels that an element's content is scrolled vertically.</para>
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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<int> GetScrollTop(CancellationToken cancellationToken) => (int)await (await HTMLElementTask).InvokeTrySync<double>("getScrollTop", cancellationToken);

    /// <summary>
    /// <para>The <i>Element.scrollTop</i> property gets or sets the number of pixels that an element's content is scrolled vertically.</para>
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
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask SetScrollTop(int value, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("setScrollTop", cancellationToken, [value]);



    /// <summary>
    /// The <i>Element.getBoundingClientRect()</i> method returns a DOMRect object providing information about the size of an element and its position relative to the viewport.
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
    public async ValueTask<DOMRect> GetBoundingClientRect(CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeTrySync<DOMRect>("getBoundingClientRect", cancellationToken);

    /// <summary>
    /// <para>The <i>getClientRects()</i> method of the Element interface returns a collection of DOMRect objects that indicate the bounding rectangles for each CSS border box in a client.</para>
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
    public async ValueTask<DOMRect[]> GetClientRects(CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeTrySync<DOMRect[]>("getClientRects", cancellationToken);


    /// <summary>
    /// The <i>Element.hasAttribute()</i> method returns a Boolean value indicating whether the specified element has the specified attribute or not.
    /// </summary>
    /// <param name="name">A string representing the name of the attribute.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> HasAttribute(string name, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeTrySync<bool>("hasAttribute", cancellationToken, [name]);

    /// <summary>
    /// The <i>hasAttributes()</i> method of the Element interface returns a boolean value indicating whether the current element has any attributes or not.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> HasAttributes(CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeTrySync<bool>("hasAttributes", cancellationToken);


    /// <summary>
    /// <para>
    /// The <i>setPointerCapture()</i> method of the Element interface is used to designate a specific element as the capture target of future pointer events.
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
    public async ValueTask SetPointerCapture(long pointerId, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("setPointerCapture", cancellationToken, [pointerId]);

    /// <summary>
    /// <para>The <i>releasePointerCapture()</i> method of the Element interface releases (stops) pointer capture that was previously set for a specific (PointerEvent) pointer.</para>
    /// <para>See the <see cref="SetPointerCapture(long, CancellationToken)"/> method for a description of pointer capture and how to set it for a particular element.</para>
    /// </summary>
    /// <param name="pointerId">The pointerId of a PointerEvent object.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ReleasePointerCapture(long pointerId, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("releasePointerCapture", cancellationToken, [pointerId]);

    /// <summary>
    /// The <i>hasPointerCapture()</i> method of the Element interface checks whether the element on which it is invoked has pointer capture for the pointer identified by the given pointer ID.
    /// </summary>
    /// <param name="pointerId">The pointerId of a PointerEvent object.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> HasPointerCapture(long pointerId, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeTrySync<bool>("hasPointerCapture", cancellationToken, [pointerId]);


    /// <summary>
    /// The <i>scroll()</i> method of the Element interface scrolls the element to a particular set of coordinates inside a given element.
    /// </summary>
    /// <param name="left">Specifies the number of pixels along the X axis to scroll the window or element.</param>
    /// <param name="top">Specifies the number of pixels along the Y axis to scroll the window or element.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Scroll(int left, int top, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("scroll", cancellationToken, [left, top]);

    /// <summary>
    /// The <i>scrollBy()</i> method of the Element interface scrolls an element by the given amount.
    /// </summary>
    /// <param name="x">Specifies the number of pixels along the X axis to scroll the window or element.</param>
    /// <param name="y">Specifies the number of pixels along the Y axis to scroll the window or element.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ScrollBy(int x, int y, CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidTrySync("scrollBy", cancellationToken, [x, y]);

    /// <summary>
    /// The Element interface's <i>scrollIntoView()</i> method scrolls the element's ancestor containers such that the element on which <i>scrollIntoView()</i> is called is visible to the user.
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
        => await (await HTMLElementTask).InvokeVoidTrySync("scrollIntoView", cancellationToken, [block, inline, behavior]);

    #endregion
}
