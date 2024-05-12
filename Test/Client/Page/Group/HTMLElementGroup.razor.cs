﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class HTMLElementGroup : ComponentBase, IAsyncDisposable {
    public const string TEST_INNERTEXT = "<innertext>-test";
    public const string TEST_OUTERTEXT = "<outertext>-test";
    public const string TEST_STYLE = "z-index: 5;";
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

    [Inject]
    public required IElementFactoryInProcess ElementFactoryInProcess { private get; init; }


    private IHTMLElement? _htmlElement;
    private IHTMLElement HTMLElement => _htmlElement ??= ElementFactory.CreateHTMLElement(htmlElement);

    private IHTMLElementInProcess? _htmlElementInProcess;
    private IHTMLElementInProcess HTMLElementInProcess => _htmlElementInProcess ??= ElementFactoryInProcess.CreateHTMLElement(htmlElement);


    private IHTMLElement? _popoverElement;
    private IHTMLElement PopoverElement => _popoverElement ??= ElementFactory.CreateHTMLElement(popoverElement);

    private IHTMLElementInProcess? _popoverElementInProcess;
    private IHTMLElementInProcess PopoverElementInProcess => _popoverElementInProcess ??= ElementFactoryInProcess.CreateHTMLElement(popoverElement);


    public const string LABEL_OUTPUT = "htmlelement-output";
    private string labelOutput = string.Empty;

    public const string HTML_ELEMENT_CONTAINER = "htmlelement-html-element-container";
    public const string HTML_ELEMENT = "htmlelement-html-element";
    private ElementReference htmlElement;

    public const string POPOVER_ELEMENT = "htmlelement-popover-element";
    private ElementReference popoverElement;

    public async ValueTask DisposeAsync() {
        if (_htmlElement != null)
            await _htmlElement.DisposeAsync();
        _htmlElementInProcess?.Dispose();

        if (_popoverElement != null)
            await _popoverElement.DisposeAsync();
        _popoverElementInProcess?.Dispose();
    }


    #region HTMLElement

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
        labelOutput = (offsetParent != null).ToString();
    }

    public const string BUTTON_GET_OFFSETPARENT_METHOD = "htmlelement-get-offsetparent-method";
    private async Task GetOffsetParent_Method() {
        await using IHTMLElement? offsetParent = await HTMLElement.GetOffsetParent(default);
        labelOutput = (offsetParent != null).ToString();
    }



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

        foreach (IHTMLElement child in children)
            await child.DisposeAsync();
    }

    public const string BUTTON_GET_CHILDREN_METHOD = "htmlelement-get-children-method";
    private async Task GetChildren_Method() {
        IHTMLElement[] children = await HTMLElement.GetChildren(default);
        labelOutput = children.Length.ToString();

        foreach (IHTMLElement child in children)
            await child.DisposeAsync();
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



    #region HTMLElementInProcess

    public const string BUTTON_GET_INNERTEXT_INPROCESS = "htmlelement-get-innertext-inprocess";
    private void GetInnerText_InProcess() {
        string innerText = HTMLElementInProcess.InnerText;
        labelOutput = innerText;
    }

    public const string BUTTON_SET_INNERTEXT_INPROCESS = "htmlelement-set-innertext-inprocess";
    private void SetInnerText_InProcess() {
        HTMLElementInProcess.InnerText = TEST_INNERTEXT;
    }


    public const string BUTTON_GET_OUTERTEXT_INPROCESS = "htmlelement-get-outertext-inprocess";
    private void GetOuterText_InProcess() {
        string outerText = HTMLElementInProcess.OuterText;
        labelOutput = outerText;
    }

    public const string BUTTON_SET_OUTERTEXT_INPROCESS = "htmlelement-set-outertext-inprocess";
    private void SetOuterText_InProcess() {
        HTMLElementInProcess.OuterText = TEST_OUTERTEXT;
    }


    public const string BUTTON_GET_STYLE_INPROCESS = "htmlelement-get-style-inprocess";
    private void GetStyle_InProcess() {
        string style = HTMLElementInProcess.Style;
        labelOutput = style;
    }

    public const string BUTTON_SET_STYLE_INPROCESS = "htmlelement-set-style-inprocess";
    private void SetStyle_InProcess() {
        HTMLElementInProcess.Style = TEST_STYLE;
    }



    public const string BUTTON_GET_OFFSETWIDTH_INPROCESS = "htmlelement-get-offsetwidth-inprocess";
    private void GetOffsetWidth_InProcess() {
        int offsetWidth = HTMLElementInProcess.OffsetWidth;
        labelOutput = offsetWidth.ToString();
    }


    public const string BUTTON_GET_OFFSETHEIGHT_INPROCESS = "htmlelement-get-offsetheight-inprocess";
    private void GetOffsetHeight_InProcess() {
        int offsetHeight = HTMLElementInProcess.OffsetHeight;
        labelOutput = offsetHeight.ToString();
    }


    public const string BUTTON_GET_OFFSETLEFT_INPROCESS = "htmlelement-get-offsetleft-inprocess";
    private void GetOffsetLeft_InProcess() {
        int offsetLeft = HTMLElementInProcess.OffsetLeft;
        labelOutput = offsetLeft.ToString();
    }


    public const string BUTTON_GET_OFFSETTOP_INPROCESS = "htmlelement-get-offsettop-inprocess";
    private void GetOffsetTop_InProcess() {
        int offsetTop = HTMLElementInProcess.OffsetTop;
        labelOutput = offsetTop.ToString();
    }


    public const string BUTTON_GET_OFFSETPARENT_INPROCESS = "htmlelement-get-offsetparent-inprocess";
    private void GetOffsetParent_InProcess() {
        using IHTMLElementInProcess? offsetParent = HTMLElementInProcess.OffsetParent;
        labelOutput = (offsetParent != null).ToString();
    }



    public const string BUTTON_GET_HASFOCUS_INPROCESS = "htmlelement-get-hasfocus-inprocess";
    private void GetHasFocus_InProcess() {
        bool hasFocus = HTMLElementInProcess.HasFocus;
        labelOutput = hasFocus.ToString();
    }



    public const string BUTTON_CLICK_INPROCESS = "htmlelement-click-inprocess";
    private void Click_InProcess() {
        HTMLElementInProcess.Click();
    }

    public const string BUTTON_FOCUS_INPROCESS = "htmlelement-focus-inprocess";
    private void Focus_InProcess() {
        HTMLElementInProcess.Focus(true);
        HTMLElementInProcess.Focus(false);
        HTMLElementInProcess.Focus();
    }

    public const string BUTTON_BLUR_INPROCESS = "htmlelement-blur-inprocess";
    private void Blur_InProcess() {
        HTMLElementInProcess.Blur();
    }

    public const string BUTTON_SHOW_POPOVER_INPROCESS = "htmlelement-show-popover-inprocess";
    private void ShowPopover_InProcess() {
        PopoverElementInProcess.ShowPopover();
    }

    public const string BUTTON_HIDE_POPOVER_INPROCESS = "htmlelement-hide-popover-inprocess";
    private void HidePopover_InProcess() {
        PopoverElementInProcess.HidePopover();
    }

    public const string BUTTON_TOGGLE_POPOVER_INPROCESS = "htmlelement-toggle-popover-inprocess";
    private void TogglePopover_InProcess() {
        PopoverElementInProcess.TogglePopover();
    }

    public const string BUTTON_TOGGLE_POPOVER_PARAMETER_INPROCESS = "htmlelement-toggle-popover-parameter-inprocess";
    private void TogglePopoverParameter_InProcess() {
        PopoverElementInProcess.TogglePopover(true);
        PopoverElementInProcess.TogglePopover(false);
    }

    #endregion


    #region ElementInProcess

    public const string BUTTON_GET_INNERHTML_INPROCESS = "htmlelement-get-innerhtml-inprocess";
    private void GetInnerHTML_InProcess() {
        string innerHTML = HTMLElementInProcess.InnerHTML;
        labelOutput = innerHTML;
    }

    public const string BUTTON_SET_INNERHTML_INPROCESS = "htmlelement-set-innerhtml-inprocess";
    private void SetInnerHTML_InProcess() {
        HTMLElementInProcess.InnerHTML = TEST_INNERHTML;
    }


    public const string BUTTON_GET_OUTERHTML_INPROCESS = "htmlelement-get-outerhtml-inprocess";
    private void GetOuterHTML_InProcess() {
        string outerHTML = HTMLElementInProcess.OuterHTML;
        labelOutput = outerHTML;
    }

    public const string BUTTON_SET_OUTERHTML_INPROCESS = "htmlelement-set-outerhtml-inprocess";
    private void SetOuterHTML_InProcess() {
        HTMLElementInProcess.OuterHTML = TEST_OUTERHTML;
    }


    public const string BUTTON_GET_ATTRIBUTES_INPROCESS = "htmlelement-get-attributes-inprocess";
    private void GetAttributes_InProcess() {
        Dictionary<string, string> attributes = HTMLElementInProcess.Attributes;
        labelOutput = JsonSerializer.Serialize(attributes);
    }


    public const string BUTTON_GET_CHILD_ELEMENT_COUNT_INPROCESS = "htmlelement-get-child-element-count-inprocess";
    private void GetChildElementCount_InProcess() {
        int childElementCount = HTMLElementInProcess.ChildElementCount;
        labelOutput = childElementCount.ToString();
    }


    public const string BUTTON_GET_CHILDREN_INPROCESS = "htmlelement-get-children-inprocess";
    private void GetChildren_InProcess() {
        IHTMLElementInProcess[] children = HTMLElementInProcess.Children;
        labelOutput = children.Length.ToString();

        foreach (IHTMLElementInProcess child in children)
            child.Dispose();
    }


    public const string BUTTON_GET_CLASSNAME_INPROCESS = "htmlelement-get-classname-inprocess";
    private void GetClassName_InProcess() {
        string className = HTMLElementInProcess.ClassName;
        labelOutput = className;
    }

    public const string BUTTON_SET_CLASSNAME_INPROCESS = "htmlelement-set-classname-inprocess";
    private void SetClassName_InProcess() {
        HTMLElementInProcess.ClassName = TEST_CLASSNAME;
    }


    public const string BUTTON_GET_CLASSLIST_INPROCESS = "htmlelement-get-classlist-inprocess";
    private void GetClassList_InProcess() {
        string[] classList = HTMLElementInProcess.ClassList;
        labelOutput = string.Join(',', classList);
    }



    public const string BUTTON_GET_CLIENTWIDTH_INPROCESS = "htmlelement-get-clientwidth-inprocess";
    private void GetClientWidth_InProcess() {
        int clientWidth = HTMLElementInProcess.ClientWidth;
        labelOutput = clientWidth.ToString();
    }


    public const string BUTTON_GET_CLIENTHEIGHT_INPROCESS = "htmlelement-get-clientheight-inprocess";
    private void GetClientHeight_InProcess() {
        int clientHeight = HTMLElementInProcess.ClientHeight;
        labelOutput = clientHeight.ToString();
    }


    public const string BUTTON_GET_CLIENTLEFT_INPROCESS = "htmlelement-get-clientleft-inprocess";
    private void GetClientLeft_InProcess() {
        int clientLeft = HTMLElementInProcess.ClientLeft;
        labelOutput = clientLeft.ToString();
    }


    public const string BUTTON_GET_CLIENTTOP_INPROCESS = "htmlelement-get-clienttop-inprocess";
    private void GetClientTop_InProcess() {
        int clientTop = HTMLElementInProcess.ClientTop;
        labelOutput = clientTop.ToString();
    }



    public const string BUTTON_GET_SCROLLWIDTH_INPROCESS = "htmlelement-get-scrollwidth-inprocess";
    private void GetScrollWidth_InProcess() {
        int ScrollWidth = HTMLElementInProcess.ScrollWidth;
        labelOutput = ScrollWidth.ToString();
    }


    public const string BUTTON_GET_SCROLLHEIGHT_INPROCESS = "htmlelement-get-scrollheight-inprocess";
    private void GetScrollHeight_InProcess() {
        int ScrollHeight = HTMLElementInProcess.ScrollHeight;
        labelOutput = ScrollHeight.ToString();
    }


    public const string BUTTON_GET_SCROLLLEFT_INPROCESS = "htmlelement-get-scrollleft-inprocess";
    private void GetScrollLeft_InProcess() {
        int ScrollLeft = HTMLElementInProcess.ScrollLeft;
        labelOutput = ScrollLeft.ToString();
    }

    public const string BUTTON_SET_SCROLLLEFT_INPROCESS = "htmlelement-set-scrollleft-inprocess";
    private void SetScrollLeft_InProcess() {
        HTMLElementInProcess.ScrollLeft = TEST_SCROLLLEFT;
    }


    public const string BUTTON_GET_SCROLLTOP_INPROCESS = "htmlelement-get-scrolltop-inprocess";
    private void GetScrollTop_InProcess() {
        int ScrollTop = HTMLElementInProcess.ScrollTop;
        labelOutput = ScrollTop.ToString();
    }

    public const string BUTTON_SET_SCROLLTOP_INPROCESS = "htmlelement-set-scrolltop-inprocess";
    private void SetScrollTop_InProcess() {
        HTMLElementInProcess.ScrollTop = TEST_SCROLLTOP;
    }



    public const string BUTTON_GET_BOUNDING_CLIENT_RECT_INPROCESS = "htmlelement-get-bounding-client-rect-inprocess";
    private void GetBoundingClientRect_InProcess() {
        DOMRect boundingClientRect = HTMLElementInProcess.GetBoundingClientRect();
        labelOutput = JsonSerializer.Serialize(boundingClientRect);
    }

    public const string BUTTON_GET_CLIENT_RECTS_INPROCESS = "htmlelement-get-client-rects-inprocess";
    private void GetClientRects_InProcess() {
        DOMRect[] boundingClientRect = HTMLElementInProcess.GetClientRects();
        labelOutput = string.Join(';', boundingClientRect.Select(rect => JsonSerializer.Serialize(rect)));
    }


    public const string BUTTON_HAS_ATTRIBUTE_INPROCESS = "htmlelement-has-attribute-inprocess";
    private void HasAttribute_InProcess() {
        bool hasAttribute = HTMLElementInProcess.HasAttribute("data-testid");
        labelOutput = hasAttribute.ToString();
    }

    public const string BUTTON_HAS_ATTRIBUTES_INPROCESS = "htmlelement-has-attributes-inprocess";
    private void HasAttributes_InProcess() {
        bool hasAttributes = HTMLElementInProcess.HasAttributes();
        labelOutput = hasAttributes.ToString();
    }


    private void SetPointerCapture_InProcess(PointerEventArgs e) {
        PopoverElementInProcess.SetPointerCapture(e.PointerId);
    }

    private void ReleasePointerCapture_InProcess(PointerEventArgs e) {
        PopoverElementInProcess.ReleasePointerCapture(e.PointerId);
    }

    private void HasPointerCapture_InProcess(PointerEventArgs e) {
        bool hasPointerCapture = PopoverElementInProcess.HasPointerCapture(e.PointerId);
        labelOutput = hasPointerCapture.ToString();
    }


    public const string BUTTON_SCROLL_INPROCESS = "htmlelement-scroll-inprocess";
    private void Scroll_InProcess() {
        HTMLElementInProcess.Scroll(TEST_SCROLL_LEFT, TEST_SCROLL_TOP);
    }

    public const string BUTTON_SCROLL_BY_INPROCESS = "htmlelement-scroll-by-inprocess";
    private void ScrollBy_InProcess() {
        HTMLElementInProcess.ScrollBy(TEST_SCROLL_BY_X, TEST_SCROLL_BY_Y);
    }

    public const string BUTTON_SCROLL_INTO_VIEW_INPROCESS = "htmlelement-scroll-into-view-inprocess";
    private void ScrollIntoView_InProcess() {
        HTMLElementInProcess.ScrollIntoView();
    }


    public const string BUTTON_REQUEST_FULLSCREEN_INPROCESS = "htmlelement-request-fullscreen-inprocess";
    private async Task RequestFullscreen_InProcess() {
        await HTMLElementInProcess.RequestFullscreen();
    }



    public const string BUTTON_REGISTER_ON_TRANSITIONSTART_INPROCESS = "htmlelement-transitionstart-event-inprocess";
    private void RegisterOnTransitionstart_InProcess() {
        HTMLElementInProcess.OnTransitionstart += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_TRANSITIONSTART_EVENT}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITIONEND_INPROCESS = "htmlelement-transitionend-event-inprocess";
    private void RegisterOnTransitionend_InProcess() {
        HTMLElementInProcess.OnTransitionend += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_TRANSITIONEND_EVENT}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITIONRUN_INPROCESS = "htmlelement-transitionrun-event-inprocess";
    private void RegisterOnTransitionrun_InProcess() {
        HTMLElementInProcess.OnTransitionrun += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_TRANSITIONRUN_EVENT}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITIONCANCEL_INPROCESS = "htmlelement-transitioncancel-event-inprocess";
    private void RegisterOnTransitioncancel_InProcess() {
        HTMLElementInProcess.OnTransitioncancel += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_TRANSITIONCANCEL_EVENT}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_ANIMATIONSTART_INPROCESS = "htmlelement-animationstart-event-inprocess";
    private void RegisterOnAnimationstart_InProcess() {
        HTMLElementInProcess.OnAnimationstart += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_ANIMATIONSTART_EVENT}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATIONEND_INPROCESS = "htmlelement-animationend-event-inprocess";
    private void RegisterOnAnimationend_InProcess() {
        HTMLElementInProcess.OnAnimationend += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_ANIMATIONEND_EVENT}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATIONITERATION_INPROCESS = "htmlelement-animationiteration-event-inprocess";
    private void RegisterOnAnimationiteration_InProcess() {
        HTMLElementInProcess.OnAnimationiteration += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_ANIMATIONITERATION_EVENT}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATIONCANCEL_INPROCESS = "htmlelement-animationcancel-event-inprocess";
    private void RegisterOnAnimationcancel_InProcess() {
        HTMLElementInProcess.OnAnimationcancel += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_ANIMATIONCANCEL_EVENT}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    #endregion
}
