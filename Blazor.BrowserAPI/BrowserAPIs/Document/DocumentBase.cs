using AutoInterfaceAttributes;
using Microsoft.JSInterop;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IDocument")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IDocumentInProcess")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class DocumentBase(IModuleManager moduleManager) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IModuleManager moduleManager = moduleManager;


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
    /// <remarks>
    /// Note: Since this is a <see href="https://developer.mozilla.org/en-US/docs/Web/API/Document">Document</see>, this property always returns "#document".
    /// </remarks>
    public string NodeName => "#document";

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
    /// <remarks>
    /// Note: Since this is a <see href="https://developer.mozilla.org/en-US/docs/Web/API/Document">Document</see>, this property always returns 9.
    /// </remarks>
    public int NodeType => 9;


    // methods - StorageAccess

    /// <summary>
    /// <para>
    /// Allows content loaded in a third-party context (i.e., embedded in an &lt;iframe&gt;) to request access to third-party cookies and unpartitioned state.
    /// This is relevant to user agents that, by default, block access to third-party, unpartitioned cookies to improve privacy (e.g., to prevent tracking), and is part of the Storage Access API.
    /// </para>
    /// <para>To check whether permission to access third-party cookies has already been granted, you can call <see cref="IPermissions.Query"/>, specifying the feature name "storage-access".</para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Note: Usage of this feature may be blocked by a storage-access Permissions Policy set on your server.
    /// In addition, the document must pass additional browser-specific checks such as allowlists, blocklists, on-device classification, user settings, anti-clickjacking heuristics,
    /// or prompting the user for explicit permission.
    /// </para>
    /// <para>
    /// RequestStorageAccess() requests are automatically denied unless the embedded content is currently processing a user gesture such as a tap or click (transient activation),
    /// or unless permission was already granted previously.
    /// If permission was not previously granted, they need to be run inside a user gesture-based event handler. The user gesture behavior depends on the state of the promise:<br />
    /// - If the promise resolves (i.e., if permission was granted), then the user gesture has not been consumed, so the script can subsequently call APIs that require a user gesture.<br />
    /// - If the promise rejects (i.e., permission was not granted), then the user gesture has been consumed, so the script can't do anything that requires a gesture.
    /// This is intentional protection against abuse — it prevents scripts from calling RequestStorageAccess() in a loop until the user accepts the prompt.
    /// </para>
    /// </remarks>
    /// <param name="all">Specifies all possible unpartitioned states should be made accessible.</param>
    /// <param name="cookies">Specifies third-party cookies should be made accessible.</param>
    /// <param name="sessionStorage">Specifies StorageAccessHandle.sessionStorage should be made accessible.</param>
    /// <param name="localStorage">Specifies StorageAccessHandle.localStorage should be made accessible.</param>
    /// <param name="indexedDB">Specifies StorageAccessHandle.indexedDB should be made accessible.</param>
    /// <param name="locks">Specifies StorageAccessHandle.locks should be made accessible.</param>
    /// <param name="caches">Specifies StorageAccessHandle.caches should be made accessible.</param>
    /// <param name="getDirectory">Specifies StorageAccessHandle.getDirectory() should be made accessible.</param>
    /// <param name="estimate">Specifies StorageAccessHandle.estimate() should be made accessible.</param>
    /// <param name="createObjectURL">Specifies StorageAccessHandle.createObjectURL() should be made accessible.</param>
    /// <param name="revokeObjectURL">Specifies StorageAccessHandle.revokeObjectURL() should be made accessible.</param>
    /// <param name="BroadcastChannel">Specifies StorageAccessHandle.BroadcastChannel() should be made accessible.</param>
    /// <param name="SharedWorker">Specifies StorageAccessHandle.SharedWorker() should be made accessible.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask RequestStorageAccess(bool all = false, bool cookies = false, bool sessionStorage = false, bool localStorage = false, bool indexedDB = false, bool locks = false, bool caches = false, bool getDirectory = false, bool estimate = false, bool createObjectURL = false, bool revokeObjectURL = false, bool BroadcastChannel = false, bool SharedWorker = false, CancellationToken cancellationToken = default)
        => moduleManager.InvokeAsync("DocumentAPI.requestStorageAccess", cancellationToken, [all, cookies, sessionStorage, localStorage, indexedDB, locks, caches, getDirectory, estimate, createObjectURL, revokeObjectURL, BroadcastChannel, SharedWorker]);

    /// <summary>
    /// Allows top-level sites to request third-party cookie access on behalf of embedded content originating from another site in the same related website set.
    /// It returns a Promise that resolves if the access was granted, and rejects if access was denied.
    /// </summary>
    /// <remarks>
    /// RequestStorageAccessFor() requests are automatically denied unless the top-level content is currently processing a user gesture such as a tap or click (transient activation),
    /// or unless permission was already granted previously.
    /// If permission was not previously granted, they must run inside a user gesture-based event handler.
    /// The user gesture behavior depends on the state of the promise:<br />
    /// - If the promise resolves (i.e., permission was granted), then the user gesture has not been consumed, so the script can subsequently call APIs requiring a user gesture.<br />
    /// - If the promise is rejected (i.e., permission was not granted), then the user gesture has been consumed, so the script can't do anything that requires a gesture.
    /// This prevents scripts from calling RequestStorageAccessFor() again if permission is denied.
    /// </remarks>
    /// <param name="requestedOrigin">A string representing the URL of the origin you are requesting third-party cookie access for.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask RequestStorageAccessFor(string requestedOrigin, CancellationToken cancellationToken = default) => moduleManager.InvokeAsync("DocumentAPI.requestStorageAccessFor", cancellationToken, [requestedOrigin]);

    /// <summary>
    /// <para>Resolves with a boolean value indicating whether the document has access to third-party, unpartitioned cookies.</para>
    /// <para>This method is part of the Storage Access API.</para>
    /// </summary>
    /// <remarks>Note: This method is another name for Document.hasUnpartitionedCookieAccess(). There are no current plans to remove this method in favor of Document.hasUnpartitionedCookieAccess().</remarks>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> HasStorageAccess(CancellationToken cancellationToken = default) => moduleManager.InvokeAsync<bool>("DocumentAPI.hasStorageAccess", cancellationToken);


    // methods - exit (ExitPointerLock() is in derived classes)

    /// <summary>
    /// Requests that the element on this document which is currently being presented in fullscreen mode be taken out of fullscreen mode, restoring the previous state of the screen.
    /// This usually reverses the effects of a previous call to <see cref="IHTMLElement.RequestFullscreen"/>.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask ExitFullscreen(CancellationToken cancellationToken = default) => moduleManager.InvokeAsync("DocumentAPI.exitFullscreen", cancellationToken);

    /// <summary>
    /// Requests that a video contained in this document, which is currently floating, be taken out of picture-in-picture mode, restoring the previous state of the screen.
    /// This usually reverses the effects of a previous call to <see cref="IHTMLMediaElement.RequestPictureInPicture"/>.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask ExitPictureInPicture(CancellationToken cancellationToken = default) => moduleManager.InvokeAsync("DocumentAPI.exitPictureInPicture", cancellationToken);
}
