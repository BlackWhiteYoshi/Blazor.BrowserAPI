using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class DocumentInProcessGroup : ComponentBase {
    public const string TEST_SET_BODY = "body set";
    public const string TEST_NO_REFFERER = "(no referrer)";
    public const string TEST_SET_TITLE = "new document title";
    public const string TEST_ELEMENT_NAME = "some element name";
    public const string TEST_REQUEST_STORAGE_ACCESS = "got storage access";
    public const string TEST_REQUEST_STORAGE_ACCESS_FOR = "got storage access for localhost";


    [Inject]
    public required IDocumentInProcess Document { private get; init; }


    public const string LABEL_OUTPUT = "document-inprocess-output";
    private string labelOutput = string.Empty;


    // Properties - HTMLElement reference

    public const string BUTTON_GET_DOCUMENT_ELEMENT = "document-inprocess-get-document-element";
    private void GetDocumentElement() {
        using IHTMLElementInProcess documentElement = Document.DocumentElement;
        labelOutput = (documentElement is not null).ToString();
    }

    public const string BUTTON_GET_HEAD = "document-inprocess-get-head";
    private void GetHead() {
        using IHTMLElementInProcess head = Document.Head;
        labelOutput = (head is not null).ToString();
    }

    public const string BUTTON_GET_BODY = "document-inprocess-get-body";
    private void GetBody() {
        using IHTMLElementInProcess body = Document.Body;
        labelOutput = (body is not null).ToString();
    }

    public const string BUTTON_SET_BODY = "document-inprocess-set-body";
    private void SetBody() {
        Document.Body = Document.Body;
        labelOutput = TEST_SET_BODY;
    }

    public const string BUTTON_GET_SCROLLING_ELEMENT = "document-inprocess-get-scrolling-element";
    private void GetScrollingElement() {
        using IHTMLElementInProcess scrollingElement = Document.ScrollingElement;
        labelOutput = (scrollingElement is not null).ToString();
    }


    // Properties - HTMLElement Collection

    public const string BUTTON_GET_EMBEDS = "document-inprocess-get-embeds";
    private void GetEmbeds() {
        IHTMLElementInProcess[] embedElements = Document.Embeds;
        labelOutput = embedElements.Length.ToString();

        embedElements.Dispose();
    }

    public const string BUTTON_GET_FORMS = "document-inprocess-get-forms";
    private void GetForms() {
        IHTMLElementInProcess[] formElements = Document.Forms;
        labelOutput = formElements.Length.ToString();

        formElements.Dispose();
    }

    public const string BUTTON_GET_IMAGES = "document-inprocess-get-images";
    private void GetImages() {
        IHTMLElementInProcess[] imageElements = Document.Images;
        labelOutput = imageElements.Length.ToString();

        imageElements.Dispose();
    }

    public const string BUTTON_GET_LINKS = "document-inprocess-get-links";
    private void GetLinks() {
        IHTMLElementInProcess[] linkElements = Document.Links;
        labelOutput = linkElements.Length.ToString();

        linkElements.Dispose();
    }

    public const string BUTTON_GET_PLUGINS = "document-inprocess-get-plugins";
    private void GetPlugins() {
        IHTMLElementInProcess[] pluginElements = Document.Plugins;
        labelOutput = pluginElements.Length.ToString();

        pluginElements.Dispose();
    }

    public const string BUTTON_GET_SCRIPTS = "document-inprocess-get-scripts";
    private void GetScripts() {
        IHTMLElementInProcess[] scriptElements = Document.Scripts;
        labelOutput = scriptElements.Length.ToString();

        scriptElements.Dispose();
    }


    // Properties - HTMLElement situational

    public const string BUTTON_GET_ACTIVE_ELEMENT = "document-inprocess-get-active-element";
    private void GetActiveElement() {
        using IHTMLElementInProcess? activeElement = Document.ActiveElement;
        labelOutput = (activeElement is not null).ToString();
    }

    public const string BUTTON_GET_CURRENT_SCRIPT = "document-inprocess-get-current-script";
    private void GetCurrentScript() {
        using IHTMLElementInProcess? currentScript = Document.CurrentScript;
        labelOutput = (currentScript is not null).ToString();
    }

    public const string BUTTON_GET_FULLSCREEN_ELEMENT = "document-inprocess-get-fullscreen-element";
    private void GetFullscreenElement() {
        using IHTMLElementInProcess? fullscreenElement = Document.FullscreenElement;
        labelOutput = (fullscreenElement is not null).ToString();
    }

    public const string BUTTON_GET_PICTURE_IN_PICTURE_ELEMENT = "document-inprocess-get-picture-in-picture-element";
    private void GetPictureInPictureElement() {
        using IHTMLElementInProcess? pictureInPicture = Document.PictureInPictureElement;
        labelOutput = (pictureInPicture is not null).ToString();
    }

    public const string BUTTON_GET_POINTER_LOCK_ELEMENT = "document-inprocess-get-pointer-lock-element";
    private void GetPointerLockElement() {
        using IHTMLElementInProcess? pointerLockElement = Document.PointerLockElement;
        labelOutput = (pointerLockElement is not null).ToString();
    }


    // Properties

    public const string BUTTON_GET_CHARACTER_SET = "document-inprocess-get-character-set";
    private void GetCharacterSet() {
        string characterSet = Document.CharacterSet;
        labelOutput = characterSet;
    }

    public const string BUTTON_GET_COMPAT_MODE = "document-inprocess-get-compat-mode";
    private void GetCompatMode() {
        string compatMode = Document.CompatMode;
        labelOutput = compatMode;
    }

    public const string BUTTON_GET_CONTENT_TYPE = "document-inprocess-get-content-type";
    private void GetContentType() {
        string contentType = Document.ContentType;
        labelOutput = contentType;
    }

    public const string BUTTON_GET_DESIGN_MODE = "document-inprocess-get-design-mode";
    private void GetDesignMode() {
        string designMode = Document.DesignMode;
        labelOutput = designMode;
    }

    public const string BUTTON_SET_DESIGN_MODE = "document-inprocess-set-design-mode";
    private void SetDesignMode() {
        Document.DesignMode = "on";
    }

    public const string BUTTON_GET_DIR = "document-inprocess-get-dir";
    private void GetDir() {
        string dir = Document.Dir;
        labelOutput = dir;
    }

    public const string BUTTON_SET_DIR = "document-inprocess-set-dir";
    private void SetDir() {
        Document.Dir = "rtl";
    }

    public const string BUTTON_GET_DOCUMENT_URI = "document-inprocess-get-document-uri";
    private void GetDocumentURI() {
        string documentURI = Document.DocumentURI;
        labelOutput = documentURI;
    }

    public const string BUTTON_GET_FULLSCREEN_ENABLED = "document-inprocess-get-fullscreen-enabled";
    private void GetFullscreenEnabled() {
        bool fullscreenEnabled = Document.FullscreenEnabled;
        labelOutput = fullscreenEnabled.ToString();
    }

    public const string BUTTON_GET_HIDDEN = "document-inprocess-get-hidden";
    private void GetHidden() {
        bool hidden = Document.Hidden;
        labelOutput = hidden.ToString();
    }

    public const string BUTTON_GET_LAST_MODIFIED = "document-inprocess-get-last-modified";
    private void GetLastModified() {
        string lastModified = Document.LastModified;
        labelOutput = lastModified;
    }

    public const string BUTTON_GET_PICTURE_IN_PICTURE_ENABLED = "document-inprocess-get-picture-in-picture-enabled";
    private void GetPictureInPictureEnabled() {
        bool pictureInPictureEnabled = Document.PictureInPictureEnabled;
        labelOutput = pictureInPictureEnabled.ToString();
    }

    public const string BUTTON_GET_READY_STATE = "document-inprocess-get-ready-state";
    private void GetReadyState() {
        string readyState = Document.ReadyState;
        labelOutput = readyState;
    }

    public const string BUTTON_GET_REFERRER = "document-inprocess-get-referrer";
    private void GetReferrer() {
        string referrer = Document.Referrer;
        labelOutput = referrer is not "" ? referrer : TEST_NO_REFFERER;
    }

    public const string BUTTON_GET_TITLE = "document-inprocess-get-title";
    private void GetTitle() {
        string title = Document.Title;
        labelOutput = title;
    }

    public const string BUTTON_SET_TITLE = "document-inprocess-set-title";
    private void SetTitle() {
        Document.Title = TEST_SET_TITLE;
    }

    public const string BUTTON_GET_URL = "document-inprocess-get-url";
    private void GetURL() {
        string url = Document.URL;
        labelOutput = url;
    }

    public const string BUTTON_GET_VISIBILITY_STATE = "document-inprocess-get-visibility-state";
    private void GetVisibilityState() {
        string visibilityState = Document.VisibilityState;
        labelOutput = visibilityState;
    }


    // Properties - Node

    public const string BUTTON_GET_BASE_URI = "document-inprocess-get-base-uri";
    private void GetBaseURI() {
        string baseURI = Document.BaseURI;
        labelOutput = baseURI;
    }

    public const string BUTTON_GET_NODE_NAME = "document-inprocess-get-node-name";
    private void GetNodeName() {
        string nodeName = Document.NodeName;
        labelOutput = nodeName;
    }

    public const string BUTTON_GET_NODE_TYPE = "document-inprocess-get-node-type";
    private void GetNodeType() {
        int nodeType = Document.NodeType;
        labelOutput = nodeType.ToString();
    }



    // methods - DOM

    public const string BUTTON_CREATE_ELEMENT = "document-inprocess-create-element";
    private void CreateElement() {
        using IHTMLElementInProcess htmlElement = Document.CreateElement("label");
        labelOutput = (htmlElement is not null).ToString();
    }

    public const string BUTTON_CREATE_ELEMENT_NS = "document-inprocess-create-element-ns";
    private void CreateElementNS() {
        using IHTMLElementInProcess htmlElement = Document.CreateElementNS("http://www.w3.org/1999/xhtml", "label");
        labelOutput = (htmlElement is not null).ToString();
    }

    public const string BUTTON_GET_ELEMENT_BY_ID = "document-inprocess-get-element-by-id";
    private void GetElementById() {
        using IHTMLElementInProcess? htmlElement = Document.GetElementById("test-page");
        labelOutput = (htmlElement is not null).ToString();
    }

    public const string BUTTON_GET_ELEMENTS_BY_CLASS_NAME = "document-inprocess-get-elements-by-class-name";
    private void GetElementsByClassName() {
        IHTMLElementInProcess[] htmlElements = Document.GetElementsByClassName("group");
        labelOutput = htmlElements.Length.ToString();

        htmlElements.Dispose();
    }

    public const string BUTTON_GET_ELEMENTS_BY_TAG_NAME = "document-inprocess-get-elements-by-tag-name";
    private void GetElementsByTagName() {
        IHTMLElementInProcess[] htmlElements = Document.GetElementsByTagName("h1");
        labelOutput = htmlElements.Length.ToString();

        htmlElements.Dispose();
    }

    public const string BUTTON_GET_ELEMENTS_BY_TAG_NAME_NS = "document-inprocess-get-elements-by-tag-name-ns";
    private void GetElementsByTagNameNS() {
        IHTMLElementInProcess[] htmlElements = Document.GetElementsByTagNameNS("http://www.w3.org/1999/xhtml", "h1");
        labelOutput = htmlElements.Length.ToString();

        htmlElements.Dispose();
    }

    public const string BUTTON_GET_ELEMENTS_BY_NAME = "document-inprocess-get-elements-by-name";
    private void GetElementsByName() {
        IHTMLElementInProcess[] htmlElements = Document.GetElementsByName(TEST_ELEMENT_NAME);
        labelOutput = htmlElements.Length.ToString();

        htmlElements.Dispose();
    }

    public const string BUTTON_QUERY_SELECTOR = "document-inprocess-query-selector";
    private void QuerySelector() {
        using IHTMLElementInProcess? htmlElement = Document.QuerySelector(".group");
        labelOutput = (htmlElement is not null).ToString();
    }

    public const string BUTTON_QUERY_SELECTOR_ALL = "document-inprocess-query-selector-all";
    private void QuerySelectorAll() {
        IHTMLElementInProcess[] htmlElements = Document.QuerySelectorAll(".group");
        labelOutput = htmlElements.Length.ToString();

        htmlElements.Dispose();
    }

    public const string BUTTON_ELEMENT_FROM_POINT = "document-inprocess-element-from-point";
    private void ElementFromPoint() {
        using IHTMLElementInProcess? htmlElement = Document.ElementFromPoint(1, 1);
        labelOutput = (htmlElement is not null).ToString();
    }

    public const string BUTTON_ELEMENTS_FROM_POINT = "document-inprocess-elements-from-point";
    private void ElementsFromPoint() {
        IHTMLElementInProcess[] htmlElements = Document.ElementsFromPoint(1, 1);
        labelOutput = htmlElements.Length.ToString();

        htmlElements.Dispose();
    }

    public const string BUTTON_REPLACE_CHILDREN = "document-inprocess-replace-children";
    private async Task ReplaceChildren() {
        using IHTMLElementInProcess rootElement = Document.DocumentElement;
        Document.ReplaceChildren([]);
        await Task.Delay(100);
        Document.ReplaceChildren([rootElement]);
        labelOutput = (rootElement is not null).ToString();
    }


    // methods - StorageAccess

    public const string BUTTON_REQUEST_STORAGE_ACCESS = "document-inprocess-request-storage-access";
    private async Task RequestStorageAccess() {
        await Document.RequestStorageAccess(all: true);
        labelOutput = TEST_REQUEST_STORAGE_ACCESS;
    }

    public const string BUTTON_REQUEST_STORAGE_ACCESS_FOR = "document-inprocess-request-storage-access-for";
    private async Task RequestStorageAccessFor() {
        await Document.RequestStorageAccessFor("https://localhost");
        labelOutput = TEST_REQUEST_STORAGE_ACCESS_FOR;
    }

    public const string BUTTON_HAS_STORAGE_ACCESS = "document-inprocess-has-storage-access";
    private async Task HasStorageAccess() {
        bool storageAccess = await Document.HasStorageAccess();
        labelOutput = storageAccess.ToString();
    }


    // methods - exit

    public const string BUTTON_EXIT_FULLSCREEN = "document-inprocess-exit-fullscreen";
    private async Task ExitFullscreen() {
        await Document.ExitFullscreen();
    }

    public const string BUTTON_EXIT_PICTURE_IN_PICTURE = "document-inprocess-exit-picture-in-picture";
    private async Task ExitPictureInPicture() {
        try {
            await Document.ExitPictureInPicture();
            labelOutput = "picture in picture exit";
        }
        catch (Microsoft.JSInterop.JSException exception) {
            labelOutput = exception.Message.Substring(0, exception.Message.IndexOf('\n'));
        }
    }

    public const string BUTTON_EXIT_POINTER_LOCK = "document-inprocess-exit-pointer-lock";
    private void ExitPointerLock() {
        Document.ExitPointerLock();
    }


    // methods

    public const string BUTTON_HAS_FOCUS = "document-inprocess-has-focus";
    private void HasFocus() {
        bool focus = Document.HasFocus();
        labelOutput = focus.ToString();
    }


    // methods - Node

    public const string BUTTON_COMPARE_DOCUMENT_POSITION = "document-inprocess-compare-document-position";
    private void CompareDocumentPosition() {
        int comparison = Document.CompareDocumentPosition(Document.Body);
        labelOutput = comparison.ToString();
    }

    public const string BUTTON_CONTAINS = "document-inprocess-contains";
    private void Contains() {
        bool contains = Document.Contains(Document.Body);
        labelOutput = contains.ToString();
    }

    public const string BUTTON_IS_DEFAULT_NAMESPACE = "document-inprocess-is-default-namespace";
    private void IsDefaultNamespace() {
        bool isDefaultNamespace = Document.IsDefaultNamespace("http://www.w3.org/1999/xhtml");
        labelOutput = isDefaultNamespace.ToString();
    }

    public const string BUTTON_LOOKUP_PREFIX = "document-inprocess-lookup-prefix";
    private void LookupPrefix() {
        string? prefix = Document.LookupPrefix("http://www.w3.org/1999/xhtml");
        labelOutput = prefix ?? "(no prefix)";
    }

    public const string BUTTON_LOOKUP_NAMESPACE_URI = "document-inprocess-lookup-namespace-uri";
    private void LookupNamespaceURI() {
        string? namespaceURI = Document.LookupNamespaceURI(null);
        labelOutput = namespaceURI ?? "(no namespace uri)";
    }

    public const string BUTTON_NORMALIZE = "document-inprocess-normalize";
    private void Normalize() {
        Document.Normalize();
    }
}
