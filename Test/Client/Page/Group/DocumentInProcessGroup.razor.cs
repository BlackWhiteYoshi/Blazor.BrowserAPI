using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class DocumentInProcessGroup : ComponentBase {
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
    public required IDocumentInProcess Document { private get; init; }


    public const string LABEL_OUTPUT = "document-inprocess-output";
    private string labelOutput = string.Empty;

    public const string TEMP_HTML_ELEMENT_ID = "document-inprocess-temp-htmlElement-id";


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



    // events - Document

    public const string BUTTON_REGISTER_ON_SECURITY_POLICY_VIOLATION = "document-inprocess-security-policy-violation-event";
    private void RegisterOnSecurityPolicyViolation() {
        Document.OnSecurityPolicyViolation += (SecurityPolicyViolationEvent securityPolicyViolationEvent) => {
            labelOutput = securityPolicyViolationEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_VISIBILITY_CHANGE = "document-inprocess-visibility-change-event";
    private void RegisterOnVisibilityChange() {
        Document.OnVisibilityChange += () => {
            labelOutput = TEST_EVENT_VISIBILITY_CHANGE;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_FULLSCREEN_CHANGE = "document-inprocess-fullscreen-change-event";
    private void RegisterOnFullscreenChange() {
        Document.OnFullscreenChange += () => {
            labelOutput = TEST_EVENT_FULLSCREEN_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_FULLSCREEN_ERROR = "document-inprocess-fullscreen-error-event";
    private void RegisterOnFullscreenError() {
        Document.OnFullscreenError += () => {
            labelOutput = TEST_EVENT_FULLSCREEN_ERROR;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_DOM_CONTENT_LOADED = "document-inprocess-dom-content-loaded-event";
    private void RegisterOnDOMContentLoaded() {
        Document.OnDOMContentLoaded += () => {
            labelOutput = TEST_EVENT_DOM_CONTENT_LOADED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_READY_STATE_CHANGE = "document-inprocess-ready-state-change-event";
    private void RegisterOnReadyStateChange() {
        Document.OnReadyStateChange += () => {
            labelOutput = TEST_EVENT_READY_STATE_CHANGE;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_POINTER_LOCK_CHANGE = "document-inprocess-pointer-lock-change-event";
    private void RegisterOnPointerLockChange() {
        Document.OnPointerLockChange += () => {
            labelOutput = TEST_EVENT_POINTER_LOCK_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_LOCK_ERROR = "document-inprocess-pointer-lock-error-event";
    private void RegisterOnPointerLockError() {
        Document.OnPointerLockError += () => {
            labelOutput = TEST_EVENT_POINTER_LOCK_ERROR;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_SCROLL = "document-inprocess-scroll-event";
    private void RegisterOnScroll() {
        Document.OnScroll += () => {
            labelOutput = TEST_EVENT_SCROLL;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SCROLL_END = "document-inprocess-scroll-end-event";
    private void RegisterOnScrollEnd() {
        Document.OnScrollEnd += () => {
            labelOutput = TEST_EVENT_SCROLL_END;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_SELECTION_CHANGE = "document-inprocess-selection-change-event";
    private void RegisterOnSelectionChange() {
        Document.OnSelectionChange += () => {
            labelOutput = TEST_EVENT_SELECTION_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SELECT_START = "document-inprocess-select-start-event";
    private void RegisterOnSelectStart() {
        Document.OnSelectStart += () => {
            labelOutput = TEST_EVENT_SELECT_START;
            StateHasChanged();
        };
    }


    // events - HTMLElement

    public const string BUTTON_REGISTER_ON_CHANGE = "document-inprocess-change-event";
    private void RegisterOnChange() {
        Document.OnChange += () => {
            labelOutput = TEST_EVENT_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOAD = "document-inprocess-load-event";
    private void RegisterOnLoad() {
        Document.OnLoad += () => {
            labelOutput = TEST_EVENT_LOAD;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ERROR = "document-inprocess-error-event";
    private void RegisterOnError() {
        Document.OnError += (JsonElement error) => {
            labelOutput = error.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_DRAG = "document-inprocess-drag-event";
    private void RegisterOnDrag() {
        Document.OnDrag += (DragEventInProcess dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                dragEvent.Files.Dispose();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_START = "document-inprocess-drag-start-event";
    private void RegisterOnDragStart() {
        Document.OnDragStart += (DragEventInProcess dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                dragEvent.Files.Dispose();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_END = "document-inprocess-drag-end-event";
    private void RegisterOnDragEnd() {
        Document.OnDragEnd += (DragEventInProcess dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                dragEvent.Files.Dispose();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_ENTER = "document-inprocess-drag-enter-event";
    private void RegisterOnDragEnter() {
        Document.OnDragEnter += (DragEventInProcess dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                dragEvent.Files.Dispose();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_LEAVE = "document-inprocess-drag-leave-event";
    private void RegisterOnDragLeave() {
        Document.OnDragLeave += (DragEventInProcess dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                dragEvent.Files.Dispose();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_OVER = "document-inprocess-drag-over-event";
    private void RegisterOnDragOver() {
        Document.OnDragOver += (DragEventInProcess dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                dragEvent.Files.Dispose();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DROP = "document-inprocess-drop-event";
    private void RegisterOnDrop() {
        Document.OnDrop += (DragEventInProcess dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                dragEvent.Files.Dispose();
            }
        };
    }


    public const string BUTTON_REGISTER_ON_TOGGLE = "document-inprocess-toggle-event";
    private void RegisterOnToggle() {
        Document.OnToggle += (string oldState, string newState) => {
            labelOutput = $"oldState='{oldState}', newState='{newState}'";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_TOGGLE = "document-inprocess-before-toggle-event";
    private void RegisterOnBeforeToggle() {
        Document.OnBeforeToggle += (string oldState, string newState) => {
            labelOutput = $"oldState='{oldState}', newState='{newState}'";
            StateHasChanged();
        };
    }


    // events - Element

    public const string BUTTON_REGISTER_ON_INPUT = "document-inprocess-input-event";
    private void RegisterOnInput() {
        Document.OnInput += (string? data, string? inputType, bool isComposing) => {
            labelOutput = $"data={data ?? "(null)"}, inputType={inputType ?? "(null)"}, isComposing={isComposing}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_INPUT = "document-inprocess-before-input-event";
    private void RegisterOnBeforeInput() {
        Document.OnBeforeInput += (string? data, string? inputType, bool isComposing) => {
            labelOutput = $"data={data ?? "(null)"}, inputType={inputType ?? "(null)"}, isComposing={isComposing}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_MATCH = "document-inprocess-before-match-event";
    private void RegisterOnBeforeMatch() {
        Document.OnBeforeMatch += () => {
            labelOutput = TEST_EVENT_BEFORE_MATCH;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_KEY_DOWN = "document-inprocess-key-down-event";
    private void RegisterOnKeyDown() {
        Document.OnKeyDown += (KeyboardEvent keyboardEvent) => {
            labelOutput = keyboardEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_KEY_UP = "document-inprocess-key-up-event";
    private void RegisterOnKeyUp() {
        Document.OnKeyUp += (KeyboardEvent keyboardEvent) => {
            labelOutput = keyboardEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_CLICK = "document-inprocess-click-event";
    private void RegisterOnClick() {
        Document.OnClick += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DBL_CLICK = "document-inprocess-dbl-click-event";
    private void RegisterOnDblClick() {
        Document.OnDblClick += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_AUX_CLICK = "document-inprocess-aux-click-event";
    private void RegisterOnAuxClick() {
        Document.OnAuxClick += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CONTEXT_MENU = "document-inprocess-context-menu-event";
    private void RegisterOnContextMenu() {
        Document.OnContextMenu += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_DOWN = "document-inprocess-mouse-down-event";
    private void RegisterOnMouseDown() {
        Document.OnMouseDown += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_UP = "document-inprocess-mouse-up-event";
    private void RegisterOnMouseUp() {
        Document.OnMouseUp += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_WHEEL = "document-inprocess-wheel-event";
    private void RegisterOnWheel() {
        Document.OnWheel += (WheelEvent wheelEvent) => {
            labelOutput = wheelEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_MOVE = "document-inprocess-mouse-move-event";
    private void RegisterOnMouseMove() {
        Document.OnMouseMove += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_OVER = "document-inprocess-mouse-over-event";
    private void RegisterOnMouseOver() {
        Document.OnMouseOver += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_OUT = "document-inprocess-mouse-out-event";
    private void RegisterOnMouseOut() {
        Document.OnMouseOut += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_ENTER = "document-inprocess-mouse-enter-event";
    private void RegisterOnMouseEnter() {
        Document.OnMouseEnter += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_LEAVE = "document-inprocess-mouse-leave-event";
    private void RegisterOnMouseLeave() {
        Document.OnMouseLeave += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_TOUCH_START = "document-inprocess-touch-start-event";
    private void RegisterOnTouchStart() {
        Document.OnTouchStart += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_END = "document-inprocess-touch-end-event";
    private void RegisterOnTouchEnd() {
        Document.OnTouchEnd += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_MOVE = "document-inprocess-touch-move-event";
    private void RegisterOnTouchMove() {
        Document.OnTouchMove += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_CANCEL = "document-inprocess-touch-cancel-event";
    private void RegisterOnTouchCancel() {
        Document.OnTouchCancel += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_POINTER_DOWN = "document-inprocess-pointer-down-event";
    private void RegisterOnPointerDown() {
        Document.OnPointerDown += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_UP = "document-inprocess-pointer-up-event";
    private void RegisterOnPointerUp() {
        Document.OnPointerUp += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_MOVE = "document-inprocess-pointer-move-event";
    private void RegisterOnPointerMove() {
        Document.OnPointerMove += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_OVER = "document-inprocess-pointer-over-event";
    private void RegisterOnPointerOver() {
        Document.OnPointerOver += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_OUT = "document-inprocess-pointer-out-event";
    private void RegisterOnPointerOut() {
        Document.OnPointerOut += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_ENTER = "document-inprocess-pointer-enter-event";
    private void RegisterOnPointerEnter() {
        Document.OnPointerEnter += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_LEAVE = "document-inprocess-pointer-leave-event";
    private void RegisterOnPointerLeave() {
        Document.OnPointerLeave += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_CANCEL = "document-inprocess-pointer-cancel-event";
    private void RegisterOnPointerCancel() {
        Document.OnPointerCancel += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_RAW_UPDATE = "document-inprocess-pointer-raw-update-event";
    private void RegisterOnPointerRawUpdate() {
        Document.OnPointerRawUpdate += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_GOT_POINTER_CAPTURE = "document-inprocess-got-pointer-capture-event";
    private void RegisterOnGotPointerCapture() {
        Document.OnGotPointerCapture += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOST_POINTER_CAPTURE = "document-inprocess-lost-pointer-capture-event";
    private void RegisterOnLostPointerCapture() {
        Document.OnLostPointerCapture += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_FOCUS = "document-inprocess-focus-event";
    private void RegisterOnFocus() {
        Document.OnFocus += () => {
            labelOutput = TEST_EVENT_FOCUS;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_FOCUS_IN = "document-inprocess-focus-in-event";
    private void RegisterOnFocusIn() {
        Document.OnFocusIn += () => {
            labelOutput = TEST_EVENT_FOCUS_IN;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BLUR = "document-inprocess-blur-event";
    private void RegisterOnBlur() {
        Document.OnBlur += () => {
            labelOutput = TEST_EVENT_BLUR;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_FOCUS_OUT = "document-inprocess-focus-out-event";
    private void RegisterOnFocusOut() {
        Document.OnFocusOut += () => {
            labelOutput = TEST_EVENT_FOCUS_OUT;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_COPY = "document-inprocess-copy-event";
    private void RegisterOnCopy() {
        Document.OnCopy += () => {
            labelOutput = TEST_EVENT_COPY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PASTE = "document-inprocess-paste-event";
    private void RegisterOnPaste() {
        Document.OnPaste += () => {
            labelOutput = TEST_EVENT_PASTE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CUT = "document-inprocess-cut-event";
    private void RegisterOnCut() {
        Document.OnCut += () => {
            labelOutput = TEST_EVENT_CUT;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_TRANSITION_START = "document-inprocess-transition-start-event";
    private void RegisterOnTransitionStart() {
        Document.OnTransitionStart += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_START}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_END = "document-inprocess-transition-end-event";
    private void RegisterOnTransitionEnd() {
        Document.OnTransitionEnd += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_END}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_RUN = "document-inprocess-transition-run-event";
    private void RegisterOnTransitionRun() {
        Document.OnTransitionRun += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_RUN}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_CANCEL = "document-inprocess-transition-cancel-event";
    private void RegisterOnTransitionCancel() {
        Document.OnTransitionCancel += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_CANCEL}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_ANIMATION_START = "document-inprocess-animation-start-event";
    private void RegisterOnAnimationStart() {
        Document.OnAnimationStart += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_START}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_END = "document-inprocess-animation-end-event";
    private void RegisterOnAnimationEnd() {
        Document.OnAnimationEnd += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_END}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_ITERATION = "document-inprocess-animation-iteration-event";
    private void RegisterOnAnimationIteration() {
        Document.OnAnimationIteration += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_ITERATION}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_CANCEL = "document-inprocess-animation-cancel-event";
    private void RegisterOnAnimationCancel() {
        Document.OnAnimationCancel += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_CANCEL}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }


    // events - HTMLMediaElement Ready

    public const string BUTTON_REGISTER_ON_CAN_PLAY = "document-inprocess-can-play-event";
    private void RegisterOnCanPlay() {
        Document.OnCanPlay += () => {
            labelOutput = TEST_EVENT_CAN_PLAY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CAN_PLAY_THROUGH = "document-inprocess-can-play-through-event";
    private void RegisterOnCanPlayThrough() {
        Document.OnCanPlayThrough += () => {
            labelOutput = TEST_EVENT_CAN_PLAY_THROUGH;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PLAYING = "document-inprocess-playing-event";
    private void RegisterOnPlaying() {
        Document.OnPlaying += () => {
            labelOutput = TEST_EVENT_PLAYING;
            StateHasChanged();
        };
    }

    // events - HTMLMediaElement Data

    public const string BUTTON_REGISTER_ON_LOAD_START = "document-inprocess-load-start-event";
    private void RegisterOnLoadStart() {
        Document.OnLoadStart += () => {
            labelOutput = TEST_EVENT_LOAD_START;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PROGRESS = "document-inprocess-progress-event";
    private void RegisterOnProgress() {
        Document.OnProgress += () => {
            labelOutput = TEST_EVENT_PROGRESS;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOADED_DATA = "document-inprocess-loaded-data-event";
    private void RegisterOnLoadedData() {
        Document.OnLoadedData += () => {
            labelOutput = TEST_EVENT_LOADED_DATA;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOADED_METADATA = "document-inprocess-loaded-metadata-event";
    private void RegisterOnLoadedMetadata() {
        Document.OnLoadedMetadata += () => {
            labelOutput = TEST_EVENT_LOADED_METADATA;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_STALLED = "document-inprocess-stalled-event";
    private void RegisterOnStalled() {
        Document.OnStalled += () => {
            labelOutput = TEST_EVENT_STALLED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SUSPEND = "document-inprocess-suspend-event";
    private void RegisterOnSuspend() {
        Document.OnSuspend += () => {
            labelOutput = TEST_EVENT_SUSPEND;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_WAITING = "document-inprocess-waiting-event";
    private void RegisterOnWaiting() {
        Document.OnWaiting += () => {
            labelOutput = TEST_EVENT_WAITING;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ABORT = "document-inprocess-abort-event";
    private void RegisterOnAbort() {
        Document.OnAbort += () => {
            labelOutput = TEST_EVENT_ABORT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_EMPTIED = "document-inprocess-emptied-event";
    private void RegisterOnEmptied() {
        Document.OnEmptied += () => {
            labelOutput = TEST_EVENT_EMPTIED;
            StateHasChanged();
        };
    }

    // events - HTMLMediaElement Timing

    public const string BUTTON_REGISTER_ON_PLAY = "document-inprocess-play-event";
    private void RegisterOnPlay() {
        Document.OnPlay += () => {
            labelOutput = TEST_EVENT_PLAY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PAUSE = "document-inprocess-pause-event";
    private void RegisterOnPause() {
        Document.OnPause += () => {
            labelOutput = TEST_EVENT_PAUSE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ENDED = "document-inprocess-ended-event";
    private void RegisterOnEnded() {
        Document.OnEnded += () => {
            labelOutput = TEST_EVENT_ENDED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SEEKING = "document-inprocess-seeking-event";
    private void RegisterOnSeeking() {
        Document.OnSeeking += () => {
            labelOutput = TEST_EVENT_SEEKING;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SEEKED = "document-inprocess-seeked-event";
    private void RegisterOnSeeked() {
        Document.OnSeeked += () => {
            labelOutput = TEST_EVENT_SEEKED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TIME_UPDATE = "document-inprocess-time-update-event";
    private void RegisterOnTimeUpdate() {
        Document.OnTimeUpdate += () => {
            labelOutput = TEST_EVENT_TIME_UPDATE;
            StateHasChanged();
        };
    }

    // events - HTMLMediaElement Setting

    public const string BUTTON_REGISTER_ON_VOLUME_CHANGE = "document-inprocess-volume-change-event";
    private void RegisterOnVolumeChange() {
        Document.OnVolumeChange += () => {
            labelOutput = TEST_EVENT_VOLUME_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_RATE_CHANGE = "document-inprocess-rate-change-event";
    private void RegisterOnRateChange() {
        Document.OnRateChange += () => {
            labelOutput = TEST_EVENT_RATE_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DURATION_CHANGE = "document-inprocess-duration-change-event";
    private void RegisterOnDurationChange() {
        Document.OnDurationChange += () => {
            labelOutput = TEST_EVENT_DURATION_CHANGE;
            StateHasChanged();
        };
    }

    // events - HTMLMediaElement Video

    public const string BUTTON_REGISTER_ON_RESIZE = "document-inprocess-resize-event";
    private void RegisterOnResize() {
        Document.OnResize += () => {
            labelOutput = TEST_EVENT_RESIZE;
            StateHasChanged();
        };
    }


    // events - HTMLDialogElement

    public const string BUTTON_REGISTER_ON_CLOSE = "document-inprocess-close-event";
    private void RegisterOnClose() {
        Document.OnClose += () => {
            labelOutput = TEST_EVENT_CLOSE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CANCEL = "document-inprocess-cancel-event";
    private void RegisterOnCancel() {
        Document.OnCancel += () => {
            labelOutput = TEST_EVENT_CANCEL;
            StateHasChanged();
        };
    }
}
