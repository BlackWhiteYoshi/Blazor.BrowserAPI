using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Xml.Linq;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>Represents any web page loaded in the browser and serves as an entry point into the web page's content, which is the DOM tree.</para>
/// <para>
/// The DOM tree includes elements such as &lt;body&gt; and &lt;table&gt;, among many others.
/// It provides functionality globally to the document, like how to obtain the page's URL and create new elements in the document.
/// </para>
/// <para>
/// The Document interface describes the common properties and methods for any kind of document.
/// Depending on the document's type (e.g., HTML, XML, SVG, …), a larger API is available:
/// HTML documents, served with the "text/html" content type, also implement the HTMLDocument interface,
/// whereas XML and SVG documents implement the XMLDocument interface.
/// </para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class DocumentInProcess(IModuleManager moduleManager) : DocumentBase(moduleManager), IDocumentInProcess {
    // Properties - HTMLElement reference

    /// <summary>
    /// Returns the Element that is the root element of the document (for example, the &lt;html&gt; element for HTML documents).
    /// </summary>
    public IHTMLElementInProcess DocumentElement => new HTMLElementInProcess(moduleManager.InvokeSync<IJSInProcessObjectReference>("DocumentAPI.getDocumentElement"));

    /// <summary>
    /// Returns the &lt;head&gt; element of the current document.
    /// </summary>
    public IHTMLElementInProcess Head => new HTMLElementInProcess(moduleManager.InvokeSync<IJSInProcessObjectReference>("DocumentAPI.getHead"));

    /// <summary>
    /// Represents the &lt;body&gt; or &lt;frameset&gt; node of the current document, or null if no such element exists.
    /// </summary>
    public IHTMLElementInProcess Body {
        get => new HTMLElementInProcess(moduleManager.InvokeSync<IJSInProcessObjectReference>("DocumentAPI.getBody"));
        set => moduleManager.InvokeSync("DocumentAPI.setBody", [value.HTMLElement]);
    }

    /// <summary>
    /// <para>Returns a reference to the Element that scrolls the document. In standards mode, this is the root element of the document, <see cref="DocumentElement"/>.</para>
    /// <para>
    /// When in quirks mode, the scrollingElement attribute returns the HTML body element if it exists and is not potentially scrollable, otherwise it returns null.
    /// This may look surprising but is true according to both the specification and browsers.
    /// </para>
    /// </summary>
    public IHTMLElementInProcess ScrollingElement => new HTMLElementInProcess(moduleManager.InvokeSync<IJSInProcessObjectReference>("DocumentAPI.getScrollingElement"));


    // Properties - HTMLElement Collection

    /// <summary>
    /// Returns a list of the embedded &lt;embed&gt; elements within the current document.
    /// </summary>
    public IHTMLElementInProcess[] Embeds {
        get {
            IJSInProcessObjectReference[] embedElements = moduleManager.InvokeSync<IJSInProcessObjectReference[]>("DocumentAPI.getEmbeds");

            IHTMLElementInProcess[] result = new IHTMLElementInProcess[embedElements.Length];
            for (int i = 0; i < result.Length; i++)
                result[i] = new HTMLElementInProcess(embedElements[i]);
            return result;
        }
    }

    /// <summary>
    /// Returns an HTMLCollection listing all the &lt;form&gt; elements contained in the document.
    /// </summary>
    public IHTMLElementInProcess[] Forms {
        get {
            IJSInProcessObjectReference[] formElements = moduleManager.InvokeSync<IJSInProcessObjectReference[]>("DocumentAPI.getForms");

            IHTMLElementInProcess[] result = new IHTMLElementInProcess[formElements.Length];
            for (int i = 0; i < result.Length; i++)
                result[i] = new HTMLElementInProcess(formElements[i]);
            return result;
        }
    }

    /// <summary>
    /// Returns a collection of the images in the current HTML document.
    /// Each entry in the collection is an HTMLImageElement &lt;img&gt; representing a single image element.
    /// </summary>
    public IHTMLElementInProcess[] Images {
        get {
            IJSInProcessObjectReference[] imageElements = moduleManager.InvokeSync<IJSInProcessObjectReference[]>("DocumentAPI.getImages");

            IHTMLElementInProcess[] result = new IHTMLElementInProcess[imageElements.Length];
            for (int i = 0; i < result.Length; i++)
                result[i] = new HTMLElementInProcess(imageElements[i]);
            return result;
        }
    }

    /// <summary>
    /// Returns a collection of all &lt;area&gt; elements and &lt;a&gt; elements in a document with a value for the href attribute.
    /// </summary>
    public IHTMLElementInProcess[] Links {
        get {
            IJSInProcessObjectReference[] linkElements = moduleManager.InvokeSync<IJSInProcessObjectReference[]>("DocumentAPI.getLinks");

            IHTMLElementInProcess[] result = new IHTMLElementInProcess[linkElements.Length];
            for (int i = 0; i < result.Length; i++)
                result[i] = new HTMLElementInProcess(linkElements[i]);
            return result;
        }
    }

    /// <summary>
    /// Returns an HTMLCollection object containing one or more HTMLEmbedElements representing the &lt;embed&gt; elements in the current document.
    /// </summary>
    public IHTMLElementInProcess[] Plugins {
        get {
            IJSInProcessObjectReference[] pluginElements = moduleManager.InvokeSync<IJSInProcessObjectReference[]>("DocumentAPI.getPlugins");

            IHTMLElementInProcess[] result = new IHTMLElementInProcess[pluginElements.Length];
            for (int i = 0; i < result.Length; i++)
                result[i] = new HTMLElementInProcess(pluginElements[i]);
            return result;
        }
    }

    /// <summary>
    /// Returns a list of the &lt;script&gt; elements in the document.
    /// </summary>
    public IHTMLElementInProcess[] Scripts {
        get {
            IJSInProcessObjectReference[] scriptElements = moduleManager.InvokeSync<IJSInProcessObjectReference[]>("DocumentAPI.getScripts");

            IHTMLElementInProcess[] result = new IHTMLElementInProcess[scriptElements.Length];
            for (int i = 0; i < result.Length; i++)
                result[i] = new HTMLElementInProcess(scriptElements[i]);
            return result;
        }
    }


    // Properties - HTMLElement situational

    /// <summary>
    /// <para>Returns the Element within the DOM that is receiving keyboard events such as keydown and keyup. This is usually analogous to the focused element.</para>
    /// <para>
    /// Which elements are focusable varies depending on the platform and the browser's current configuration.
    /// For example, on Safari, following the behavior of macOS, elements that aren't text input elements are not focusable by default, unless the "Full Keyboard Access" setting is enabled in System Preferences.
    /// </para>
    /// <para>
    /// Typically a user can press the Tab key to move the focus around the page among focusable elements,
    /// and use keyboard gestures such as Space or Enter to simulate clicks on the focused element.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Note: Focus (which element is receiving user input events) is not the same thing as selection (the currently highlighted part of the document).
    /// You can get the current selection using window.getSelection().
    /// </remarks>
    public IHTMLElementInProcess? ActiveElement {
        get {
            IJSInProcessObjectReference?[] singleReference = moduleManager.InvokeSync<IJSInProcessObjectReference?[]>("DocumentAPI.getActiveElement");
            if (singleReference[0] is IJSInProcessObjectReference htmlElement)
                return new HTMLElementInProcess(htmlElement);
            else
                return null;
        }
    }

    /// <summary>
    /// <para>Returns the &lt;script&gt; element whose script is currently being processed and isn't a JavaScript module. (For modules use import.meta instead.)</para>
    /// <para>
    /// It's important to note that this will not reference the &lt;script&gt; element if the code in the script is being called as a callback or event handler;
    /// it will only reference the element while it's initially being processed.
    /// </para>
    /// </summary>
    public IHTMLElementInProcess? CurrentScript {
        get {
            IJSInProcessObjectReference?[] singleReference = moduleManager.InvokeSync<IJSInProcessObjectReference?[]>("DocumentAPI.getCurrentScript");
            if (singleReference[0] is IJSInProcessObjectReference htmlElement)
                return new HTMLElementInProcess(htmlElement);
            else
                return null;
        }
    }

    /// <summary>
    /// <para>Returns the Element that is currently being presented in fullscreen mode in this document, or null if fullscreen mode is not currently in use.</para>
    /// <para>Although this property is read-only, it will not throw if it is modified (even in strict mode); the setter is a no-operation and it will be ignored.</para>
    /// </summary>
    public IHTMLElementInProcess? FullscreenElement {
        get {
            IJSInProcessObjectReference?[] singleReference = moduleManager.InvokeSync<IJSInProcessObjectReference?[]>("DocumentAPI.getFullscreenElement");
            if (singleReference[0] is IJSInProcessObjectReference htmlElement)
                return new HTMLElementInProcess(htmlElement);
            else
                return null;
        }
    }

    /// <summary>
    /// <para>Returns the Element that is currently being presented in picture-in-picture mode in this document, or null if picture-in-picture mode is not currently in use.</para>
    /// <para>Although this property is read-only, it will not throw if it is modified (even in strict mode); the setter is a no-operation and will be ignored.</para>
    /// </summary>
    public IHTMLElementInProcess? PictureInPictureElement {
        get {
            IJSInProcessObjectReference?[] singleReference = moduleManager.InvokeSync<IJSInProcessObjectReference?[]>("DocumentAPI.getPictureInPictureElement");
            if (singleReference[0] is IJSInProcessObjectReference htmlElement)
                return new HTMLElementInProcess(htmlElement);
            else
                return null;
        }
    }

    /// <summary>
    /// Provides the element set as the target for mouse events while the pointer is locked.
    /// It is null if lock is pending, pointer is unlocked, or the target is in another document.
    /// </summary>
    public IHTMLElementInProcess? PointerLockElement {
        get {
            IJSInProcessObjectReference?[] singleReference = moduleManager.InvokeSync<IJSInProcessObjectReference?[]>("DocumentAPI.getPointerLockElement");
            if (singleReference[0] is IJSInProcessObjectReference htmlElement)
                return new HTMLElementInProcess(htmlElement);
            else
                return null;
        }
    }


    // Properties

    /// <summary>
    /// Returns the character encoding of the document that it's currently rendered with.
    /// </summary>
    /// <remarks>Note: A "character set" and a "character encoding" are related, but different. Despite the name of this property, it returns the encoding.</remarks>
    public string CharacterSet => moduleManager.InvokeSync<string>("DocumentAPI.getCharacterSet");

    /// <summary>
    /// <para>Indicates whether the document is rendered in Quirks mode or Standards mode.</para>
    /// <para>
    /// The value is a string that is one of the following:<br />
    /// - "BackCompat": The document is in quirks mode.<br />
    /// - "CSS1Compat": The document is in no-quirks (also known as "standards") mode or limited-quirks (also known as "almost standards") mode.
    /// </para>
    /// </summary>
    /// <remarks>Note: All these modes are now standardized, so the older "standards" and "almost standards" names are nonsensical and no longer used in standards.</remarks>
    public string CompatMode => moduleManager.InvokeSync<string>("DocumentAPI.getCompatMode");

    /// <summary>
    /// Returns the MIME type that the document is being rendered as.
    /// This may come from HTTP headers or other sources of MIME information, and might be affected by automatic type conversions performed by either the browser or extensions.
    /// </summary>
    /// <remarks>Note: This property is unaffected by &lt;meta&gt; elements.</remarks>
    public string ContentType => moduleManager.InvokeSync<string>("DocumentAPI.getContentType");

    /// <summary>
    /// Controls whether the entire document is editable.
    /// Valid values are "on" and "off".
    /// According to the specification, this property is meant to default to "off".
    /// Firefox follows this standard.
    /// The earlier versions of Chrome and IE default to "inherit".
    /// Starting in Chrome 43, the default is "off" and "inherit" is no longer supported.
    /// In IE6-10, the value is capitalized.
    /// </summary>
    public string DesignMode {
        get => moduleManager.InvokeSync<string>("DocumentAPI.getDesignMode");
        set => moduleManager.InvokeSync("DocumentAPI.setDesignMode", [value]);
    }

    /// <summary>
    /// Representing the directionality of the text of the document, whether left to right (default) or right to left.
    /// Possible values are "rtl", right to left, and "ltr", left to right.
    /// </summary>
    public string Dir {
        get => moduleManager.InvokeSync<string>("DocumentAPI.getDir");
        set => moduleManager.InvokeSync("DocumentAPI.setDir", [value]);
    }

    /// <summary>
    /// Returns the document location as a string.
    /// </summary>
    public string DocumentURI => moduleManager.InvokeSync<string>("DocumentAPI.getDocumentURI");

    /// <summary>
    /// <para>Indicates whether or not fullscreen mode is available.</para>
    /// <para>
    /// fullscreen mode is available only for a page that has no windowed plug-ins in any of its documents,
    /// and if all &lt;iframe&gt; elements which contain the document have their allowfullscreen attribute set.
    /// </para>
    /// <para>Although this property is read-only, it will not throw if it is modified (even in strict mode); the setter is a no-operation and it will be ignored.</para>
    /// </summary>
    public bool FullscreenEnabled => moduleManager.InvokeSync<bool>("DocumentAPI.getFullscreenEnabled");

    /// <summary>
    /// <para>Indicates if the page is considered hidden or not.</para>
    /// <para>The <see cref="VisibilityState"/> property provides an alternative way to determine whether the page is hidden.</para>
    /// </summary>
    public bool Hidden => moduleManager.InvokeSync<bool>("DocumentAPI.getHidden");

    /// <summary>
    /// Contains the date and local time on which the current document was last modified.
    /// </summary>
    public string LastModified => moduleManager.InvokeSync<string>("DocumentAPI.getLastModified");

    /// <summary>
    /// <para>Indicates whether or not picture-in-picture mode is available.</para>
    /// <para>Picture-in-Picture mode is available by default unless specified otherwise by a Permissions-Policy.</para>
    /// <para>Although this property is read-only, it will not throw if it is modified (even in strict mode); the setter is a no-operation and will be ignored.</para>
    /// </summary>
    public bool PictureInPictureEnabled => moduleManager.InvokeSync<bool>("DocumentAPI.getPictureInPictureEnabled");

    /// <summary>
    /// <para>Describes the loading state of the document. When the value of this property changes, a readystatechange event fires on the document object.</para>
    /// <para>
    /// The readyState of a document can be one of following:<br />
    /// - "loading": The document is still loading.<br />
    /// - "interactive": The document has finished loading and the document has been parsed but sub-resources such as scripts, images, stylesheets and frames are still loading.
    /// The state indicates that the DOMContentLoaded event is about to fire.<br />
    /// - "complete": The document and all sub-resources have finished loading. The state indicates that the load event is about to fire.
    /// </para>
    /// </summary>
    public string ReadyState => moduleManager.InvokeSync<string>("DocumentAPI.getReadyState");

    /// <summary>
    /// <para>Returns the URI of the page that linked to this page.</para>
    /// <para>
    /// The value is an empty string if the user navigated to the page directly (not through a link, but, for example, by using a bookmark).
    /// Because this property returns only a string, it doesn't give you document object model (DOM) access to the referring page.
    /// </para>
    /// <para>
    /// Inside an &lt;iframe&gt;, the Document.referrer will initially be set to the href of the parent's Window.location in same-origin requests.
    /// In cross-origin requests, it's the origin of the parent's Window.location by default.
    /// For more information, see the <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Headers/Referrer-Policy#strict-origin-when-cross-origin">Referrer-Policy: strict-origin-when-cross-origin</see> documentation.
    /// </para>
    /// </summary>
    public string Referrer => moduleManager.InvokeSync<string>("DocumentAPI.getReferrer");

    /// <summary>
    /// Gets or sets the current title of the document. When present, it defaults to the value of the &lt;title&gt;.
    /// </summary>
    public string Title {
        get => moduleManager.InvokeSync<string>("DocumentAPI.getTitle");
        set => moduleManager.InvokeSync("DocumentAPI.setTitle", [value]);
    }

    /// <summary>
    /// Returns the document location as a string.
    /// </summary>
    public string URL => moduleManager.InvokeSync<string>("DocumentAPI.getURL");

    /// <summary>
    /// <para>Returns the visibility of the document. It can be used to check whether the document is in the background or in a minimized window, or is otherwise not visible to the user.</para>
    /// <para>When the value of this property changes, the visibilitychange event is sent to the Document.</para>
    /// <para>The <see cref="Hidden"/> property provides an alternative way to determine whether the page is hidden.</para>
    /// <para>
    /// The value is a string with one of the following values:<br />
    /// - "visible": The page content may be at least partially visible. In practice this means that the page is the foreground tab of a non-minimized window.<br />
    /// - "hidden": The page content is not visible to the user. In practice this means that the document is either a background tab or part of a minimized window, or the OS screen lock is active.
    /// </para>
    /// </summary>
    public string VisibilityState => moduleManager.InvokeSync<string>("DocumentAPI.getVisibilityState");


    // Properties - Node

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
    public string BaseURI => moduleManager.InvokeSync<string>("DocumentAPI.getBaseURI");



    // methods - DOM

    /// <summary>
    /// Creates the HTML element specified by tagName, or an HTMLUnknownElement if tagName isn't recognized.
    /// </summary>
    /// <param name="tagName">
    /// Specifies the type of element to be created.
    /// Don't use qualified names (like "html:a") with this method.
    /// When called on an HTML document, createElement() converts tagName to lower case before creating the element.
    /// In Firefox, Opera, and Chrome, createElement(null) works like createElement("null").
    /// </param>
    /// <returns></returns>
    public IHTMLElementInProcess CreateElement(string tagName)
        => new HTMLElementInProcess(moduleManager.InvokeSync<IJSInProcessObjectReference>("DocumentAPI.createElement", [tagName]));

    /// <summary>
    /// <para>Creates an element with the specified namespace URI and qualified name.</para>
    /// <para>To create an element without specifying a namespace URI, use the <see cref="CreateElement"/> method.</para>
    /// </summary>
    /// <param name="namespaceURI">
    /// <para>Specifies the namespaceURI to associate with the element.</para>
    /// <para>
    /// Some important namespace URIs are:<br />
    /// - HTML. "http://www.w3.org/1999/xhtml"<br />
    /// - SVG: "http://www.w3.org/2000/svg"<br />
    /// - MathML: "http://www.w3.org/1998/Math/MathML"
    /// </para>
    /// </param>
    /// <param name="qualifiedName">Specifies the type of element to be created. The nodeName property of the created element is initialized with the value of qualifiedName.</param>
    /// <returns></returns>
    public IHTMLElementInProcess CreateElementNS(string namespaceURI, string qualifiedName)
        => new HTMLElementInProcess(moduleManager.InvokeSync<IJSInProcessObjectReference>("DocumentAPI.createElementNS", [namespaceURI, qualifiedName]));

    /// <summary>
    /// <para>
    /// Returns an Element object representing the element whose id property matches the specified string.
    /// Since element IDs are required to be unique if specified, they're a useful way to get access to a specific element quickly.
    /// </para>
    /// <para>If you need to get access to an element which doesn't have an ID, you can use <see cref="QuerySelector"/> to find the element using any selector.</para>
    /// </summary>
    /// <remarks>Note: IDs should be unique inside a document. If two or more elements in a document have the same ID, this method returns the first element found.</remarks>
    /// <param name="elementId">The ID of the element to locate. The ID is a case-sensitive string which is unique within the document; only one element should have any given ID.</param>
    /// <returns></returns>
    public IHTMLElementInProcess? GetElementById(string elementId) {
        IJSInProcessObjectReference?[] singleReference = moduleManager.InvokeSync<IJSInProcessObjectReference?[]>("DocumentAPI.getElementById", [elementId]);
        if (singleReference[0] is IJSInProcessObjectReference element)
            return new HTMLElementInProcess(element);
        else
            return null;
    }

    /// <summary>
    /// <para>Returns all child elements which have all of the given class name(s).</para>
    /// <para>
    /// When called on the document object, the complete document is searched, including the root node.
    /// You may also call getElementsByClassName() on any element; it will return only elements which are descendants of the specified root element with the given class name(s).
    /// </para>
    /// </summary>
    /// <param name="classNames">Representing the class name(s) to match; multiple class names are separated by whitespace.</param>
    /// <returns></returns>
    public IHTMLElementInProcess[] GetElementsByClassName(string classNames) {
        IJSInProcessObjectReference[] elements = moduleManager.InvokeSync<IJSInProcessObjectReference[]>("DocumentAPI.getElementsByClassName", [classNames]);

        HTMLElementInProcess[] result = new HTMLElementInProcess[elements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElementInProcess(elements[i]);
        return result;
    }

    /// <summary>
    /// <para>Returns an HTMLCollection of elements with the given tag name.</para>
    /// <para>The complete document is searched, including the root node.</para>
    /// </summary>
    /// <param name="qualifiedName">Representing the name of the elements. The special string * represents all elements.</param>
    /// <returns></returns>
    public IHTMLElementInProcess[] GetElementsByTagName(string qualifiedName) {
        IJSInProcessObjectReference[] elements = moduleManager.InvokeSync<IJSInProcessObjectReference[]>("DocumentAPI.getElementsByTagName", [qualifiedName]);

        HTMLElementInProcess[] result = new HTMLElementInProcess[elements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElementInProcess(elements[i]);
        return result;
    }

    /// <summary>
    /// Returns a list of elements with the given tag name belonging to the given namespace. The complete document is searched, including the root node.
    /// </summary>
    /// <param name="namespaceURL">The namespace URI of elements to look for.</param>
    /// <param name="localName">Either the local name of elements to look for or the special value *, which matches all elements.</param>
    /// <returns></returns>
    public IHTMLElementInProcess[] GetElementsByTagNameNS(string namespaceURL, string localName) {
        IJSInProcessObjectReference[] elements = moduleManager.InvokeSync<IJSInProcessObjectReference[]>("DocumentAPI.getElementsByTagNameNS", [namespaceURL, localName]);

        HTMLElementInProcess[] result = new HTMLElementInProcess[elements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElementInProcess(elements[i]);
        return result;
    }

    /// <summary>
    /// Returns elements with a given name attribute in the document.
    /// </summary>
    /// <param name="elementName">The value of the name attribute of the element(s) we are looking for.</param>
    /// <returns></returns>
    public IHTMLElementInProcess[] GetElementsByName(string elementName) {
        IJSInProcessObjectReference[] elements = moduleManager.InvokeSync<IJSInProcessObjectReference[]>("DocumentAPI.getElementsByName", [elementName]);

        HTMLElementInProcess[] result = new HTMLElementInProcess[elements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElementInProcess(elements[i]);
        return result;
    }

    /// <summary>
    /// <para>Returns the first Element within the document that matches the specified CSS selector, or group of CSS selectors. If no matches are found, null is returned.</para>
    /// <para>
    /// The matching is done using depth-first pre-order traversal of the document's nodes starting with the first element in the document's markup
    /// and iterating through sequential nodes by order of the number of child nodes.
    /// </para>
    /// <para>If the specified selector matches an ID that is incorrectly used more than once in the document, the first element with that ID is returned.</para>
    /// <para>CSS pseudo-elements will never return any elements.</para>
    /// </summary>
    /// <param name="selectors">
    /// <para>One or more selectors to match. This string must be a valid CSS selector string; if it isn't, a SyntaxError exception is thrown.</para>
    /// <para>
    /// Note that the HTML specification does not require attribute values to be valid CSS identifiers.
    /// If a class or id attribute value is not a valid CSS identifier, then you must escape it before using it in a selector,
    /// either by calling CSS.escape() on the value, or using one of the techniques described in Escaping characters.
    /// See <see href="https://developer.mozilla.org/en-US/docs/Web/API/Document/querySelector#escaping_attribute_values">Escaping attribute values</see> for an example.
    /// </para>
    /// </param>
    /// <returns></returns>
    public IHTMLElementInProcess? QuerySelector(string selectors) {
        IJSInProcessObjectReference?[] singleReference = moduleManager.InvokeSync<IJSInProcessObjectReference?[]>("DocumentAPI.querySelector", [selectors]);
        if (singleReference[0] is IJSInProcessObjectReference element)
            return new HTMLElementInProcess(element);
        else
            return null;
    }

    /// <summary>
    /// Returns a list of the document's elements that match the specified group of selectors.
    /// </summary>
    /// <param name="selectors">
    /// <para>One or more selectors to match. This string must be a valid CSS selector string; if it isn't, a SyntaxError exception is thrown.</para>
    /// <para>
    /// Note that the HTML specification does not require attribute values to be valid CSS identifiers.
    /// If a class or id attribute value is not a valid CSS identifier, then you must escape it before using it in a selector,
    /// either by calling CSS.escape() on the value, or using one of the techniques described in Escaping characters.
    /// See <see href="https://developer.mozilla.org/en-US/docs/Web/API/Document/querySelectorAll#escaping_attribute_values">Escaping attribute values</see> for an example.
    /// </para>
    /// </param>
    /// <returns></returns>
    public IHTMLElementInProcess[] QuerySelectorAll(string selectors) {
        IJSInProcessObjectReference[] elements = moduleManager.InvokeSync<IJSInProcessObjectReference[]>("DocumentAPI.querySelectorAll", [selectors]);

        HTMLElementInProcess[] result = new HTMLElementInProcess[elements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElementInProcess(elements[i]);
        return result;
    }

    /// <summary>
    /// <para>Returns the topmost Element at the specified coordinates (relative to the viewport).</para>
    /// <para>
    /// If the element at the specified point belongs to another document (for example, the document of an &lt;iframe&gt;), that document's parent element is returned (the &lt;iframe&gt; itself).
    /// If the element at the given point is anonymous or XBL generated content, such as a textbox's scroll bars, then the first non-anonymous ancestor element (for example, the textbox) is returned.
    /// </para>
    /// <para>Elements with pointer-events set to none will be ignored, and the element below it will be returned.</para>
    /// <para>If the method is run on another document (like an &lt;iframe&gt;'s subdocument), the coordinates are relative to the document where the method is being called.</para>
    /// <para>If the specified point is outside the visible bounds of the document or either coordinate is negative, the result is null.</para>
    /// </summary>
    /// <param name="x">The horizontal coordinate of a point, relative to the left edge of the current viewport.</param>
    /// <param name="y">The vertical coordinate of a point, relative to the top edge of the current viewport.</param>
    /// <returns></returns>
    public IHTMLElementInProcess? ElementFromPoint(int x, int y) {
        IJSInProcessObjectReference?[] singleReference = moduleManager.InvokeSync<IJSInProcessObjectReference?[]>("DocumentAPI.elementFromPoint", [x, y]);
        if (singleReference[0] is IJSInProcessObjectReference element)
            return new HTMLElementInProcess(element);
        else
            return null;
    }

    /// <summary>
    /// <para>Returns all elements at the specified coordinates (relative to the viewport). The elements are ordered from the topmost to the bottommost box of the viewport.</para>
    /// <para>It operates in a similar way to the <see cref="ElementFromPoint"/> method.</para>
    /// </summary>
    /// <param name="x">The horizontal coordinate of a point.</param>
    /// <param name="y">The vertical coordinate of a point.</param>
    /// <returns></returns>
    public IHTMLElementInProcess[] ElementsFromPoint(int x, int y) {
        IJSInProcessObjectReference[] elements = moduleManager.InvokeSync<IJSInProcessObjectReference[]>("DocumentAPI.elementsFromPoint", [x, y]);

        HTMLElementInProcess[] result = new HTMLElementInProcess[elements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElementInProcess(elements[i]);
        return result;
    }

    /// <summary>
    /// Replaces the existing children of a Document with a specified new set of children.
    /// </summary>
    /// <remarks>It provides a very convenient mechanism for emptying a document of all its children. You call it with an empty array.</remarks>
    /// <param name="children">
    /// A set of Node objects to replace the Document's existing children with.
    /// If no replacement objects are specified, then the Document is emptied of all child nodes.
    /// </param>
    public void ReplaceChildren(IHTMLElementInProcess[] children) {
        IJSInProcessObjectReference[] childrenJS = new IJSInProcessObjectReference[children.Length];
        for (int i = 0; i < childrenJS.Length; i++)
            childrenJS[i] = children[i].HTMLElement;

        moduleManager.InvokeSync("DocumentAPI.replaceChildren", [childrenJS]);
    }


    // methods - exit (ExitFullscreen() and ExitPictureInPicture() are in base class)

    /// <summary>
    /// <para>Asynchronously releases a pointer lock previously requested through <see cref="IHTMLElementInProcess.RequestPointerLock"/>.</para>
    /// <para>To track the success or failure of the request, it is necessary to listen for the <see cref="IDocument.PointerLockChange"/> and <see cref="IDocument.PointerLockError"/> events.</para>
    /// </summary>
    public void ExitPointerLock() => moduleManager.InvokeSync("DocumentAPI.exitPointerLock");


    // methods

    /// <summary>
    /// Indicates whether the document or any element inside the document has focus.
    /// This method can be used to determine whether the active element in a document has focus.
    /// </summary>
    /// <remarks>
    /// Note: When viewing a document, an element with focus is always the active element in the document, but an active element does not necessarily have focus.
    /// For example, an active element within a popup window that is not the foreground doesn't have focus.
    /// </remarks>
    /// <returns></returns>
    public bool HasFocus() => moduleManager.InvokeSync<bool>("DocumentAPI.hasFocus");


    // methods - Node

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
    /// <returns></returns>
    public int CompareDocumentPosition(IHTMLElementInProcess other) => moduleManager.InvokeSync<int>("DocumentAPI.compareDocumentPosition", [other.HTMLElement]);

    /// <summary>
    /// Returns a boolean value indicating whether a node is a descendant of a given node, that is the node itself, one of its direct children (childNodes), one of the children's direct children, and so on.
    /// </summary>
    /// <remarks>Note: A node is contained inside itself.</remarks>
    /// <param name="other">The Node to test with.</param>
    /// <returns></returns>
    public bool Contains(IHTMLElementInProcess other) => moduleManager.InvokeSync<bool>("DocumentAPI.contains", [other.HTMLElement]);

    /// <summary>
    /// Accepts a namespace URI as an argument. It returns a boolean value that is true if the namespace is the default namespace on the given node and false if not.
    /// </summary>
    /// <param name="namespaceURI">A string representing the namespace against which the element will be checked.</param>
    /// <returns></returns>
    public bool IsDefaultNamespace(string? namespaceURI) => moduleManager.InvokeSync<bool>("DocumentAPI.isDefaultNamespace", [namespaceURI]);

    /// <summary>
    /// <para>Returns a string containing the prefix for a given namespace URI, if present, and null if not. When multiple prefixes are possible, the first prefix is returned.</para>
    /// <para>If the node is a <i>DocumentType</i> or a <i>DocumentFragment</i>, it returns null.</para>
    /// </summary>
    /// <param name="namespace">A string containing the namespace to look the prefix up.</param>
    /// <returns></returns>
    public string? LookupPrefix(string? @namespace) => moduleManager.InvokeSync<string?>("DocumentAPI.lookupPrefix", [@namespace]);

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
    /// <returns></returns>
    public string? LookupNamespaceURI(string? prefix) => moduleManager.InvokeSync<string?>("DocumentAPI.lookupNamespaceURI", [prefix]);

    /// <summary>
    /// Puts the specified node and all of its sub-tree into a normalized form. In a normalized sub-tree, no text nodes in the sub-tree are empty and there are no adjacent text nodes.
    /// </summary>
    public void Normalize() => moduleManager.InvokeSync("DocumentAPI.normalize");
}
