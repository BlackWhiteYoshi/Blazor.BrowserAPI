using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Data;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class HTMLElementGroup : ComponentBase, IAsyncDisposable {
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
    public const string TEST_TRANSITIONSTART_EVENT = "transitionstart-event-test";
    public const string TEST_TRANSITIONEND_EVENT = "transitionend-event-test";
    public const string TEST_TRANSITIONRUN_EVENT = "transitionrun-event-test";
    public const string TEST_TRANSITIONCANCEL_EVENT = "transitioncancel-event-test";
    public const string TEST_ANIMATIONSTART_EVENT = "animationstart-event-test";
    public const string TEST_ANIMATIONEND_EVENT = "animationend-event-test";
    public const string TEST_ANIMATIONITERATION_EVENT = "animationiteration-event-test";
    public const string TEST_ANIMATIONCANCEL_EVENT = "animationcancel-event-test";


    [Inject]
    public required IElementFactory ElementFactory { private get; init; }


    private IHTMLElement? _htmlElement;
    private IHTMLElement HTMLElement => _htmlElement ??= ElementFactory.CreateHTMLElement(htmlElement);


    private IHTMLElement? _popoverElement;
    private IHTMLElement PopoverElement => _popoverElement ??= ElementFactory.CreateHTMLElement(popoverElement);

    private IHTMLElement? _hiddenElement;
    private IHTMLElement HiddenElement => _hiddenElement ??= ElementFactory.CreateHTMLElement(hiddenElement);


    public const string LABEL_OUTPUT = "htmlelement-output";
    private string labelOutput = string.Empty;

    public const string HTML_ELEMENT_CONTAINER = "htmlelement-html-element-container";
    public const string HTML_ELEMENT = "htmlelement-html-element";
    private ElementReference htmlElement;

    public const string POPOVER_ELEMENT = "htmlelement-popover-element";
    private ElementReference popoverElement;

    public const string HIDDEN_ELEMENT = "htmlelement-hidden-element";
    private ElementReference hiddenElement;

    public async ValueTask DisposeAsync() {
        ValueTask htmlDisposing = _htmlElement?.DisposeAsync() ?? ValueTask.CompletedTask;
        ValueTask popoverDisposing = _popoverElement?.DisposeAsync() ?? ValueTask.CompletedTask;
        ValueTask hiddenDisposing = _hiddenElement?.DisposeAsync() ?? ValueTask.CompletedTask;

        await htmlDisposing;
        await popoverDisposing;
        await hiddenDisposing;
    }


    #region HTMLElement

    public const string BUTTON_GET_ACCESS_KEY_PROPERTY = "htmlelement-get-access-key-property";
    public async Task GetAccessKey_Property() {
        string accessKey = await HTMLElement.AccessKey;
        labelOutput = accessKey;
    }

    public const string BUTTON_GET_ACCESS_KEY_METHOD = "htmlelement-get-access-key-method";
    public async Task GetAccessKey_Method() {
        string accessKey = await HTMLElement.GetAccessKey(default);
        labelOutput = accessKey;
    }

    public const string BUTTON_SET_ACCESS_KEY = "htmlelement-set-access-key";
    private async Task SetAccessKey() {
        await HTMLElement.SetAccessKey(TEST_ACCESS_KEY);
    }


    public const string BUTTON_GET_ACCESS_KEY_LABEL_PROPERTY = "htmlelement-get-access-key-label-property";
    public async Task GetAccessKeyLabel_Property() {
        string accessKeyLabel = await HTMLElement.AccessKeyLabel;
        labelOutput = accessKeyLabel;
    }

    public const string BUTTON_GET_ACCESS_KEY_LABEL_METHOD = "htmlelement-get-access-key-label-method";
    public async Task GetAccessKeyLabel_Method() {
        string accessKeyLabel = await HTMLElement.GetAccessKeyLabel(default);
        labelOutput = accessKeyLabel;
    }


    public const string BUTTON_GET_ATTRIBUTE_STYLE_MAP_PROPERTY = "htmlelement-get-attribute-style-map-property";
    public async Task GetAttributeStyleMap_Property() {
        Dictionary<string, string> attributeStyleMap = await HTMLElement.AttributeStyleMap;
        labelOutput = string.Join(", ", attributeStyleMap.Select(pair => $"{pair.Key} = {pair.Value}"));
    }

    public const string BUTTON_GET_ATTRIBUTE_STYLE_MAP_METHOD = "htmlelement-get-attribute-style-map-method";
    public async Task GetAttributeStyleMap_Method() {
        Dictionary<string, string> attributeStyleMap = await HTMLElement.GetAttributeStyleMap(default);
        labelOutput = string.Join(", ", attributeStyleMap.Select(pair => $"{pair.Key} = {pair.Value}"));
    }

    public const string BUTTON_SET_ATTRIBUTE_STYLE_MAP = "htmlelement-set-attribute-style-map";
    public async Task SetAttributeStyleMap() {
        await HTMLElement.SetAttributeStyleMap(TEST_STYLE_NAME, TEST_STYLE_VALUE);
    }

    public const string BUTTON_REMOVE_ATTRIBUTE_STYLE_MAP = "htmlelement-remove-attribute-style-map";
    public async Task RemoveAttributeStyleMap() {
        await HTMLElement.RemoveAttributeStyleMap(TEST_STYLE_NAME);
    }


    public const string BUTTON_GET_AUTOCAPITALIZE_PROPERTY = "htmlelement-get-autocapitalize-property";
    public async Task GetAutocapitalize_Property() {
        string autocapitalize = await HTMLElement.Autocapitalize;
        labelOutput = autocapitalize;
    }

    public const string BUTTON_GET_AUTOCAPITALIZE_METHOD = "htmlelement-get-autocapitalize-method";
    public async Task GetAutocapitalize_Method() {
        string autocapitalize = await HTMLElement.GetAutocapitalize(default);
        labelOutput = autocapitalize;
    }

    public const string BUTTON_SET_AUTOCAPITALIZE = "htmlelement-set-autocapitalize";
    private async Task SetAutocapitalize() {
        await HTMLElement.SetAutocapitalize(TEST_AUTOCAPITALIZE);
    }


    public const string BUTTON_GET_AUTOFOCUS_PROPERTY = "htmlelement-get-autofocus-property";
    public async Task GetAutofocus_Property() {
        bool autofocus = await HTMLElement.Autofocus;
        labelOutput = autofocus.ToString();
    }

    public const string BUTTON_GET_AUTOFOCUS_METHOD = "htmlelement-get-autofocus-method";
    public async Task GetAutofocus_Method() {
        bool autofocus = await HTMLElement.GetAutofocus(default);
        labelOutput = autofocus.ToString();
    }

    public const string BUTTON_SET_AUTOFOCUS = "htmlelement-set-autofocus";
    private async Task SetAutofocus() {
        await HTMLElement.SetAutofocus(true);
    }


    public const string BUTTON_GET_CONTENT_EDITABLE_PROPERTY = "htmlelement-get-content-editable-property";
    public async Task GetContentEditable_Property() {
        string contentEditable = await HTMLElement.ContentEditable;
        labelOutput = contentEditable;
    }

    public const string BUTTON_GET_CONTENT_EDITABLE_METHOD = "htmlelement-get-content-editable-method";
    public async Task GetContentEditable_Method() {
        string contentEditable = await HTMLElement.GetContentEditable(default);
        labelOutput = contentEditable;
    }

    public const string BUTTON_SET_CONTENT_EDITABLE = "htmlelement-set-content-editable";
    private async Task SetContentEditable() {
        await HTMLElement.SetContentEditable("true");
    }


    public const string BUTTON_GET_DATASET_PROPERTY = "htmlelement-get-dataset-property";
    public async Task GetDataset_Property() {
        Dictionary<string, string> dataset = await HTMLElement.Dataset;
        labelOutput = string.Join(", ", dataset.Select(pair => $"{pair.Key} = {pair.Value}"));
    }

    public const string BUTTON_GET_DATASET_METHOD = "htmlelement-get-dataset-method";
    public async Task GetDataset_Method() {
        Dictionary<string, string> dataset = await HTMLElement.GetDataset(default);
        labelOutput = string.Join(", ", dataset.Select(pair => $"{pair.Key} = {pair.Value}"));
    }

    public const string BUTTON_SET_DATASET = "htmlelement-set-dataset";
    public async Task SetDataset() {
        await HTMLElement.SetDataset(TEST_DATASET_NAME, TEST_DATASET_VALUE);
    }

    public const string BUTTON_REMOVE_DATASET = "htmlelement-remove-dataset";
    public async Task RemoveDataset() {
        await HTMLElement.RemoveDataset(TEST_DATASET_NAME);
    }


    public const string BUTTON_GET_DIR_PROPERTY = "htmlelement-get-dir-property";
    public async Task GetDir_Property() {
        string dir = await HTMLElement.Dir;
        labelOutput = dir;
    }

    public const string BUTTON_GET_DIR_METHOD = "htmlelement-get-dir-method";
    public async Task GetDir_Method() {
        string dir = await HTMLElement.GetDir(default);
        labelOutput = dir;
    }

    public const string BUTTON_SET_DIR = "htmlelement-set-dir";
    private async Task SetDir() {
        await HTMLElement.SetDir(TEST_DIR);
    }


    public const string BUTTON_GET_DRAGGABLE_PROPERTY = "htmlelement-get-draggable-property";
    public async Task GetDraggable_Property() {
        bool draggable = await HTMLElement.Draggable;
        labelOutput = draggable.ToString();
    }

    public const string BUTTON_GET_DRAGGABLE_METHOD = "htmlelement-get-draggable-method";
    public async Task GetDraggable_Method() {
        bool draggable = await HTMLElement.GetDraggable(default);
        labelOutput = draggable.ToString();
    }

    public const string BUTTON_SET_DRAGGABLE = "htmlelement-set-draggable";
    private async Task SetDraggable() {
        await HTMLElement.SetDraggable(true);
    }


    public const string BUTTON_GET_ENTER_KEY_HINT_PROPERTY = "htmlelement-get-enter-key-hint-property";
    public async Task GetEnterKeyHint_Property() {
        string enterKeyHint = await HTMLElement.EnterKeyHint;
        labelOutput = enterKeyHint;
    }

    public const string BUTTON_GET_ENTER_KEY_HINT_METHOD = "htmlelement-get-enter-key-hint-method";
    public async Task GetEnterKeyHint_Method() {
        string enterKeyHint = await HTMLElement.GetEnterKeyHint(default);
        labelOutput = enterKeyHint;
    }

    public const string BUTTON_SET_ENTER_KEY_HINT = "htmlelement-set-enter-key-hint";
    private async Task SetEnterKeyHint() {
        await HTMLElement.SetEnterKeyHint(TEST_ENTER_KEY_HINT);
    }


    public const string BUTTON_GET_HIDDEN_PROPERTY = "htmlelement-get-hidden-property";
    public async Task GetHidden_Property() {
        bool hidden = await HTMLElement.Hidden;
        labelOutput = hidden.ToString();
    }

    public const string BUTTON_GET_HIDDEN_METHOD = "htmlelement-get-hidden-method";
    public async Task GetHidden_Method() {
        bool hidden = await HTMLElement.GetHidden(default);
        labelOutput = hidden.ToString();
    }

    public const string BUTTON_SET_HIDDEN = "htmlelement-set-hidden";
    private async Task SetHidden() {
        await HTMLElement.SetHidden(true);
    }


    public const string BUTTON_GET_INERT_PROPERTY = "htmlelement-get-inert-property";
    public async Task GetInert_Property() {
        bool inert = await HTMLElement.Inert;
        labelOutput = inert.ToString();
    }

    public const string BUTTON_GET_INERT_METHOD = "htmlelement-get-inert-method";
    public async Task GetInert_Method() {
        bool inert = await HTMLElement.GetInert(default);
        labelOutput = inert.ToString();
    }

    public const string BUTTON_SET_INERT = "htmlelement-set-inert";
    private async Task SetInert() {
        await HTMLElement.SetInert(true);
    }


    public const string BUTTON_GET_INNERTEXT_PROPERTY = "htmlelement-get-innertext-property";
    private async Task GetInnerText_Property() {
        string innerText = await HTMLElement.InnerText;
        labelOutput = innerText;
    }

    public const string BUTTON_GET_INNERTEXT_METHOD = "htmlelement-get-innertext-method";
    private async Task GetInnerText_Method() {
        string innerText = await HTMLElement.GetInnerText(default);
        labelOutput = innerText;
    }

    public const string BUTTON_SET_INNERTEXT = "htmlelement-set-innertext";
    private async Task SetInnerText() {
        await HTMLElement.SetInnerText(TEST_INNERTEXT);
    }


    public const string BUTTON_GET_INPUT_MODE_PROPERTY = "htmlelement-get-input-mode-property";
    public async Task GetInputMode_Property() {
        string inputMode = await HTMLElement.InputMode;
        labelOutput = inputMode;
    }

    public const string BUTTON_GET_INPUT_MODE_METHOD = "htmlelement-get-input-mode-method";
    public async Task GetInputMode_Method() {
        string inputMode = await HTMLElement.GetInputMode(default);
        labelOutput = inputMode;
    }

    public const string BUTTON_SET_INPUT_MODE = "htmlelement-set-input-mode";
    private async Task SetInputMode() {
        await HTMLElement.SetInputMode(TEST_INPUT_MODE);
    }


    public const string BUTTON_GET_IS_CONTENT_EDITABLE_PROPERTY = "htmlelement-get-is-content-editable-property";
    public async Task GetIsContentEditable_Property() {
        bool isContentEditable = await HTMLElement.IsContentEditable;
        labelOutput = isContentEditable.ToString();
    }

    public const string BUTTON_GET_IS_CONTENT_EDITABLE_METHOD = "htmlelement-get-is-content-editable-method";
    public async Task GetIsContentEditable_Method() {
        bool isContentEditable = await HTMLElement.GetIsContentEditable(default);
        labelOutput = isContentEditable.ToString();
    }


    public const string BUTTON_GET_LANG_PROPERTY = "htmlelement-get-lang-property";
    public async Task GetLang_Property() {
        string lang = await HTMLElement.Lang;
        labelOutput = lang;
    }

    public const string BUTTON_GET_LANG_METHOD = "htmlelement-get-lang-method";
    public async Task GetLang_Method() {
        string lang = await HTMLElement.GetLang(default);
        labelOutput = lang;
    }

    public const string BUTTON_SET_LANG = "htmlelement-set-lang";
    private async Task SetLang() {
        await HTMLElement.SetLang(TEST_LANG);
    }


    public const string BUTTON_GET_NONCE_PROPERTY = "htmlelement-get-nonce-property";
    public async Task GetNonce_Property() {
        string nonce = await HTMLElement.Nonce;
        labelOutput = nonce;
    }

    public const string BUTTON_GET_NONCE_METHOD = "htmlelement-get-nonce-method";
    public async Task GetNonce_Method() {
        string nonce = await HTMLElement.GetNonce(default);
        labelOutput = nonce;
    }

    public const string BUTTON_SET_NONCE = "htmlelement-set-nonce";
    private async Task SetNonce() {
        await HTMLElement.SetNonce(TEST_NONCE);
    }


    public const string BUTTON_GET_OFFSETWIDTH_PROPERTY = "htmlelement-get-offsetwidth-property";
    private async Task GetOffsetWidth_Property() {
        int offsetWidth = await HTMLElement.OffsetWidth;
        labelOutput = offsetWidth.ToString();
    }

    public const string BUTTON_GET_OFFSETWIDTH_METHOD = "htmlelement-get-offsetwidth-method";
    private async Task GetOffsetWidth_Method() {
        int offsetWidth = await HTMLElement.GetOffsetWidth(default);
        labelOutput = offsetWidth.ToString();
    }

    public const string BUTTON_GET_OFFSETHEIGHT_PROPERTY = "htmlelement-get-offsetheight-property";
    private async Task GetOffsetHeight_Property() {
        int offsetHeight = await HTMLElement.OffsetHeight;
        labelOutput = offsetHeight.ToString();
    }

    public const string BUTTON_GET_OFFSETHEIGHT_METHOD = "htmlelement-get-offsetheight-method";
    private async Task GetOffsetHeight_Method() {
        int offsetHeight = await HTMLElement.GetOffsetHeight(default);
        labelOutput = offsetHeight.ToString();
    }

    public const string BUTTON_GET_OFFSETLEFT_PROPERTY = "htmlelement-get-offsetleft-property";
    private async Task GetOffsetLeft_Property() {
        int offsetLeft = await HTMLElement.OffsetLeft;
        labelOutput = offsetLeft.ToString();
    }

    public const string BUTTON_GET_OFFSETLEFT_METHOD = "htmlelement-get-offsetleft-method";
    private async Task GetOffsetLeft_Method() {
        int offsetLeft = await HTMLElement.GetOffsetLeft(default);
        labelOutput = offsetLeft.ToString();
    }

    public const string BUTTON_GET_OFFSETTOP_PROPERTY = "htmlelement-get-offsettop-property";
    private async Task GetOffsetTop_Property() {
        int offsetTop = await HTMLElement.OffsetTop;
        labelOutput = offsetTop.ToString();
    }

    public const string BUTTON_GET_OFFSETTOP_METHOD = "htmlelement-get-offsettop-method";
    private async Task GetOffsetTop_Method() {
        int offsetTop = await HTMLElement.GetOffsetTop(default);
        labelOutput = offsetTop.ToString();
    }

    public const string BUTTON_GET_OFFSETPARENT_PROPERTY = "htmlelement-get-offsetparent-property";
    private async Task GetOffsetParent_Property() {
        await using IHTMLElement? offsetParent = await HTMLElement.OffsetParent;
        labelOutput = (offsetParent is not null).ToString();
    }

    public const string BUTTON_GET_OFFSETPARENT_METHOD = "htmlelement-get-offsetparent-method";
    private async Task GetOffsetParent_Method() {
        await using IHTMLElement? offsetParent = await HTMLElement.GetOffsetParent(default);
        labelOutput = (offsetParent is not null).ToString();
    }


    public const string BUTTON_GET_OUTERTEXT_PROPERTY = "htmlelement-get-outertext-property";
    private async Task GetOuterText_Property() {
        string outerText = await HTMLElement.OuterText;
        labelOutput = outerText;
    }

    public const string BUTTON_GET_OUTERTEXT_METHOD = "htmlelement-get-outertext-method";
    private async Task GetOuterText_Method() {
        string outerText = await HTMLElement.GetOuterText(default);
        labelOutput = outerText;
    }

    public const string BUTTON_SET_OUTERTEXT = "htmlelement-set-outertext";
    private async Task SetOuterText() {
        await HTMLElement.SetOuterText(TEST_OUTERTEXT);
    }


    public const string BUTTON_GET_POPOVER_PROPERTY = "htmlelement-get-popover-property";
    public async Task GetPopover_Property() {
        string? popover = await HTMLElement.Popover;
        labelOutput = popover ?? "(empty)";
    }

    public const string BUTTON_GET_POPOVER_METHOD = "htmlelement-get-popover-method";
    public async Task GetPopover_Method() {
        string? popover = await HTMLElement.GetPopover(default);
        labelOutput = popover ?? "(empty)";
    }

    public const string BUTTON_SET_POPOVER = "htmlelement-set-popover";
    private async Task SetPopover() {
        await HTMLElement.SetPopover(TEST_POPOVER);
    }


    public const string BUTTON_GET_SPELLCHECK_PROPERTY = "htmlelement-get-spellcheck-property";
    public async Task GetSpellcheck_Property() {
        bool spellcheck = await HTMLElement.Spellcheck;
        labelOutput = spellcheck.ToString();
    }

    public const string BUTTON_GET_SPELLCHECK_METHOD = "htmlelement-get-spellcheck-method";
    public async Task GetSpellcheck_Method() {
        bool spellcheck = await HTMLElement.GetSpellcheck(default);
        labelOutput = spellcheck.ToString();
    }

    public const string BUTTON_SET_SPELLCHECK = "htmlelement-set-spellcheck";
    private async Task SetSpellcheck() {
        await HTMLElement.SetSpellcheck(true);
    }


    public const string BUTTON_GET_STYLE_PROPERTY = "htmlelement-get-style-property";
    private async Task GetStyle_Property() {
        string style = await HTMLElement.Style;
        labelOutput = style;
    }

    public const string BUTTON_GET_STYLE_METHOD = "htmlelement-get-style-method";
    private async Task GetStyle_Method() {
        string style = await HTMLElement.GetStyle(default);
        labelOutput = style;
    }

    public const string BUTTON_SET_STYLE = "htmlelement-set-style";
    private async Task SetStyle() {
        await HTMLElement.SetStyle(TEST_STYLE);
    }


    public const string BUTTON_GET_TAB_INDEX_PROPERTY = "htmlelement-get-tab-index-property";
    public async Task GetTabIndex_Property() {
        long tabIndex = await HTMLElement.TabIndex;
        labelOutput = tabIndex.ToString();
    }

    public const string BUTTON_GET_TAB_INDEX_METHOD = "htmlelement-get-tab-index-method";
    public async Task GetTabIndex_Method() {
        long tabIndex = await HTMLElement.GetTabIndex(default);
        labelOutput = tabIndex.ToString();
    }

    public const string BUTTON_SET_TAB_INDEX = "htmlelement-set-tab-index";
    private async Task SetTabIndex() {
        await HTMLElement.SetTabIndex(TEST_TAB_INDEX);
    }


    public const string BUTTON_GET_TITLE_PROPERTY = "htmlelement-get-title-property";
    public async Task GetTitle_Property() {
        string title = await HTMLElement.Title;
        labelOutput = title;
    }

    public const string BUTTON_GET_TITLE_METHOD = "htmlelement-get-title-method";
    public async Task GetTitle_Method() {
        string title = await HTMLElement.GetTitle(default);
        labelOutput = title;
    }

    public const string BUTTON_SET_TITLE = "htmlelement-set-title";
    private async Task SetTitle() {
        await HTMLElement.SetTitle(TEST_TITLE);
    }


    public const string BUTTON_GET_TRANSLATE_PROPERTY = "htmlelement-get-translate-property";
    public async Task GetTranslate_Property() {
        bool translate = await HTMLElement.Translate;
        labelOutput = translate.ToString();
    }

    public const string BUTTON_GET_TRANSLATE_METHOD = "htmlelement-get-translate-method";
    public async Task GetTranslate_Method() {
        bool translate = await HTMLElement.GetTranslate(default);
        labelOutput = translate.ToString();
    }

    public const string BUTTON_SET_TRANSLATE = "htmlelement-set-translate";
    private async Task SetTranslate() {
        await HTMLElement.SetTranslate(true);
    }


    // extra

    public const string BUTTON_GET_HASFOCUS_PROPERTY = "htmlelement-get-hasfocus-property";
    private async Task GetHasFocus_Property() {
        bool hasFocus = await HTMLElement.HasFocus;
        labelOutput = hasFocus.ToString();
    }

    public const string BUTTON_GET_HASFOCUS_METHOD = "htmlelement-get-hasfocus-method";
    private async Task GetHasFocus_Method() {
        bool hasFocus = await HTMLElement.GetHasFocus(default);
        labelOutput = hasFocus.ToString();
    }


    // methods

    public const string BUTTON_CLICK = "htmlelement-click";
    private async Task Click() {
        await HTMLElement.Click();
    }

    public const string BUTTON_FOCUS = "htmlelement-focus";
    private async Task Focus() {
        await HTMLElement.Focus(true);
        await HTMLElement.Focus(false);
        await HTMLElement.Focus();
    }

    public const string BUTTON_BLUR = "htmlelement-blur";
    private async Task Blur() {
        await HTMLElement.Blur();
    }

    public const string BUTTON_SHOW_POPOVER = "htmlelement-show-popover";
    private async Task ShowPopover() {
        await PopoverElement.ShowPopover();
    }

    public const string BUTTON_HIDE_POPOVER = "htmlelement-hide-popover";
    private async Task HidePopover() {
        await PopoverElement.HidePopover();
    }

    public const string BUTTON_TOGGLE_POPOVER = "htmlelement-toggle-popover";
    private async Task TogglePopover() {
        await PopoverElement.TogglePopover();
    }

    public const string BUTTON_TOGGLE_POPOVER_PARAMETER = "htmlelement-toggle-popover-parameter";
    private async Task TogglePopoverParameter() {
        await PopoverElement.TogglePopover(true);
        await PopoverElement.TogglePopover(false);
    }

    #endregion


    #region Node/Element


    public const string BUTTON_GET_ATTRIBUTES_PROPERTY = "htmlelement-get-attributes-property";
    private async Task GetAttributes_Property() {
        Dictionary<string, string> attributes = await HTMLElement.Attributes;
        labelOutput = JsonSerializer.Serialize(attributes);
    }

    public const string BUTTON_GET_ATTRIBUTES_METHOD = "htmlelement-get-attributes-method";
    private async Task GetAttributes_Method() {
        Dictionary<string, string> attributes = await HTMLElement.GetAttributes(default);
        labelOutput = JsonSerializer.Serialize(attributes);
    }


    public const string BUTTON_GET_CLASS_LIST_PROPERTY = "htmlelement-get-class-list-property";
    private async Task GetClassList_Property() {
        string[] classList = await HTMLElement.ClassList;
        labelOutput = string.Join(',', classList);
    }

    public const string BUTTON_GET_CLASS_LIST_METHOD = "htmlelement-get-class-list-method";
    private async Task GetClassList_Method() {
        string[] classList = await HTMLElement.GetClassList(default);
        labelOutput = string.Join(',', classList);
    }


    public const string BUTTON_GET_CLASS_NAME_PROPERTY = "htmlelement-get-class-name-property";
    private async Task GetClassName_Property() {
        string className = await HTMLElement.ClassName;
        labelOutput = className;
    }

    public const string BUTTON_GET_CLASS_NAME_METHOD = "htmlelement-get-class-name-method";
    private async Task GetClassName_Method() {
        string className = await HTMLElement.GetClassName(default);
        labelOutput = className;
    }

    public const string BUTTON_SET_CLASS_NAME = "htmlelement-set-class-name";
    private async Task SetClassName() {
        await HTMLElement.SetClassName(TEST_CLASSNAME);
    }


    public const string BUTTON_GET_CLIENT_WIDTH_PROPERTY = "htmlelement-get-client-width-property";
    private async Task GetClientWidth_Property() {
        int clientWidth = await HTMLElement.ClientWidth;
        labelOutput = clientWidth.ToString();
    }

    public const string BUTTON_GET_CLIENT_WIDTH_METHOD = "htmlelement-get-client-width-method";
    private async Task GetClientWidth_Method() {
        int clientWidth = await HTMLElement.GetClientWidth(default);
        labelOutput = clientWidth.ToString();
    }

    public const string BUTTON_GET_CLIENT_HEIGHT_PROPERTY = "htmlelement-get-client-height-property";
    private async Task GetClientHeight_Property() {
        int clientHeight = await HTMLElement.ClientHeight;
        labelOutput = clientHeight.ToString();
    }

    public const string BUTTON_GET_CLIENT_HEIGHT_METHOD = "htmlelement-get-client-height-method";
    private async Task GetClientHeight_Method() {
        int clientHeight = await HTMLElement.GetClientHeight(default);
        labelOutput = clientHeight.ToString();
    }

    public const string BUTTON_GET_CLIENT_LEFT_PROPERTY = "htmlelement-get-client-left-property";
    private async Task GetClientLeft_Property() {
        int clientLeft = await HTMLElement.ClientLeft;
        labelOutput = clientLeft.ToString();
    }

    public const string BUTTON_GET_CLIENT_LEFT_METHOD = "htmlelement-get-client-left-method";
    private async Task GetClientLeft_Method() {
        int clientLeft = await HTMLElement.GetClientLeft(default);
        labelOutput = clientLeft.ToString();
    }

    public const string BUTTON_GET_CLIENT_TOP_PROPERTY = "htmlelement-get-client-top-property";
    private async Task GetClientTop_Property() {
        int clientTop = await HTMLElement.ClientTop;
        labelOutput = clientTop.ToString();
    }

    public const string BUTTON_GET_CLIENT_TOP_METHOD = "htmlelement-get-client-top-method";
    private async Task GetClientTop_Method() {
        int clientTop = await HTMLElement.GetClientTop(default);
        labelOutput = clientTop.ToString();
    }


    public const string BUTTON_GET_CURRENT_CSS_ZOOM_PROPERTY = "htmlelement-get-current-css-zoom-property";
    private async Task GetCurrentCSSZoom_Property() {
        double currentCSSZoom = await HTMLElement.CurrentCSSZoom;
        labelOutput = currentCSSZoom.ToString();
    }

    public const string BUTTON_GET_CURRENT_CSS_ZOOM_METHOD = "htmlelement-get-current-css-zoom-method";
    private async Task GetCurrentCSSZoom_Method() {
        double currentCSSZoom = await HTMLElement.GetCurrentCSSZoom(default);
        labelOutput = currentCSSZoom.ToString();
    }


    public const string BUTTON_GET_ID_PROPERTY = "htmlelement-get-id-property";
    private async Task GetId_Property() {
        string id = await HTMLElement.Id;
        labelOutput = id;
    }

    public const string BUTTON_GET_ID_METHOD = "htmlelement-get-id-method";
    private async Task GetId_Method() {
        string id = await HTMLElement.GetId(default);
        labelOutput = id;
    }

    public const string BUTTON_SET_ID = "htmlelement-set-id";
    private async Task SetId() {
        await HTMLElement.SetId(TEST_ID);
    }


    public const string BUTTON_GET_IS_CONNECTED_PROPERTY = "htmlelement-get-is-connected-property";
    private async Task GetIsConnected_Property() {
        bool isConnected = await HTMLElement.IsConnected;
        labelOutput = isConnected.ToString();
    }

    public const string BUTTON_GET_IS_CONNECTED_METHOD = "htmlelement-get-is-connected-method";
    private async Task GetIsConnected_Method() {
        bool isConnected = await HTMLElement.GetIsConnected(default);
        labelOutput = isConnected.ToString();
    }


    public const string BUTTON_GET_INNER_HTML_PROPERTY = "htmlelement-get-inner-html-property";
    private async Task GetInnerHTML_Property() {
        string innerHTML = await HTMLElement.InnerHTML;
        labelOutput = innerHTML;
    }

    public const string BUTTON_GET_INNER_HTML_METHOD = "htmlelement-get-inner-html-method";
    private async Task GetInnerHTML_Method() {
        string innerHTML = await HTMLElement.GetInnerHTML(default);
        labelOutput = innerHTML;
    }

    public const string BUTTON_SET_INNER_HTML = "htmlelement-set-inner-html";
    private async Task SetInnerHTML() {
        await HTMLElement.SetInnerHTML(TEST_INNERHTML);
    }


    public const string BUTTON_GET_OUTER_HTML_PROPERTY = "htmlelement-get-outer-html-property";
    private async Task GetOuterHTML_Property() {
        string outerHTML = await HTMLElement.OuterHTML;
        labelOutput = outerHTML;
    }

    public const string BUTTON_GET_OUTER_HTML_METHOD = "htmlelement-get-outer-html-method";
    private async Task GetOuterHTML_Method() {
        string outerHTML = await HTMLElement.GetOuterHTML(default);
        labelOutput = outerHTML;
    }

    public const string BUTTON_SET_OUTER_HTML = "htmlelement-set-outer-html";
    private async Task SetOuterHTML() {
        await HTMLElement.SetOuterHTML(TEST_OUTERHTML);
    }


    public const string BUTTON_GET_PART_PROPERTY = "htmlelement-get-part-property";
    private async Task GetPart_Property() {
        string[] part = await HTMLElement.Part;
        labelOutput = string.Join(',', part);
    }

    public const string BUTTON_GET_PART_METHOD = "htmlelement-get-part-method";
    private async Task GetPart_Method() {
        string[] part = await HTMLElement.GetPart(default);
        labelOutput = string.Join(',', part);
    }


    public const string BUTTON_GET_SCROLL_WIDTH_PROPERTY = "htmlelement-get-scroll-width-property";
    private async Task GetScrollWidth_Property() {
        int ScrollWidth = await HTMLElement.ScrollWidth;
        labelOutput = ScrollWidth.ToString();
    }

    public const string BUTTON_GET_SCROLL_WIDTH_METHOD = "htmlelement-get-scroll-width-method";
    private async Task GetScrollWidth_Method() {
        int ScrollWidth = await HTMLElement.GetScrollWidth(default);
        labelOutput = ScrollWidth.ToString();
    }

    public const string BUTTON_GET_SCROLL_HEIGHT_PROPERTY = "htmlelement-get-scroll-height-property";
    private async Task GetScrollHeight_Property() {
        int ScrollHeight = await HTMLElement.ScrollHeight;
        labelOutput = ScrollHeight.ToString();
    }

    public const string BUTTON_GET_SCROLL_HEIGHT_METHOD = "htmlelement-get-scroll-height-method";
    private async Task GetScrollHeight_Method() {
        int ScrollHeight = await HTMLElement.GetScrollHeight(default);
        labelOutput = ScrollHeight.ToString();
    }

    public const string BUTTON_GET_SCROLL_LEFT_PROPERTY = "htmlelement-get-scroll-left-property";
    private async Task GetScrollLeft_Property() {
        int ScrollLeft = await HTMLElement.ScrollLeft;
        labelOutput = ScrollLeft.ToString();
    }

    public const string BUTTON_GET_SCROLL_LEFT_METHOD = "htmlelement-get-scroll-left-method";
    private async Task GetScrollLeft_Method() {
        int ScrollLeft = await HTMLElement.GetScrollLeft(default);
        labelOutput = ScrollLeft.ToString();
    }

    public const string BUTTON_SET_SCROLL_LEFT = "htmlelement-set-scroll-left";
    private async Task SetScrollLeft() {
        await HTMLElement.SetScrollLeft(TEST_SCROLLLEFT);
    }

    public const string BUTTON_GET_SCROLL_TOP_PROPERTY = "htmlelement-get-scroll-top-property";
    private async Task GetScrollTop_Property() {
        int ScrollTop = await HTMLElement.ScrollTop;
        labelOutput = ScrollTop.ToString();
    }

    public const string BUTTON_GET_SCROLL_TOP_METHOD = "htmlelement-get-scroll-top-method";
    private async Task GetScrollTop_Method() {
        int ScrollTop = await HTMLElement.GetScrollTop(default);
        labelOutput = ScrollTop.ToString();
    }

    public const string BUTTON_SET_SCROLL_TOP = "htmlelement-set-scroll-top";
    private async Task SetScrollTop() {
        await HTMLElement.SetScrollTop(TEST_SCROLLTOP);
    }


    public const string BUTTON_GET_SLOT_PROPERTY = "htmlelement-get-slot-property";
    private async Task GetSlot_Property() {
        string slot = await HTMLElement.Slot;
        labelOutput = slot;
    }

    public const string BUTTON_GET_SLOT_METHOD = "htmlelement-get-slot-method";
    private async Task GetSlot_Method() {
        string slot = await HTMLElement.GetSlot(default);
        labelOutput = slot;
    }

    public const string BUTTON_SET_SLOT = "htmlelement-set-slot";
    private async Task SetSlot() {
        await HTMLElement.SetSlot(TEST_SLOT);
    }


    public const string BUTTON_GET_LOCAL_NAME_PROPERTY = "htmlelement-get-local-name-property";
    private async Task GetLocalName_Property() {
        string localName = await HTMLElement.LocalName;
        labelOutput = localName;
    }

    public const string BUTTON_GET_LOCAL_NAME_METHOD = "htmlelement-get-local-name-method";
    private async Task GetLocalName_Method() {
        string localName = await HTMLElement.GetLocalName(default);
        labelOutput = localName;
    }

    public const string BUTTON_GET_NAMESPACE_URI_PROPERTY = "htmlelement-get-namespace-uri-property";
    private async Task GetNamespaceURI_Property() {
        string? namespaceURI = await HTMLElement.NamespaceURI;
        labelOutput = namespaceURI ?? "empty namespace";
    }

    public const string BUTTON_GET_NAMESPACE_URI_METHOD = "htmlelement-get-namespace-uri-method";
    private async Task GetNamespaceURI_Method() {
        string? namespaceURI = await HTMLElement.GetNamespaceURI(default);
        labelOutput = namespaceURI ?? "empty namespace";
    }

    public const string BUTTON_GET_PREFIX_PROPERTY = "htmlelement-get-prefix-property";
    private async Task GetPrefix_Property() {
        string? prefix = await HTMLElement.Prefix;
        labelOutput = prefix ?? "no prefix";
    }

    public const string BUTTON_GET_PREFIX_METHOD = "htmlelement-get-prefix-method";
    private async Task GetPrefix_Method() {
        string? prefix = await HTMLElement.GetPrefix(default);
        labelOutput = prefix ?? "no prefix";
    }

    public const string BUTTON_GET_BASE_URI_PROPERTY = "htmlelement-get-base-uri-property";
    private async Task GetBaseURI_Property() {
        string baseURI = await HTMLElement.BaseURI;
        labelOutput = baseURI;
    }

    public const string BUTTON_GET_BASE_URI_METHOD = "htmlelement-get-base-uri-method";
    private async Task GetBaseURI_Method() {
        string baseURI = await HTMLElement.GetBaseURI(default);
        labelOutput = baseURI;
    }

    public const string BUTTON_GET_TAG_NAME_PROPERTY = "htmlelement-get-tag-name-property";
    private async Task GetTagName_Property() {
        string tagName = await HTMLElement.TagName;
        labelOutput = tagName;
    }

    public const string BUTTON_GET_TAG_NAME_METHOD = "htmlelement-get-tag-name-method";
    private async Task GetTagName_Method() {
        string tagName = await HTMLElement.GetTagName(default);
        labelOutput = tagName;
    }

    public const string BUTTON_GET_NODE_NAME_PROPERTY = "htmlelement-get-node-name-property";
    private async Task GetNodeName_Property() {
        string nodeName = await HTMLElement.NodeName;
        labelOutput = nodeName;
    }

    public const string BUTTON_GET_NODE_NAME_METHOD = "htmlelement-get-node-name-method";
    private async Task GetNodeName_Method() {
        string nodeName = await HTMLElement.GetNodeName(default);
        labelOutput = nodeName;
    }

    public const string BUTTON_GET_NODE_TYPE_PROPERTY = "htmlelement-get-node-type-property";
    private async Task GetNodeType_Property() {
        int nodeType = await HTMLElement.NodeType;
        labelOutput = nodeType.ToString();
    }

    public const string BUTTON_GET_NODE_TYPE_METHOD = "htmlelement-get-node-type-method";
    private async Task GetNodeType_Method() {
        int nodeType = await HTMLElement.GetNodeType(default);
        labelOutput = nodeType.ToString();
    }


    // properties - Tree nodes

    public const string BUTTON_GET_CHILD_ELEMENT_COUNT_PROPERTY = "htmlelement-get-child-element-count-property";
    private async Task GetChildElementCount_Property() {
        int childElementCount = await HTMLElement.ChildElementCount;
        labelOutput = childElementCount.ToString();
    }

    public const string BUTTON_GET_CHILD_ELEMENT_COUNT_METHOD = "htmlelement-get-child-element-count-method";
    private async Task GetChildElementCount_Method() {
        int childElementCount = await HTMLElement.GetChildElementCount(default);
        labelOutput = childElementCount.ToString();
    }


    public const string BUTTON_GET_CHILDREN_PROPERTY = "htmlelement-get-children-property";
    private async Task GetChildren_Property() {
        IHTMLElement[] children = await HTMLElement.Children;
        labelOutput = children.Length.ToString();

        await children.DisposeAsync();
    }

    public const string BUTTON_GET_CHILDREN_METHOD = "htmlelement-get-children-method";
    private async Task GetChildren_Method() {
        IHTMLElement[] children = await HTMLElement.GetChildren(default);
        labelOutput = children.Length.ToString();

        await children.DisposeAsync();
    }


    public const string BUTTON_GET_FIRST_ELEMENT_CHILD_PROPERTY = "htmlelement-get-first-element-child-property";
    private async Task GetFirstElementChild_Property() {
        await using IHTMLElement? child = await HTMLElement.FirstElementChild;
        labelOutput = (child is not null).ToString();
    }

    public const string BUTTON_GET_FIRST_ELEMENT_CHILD_METHOD = "htmlelement-get-first-element-child-method";
    private async Task GetFirstElementChild_Method() {
        await using IHTMLElement? child = await HTMLElement.GetFirstElementChild(default);
        labelOutput = (child is not null).ToString();
    }


    public const string BUTTON_GET_LAST_ELEMENT_CHILD_PROPERTY = "htmlelement-get-last-element-child-property";
    private async Task GetLastElementChild_Property() {
        await using IHTMLElement? child = await HTMLElement.LastElementChild;
        labelOutput = (child is not null).ToString();
    }

    public const string BUTTON_GET_LAST_ELEMENT_CHILD_METHOD = "htmlelement-get-last-element-child-method";
    private async Task GetLastElementChild_Method() {
        await using IHTMLElement? child = await HTMLElement.GetLastElementChild(default);
        labelOutput = (child is not null).ToString();
    }


    public const string BUTTON_GET_PREVIOUS_ELEMENT_SIBLING_PROPERTY = "htmlelement-get-previous-element-sibling-property";
    private async Task GetPreviousElementSibling_Property() {
        await using IHTMLElement? sibling = await HTMLElement.PreviousElementSibling;
        labelOutput = (sibling is not null).ToString();
    }

    public const string BUTTON_GET_PREVIOUS_ELEMENT_SIBLING_METHOD = "htmlelement-get-previous-element-sibling-method";
    private async Task GetPreviousElementSibling_Method() {
        await using IHTMLElement? sibling = await HTMLElement.GetPreviousElementSibling(default);
        labelOutput = (sibling is not null).ToString();
    }


    public const string BUTTON_GET_NEXT_ELEMENT_SIBLING_PROPERTY = "htmlelement-get-next-element-sibling-property";
    private async Task GetNextElementSibling_Property() {
        await using IHTMLElement? sibling = await HTMLElement.NextElementSibling;
        labelOutput = (sibling is not null).ToString();
    }

    public const string BUTTON_GET_NEXT_ELEMENT_SIBLING_METHOD = "htmlelement-get-next-element-sibling-method";
    private async Task GetNextElementSibling_Method() {
        await using IHTMLElement? sibling = await HTMLElement.GetNextElementSibling(default);
        labelOutput = (sibling is not null).ToString();
    }


    public const string BUTTON_GET_PARENT_ELEMENT_PROPERTY = "htmlelement-get-parent-element-property";
    private async Task GetParentElement_Property() {
        await using IHTMLElement? parent = await HTMLElement.ParentElement;
        labelOutput = (parent is not null).ToString();
    }

    public const string BUTTON_GET_PARENT_ELEMENT_METHOD = "htmlelement-get-parent-element-method";
    private async Task GetParentElement_Method() {
        await using IHTMLElement? parent = await HTMLElement.GetParentElement(default);
        labelOutput = (parent is not null).ToString();
    }


    // properties - ARIA

    public const string BUTTON_GET_ARIA_ATOMIC_PROPERTY = "htmlelement-get-aria-atomic-property";
    private async Task GetAriaAtomic_Property() => labelOutput = await HTMLElement.AriaAtomic ?? "'aria-atomic' attr not set";

    public const string BUTTON_GET_ARIA_ATOMIC_METHOD = "htmlelement-get-aria-atomic-method";
    private async Task GetAriaAtomic_Method() => labelOutput = await HTMLElement.GetAriaAtomic(default) ?? "'aria-atomic' attr not set";

    public const string BUTTON_SET_ARIA_ATOMIC = "htmlelement-set-aria-atomic";
    private async Task SetAriaAtomic() => await HTMLElement.SetAriaAtomic(TEST_ARIA_ATOMIC);


    public const string BUTTON_GET_ARIA_AUTO_COMPLETE_PROPERTY = "htmlelement-get-aria-auto-complete-property";
    private async Task GetAriaAutoComplete_Property() => labelOutput = await HTMLElement.AriaAutoComplete ?? "'aria-autocomplete' attr not set";

    public const string BUTTON_GET_ARIA_AUTO_COMPLETE_METHOD = "htmlelement-get-aria-auto-complete-method";
    private async Task GetAriaAutoComplete_Method() => labelOutput = await HTMLElement.GetAriaAutoComplete(default) ?? "'aria-autocomplete' attr not set";

    public const string BUTTON_SET_ARIA_AUTO_COMPLETE = "htmlelement-set-aria-auto-complete";
    private async Task SetAriaAutoComplete() => await HTMLElement.SetAriaAutoComplete(TEST_ARIA_AUTO_COMPLETE);


    public const string BUTTON_GET_ARIA_BRAILLE_LABEL_PROPERTY = "htmlelement-get-aria-braille-label-property";
    private async Task GetAriaBrailleLabel_Property() => labelOutput = await HTMLElement.AriaBrailleLabel ?? "'aria-braillelabel' attr not set";

    public const string BUTTON_GET_ARIA_BRAILLE_LABEL_METHOD = "htmlelement-get-aria-braille-label-method";
    private async Task GetAriaBrailleLabel_Method() => labelOutput = await HTMLElement.GetAriaBrailleLabel(default) ?? "'aria-braillelabel' attr not set";

    public const string BUTTON_SET_ARIA_BRAILLE_LABEL = "htmlelement-set-aria-braille-label";
    private async Task SetAriaBrailleLabel() => await HTMLElement.SetAriaBrailleLabel(TEST_ARIA_BRAILLE_LABEL);


    public const string BUTTON_GET_ARIA_BRAILLE_ROLE_DESCRIPTION_PROPERTY = "htmlelement-get-aria-braille-role-description-property";
    private async Task GetAriaBrailleRoleDescription_Property() => labelOutput = await HTMLElement.AriaBrailleRoleDescription ?? "'aria-brailleroledescription' attr not set";

    public const string BUTTON_GET_ARIA_BRAILLE_ROLE_DESCRIPTION_METHOD = "htmlelement-get-aria-braille-role-description-method";
    private async Task GetAriaBrailleRoleDescription_Method() => labelOutput = await HTMLElement.GetAriaBrailleRoleDescription(default) ?? "'aria-brailleroledescription' attr not set";

    public const string BUTTON_SET_ARIA_BRAILLE_ROLE_DESCRIPTION = "htmlelement-set-aria-braille-role-description";
    private async Task SetAriaBrailleRoleDescription() => await HTMLElement.SetAriaBrailleRoleDescription(TEST_ARIA_BRAILLE_ROLE_DESCRIPTION);


    public const string BUTTON_GET_ARIA_BUSY_PROPERTY = "htmlelement-get-aria-busy-property";
    private async Task GetAriaBusy_Property() => labelOutput = await HTMLElement.AriaBusy ?? "'aria-busy' attr not set";

    public const string BUTTON_GET_ARIA_BUSY_METHOD = "htmlelement-get-aria-busy-method";
    private async Task GetAriaBusy_Method() => labelOutput = await HTMLElement.GetAriaBusy(default) ?? "'aria-busy' attr not set";

    public const string BUTTON_SET_ARIA_BUSY = "htmlelement-set-aria-busy";
    private async Task SetAriaBusy() => await HTMLElement.SetAriaBusy(TEST_ARIA_BUSY);


    public const string BUTTON_GET_ARIA_CHECKED_PROPERTY = "htmlelement-get-aria-checked-property";
    private async Task GetAriaChecked_Property() => labelOutput = await HTMLElement.AriaChecked ?? "'aria-checked' attr not set";

    public const string BUTTON_GET_ARIA_CHECKED_METHOD = "htmlelement-get-aria-checked-method";
    private async Task GetAriaChecked_Method() => labelOutput = await HTMLElement.GetAriaChecked(default) ?? "'aria-checked' attr not set";

    public const string BUTTON_SET_ARIA_CHECKED = "htmlelement-set-aria-checked";
    private async Task SetAriaChecked() => await HTMLElement.SetAriaChecked(TEST_ARIA_CHECKED);


    public const string BUTTON_GET_ARIA_COL_COUNT_PROPERTY = "htmlelement-get-aria-col-count-property";
    private async Task GetAriaColCount_Property() => labelOutput = await HTMLElement.AriaColCount ?? "'aria-colcount' attr not set";

    public const string BUTTON_GET_ARIA_COL_COUNT_METHOD = "htmlelement-get-aria-col-count-method";
    private async Task GetAriaColCount_Method() => labelOutput = await HTMLElement.GetAriaColCount(default) ?? "'aria-colcount' attr not set";

    public const string BUTTON_SET_ARIA_COL_COUNT = "htmlelement-set-aria-col-count";
    private async Task SetAriaColCount() => await HTMLElement.SetAriaColCount(TEST_ARIA_COL_COUNT);


    public const string BUTTON_GET_ARIA_COL_INDEX_PROPERTY = "htmlelement-get-aria-col-index-property";
    private async Task GetAriaColIndex_Property() => labelOutput = await HTMLElement.AriaColIndex ?? "'aria-colindex' attr not set";

    public const string BUTTON_GET_ARIA_COL_INDEX_METHOD = "htmlelement-get-aria-col-index-method";
    private async Task GetAriaColIndex_Method() => labelOutput = await HTMLElement.GetAriaColIndex(default) ?? "'aria-colindex' attr not set";

    public const string BUTTON_SET_ARIA_COL_INDEX = "htmlelement-set-aria-col-index";
    private async Task SetAriaColIndex() => await HTMLElement.SetAriaColIndex(TEST_ARIA_COL_INDEX);


    public const string BUTTON_GET_ARIA_COL_INDEX_TEXT_PROPERTY = "htmlelement-get-aria-col-index-text-property";
    private async Task GetAriaColIndexText_Property() => labelOutput = await HTMLElement.AriaColIndexText ?? "'aria-colindextext' attr not set";

    public const string BUTTON_GET_ARIA_COL_INDEX_TEXT_METHOD = "htmlelement-get-aria-col-index-text-method";
    private async Task GetAriaColIndexText_Method() => labelOutput = await HTMLElement.GetAriaColIndexText(default) ?? "'aria-colindextext' attr not set";

    public const string BUTTON_SET_ARIA_COL_INDEX_TEXT = "htmlelement-set-aria-col-index-text";
    private async Task SetAriaColIndexText() => await HTMLElement.SetAriaColIndexText(TEST_ARIA_COL_INDEX_TEXT);


    public const string BUTTON_GET_ARIA_COL_SPAN_PROPERTY = "htmlelement-get-aria-col-span-property";
    private async Task GetAriaColSpan_Property() => labelOutput = await HTMLElement.AriaColSpan ?? "'aria-colspan' attr not set";

    public const string BUTTON_GET_ARIA_COL_SPAN_METHOD = "htmlelement-get-aria-col-span-method";
    private async Task GetAriaColSpan_Method() => labelOutput = await HTMLElement.GetAriaColSpan(default) ?? "'aria-colspan' attr not set";

    public const string BUTTON_SET_ARIA_COL_SPAN = "htmlelement-set-aria-col-span";
    private async Task SetAriaColSpan() => await HTMLElement.SetAriaColSpan(TEST_ARIA_COL_SPAN);


    public const string BUTTON_GET_ARIA_CURRENT_PROPERTY = "htmlelement-get-aria-current-property";
    private async Task GetAriaCurrent_Property() => labelOutput = await HTMLElement.AriaCurrent ?? "'aria-current' attr not set";

    public const string BUTTON_GET_ARIA_CURRENT_METHOD = "htmlelement-get-aria-current-method";
    private async Task GetAriaCurrent_Method() => labelOutput = await HTMLElement.GetAriaCurrent(default) ?? "'aria-current' attr not set";

    public const string BUTTON_SET_ARIA_CURRENT = "htmlelement-set-aria-current";
    private async Task SetAriaCurrent() => await HTMLElement.SetAriaCurrent(TEST_ARIA_CURRENT);


    public const string BUTTON_GET_ARIA_DESCRIPTION_PROPERTY = "htmlelement-get-aria-description-property";
    private async Task GetAriaDescription_Property() => labelOutput = await HTMLElement.AriaDescription ?? "'aria-description' attr not set";

    public const string BUTTON_GET_ARIA_DESCRIPTION_METHOD = "htmlelement-get-aria-description-method";
    private async Task GetAriaDescription_Method() => labelOutput = await HTMLElement.GetAriaDescription(default) ?? "'aria-description' attr not set";

    public const string BUTTON_SET_ARIA_DESCRIPTION = "htmlelement-set-aria-description";
    private async Task SetAriaDescription() => await HTMLElement.SetAriaDescription(TEST_ARIA_DESCRIPTION);


    public const string BUTTON_GET_ARIA_DISABLED_PROPERTY = "htmlelement-get-aria-disabled-property";
    private async Task GetAriaDisabled_Property() => labelOutput = await HTMLElement.AriaDisabled ?? "'aria-disabled' attr not set";

    public const string BUTTON_GET_ARIA_DISABLED_METHOD = "htmlelement-get-aria-disabled-method";
    private async Task GetAriaDisabled_Method() => labelOutput = await HTMLElement.GetAriaDisabled(default) ?? "'aria-disabled' attr not set";

    public const string BUTTON_SET_ARIA_DISABLED = "htmlelement-set-aria-disabled";
    private async Task SetAriaDisabled() => await HTMLElement.SetAriaDisabled(TEST_ARIA_DISABLED);


    public const string BUTTON_GET_ARIA_EXPANDED_PROPERTY = "htmlelement-get-aria-expanded-property";
    private async Task GetAriaExpanded_Property() => labelOutput = await HTMLElement.AriaExpanded ?? "'aria-expanded' attr not set";

    public const string BUTTON_GET_ARIA_EXPANDED_METHOD = "htmlelement-get-aria-expanded-method";
    private async Task GetAriaExpanded_Method() => labelOutput = await HTMLElement.GetAriaExpanded(default) ?? "'aria-expanded' attr not set";

    public const string BUTTON_SET_ARIA_EXPANDED = "htmlelement-set-aria-expanded";
    private async Task SetAriaExpanded() => await HTMLElement.SetAriaExpanded(TEST_ARIA_EXPANDED);


    public const string BUTTON_GET_ARIA_HAS_POPUP_PROPERTY = "htmlelement-get-aria-has-popup-property";
    private async Task GetAriaHasPopup_Property() => labelOutput = await HTMLElement.AriaHasPopup ?? "'aria-haspopup' attr not set";

    public const string BUTTON_GET_ARIA_HAS_POPUP_METHOD = "htmlelement-get-aria-has-popup-method";
    private async Task GetAriaHasPopup_Method() => labelOutput = await HTMLElement.GetAriaHasPopup(default) ?? "'aria-haspopup' attr not set";

    public const string BUTTON_SET_ARIA_HAS_POPUP = "htmlelement-set-aria-has-popup";
    private async Task SetAriaHasPopup() => await HTMLElement.SetAriaHasPopup(TEST_ARIA_HAS_POPUP);


    public const string BUTTON_GET_ARIA_HIDDEN_PROPERTY = "htmlelement-get-aria-hidden-property";
    private async Task GetAriaHidden_Property() => labelOutput = await HTMLElement.AriaHidden ?? "'aria-hidden' attr not set";

    public const string BUTTON_GET_ARIA_HIDDEN_METHOD = "htmlelement-get-aria-hidden-method";
    private async Task GetAriaHidden_Method() => labelOutput = await HTMLElement.GetAriaHidden(default) ?? "'aria-hidden' attr not set";

    public const string BUTTON_SET_ARIA_HIDDEN = "htmlelement-set-aria-hidden";
    private async Task SetAriaHidden() => await HTMLElement.SetAriaHidden(TEST_ARIA_HIDDEN);


    public const string BUTTON_GET_ARIA_INVALID_PROPERTY = "htmlelement-get-aria-invalid-property";
    private async Task GetAriaInvalid_Property() => labelOutput = await HTMLElement.AriaInvalid ?? "'aria-invalid' attr not set";

    public const string BUTTON_GET_ARIA_INVALID_METHOD = "htmlelement-get-aria-invalid-method";
    private async Task GetAriaInvalid_Method() => labelOutput = await HTMLElement.GetAriaInvalid(default) ?? "'aria-invalid' attr not set";

    public const string BUTTON_SET_ARIA_INVALID = "htmlelement-set-aria-invalid";
    private async Task SetAriaInvalid() => await HTMLElement.SetAriaInvalid(TEST_ARIA_INVALID);


    public const string BUTTON_GET_ARIA_KEY_SHORTCUTS_PROPERTY = "htmlelement-get-aria-key-shortcuts-property";
    private async Task GetAriaKeyShortcuts_Property() => labelOutput = await HTMLElement.AriaKeyShortcuts ?? "'aria-keyshortcuts' attr not set";

    public const string BUTTON_GET_ARIA_KEY_SHORTCUTS_METHOD = "htmlelement-get-aria-key-shortcuts-method";
    private async Task GetAriaKeyShortcuts_Method() => labelOutput = await HTMLElement.GetAriaKeyShortcuts(default) ?? "'aria-keyshortcuts' attr not set";

    public const string BUTTON_SET_ARIA_KEY_SHORTCUTS = "htmlelement-set-aria-key-shortcuts";
    private async Task SetAriaKeyShortcuts() => await HTMLElement.SetAriaKeyShortcuts(TEST_ARIA_KEY_SHORTCUTS);


    public const string BUTTON_GET_ARIA_LABEL_PROPERTY = "htmlelement-get-aria-label-property";
    private async Task GetAriaLabel_Property() => labelOutput = await HTMLElement.AriaLabel ?? "'aria-label' attr not set";

    public const string BUTTON_GET_ARIA_LABEL_METHOD = "htmlelement-get-aria-label-method";
    private async Task GetAriaLabel_Method() => labelOutput = await HTMLElement.GetAriaLabel(default) ?? "'aria-label' attr not set";

    public const string BUTTON_SET_ARIA_LABEL = "htmlelement-set-aria-label";
    private async Task SetAriaLabel() => await HTMLElement.SetAriaLabel(TEST_ARIA_LABEL);


    public const string BUTTON_GET_ARIA_LEVEL_PROPERTY = "htmlelement-get-aria-level-property";
    private async Task GetAriaLevel_Property() => labelOutput = await HTMLElement.AriaLevel ?? "'aria-level' attr not set";

    public const string BUTTON_GET_ARIA_LEVEL_METHOD = "htmlelement-get-aria-level-method";
    private async Task GetAriaLevel_Method() => labelOutput = await HTMLElement.GetAriaLevel(default) ?? "'aria-level' attr not set";

    public const string BUTTON_SET_ARIA_LEVEL = "htmlelement-set-aria-level";
    private async Task SetAriaLevel() => await HTMLElement.SetAriaLevel(TEST_ARIA_LEVEL);


    public const string BUTTON_GET_ARIA_LIVE_PROPERTY = "htmlelement-get-aria-live-property";
    private async Task GetAriaLive_Property() => labelOutput = await HTMLElement.AriaLive ?? "'aria-live' attr not set";

    public const string BUTTON_GET_ARIA_LIVE_METHOD = "htmlelement-get-aria-live-method";
    private async Task GetAriaLive_Method() => labelOutput = await HTMLElement.GetAriaLive(default) ?? "'aria-live' attr not set";

    public const string BUTTON_SET_ARIA_LIVE = "htmlelement-set-aria-live";
    private async Task SetAriaLive() => await HTMLElement.SetAriaLive(TEST_ARIA_LIVE);


    public const string BUTTON_GET_ARIA_MODAL_PROPERTY = "htmlelement-get-aria-modal-property";
    private async Task GetAriaModal_Property() => labelOutput = await HTMLElement.AriaModal ?? "'aria-modal' attr not set";

    public const string BUTTON_GET_ARIA_MODAL_METHOD = "htmlelement-get-aria-modal-method";
    private async Task GetAriaModal_Method() => labelOutput = await HTMLElement.GetAriaModal(default) ?? "'aria-modal' attr not set";

    public const string BUTTON_SET_ARIA_MODAL = "htmlelement-set-aria-modal";
    private async Task SetAriaModal() => await HTMLElement.SetAriaModal(TEST_ARIA_MODAL);


    public const string BUTTON_GET_ARIA_MULTILINE_PROPERTY = "htmlelement-get-aria-multiline-property";
    private async Task GetAriaMultiline_Property() => labelOutput = await HTMLElement.AriaMultiline ?? "'aria-multiline' attr not set";

    public const string BUTTON_GET_ARIA_MULTILINE_METHOD = "htmlelement-get-aria-multiline-method";
    private async Task GetAriaMultiline_Method() => labelOutput = await HTMLElement.GetAriaMultiline(default) ?? "'aria-multiline' attr not set";

    public const string BUTTON_SET_ARIA_MULTILINE = "htmlelement-set-aria-multiline";
    private async Task SetAriaMultiline() => await HTMLElement.SetAriaMultiline(TEST_ARIA_MULTILINE);


    public const string BUTTON_GET_ARIA_MULTI_SELECTABLE_PROPERTY = "htmlelement-get-aria-multi-selectable-property";
    private async Task GetAriaMultiSelectable_Property() => labelOutput = await HTMLElement.AriaMultiSelectable ?? "'aria-multiselectable' attr not set";

    public const string BUTTON_GET_ARIA_MULTI_SELECTABLE_METHOD = "htmlelement-get-aria-multi-selectable-method";
    private async Task GetAriaMultiSelectable_Method() => labelOutput = await HTMLElement.GetAriaMultiSelectable(default) ?? "'aria-multiselectable' attr not set";

    public const string BUTTON_SET_ARIA_MULTI_SELECTABLE = "htmlelement-set-aria-multi-selectable";
    private async Task SetAriaMultiSelectable() => await HTMLElement.SetAriaMultiSelectable(TEST_ARIA_MULTI_SELECTABLE);


    public const string BUTTON_GET_ARIA_ORIENTATION_PROPERTY = "htmlelement-get-aria-orientation-property";
    private async Task GetAriaOrientation_Property() => labelOutput = await HTMLElement.AriaOrientation ?? "'aria-orientation' attr not set";

    public const string BUTTON_GET_ARIA_ORIENTATION_METHOD = "htmlelement-get-aria-orientation-method";
    private async Task GetAriaOrientation_Method() => labelOutput = await HTMLElement.GetAriaOrientation(default) ?? "'aria-orientation' attr not set";

    public const string BUTTON_SET_ARIA_ORIENTATION = "htmlelement-set-aria-orientation";
    private async Task SetAriaOrientation() => await HTMLElement.SetAriaOrientation(TEST_ARIA_ORIENTATION);


    public const string BUTTON_GET_ARIA_PLACEHOLDER_PROPERTY = "htmlelement-get-aria-placeholder-property";
    private async Task GetAriaPlaceholder_Property() => labelOutput = await HTMLElement.AriaPlaceholder ?? "'aria-placeholder' attr not set";

    public const string BUTTON_GET_ARIA_PLACEHOLDER_METHOD = "htmlelement-get-aria-placeholder-method";
    private async Task GetAriaPlaceholder_Method() => labelOutput = await HTMLElement.GetAriaPlaceholder(default) ?? "'aria-placeholder' attr not set";

    public const string BUTTON_SET_ARIA_PLACEHOLDER = "htmlelement-set-aria-placeholder";
    private async Task SetAriaPlaceholder() => await HTMLElement.SetAriaPlaceholder(TEST_ARIA_PLACEHOLDER);


    public const string BUTTON_GET_ARIA_POS_IN_SET_PROPERTY = "htmlelement-get-aria-pos-in-set-property";
    private async Task GetAriaPosInSet_Property() => labelOutput = await HTMLElement.AriaPosInSet ?? "'aria-posinset' attr not set";

    public const string BUTTON_GET_ARIA_POS_IN_SET_METHOD = "htmlelement-get-aria-pos-in-set-method";
    private async Task GetAriaPosInSet_Method() => labelOutput = await HTMLElement.GetAriaPosInSet(default) ?? "'aria-posinset' attr not set";

    public const string BUTTON_SET_ARIA_POS_IN_SET = "htmlelement-set-aria-pos-in-set";
    private async Task SetAriaPosInSet() => await HTMLElement.SetAriaPosInSet(TEST_ARIA_POS_IN_SET);


    public const string BUTTON_GET_ARIA_PRESSED_PROPERTY = "htmlelement-get-aria-pressed-property";
    private async Task GetAriaPressed_Property() => labelOutput = await HTMLElement.AriaPressed ?? "'aria-pressed' attr not set";

    public const string BUTTON_GET_ARIA_PRESSED_METHOD = "htmlelement-get-aria-pressed-method";
    private async Task GetAriaPressed_Method() => labelOutput = await HTMLElement.GetAriaPressed(default) ?? "'aria-pressed' attr not set";

    public const string BUTTON_SET_ARIA_PRESSED = "htmlelement-set-aria-pressed";
    private async Task SetAriaPressed() => await HTMLElement.SetAriaPressed(TEST_ARIA_PRESSED);


    public const string BUTTON_GET_ARIA_READ_ONLY_PROPERTY = "htmlelement-get-aria-read-only-property";
    private async Task GetAriaReadOnly_Property() => labelOutput = await HTMLElement.AriaReadOnly ?? "'aria-readonly' attr not set";

    public const string BUTTON_GET_ARIA_READ_ONLY_METHOD = "htmlelement-get-aria-read-only-method";
    private async Task GetAriaReadOnly_Method() => labelOutput = await HTMLElement.GetAriaReadOnly(default) ?? "'aria-readonly' attr not set";

    public const string BUTTON_SET_ARIA_READ_ONLY = "htmlelement-set-aria-read-only";
    private async Task SetAriaReadOnly() => await HTMLElement.SetAriaReadOnly(TEST_ARIA_READ_ONLY);


    public const string BUTTON_GET_ARIA_REQUIRED_PROPERTY = "htmlelement-get-aria-required-property";
    private async Task GetAriaRequired_Property() => labelOutput = await HTMLElement.AriaRequired ?? "'aria-required' attr not set";

    public const string BUTTON_GET_ARIA_REQUIRED_METHOD = "htmlelement-get-aria-required-method";
    private async Task GetAriaRequired_Method() => labelOutput = await HTMLElement.GetAriaRequired(default) ?? "'aria-required' attr not set";

    public const string BUTTON_SET_ARIA_REQUIRED = "htmlelement-set-aria-required";
    private async Task SetAriaRequired() => await HTMLElement.SetAriaRequired(TEST_ARIA_REQUIRED);


    public const string BUTTON_GET_ARIA_ROLE_DESCRIPTION_PROPERTY = "htmlelement-get-aria-roledescription-property";
    private async Task GetAriaRoleDescription_Property() => labelOutput = await HTMLElement.AriaRoleDescription ?? "'aria-roledescription' attr not set";

    public const string BUTTON_GET_ARIA_ROLE_DESCRIPTION_METHOD = "htmlelement-get-aria-roledescription-method";
    private async Task GetAriaRoleDescription_Method() => labelOutput = await HTMLElement.GetAriaRoleDescription(default) ?? "'aria-roledescription' attr not set";

    public const string BUTTON_SET_ARIA_ROLE_DESCRIPTION = "htmlelement-set-aria-roledescription";
    private async Task SetAriaRoleDescription() => await HTMLElement.SetAriaRoleDescription(TEST_ARIA_ROLE_DESCRIPTION);


    public const string BUTTON_GET_ARIA_ROW_COUNT_PROPERTY = "htmlelement-get-aria-row-count-property";
    private async Task GetAriaRowCount_Property() => labelOutput = await HTMLElement.AriaRowCount ?? "'aria-rowcount' attr not set";

    public const string BUTTON_GET_ARIA_ROW_COUNT_METHOD = "htmlelement-get-aria-row-count-method";
    private async Task GetAriaRowCount_Method() => labelOutput = await HTMLElement.GetAriaRowCount(default) ?? "'aria-rowcount' attr not set";

    public const string BUTTON_SET_ARIA_ROW_COUNT = "htmlelement-set-aria-row-count";
    private async Task SetAriaRowCount() => await HTMLElement.SetAriaRowCount(TEST_ARIA_ROW_COUNT);


    public const string BUTTON_GET_ARIA_ROW_INDEX_PROPERTY = "htmlelement-get-aria-row-index-property";
    private async Task GetAriaRowIndex_Property() => labelOutput = await HTMLElement.AriaRowIndex ?? "'aria-rowindex' attr not set";

    public const string BUTTON_GET_ARIA_ROW_INDEX_METHOD = "htmlelement-get-aria-row-index-method";
    private async Task GetAriaRowIndex_Method() => labelOutput = await HTMLElement.GetAriaRowIndex(default) ?? "'aria-rowindex' attr not set";

    public const string BUTTON_SET_ARIA_ROW_INDEX = "htmlelement-set-aria-row-index";
    private async Task SetAriaRowIndex() => await HTMLElement.SetAriaRowIndex(TEST_ARIA_ROW_INDEX);


    public const string BUTTON_GET_ARIA_ROW_INDEX_TEXT_PROPERTY = "htmlelement-get-aria-row-index-text-property";
    private async Task GetAriaRowIndexText_Property() => labelOutput = await HTMLElement.AriaRowIndexText ?? "'aria-rowindextext' attr not set";

    public const string BUTTON_GET_ARIA_ROW_INDEX_TEXT_METHOD = "htmlelement-get-aria-row-index-text-method";
    private async Task GetAriaRowIndexText_Method() => labelOutput = await HTMLElement.GetAriaRowIndexText(default) ?? "'aria-rowindextext' attr not set";

    public const string BUTTON_SET_ARIA_ROW_INDEX_TEXT = "htmlelement-set-aria-row-index-text";
    private async Task SetAriaRowIndexText() => await HTMLElement.SetAriaRowIndexText(TEST_ARIA_ROW_INDEX_TEXT);


    public const string BUTTON_GET_ARIA_ROW_SPAN_PROPERTY = "htmlelement-get-aria-row-span-property";
    private async Task GetAriaRowSpan_Property() => labelOutput = await HTMLElement.AriaRowSpan ?? "'aria-rowspan' attr not set";

    public const string BUTTON_GET_ARIA_ROW_SPAN_METHOD = "htmlelement-get-aria-row-span-method";
    private async Task GetAriaRowSpan_Method() => labelOutput = await HTMLElement.GetAriaRowSpan(default) ?? "'aria-rowspan' attr not set";

    public const string BUTTON_SET_ARIA_ROW_SPAN = "htmlelement-set-aria-row-span";
    private async Task SetAriaRowSpan() => await HTMLElement.SetAriaRowSpan(TEST_ARIA_ROW_SPAN);


    public const string BUTTON_GET_ARIA_SELECTED_PROPERTY = "htmlelement-get-aria-selected-property";
    private async Task GetAriaSelected_Property() => labelOutput = await HTMLElement.AriaSelected ?? "'aria-selected' attr not set";

    public const string BUTTON_GET_ARIA_SELECTED_METHOD = "htmlelement-get-aria-selected-method";
    private async Task GetAriaSelected_Method() => labelOutput = await HTMLElement.GetAriaSelected(default) ?? "'aria-selected' attr not set";

    public const string BUTTON_SET_ARIA_SELECTED = "htmlelement-set-aria-selected";
    private async Task SetAriaSelected() => await HTMLElement.SetAriaSelected(TEST_ARIA_SELECTED);


    public const string BUTTON_GET_ARIA_SET_SIZE_PROPERTY = "htmlelement-get-aria-set-size-property";
    private async Task GetAriaSetSize_Property() => labelOutput = await HTMLElement.AriaSetSize ?? "'aria-setsize' attr not set";

    public const string BUTTON_GET_ARIA_SET_SIZE_METHOD = "htmlelement-get-aria-set-size-method";
    private async Task GetAriaSetSize_Method() => labelOutput = await HTMLElement.GetAriaSetSize(default) ?? "'aria-setsize' attr not set";

    public const string BUTTON_SET_ARIA_SET_SIZE = "htmlelement-set-aria-set-size";
    private async Task SetAriaSetSize() => await HTMLElement.SetAriaSetSize(TEST_ARIA_SET_SIZE);


    public const string BUTTON_GET_ARIA_SORT_PROPERTY = "htmlelement-get-aria-sort-property";
    private async Task GetAriaSort_Property() => labelOutput = await HTMLElement.AriaSort ?? "'aria-sort' attr not set";

    public const string BUTTON_GET_ARIA_SORT_METHOD = "htmlelement-get-aria-sort-method";
    private async Task GetAriaSort_Method() => labelOutput = await HTMLElement.GetAriaSort(default) ?? "'aria-sort' attr not set";

    public const string BUTTON_SET_ARIA_SORT = "htmlelement-set-aria-sort";
    private async Task SetAriaSort() => await HTMLElement.SetAriaSort(TEST_ARIA_SORT);


    public const string BUTTON_GET_ARIA_VALUE_MAX_PROPERTY = "htmlelement-get-aria-value-max-property";
    private async Task GetAriaValueMax_Property() => labelOutput = await HTMLElement.AriaValueMax ?? "'aria-valuemax' attr not set";

    public const string BUTTON_GET_ARIA_VALUE_MAX_METHOD = "htmlelement-get-aria-value-max-method";
    private async Task GetAriaValueMax_Method() => labelOutput = await HTMLElement.GetAriaValueMax(default) ?? "'aria-valuemax' attr not set";

    public const string BUTTON_SET_ARIA_VALUE_MAX = "htmlelement-set-aria-value-max";
    private async Task SetAriaValueMax() => await HTMLElement.SetAriaValueMax(TEST_ARIA_VALUE_MAX);


    public const string BUTTON_GET_ARIA_VALUE_MIN_PROPERTY = "htmlelement-get-aria-value-min-property";
    private async Task GetAriaValueMin_Property() => labelOutput = await HTMLElement.AriaValueMin ?? "'aria-valuemin' attr not set";

    public const string BUTTON_GET_ARIA_VALUE_MIN_METHOD = "htmlelement-get-aria-value-min-method";
    private async Task GetAriaValueMin_Method() => labelOutput = await HTMLElement.GetAriaValueMin(default) ?? "'aria-valuemin' attr not set";

    public const string BUTTON_SET_ARIA_VALUE_MIN = "htmlelement-set-aria-value-min";
    private async Task SetAriaValueMin() => await HTMLElement.SetAriaValueMin(TEST_ARIA_VALUE_MIN);


    public const string BUTTON_GET_ARIA_VALUE_NOW_PROPERTY = "htmlelement-get-aria-value-now-property";
    private async Task GetAriaValueNow_Property() => labelOutput = await HTMLElement.AriaValueNow ?? "'aria-valuenow' attr not set";

    public const string BUTTON_GET_ARIA_VALUE_NOW_METHOD = "htmlelement-get-aria-value-now-method";
    private async Task GetAriaValueNow_Method() => labelOutput = await HTMLElement.GetAriaValueNow(default) ?? "'aria-valuenow' attr not set";

    public const string BUTTON_SET_ARIA_VALUE_NOW = "htmlelement-set-aria-value-now";
    private async Task SetAriaValueNow() => await HTMLElement.SetAriaValueNow(TEST_ARIA_VALUE_NOW);


    public const string BUTTON_GET_ARIA_VALUE_TEXT_PROPERTY = "htmlelement-get-aria-value-text-property";
    private async Task GetAriaValueText_Property() => labelOutput = await HTMLElement.AriaValueText ?? "'aria-valuetext' attr not set";

    public const string BUTTON_GET_ARIA_VALUE_TEXT_METHOD = "htmlelement-get-aria-value-text-method";
    private async Task GetAriaValueText_Method() => labelOutput = await HTMLElement.GetAriaValueText(default) ?? "'aria-valuetext' attr not set";

    public const string BUTTON_SET_ARIA_VALUE_TEXT = "htmlelement-set-aria-value-text";
    private async Task SetAriaValueText() => await HTMLElement.SetAriaValueText(TEST_ARIA_VALUE_TEXT);


    public const string BUTTON_GET_ROLE_PROPERTY = "htmlelement-get-role-property";
    private async Task GetRole_Property() => labelOutput = await HTMLElement.Role ?? "'role' attr not set";

    public const string BUTTON_GET_ROLE_METHOD = "htmlelement-get-role-method";
    private async Task GetRole_Method() => labelOutput = await HTMLElement.GetRole(default) ?? "'role' attr not set";

    public const string BUTTON_SET_ROLE = "htmlelement-set-role";
    private async Task SetRole() => await HTMLElement.SetRole(TEST_ROLE);


    // methods

    public const string BUTTON_CHECK_VISIBILITY = "htmlelement-check-visibility";
    private async Task CheckVisibility() {
        bool visibility = await HTMLElement.CheckVisibility();
        labelOutput = visibility.ToString();
    }

    public const string BUTTON_COMPUTED_STYLE_MAP = "htmlelement-computed-style-map";
    private async Task ComputedStyleMap() {
        Dictionary<string, string> computedStyleMap = await HTMLElement.ComputedStyleMap();
        labelOutput = JsonSerializer.Serialize(computedStyleMap);
    }

    public const string BUTTON_GET_BOUNDING_CLIENT_RECT = "htmlelement-get-bounding-client-rect";
    private async Task GetBoundingClientRect() {
        DOMRect boundingClientRect = await HTMLElement.GetBoundingClientRect();
        labelOutput = JsonSerializer.Serialize(boundingClientRect);
    }

    public const string BUTTON_GET_CLIENT_RECTS = "htmlelement-get-client-rects";
    private async Task GetClientRects() {
        DOMRect[] boundingClientRect = await HTMLElement.GetClientRects();
        labelOutput = string.Join(';', boundingClientRect.Select(rect => JsonSerializer.Serialize(rect)));
    }

    public const string BUTTON_MATCHES = "htmlelement-matches";
    public async Task Matches() {
        bool matches = await HTMLElement.Matches($"[data-testid={HTML_ELEMENT}]");
        labelOutput = matches.ToString();
    }

    public const string BUTTON_REQUEST_FULLSCREEN = "htmlelement-request-fullscreen";
    private async Task RequestFullscreen() {
        await HTMLElement.RequestFullscreen();
    }

    public const string BUTTON_REQUEST_POINTER_LOCK = "htmlelement-request-pointer-lock";
    private async Task RequestPointerLock() {
        await HTMLElement.RequestPointerLock();
    }

    public const string BUTTON_IS_DEFAULT_NAMESPACE = "htmlelement-is-default-namespace";
    private async Task IsDefaultNamespace() {
        bool isDefaultNamespace = await HTMLElement.IsDefaultNamespace("http://www.w3.org/1999/xhtml");
        labelOutput = isDefaultNamespace.ToString();
    }

    public const string BUTTON_LOOKUP_PREFIX = "htmlelement-lookup-prefix";
    private async Task LookupPrefix() {
        string? prefix = await HTMLElement.LookupPrefix("http://www.w3.org/1999/xhtml");
        labelOutput = prefix ?? "(no prefix)";
    }

    public const string BUTTON_LOOKUP_NAMESPACE_URI = "htmlelement-lookup-namespace-uri";
    private async Task LookupNamespaceURI() {
        string? namespaceURI = await HTMLElement.LookupNamespaceURI(null);
        labelOutput = namespaceURI ?? "(no namespace uri)";
    }

    public const string BUTTON_NORMALIZE = "htmlelement-normalize";
    private async Task Normalize() {
        await HTMLElement.Normalize();
    }


    // methods - Pointer Capture

    private async Task SetPointerCapture(PointerEventArgs e) {
        await HTMLElement.SetPointerCapture(e.PointerId);
    }

    private async Task ReleasePointerCapture(PointerEventArgs e) {
        await HTMLElement.ReleasePointerCapture(e.PointerId);
    }

    private async Task HasPointerCapture(PointerEventArgs e) {
        bool hasPointerCapture = await HTMLElement.HasPointerCapture(e.PointerId);
        labelOutput = hasPointerCapture.ToString();
    }


    // methods - Scroll

    public const string BUTTON_SCROLL = "htmlelement-scroll";
    private async Task Scroll() {
        await HTMLElement.Scroll(TEST_SCROLL_LEFT, TEST_SCROLL_TOP);
    }

    public const string BUTTON_SCROLL_TO = "htmlelement-scroll-to";
    private async Task ScrollTo() {
        await HTMLElement.ScrollTo(TEST_SCROLL_LEFT, TEST_SCROLL_TOP);
    }

    public const string BUTTON_SCROLL_BY = "htmlelement-scroll-by";
    private async Task ScrollBy() {
        await HTMLElement.ScrollBy(TEST_SCROLL_BY_X, TEST_SCROLL_BY_Y);
    }

    public const string BUTTON_SCROLL_INTO_VIEW = "htmlelement-scroll-into-view";
    private async Task ScrollIntoView() {
        await HTMLElement.ScrollIntoView();
    }


    // methods - Attribute

    public const string BUTTON_GET_ATTRIBUTE = "htmlelement-get-attribute";
    private async Task GetAttribute() {
        string? attribute = await HTMLElement.GetAttribute("data-testid");
        labelOutput = attribute ?? "'data-testid' attr not found";
    }

    public const string BUTTON_GET_ATTRIBUTE_NS = "htmlelement-get-attribute-ns";
    private async Task GetAttributeNS() {
        string? attribute = await HTMLElement.GetAttributeNS("", "data-testid");
        labelOutput = attribute ?? "'data-testid' attr not found";
    }

    public const string BUTTON_GET_ATTRIBUTE_NAMES = "htmlelement-get-attribute-names";
    private async Task GetAttributeNames() {
        string[] attributeNames = await HTMLElement.GetAttributeNames();
        labelOutput = $"({attributeNames.Length}): {string.Join(',', attributeNames)}";
    }

    public const string BUTTON_SET_ATTRIBUTE = "htmlelement-set-attribute";
    private async Task SetAttribute() {
        await HTMLElement.SetAttribute(TEST_CUSTOM_NAME, TEST_CUSTOM_VALUE);
    }

    public const string BUTTON_SET_ATTRIBUTE_NS = "htmlelement-set-attribute-ns";
    private async Task SetAttributeNS() {
        await HTMLElement.SetAttributeNS("http://www.w3.org/1999/xhtml", TEST_CUSTOM_NAME, TEST_CUSTOM_VALUE);
    }

    public const string BUTTON_TOGGLE_ATTRIBUTE = "htmlelement-toggle-attribute";
    private async Task ToggleAttribute() {
        await HTMLElement.ToggleAttribute(TEST_CUSTOM_NAME);
    }

    public const string BUTTON_REMOVE_ATTRIBUTE = "htmlelement-remove-attribute";
    private async Task RemoveAttribute() {
        await HTMLElement.RemoveAttribute(TEST_CUSTOM_NAME);
    }

    public const string BUTTON_REMOVE_ATTRIBUTE_NS = "htmlelement-remove-attribute-ns";
    private async Task RemoveAttributeNS() {
        await HTMLElement.RemoveAttributeNS("", TEST_CUSTOM_NAME);
    }

    public const string BUTTON_HAS_ATTRIBUTE = "htmlelement-has-attribute";
    private async Task HasAttribute() {
        bool hasAttribute = await HTMLElement.HasAttribute("data-testid");
        labelOutput = hasAttribute.ToString();
    }

    public const string BUTTON_HAS_ATTRIBUTE_NS = "htmlelement-has-attribute-ns";
    private async Task HasAttributeNS() {
        bool hasAttribute = await HTMLElement.HasAttributeNS("", "data-testid");
        labelOutput = hasAttribute.ToString();
    }

    public const string BUTTON_HAS_ATTRIBUTES = "htmlelement-has-attributes";
    private async Task HasAttributes() {
        bool hasAttributes = await HTMLElement.HasAttributes();
        labelOutput = hasAttributes.ToString();
    }


    // methods - Tree-nodes

    public const string BUTTON_GET_ELEMENTS_BY_CLASS_NAME = "htmlelement-get-elements-by-class-name";
    private async Task GetElementsByClassName() {
        IHTMLElement[] elements = await HTMLElement.GetElementsByClassName(TEST_CUSTOM_NAME);
        labelOutput = elements.Length.ToString();

        await elements.DisposeAsync();
    }

    public const string BUTTON_GET_ELEMENTS_BY_TAG_NAME = "htmlelement-get-elements-by-tag-name";
    private async Task GetElementsByTagName() {
        IHTMLElement[] elements = await HTMLElement.GetElementsByTagName("b");
        labelOutput = elements.Length.ToString();

        await elements.DisposeAsync();
    }

    public const string BUTTON_GET_ELEMENTS_BY_TAG_NAME_NS = "htmlelement-get-elements-by-tag-name-ns";
    private async Task GetElementsByTagNameNS() {
        IHTMLElement[] elements = await HTMLElement.GetElementsByTagNameNS("http://www.w3.org/1999/xhtml", "b");
        labelOutput = elements.Length.ToString();

        await elements.DisposeAsync();
    }

    public const string BUTTON_QUERY_SELECTOR = "htmlelement-query-selector";
    private async Task QuerySelector() {
        await using IHTMLElement? element = await HTMLElement.QuerySelector("b");
        labelOutput = (element is not null).ToString();
    }

    public const string BUTTON_QUERY_SELECTOR_ALL = "htmlelement-query-selector-all";
    private async Task QuerySelectorAll() {
        IHTMLElement[] elements = await HTMLElement.QuerySelectorAll("b");
        labelOutput = elements.Length.ToString();

        await elements.DisposeAsync();
    }

    public const string BUTTON_CLOSEST = "htmlelement-closest";
    private async Task Closest() {
        await using IHTMLElement? element = await HTMLElement.Closest(".group");
        labelOutput = (element is not null).ToString();
    }


    public const string BUTTON_BEFORE_STRING = "htmlelement-before-string";
    private async Task Before_String() {
        await HTMLElement.Before([TEST_CUSTOM_VALUE]);
    }

    public const string BUTTON_BEFORE_HTML_ELEMENT = "htmlelement-before-html-element";
    private async Task Before_HtmlElement() {
        await HTMLElement.Before([HiddenElement]);
    }

    public const string BUTTON_AFTER_STRING = "htmlelement-after-string";
    private async Task After_String() {
        await HTMLElement.After([TEST_CUSTOM_VALUE]);
    }

    public const string BUTTON_AFTER_HTML_ELEMENT = "htmlelement-after-html-element";
    private async Task After_HtmlElement() {
        await HTMLElement.After([HiddenElement]);
    }


    public const string BUTTON_PREPEND_STRING = "htmlelement-prepend-string";
    private async Task Prepend_String() {
        await HTMLElement.Prepend([TEST_CUSTOM_VALUE]);
    }

    public const string BUTTON_PREPEND_HTML_ELEMENT = "htmlelement-prepend-html-element";
    private async Task Prepend_HtmlElement() {
        await HTMLElement.Prepend([HiddenElement]);
    }

    public const string BUTTON_APPEND_CHILD = "htmlelement-append-child";
    private async Task AppendChild() {
        await HTMLElement.AppendChild(HiddenElement);
    }

    public const string BUTTON_APPEND_STRING = "htmlelement-append-string";
    private async Task Append_String() {
        await HTMLElement.Append([TEST_CUSTOM_VALUE]);
    }

    public const string BUTTON_APPEND_HTML_ELEMENT = "htmlelement-append-html-element";
    private async Task Append_HtmlElement() {
        await HTMLElement.Append([HiddenElement]);
    }

    public const string BUTTON_INSERT_ADJACENT_ELEMENT = "htmlelement-insert-adjacent-element";
    private async Task InsertAdjacentElement() {
        bool success = await HTMLElement.InsertAdjacentElement("afterbegin", HiddenElement);
        labelOutput = success.ToString();
    }

    public const string BUTTON_INSERT_ADJACENT_HTML = "htmlelement-insert-adjacent-html";
    private async Task InsertAdjacentHTML() {
        await HTMLElement.InsertAdjacentHTML("afterbegin", TEST_INSERT_HTML);
    }

    public const string BUTTON_INSERT_ADJACENT_TEXT = "htmlelement-insert-adjacent-text";
    private async Task InsertAdjacentText() {
        await HTMLElement.InsertAdjacentText("afterbegin", TEST_CUSTOM_VALUE);
    }


    public const string BUTTON_REMOVE_CHILD = "htmlelement-remove-child";
    private async Task RemoveChild() {
        await HTMLElement.RemoveChild(HiddenElement);
    }

    public const string BUTTON_REMOVE = "htmlelement-remove";
    private async Task Remove() {
        await HTMLElement.Remove();
    }

    public const string BUTTON_REPLACE_CHILD = "htmlelement-replace-child";
    private async Task ReplaceChild() {
        await HTMLElement.ReplaceChild(PopoverElement, HiddenElement);
    }

    public const string BUTTON_REPLACE_CHILD_INDEX = "htmlelement-replace-child-index";
    private async Task ReplaceChild_Index() {
        await HTMLElement.ReplaceChild(PopoverElement, 0);
    }

    public const string BUTTON_REPLACE_WITH_STRING = "htmlelement-replace-with-string";
    private async Task ReplaceWith_String() {
        await HTMLElement.ReplaceWith([TEST_CUSTOM_VALUE]);
    }

    public const string BUTTON_REPLACE_WITH_HTML_ELEMENT = "htmlelement-replace-with-html-element";
    private async Task ReplaceWith_HtmlElement() {
        await HTMLElement.ReplaceWith([HiddenElement]);
    }

    public const string BUTTON_REPLACE_CHILDREN_STRING = "htmlelement-replace-children-string";
    private async Task ReplaceChildren_String() {
        await HTMLElement.ReplaceChildren([TEST_CUSTOM_VALUE]);
    }

    public const string BUTTON_REPLACE_CHILDREN_HTML_ELEMENT = "htmlelement-replace-children-html-element";
    private async Task ReplaceChildren_HtmlElement() {
        await HTMLElement.ReplaceChildren([HiddenElement]);
    }


    public const string BUTTON_CLONE_NODE = "htmlelement-clone-node";
    private async Task CloneNode() {
        await using IHTMLElement clonedElement = await HTMLElement.CloneNode();
        labelOutput = (clonedElement is not null).ToString();
    }

    public const string BUTTON_IS_SAME_NODE = "htmlelement-is-same-node";
    private async Task IsSameNode() {
        bool isSameNode = await HTMLElement.IsSameNode(HTMLElement);
        labelOutput = isSameNode.ToString();
    }

    public const string BUTTON_IS_EQUAL_NODE = "htmlelement-is-equal-node";
    private async Task IsEqualNode() {
        bool isEqualNode = await HTMLElement.IsEqualNode(HTMLElement);
        labelOutput = isEqualNode.ToString();
    }

    public const string BUTTON_CONTAINS = "htmlelement-contains";
    private async Task Contains() {
        bool contains = await HTMLElement.Contains(HiddenElement);
        labelOutput = contains.ToString();
    }

    public const string BUTTON_COMPARE_DOCUMENT_POSITION = "htmlelement-compare-document-position";
    private async Task CompareDocumentPosition() {
        int comparison = await HTMLElement.CompareDocumentPosition(HiddenElement);
        labelOutput = comparison.ToString();
    }


    // events

    public const string BUTTON_REGISTER_ON_TRANSITIONSTART = "htmlelement-transitionstart-event";
    private void RegisterOnTransitionstart() {
        HTMLElement.OnTransitionstart += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_TRANSITIONSTART_EVENT}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITIONEND = "htmlelement-transitionend-event";
    private void RegisterOnTransitionend() {
        HTMLElement.OnTransitionend += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_TRANSITIONEND_EVENT}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITIONRUN = "htmlelement-transitionrun-event";
    private void RegisterOnTransitionrun() {
        HTMLElement.OnTransitionrun += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_TRANSITIONRUN_EVENT}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITIONCANCEL = "htmlelement-transitioncancel-event";
    private void RegisterOnTransitioncancel() {
        HTMLElement.OnTransitioncancel += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_TRANSITIONCANCEL_EVENT}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_ANIMATIONSTART = "htmlelement-animationstart-event";
    private void RegisterOnAnimationstart() {
        HTMLElement.OnAnimationstart += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_ANIMATIONSTART_EVENT}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATIONEND = "htmlelement-animationend-event";
    private void RegisterOnAnimationend() {
        HTMLElement.OnAnimationend += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_ANIMATIONEND_EVENT}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATIONITERATION = "htmlelement-animationiteration-event";
    private void RegisterOnAnimationiteration() {
        HTMLElement.OnAnimationiteration += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_ANIMATIONITERATION_EVENT}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATIONCANCEL = "htmlelement-animationcancel-event";
    private void RegisterOnAnimationcancel() {
        HTMLElement.OnAnimationcancel += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_ANIMATIONCANCEL_EVENT}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    #endregion
}
