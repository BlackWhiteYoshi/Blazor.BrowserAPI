using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

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
public sealed class Document(IModuleManager moduleManager) : DocumentBase(moduleManager), IDocument {
    // Properties - HTMLElement reference

    /// <summary>
    /// Returns the Element that is the root element of the document (for example, the &lt;html&gt; element for HTML documents).
    /// </summary>
    public IHTMLElement DocumentElement => new HTMLElement(moduleManager.InvokeTrySync<IJSObjectReference>("DocumentAPI.getDocumentElement", default).AsTask());

    /// <summary>
    /// Returns the &lt;head&gt; element of the current document.
    /// </summary>
    public IHTMLElement Head => new HTMLElement(moduleManager.InvokeTrySync<IJSObjectReference>("DocumentAPI.getHead", default).AsTask());

    /// <summary>
    /// Represents the &lt;body&gt; or &lt;frameset&gt; node of the current document, or null if no such element exists.
    /// </summary>
    public IHTMLElement Body => new HTMLElement(moduleManager.InvokeTrySync<IJSObjectReference>("DocumentAPI.getBody", default).AsTask());

    /// <summary>
    /// Represents the &lt;body&gt; or &lt;frameset&gt; node of the current document, or null if no such element exists.
    /// </summary>
    public async ValueTask SetBody(IHTMLElement value, CancellationToken cancellationToken = default) => await moduleManager.InvokeTrySync("DocumentAPI.setBody", cancellationToken, [await value.HTMLElementTask]);

    /// <summary>
    /// <para>Returns a reference to the Element that scrolls the document. In standards mode, this is the root element of the document, <see cref="DocumentElement"/>.</para>
    /// <para>
    /// When in quirks mode, the scrollingElement attribute returns the HTML body element if it exists and is not potentially scrollable, otherwise it returns null.
    /// This may look surprising but is true according to both the specification and browsers.
    /// </para>
    /// </summary>
    public IHTMLElement ScrollingElement => new HTMLElement(moduleManager.InvokeTrySync<IJSObjectReference>("DocumentAPI.getScrollingElement", default).AsTask());


    // Properties - HTMLElement Collection

    /// <summary>
    /// Returns a list of the embedded &lt;embed&gt; elements within the current document.
    /// </summary>
    public ValueTask<IHTMLElement[]> Embeds => GetEmbeds(default);

    /// <inheritdoc cref="Embeds" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement[]> GetEmbeds(CancellationToken cancellationToken) {
        IJSObjectReference[] embedElements = await moduleManager.InvokeTrySync<IJSObjectReference[]>("DocumentAPI.getEmbeds", default);

        IHTMLElement[] result = new IHTMLElement[embedElements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElement(Task.FromResult(embedElements[i]));
        return result;
    }


    /// <summary>
    /// Returns an HTMLCollection listing all the &lt;form&gt; elements contained in the document.
    /// </summary>
    public ValueTask<IHTMLElement[]> Forms => GetForms(default);

    /// <inheritdoc cref="Forms" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement[]> GetForms(CancellationToken cancellationToken) {
        IJSObjectReference[] formElements = await moduleManager.InvokeTrySync<IJSObjectReference[]>("DocumentAPI.getForms", default);

        IHTMLElement[] result = new IHTMLElement[formElements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElement(Task.FromResult(formElements[i]));
        return result;
    }


    /// <summary>
    /// Returns a collection of the images in the current HTML document.
    /// Each entry in the collection is an HTMLImageElement &lt;img&gt; representing a single image element.
    /// </summary>
    public ValueTask<IHTMLElement[]> Images => GetImages(default);

    /// <inheritdoc cref="Images" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement[]> GetImages(CancellationToken cancellationToken) {
        IJSObjectReference[] imageElements = await moduleManager.InvokeTrySync<IJSObjectReference[]>("DocumentAPI.getImages", default);

        IHTMLElement[] result = new IHTMLElement[imageElements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElement(Task.FromResult(imageElements[i]));
        return result;
    }


