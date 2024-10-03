using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using System.Text.Json;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class HTMLElement(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    #region HTMLElement

    [Fact]
    public async Task GetInnerText_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_INNERTEXT_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("test bold italic underlined", result);
    }

    [Fact]
    public async Task GetInnerText_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_INNERTEXT_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("test bold italic underlined", result);
    }

    [Fact]
    public async Task SetInnerText() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_INNERTEXT).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).InnerHTMLAsync();
        string expected = HTMLElementGroup.TEST_INNERTEXT.Replace("<", "&lt;").Replace(">", "&gt;");
        Assert.Equal(expected, result);
    }


    [Fact]
    public async Task GetOuterText_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OUTERTEXT_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("test bold italic underlined", result);
    }

    [Fact]
    public async Task GetOuterText_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OUTERTEXT_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("test bold italic underlined", result);
    }

    [Fact]
    public async Task SetOuterText() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_OUTERTEXT).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).InnerHTMLAsync();
        string expected = HTMLElementGroup.TEST_OUTERTEXT.Replace("<", "&lt;").Replace(">", "&gt;");
        Assert.Equal(expected, result);
    }


    [Fact]
    public async Task GetStyle_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_STYLE_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("visibility: visible;", result);
    }

    [Fact]
    public async Task GetStyle_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_STYLE_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("visibility: visible;", result);
    }

    [Fact]
    public async Task SetStyle() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_STYLE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("style");
        Assert.Equal(HTMLElementGroup.TEST_STYLE, result);
    }



    [Fact]
    public async Task GetOffsetWidth_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETWIDTH_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }

    [Fact]
    public async Task GetOffsetWidth_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETWIDTH_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetOffsetHeight_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETHEIGHT_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }

    [Fact]
    public async Task GetOffsetHeight_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETHEIGHT_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetOffsetLeft_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETLEFT_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }

    [Fact]
    public async Task GetOffsetLeft_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETLEFT_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetOffsetTop_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETTOP_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }

    [Fact]
    public async Task GetOffsetTop_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETTOP_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetOffsetParent_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETPARENT_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }

    [Fact]
    public async Task GetOffsetParent_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETPARENT_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }



    [Fact]
    public async Task HasFocus_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.focus();");

        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_HASFOCUS_PROPERTY).HoverAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }

    [Fact]
    public async Task HasFocus_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.focus();");

        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_HASFOCUS_METHOD).HoverAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }


    [Fact]
    public async Task Click() {
        bool consoleClicked = false;
        Page.Console += ConsoleListener;
        void ConsoleListener(object? sender, IConsoleMessage message) => consoleClicked = message.Text == "clicked";
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.addEventListener('click', () => console.log('clicked'));");

        await Page.GetByTestId(HTMLElementGroup.BUTTON_CLICK).ClickAsync();

        Page.Console -= ConsoleListener;
        Assert.True(consoleClicked);
    }

    [Fact]
    public async Task Focus() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_FOCUS).ClickAsync();

        bool hasFocus = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<bool>("node => node === document.activeElement;");
        Assert.True(hasFocus);
    }

    [Fact]
    public async Task Blur() {
        ILocator htmlElement = Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT);

        // set focus
        {
            await htmlElement.EvaluateAsync("node => node.focus()");
            bool hasFocus = await htmlElement.EvaluateAsync<bool>("node => node === document.activeElement;");
            Assert.True(hasFocus);
        }

        await Page.GetByTestId(HTMLElementGroup.BUTTON_BLUR).HoverAsync();

        // has no focus anymore
        {
            bool hasFocus = await htmlElement.EvaluateAsync<bool>("node => node === document.activeElement;");
            Assert.False(hasFocus);
        }
    }

    [Fact]
    public async Task ShowPopover() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SHOW_POPOVER).ClickAsync();

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
        Assert.True(visible);
    }

    [Fact]
    public async Task HidePopover() {
        // show popover
        {
            await Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.showPopover();");

            bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
            Assert.True(visible);
        }

        // hide again
        {
            await Page.GetByTestId(HTMLElementGroup.BUTTON_HIDE_POPOVER).ClickAsync();

            bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
            Assert.False(visible);
        }
    }

    [Fact]
    public async Task TogglePopover() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_TOGGLE_POPOVER).ClickAsync();

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
        Assert.True(visible);
    }

    [Fact]
    public async Task TogglePopoverParameter() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_TOGGLE_POPOVER_PARAMETER).ClickAsync();

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
        Assert.False(visible);
    }

    #endregion


    #region Element

    [Fact]
    public async Task GetInnerHtml_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_INNERHTML_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("<!--!-->\n            test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u>", result);
    }

    [Fact]
    public async Task GetInnerHtml_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_INNERHTML_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("<!--!-->\n            test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u>", result);
    }

    [Fact]
    public async Task SetInnerHtml() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_INNERHTML).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).InnerHTMLAsync();
        string expected = HTMLElementGroup.TEST_INNERHTML;
        Assert.Equal(expected, result);
    }


    [Fact]
    public async Task GetOuterHtml_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OUTERHTML_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        const string expected = """
            <div data-testid="htmlelement-html-element" class="html-element" tabindex="-1" style="visibility: visible;" _bl_4=""><!--!-->
                        test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u></div>
            """;
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task GetOuterHtml_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OUTERHTML_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        const string expected = """
            <div data-testid="htmlelement-html-element" class="html-element" tabindex="-1" style="visibility: visible;" _bl_4=""><!--!-->
                        test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u></div>
            """;
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task SetOuterHtml() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_OUTERHTML).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).InnerHTMLAsync();
        string expected = HTMLElementGroup.TEST_OUTERHTML;
        Assert.Equal(expected, result);
    }


    [Fact]
    public async Task GetAttributes_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_ATTRIBUTES_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("""{"data-testid":"htmlelement-html-element","class":"html-element","tabindex":"-1","style":"visibility: visible;","_bl_4":""}""", result);
    }

    [Fact]
    public async Task GetAttributes_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_ATTRIBUTES_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("""{"data-testid":"htmlelement-html-element","class":"html-element","tabindex":"-1","style":"visibility: visible;","_bl_4":""}""", result);
    }


    [Fact]
    public async Task GetChildElementCount_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CHILD_ELEMENT_COUNT_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("3", result);
    }

    [Fact]
    public async Task GetChildElementCount_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CHILD_ELEMENT_COUNT_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("3", result);
    }


    [Fact]
    public async Task GetChildren_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CHILDREN_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("3", result);
    }

    [Fact]
    public async Task GetChildren_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CHILDREN_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("3", result);
    }


    [Fact]
    public async Task GetClassName_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLASSNAME_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("html-element", result);
    }

    [Fact]
    public async Task GetClassName_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLASSNAME_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("html-element", result);
    }

    [Fact]
    public async Task SetClassName() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_CLASSNAME).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.className;");
        Assert.Equal(HTMLElementGroup.TEST_CLASSNAME, result);
    }


    [Fact]
    public async Task GetClassList_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLASSLIST_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("html-element", result);
    }

    [Fact]
    public async Task GetClassList_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLASSLIST_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("html-element", result);
    }



    [Fact]
    public async Task GetClientWidth_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLIENTWIDTH_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }

    [Fact]
    public async Task GetClientWidth_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLIENTWIDTH_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetClientHeight_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLIENTHEIGHT_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }

    [Fact]
    public async Task GetClientHeight_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLIENTHEIGHT_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetClientLeft_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLIENTLEFT_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }

    [Fact]
    public async Task GetClientLeft_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLIENTLEFT_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetClientTop_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLIENTTOP_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }

    [Fact]
    public async Task GetClientTop_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLIENTTOP_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }



    [Fact]
    public async Task GetScrollWidth_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_SCROLLWIDTH_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 50);
    }

    [Fact]
    public async Task GetScrollWidth_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_SCROLLWIDTH_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 50);
    }


    [Fact]
    public async Task GetScrollHeight_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_SCROLLHEIGHT_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 50);
    }

    [Fact]
    public async Task GetScrollHeight_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_SCROLLHEIGHT_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 50);
    }


    [Fact]
    public async Task GetScrollLeft_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_SCROLLLEFT_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.Equal(0, resultAsNumber);
    }

    [Fact]
    public async Task GetScrollLeft_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_SCROLLLEFT_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.Equal(0, resultAsNumber);
    }

    [Fact]
    public async Task SetScrollLeft() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_SCROLLLEFT).ClickAsync();

        int result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        Assert.True(result > 0);
    }


    [Fact]
    public async Task GetScrollTop_Property() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_SCROLLTOP_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.Equal(0, resultAsNumber);
    }

    [Fact]
    public async Task GetScrollTop_Method() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_SCROLLTOP_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.Equal(0, resultAsNumber);
    }

    [Fact]
    public async Task SetScrollTop() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_SCROLLTOP).ClickAsync();

        int result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        Assert.True(result > 0);
    }



    [Fact]
    public async Task GetBoundingClientRect() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_BOUNDING_CLIENT_RECT).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.True(result?.Length > 0);

        DOMRect? domRect = JsonSerializer.Deserialize<DOMRect?>(result);
        Assert.NotNull(domRect);
    }

    [Fact]
    public async Task GetClientRects() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLIENT_RECTS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.True(result?.Length > 0);

        foreach (string json in result.Split(';')) {
            DOMRect? domRect = JsonSerializer.Deserialize<DOMRect?>(json);
            Assert.NotNull(domRect);
        }
    }


    [Fact]
    public async Task HasAttribute() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_HAS_ATTRIBUTE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }

    [Fact]
    public async Task HasAttributes() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_HAS_ATTRIBUTES).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }


    [Fact]
    public async Task PointerCapture() {
        ILocator htmlElement = Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT);
        ILocator labelOutput = Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT);

        // hasPointerCapture false
        {
            await htmlElement.HoverAsync();
            string? result = await labelOutput.TextContentAsync();
            Assert.Equal("False", result);
        }

        await Page.Mouse.DownAsync();

        // hasPointerCapture true
        {
            await Page.Mouse.MoveAsync(1, 1);
            string? result = await labelOutput.TextContentAsync();
            Assert.Equal("True", result);
        }

        await Page.Mouse.UpAsync();

        // hasPointerCapture false
        {
            await htmlElement.HoverAsync();
            string? result = await labelOutput.TextContentAsync();
            Assert.Equal("False", result);
        }
    }


    [Fact]
    public async Task Scroll() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SCROLL).ClickAsync();

        int resultLeft = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        Assert.True(resultLeft > 0);
        int resultTop = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        Assert.True(resultTop > 0);
    }

    [Fact]
    public async Task ScrollBy() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SCROLL_BY).ClickAsync();

        int resultLeft = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        Assert.True(resultLeft > 0);
        int resultTop = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        Assert.True(resultTop > 0);
    }

    [Fact]
    public async Task ScrollIntoView() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SCROLL_INTO_VIEW).HoverAsync();
        int initial = await Page.EvaluateAsync<int>("window.scrollY;");

        await Page.GetByTestId(HTMLElementGroup.BUTTON_SCROLL_INTO_VIEW).ClickAsync();
        await Task.Delay(100);
        int scrolled = await Page.EvaluateAsync<int>("window.scrollY;");

        Assert.True(scrolled > initial);
    }


    [Fact]
    public async Task RequestFullscreen() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REQUEST_FULLSCREEN).ClickAsync();
    }



    [Fact]
    public async Task RegisterOnTransitionstart() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITIONSTART).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementGroup.TEST_TRANSITIONSTART_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnTransitionend() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITIONEND).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(600);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementGroup.TEST_TRANSITIONEND_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnTransitionrun() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITIONRUN).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementGroup.TEST_TRANSITIONRUN_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnTransitioncancel() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITIONCANCEL).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#222';");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementGroup.TEST_TRANSITIONCANCEL_EVENT, result);
    }


    [Fact]
    public async Task RegisterOnAnimationstart() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATIONSTART).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementGroup.TEST_ANIMATIONSTART_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnAnimationnend() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATIONEND).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(600);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementGroup.TEST_ANIMATIONEND_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnAnimationiteration() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATIONITERATION).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start-infinite');");
        await Task.Delay(600);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementGroup.TEST_ANIMATIONITERATION_EVENT, result);
    }

    // does not work in Chromium Browser. To make this test work, go to PlayWrightFixture.InitializeAsync() and change "Chromium" to "Firefox"
    //[Fact]
    //public async Task RegisterOnAnimationcancel() {
    //    await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATIONCANCEL).ClickAsync();
    //    await Task.Delay(100);

    //    await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
    //    await Task.Delay(100);
    //    await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.remove('animation-start');");
    //    await Task.Delay(100);

    //    string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
    //    //Assert.Equal(HTMLElementGroup.TEST_ANIMATIONCANCEL_EVENT, result);
    //}

    #endregion
}
