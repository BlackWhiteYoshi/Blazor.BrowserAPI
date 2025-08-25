using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class DocumentInProcessGroup : ComponentBase {
    public const string TEST_SET_BODY = "body set";
    public const string TEST_NO_REFFERER = "(no referrer)";
    public const string TEST_SET_TITLE = "new document title";


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



    // methods
}
