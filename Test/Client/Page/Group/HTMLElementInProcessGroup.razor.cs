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

    // Element
    public const string TEST_INNERHTML = "<span>innerhtml</span>-test";
    public const string TEST_OUTERHTML = "<span>outerhtml</span>-test";
    public const string TEST_CLASSNAME = "classname-test";

    public const int TEST_SCROLLLEFT = 16;
    public const int TEST_SCROLLTOP = 18;
    public const int TEST_SCROLL_LEFT = 6;
    public const int TEST_SCROLL_TOP = 8;
    public const int TEST_SCROLL_BY_X = 10;
    public const int TEST_SCROLL_BY_Y = 12;

    public const string TEST_TRANSITIONSTART_EVENT = "transitionstart-event-test";
    public const string TEST_TRANSITIONEND_EVENT = "transitionend-event-test";
    public const string TEST_TRANSITIONRUN_EVENT = "transitionrun-event-test";
    public const string TEST_TRANSITIONCANCEL_EVENT = "transitioncancel-event-test";
    public const string TEST_ANIMATIONSTART_EVENT = "animationstart-event-test";
    public const string TEST_ANIMATIONEND_EVENT = "animationend-event-test";
    public const string TEST_ANIMATIONITERATION_EVENT = "animationiteration-event-test";
    public const string TEST_ANIMATIONCANCEL_EVENT = "animationcancel-event-test";


    [Inject]
    public required IElementFactoryInProcess ElementFactory { private get; init; }


    private IHTMLElementInProcess? _htmlElement;
    private IHTMLElementInProcess HTMLElement => _htmlElement ??= ElementFactory.CreateHTMLElement(htmlElement);


    private IHTMLElementInProcess? _popoverElement;
    private IHTMLElementInProcess PopoverElement => _popoverElement ??= ElementFactory.CreateHTMLElement(popoverElement);


    public const string LABEL_OUTPUT = "htmlelement-inprocess-output";
    private string labelOutput = string.Empty;

    public const string HTML_ELEMENT_CONTAINER = "htmlelement-inprocess-html-element-container";
    public const string HTML_ELEMENT = "htmlelement-inprocess-html-element";
    private ElementReference htmlElement;

    public const string POPOVER_ELEMENT = "htmlelement-inprocess-popover-element";
    private ElementReference popoverElement;

    public void Dispose() {
        _htmlElement?.Dispose();
        _popoverElement?.Dispose();
    }


    #region HTMLElement

    public const string BUTTON_GET_ACCESS_KEY = "htmlelement-inprocess-get-access-key";
    public void GetAccessKey() {
        string accessKey = HTMLElement.AccessKey;
        labelOutput = accessKey;
    }

    public const string BUTTON_SET_ACCESS_KEY = "htmlelement-inprocess-set-access-key";
    private void SetAccessKey() {
        HTMLElement.AccessKey = TEST_ACCESS_KEY;
    }


    public const string BUTTON_GET_ACCESS_KEY_LABEL = "htmlelement-inprocess-get-access-key-label";
    public void GetAccessKeyLabel() {
        string accessKeyLabel = HTMLElement.AccessKeyLabel;
        labelOutput = accessKeyLabel;
    }


    public const string BUTTON_GET_ATTRIBUTE_STYLE_MAP = "htmlelement-inprocess-get-attribute-style-map";
    public void GetAttributeStyleMap() {
        Dictionary<string, string> attributeStyleMap = HTMLElement.AttributeStyleMap;
        labelOutput = string.Join(", ", attributeStyleMap.Select(pair => $"{pair.Key} = {pair.Value}"));
    }

    public const string BUTTON_SET_ATTRIBUTE_STYLE_MAP = "htmlelement-inprocess-set-attribute-style-map";
    public void SetAttributeStyleMap() {
        HTMLElement.SetAttributeStyleMap(TEST_STYLE_NAME, TEST_STYLE_VALUE);
    }

    public const string BUTTON_REMOVE_ATTRIBUTE_STYLE_MAP = "htmlelement-inprocess-remove-attribute-style-map";
    public void RemoveAttributeStyleMap() {
        HTMLElement.RemoveAttributeStyleMap(TEST_STYLE_NAME);
    }


    public const string BUTTON_GET_AUTOCAPITALIZE = "htmlelement-inprocess-get-autocapitalize";
    public void GetAutocapitalize() {
        string autocapitalize = HTMLElement.Autocapitalize;
        labelOutput = autocapitalize;
    }

    public const string BUTTON_SET_AUTOCAPITALIZE = "htmlelement-inprocess-set-autocapitalize";
    private void SetAutocapitalize() {
        HTMLElement.Autocapitalize = TEST_AUTOCAPITALIZE;
    }


    public const string BUTTON_GET_AUTOFOCUS = "htmlelement-inprocess-get-autofocus";
    public void GetAutofocus() {
        bool autofocus = HTMLElement.Autofocus;
        labelOutput = autofocus.ToString();
    }

    public const string BUTTON_SET_AUTOFOCUS = "htmlelement-inprocess-set-autofocus";
    private void SetAutofocus() {
        HTMLElement.Autofocus = true;
    }


    public const string BUTTON_GET_CONTENT_EDITABLE = "htmlelement-inprocess-get-content-editable";
    public void GetContentEditable() {
        string contentEditable = HTMLElement.ContentEditable;
        labelOutput = contentEditable;
    }

    public const string BUTTON_SET_CONTENT_EDITABLE = "htmlelement-inprocess-set-content-editable";
    private void SetContentEditable() {
        HTMLElement.ContentEditable = "true";
    }


    public const string BUTTON_GET_DATASET = "htmlelement-inprocess-get-dataset";
    public void GetDataset() {
        Dictionary<string, string> dataset = HTMLElement.Dataset;
        labelOutput = string.Join(", ", dataset.Select(pair => $"{pair.Key} = {pair.Value}"));
    }

    public const string BUTTON_SET_DATASET = "htmlelement-inprocess-set-dataset";
    public void SetDataset() {
        HTMLElement.SetDataset(TEST_DATASET_NAME, TEST_DATASET_VALUE);
    }

    public const string BUTTON_REMOVE_DATASET = "htmlelement-inprocess-remove-dataset";
    public void RemoveDataset() {
        HTMLElement.RemoveDataset(TEST_DATASET_NAME);
    }


    public const string BUTTON_GET_DIR = "htmlelement-inprocess-get-dir";
    public void GetDir() {
        string dir = HTMLElement.Dir;
        labelOutput = dir;
    }

    public const string BUTTON_SET_DIR = "htmlelement-inprocess-set-dir";
    private void SetDir() {
        HTMLElement.Dir = TEST_DIR;
    }


    public const string BUTTON_GET_DRAGGABLE = "htmlelement-inprocess-get-draggable";
    public void GetDraggable() {
        bool draggable = HTMLElement.Draggable;
        labelOutput = draggable.ToString();
    }

    public const string BUTTON_SET_DRAGGABLE = "htmlelement-inprocess-set-draggable";
    private void SetDraggable() {
        HTMLElement.Draggable = true;
    }


    public const string BUTTON_GET_ENTER_KEY_HINT = "htmlelement-inprocess-get-enter-key-hint";
    public void GetEnterKeyHint() {
        string enterKeyHint = HTMLElement.EnterKeyHint;
        labelOutput = enterKeyHint;
    }

    public const string BUTTON_SET_ENTER_KEY_HINT = "htmlelement-inprocess-set-enter-key-hint";
    private void SetEnterKeyHint() {
        HTMLElement.EnterKeyHint = TEST_ENTER_KEY_HINT;
    }


    public const string BUTTON_GET_HIDDEN = "htmlelement-inprocess-get-hidden";
    public void GetHidden() {
        bool hidden = HTMLElement.Hidden;
        labelOutput = hidden.ToString();
    }

    public const string BUTTON_SET_HIDDEN = "htmlelement-inprocess-set-hidden";
    private void SetHidden() {
        HTMLElement.Hidden = true;
    }


    public const string BUTTON_GET_INERT = "htmlelement-inprocess-get-inert";
    public void GetInert() {
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
    public void GetInputMode() {
        string inputMode = HTMLElement.InputMode;
        labelOutput = inputMode;
    }

    public const string BUTTON_SET_INPUT_MODE = "htmlelement-inprocess-set-input-mode";
    private void SetInputMode() {
        HTMLElement.InputMode = TEST_INPUT_MODE;
    }


    public const string BUTTON_GET_IS_CONTENT_EDITABLE = "htmlelement-inprocess-get-is-content-editable";
    public void GetIsContentEditable() {
        bool isContentEditable = HTMLElement.IsContentEditable;
        labelOutput = isContentEditable.ToString();
    }


    public const string BUTTON_GET_LANG = "htmlelement-inprocess-get-lang";
    public void GetLang() {
        string lang = HTMLElement.Lang;
        labelOutput = lang;
    }

    public const string BUTTON_SET_LANG = "htmlelement-inprocess-set-lang";
    private void SetLang() {
        HTMLElement.Lang = TEST_LANG;
    }


    public const string BUTTON_GET_NONCE = "htmlelement-inprocess-get-nonce";
    public void GetNonce() {
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
    public void GetPopover() {
        string? popover = HTMLElement.Popover;
        labelOutput = popover ?? "(empty)";
    }

    public const string BUTTON_SET_POPOVER = "htmlelement-inprocess-set-popover";
    private void SetPopover() {
        HTMLElement.Popover = TEST_POPOVER;
    }


    public const string BUTTON_GET_SPELLCHECK = "htmlelement-inprocess-get-spellcheck";
    public void GetSpellcheck() {
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
    public void GetTabIndex() {
        long tabIndex = HTMLElement.TabIndex;
        labelOutput = tabIndex.ToString();
    }

    public const string BUTTON_SET_TAB_INDEX = "htmlelement-inprocess-set-tab-index";
    private void SetTabIndex() {
        HTMLElement.TabIndex = TEST_TAB_INDEX;
    }


    public const string BUTTON_GET_TITLE = "htmlelement-inprocess-get-title";
    public void GetTitle() {
        string title = HTMLElement.Title;
        labelOutput = title;
    }

    public const string BUTTON_SET_TITLE = "htmlelement-inprocess-set-title";
    private void SetTitle() {
        HTMLElement.Title = TEST_TITLE;
    }


    public const string BUTTON_GET_TRANSLATE = "htmlelement-inprocess-get-translate";
    public void GetTranslate() {
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

    #endregion


    #region Element

    public const string BUTTON_GET_INNERHTML = "htmlelement-inprocess-get-innerhtml";
    private void GetInnerHTML() {
        string innerHTML = HTMLElement.InnerHTML;
        labelOutput = innerHTML;
    }

    public const string BUTTON_SET_INNERHTML = "htmlelement-inprocess-set-innerhtml";
    private void SetInnerHTML() {
        HTMLElement.InnerHTML = TEST_INNERHTML;
    }


    public const string BUTTON_GET_OUTERHTML = "htmlelement-inprocess-get-outerhtml";
    private void GetOuterHTML() {
        string outerHTML = HTMLElement.OuterHTML;
        labelOutput = outerHTML;
    }

    public const string BUTTON_SET_OUTERHTML = "htmlelement-inprocess-set-outerhtml";
    private void SetOuterHTML() {
        HTMLElement.OuterHTML = TEST_OUTERHTML;
    }


    public const string BUTTON_GET_ATTRIBUTES = "htmlelement-inprocess-get-attributes";
    private void GetAttributes() {
        Dictionary<string, string> attributes = HTMLElement.Attributes;
        labelOutput = JsonSerializer.Serialize(attributes);
    }


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


    public const string BUTTON_GET_CLASSNAME = "htmlelement-inprocess-get-classname";
    private void GetClassName() {
        string className = HTMLElement.ClassName;
        labelOutput = className;
    }

    public const string BUTTON_SET_CLASSNAME = "htmlelement-inprocess-set-classname";
    private void SetClassName() {
        HTMLElement.ClassName = TEST_CLASSNAME;
    }


    public const string BUTTON_GET_CLASSLIST = "htmlelement-inprocess-get-classlist";
    private void GetClassList() {
        string[] classList = HTMLElement.ClassList;
        labelOutput = string.Join(',', classList);
    }



    public const string BUTTON_GET_CLIENTWIDTH = "htmlelement-inprocess-get-clientwidth";
    private void GetClientWidth() {
        int clientWidth = HTMLElement.ClientWidth;
        labelOutput = clientWidth.ToString();
    }


    public const string BUTTON_GET_CLIENTHEIGHT = "htmlelement-inprocess-get-clientheight";
    private void GetClientHeight() {
        int clientHeight = HTMLElement.ClientHeight;
        labelOutput = clientHeight.ToString();
    }


    public const string BUTTON_GET_CLIENTLEFT = "htmlelement-inprocess-get-clientleft";
    private void GetClientLeft() {
        int clientLeft = HTMLElement.ClientLeft;
        labelOutput = clientLeft.ToString();
    }


    public const string BUTTON_GET_CLIENTTOP = "htmlelement-inprocess-get-clienttop";
    private void GetClientTop() {
        int clientTop = HTMLElement.ClientTop;
        labelOutput = clientTop.ToString();
    }



    public const string BUTTON_GET_SCROLLWIDTH = "htmlelement-inprocess-get-scrollwidth";
    private void GetScrollWidth() {
        int ScrollWidth = HTMLElement.ScrollWidth;
        labelOutput = ScrollWidth.ToString();
    }


    public const string BUTTON_GET_SCROLLHEIGHT = "htmlelement-inprocess-get-scrollheight";
    private void GetScrollHeight() {
        int ScrollHeight = HTMLElement.ScrollHeight;
        labelOutput = ScrollHeight.ToString();
    }


    public const string BUTTON_GET_SCROLLLEFT = "htmlelement-inprocess-get-scrollleft";
    private void GetScrollLeft() {
        int ScrollLeft = HTMLElement.ScrollLeft;
        labelOutput = ScrollLeft.ToString();
    }

    public const string BUTTON_SET_SCROLLLEFT = "htmlelement-inprocess-set-scrollleft";
    private void SetScrollLeft() {
        HTMLElement.ScrollLeft = TEST_SCROLLLEFT;
    }


    public const string BUTTON_GET_SCROLLTOP = "htmlelement-inprocess-get-scrolltop";
    private void GetScrollTop() {
        int ScrollTop = HTMLElement.ScrollTop;
        labelOutput = ScrollTop.ToString();
    }

    public const string BUTTON_SET_SCROLLTOP = "htmlelement-inprocess-set-scrolltop";
    private void SetScrollTop() {
        HTMLElement.ScrollTop = TEST_SCROLLTOP;
    }


    // methods

    public const string BUTTON_GET_BOUNDING_CLIENT_RECT = "htmlelement-inprocess-get-bounding-client-rect";
    private void GetBoundingClientRect() {
        DOMRect boundingClientRect = HTMLElement.GetBoundingClientRect();
        labelOutput = JsonSerializer.Serialize(boundingClientRect);
    }

    public const string BUTTON_GET_CLIENT_RECTS = "htmlelement-inprocess-get-client-rects";
    private void GetClientRects() {
        DOMRect[] boundingClientRect = HTMLElement.GetClientRects();
        labelOutput = string.Join(';', boundingClientRect.Select(rect => JsonSerializer.Serialize(rect)));
    }


    public const string BUTTON_HAS_ATTRIBUTE = "htmlelement-inprocess-has-attribute";
    private void HasAttribute() {
        bool hasAttribute = HTMLElement.HasAttribute("data-testid");
        labelOutput = hasAttribute.ToString();
    }

    public const string BUTTON_HAS_ATTRIBUTES = "htmlelement-inprocess-has-attributes";
    private void HasAttributes() {
        bool hasAttributes = HTMLElement.HasAttributes();
        labelOutput = hasAttributes.ToString();
    }


    private void SetPointerCapture(PointerEventArgs e) {
        HTMLElement.SetPointerCapture(e.PointerId);
    }

    private void ReleasePointerCapture(PointerEventArgs e) {
        HTMLElement.ReleasePointerCapture(e.PointerId);
    }

    private void HasPointerCapture(PointerEventArgs e) {
        bool hasPointerCapture = HTMLElement.HasPointerCapture(e.PointerId);
        labelOutput = hasPointerCapture.ToString();
    }


    public const string BUTTON_SCROLL = "htmlelement-inprocess-scroll";
    private void Scroll() {
        HTMLElement.Scroll(TEST_SCROLL_LEFT, TEST_SCROLL_TOP);
    }

    public const string BUTTON_SCROLL_BY = "htmlelement-inprocess-scroll-by";
    private void ScrollBy() {
        HTMLElement.ScrollBy(TEST_SCROLL_BY_X, TEST_SCROLL_BY_Y);
    }

    public const string BUTTON_SCROLL_INTO_VIEW = "htmlelement-inprocess-scroll-into-view";
    private void ScrollIntoView() {
        HTMLElement.ScrollIntoView();
    }


    public const string BUTTON_REQUEST_FULLSCREEN = "htmlelement-inprocess-request-fullscreen";
    private async Task RequestFullscreen() {
        await HTMLElement.RequestFullscreen();
    }


    // events

    public const string BUTTON_REGISTER_ON_TRANSITIONSTART = "htmlelement-inprocess-transitionstart-event";
    private void RegisterOnTransitionstart() {
        HTMLElement.OnTransitionstart += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_TRANSITIONSTART_EVENT}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITIONEND = "htmlelement-inprocess-transitionend-event";
    private void RegisterOnTransitionend() {
        HTMLElement.OnTransitionend += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_TRANSITIONEND_EVENT}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITIONRUN = "htmlelement-inprocess-transitionrun-event";
    private void RegisterOnTransitionrun() {
        HTMLElement.OnTransitionrun += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_TRANSITIONRUN_EVENT}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITIONCANCEL = "htmlelement-inprocess-transitioncancel-event";
    private void RegisterOnTransitioncancel() {
        HTMLElement.OnTransitioncancel += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_TRANSITIONCANCEL_EVENT}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_ANIMATIONSTART = "htmlelement-inprocess-animationstart-event";
    private void RegisterOnAnimationstart() {
        HTMLElement.OnAnimationstart += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_ANIMATIONSTART_EVENT}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATIONEND = "htmlelement-inprocess-animationend-event";
    private void RegisterOnAnimationend() {
        HTMLElement.OnAnimationend += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_ANIMATIONEND_EVENT}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATIONITERATION = "htmlelement-inprocess-animationiteration-event";
    private void RegisterOnAnimationiteration() {
        HTMLElement.OnAnimationiteration += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_ANIMATIONITERATION_EVENT}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATIONCANCEL = "htmlelement-inprocess-animationcancel-event";
    private void RegisterOnAnimationcancel() {
        HTMLElement.OnAnimationcancel += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_ANIMATIONCANCEL_EVENT}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    #endregion
}
