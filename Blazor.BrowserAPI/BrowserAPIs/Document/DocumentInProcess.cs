using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

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
}
