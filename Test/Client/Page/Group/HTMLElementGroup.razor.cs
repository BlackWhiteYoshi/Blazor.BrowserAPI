using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
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
    public const string TEST_INNERHTML = "<span>innerhtml</span>-test";
    public const string TEST_OUTERHTML = "<span>outerhtml</span>-test";
    public const string TEST_CLASSNAME = "classname-test";

    public const int TEST_SCROLLLEFT = 15;
    public const int TEST_SCROLLTOP = 17;
    public const int TEST_SCROLL_LEFT = 5;
    public const int TEST_SCROLL_TOP = 7;
    public const int TEST_SCROLL_BY_X = 9;
    public const int TEST_SCROLL_BY_Y = 11;

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


    public const string LABEL_OUTPUT = "htmlelement-output";
    private string labelOutput = string.Empty;

    public const string HTML_ELEMENT_CONTAINER = "htmlelement-html-element-container";
    public const string HTML_ELEMENT = "htmlelement-html-element";
    private ElementReference htmlElement;

    public const string POPOVER_ELEMENT = "htmlelement-popover-element";
    private ElementReference popoverElement;

    public ValueTask DisposeAsync() {
        ValueTask htmlDisposing = _htmlElement?.DisposeAsync() ?? ValueTask.CompletedTask;
        ValueTask popoverDisposing = _popoverElement?.DisposeAsync() ?? ValueTask.CompletedTask;

        return (htmlDisposing.IsCompleted, popoverDisposing.IsCompleted) switch {
            (true, true) => ValueTask.CompletedTask,
            (false, true) => htmlDisposing,
            (true, false) => popoverDisposing,
            (false, false) => new ValueTask(Task.WhenAll([htmlDisposing.AsTask(), popoverDisposing.AsTask()]))
        };
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


    #region Element

    public const string BUTTON_GET_INNERHTML_PROPERTY = "htmlelement-get-innerhtml-property";
    private async Task GetInnerHTML_Property() {
        string innerHTML = await HTMLElement.InnerHTML;
        labelOutput = innerHTML;
    }

    public const string BUTTON_GET_INNERHTML_METHOD = "htmlelement-get-innerhtml-method";
    private async Task GetInnerHTML_Method() {
        string innerHTML = await HTMLElement.GetInnerHTML(default);
        labelOutput = innerHTML;
    }

    public const string BUTTON_SET_INNERHTML = "htmlelement-set-innerhtml";
    private async Task SetInnerHTML() {
        await HTMLElement.SetInnerHTML(TEST_INNERHTML);
    }


    public const string BUTTON_GET_OUTERHTML_PROPERTY = "htmlelement-get-outerhtml-property";
    private async Task GetOuterHTML_Property() {
        string outerHTML = await HTMLElement.OuterHTML;
        labelOutput = outerHTML;
    }

    public const string BUTTON_GET_OUTERHTML_METHOD = "htmlelement-get-outerhtml-method";
    private async Task GetOuterHTML_Method() {
        string outerHTML = await HTMLElement.GetOuterHTML(default);
        labelOutput = outerHTML;
    }

    public const string BUTTON_SET_OUTERHTML = "htmlelement-set-outerhtml";
    private async Task SetOuterHTML() {
        await HTMLElement.SetOuterHTML(TEST_OUTERHTML);
    }


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


    public const string BUTTON_GET_CLASSNAME_PROPERTY = "htmlelement-get-classname-property";
    private async Task GetClassName_Property() {
        string className = await HTMLElement.ClassName;
        labelOutput = className;
    }

    public const string BUTTON_GET_CLASSNAME_METHOD = "htmlelement-get-classname-method";
    private async Task GetClassName_Method() {
        string className = await HTMLElement.GetClassName(default);
        labelOutput = className;
    }

    public const string BUTTON_SET_CLASSNAME = "htmlelement-set-classname";
    private async Task SetClassName() {
        await HTMLElement.SetClassName(TEST_CLASSNAME);
    }


    public const string BUTTON_GET_CLASSLIST_PROPERTY = "htmlelement-get-classlist-property";
    private async Task GetClassList_Property() {
        string[] classList = await HTMLElement.ClassList;
        labelOutput = string.Join(',', classList);
    }

    public const string BUTTON_GET_CLASSLIST_METHOD = "htmlelement-get-classlist-method";
    private async Task GetClassList_Method() {
        string[] classList = await HTMLElement.GetClassList(default);
        labelOutput = string.Join(',', classList);
    }



    public const string BUTTON_GET_CLIENTWIDTH_PROPERTY = "htmlelement-get-clientwidth-property";
    private async Task GetClientWidth_Property() {
        int clientWidth = await HTMLElement.ClientWidth;
        labelOutput = clientWidth.ToString();
    }

    public const string BUTTON_GET_CLIENTWIDTH_METHOD = "htmlelement-get-clientwidth-method";
    private async Task GetClientWidth_Method() {
        int clientWidth = await HTMLElement.GetClientWidth(default);
        labelOutput = clientWidth.ToString();
    }


    public const string BUTTON_GET_CLIENTHEIGHT_PROPERTY = "htmlelement-get-clientheight-property";
    private async Task GetClientHeight_Property() {
        int clientHeight = await HTMLElement.ClientHeight;
        labelOutput = clientHeight.ToString();
    }

    public const string BUTTON_GET_CLIENTHEIGHT_METHOD = "htmlelement-get-clientheight-method";
    private async Task GetClientHeight_Method() {
        int clientHeight = await HTMLElement.GetClientHeight(default);
        labelOutput = clientHeight.ToString();
    }


    public const string BUTTON_GET_CLIENTLEFT_PROPERTY = "htmlelement-get-clientleft-property";
    private async Task GetClientLeft_Property() {
        int clientLeft = await HTMLElement.ClientLeft;
        labelOutput = clientLeft.ToString();
    }

    public const string BUTTON_GET_CLIENTLEFT_METHOD = "htmlelement-get-clientleft-method";
    private async Task GetClientLeft_Method() {
        int clientLeft = await HTMLElement.GetClientLeft(default);
        labelOutput = clientLeft.ToString();
    }


    public const string BUTTON_GET_CLIENTTOP_PROPERTY = "htmlelement-get-clienttop-property";
    private async Task GetClientTop_Property() {
        int clientTop = await HTMLElement.ClientTop;
        labelOutput = clientTop.ToString();
    }

    public const string BUTTON_GET_CLIENTTOP_METHOD = "htmlelement-get-clienttop-method";
    private async Task GetClientTop_Method() {
        int clientTop = await HTMLElement.GetClientTop(default);
        labelOutput = clientTop.ToString();
    }



    public const string BUTTON_GET_SCROLLWIDTH_PROPERTY = "htmlelement-get-scrollwidth-property";
    private async Task GetScrollWidth_Property() {
        int ScrollWidth = await HTMLElement.ScrollWidth;
        labelOutput = ScrollWidth.ToString();
    }

    public const string BUTTON_GET_SCROLLWIDTH_METHOD = "htmlelement-get-scrollwidth-method";
    private async Task GetScrollWidth_Method() {
        int ScrollWidth = await HTMLElement.GetScrollWidth(default);
        labelOutput = ScrollWidth.ToString();
    }


    public const string BUTTON_GET_SCROLLHEIGHT_PROPERTY = "htmlelement-get-scrollheight-property";
    private async Task GetScrollHeight_Property() {
        int ScrollHeight = await HTMLElement.ScrollHeight;
        labelOutput = ScrollHeight.ToString();
    }

    public const string BUTTON_GET_SCROLLHEIGHT_METHOD = "htmlelement-get-scrollheight-method";
    private async Task GetScrollHeight_Method() {
        int ScrollHeight = await HTMLElement.GetScrollHeight(default);
        labelOutput = ScrollHeight.ToString();
    }


    public const string BUTTON_GET_SCROLLLEFT_PROPERTY = "htmlelement-get-scrollleft-property";
    private async Task GetScrollLeft_Property() {
        int ScrollLeft = await HTMLElement.ScrollLeft;
        labelOutput = ScrollLeft.ToString();
    }

    public const string BUTTON_GET_SCROLLLEFT_METHOD = "htmlelement-get-scrollleft-method";
    private async Task GetScrollLeft_Method() {
        int ScrollLeft = await HTMLElement.GetScrollLeft(default);
        labelOutput = ScrollLeft.ToString();
    }

    public const string BUTTON_SET_SCROLLLEFT = "htmlelement-set-scrollleft";
    private async Task SetScrollLeft() {
        await HTMLElement.SetScrollLeft(TEST_SCROLLLEFT);
    }


    public const string BUTTON_GET_SCROLLTOP_PROPERTY = "htmlelement-get-scrolltop-property";
    private async Task GetScrollTop_Property() {
        int ScrollTop = await HTMLElement.ScrollTop;
        labelOutput = ScrollTop.ToString();
    }

    public const string BUTTON_GET_SCROLLTOP_METHOD = "htmlelement-get-scrolltop-method";
    private async Task GetScrollTop_Method() {
        int ScrollTop = await HTMLElement.GetScrollTop(default);
        labelOutput = ScrollTop.ToString();
    }

    public const string BUTTON_SET_SCROLLTOP = "htmlelement-set-scrolltop";
    private async Task SetScrollTop() {
        await HTMLElement.SetScrollTop(TEST_SCROLLTOP);
    }


    // methods

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


    public const string BUTTON_HAS_ATTRIBUTE = "htmlelement-has-attribute";
    private async Task HasAttribute() {
        bool hasAttribute = await HTMLElement.HasAttribute("data-testid");
        labelOutput = hasAttribute.ToString();
    }

    public const string BUTTON_HAS_ATTRIBUTES = "htmlelement-has-attributes";
    private async Task HasAttributes() {
        bool hasAttributes = await HTMLElement.HasAttributes();
        labelOutput = hasAttributes.ToString();
    }


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


    public const string BUTTON_SCROLL = "htmlelement-scroll";
    private async Task Scroll() {
        await HTMLElement.Scroll(TEST_SCROLL_LEFT, TEST_SCROLL_TOP);
    }

    public const string BUTTON_SCROLL_BY = "htmlelement-scroll-by";
    private async Task ScrollBy() {
        await HTMLElement.ScrollBy(TEST_SCROLL_BY_X, TEST_SCROLL_BY_Y);
    }

    public const string BUTTON_SCROLL_INTO_VIEW = "htmlelement-scroll-into-view";
    private async Task ScrollIntoView() {
        await HTMLElement.ScrollIntoView();
    }


    public const string BUTTON_REQUEST_FULLSCREEN = "htmlelement-request-fullscreen";
    private async Task RequestFullscreen() {
        await HTMLElement.RequestFullscreen();
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