    /// <summary>
    /// Returns a collection of all &lt;area&gt; elements and &lt;a&gt; elements in a document with a value for the href attribute.
    /// </summary>
    public ValueTask<IHTMLElement[]> Links => GetLinks(default);

    /// <inheritdoc cref="Links" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement[]> GetLinks(CancellationToken cancellationToken) {
        IJSObjectReference[] linkElements = await moduleManager.InvokeTrySync<IJSObjectReference[]>("DocumentAPI.getLinks", default);

        IHTMLElement[] result = new IHTMLElement[linkElements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElement(Task.FromResult(linkElements[i]));
        return result;
    }


    /// <summary>
    /// Returns an HTMLCollection object containing one or more HTMLEmbedElements representing the &lt;embed&gt; elements in the current document.
    /// </summary>
    public ValueTask<IHTMLElement[]> Plugins => GetPlugins(default);

    /// <inheritdoc cref="Plugins" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement[]> GetPlugins(CancellationToken cancellationToken) {
        IJSObjectReference[] pluginElements = await moduleManager.InvokeTrySync<IJSObjectReference[]>("DocumentAPI.getPlugins", default);

        IHTMLElement[] result = new IHTMLElement[pluginElements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElement(Task.FromResult(pluginElements[i]));
        return result;
    }


    /// <summary>
    /// Returns a list of the &lt;script&gt; elements in the document.
    /// </summary>
    public ValueTask<IHTMLElement[]> Scripts => GetScripts(default);

    /// <inheritdoc cref="Scripts" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement[]> GetScripts(CancellationToken cancellationToken) {
        IJSObjectReference[] scriptElements = await moduleManager.InvokeTrySync<IJSObjectReference[]>("DocumentAPI.getScripts", default);

        IHTMLElement[] result = new IHTMLElement[scriptElements.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new HTMLElement(Task.FromResult(scriptElements[i]));
        return result;
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
    public ValueTask<IHTMLElement?> ActiveElement => GetActiveElement(default);

    /// <inheritdoc cref="ActiveElement" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> GetActiveElement(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await moduleManager.InvokeTrySync<IJSObjectReference?[]>("DocumentAPI.getActiveElement", cancellationToken);
        if (singleReference[0] is IJSObjectReference htmlElement)
            return new HTMLElement(Task.FromResult(htmlElement));
        else
            return null;
    }


    /// <summary>
    /// <para>Returns the &lt;script&gt; element whose script is currently being processed and isn't a JavaScript module. (For modules use import.meta instead.)</para>
    /// <para>
    /// It's important to note that this will not reference the &lt;script&gt; element if the code in the script is being called as a callback or event handler;
    /// it will only reference the element while it's initially being processed.
    /// </para>
    /// </summary>
    public ValueTask<IHTMLElement?> CurrentScript => GetCurrentScript(default);

