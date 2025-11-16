using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class HTMLElementInProcessGroup : ComponentBase, IDisposable {
    // HTMLElement
    public const string TEST_ACCESS_KEY = "access-key-test";
    public const string TEST_STYLE_NAME = "visibility";
    public const string TEST_STYLE_VALUE = "visible";
    public const string TEST_DATASET_NAME = "custominfo";
    public const string TEST_DATASET_VALUE = "123";
    public const string TEST_AUTOCAPITALIZE = "sentences";
    public const string TEST_DIR = "ltr";
    public const string TEST_ENTER_KEY_HINT = "enter";
    public const string TEST_INNERTEXT = "<innertext>-test";
    public const string TEST_INPUT_MODE = "email";
    public const string TEST_LANG = "en";
    public const string TEST_NONCE = "nonce-test";
    public const string TEST_OUTERTEXT = "<outertext>-test";
    public const string TEST_POPOVER = "hint";
    public const string TEST_STYLE = "z-index: 5;";
    public const long TEST_TAB_INDEX = 100L;
    public const string TEST_TITLE = "title-test";
    // HTMLElement - events
    public const string TEST_EVENT_CHANGE = "change event";
    public const string TEST_EVENT_LOAD = "load event";

    // Element
    public const string TEST_CLASSNAME = "classname-test";
    public const string TEST_ID = "some-unique-id";
    public const string TEST_INNERHTML = "<span>innerhtml</span>-test";
    public const string TEST_OUTERHTML = "<span>outerhtml</span>-test";
    public const int TEST_SCROLLLEFT = 15;
    public const int TEST_SCROLLTOP = 17;
    public const int TEST_SCROLL_LEFT = 5;
    public const int TEST_SCROLL_TOP = 7;
    public const int TEST_SCROLL_BY_X = 9;
    public const int TEST_SCROLL_BY_Y = 11;
    public const string TEST_SLOT = "ChildContent";
    public const string TEST_TEXT_CONTENT = "text content test";
    // Element - ARIA
    public const string TEST_ARIA_ATOMIC = "true";
    public const string TEST_ARIA_AUTO_COMPLETE = "list";
    public const string TEST_ARIA_BRAILLE_LABEL = "braille label";
    public const string TEST_ARIA_BRAILLE_ROLE_DESCRIPTION = "braille role description";
    public const string TEST_ARIA_BUSY = "true";
    public const string TEST_ARIA_CHECKED = "true";
    public const string TEST_ARIA_COL_COUNT = "1";
    public const string TEST_ARIA_COL_INDEX = "0";
    public const string TEST_ARIA_COL_INDEX_TEXT = "first";
    public const string TEST_ARIA_COL_SPAN = "1";
    public const string TEST_ARIA_CURRENT = "true";
    public const string TEST_ARIA_DESCRIPTION = "description";
    public const string TEST_ARIA_DISABLED = "true";
    public const string TEST_ARIA_EXPANDED = "true";
    public const string TEST_ARIA_HAS_POPUP = "false";
    public const string TEST_ARIA_HIDDEN = "false";
    public const string TEST_ARIA_INVALID = "spelling";
    public const string TEST_ARIA_KEY_SHORTCUTS = "k";
    public const string TEST_ARIA_LABEL = "some label";
    public const string TEST_ARIA_LEVEL = "1";
    public const string TEST_ARIA_LIVE = "polite";
    public const string TEST_ARIA_MODAL = "true";
    public const string TEST_ARIA_MULTILINE = "true";
    public const string TEST_ARIA_MULTI_SELECTABLE = "true";
    public const string TEST_ARIA_ORIENTATION = "horizontal";
    public const string TEST_ARIA_PLACEHOLDER = "small hint description";
    public const string TEST_ARIA_POS_IN_SET = "1";
    public const string TEST_ARIA_PRESSED = "false";
    public const string TEST_ARIA_READ_ONLY = "true";
    public const string TEST_ARIA_REQUIRED = "false";
    public const string TEST_ARIA_ROLE_DESCRIPTION = "role description";
    public const string TEST_ARIA_ROW_COUNT = "1";
    public const string TEST_ARIA_ROW_INDEX = "0";
    public const string TEST_ARIA_ROW_INDEX_TEXT = "first";
    public const string TEST_ARIA_ROW_SPAN = "1";
    public const string TEST_ARIA_SELECTED = "false";
    public const string TEST_ARIA_SET_SIZE = "1";
    public const string TEST_ARIA_SORT = "none";
    public const string TEST_ARIA_VALUE_MAX = "9";
    public const string TEST_ARIA_VALUE_MIN = "1";
    public const string TEST_ARIA_VALUE_NOW = "1";
    public const string TEST_ARIA_VALUE_TEXT = "one";
    public const string TEST_ROLE = "my role";
    // Element - Methods
    public const string TEST_CUSTOM_NAME = "custom-name";
    public const string TEST_CUSTOM_VALUE = "my-value";
    public const string TEST_INSERT_HTML = $"<label>{TEST_CUSTOM_VALUE}</label>";
    // Element - Events
    public const string TEST_EVENT_BEFORE_MATCH = "before-match-event-test";
    public const string TEST_EVENT_SELECT_START = "select-start-event-test";
    public const string TEST_EVENT_SCROLL_START = "scroll-start-event-test";
    public const string TEST_EVENT_SCROLL_END = "scroll-end-event-test";
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
    public const string TEST_EVENT_FULLSCREEN_CHANGE = "fullscreen-change-event-test";
    public const string TEST_EVENT_FULLSCREEN_ERROR = "fullscreen-error-event-test";


    [Inject]
    public required IElementFactoryInProcess ElementFactory { private get; init; }


    private IHTMLElementInProcess? _htmlElement;
    private IHTMLElementInProcess HTMLElement => _htmlElement ??= ElementFactory.CreateHTMLElement(htmlElement);


    private IHTMLElementInProcess? _popoverElement;
    private IHTMLElementInProcess PopoverElement => _popoverElement ??= ElementFactory.CreateHTMLElement(popoverElement);

    private IHTMLElementInProcess? _hiddenElement;
    private IHTMLElementInProcess HiddenElement => _hiddenElement ??= ElementFactory.CreateHTMLElement(hiddenElement);


    public const string LABEL_OUTPUT = "htmlelement-inprocess-output";
    private string labelOutput = string.Empty;

    public const string HTML_ELEMENT_CONTAINER = "htmlelement-inprocess-html-element-container";
    public const string HTML_ELEMENT = "htmlelement-inprocess-html-element";
    private ElementReference htmlElement;

    public const string POPOVER_ELEMENT = "htmlelement-inprocess-popover-element";
    private ElementReference popoverElement;

    public const string HIDDEN_ELEMENT = "htmlelement-inprocess-hidden-element";
    private ElementReference hiddenElement;

    public void Dispose() {
        _htmlElement?.Dispose();
        _popoverElement?.Dispose();
        _hiddenElement?.Dispose();
    }


    public const string BUTTON_TO_HTML_DIALOG_ELEMENT = "htmlelement-inprocess-to-html-dialog-element";
    private void ToHTMLDialogElement() {
        using IHTMLDialogElementInProcess dialog = HTMLElement.ToHTMLDialogElement();
        labelOutput = (dialog is not null).ToString();
    }

    public const string BUTTON_TO_HTML_MEDIA_ELEMENT = "htmlelement-inprocess-to-html-media-element";
    private void ToHTMLMediaElement() {
        using IHTMLMediaElementInProcess mediaElement = HTMLElement.ToHTMLMediaElement();
        labelOutput = (mediaElement is not null).ToString();
    }


    #region HTMLElement

    public const string BUTTON_GET_ACCESS_KEY = "htmlelement-inprocess-get-access-key";
    private void GetAccessKey() {
        string accessKey = HTMLElement.AccessKey;
        labelOutput = accessKey;
    }

    public const string BUTTON_SET_ACCESS_KEY = "htmlelement-inprocess-set-access-key";
    private void SetAccessKey() {
        HTMLElement.AccessKey = TEST_ACCESS_KEY;
    }


    public const string BUTTON_GET_ACCESS_KEY_LABEL = "htmlelement-inprocess-get-access-key-label";
    private void GetAccessKeyLabel() {
        string accessKeyLabel = HTMLElement.AccessKeyLabel;
        labelOutput = accessKeyLabel;
    }


    public const string BUTTON_GET_ATTRIBUTE_STYLE_MAP = "htmlelement-inprocess-get-attribute-style-map";
    private void GetAttributeStyleMap() {
        Dictionary<string, string> attributeStyleMap = HTMLElement.AttributeStyleMap;
        labelOutput = string.Join(", ", attributeStyleMap.Select(pair => $"{pair.Key} = {pair.Value}"));
    }

    public const string BUTTON_SET_ATTRIBUTE_STYLE_MAP = "htmlelement-inprocess-set-attribute-style-map";
    private void SetAttributeStyleMap() {
        HTMLElement.SetAttributeStyleMap(TEST_STYLE_NAME, TEST_STYLE_VALUE);
    }

    public const string BUTTON_REMOVE_ATTRIBUTE_STYLE_MAP = "htmlelement-inprocess-remove-attribute-style-map";
    private void RemoveAttributeStyleMap() {
        HTMLElement.RemoveAttributeStyleMap(TEST_STYLE_NAME);
    }


    public const string BUTTON_GET_AUTOCAPITALIZE = "htmlelement-inprocess-get-autocapitalize";
    private void GetAutocapitalize() {
        string autocapitalize = HTMLElement.Autocapitalize;
        labelOutput = autocapitalize;
    }

    public const string BUTTON_SET_AUTOCAPITALIZE = "htmlelement-inprocess-set-autocapitalize";
    private void SetAutocapitalize() {
        HTMLElement.Autocapitalize = TEST_AUTOCAPITALIZE;
    }


    public const string BUTTON_GET_AUTOFOCUS = "htmlelement-inprocess-get-autofocus";
    private void GetAutofocus() {
        bool autofocus = HTMLElement.Autofocus;
        labelOutput = autofocus.ToString();
    }

    public const string BUTTON_SET_AUTOFOCUS = "htmlelement-inprocess-set-autofocus";
    private void SetAutofocus() {
        HTMLElement.Autofocus = true;
    }


    public const string BUTTON_GET_CONTENT_EDITABLE = "htmlelement-inprocess-get-content-editable";
    private void GetContentEditable() {
        string contentEditable = HTMLElement.ContentEditable;
        labelOutput = contentEditable;
    }

    public const string BUTTON_SET_CONTENT_EDITABLE = "htmlelement-inprocess-set-content-editable";
    private void SetContentEditable() {
        HTMLElement.ContentEditable = "true";
    }


    public const string BUTTON_GET_DATASET = "htmlelement-inprocess-get-dataset";
    private void GetDataset() {
        Dictionary<string, string> dataset = HTMLElement.Dataset;
        labelOutput = string.Join(", ", dataset.Select(pair => $"{pair.Key} = {pair.Value}"));
    }

    public const string BUTTON_SET_DATASET = "htmlelement-inprocess-set-dataset";
    private void SetDataset() {
        HTMLElement.SetDataset(TEST_DATASET_NAME, TEST_DATASET_VALUE);
    }

    public const string BUTTON_REMOVE_DATASET = "htmlelement-inprocess-remove-dataset";
    private void RemoveDataset() {
        HTMLElement.RemoveDataset(TEST_DATASET_NAME);
    }


    public const string BUTTON_GET_DIR = "htmlelement-inprocess-get-dir";
    private void GetDir() {
        string dir = HTMLElement.Dir;
        labelOutput = dir;
    }

    public const string BUTTON_SET_DIR = "htmlelement-inprocess-set-dir";
    private void SetDir() {
        HTMLElement.Dir = TEST_DIR;
    }


    public const string BUTTON_GET_DRAGGABLE = "htmlelement-inprocess-get-draggable";
    private void GetDraggable() {
        bool draggable = HTMLElement.Draggable;
        labelOutput = draggable.ToString();
    }

    public const string BUTTON_SET_DRAGGABLE = "htmlelement-inprocess-set-draggable";
    private void SetDraggable() {
        HTMLElement.Draggable = true;
    }


    public const string BUTTON_GET_ENTER_KEY_HINT = "htmlelement-inprocess-get-enter-key-hint";
    private void GetEnterKeyHint() {
        string enterKeyHint = HTMLElement.EnterKeyHint;
        labelOutput = enterKeyHint;
    }

    public const string BUTTON_SET_ENTER_KEY_HINT = "htmlelement-inprocess-set-enter-key-hint";
    private void SetEnterKeyHint() {
        HTMLElement.EnterKeyHint = TEST_ENTER_KEY_HINT;
    }


    public const string BUTTON_GET_HIDDEN = "htmlelement-inprocess-get-hidden";
    private void GetHidden() {
        bool hidden = HTMLElement.Hidden;
        labelOutput = hidden.ToString();
    }

    public const string BUTTON_SET_HIDDEN = "htmlelement-inprocess-set-hidden";
    private void SetHidden() {
        HTMLElement.Hidden = true;
    }


    public const string BUTTON_GET_INERT = "htmlelement-inprocess-get-inert";
    private void GetInert() {
        bool inert = HTMLElement.Inert;
        labelOutput = inert.ToString();
    }

    public const string BUTTON_SET_INERT = "htmlelement-inprocess-set-inert";
    private void SetInert() {
        HTMLElement.Inert = true;
    }


    public const string BUTTON_GET_INNERTEXT = "htmlelement-inprocess-get-innertext";
    private void GetInnerText() {
        string innerText = HTMLElement.InnerText;
        labelOutput = innerText;
    }

    public const string BUTTON_SET_INNERTEXT = "htmlelement-inprocess-set-innertext";
    private void SetInnerText() {
        HTMLElement.InnerText = TEST_INNERTEXT;
    }


    public const string BUTTON_GET_INPUT_MODE = "htmlelement-inprocess-get-input-mode";
    private void GetInputMode() {
        string inputMode = HTMLElement.InputMode;
        labelOutput = inputMode;
    }

    public const string BUTTON_SET_INPUT_MODE = "htmlelement-inprocess-set-input-mode";
    private void SetInputMode() {
        HTMLElement.InputMode = TEST_INPUT_MODE;
    }


    public const string BUTTON_GET_IS_CONTENT_EDITABLE = "htmlelement-inprocess-get-is-content-editable";
    private void GetIsContentEditable() {
        bool isContentEditable = HTMLElement.IsContentEditable;
        labelOutput = isContentEditable.ToString();
    }


    public const string BUTTON_GET_LANG = "htmlelement-inprocess-get-lang";
    private void GetLang() {
        string lang = HTMLElement.Lang;
        labelOutput = lang;
    }

    public const string BUTTON_SET_LANG = "htmlelement-inprocess-set-lang";
    private void SetLang() {
        HTMLElement.Lang = TEST_LANG;
    }


    public const string BUTTON_GET_NONCE = "htmlelement-inprocess-get-nonce";
    private void GetNonce() {
        string nonce = HTMLElement.Nonce;
        labelOutput = nonce;
    }

    public const string BUTTON_SET_NONCE = "htmlelement-inprocess-set-nonce";
    private void SetNonce() {
        HTMLElement.Nonce = TEST_NONCE;
    }


    public const string BUTTON_GET_OFFSETWIDTH = "htmlelement-inprocess-get-offsetwidth";
    private void GetOffsetWidth() {
        int offsetWidth = HTMLElement.OffsetWidth;
        labelOutput = offsetWidth.ToString();
    }

    public const string BUTTON_GET_OFFSETHEIGHT = "htmlelement-inprocess-get-offsetheight";
    private void GetOffsetHeight() {
        int offsetHeight = HTMLElement.OffsetHeight;
        labelOutput = offsetHeight.ToString();
    }

    public const string BUTTON_GET_OFFSETLEFT = "htmlelement-inprocess-get-offsetleft";
    private void GetOffsetLeft() {
        int offsetLeft = HTMLElement.OffsetLeft;
        labelOutput = offsetLeft.ToString();
    }

    public const string BUTTON_GET_OFFSETTOP = "htmlelement-inprocess-get-offsettop";
    private void GetOffsetTop() {
        int offsetTop = HTMLElement.OffsetTop;
        labelOutput = offsetTop.ToString();
    }

    public const string BUTTON_GET_OFFSETPARENT = "htmlelement-inprocess-get-offsetparent";
    private void GetOffsetParent() {
        using IHTMLElementInProcess? offsetParent = HTMLElement.OffsetParent;
        labelOutput = (offsetParent != null).ToString();
    }


    public const string BUTTON_GET_OUTERTEXT = "htmlelement-inprocess-get-outertext";
    private void GetOuterText() {
        string outerText = HTMLElement.OuterText;
        labelOutput = outerText;
    }

    public const string BUTTON_SET_OUTERTEXT = "htmlelement-inprocess-set-outertext";
    private void SetOuterText() {
        HTMLElement.OuterText = TEST_OUTERTEXT;
    }


    public const string BUTTON_GET_POPOVER = "htmlelement-inprocess-get-popover";
    private void GetPopover() {
        string? popover = HTMLElement.Popover;
        labelOutput = popover ?? "(empty)";
    }

    public const string BUTTON_SET_POPOVER = "htmlelement-inprocess-set-popover";
    private void SetPopover() {
        HTMLElement.Popover = TEST_POPOVER;
    }


    public const string BUTTON_GET_SPELLCHECK = "htmlelement-inprocess-get-spellcheck";
    private void GetSpellcheck() {
        bool spellcheck = HTMLElement.Spellcheck;
        labelOutput = spellcheck.ToString();
    }

    public const string BUTTON_SET_SPELLCHECK = "htmlelement-inprocess-set-spellcheck";
    private void SetSpellcheck() {
        HTMLElement.Spellcheck = true;
    }


    public const string BUTTON_GET_STYLE = "htmlelement-inprocess-get-style";
    private void GetStyle() {
        string style = HTMLElement.Style;
        labelOutput = style;
    }

    public const string BUTTON_SET_STYLE = "htmlelement-inprocess-set-style";
    private void SetStyle() {
        HTMLElement.Style = TEST_STYLE;
    }


    public const string BUTTON_GET_TAB_INDEX = "htmlelement-inprocess-get-tab-index";
    private void GetTabIndex() {
        long tabIndex = HTMLElement.TabIndex;
        labelOutput = tabIndex.ToString();
    }

    public const string BUTTON_SET_TAB_INDEX = "htmlelement-inprocess-set-tab-index";
    private void SetTabIndex() {
        HTMLElement.TabIndex = TEST_TAB_INDEX;
    }


    public const string BUTTON_GET_TITLE = "htmlelement-inprocess-get-title";
    private void GetTitle() {
        string title = HTMLElement.Title;
        labelOutput = title;
    }

    public const string BUTTON_SET_TITLE = "htmlelement-inprocess-set-title";
    private void SetTitle() {
        HTMLElement.Title = TEST_TITLE;
    }


    public const string BUTTON_GET_TRANSLATE = "htmlelement-inprocess-get-translate";
    private void GetTranslate() {
        bool translate = HTMLElement.Translate;
        labelOutput = translate.ToString();
    }

    public const string BUTTON_SET_TRANSLATE = "htmlelement-inprocess-set-translate";
    private void SetTranslate() {
        HTMLElement.Translate = true;
    }


    // extra

    public const string BUTTON_GET_HASFOCUS = "htmlelement-inprocess-get-hasfocus";
    private void GetHasFocus() {
        bool hasFocus = HTMLElement.HasFocus;
        labelOutput = hasFocus.ToString();
    }


    // methods

    public const string BUTTON_CLICK = "htmlelement-inprocess-click";
    private void Click() {
        HTMLElement.Click();
    }

    public const string BUTTON_FOCUS = "htmlelement-inprocess-focus";
    private void Focus() {
        HTMLElement.Focus(true);
        HTMLElement.Focus(false);
        HTMLElement.Focus();
    }

    public const string BUTTON_BLUR = "htmlelement-inprocess-blur";
    private void Blur() {
        HTMLElement.Blur();
    }

    public const string BUTTON_SHOW_POPOVER = "htmlelement-inprocess-show-popover";
    private void ShowPopover() {
        PopoverElement.ShowPopover();
    }

    public const string BUTTON_HIDE_POPOVER = "htmlelement-inprocess-hide-popover";
    private void HidePopover() {
        PopoverElement.HidePopover();
    }

    public const string BUTTON_TOGGLE_POPOVER = "htmlelement-inprocess-toggle-popover";
    private void TogglePopover() {
        PopoverElement.TogglePopover();
    }

    public const string BUTTON_TOGGLE_POPOVER_PARAMETER = "htmlelement-inprocess-toggle-popover-parameter";
    private void TogglePopoverParameter() {
        PopoverElement.TogglePopover(true);
        PopoverElement.TogglePopover(false);
    }


    // events

    public const string BUTTON_REGISTER_ON_CHANGE = "htmlelement-inprocess-change-event";
    private void RegisterOnChange() {
        IHTMLElementInProcess? tempElement = HTMLElement.NextElementSibling;
        if (tempElement is null)
            return;

        tempElement.OnChange += OnChange;

        void OnChange() {
            labelOutput = TEST_EVENT_CHANGE;
            StateHasChanged();
            tempElement.OnChange -= OnChange;
            tempElement.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_COMMAND = "htmlelement-inprocess-command-event";
    private void RegisterOnCommand() {
        PopoverElement.OnCommand += OnCommand;

        void OnCommand(IHTMLElementInProcess source, string command) {
            string? sourceId = source.GetAttribute("data-testid");
            labelOutput = $"id='{sourceId ?? "(null)"}', command='{command}'";
            StateHasChanged();
            PopoverElement.OnCommand -= OnCommand;
            source.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_LOAD = "htmlelement-inprocess-load-event";
    private void RegisterOnLoad() {
        IHTMLElementInProcess? tempElement = HTMLElement.NextElementSibling;
        if (tempElement is null)
            return;

        tempElement.OnLoad += OnLoad;

        void OnLoad() {
            labelOutput = TEST_EVENT_LOAD;
            StateHasChanged();
            tempElement.OnLoad -= OnLoad;
            tempElement.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_ERROR = "htmlelement-inprocess-error-event";
    private void RegisterOnError() {
        IHTMLElementInProcess? tempElement = HTMLElement.NextElementSibling;
        if (tempElement is null)
            return;

        tempElement.OnError += OnError;

        void OnError(JsonElement error) {
            labelOutput = error.ToString();
            StateHasChanged();
            tempElement.OnError -= OnError;
            tempElement.Dispose();
        }
    }


    public const string BUTTON_REGISTER_ON_DRAG = "htmlelement-inprocess-drag-event";
    private void RegisterOnDrag() {
        HiddenElement.OnDrag += OnDrag;

        void OnDrag(DragEventInProcess dragEvent) {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                HiddenElement.OnDrag -= OnDrag;
                dragEvent.Files.Dispose();
            }
        }
    }

    public const string BUTTON_REGISTER_ON_DRAG_START = "htmlelement-inprocess-drag-start-event";
    private void RegisterOnDragStart() {
        HiddenElement.OnDragStart += OnDragStart;

        void OnDragStart(DragEventInProcess dragEvent) {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                HiddenElement.OnDragStart -= OnDragStart;
                dragEvent.Files.Dispose();
            }
        }
    }

    public const string BUTTON_REGISTER_ON_DRAG_END = "htmlelement-inprocess-drag-end-event";
    private void RegisterOnDragEnd() {
        HiddenElement.OnDragEnd += OnDragEnd;

        void OnDragEnd(DragEventInProcess dragEvent) {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                HiddenElement.OnDragEnd -= OnDragEnd;
                dragEvent.Files.Dispose();
            }
        }
    }

    public const string BUTTON_REGISTER_ON_DRAG_ENTER = "htmlelement-inprocess-drag-enter-event";
    private void RegisterOnDragEnter() {
        PopoverElement.OnDragEnter += OnDragEnter;

        void OnDragEnter(DragEventInProcess dragEvent) {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                PopoverElement.OnDragEnter -= OnDragEnter;
                dragEvent.Files.Dispose();
            }
        }
    }

    public const string BUTTON_REGISTER_ON_DRAG_LEAVE = "htmlelement-inprocess-drag-leave-event";
    private void RegisterOnDragLeave() {
        PopoverElement.OnDragLeave += OnDragLeave;

        void OnDragLeave(DragEventInProcess dragEvent) {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                PopoverElement.OnDragLeave -= OnDragLeave;
                dragEvent.Files.Dispose();
            }
        }
    }

    public const string BUTTON_REGISTER_ON_DRAG_OVER = "htmlelement-inprocess-drag-over-event";
    private void RegisterOnDragOver() {
        PopoverElement.OnDragOver += OnDragOver;

        void OnDragOver(DragEventInProcess dragEvent) {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                PopoverElement.OnDragOver -= OnDragOver;
                dragEvent.Files.Dispose();
            }
        }
    }

    public const string BUTTON_REGISTER_ON_DROP = "htmlelement-inprocess-drop-event";
    private void RegisterOnDrop() {
        PopoverElement.OnDrop += OnDrop;

        void OnDrop(DragEventInProcess dragEvent) {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                PopoverElement.OnDrop -= OnDrop;
                dragEvent.Files.Dispose();
            }
        }
    }


    public const string BUTTON_REGISTER_ON_TOGGLE = "htmlelement-inprocess-toggle-event";
    private void RegisterOnToggle() {
        PopoverElement.OnToggle += OnToggle;

        void OnToggle(string oldState, string newState) {
            labelOutput = $"oldState='{oldState}', newState='{newState}'";
            StateHasChanged();
            PopoverElement.OnToggle -= OnToggle;
        }
    }

    public const string BUTTON_REGISTER_ON_BEFORE_TOGGLE = "htmlelement-inprocess-before-toggle-event";
    private void RegisterOnBeforeToggle() {
        PopoverElement.OnBeforeToggle += OnBeforeToggle;

        void OnBeforeToggle(string oldState, string newState) {
            labelOutput = $"oldState='{oldState}', newState='{newState}'";
            StateHasChanged();
            PopoverElement.OnBeforeToggle -= OnBeforeToggle;
        }
    }

    #endregion


    #region Node/Element

    public const string BUTTON_GET_ATTRIBUTES = "htmlelement-inprocess-get-attributes";
    private void GetAttributes() {
        Dictionary<string, string> attributes = HTMLElement.Attributes;
        labelOutput = JsonSerializer.Serialize(attributes);
    }

    public const string BUTTON_GET_CLASS_LIST = "htmlelement-inprocess-get-class-list";
    private void GetClassList() {
        string[] classList = HTMLElement.ClassList;
        labelOutput = string.Join(',', classList);
    }

    public const string BUTTON_GET_CLASS_NAME = "htmlelement-inprocess-get-class-name";
    private void GetClassName() {
        string className = HTMLElement.ClassName;
        labelOutput = className;
    }

    public const string BUTTON_SET_CLASS_NAME = "htmlelement-inprocess-set-class-name";
    private void SetClassName() {
        HTMLElement.ClassName = TEST_CLASSNAME;
    }


    public const string BUTTON_GET_CLIENT_WIDTH = "htmlelement-inprocess-get-client-width";
    private void GetClientWidth() {
        int clientWidth = HTMLElement.ClientWidth;
        labelOutput = clientWidth.ToString();
    }

    public const string BUTTON_GET_CLIENT_HEIGHT = "htmlelement-inprocess-get-client-height";
    private void GetClientHeight() {
        int clientHeight = HTMLElement.ClientHeight;
        labelOutput = clientHeight.ToString();
    }

    public const string BUTTON_GET_CLIENT_LEFT = "htmlelement-inprocess-get-client-left";
    private void GetClientLeft() {
        int clientLeft = HTMLElement.ClientLeft;
        labelOutput = clientLeft.ToString();
    }

    public const string BUTTON_GET_CLIENT_TOP = "htmlelement-inprocess-get-client-top";
    private void GetClientTop() {
        int clientTop = HTMLElement.ClientTop;
        labelOutput = clientTop.ToString();
    }


    public const string BUTTON_GET_CURRENT_CSS_ZOOM = "htmlelement-inprocess-get-current-css-zoom";
    private void GetCurrentCSSZoom() {
        double currentCSSZoom = HTMLElement.CurrentCSSZoom;
        labelOutput = currentCSSZoom.ToString();
    }


    public const string BUTTON_GET_ID = "htmlelement-inprocess-get-id";
    private void GetId() {
        string id = HTMLElement.Id;
        labelOutput = id;
    }

    public const string BUTTON_SET_ID = "htmlelement-inprocess-set-id";
    private void SetId() {
        HTMLElement.Id = TEST_ID;
    }


    public const string BUTTON_GET_IS_CONNECTED = "htmlelement-inprocess-get-is-connected";
    private void GetIsConnected() {
        bool isConnected = HTMLElement.IsConnected;
        labelOutput = isConnected.ToString();
    }


    public const string BUTTON_GET_INNER_HTML = "htmlelement-inprocess-get-inner-html";
    private void GetInnerHTML() {
        string innerHTML = HTMLElement.InnerHTML;
        labelOutput = innerHTML;
    }

    public const string BUTTON_SET_INNER_HTML = "htmlelement-inprocess-set-inner-html";
    private void SetInnerHTML() {
        HTMLElement.InnerHTML = TEST_INNERHTML;
    }


    public const string BUTTON_GET_OUTER_HTML = "htmlelement-inprocess-get-outer-html";
    private void GetOuterHTML() {
        string outerHTML = HTMLElement.OuterHTML;
        labelOutput = outerHTML;
    }

    public const string BUTTON_SET_OUTER_HTML = "htmlelement-inprocess-set-outer-html";
    private void SetOuterHTML() {
        HTMLElement.OuterHTML = TEST_OUTERHTML;
    }


    public const string BUTTON_GET_PART = "htmlelement-inprocess-get-part";
    private void GetPart() {
        string[] part = HTMLElement.Part;
        labelOutput = string.Join(',', part);
    }


    public const string BUTTON_GET_SCROLL_WIDTH = "htmlelement-inprocess-get-scroll-width";
    private void GetScrollWidth() {
        int ScrollWidth = HTMLElement.ScrollWidth;
        labelOutput = ScrollWidth.ToString();
    }

    public const string BUTTON_GET_SCROLL_HEIGHT = "htmlelement-inprocess-get-scroll-height";
    private void GetScrollHeight() {
        int ScrollHeight = HTMLElement.ScrollHeight;
        labelOutput = ScrollHeight.ToString();
    }

    public const string BUTTON_GET_SCROLL_LEFT = "htmlelement-inprocess-get-scroll-left";
    private void GetScrollLeft() {
        int ScrollLeft = HTMLElement.ScrollLeft;
        labelOutput = ScrollLeft.ToString();
    }

    public const string BUTTON_SET_SCROLL_LEFT = "htmlelement-inprocess-set-scroll-left";
    private void SetScrollLeft() {
        HTMLElement.ScrollLeft = TEST_SCROLLLEFT;
    }

    public const string BUTTON_GET_SCROLL_TOP = "htmlelement-inprocess-get-scroll-top";
    private void GetScrollTop() {
        int ScrollTop = HTMLElement.ScrollTop;
        labelOutput = ScrollTop.ToString();
    }

    public const string BUTTON_SET_SCROLL_TOP = "htmlelement-inprocess-set-scroll-top";
    private void SetScrollTop() {
        HTMLElement.ScrollTop = TEST_SCROLLTOP;
    }


    public const string BUTTON_GET_SLOT = "htmlelement-inprocess-get-slot";
    private void GetSlot() {
        string slot = HTMLElement.Slot;
        labelOutput = slot;
    }

    public const string BUTTON_SET_SLOT = "htmlelement-inprocess-set-slot";
    private void SetSlot() {
        HTMLElement.Slot = TEST_SLOT;
    }


    public const string BUTTON_GET_TEXT_CONTENT = "htmlelement-inprocess-get-text-content";
    private void GetTextContent() {
        string textContent = HTMLElement.TextContent;
        labelOutput = textContent;
    }

    public const string BUTTON_SET_TEXT_CONTENT = "htmlelement-inprocess-set-text-content";
    private void SetTextContent() {
        HTMLElement.TextContent = TEST_TEXT_CONTENT;
    }


    public const string BUTTON_GET_LOCAL_NAME = "htmlelement-inprocess-get-local-name";
    private void GetLocalName() {
        string localName = HTMLElement.LocalName;
        labelOutput = localName;
    }

    public const string BUTTON_GET_NAMESPACE_URI = "htmlelement-inprocess-get-namespace-uri";
    private void GetNamespaceURI() {
        string? namespaceURI = HTMLElement.NamespaceURI;
        labelOutput = namespaceURI ?? "empty namespace";
    }

    public const string BUTTON_GET_PREFIX = "htmlelement-inprocess-get-prefix";
    private void GetPrefix() {
        string? prefix = HTMLElement.Prefix;
        labelOutput = prefix ?? "no prefix";
    }

    public const string BUTTON_GET_BASE_URI = "htmlelement-inprocess-get-base-uri";
    private void GetBaseURI() {
        string baseURI = HTMLElement.BaseURI;
        labelOutput = baseURI;
    }

    public const string BUTTON_GET_TAG_NAME = "htmlelement-inprocess-get-tag-name";
    private void GetTagName() {
        string tagName = HTMLElement.TagName;
        labelOutput = tagName;
    }

    public const string BUTTON_GET_NODE_NAME = "htmlelement-inprocess-get-node-name";
    private void GetNodeName() {
        string nodeName = HTMLElement.NodeName;
        labelOutput = nodeName;
    }

    public const string BUTTON_GET_NODE_TYPE = "htmlelement-inprocess-get-node-type";
    private void GetNodeType() {
        int nodeType = HTMLElement.NodeType;
        labelOutput = nodeType.ToString();
    }


    // properties - Tree nodes

    public const string BUTTON_GET_CHILD_ELEMENT_COUNT = "htmlelement-inprocess-get-child-element-count";
    private void GetChildElementCount() {
        int childElementCount = HTMLElement.ChildElementCount;
        labelOutput = childElementCount.ToString();
    }

    public const string BUTTON_GET_CHILDREN = "htmlelement-inprocess-get-children";
    private void GetChildren() {
        IHTMLElementInProcess[] children = HTMLElement.Children;
        labelOutput = children.Length.ToString();

        children.Dispose();
    }

    public const string BUTTON_GET_FIRST_ELEMENT_CHILD = "htmlelement-inprocess-get-first-element-child";
    private void GetFirstElementChild() {
        using IHTMLElementInProcess? child = HTMLElement.FirstElementChild;
        labelOutput = (child is not null).ToString();
    }

    public const string BUTTON_GET_LAST_ELEMENT_CHILD = "htmlelement-inprocess-get-last-element-child";
    private void GetLastElementChild() {
        using IHTMLElementInProcess? child = HTMLElement.LastElementChild;
        labelOutput = (child is not null).ToString();
    }

    public const string BUTTON_GET_PREVIOUS_ELEMENT_SIBLING = "htmlelement-inprocess-get-previous-element-sibling";
    private void GetPreviousElementSibling() {
        using IHTMLElementInProcess? sibling = HTMLElement.PreviousElementSibling;
        labelOutput = (sibling is not null).ToString();
    }

    public const string BUTTON_GET_NEXT_ELEMENT_SIBLING = "htmlelement-inprocess-get-next-element-sibling";
    private void GetNextElementSibling() {
        using IHTMLElementInProcess? sibling = HTMLElement.NextElementSibling;
        labelOutput = (sibling is not null).ToString();
    }

    public const string BUTTON_GET_PARENT_ELEMENT = "htmlelement-inprocess-get-parent-element";
    private void GetParentElement() {
        using IHTMLElementInProcess? parent = HTMLElement.ParentElement;
        labelOutput = (parent is not null).ToString();
    }


    // properties - ARIA

    public const string BUTTON_GET_ARIA_ATOMIC = "htmlelement-inprocess-get-aria-atomic";
    private void GetAriaAtomic() => labelOutput = HTMLElement.AriaAtomic ?? "'aria-atomic' attr not set";

    public const string BUTTON_SET_ARIA_ATOMIC = "htmlelement-inprocess-set-aria-atomic";
    private void SetAriaAtomic() => HTMLElement.AriaAtomic = TEST_ARIA_ATOMIC;


    public const string BUTTON_GET_ARIA_AUTO_COMPLETE = "htmlelement-inprocess-get-aria-auto-complete";
    private void GetAriaAutoComplete() => labelOutput = HTMLElement.AriaAutoComplete ?? "'aria-autocomplete' attr not set";

    public const string BUTTON_SET_ARIA_AUTO_COMPLETE = "htmlelement-inprocess-set-aria-auto-complete";
    private void SetAriaAutoComplete() => HTMLElement.AriaAutoComplete = TEST_ARIA_AUTO_COMPLETE;


    public const string BUTTON_GET_ARIA_BRAILLE_LABEL = "htmlelement-inprocess-get-aria-braille-label";
    private void GetAriaBrailleLabel() => labelOutput = HTMLElement.AriaBrailleLabel ?? "'aria-braillelabel' attr not set";

    public const string BUTTON_SET_ARIA_BRAILLE_LABEL = "htmlelement-inprocess-set-aria-braille-label";
    private void SetAriaBrailleLabel() => HTMLElement.AriaBrailleLabel = TEST_ARIA_BRAILLE_LABEL;


    public const string BUTTON_GET_ARIA_BRAILLE_ROLE_DESCRIPTION = "htmlelement-inprocess-get-aria-braille-role-description";
    private void GetAriaBrailleRoleDescription() => labelOutput = HTMLElement.AriaBrailleRoleDescription ?? "'aria-brailleroledescription' attr not set";

    public const string BUTTON_SET_ARIA_BRAILLE_ROLE_DESCRIPTION = "htmlelement-inprocess-set-aria-braille-role-description";
    private void SetAriaBrailleRoleDescription() => HTMLElement.AriaBrailleRoleDescription = TEST_ARIA_BRAILLE_ROLE_DESCRIPTION;


    public const string BUTTON_GET_ARIA_BUSY = "htmlelement-inprocess-get-aria-busy";
    private void GetAriaBusy() => labelOutput = HTMLElement.AriaBusy ?? "'aria-busy' attr not set";

    public const string BUTTON_SET_ARIA_BUSY = "htmlelement-inprocess-set-aria-busy";
    private void SetAriaBusy() => HTMLElement.AriaBusy = TEST_ARIA_BUSY;


    public const string BUTTON_GET_ARIA_CHECKED = "htmlelement-inprocess-get-aria-checked";
    private void GetAriaChecked() => labelOutput = HTMLElement.AriaChecked ?? "'aria-checked' attr not set";

    public const string BUTTON_SET_ARIA_CHECKED = "htmlelement-inprocess-set-aria-checked";
    private void SetAriaChecked() => HTMLElement.AriaChecked = TEST_ARIA_CHECKED;


    public const string BUTTON_GET_ARIA_COL_COUNT = "htmlelement-inprocess-get-aria-col-count";
    private void GetAriaColCount() => labelOutput = HTMLElement.AriaColCount ?? "'aria-colcount' attr not set";

    public const string BUTTON_SET_ARIA_COL_COUNT = "htmlelement-inprocess-set-aria-col-count";
    private void SetAriaColCount() => HTMLElement.AriaColCount = TEST_ARIA_COL_COUNT;


    public const string BUTTON_GET_ARIA_COL_INDEX = "htmlelement-inprocess-get-aria-col-index";
    private void GetAriaColIndex() => labelOutput = HTMLElement.AriaColIndex ?? "'aria-colindex' attr not set";

    public const string BUTTON_SET_ARIA_COL_INDEX = "htmlelement-inprocess-set-aria-col-index";
    private void SetAriaColIndex() => HTMLElement.AriaColIndex = TEST_ARIA_COL_INDEX;


    public const string BUTTON_GET_ARIA_COL_INDEX_TEXT = "htmlelement-inprocess-get-aria-col-index-text";
    private void GetAriaColIndexText() => labelOutput = HTMLElement.AriaColIndexText ?? "'aria-colindextext' attr not set";

    public const string BUTTON_SET_ARIA_COL_INDEX_TEXT = "htmlelement-inprocess-set-aria-col-index-text";
    private void SetAriaColIndexText() => HTMLElement.AriaColIndexText = TEST_ARIA_COL_INDEX_TEXT;


    public const string BUTTON_GET_ARIA_COL_SPAN = "htmlelement-inprocess-get-aria-col-span";
    private void GetAriaColSpan() => labelOutput = HTMLElement.AriaColSpan ?? "'aria-colspan' attr not set";

    public const string BUTTON_SET_ARIA_COL_SPAN = "htmlelement-inprocess-set-aria-col-span";
    private void SetAriaColSpan() => HTMLElement.AriaColSpan = TEST_ARIA_COL_SPAN;


    public const string BUTTON_GET_ARIA_CURRENT = "htmlelement-inprocess-get-aria-current";
    private void GetAriaCurrent() => labelOutput = HTMLElement.AriaCurrent ?? "'aria-current' attr not set";

    public const string BUTTON_SET_ARIA_CURRENT = "htmlelement-inprocess-set-aria-current";
    private void SetAriaCurrent() => HTMLElement.AriaCurrent = TEST_ARIA_CURRENT;


    public const string BUTTON_GET_ARIA_DESCRIPTION = "htmlelement-inprocess-get-aria-description";
    private void GetAriaDescription() => labelOutput = HTMLElement.AriaDescription ?? "'aria-description' attr not set";

    public const string BUTTON_SET_ARIA_DESCRIPTION = "htmlelement-inprocess-set-aria-description";
    private void SetAriaDescription() => HTMLElement.AriaDescription = TEST_ARIA_DESCRIPTION;


    public const string BUTTON_GET_ARIA_DISABLED = "htmlelement-inprocess-get-aria-disabled";
    private void GetAriaDisabled() => labelOutput = HTMLElement.AriaDisabled ?? "'aria-disabled' attr not set";

    public const string BUTTON_SET_ARIA_DISABLED = "htmlelement-inprocess-set-aria-disabled";
    private void SetAriaDisabled() => HTMLElement.AriaDisabled = TEST_ARIA_DISABLED;


    public const string BUTTON_GET_ARIA_EXPANDED = "htmlelement-inprocess-get-aria-expanded";
    private void GetAriaExpanded() => labelOutput = HTMLElement.AriaExpanded ?? "'aria-expanded' attr not set";

    public const string BUTTON_SET_ARIA_EXPANDED = "htmlelement-inprocess-set-aria-expanded";
    private void SetAriaExpanded() => HTMLElement.AriaExpanded = TEST_ARIA_EXPANDED;


    public const string BUTTON_GET_ARIA_HAS_POPUP = "htmlelement-inprocess-get-aria-has-popup";
    private void GetAriaHasPopup() => labelOutput = HTMLElement.AriaHasPopup ?? "'aria-haspopup' attr not set";

    public const string BUTTON_SET_ARIA_HAS_POPUP = "htmlelement-inprocess-set-aria-has-popup";
    private void SetAriaHasPopup() => HTMLElement.AriaHasPopup = TEST_ARIA_HAS_POPUP;


    public const string BUTTON_GET_ARIA_HIDDEN = "htmlelement-inprocess-get-aria-hidden";
    private void GetAriaHidden() => labelOutput = HTMLElement.AriaHidden ?? "'aria-hidden' attr not set";

    public const string BUTTON_SET_ARIA_HIDDEN = "htmlelement-inprocess-set-aria-hidden";
    private void SetAriaHidden() => HTMLElement.AriaHidden = TEST_ARIA_HIDDEN;


    public const string BUTTON_GET_ARIA_INVALID = "htmlelement-inprocess-get-aria-invalid";
    private void GetAriaInvalid() => labelOutput = HTMLElement.AriaInvalid ?? "'aria-invalid' attr not set";

    public const string BUTTON_SET_ARIA_INVALID = "htmlelement-inprocess-set-aria-invalid";
    private void SetAriaInvalid() => HTMLElement.AriaInvalid = TEST_ARIA_INVALID;


    public const string BUTTON_GET_ARIA_KEY_SHORTCUTS = "htmlelement-inprocess-get-aria-key-shortcuts";
    private void GetAriaKeyShortcuts() => labelOutput = HTMLElement.AriaKeyShortcuts ?? "'aria-keyshortcuts' attr not set";

    public const string BUTTON_SET_ARIA_KEY_SHORTCUTS = "htmlelement-inprocess-set-aria-key-shortcuts";
    private void SetAriaKeyShortcuts() => HTMLElement.AriaKeyShortcuts = TEST_ARIA_KEY_SHORTCUTS;


    public const string BUTTON_GET_ARIA_LABEL = "htmlelement-inprocess-get-aria-label";
    private void GetAriaLabel() => labelOutput = HTMLElement.AriaLabel ?? "'aria-label' attr not set";

    public const string BUTTON_SET_ARIA_LABEL = "htmlelement-inprocess-set-aria-label";
    private void SetAriaLabel() => HTMLElement.AriaLabel = TEST_ARIA_LABEL;


    public const string BUTTON_GET_ARIA_LEVEL = "htmlelement-inprocess-get-aria-level";
    private void GetAriaLevel() => labelOutput = HTMLElement.AriaLevel ?? "'aria-level' attr not set";

    public const string BUTTON_SET_ARIA_LEVEL = "htmlelement-inprocess-set-aria-level";
    private void SetAriaLevel() => HTMLElement.AriaLevel = TEST_ARIA_LEVEL;


    public const string BUTTON_GET_ARIA_LIVE = "htmlelement-inprocess-get-aria-live";
    private void GetAriaLive() => labelOutput = HTMLElement.AriaLive ?? "'aria-live' attr not set";

    public const string BUTTON_SET_ARIA_LIVE = "htmlelement-inprocess-set-aria-live";
    private void SetAriaLive() => HTMLElement.AriaLive = TEST_ARIA_LIVE;


    public const string BUTTON_GET_ARIA_MODAL = "htmlelement-inprocess-get-aria-modal";
    private void GetAriaModal() => labelOutput = HTMLElement.AriaModal ?? "'aria-modal' attr not set";

    public const string BUTTON_SET_ARIA_MODAL = "htmlelement-inprocess-set-aria-modal";
    private void SetAriaModal() => HTMLElement.AriaModal = TEST_ARIA_MODAL;


    public const string BUTTON_GET_ARIA_MULTILINE = "htmlelement-inprocess-get-aria-multiline";
    private void GetAriaMultiline() => labelOutput = HTMLElement.AriaMultiline ?? "'aria-multiline' attr not set";

    public const string BUTTON_SET_ARIA_MULTILINE = "htmlelement-inprocess-set-aria-multiline";
    private void SetAriaMultiline() => HTMLElement.AriaMultiline = TEST_ARIA_MULTILINE;


    public const string BUTTON_GET_ARIA_MULTI_SELECTABLE = "htmlelement-inprocess-get-aria-multi-selectable";
    private void GetAriaMultiSelectable() => labelOutput = HTMLElement.AriaMultiSelectable ?? "'aria-multiselectable' attr not set";

    public const string BUTTON_SET_ARIA_MULTI_SELECTABLE = "htmlelement-inprocess-set-aria-multi-selectable";
    private void SetAriaMultiSelectable() => HTMLElement.AriaMultiSelectable = TEST_ARIA_MULTI_SELECTABLE;


    public const string BUTTON_GET_ARIA_ORIENTATION = "htmlelement-inprocess-get-aria-orientation";
    private void GetAriaOrientation() => labelOutput = HTMLElement.AriaOrientation ?? "'aria-orientation' attr not set";

    public const string BUTTON_SET_ARIA_ORIENTATION = "htmlelement-inprocess-set-aria-orientation";
    private void SetAriaOrientation() => HTMLElement.AriaOrientation = TEST_ARIA_ORIENTATION;


    public const string BUTTON_GET_ARIA_PLACEHOLDER = "htmlelement-inprocess-get-aria-placeholder";
    private void GetAriaPlaceholder() => labelOutput = HTMLElement.AriaPlaceholder ?? "'aria-placeholder' attr not set";

    public const string BUTTON_SET_ARIA_PLACEHOLDER = "htmlelement-inprocess-set-aria-placeholder";
    private void SetAriaPlaceholder() => HTMLElement.AriaPlaceholder = TEST_ARIA_PLACEHOLDER;


    public const string BUTTON_GET_ARIA_POS_IN_SET = "htmlelement-inprocess-get-aria-pos-in-set";
    private void GetAriaPosInSet() => labelOutput = HTMLElement.AriaPosInSet ?? "'aria-posinset' attr not set";

    public const string BUTTON_SET_ARIA_POS_IN_SET = "htmlelement-inprocess-set-aria-pos-in-set";
    private void SetAriaPosInSet() => HTMLElement.AriaPosInSet = TEST_ARIA_POS_IN_SET;


    public const string BUTTON_GET_ARIA_PRESSED = "htmlelement-inprocess-get-aria-pressed";
    private void GetAriaPressed() => labelOutput = HTMLElement.AriaPressed ?? "'aria-pressed' attr not set";

    public const string BUTTON_SET_ARIA_PRESSED = "htmlelement-inprocess-set-aria-pressed";
    private void SetAriaPressed() => HTMLElement.AriaPressed = TEST_ARIA_PRESSED;


    public const string BUTTON_GET_ARIA_READ_ONLY = "htmlelement-inprocess-get-aria-read-only";
    private void GetAriaReadOnly() => labelOutput = HTMLElement.AriaReadOnly ?? "'aria-readonly' attr not set";

    public const string BUTTON_SET_ARIA_READ_ONLY = "htmlelement-inprocess-set-aria-read-only";
    private void SetAriaReadOnly() => HTMLElement.AriaReadOnly = TEST_ARIA_READ_ONLY;


    public const string BUTTON_GET_ARIA_REQUIRED = "htmlelement-inprocess-get-aria-required";
    private void GetAriaRequired() => labelOutput = HTMLElement.AriaRequired ?? "'aria-required' attr not set";

    public const string BUTTON_SET_ARIA_REQUIRED = "htmlelement-inprocess-set-aria-required";
    private void SetAriaRequired() => HTMLElement.AriaRequired = TEST_ARIA_REQUIRED;


    public const string BUTTON_GET_ARIA_ROLE_DESCRIPTION = "htmlelement-inprocess-get-aria-roledescription";
    private void GetAriaRoleDescription() => labelOutput = HTMLElement.AriaRoleDescription ?? "'aria-roledescription' attr not set";

    public const string BUTTON_SET_ARIA_ROLE_DESCRIPTION = "htmlelement-inprocess-set-aria-roledescription";
    private void SetAriaRoleDescription() => HTMLElement.AriaRoleDescription = TEST_ARIA_ROLE_DESCRIPTION;


    public const string BUTTON_GET_ARIA_ROW_COUNT = "htmlelement-inprocess-get-aria-row-count";
    private void GetAriaRowCount() => labelOutput = HTMLElement.AriaRowCount ?? "'aria-rowcount' attr not set";

    public const string BUTTON_SET_ARIA_ROW_COUNT = "htmlelement-inprocess-set-aria-row-count";
    private void SetAriaRowCount() => HTMLElement.AriaRowCount = TEST_ARIA_ROW_COUNT;


    public const string BUTTON_GET_ARIA_ROW_INDEX = "htmlelement-inprocess-get-aria-row-index";
    private void GetAriaRowIndex() => labelOutput = HTMLElement.AriaRowIndex ?? "'aria-rowindex' attr not set";

    public const string BUTTON_SET_ARIA_ROW_INDEX = "htmlelement-inprocess-set-aria-row-index";
    private void SetAriaRowIndex() => HTMLElement.AriaRowIndex = TEST_ARIA_ROW_INDEX;


    public const string BUTTON_GET_ARIA_ROW_INDEX_TEXT = "htmlelement-inprocess-get-aria-row-index-text";
    private void GetAriaRowIndexText() => labelOutput = HTMLElement.AriaRowIndexText ?? "'aria-rowindextext' attr not set";

    public const string BUTTON_SET_ARIA_ROW_INDEX_TEXT = "htmlelement-inprocess-set-aria-row-index-text";
    private void SetAriaRowIndexText() => HTMLElement.AriaRowIndexText = TEST_ARIA_ROW_INDEX_TEXT;


    public const string BUTTON_GET_ARIA_ROW_SPAN = "htmlelement-inprocess-get-aria-row-span";
    private void GetAriaRowSpan() => labelOutput = HTMLElement.AriaRowSpan ?? "'aria-rowspan' attr not set";

    public const string BUTTON_SET_ARIA_ROW_SPAN = "htmlelement-inprocess-set-aria-row-span";
    private void SetAriaRowSpan() => HTMLElement.AriaRowSpan = TEST_ARIA_ROW_SPAN;


    public const string BUTTON_GET_ARIA_SELECTED = "htmlelement-inprocess-get-aria-selected";
    private void GetAriaSelected() => labelOutput = HTMLElement.AriaSelected ?? "'aria-selected' attr not set";

    public const string BUTTON_SET_ARIA_SELECTED = "htmlelement-inprocess-set-aria-selected";
    private void SetAriaSelected() => HTMLElement.AriaSelected = TEST_ARIA_SELECTED;


    public const string BUTTON_GET_ARIA_SET_SIZE = "htmlelement-inprocess-get-aria-set-size";
    private void GetAriaSetSize() => labelOutput = HTMLElement.AriaSetSize ?? "'aria-setsize' attr not set";

    public const string BUTTON_SET_ARIA_SET_SIZE = "htmlelement-inprocess-set-aria-set-size";
    private void SetAriaSetSize() => HTMLElement.AriaSetSize = TEST_ARIA_SET_SIZE;


    public const string BUTTON_GET_ARIA_SORT = "htmlelement-inprocess-get-aria-sort";
    private void GetAriaSort() => labelOutput = HTMLElement.AriaSort ?? "'aria-sort' attr not set";

    public const string BUTTON_SET_ARIA_SORT = "htmlelement-inprocess-set-aria-sort";
    private void SetAriaSort() => HTMLElement.AriaSort = TEST_ARIA_SORT;


    public const string BUTTON_GET_ARIA_VALUE_MAX = "htmlelement-inprocess-get-aria-value-max";
    private void GetAriaValueMax() => labelOutput = HTMLElement.AriaValueMax ?? "'aria-valuemax' attr not set";

    public const string BUTTON_SET_ARIA_VALUE_MAX = "htmlelement-inprocess-set-aria-value-max";
    private void SetAriaValueMax() => HTMLElement.AriaValueMax = TEST_ARIA_VALUE_MAX;


    public const string BUTTON_GET_ARIA_VALUE_MIN = "htmlelement-inprocess-get-aria-value-min";
    private void GetAriaValueMin() => labelOutput = HTMLElement.AriaValueMin ?? "'aria-valuemin' attr not set";

    public const string BUTTON_SET_ARIA_VALUE_MIN = "htmlelement-inprocess-set-aria-value-min";
    private void SetAriaValueMin() => HTMLElement.AriaValueMin = TEST_ARIA_VALUE_MIN;


    public const string BUTTON_GET_ARIA_VALUE_NOW = "htmlelement-inprocess-get-aria-value-now";
    private void GetAriaValueNow() => labelOutput = HTMLElement.AriaValueNow ?? "'aria-valuenow' attr not set";

    public const string BUTTON_SET_ARIA_VALUE_NOW = "htmlelement-inprocess-set-aria-value-now";
    private void SetAriaValueNow() => HTMLElement.AriaValueNow = TEST_ARIA_VALUE_NOW;


    public const string BUTTON_GET_ARIA_VALUE_TEXT = "htmlelement-inprocess-get-aria-value-text";
    private void GetAriaValueText() => labelOutput = HTMLElement.AriaValueText ?? "'aria-valuetext' attr not set";

    public const string BUTTON_SET_ARIA_VALUE_TEXT = "htmlelement-inprocess-set-aria-value-text";
    private void SetAriaValueText() => HTMLElement.AriaValueText = TEST_ARIA_VALUE_TEXT;


    public const string BUTTON_GET_ROLE = "htmlelement-inprocess-get-role";
    private void GetRole() => labelOutput = HTMLElement.Role ?? "'role' attr not set";

    public const string BUTTON_SET_ROLE = "htmlelement-inprocess-set-role";
    private void SetRole() => HTMLElement.Role = TEST_ROLE;


    // methods

    public const string BUTTON_CHECK_VISIBILITY = "htmlelement-inprocess-check-visibility";
    private void CheckVisibility() {
        bool visibility = HTMLElement.CheckVisibility();
        labelOutput = visibility.ToString();
    }

    public const string BUTTON_COMPUTED_STYLE_MAP = "htmlelement-inprocess-computed-style-map";
    private void ComputedStyleMap() {
        Dictionary<string, string> computedStyleMap = HTMLElement.ComputedStyleMap();
        labelOutput = JsonSerializer.Serialize(computedStyleMap);
    }

    public const string BUTTON_GET_BOUNDING_CLIENT_RECT = "htmlelement-inprocess-get-bounding-client-rect";
    private void GetBoundingClientRect() {
        DOMRect domRect = HTMLElement.GetBoundingClientRect();
        labelOutput = domRect.ToString();
    }

    public const string BUTTON_GET_CLIENT_RECTS = "htmlelement-inprocess-get-client-rects";
    private void GetClientRects() {
        DOMRect[] domRect = HTMLElement.GetClientRects();
        labelOutput = string.Join(';', domRect);
    }

    public const string BUTTON_MATCHES = "htmlelement-inprocess-matches";
    private void Matches() {
        bool matches = HTMLElement.Matches($"[data-testid={HTML_ELEMENT}]");
        labelOutput = matches.ToString();
    }

    public const string BUTTON_REQUEST_FULLSCREEN = "htmlelement-inprocess-request-fullscreen";
    private async Task RequestFullscreen() {
        await HTMLElement.RequestFullscreen();
    }

    public const string BUTTON_REQUEST_POINTER_LOCK = "htmlelement-inprocess-request-pointer-lock";
    private async Task RequestPointerLock() {
        await HTMLElement.RequestPointerLock();
    }

    public const string BUTTON_IS_DEFAULT_NAMESPACE = "htmlelement-inprocess-is-default-namespace";
    private void IsDefaultNamespace() {
        bool isDefaultNamespace = HTMLElement.IsDefaultNamespace("http://www.w3.org/1999/xhtml");
        labelOutput = isDefaultNamespace.ToString();
    }

    public const string BUTTON_LOOKUP_PREFIX = "htmlelement-inprocess-lookup-prefix";
    private void LookupPrefix() {
        string? prefix = HTMLElement.LookupPrefix("http://www.w3.org/1999/xhtml");
        labelOutput = prefix ?? "(no prefix)";
    }

    public const string BUTTON_LOOKUP_NAMESPACE_URI = "htmlelement-inprocess-lookup-namespace-uri";
    private void LookupNamespaceURI() {
        string? namespaceURI = HTMLElement.LookupNamespaceURI(null);
        labelOutput = namespaceURI ?? "(no namespace uri)";
    }

    public const string BUTTON_NORMALIZE = "htmlelement-inprocess-normalize";
    private void Normalize() {
        HTMLElement.Normalize();
    }


    // methods - Pointer Capture

    private void SetPointerCapture(PointerEventArgs e) {
        HTMLElement.SetPointerCapture(e.PointerId);
    }

    private void ReleasePointerCapture(PointerEventArgs e) {
        HTMLElement.ReleasePointerCapture(e.PointerId);
    }

    private void HasPointerCapture(PointerEventArgs e) {
        bool hasPointerCapture = HTMLElement.HasPointerCapture(e.PointerId);
        labelOutput = $"HasPointerCapture={hasPointerCapture}";
    }


    // methods - Scroll

    public const string BUTTON_SCROLL = "htmlelement-inprocess-scroll";
    private void Scroll() {
        HTMLElement.Scroll(TEST_SCROLL_LEFT, TEST_SCROLL_TOP);
    }

    public const string BUTTON_SCROLL_TO = "htmlelement-inprocess-scroll-to";
    private void ScrollTo() {
        HTMLElement.ScrollTo(TEST_SCROLL_LEFT, TEST_SCROLL_TOP);
    }

    public const string BUTTON_SCROLL_BY = "htmlelement-inprocess-scroll-by";
    private void ScrollBy() {
        HTMLElement.ScrollBy(TEST_SCROLL_BY_X, TEST_SCROLL_BY_Y);
    }

    public const string BUTTON_SCROLL_INTO_VIEW = "htmlelement-inprocess-scroll-into-view";
    private void ScrollIntoView() {
        HTMLElement.ScrollIntoView();
    }


    // methods - Attribute

    public const string BUTTON_GET_ATTRIBUTE = "htmlelement-inprocess-get-attribute";
    private void GetAttribute() {
        string? attribute = HTMLElement.GetAttribute("data-testid");
        labelOutput = attribute ?? "'data-testid' attr not found";
    }

    public const string BUTTON_GET_ATTRIBUTE_NS = "htmlelement-inprocess-get-attribute-ns";
    private void GetAttributeNS() {
        string? attribute = HTMLElement.GetAttributeNS("", "data-testid");
        labelOutput = attribute ?? "'data-testid' attr not found";
    }

    public const string BUTTON_GET_ATTRIBUTE_NAMES = "htmlelement-inprocess-get-attribute-names";
    private void GetAttributeNames() {
        string[] attributeNames = HTMLElement.GetAttributeNames();
        labelOutput = $"({attributeNames.Length}): {string.Join(',', attributeNames)}";
    }

    public const string BUTTON_SET_ATTRIBUTE = "htmlelement-inprocess-set-attribute";
    private void SetAttribute() {
        HTMLElement.SetAttribute(TEST_CUSTOM_NAME, TEST_CUSTOM_VALUE);
    }

    public const string BUTTON_SET_ATTRIBUTE_NS = "htmlelement-inprocess-set-attribute-ns";
    private void SetAttributeNS() {
        HTMLElement.SetAttributeNS("http://www.w3.org/1999/xhtml", TEST_CUSTOM_NAME, TEST_CUSTOM_VALUE);
    }

    public const string BUTTON_TOGGLE_ATTRIBUTE = "htmlelement-inprocess-toggle-attribute";
    private void ToggleAttribute() {
        HTMLElement.ToggleAttribute(TEST_CUSTOM_NAME);
    }

    public const string BUTTON_REMOVE_ATTRIBUTE = "htmlelement-inprocess-remove-attribute";
    private void RemoveAttribute() {
        HTMLElement.RemoveAttribute(TEST_CUSTOM_NAME);
    }

    public const string BUTTON_REMOVE_ATTRIBUTE_NS = "htmlelement-inprocess-remove-attribute-ns";
    private void RemoveAttributeNS() {
        HTMLElement.RemoveAttributeNS("", TEST_CUSTOM_NAME);
    }

    public const string BUTTON_HAS_ATTRIBUTE = "htmlelement-inprocess-has-attribute";
    private void HasAttribute() {
        bool hasAttribute = HTMLElement.HasAttribute("data-testid");
        labelOutput = hasAttribute.ToString();
    }

    public const string BUTTON_HAS_ATTRIBUTE_NS = "htmlelement-inprocess-has-attribute-ns";
    private void HasAttributeNS() {
        bool hasAttribute = HTMLElement.HasAttributeNS("", "data-testid");
        labelOutput = hasAttribute.ToString();
    }

    public const string BUTTON_HAS_ATTRIBUTES = "htmlelement-inprocess-has-attributes";
    private void HasAttributes() {
        bool hasAttributes = HTMLElement.HasAttributes();
        labelOutput = hasAttributes.ToString();
    }


    // methods - Tree-nodes

    public const string BUTTON_GET_ELEMENTS_BY_CLASS_NAME = "htmlelement-inprocess-get-elements-by-class-name";
    private void GetElementsByClassName() {
        IHTMLElementInProcess[] elements = HTMLElement.GetElementsByClassName(TEST_CUSTOM_NAME);
        labelOutput = elements.Length.ToString();

        elements.Dispose();
    }

    public const string BUTTON_GET_ELEMENTS_BY_TAG_NAME = "htmlelement-inprocess-get-elements-by-tag-name";
    private void GetElementsByTagName() {
        IHTMLElementInProcess[] elements = HTMLElement.GetElementsByTagName("b");
        labelOutput = elements.Length.ToString();

        elements.Dispose();
    }

    public const string BUTTON_GET_ELEMENTS_BY_TAG_NAME_NS = "htmlelement-inprocess-get-elements-by-tag-name-ns";
    private void GetElementsByTagNameNS() {
        IHTMLElementInProcess[] elements = HTMLElement.GetElementsByTagNameNS("http://www.w3.org/1999/xhtml", "b");
        labelOutput = elements.Length.ToString();

        elements.Dispose();
    }

    public const string BUTTON_QUERY_SELECTOR = "htmlelement-inprocess-query-selector";
    private void QuerySelector() {
        using IHTMLElementInProcess? element = HTMLElement.QuerySelector("b");
        labelOutput = (element is not null).ToString();
    }

    public const string BUTTON_QUERY_SELECTOR_ALL = "htmlelement-inprocess-query-selector-all";
    private void QuerySelectorAll() {
        IHTMLElementInProcess[] elements = HTMLElement.QuerySelectorAll("b");
        labelOutput = elements.Length.ToString();

        elements.Dispose();
    }

    public const string BUTTON_CLOSEST = "htmlelement-inprocess-closest";
    private void Closest() {
        using IHTMLElementInProcess? element = HTMLElement.Closest(".group");
        labelOutput = (element is not null).ToString();
    }


    public const string BUTTON_BEFORE_STRING = "htmlelement-inprocess-before-string";
    private void Before_String() {
        HTMLElement.Before([TEST_CUSTOM_VALUE]);
    }

    public const string BUTTON_BEFORE_HTML_ELEMENT = "htmlelement-inprocess-before-html-element";
    private void Before_HtmlElement() {
        HTMLElement.Before([HiddenElement]);
    }

    public const string BUTTON_AFTER_STRING = "htmlelement-inprocess-after-string";
    private void After_String() {
        HTMLElement.After([TEST_CUSTOM_VALUE]);
    }

    public const string BUTTON_AFTER_HTML_ELEMENT = "htmlelement-inprocess-after-html-element";
    private void After_HtmlElement() {
        HTMLElement.After([HiddenElement]);
    }


    public const string BUTTON_PREPEND_STRING = "htmlelement-inprocess-prepend-string";
    private void Prepend_String() {
        HTMLElement.Prepend([TEST_CUSTOM_VALUE]);
    }

    public const string BUTTON_PREPEND_HTML_ELEMENT = "htmlelement-inprocess-prepend-html-element";
    private void Prepend_HtmlElement() {
        HTMLElement.Prepend([HiddenElement]);
    }

    public const string BUTTON_APPEND_CHILD = "htmlelement-inprocess-append-child";
    private void AppendChild() {
        HTMLElement.AppendChild(HiddenElement);
    }

    public const string BUTTON_APPEND_STRING = "htmlelement-inprocess-append-string";
    private void Append_String() {
        HTMLElement.Append([TEST_CUSTOM_VALUE]);
    }

    public const string BUTTON_APPEND_HTML_ELEMENT = "htmlelement-inprocess-append-html-element";
    private void Append_HtmlElement() {
        HTMLElement.Append([HiddenElement]);
    }

    public const string BUTTON_INSERT_ADJACENT_ELEMENT = "htmlelement-inprocess-insert-adjacent-element";
    private void InsertAdjacentElement() {
        bool success = HTMLElement.InsertAdjacentElement("afterbegin", HiddenElement);
        labelOutput = success.ToString();
    }

    public const string BUTTON_INSERT_ADJACENT_HTML = "htmlelement-inprocess-insert-adjacent-html";
    private void InsertAdjacentHTML() {
        HTMLElement.InsertAdjacentHTML("afterbegin", TEST_INSERT_HTML);
    }

    public const string BUTTON_INSERT_ADJACENT_TEXT = "htmlelement-inprocess-insert-adjacent-text";
    private void InsertAdjacentText() {
        HTMLElement.InsertAdjacentText("afterbegin", TEST_CUSTOM_VALUE);
    }


    public const string BUTTON_REMOVE_CHILD = "htmlelement-inprocess-remove-child";
    private void RemoveChild() {
        HTMLElement.RemoveChild(HiddenElement);
    }

    public const string BUTTON_REMOVE = "htmlelement-inprocess-remove";
    private void Remove() {
        HTMLElement.Remove();
    }

    public const string BUTTON_REPLACE_CHILD = "htmlelement-inprocess-replace-child";
    private void ReplaceChild() {
        HTMLElement.ReplaceChild(PopoverElement, HiddenElement);
    }

    public const string BUTTON_REPLACE_CHILD_INDEX = "htmlelement-inprocess-replace-child-index";
    private void ReplaceChild_Index() {
        HTMLElement.ReplaceChild(PopoverElement, 0);
    }

    public const string BUTTON_REPLACE_WITH_STRING = "htmlelement-inprocess-replace-with-string";
    private void ReplaceWith_String() {
        HTMLElement.ReplaceWith([TEST_CUSTOM_VALUE]);
    }

    public const string BUTTON_REPLACE_WITH_HTML_ELEMENT = "htmlelement-inprocess-replace-with-html-element";
    private void ReplaceWith_HtmlElement() {
        HTMLElement.ReplaceWith([HiddenElement]);
    }

    public const string BUTTON_REPLACE_CHILDREN_STRING = "htmlelement-inprocess-replace-children-string";
    private void ReplaceChildren_String() {
        HTMLElement.ReplaceChildren([TEST_CUSTOM_VALUE]);
    }

    public const string BUTTON_REPLACE_CHILDREN_HTML_ELEMENT = "htmlelement-inprocess-replace-children-html-element";
    private void ReplaceChildren_HtmlElement() {
        HTMLElement.ReplaceChildren([HiddenElement]);
    }


    public const string BUTTON_CLONE_NODE = "htmlelement-inprocess-clone-node";
    private void CloneNode() {
        using IHTMLElementInProcess clonedElement = HTMLElement.CloneNode();
        labelOutput = (clonedElement is not null).ToString();
    }

    public const string BUTTON_IS_SAME_NODE = "htmlelement-inprocess-is-same-node";
    private void IsSameNode() {
        bool isSameNode = HTMLElement.IsSameNode(HTMLElement);
        labelOutput = isSameNode.ToString();
    }

    public const string BUTTON_IS_EQUAL_NODE = "htmlelement-inprocess-is-equal-node";
    private void IsEqualNode() {
        bool isEqualNode = HTMLElement.IsEqualNode(HTMLElement);
        labelOutput = isEqualNode.ToString();
    }

    public const string BUTTON_CONTAINS = "htmlelement-inprocess-contains";
    private void Contains() {
        bool contains = HTMLElement.Contains(HiddenElement);
        labelOutput = contains.ToString();
    }

    public const string BUTTON_COMPARE_DOCUMENT_POSITION = "htmlelement-inprocess-compare-document-position";
    private void CompareDocumentPosition() {
        int comparison = HTMLElement.CompareDocumentPosition(HiddenElement);
        labelOutput = comparison.ToString();
    }


    // events

    public const string BUTTON_REGISTER_ON_INPUT = "htmlelement-inprocess-input-event";
    private void RegisterOnInput() {
        IHTMLElementInProcess? tempElement = HTMLElement.NextElementSibling;
        if (tempElement is null)
            return;

        tempElement.OnInput += OnInput;

        void OnInput(string? data, string? inputType, bool isComposing) {
            labelOutput = $"data={data ?? "(null)"}, inputType={inputType ?? "(null)"}, isComposing={isComposing}";
            StateHasChanged();
            tempElement.OnInput -= OnInput;
            tempElement.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_BEFORE_INPUT = "htmlelement-inprocess-before-input-event";
    private void RegisterOnBeforeInput() {
        IHTMLElementInProcess? tempElement = HTMLElement.NextElementSibling;
        if (tempElement is null)
            return;

        tempElement.OnBeforeInput += OnBeforeInput;

        void OnBeforeInput(string? data, string? inputType, bool isComposing) {
            labelOutput = $"data={data ?? "(null)"}, inputType={inputType ?? "(null)"}, isComposing={isComposing}";
            StateHasChanged();
            tempElement.OnBeforeInput -= OnBeforeInput;
            tempElement.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_CONTENT_VISIBILITY_AUTO_STATE_CHANGE = "htmlelement-inprocess-content-visibility-auto-state-change-event";
    private void RegisterOnContentVisibilityAutoStateChange() {
        HTMLElement.OnContentVisibilityAutoStateChange += (bool skipped) => {
            labelOutput = $"skipped={skipped}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_MATCH = "htmlelement-inprocess-before-match-event";
    private void RegisterOnBeforeMatch() {
        HTMLElement.OnBeforeMatch += () => {
            labelOutput = TEST_EVENT_BEFORE_MATCH;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SECURITY_POLICY_VIOLATION = "htmlelement-inprocess-security-policy-violation-event";
    private void RegisterOnSecurityPolicyViolation() {
        HTMLElement.OnSecurityPolicyViolation += (SecurityPolicyViolationEvent securityPolicyViolationEvent) => {
            labelOutput = securityPolicyViolationEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SELECT_START = "htmlelement-inprocess-select-start-event";
    private void RegisterOnSelectStart() {
        HTMLElement.OnSelectStart += () => {
            labelOutput = TEST_EVENT_SELECT_START;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_KEY_DOWN = "htmlelement-inprocess-key-down-event";
    private void RegisterOnKeyDown() {
        IHTMLElementInProcess? tempElement = HTMLElement.NextElementSibling;
        if (tempElement is null)
            return;

        tempElement.OnKeyDown += OnKeyDown;

        void OnKeyDown(KeyboardEvent keyboardEvent) {
            labelOutput = keyboardEvent.ToString();
            StateHasChanged();
            tempElement.OnKeyDown -= OnKeyDown;
            tempElement.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_KEY_UP = "htmlelement-inprocess-key-up-event";
    private void RegisterOnKeyUp() {
        IHTMLElementInProcess? tempElement = HTMLElement.NextElementSibling;
        if (tempElement is null)
            return;

        tempElement.OnKeyUp += OnKeyUp;

        void OnKeyUp(KeyboardEvent keyboardEvent) {
            labelOutput = keyboardEvent.ToString();
            StateHasChanged();
            tempElement.OnKeyUp -= OnKeyUp;
            tempElement.Dispose();
        }
    }


    public const string BUTTON_REGISTER_ON_CLICK = "htmlelement-inprocess-click-event";
    private void RegisterOnClick() {
        HiddenElement.OnClick += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DBL_CLICK = "htmlelement-inprocess-dbl-click-event";
    private void RegisterOnDblClick() {
        HiddenElement.OnDblClick += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_AUX_CLICK = "htmlelement-inprocess-aux-click-event";
    private void RegisterOnAuxClick() {
        HiddenElement.OnAuxClick += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CONTEXT_MENU = "htmlelement-inprocess-context-menu-event";
    private void RegisterOnContextMenu() {
        HiddenElement.OnContextMenu += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_DOWN = "htmlelement-inprocess-mouse-down-event";
    private void RegisterOnMouseDown() {
        HiddenElement.OnMouseDown += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_UP = "htmlelement-inprocess-mouse-up-event";
    private void RegisterOnMouseUp() {
        HiddenElement.OnMouseUp += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_WHEEL = "htmlelement-inprocess-wheel-event";
    private void RegisterOnWheel() {
        HiddenElement.OnWheel += (WheelEvent wheelEvent) => {
            labelOutput = wheelEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_MOVE = "htmlelement-inprocess-mouse-move-event";
    private void RegisterOnMouseMove() {
        HiddenElement.OnMouseMove += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_OVER = "htmlelement-inprocess-mouse-over-event";
    private void RegisterOnMouseOver() {
        HiddenElement.OnMouseOver += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_OUT = "htmlelement-inprocess-mouse-out-event";
    private void RegisterOnMouseOut() {
        HiddenElement.OnMouseOut += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_ENTER = "htmlelement-inprocess-mouse-enter-event";
    private void RegisterOnMouseEnter() {
        HiddenElement.OnMouseEnter += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_LEAVE = "htmlelement-inprocess-mouse-leave-event";
    private void RegisterOnMouseLeave() {
        HiddenElement.OnMouseLeave += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_TOUCH_START = "htmlelement-inprocess-touch-start-event";
    private void RegisterOnTouchStart() {
        HiddenElement.OnTouchStart += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_END = "htmlelement-inprocess-touch-end-event";
    private void RegisterOnTouchEnd() {
        HiddenElement.OnTouchEnd += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_MOVE = "htmlelement-inprocess-touch-move-event";
    private void RegisterOnTouchMove() {
        HiddenElement.OnTouchMove += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_CANCEL = "htmlelement-inprocess-touch-cancel-event";
    private void RegisterOnTouchCancel() {
        HiddenElement.OnTouchCancel += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_POINTER_DOWN = "htmlelement-inprocess-pointer-down-event";
    private void RegisterOnPointerDown() {
        HiddenElement.OnPointerDown += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_UP = "htmlelement-inprocess-pointer-up-event";
    private void RegisterOnPointerUp() {
        HiddenElement.OnPointerUp += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_MOVE = "htmlelement-inprocess-pointer-move-event";
    private void RegisterOnPointerMove() {
        HiddenElement.OnPointerMove += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_OVER = "htmlelement-inprocess-pointer-over-event";
    private void RegisterOnPointerOver() {
        HiddenElement.OnPointerOver += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_OUT = "htmlelement-inprocess-pointer-out-event";
    private void RegisterOnPointerOut() {
        HiddenElement.OnPointerOut += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_ENTER = "htmlelement-inprocess-pointer-enter-event";
    private void RegisterOnPointerEnter() {
        HiddenElement.OnPointerEnter += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_LEAVE = "htmlelement-inprocess-pointer-leave-event";
    private void RegisterOnPointerLeave() {
        HiddenElement.OnPointerLeave += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_CANCEL = "htmlelement-inprocess-pointer-cancel-event";
    private void RegisterOnPointerCancel() {
        HiddenElement.OnPointerCancel += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_RAW_UPDATE = "htmlelement-inprocess-pointer-raw-update-event";
    private void RegisterOnPointerRawUpdate() {
        HiddenElement.OnPointerRawUpdate += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_GOT_POINTER_CAPTURE = "htmlelement-inprocess-got-pointer-capture-event";
    private void RegisterOnGotPointerCapture() {
        HiddenElement.OnGotPointerCapture += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOST_POINTER_CAPTURE = "htmlelement-inprocess-lost-pointer-capture-event";
    private void RegisterOnLostPointerCapture() {
        HiddenElement.OnLostPointerCapture += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_SCROLL = "htmlelement-inprocess-scroll-event";
    private void RegisterOnScroll() {
        HTMLElement.OnScroll += () => {
            labelOutput = TEST_EVENT_SCROLL_START;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SCROLL_END = "htmlelement-inprocess-scroll-end-event";
    private void RegisterOnScrollEnd() {
        HTMLElement.OnScrollEnd += () => {
            labelOutput = TEST_EVENT_SCROLL_END;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_FOCUS = "htmlelement-inprocess-focus-event";
    private void RegisterOnFocus() {
        HTMLElement.OnFocus += () => {
            labelOutput = TEST_EVENT_FOCUS;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_FOCUS_IN = "htmlelement-inprocess-focus-in-event";
    private void RegisterOnFocusIn() {
        HTMLElement.OnFocusIn += () => {
            labelOutput = TEST_EVENT_FOCUS_IN;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BLUR = "htmlelement-inprocess-blur-event";
    private void RegisterOnBlur() {
        HTMLElement.OnBlur += () => {
            labelOutput = TEST_EVENT_BLUR;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_FOCUS_OUT = "htmlelement-inprocess-focus-out-event";
    private void RegisterOnFocusOut() {
        HTMLElement.OnFocusOut += () => {
            labelOutput = TEST_EVENT_FOCUS_OUT;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_COPY = "htmlelement-inprocess-copy-event";
    private void RegisterOnCopy() {
        HTMLElement.OnCopy += () => {
            labelOutput = TEST_EVENT_COPY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PASTE = "htmlelement-inprocess-paste-event";
    private void RegisterOnPaste() {
        HTMLElement.OnPaste += () => {
            labelOutput = TEST_EVENT_PASTE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CUT = "htmlelement-inprocess-cut-event";
    private void RegisterOnCut() {
        HTMLElement.OnCut += () => {
            labelOutput = TEST_EVENT_CUT;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_TRANSITION_START = "htmlelement-inprocess-transition-start-event";
    private void RegisterOnTransitionStart() {
        HTMLElement.OnTransitionStart += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_START}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_END = "htmlelement-inprocess-transition-end-event";
    private void RegisterOnTransitionEnd() {
        HTMLElement.OnTransitionEnd += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_END}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_RUN = "htmlelement-inprocess-transition-run-event";
    private void RegisterOnTransitionRun() {
        HTMLElement.OnTransitionRun += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_RUN}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_CANCEL = "htmlelement-inprocess-transition-cancel-event";
    private void RegisterOnTransitionCancel() {
        HTMLElement.OnTransitionCancel += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_CANCEL}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_ANIMATION_START = "htmlelement-inprocess-animation-start-event";
    private void RegisterOnAnimationStart() {
        HTMLElement.OnAnimationStart += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_START}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_END = "htmlelement-inprocess-animation-end-event";
    private void RegisterOnAnimationEnd() {
        HTMLElement.OnAnimationEnd += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_END}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_ITERATION = "htmlelement-inprocess-animation-iteration-event";
    private void RegisterOnAnimationIteration() {
        HTMLElement.OnAnimationIteration += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_ITERATION}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_CANCEL = "htmlelement-inprocess-animation-cancel-event";
    private void RegisterOnAnimationCancel() {
        HTMLElement.OnAnimationCancel += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_CANCEL}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_FULLSCREEN_CHANGE = "htmlelement-inprocess-fullscreen-change-event";
    private void RegisterOnFullscreenChange() {
        HTMLElement.OnFullscreenChange += () => {
            labelOutput = TEST_EVENT_FULLSCREEN_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_FULLSCREEN_ERROR = "htmlelement-inprocess-fullscreen-error-event";
    private void RegisterOnFullscreenError() {
        HTMLElement.OnFullscreenError += () => {
            labelOutput = TEST_EVENT_FULLSCREEN_ERROR;
            StateHasChanged();
        };
    }

    #endregion
}
