using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class DocumentGroup : ComponentBase {
    public const string TEST_SET_BODY = "body set";
    public const string TEST_NO_REFFERER = "(no referrer)";
    public const string TEST_SET_TITLE = "new document title";
    public const string TEST_ELEMENT_NAME = "some element name";
    public const string TEST_REQUEST_STORAGE_ACCESS = "got storage access";
    public const string TEST_REQUEST_STORAGE_ACCESS_FOR = "got storage access for localhost";
    // events - Document
    public const string TEST_EVENT_VISIBILITY_CHANGE = "visibility changed";
    public const string TEST_EVENT_FULLSCREEN_CHANGE = "fullscreen changed";
    public const string TEST_EVENT_FULLSCREEN_ERROR = "fullscreen error";
    public const string TEST_EVENT_DOM_CONTENT_LOADED = "DOM content loaded";
    public const string TEST_EVENT_READY_STATE_CHANGE = "ready state changed";
    public const string TEST_EVENT_POINTER_LOCK_CHANGE = "pointer lockd changed";
    public const string TEST_EVENT_POINTER_LOCK_ERROR = "pointer lockd error";
    public const string TEST_EVENT_SCROLL = "scrolled";
    public const string TEST_EVENT_SCROLL_END = "scroll ended";
    public const string TEST_EVENT_SELECTION_CHANGE = "selection changed";
    public const string TEST_EVENT_SELECT_START = "select started";
    // events - HTMLElement
    public const string TEST_EVENT_CHANGE = "change event";
    public const string TEST_EVENT_LOAD = "load event";
    // events - Element
    public const string TEST_EVENT_BEFORE_MATCH = "before-match-event-test";
    public const string TEST_EVENT_SCROLL_START = "scroll-start-event-test";
    public const string TEST_EVENT_FOCUS = "focus-event-test";
    public const string TEST_EVENT_FOCUS_IN = "focus-in-event-test";
    public const string TEST_EVENT_BLUR = "blur-event-test";
    public const string TEST_EVENT_FOCUS_OUT = "focus-out-event-test";
    public const string TEST_EVENT_COPY = "copy-event-test";
    public const string TEST_EVENT_PASTE = "paste-event-test";
    public const string TEST_EVENT_CUT = "cut-event-test";
    public const string TEST_EVENT_TRANSITION_START = "transition-start-event-test";
    public const string TEST_EVENT_TRANSITION_END = "transition-end-event-test";
    public const string TEST_EVENT_TRANSITION_RUN = "transition-run-event-test";
    public const string TEST_EVENT_TRANSITION_CANCEL = "transition-cancel-event-test";
    public const string TEST_EVENT_ANIMATION_START = "animation-start-event-test";
    public const string TEST_EVENT_ANIMATION_END = "animation-end-event-test";
    public const string TEST_EVENT_ANIMATION_ITERATION = "animation-iteration-event-test";
    public const string TEST_EVENT_ANIMATION_CANCEL = "animation-cancel-event-test";
    // events - HTMLMediaElement
    public const string TEST_EVENT_CAN_PLAY = "CanPlay event";
    public const string TEST_EVENT_CAN_PLAY_THROUGH = "CanPlayThrough event";
    public const string TEST_EVENT_PLAYING = "Playing event";
    public const string TEST_EVENT_LOAD_START = "LoadStart event";
    public const string TEST_EVENT_PROGRESS = "Progress event";
    public const string TEST_EVENT_LOADED_DATA = "LoadedData event";
    public const string TEST_EVENT_LOADED_METADATA = "LoadedMetadata event";
    public const string TEST_EVENT_STALLED = "stalled event";
    public const string TEST_EVENT_SUSPEND = "Suspend event";
    public const string TEST_EVENT_WAITING = "Waiting event";
    public const string TEST_EVENT_ABORT = "Abort event";
    public const string TEST_EVENT_EMPTIED = "Emptied event";
    public const string TEST_EVENT_PLAY = "Play event";
    public const string TEST_EVENT_PAUSE = "Pause event";
    public const string TEST_EVENT_ENDED = "Ended event";
    public const string TEST_EVENT_SEEKING = "Seeking event";
    public const string TEST_EVENT_SEEKED = "Seeked event";
    public const string TEST_EVENT_TIME_UPDATE = "TimeUpdate event";
    public const string TEST_EVENT_VOLUME_CHANGE = "VolumeChange event";
    public const string TEST_EVENT_RATE_CHANGE = "RateChange event";
    public const string TEST_EVENT_DURATION_CHANGE = "DurationChange event";
    public const string TEST_EVENT_RESIZE = "Resize event";
    // events - HTMLDialogElement
    public const string TEST_EVENT_CLOSE = "close-event-test";
    public const string TEST_EVENT_CANCEL = "cancel-event-test";


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



    // events - Document

    public const string BUTTON_REGISTER_ON_SECURITY_POLICY_VIOLATION = "document-security-policy-violation-event";
    private void RegisterOnSecurityPolicyViolation() {
        Document.OnSecurityPolicyViolation += (SecurityPolicyViolationEvent securityPolicyViolationEvent) => {
            labelOutput = securityPolicyViolationEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_VISIBILITY_CHANGE = "document-visibility-change-event";
    private void RegisterOnVisibilityChange() {
        Document.OnVisibilityChange += () => {
            labelOutput = TEST_EVENT_VISIBILITY_CHANGE;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_FULLSCREEN_CHANGE = "document-fullscreen-change-event";
    private void RegisterOnFullscreenChange() {
        Document.OnFullscreenChange += () => {
            labelOutput = TEST_EVENT_FULLSCREEN_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_FULLSCREEN_ERROR = "document-fullscreen-error-event";
    private void RegisterOnFullscreenError() {
        Document.OnFullscreenError += () => {
            labelOutput = TEST_EVENT_FULLSCREEN_ERROR;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_DOM_CONTENT_LOADED = "document-dom-content-loaded-event";
    private void RegisterOnDOMContentLoaded() {
        Document.OnDOMContentLoaded += () => {
            labelOutput = TEST_EVENT_DOM_CONTENT_LOADED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_READY_STATE_CHANGE = "document-ready-state-change-event";
    private void RegisterOnReadyStateChange() {
        Document.OnReadyStateChange += () => {
            labelOutput = TEST_EVENT_READY_STATE_CHANGE;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_POINTER_LOCK_CHANGE = "document-pointer-lock-change-event";
    private void RegisterOnPointerLockChange() {
        Document.OnPointerLockChange += () => {
            labelOutput = TEST_EVENT_POINTER_LOCK_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_LOCK_ERROR = "document-pointer-lock-error-event";
    private void RegisterOnPointerLockError() {
        Document.OnPointerLockError += () => {
            labelOutput = TEST_EVENT_POINTER_LOCK_ERROR;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_SCROLL = "document-scroll-event";
    private void RegisterOnScroll() {
        Document.OnScroll += () => {
            labelOutput = TEST_EVENT_SCROLL;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SCROLL_END = "document-scroll-end-event";
    private void RegisterOnScrollEnd() {
        Document.OnScrollEnd += () => {
            labelOutput = TEST_EVENT_SCROLL_END;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_SELECTION_CHANGE = "document-selection-change-event";
    private void RegisterOnSelectionChange() {
        Document.OnSelectionChange += () => {
            labelOutput = TEST_EVENT_SELECTION_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SELECT_START = "document-select-start-event";
    private void RegisterOnSelectStart() {
        Document.OnSelectStart += () => {
            labelOutput = TEST_EVENT_SELECT_START;
            StateHasChanged();
        };
    }


    // events - HTMLElement

    public const string BUTTON_REGISTER_ON_CHANGE = "document-change-event";
    private void RegisterOnChange() {
        Document.OnChange += () => {
            labelOutput = TEST_EVENT_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOAD = "document-load-event";
    private void RegisterOnLoad() {
        Document.OnLoad += () => {
            labelOutput = TEST_EVENT_LOAD;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ERROR = "document-error-event";
    private void RegisterOnError() {
        Document.OnError += (JsonElement error) => {
            labelOutput = error.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_DRAG = "document-drag-event";
    private void RegisterOnDrag() {
        Document.OnDrag += (DragEvent dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                await dragEvent.Files.DisposeAsync();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_START = "document-drag-start-event";
    private void RegisterOnDragStart() {
        Document.OnDragStart += (DragEvent dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                await dragEvent.Files.DisposeAsync();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_END = "document-drag-end-event";
    private void RegisterOnDragEnd() {
        Document.OnDragEnd += (DragEvent dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                await dragEvent.Files.DisposeAsync();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_ENTER = "document-drag-enter-event";
    private void RegisterOnDragEnter() {
        Document.OnDragEnter += (DragEvent dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                await dragEvent.Files.DisposeAsync();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_LEAVE = "document-drag-leave-event";
    private void RegisterOnDragLeave() {
        Document.OnDragLeave += (DragEvent dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                await dragEvent.Files.DisposeAsync();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_OVER = "document-drag-over-event";
    private void RegisterOnDragOver() {
        Document.OnDragOver += (DragEvent dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                await dragEvent.Files.DisposeAsync();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DROP = "document-drop-event";
    private void RegisterOnDrop() {
        Document.OnDrop += (DragEvent dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                await dragEvent.Files.DisposeAsync();
            }
        };
    }


    public const string BUTTON_REGISTER_ON_TOGGLE = "document-toggle-event";
    private void RegisterOnToggle() {
        Document.OnToggle += (string oldState, string newState) => {
            labelOutput = $"oldState='{oldState}', newState='{newState}'";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_TOGGLE = "document-before-toggle-event";
    private void RegisterOnBeforeToggle() {
        Document.OnBeforeToggle += (string oldState, string newState) => {
            labelOutput = $"oldState='{oldState}', newState='{newState}'";
            StateHasChanged();
        };
    }


    // events - Element

    public const string BUTTON_REGISTER_ON_INPUT = "document-input-event";
    private void RegisterOnInput() {
        Document.OnInput += (string? data, string? inputType, bool isComposing) => {
            labelOutput = $"data={data ?? "(null)"}, inputType={inputType ?? "(null)"}, isComposing={isComposing}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_INPUT = "document-before-input-event";
    private void RegisterOnBeforeInput() {
        Document.OnBeforeInput += (string? data, string? inputType, bool isComposing) => {
            labelOutput = $"data={data ?? "(null)"}, inputType={inputType ?? "(null)"}, isComposing={isComposing}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_MATCH = "document-before-match-event";
    private void RegisterOnBeforeMatch() {
        Document.OnBeforeMatch += () => {
            labelOutput = TEST_EVENT_BEFORE_MATCH;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_KEY_DOWN = "document-key-down-event";
    private void RegisterOnKeyDown() {
        Document.OnKeyDown += (KeyboardEvent keyboardEvent) => {
            labelOutput = keyboardEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_KEY_UP = "document-key-up-event";
    private void RegisterOnKeyUp() {
        Document.OnKeyUp += (KeyboardEvent keyboardEvent) => {
            labelOutput = keyboardEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_CLICK = "document-click-event";
    private void RegisterOnClick() {
        Document.OnClick += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DBL_CLICK = "document-dbl-click-event";
    private void RegisterOnDblClick() {
        Document.OnDblClick += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_AUX_CLICK = "document-aux-click-event";
    private void RegisterOnAuxClick() {
        Document.OnAuxClick += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CONTEXT_MENU = "document-context-menu-event";
    private void RegisterOnContextMenu() {
        Document.OnContextMenu += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_DOWN = "document-mouse-down-event";
    private void RegisterOnMouseDown() {
        Document.OnMouseDown += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_UP = "document-mouse-up-event";
    private void RegisterOnMouseUp() {
        Document.OnMouseUp += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_WHEEL = "document-wheel-event";
    private void RegisterOnWheel() {
        Document.OnWheel += (WheelEvent wheelEvent) => {
            labelOutput = wheelEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_MOVE = "document-mouse-move-event";
    private void RegisterOnMouseMove() {
        Document.OnMouseMove += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_OVER = "document-mouse-over-event";
    private void RegisterOnMouseOver() {
        Document.OnMouseOver += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_OUT = "document-mouse-out-event";
    private void RegisterOnMouseOut() {
        Document.OnMouseOut += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_ENTER = "document-mouse-enter-event";
    private void RegisterOnMouseEnter() {
        Document.OnMouseEnter += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_LEAVE = "document-mouse-leave-event";
    private void RegisterOnMouseLeave() {
        Document.OnMouseLeave += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_TOUCH_START = "document-touch-start-event";
    private void RegisterOnTouchStart() {
        Document.OnTouchStart += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_END = "document-touch-end-event";
    private void RegisterOnTouchEnd() {
        Document.OnTouchEnd += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_MOVE = "document-touch-move-event";
    private void RegisterOnTouchMove() {
        Document.OnTouchMove += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_CANCEL = "document-touch-cancel-event";
    private void RegisterOnTouchCancel() {
        Document.OnTouchCancel += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_POINTER_DOWN = "document-pointer-down-event";
    private void RegisterOnPointerDown() {
        Document.OnPointerDown += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_UP = "document-pointer-up-event";
    private void RegisterOnPointerUp() {
        Document.OnPointerUp += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_MOVE = "document-pointer-move-event";
    private void RegisterOnPointerMove() {
        Document.OnPointerMove += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_OVER = "document-pointer-over-event";
    private void RegisterOnPointerOver() {
        Document.OnPointerOver += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_OUT = "document-pointer-out-event";
    private void RegisterOnPointerOut() {
        Document.OnPointerOut += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_ENTER = "document-pointer-enter-event";
    private void RegisterOnPointerEnter() {
        Document.OnPointerEnter += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_LEAVE = "document-pointer-leave-event";
    private void RegisterOnPointerLeave() {
        Document.OnPointerLeave += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_CANCEL = "document-pointer-cancel-event";
    private void RegisterOnPointerCancel() {
        Document.OnPointerCancel += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_RAW_UPDATE = "document-pointer-raw-update-event";
    private void RegisterOnPointerRawUpdate() {
        Document.OnPointerRawUpdate += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_GOT_POINTER_CAPTURE = "document-got-pointer-capture-event";
    private void RegisterOnGotPointerCapture() {
        Document.OnGotPointerCapture += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOST_POINTER_CAPTURE = "document-lost-pointer-capture-event";
    private void RegisterOnLostPointerCapture() {
        Document.OnLostPointerCapture += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_FOCUS = "document-focus-event";
    private void RegisterOnFocus() {
        Document.OnFocus += () => {
            labelOutput = TEST_EVENT_FOCUS;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_FOCUS_IN = "document-focus-in-event";
    private void RegisterOnFocusIn() {
        Document.OnFocusIn += () => {
            labelOutput = TEST_EVENT_FOCUS_IN;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BLUR = "document-blur-event";
    private void RegisterOnBlur() {
        Document.OnBlur += () => {
            labelOutput = TEST_EVENT_BLUR;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_FOCUS_OUT = "document-focus-out-event";
    private void RegisterOnFocusOut() {
        Document.OnFocusOut += () => {
            labelOutput = TEST_EVENT_FOCUS_OUT;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_COPY = "document-copy-event";
    private void RegisterOnCopy() {
        Document.OnCopy += () => {
            labelOutput = TEST_EVENT_COPY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PASTE = "document-paste-event";
    private void RegisterOnPaste() {
        Document.OnPaste += () => {
            labelOutput = TEST_EVENT_PASTE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CUT = "document-cut-event";
    private void RegisterOnCut() {
        Document.OnCut += () => {
            labelOutput = TEST_EVENT_CUT;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_TRANSITION_START = "document-transition-start-event";
    private void RegisterOnTransitionStart() {
        Document.OnTransitionStart += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_START}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_END = "document-transition-end-event";
    private void RegisterOnTransitionEnd() {
        Document.OnTransitionEnd += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_END}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_RUN = "document-transition-run-event";
    private void RegisterOnTransitionRun() {
        Document.OnTransitionRun += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_RUN}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_CANCEL = "document-transition-cancel-event";
    private void RegisterOnTransitionCancel() {
        Document.OnTransitionCancel += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_CANCEL}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_ANIMATION_START = "document-animation-start-event";
    private void RegisterOnAnimationStart() {
        Document.OnAnimationStart += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_START}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_END = "document-animation-end-event";
    private void RegisterOnAnimationEnd() {
        Document.OnAnimationEnd += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_END}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_ITERATION = "document-animation-iteration-event";
    private void RegisterOnAnimationIteration() {
        Document.OnAnimationIteration += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_ITERATION}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_CANCEL = "document-animation-cancel-event";
    private void RegisterOnAnimationCancel() {
        Document.OnAnimationCancel += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_CANCEL}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }


    // events - HTMLMediaElement Ready

    public const string BUTTON_REGISTER_ON_CAN_PLAY = "document-can-play-event";
    private void RegisterOnCanPlay() {
        Document.OnCanPlay += () => {
            labelOutput = TEST_EVENT_CAN_PLAY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CAN_PLAY_THROUGH = "document-can-play-through-event";
    private void RegisterOnCanPlayThrough() {
        Document.OnCanPlayThrough += () => {
            labelOutput = TEST_EVENT_CAN_PLAY_THROUGH;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PLAYING = "document-playing-event";
    private void RegisterOnPlaying() {
        Document.OnPlaying += () => {
            labelOutput = TEST_EVENT_PLAYING;
            StateHasChanged();
        };
    }

    // events - HTMLMediaElement Data

    public const string BUTTON_REGISTER_ON_LOAD_START = "document-load-start-event";
    private void RegisterOnLoadStart() {
        Document.OnLoadStart += () => {
            labelOutput = TEST_EVENT_LOAD_START;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PROGRESS = "document-progress-event";
    private void RegisterOnProgress() {
        Document.OnProgress += () => {
            labelOutput = TEST_EVENT_PROGRESS;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOADED_DATA = "document-loaded-data-event";
    private void RegisterOnLoadedData() {
        Document.OnLoadedData += () => {
            labelOutput = TEST_EVENT_LOADED_DATA;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOADED_METADATA = "document-loaded-metadata-event";
    private void RegisterOnLoadedMetadata() {
        Document.OnLoadedMetadata += () => {
            labelOutput = TEST_EVENT_LOADED_METADATA;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_STALLED = "document-stalled-event";
    private void RegisterOnStalled() {
        Document.OnStalled += () => {
            labelOutput = TEST_EVENT_STALLED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SUSPEND = "document-suspend-event";
    private void RegisterOnSuspend() {
        Document.OnSuspend += () => {
            labelOutput = TEST_EVENT_SUSPEND;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_WAITING = "document-waiting-event";
    private void RegisterOnWaiting() {
        Document.OnWaiting += () => {
            labelOutput = TEST_EVENT_WAITING;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ABORT = "document-abort-event";
    private void RegisterOnAbort() {
        Document.OnAbort += () => {
            labelOutput = TEST_EVENT_ABORT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_EMPTIED = "document-emptied-event";
    private void RegisterOnEmptied() {
        Document.OnEmptied += () => {
            labelOutput = TEST_EVENT_EMPTIED;
            StateHasChanged();
        };
    }

    // events - HTMLMediaElement Timing

    public const string BUTTON_REGISTER_ON_PLAY = "document-play-event";
    private void RegisterOnPlay() {
        Document.OnPlay += () => {
            labelOutput = TEST_EVENT_PLAY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PAUSE = "document-pause-event";
    private void RegisterOnPause() {
        Document.OnPause += () => {
            labelOutput = TEST_EVENT_PAUSE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ENDED = "document-ended-event";
    private void RegisterOnEnded() {
        Document.OnEnded += () => {
            labelOutput = TEST_EVENT_ENDED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SEEKING = "document-seeking-event";
    private void RegisterOnSeeking() {
        Document.OnSeeking += () => {
            labelOutput = TEST_EVENT_SEEKING;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SEEKED = "document-seeked-event";
    private void RegisterOnSeeked() {
        Document.OnSeeked += () => {
            labelOutput = TEST_EVENT_SEEKED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TIME_UPDATE = "document-time-update-event";
    private void RegisterOnTimeUpdate() {
        Document.OnTimeUpdate += () => {
            labelOutput = TEST_EVENT_TIME_UPDATE;
            StateHasChanged();
        };
    }

    // events - HTMLMediaElement Setting

    public const string BUTTON_REGISTER_ON_VOLUME_CHANGE = "document-volume-change-event";
    private void RegisterOnVolumeChange() {
        Document.OnVolumeChange += () => {
            labelOutput = TEST_EVENT_VOLUME_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_RATE_CHANGE = "document-rate-change-event";
    private void RegisterOnRateChange() {
        Document.OnRateChange += () => {
            labelOutput = TEST_EVENT_RATE_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DURATION_CHANGE = "document-duration-change-event";
    private void RegisterOnDurationChange() {
        Document.OnDurationChange += () => {
            labelOutput = TEST_EVENT_DURATION_CHANGE;
            StateHasChanged();
        };
    }

    // events - HTMLMediaElement Video

    public const string BUTTON_REGISTER_ON_RESIZE = "document-resize-event";
    private void RegisterOnResize() {
        Document.OnResize += () => {
            labelOutput = TEST_EVENT_RESIZE;
            StateHasChanged();
        };
    }


    // events - HTMLDialogElement

    public const string BUTTON_REGISTER_ON_CLOSE = "document-close-event";
    private void RegisterOnClose() {
        Document.OnClose += () => {
            labelOutput = TEST_EVENT_CLOSE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CANCEL = "document-cancel-event";
    private void RegisterOnCancel() {
        Document.OnCancel += () => {
            labelOutput = TEST_EVENT_CANCEL;
            StateHasChanged();
        };
    }
}