    /// <inheritdoc cref="CurrentScript" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> GetCurrentScript(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await moduleManager.InvokeTrySync<IJSObjectReference?[]>("DocumentAPI.getCurrentScript", cancellationToken);
        if (singleReference[0] is IJSObjectReference htmlElement)
            return new HTMLElement(Task.FromResult(htmlElement));
        else
            return null;
    }


    /// <summary>
    /// <para>Returns the Element that is currently being presented in fullscreen mode in this document, or null if fullscreen mode is not currently in use.</para>
    /// <para>Although this property is read-only, it will not throw if it is modified (even in strict mode); the setter is a no-operation and it will be ignored.</para>
    /// </summary>
    public ValueTask<IHTMLElement?> FullscreenElement => GetFullscreenElement(default);

    /// <inheritdoc cref="FullscreenElement" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> GetFullscreenElement(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await moduleManager.InvokeTrySync<IJSObjectReference?[]>("DocumentAPI.getFullscreenElement", cancellationToken);
        if (singleReference[0] is IJSObjectReference htmlElement)
            return new HTMLElement(Task.FromResult(htmlElement));
        else
            return null;
    }


    /// <summary>
    /// <para>Returns the Element that is currently being presented in picture-in-picture mode in this document, or null if picture-in-picture mode is not currently in use.</para>
    /// <para>Although this property is read-only, it will not throw if it is modified (even in strict mode); the setter is a no-operation and will be ignored.</para>
    /// </summary>
    public ValueTask<IHTMLElement?> PictureInPictureElement => GetPictureInPictureElement(default);

    /// <inheritdoc cref="PictureInPictureElement" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> GetPictureInPictureElement(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await moduleManager.InvokeTrySync<IJSObjectReference?[]>("DocumentAPI.getPictureInPictureElement", cancellationToken);
        if (singleReference[0] is IJSObjectReference htmlElement)
            return new HTMLElement(Task.FromResult(htmlElement));
        else
            return null;
    }


    /// <summary>
    /// Provides the element set as the target for mouse events while the pointer is locked.
    /// It is null if lock is pending, pointer is unlocked, or the target is in another document.
    /// </summary>
    public ValueTask<IHTMLElement?> PointerLockElement => GetPointerLockElement(default);

    /// <inheritdoc cref="PointerLockElement" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> GetPointerLockElement(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await moduleManager.InvokeTrySync<IJSObjectReference?[]>("DocumentAPI.getPointerLockElement", cancellationToken);
        if (singleReference[0] is IJSObjectReference htmlElement)
            return new HTMLElement(Task.FromResult(htmlElement));
        else
            return null;
    }


    // Properties

    /// <summary>
    /// Returns the character encoding of the document that it's currently rendered with.
    /// </summary>
    /// <remarks>Note: A "character set" and a "character encoding" are related, but different. Despite the name of this property, it returns the encoding.</remarks>
    public ValueTask<string> CharacterSet => GetCharacterSet(default);

    /// <inheritdoc cref="CharacterSet" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetCharacterSet(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("DocumentAPI.getCharacterSet", cancellationToken);


    /// <summary>
    /// <para>Indicates whether the document is rendered in Quirks mode or Standards mode.</para>
    /// <para>
    /// The value is a string that is one of the following:<br />
    /// - "BackCompat": The document is in quirks mode.<br />
    /// - "CSS1Compat": The document is in no-quirks (also known as "standards") mode or limited-quirks (also known as "almost standards") mode.
    /// </para>
    /// </summary>
    /// <remarks>Note: All these modes are now standardized, so the older "standards" and "almost standards" names are nonsensical and no longer used in standards.</remarks>
    public ValueTask<string> CompatMode => GetCompatMode(default);

    /// <inheritdoc cref="CompatMode" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetCompatMode(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("DocumentAPI.getCompatMode", cancellationToken);


    /// <summary>
    /// Returns the MIME type that the document is being rendered as.
    /// This may come from HTTP headers or other sources of MIME information, and might be affected by automatic type conversions performed by either the browser or extensions.
    /// </summary>
    /// <remarks>Note: This property is unaffected by &lt;meta&gt; elements.</remarks>
    public ValueTask<string> ContentType => GetContentType(default);

    /// <inheritdoc cref="ContentType" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetContentType(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("DocumentAPI.getContentType", cancellationToken);


    /// <summary>
    /// Controls whether the entire document is editable.
    /// Valid values are "on" and "off".
    /// According to the specification, this property is meant to default to "off".
    /// Firefox follows this standard.
    /// The earlier versions of Chrome and IE default to "inherit".
    /// Starting in Chrome 43, the default is "off" and "inherit" is no longer supported.
    /// In IE6-10, the value is capitalized.
    /// </summary>
    public ValueTask<string> DesignMode => GetDesignMode(default);

    /// <inheritdoc cref="DesignMode" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetDesignMode(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("DocumentAPI.getDesignMode", cancellationToken);

    /// <inheritdoc cref="DesignMode" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask SetDesignMode(string value, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("DocumentAPI.setDesignMode", cancellationToken, [value]);


    /// <summary>
    /// Representing the directionality of the text of the document, whether left to right (default) or right to left.
    /// Possible values are "rtl", right to left, and "ltr", left to right.
    /// </summary>
    public ValueTask<string> Dir => GetDir(default);

    /// <inheritdoc cref="Dir" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetDir(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("DocumentAPI.getDir", cancellationToken);

    /// <inheritdoc cref="Dir" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask SetDir(string value, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("DocumentAPI.setDir", cancellationToken, [value]);


    /// <summary>
    /// Returns the document location as a string.
    /// </summary>
    public ValueTask<string> DocumentURI => GetDocumentURI(default);

    /// <inheritdoc cref="DocumentURI" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetDocumentURI(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("DocumentAPI.getDocumentURI", cancellationToken);


    /// <summary>
    /// <para>Indicates whether or not fullscreen mode is available.</para>
    /// <para>
    /// fullscreen mode is available only for a page that has no windowed plug-ins in any of its documents,
    /// and if all &lt;iframe&gt; elements which contain the document have their allowfullscreen attribute set.
    /// </para>
    /// <para>Although this property is read-only, it will not throw if it is modified (even in strict mode); the setter is a no-operation and it will be ignored.</para>
    /// </summary>
    public ValueTask<bool> FullscreenEnabled => GetFullscreenEnabled(default);

    /// <inheritdoc cref="FullscreenEnabled" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetFullscreenEnabled(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("DocumentAPI.getFullscreenEnabled", cancellationToken);


    /// <summary>
    /// <para>Indicates if the page is considered hidden or not.</para>
    /// <para>The <see cref="VisibilityState"/> property provides an alternative way to determine whether the page is hidden.</para>
    /// </summary>
    public ValueTask<bool> Hidden => GetHidden(default);

    /// <inheritdoc cref="Hidden" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetHidden(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("DocumentAPI.getHidden", cancellationToken);


    /// <summary>
    /// Contains the date and local time on which the current document was last modified.
    /// </summary>
    public ValueTask<string> LastModified => GetLastModified(default);

    /// <inheritdoc cref="LastModified" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetLastModified(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("DocumentAPI.getLastModified", cancellationToken);


    /// <summary>
    /// <para>Indicates whether or not picture-in-picture mode is available.</para>
    /// <para>Picture-in-Picture mode is available by default unless specified otherwise by a Permissions-Policy.</para>
    /// <para>Although this property is read-only, it will not throw if it is modified (even in strict mode); the setter is a no-operation and will be ignored.</para>
    /// </summary>
    public ValueTask<bool> PictureInPictureEnabled => GetPictureInPictureEnabled(default);

    /// <inheritdoc cref="PictureInPictureEnabled" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetPictureInPictureEnabled(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("DocumentAPI.getPictureInPictureEnabled", cancellationToken);


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
    public ValueTask<string> ReadyState => GetReadyState(default);

    /// <inheritdoc cref="ReadyState" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetReadyState(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("DocumentAPI.getReadyState", cancellationToken);


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
    public ValueTask<string> Referrer => GetReferrer(default);

    /// <inheritdoc cref="Referrer" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetReferrer(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("DocumentAPI.getReferrer", cancellationToken);


    /// <summary>
    /// Gets or sets the current title of the document. When present, it defaults to the value of the &lt;title&gt;.
    /// </summary>
    public ValueTask<string> Title => GetTitle(default);

    /// <inheritdoc cref="Title" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetTitle(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("DocumentAPI.getTitle", cancellationToken);

    /// <inheritdoc cref="Title" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask SetTitle(string value, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("DocumentAPI.setTitle", cancellationToken, [value]);


    /// <summary>
    /// Returns the document location as a string.
    /// </summary>
    public ValueTask<string> URL => GetURL(default);

    /// <inheritdoc cref="URL" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetURL(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("DocumentAPI.getURL", cancellationToken);


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
    public ValueTask<string> VisibilityState => GetVisibilityState(default);

    /// <inheritdoc cref="VisibilityState" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetVisibilityState(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("DocumentAPI.getVisibilityState", cancellationToken);


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
    public ValueTask<string> BaseURI => GetBaseURI(default);

    /// <inheritdoc cref="BaseURI" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetBaseURI(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("DocumentAPI.getBaseURI", cancellationToken);
}
