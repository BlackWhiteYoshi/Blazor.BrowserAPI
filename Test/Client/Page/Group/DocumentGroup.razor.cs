using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class DocumentGroup : ComponentBase {
    public const string TEST_SET_BODY = "body set";
    public const string TEST_NO_REFFERER = "(no referrer)";
    public const string TEST_SET_TITLE = "new document title";
    public const string TEST_ELEMENT_NAME = "some element name";
    public const string TEST_REQUEST_STORAGE_ACCESS = "got storage access";
    public const string TEST_REQUEST_STORAGE_ACCESS_FOR = "got storage access for localhost";


    [Inject]
    public required IDocument Document { private get; init; }


    public const string LABEL_OUTPUT = "document-output";
    private string labelOutput = string.Empty;


    // Properties - HTMLElement reference

    public const string BUTTON_GET_DOCUMENT_ELEMENT = "document-get-document-element";
    private async Task GetDocumentElement() {
        await using IHTMLElement documentElement = Document.DocumentElement;
        labelOutput = (documentElement is not null).ToString();
    }

    public const string BUTTON_GET_HEAD = "document-get-head";
    private async Task GetHead() {
        await using IHTMLElement head = Document.Head;
        labelOutput = (head is not null).ToString();
    }

    public const string BUTTON_GET_BODY = "document-get-body";
    private async Task GetBody() {
        await using IHTMLElement body = Document.Body;
        labelOutput = (body is not null).ToString();
    }

    public const string BUTTON_SET_BODY = "document-set-body";
    private async Task SetBody() {
        await Document.SetBody(Document.Body);
        labelOutput = TEST_SET_BODY;
    }

    public const string BUTTON_GET_SCROLLING_ELEMENT = "document-get-scrolling-element";
    private async Task GetScrollingElement() {
        await using IHTMLElement scrollingElement = Document.ScrollingElement;
        labelOutput = (scrollingElement is not null).ToString();
    }


    // Properties - HTMLElement Collection

    public const string BUTTON_GET_EMBEDS_PROPERTY = "document-get-embeds-property";
    private async Task GetEmbeds_Property() {
        IHTMLElement[] embedElements = await Document.Embeds;
        labelOutput = embedElements.Length.ToString();

        await embedElements.DisposeAsync();
    }

    public const string BUTTON_GET_EMBEDS_METHOD = "document-get-embeds-method";
    private async Task GetEmbeds_Method() {
        IHTMLElement[] embedElements = await Document.GetEmbeds(default);
        labelOutput = embedElements.Length.ToString();

        await embedElements.DisposeAsync();
    }


    public const string BUTTON_GET_FORMS_PROPERTY = "document-get-forms-property";
    private async Task GetForms_Property() {
        IHTMLElement[] formElements = await Document.Forms;
        labelOutput = formElements.Length.ToString();

        await formElements.DisposeAsync();
    }

    public const string BUTTON_GET_FORMS_METHOD = "document-get-forms-method";
    private async Task GetForms_Method() {
        IHTMLElement[] formElements = await Document.GetForms(default);
        labelOutput = formElements.Length.ToString();

        await formElements.DisposeAsync();
    }


    public const string BUTTON_GET_IMAGES_PROPERTY = "document-get-images-property";
    private async Task GetImages_Property() {
        IHTMLElement[] imageElements = await Document.Images;
        labelOutput = imageElements.Length.ToString();

        await imageElements.DisposeAsync();
    }

    public const string BUTTON_GET_IMAGES_METHOD = "document-get-images-method";
    private async Task GetImages_Method() {
        IHTMLElement[] imageElements = await Document.GetImages(default);
        labelOutput = imageElements.Length.ToString();

        await imageElements.DisposeAsync();
    }


    public const string BUTTON_GET_LINKS_PROPERTY = "document-get-links-property";
    private async Task GetLinks_Property() {
        IHTMLElement[] linkElements = await Document.Links;
        labelOutput = linkElements.Length.ToString();

        await linkElements.DisposeAsync();
    }

    public const string BUTTON_GET_LINKS_METHOD = "document-get-links-method";
    private async Task GetLinks_Method() {
        IHTMLElement[] linkElements = await Document.GetLinks(default);
        labelOutput = linkElements.Length.ToString();

        await linkElements.DisposeAsync();
    }


    public const string BUTTON_GET_PLUGINS_PROPERTY = "document-get-plugins-property";
    private async Task GetPlugins_Property() {
        IHTMLElement[] pluginElements = await Document.Plugins;
        labelOutput = pluginElements.Length.ToString();

        await pluginElements.DisposeAsync();
    }

    public const string BUTTON_GET_PLUGINS_METHOD = "document-get-plugins-method";
    private async Task GetPlugins_Method() {
        IHTMLElement[] pluginElements = await Document.GetPlugins(default);
        labelOutput = pluginElements.Length.ToString();

        await pluginElements.DisposeAsync();
    }


    public const string BUTTON_GET_SCRIPTS_PROPERTY = "document-get-scripts-property";
    private async Task GetScripts_Property() {
        IHTMLElement[] scriptElements = await Document.Scripts;
        labelOutput = scriptElements.Length.ToString();

        await scriptElements.DisposeAsync();
    }

    public const string BUTTON_GET_SCRIPTS_METHOD = "document-get-scripts-method";
    private async Task GetScripts_Method() {
        IHTMLElement[] scriptElements = await Document.GetScripts(default);
        labelOutput = scriptElements.Length.ToString();

        await scriptElements.DisposeAsync();
    }


    // Properties - HTMLElement situational

    public const string BUTTON_GET_ACTIVE_ELEMENT_PROPERTY = "document-get-active-element-property";
    private async Task GetActiveElement_Property() {
        await using IHTMLElement? activeElement = await Document.ActiveElement;
        labelOutput = (activeElement is not null).ToString();
    }

    public const string BUTTON_GET_ACTIVE_ELEMENT_METHOD = "document-get-active-element-method";
    private async Task GetActiveElement_Method() {
        await using IHTMLElement? activeElement = await Document.GetActiveElement(default);
        labelOutput = (activeElement is not null).ToString();
    }


    public const string BUTTON_GET_CURRENT_SCRIPT_PROPERTY = "document-get-current-script-property";
    private async Task GetCurrentScript_Property() {
        await using IHTMLElement? currentScript = await Document.CurrentScript;
        labelOutput = (currentScript is not null).ToString();
    }

    public const string BUTTON_GET_CURRENT_SCRIPT_METHOD = "document-get-current-script-method";
    private async Task GetCurrentScript_Method() {
        await using IHTMLElement? currentScript = await Document.GetCurrentScript(default);
        labelOutput = (currentScript is not null).ToString();
    }


    public const string BUTTON_GET_FULLSCREEN_ELEMENT_PROPERTY = "document-get-fullscreen-element-property";
    private async Task GetFullscreenElement_Property() {
        await using IHTMLElement? fullscreenElement = await Document.FullscreenElement;
        labelOutput = (fullscreenElement is not null).ToString();
    }

    public const string BUTTON_GET_FULLSCREEN_ELEMENT_METHOD = "document-get-fullscreen-element-method";
    private async Task GetFullscreenElement_Method() {
        await using IHTMLElement? fullscreenElement = await Document.GetFullscreenElement(default);
        labelOutput = (fullscreenElement is not null).ToString();
    }


    public const string BUTTON_GET_PICTURE_IN_PICTURE_ELEMENT_PROPERTY = "document-get-picture-in-picture-element-property";
    private async Task GetPictureInPictureElement_Property() {
        await using IHTMLElement? pictureInPicture = await Document.PictureInPictureElement;
        labelOutput = (pictureInPicture is not null).ToString();
    }

    public const string BUTTON_GET_PICTURE_IN_PICTURE_ELEMENT_METHOD = "document-get-picture-in-picture-element-method";
    private async Task GetPictureInPictureElement_Method() {
        await using IHTMLElement? pictureInPicture = await Document.GetPictureInPictureElement(default);
        labelOutput = (pictureInPicture is not null).ToString();
    }


    public const string BUTTON_GET_POINTER_LOCK_ELEMENT_PROPERTY = "document-get-pointer-lock-element-property";
    private async Task GetPointerLockElement_Property() {
        await using IHTMLElement? pointerLockElement = await Document.PointerLockElement;
        labelOutput = (pointerLockElement is not null).ToString();
    }

    public const string BUTTON_GET_POINTER_LOCK_ELEMENT_METHOD = "document-get-pointer-lock-element-method";
    private async Task GetPointerLockElement_Method() {
        await using IHTMLElement? pointerLockElement = await Document.GetPointerLockElement(default);
        labelOutput = (pointerLockElement is not null).ToString();
    }


    // Properties

    public const string BUTTON_GET_CHARACTER_SET_PROPERTY = "document-get-character-set-property";
    private async Task GetCharacterSet_Property() {
        string characterSet = await Document.CharacterSet;
        labelOutput = characterSet;
    }

    public const string BUTTON_GET_CHARACTER_SET_METHOD = "document-get-character-set-method";
    private async Task GetCharacterSet_Method() {
        string characterSet = await Document.GetCharacterSet(default);
        labelOutput = characterSet;
    }


    public const string BUTTON_GET_COMPAT_MODE_PROPERTY = "document-get-compat-mode-property";
    private async Task GetCompatMode_Property() {
        string compatMode = await Document.CompatMode;
        labelOutput = compatMode;
    }

    public const string BUTTON_GET_COMPAT_MODE_METHOD = "document-get-compat-mode-method";
    private async Task GetCompatMode_Method() {
        string compatMode = await Document.GetCompatMode(default);
        labelOutput = compatMode;
    }


    public const string BUTTON_GET_CONTENT_TYPE_PROPERTY = "document-get-content-type-property";
    private async Task GetContentType_Property() {
        string contentType = await Document.ContentType;
        labelOutput = contentType;
    }

    public const string BUTTON_GET_CONTENT_TYPE_METHOD = "document-get-content-type-method";
    private async Task GetContentType_Method() {
        string contentType = await Document.GetContentType(default);
        labelOutput = contentType;
    }


    public const string BUTTON_GET_DESIGN_MODE_PROPERTY = "document-get-design-mode-property";
    private async Task GetDesignMode_Property() {
        string designMode = await Document.DesignMode;
        labelOutput = designMode;
    }

    public const string BUTTON_GET_DESIGN_MODE_METHOD = "document-get-design-mode-method";
    private async Task GetDesignMode_Method() {
        string designMode = await Document.GetDesignMode(default);
        labelOutput = designMode;
    }

    public const string BUTTON_SET_DESIGN_MODE = "document-set-design-mode";
    private async Task SetDesignMode() {
        await Document.SetDesignMode("on");
    }


    public const string BUTTON_GET_DIR_PROPERTY = "document-get-dir-property";
    private async Task GetDir_Property() {
        string dir = await Document.Dir;
        labelOutput = dir;
    }

    public const string BUTTON_GET_DIR_METHOD = "document-get-dir-method";
    private async Task GetDir_Method() {
        string dir = await Document.GetDir(default);
        labelOutput = dir;
    }

    public const string BUTTON_SET_DIR = "document-set-dir";
    private async Task SetDir() {
        await Document.SetDir("rtl");
    }


    public const string BUTTON_GET_DOCUMENT_URI_PROPERTY = "document-get-document-uri-property";
    private async Task GetDocumentURI_Property() {
        string documentURI = await Document.DocumentURI;
        labelOutput = documentURI;
    }

    public const string BUTTON_GET_DOCUMENT_URI_METHOD = "document-get-document-uri-method";
    private async Task GetDocumentURI_Method() {
        string documentURI = await Document.GetDocumentURI(default);
        labelOutput = documentURI;
    }


    public const string BUTTON_GET_FULLSCREEN_ENABLED_PROPERTY = "document-get-fullscreen-enabled-property";
    private async Task GetFullscreenEnabled_Property() {
        bool fullscreenEnabled = await Document.FullscreenEnabled;
        labelOutput = fullscreenEnabled.ToString();
    }

    public const string BUTTON_GET_FULLSCREEN_ENABLED_METHOD = "document-get-fullscreen-enabled-method";
    private async Task GetFullscreenEnabled_Method() {
        bool fullscreenEnabled = await Document.GetFullscreenEnabled(default);
        labelOutput = fullscreenEnabled.ToString();
    }


    public const string BUTTON_GET_HIDDEN_PROPERTY = "document-get-hidden-property";
    private async Task GetHidden_Property() {
        bool hidden = await Document.Hidden;
        labelOutput = hidden.ToString();
    }

    public const string BUTTON_GET_HIDDEN_METHOD = "document-get-hidden-method";
    private async Task GetHidden_Method() {
        bool hidden = await Document.GetHidden(default);
        labelOutput = hidden.ToString();
    }


    public const string BUTTON_GET_LAST_MODIFIED_PROPERTY = "document-get-last-modified-property";
    private async Task GetLastModified_Property() {
        string lastModified = await Document.LastModified;
        labelOutput = lastModified;
    }

    public const string BUTTON_GET_LAST_MODIFIED_METHOD = "document-get-last-modified-method";
    private async Task GetLastModified_Method() {
        string lastModified = await Document.GetLastModified(default);
        labelOutput = lastModified;
    }


    public const string BUTTON_GET_PICTURE_IN_PICTURE_ENABLED_PROPERTY = "document-get-picture-in-picture-enabled-property";
    private async Task GetPictureInPictureEnabled_Property() {
        bool pictureInPictureEnabled = await Document.PictureInPictureEnabled;
        labelOutput = pictureInPictureEnabled.ToString();
    }

    public const string BUTTON_GET_PICTURE_IN_PICTURE_ENABLED_METHOD = "document-get-picture-in-picture-enabled-method";
    private async Task GetPictureInPictureEnabled_Method() {
        bool pictureInPictureEnabled = await Document.GetPictureInPictureEnabled(default);
        labelOutput = pictureInPictureEnabled.ToString();
    }


    public const string BUTTON_GET_READY_STATE_PROPERTY = "document-get-ready-state-property";
    private async Task GetReadyState_Property() {
        string readyState = await Document.ReadyState;
        labelOutput = readyState;
    }

    public const string BUTTON_GET_READY_STATE_METHOD = "document-get-ready-state-method";
    private async Task GetReadyState_Method() {
        string readyState = await Document.GetReadyState(default);
        labelOutput = readyState;
    }


    public const string BUTTON_GET_REFERRER_PROPERTY = "document-get-referrer-property";
    private async Task GetReferrer_Property() {
        string referrer = await Document.Referrer;
        labelOutput = referrer is not "" ? referrer : TEST_NO_REFFERER;
    }

    public const string BUTTON_GET_REFERRER_METHOD = "document-get-referrer-method";
    private async Task GetReferrer_Method() {
        string referrer = await Document.GetReferrer(default);
        labelOutput = referrer is not "" ? referrer : TEST_NO_REFFERER;
    }


    public const string BUTTON_GET_TITLE_PROPERTY = "document-get-title-property";
    private async Task GetTitle_Property() {
        string title = await Document.Title;
        labelOutput = title;
    }

    public const string BUTTON_GET_TITLE_METHOD = "document-get-title-method";
    private async Task GetTitle_Method() {
        string title = await Document.GetTitle(default);
        labelOutput = title;
    }

    public const string BUTTON_SET_TITLE = "document-set-title";
    private async Task SetTitle() {
        await Document.SetTitle(TEST_SET_TITLE);
    }


    public const string BUTTON_GET_URL_PROPERTY = "document-get-url-property";
    private async Task GetURL_Property() {
        string url = await Document.URL;
        labelOutput = url;
    }

    public const string BUTTON_GET_URL_METHOD = "document-get-url-method";
    private async Task GetURL_Method() {
        string url = await Document.GetURL(default);
        labelOutput = url;
    }


    public const string BUTTON_GET_VISIBILITY_STATE_PROPERTY = "document-get-visibility-state-property";
    private async Task GetVisibilityState_Property() {
        string visibilityState = await Document.VisibilityState;
        labelOutput = visibilityState;
    }

    public const string BUTTON_GET_VISIBILITY_STATE_METHOD = "document-get-visibility-state-method";
    private async Task GetVisibilityState_Method() {
        string visibilityState = await Document.GetVisibilityState(default);
        labelOutput = visibilityState;
    }


    // Properties - Node

    public const string BUTTON_GET_BASE_URI_PROPERTY = "document-get-base-uri-property";
    private async Task GetBaseURI_Property() {
        string baseURI = await Document.BaseURI;
        labelOutput = baseURI;
    }

    public const string BUTTON_GET_BASE_URI_METHOD = "document-get-base-uri-method";
    private async Task GetBaseURI_Method() {
        string baseURI = await Document.GetBaseURI(default);
        labelOutput = baseURI;
    }


    public const string BUTTON_GET_NODE_NAME = "document-get-node-name";
    private void GetNodeName() {
        string nodeName = Document.NodeName;
        labelOutput = nodeName;
    }


    public const string BUTTON_GET_NODE_TYPE = "document-get-node-type";
    private void GetNodeType() {
        int nodeType = Document.NodeType;
        labelOutput = nodeType.ToString();
    }



    // methods - DOM

    public const string BUTTON_CREATE_ELEMENT = "document-create-element";
    private async Task CreateElement() {
        await using IHTMLElement htmlElement = Document.CreateElement("label");
        labelOutput = (htmlElement is not null).ToString();
    }

    public const string BUTTON_CREATE_ELEMENT_NS = "document-create-element-ns";
    private async Task CreateElementNS() {
        await using IHTMLElement htmlElement = Document.CreateElementNS("http://www.w3.org/1999/xhtml", "label");
        labelOutput = (htmlElement is not null).ToString();
    }

    public const string BUTTON_GET_ELEMENT_BY_ID = "document-get-element-by-id";
    private async Task GetElementById() {
        await using IHTMLElement? htmlElement = await Document.GetElementById("test-page");
        labelOutput = (htmlElement is not null).ToString();
    }

    public const string BUTTON_GET_ELEMENTS_BY_CLASS_NAME = "document-get-elements-by-class-name";
    private async Task GetElementsByClassName() {
        IHTMLElement[] htmlElements = await Document.GetElementsByClassName("group");
        labelOutput = htmlElements.Length.ToString();

        await htmlElements.DisposeAsync();
    }

    public const string BUTTON_GET_ELEMENTS_BY_TAG_NAME = "document-get-elements-by-tag-name";
    private async Task GetElementsByTagName() {
        IHTMLElement[] htmlElements = await Document.GetElementsByTagName("label");
        labelOutput = htmlElements.Length.ToString();

        await htmlElements.DisposeAsync();
    }

    public const string BUTTON_GET_ELEMENTS_BY_TAG_NAME_NS = "document-get-elements-by-tag-name-ns";
    private async Task GetElementsByTagNameNS() {
        IHTMLElement[] htmlElements = await Document.GetElementsByTagNameNS("http://www.w3.org/1999/xhtml", "label");
        labelOutput = htmlElements.Length.ToString();

        await htmlElements.DisposeAsync();
    }

    public const string BUTTON_GET_ELEMENTS_BY_NAME = "document-get-elements-by-name";
    private async Task GetElementsByName() {
        IHTMLElement[] htmlElements = await Document.GetElementsByName(TEST_ELEMENT_NAME);
        labelOutput = htmlElements.Length.ToString();

        await htmlElements.DisposeAsync();
    }

    public const string BUTTON_QUERY_SELECTOR = "document-query-selector";
    private async Task QuerySelector() {
        await using IHTMLElement? htmlElement = await Document.QuerySelector(".group");
        labelOutput = (htmlElement is not null).ToString();
    }

    public const string BUTTON_QUERY_SELECTOR_ALL = "document-query-selector-all";
    private async Task QuerySelectorAll() {
        IHTMLElement[] htmlElements = await Document.QuerySelectorAll(".group");
        labelOutput = htmlElements.Length.ToString();

        await htmlElements.DisposeAsync();
    }

    public const string BUTTON_ELEMENT_FROM_POINT = "document-element-from-point";
    private async Task ElementFromPoint() {
        await using IHTMLElement? htmlElement = await Document.ElementFromPoint(1, 1);
        labelOutput = (htmlElement is not null).ToString();
    }

    public const string BUTTON_ELEMENTS_FROM_POINT = "document-elements-from-point";
    private async Task ElementsFromPoint() {
        IHTMLElement[] htmlElements = await Document.ElementsFromPoint(1, 1);
        labelOutput = htmlElements.Length.ToString();

        await htmlElements.DisposeAsync();
    }

    public const string BUTTON_REPLACE_CHILDREN = "document-replace-children";
    private async Task ReplaceChildren() {
        await using IHTMLElement rootElement = Document.DocumentElement;
        await Document.ReplaceChildren([]);
        await Task.Delay(100);
        await Document.ReplaceChildren([rootElement]);
        labelOutput = (rootElement is not null).ToString();
    }


    // methods - StorageAccess

    public const string BUTTON_REQUEST_STORAGE_ACCESS = "document-request-storage-access";
    private async Task RequestStorageAccess() {
        await Document.RequestStorageAccess(all: true);
        labelOutput = TEST_REQUEST_STORAGE_ACCESS;
    }

    public const string BUTTON_REQUEST_STORAGE_ACCESS_FOR = "document-request-storage-access-for";
    private async Task RequestStorageAccessFor() {
        await Document.RequestStorageAccessFor("https://localhost");
        labelOutput = TEST_REQUEST_STORAGE_ACCESS_FOR;
    }

    public const string BUTTON_HAS_STORAGE_ACCESS = "document-has-storage-access";
    private async Task HasStorageAccess() {
        bool storageAccess = await Document.HasStorageAccess();
        labelOutput = storageAccess.ToString();
    }


    // methods - exit

    public const string BUTTON_EXIT_FULLSCREEN = "document-exit-fullscreen";
    private async Task ExitFullscreen() {
        await Document.ExitFullscreen();
    }

    public const string BUTTON_EXIT_PICTURE_IN_PICTURE = "document-exit-picture-in-picture";
    private async Task ExitPictureInPicture() {
        try {
            await Document.ExitPictureInPicture();
            labelOutput = "picture in picture exit";
        }
        catch (Microsoft.JSInterop.JSException exception) {
            labelOutput = exception.Message.Substring(0, exception.Message.IndexOf('\n'));
        }
    }

    public const string BUTTON_EXIT_POINTER_LOCK = "document-exit-pointer-lock";
    private async Task ExitPointerLock() {
        await Document.ExitPointerLock();
    }


    // methods

    public const string BUTTON_HAS_FOCUS = "document-has-focus";
    private async Task HasFocus() {
        bool focus = await Document.HasFocus();
        labelOutput = focus.ToString();
    }


    // methods - Node

    public const string BUTTON_COMPARE_DOCUMENT_POSITION = "document-compare-document-position";
    private async Task CompareDocumentPosition() {
        int comparison = await Document.CompareDocumentPosition(Document.Body);
        labelOutput = comparison.ToString();
    }

    public const string BUTTON_CONTAINS = "document-contains";
    private async Task Contains() {
        bool contains = await Document.Contains(Document.Body);
        labelOutput = contains.ToString();
    }

    public const string BUTTON_IS_DEFAULT_NAMESPACE = "document-is-default-namespace";
    private async Task IsDefaultNamespace() {
        bool isDefaultNamespace = await Document.IsDefaultNamespace("http://www.w3.org/1999/xhtml");
        labelOutput = isDefaultNamespace.ToString();
    }

    public const string BUTTON_LOOKUP_PREFIX = "document-lookup-prefix";
    private async Task LookupPrefix() {
        string? prefix = await Document.LookupPrefix("http://www.w3.org/1999/xhtml");
        labelOutput = prefix ?? "(no prefix)";
    }

    public const string BUTTON_LOOKUP_NAMESPACE_URI = "document-lookup-namespace-uri";
    private async Task LookupNamespaceURI() {
        string? namespaceURI = await Document.LookupNamespaceURI(null);
        labelOutput = namespaceURI ?? "(no namespace uri)";
    }

    public const string BUTTON_NORMALIZE = "document-normalize";
    private async Task Normalize() {
        await Document.Normalize();
    }
}
