using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using System.Text.Json;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class HTMLElementInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    #region HTMLElement

    [Fact]
    public async Task GetInnerText_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_INNERTEXT_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("test bold italic underlined", result);
    }

    [Fact]
    public async Task SetInnerText_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_INNERTEXT_INPROCESS).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).InnerHTMLAsync();
        string expected = HTMLElementGroup.TEST_INNERTEXT.Replace("<", "&lt;").Replace(">", "&gt;");
        Assert.Equal(expected, result);
    }


    [Fact]
    public async Task GetOuterText_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OUTERTEXT_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("test bold italic underlined", result);
    }

    [Fact]
    public async Task SetOuterText_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_OUTERTEXT_INPROCESS).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).InnerHTMLAsync();
        string expected = HTMLElementGroup.TEST_OUTERTEXT.Replace("<", "&lt;").Replace(">", "&gt;");
        Assert.Equal(expected, result);
    }


    [Fact]
    public async Task GetStyle_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_STYLE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("visibility: visible;", result);
    }

    [Fact]
    public async Task SetStyle_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_STYLE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("style");
        Assert.Equal(HTMLElementGroup.TEST_STYLE, result);
    }



    [Fact]
    public async Task GetOffsetWidth_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETWIDTH_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetOffsetHeight_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETHEIGHT_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetOffsetLeft_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETLEFT_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetOffsetTop_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETTOP_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetOffsetParent_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OFFSETPARENT_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }



    [Fact]
    public async Task HasFocus_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.focus();");

        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_HASFOCUS_INPROCESS).HoverAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }


    [Fact]
    public async Task Click_InProcess() {
        bool consoleClicked = false;
        Page.Console += ConsoleListener;
        void ConsoleListener(object? sender, IConsoleMessage message) => consoleClicked = message.Text == "clicked";
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.addEventListener('click', () => console.log('clicked'));");

        await Page.GetByTestId(HTMLElementGroup.BUTTON_CLICK_INPROCESS).ClickAsync();

        Page.Console -= ConsoleListener;
        Assert.True(consoleClicked);
    }

    [Fact]
    public async Task Focus_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_FOCUS_INPROCESS).ClickAsync();

        bool hasFocus = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<bool>("node => node === document.activeElement;");
        Assert.True(hasFocus);
    }

    [Fact]
    public async Task Blur_InProcess() {
        ILocator htmlElement = Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT);

        // set focus
        {
            await htmlElement.EvaluateAsync("node => node.focus()");
            bool hasFocus = await htmlElement.EvaluateAsync<bool>("node => node === document.activeElement;");
            Assert.True(hasFocus);
        }

        await Page.GetByTestId(HTMLElementGroup.BUTTON_BLUR_INPROCESS).HoverAsync();

        // has no focus anymore
        {
            bool hasFocus = await htmlElement.EvaluateAsync<bool>("node => node === document.activeElement;");
            Assert.False(hasFocus);
        }
    }

    [Fact]
    public async Task ShowPopover_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SHOW_POPOVER_INPROCESS).ClickAsync();

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
        Assert.True(visible);
    }

    [Fact]
    public async Task HidePopover_InProcess() {
        // show popover
        {
            await Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.showPopover();");

            bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
            Assert.True(visible);
        }

        // hide again
        {
            await Page.GetByTestId(HTMLElementGroup.BUTTON_HIDE_POPOVER_INPROCESS).ClickAsync();

            bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
            Assert.False(visible);
        }
    }

    [Fact]
    public async Task TogglePopover_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_TOGGLE_POPOVER_INPROCESS).ClickAsync();

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
        Assert.True(visible);
    }

    [Fact]
    public async Task TogglePopoverParameter_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_TOGGLE_POPOVER_PARAMETER_INPROCESS).ClickAsync();

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
        Assert.False(visible);
    }

    #endregion


    #region Element

    [Fact]
    public async Task GetInnerHtml_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_INNERHTML_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("<!--!-->\n            test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u>", result);
    }

    [Fact]
    public async Task SetInnerHtml_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_INNERHTML_INPROCESS).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).InnerHTMLAsync();
        string expected = HTMLElementGroup.TEST_INNERHTML;
        Assert.Equal(expected, result);
    }


    [Fact]
    public async Task GetOuterHtml_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_OUTERHTML_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        const string expected = """
            <div data-testid="htmlelement-html-element" class="html-element" tabindex="-1" style="visibility: visible;" _bl_3=""><!--!-->
                        test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u></div>
            """;
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task SetOuterHtml_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_OUTERHTML_INPROCESS).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).InnerHTMLAsync();
        string expected = HTMLElementGroup.TEST_OUTERHTML;
        Assert.Equal(expected, result);
    }


    [Fact]
    public async Task GetAttributes_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_ATTRIBUTES_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("""{"data-testid":"htmlelement-html-element","class":"html-element","tabindex":"-1","style":"visibility: visible;","_bl_3":""}""", result);
    }


    [Fact]
    public async Task GetChildElementCount_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CHILD_ELEMENT_COUNT_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("3", result);
    }


    [Fact]
    public async Task GetChildren_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CHILDREN_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("3", result);
    }


    [Fact]
    public async Task GetClassName_InProcessy() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLASSNAME_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("html-element", result);
    }

    [Fact]
    public async Task SetClassName_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_CLASSNAME_INPROCESS).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.className;");
        Assert.Equal(HTMLElementGroup.TEST_CLASSNAME, result);
    }


    [Fact]
    public async Task GetClassList_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLASSLIST_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("html-element", result);
    }



    [Fact]
    public async Task GetClientWidth_InProcessy() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLIENTWIDTH_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetClientHeight_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLIENTHEIGHT_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetClientLeft_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLIENTLEFT_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetClientTop_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLIENTTOP_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }



    [Fact]
    public async Task GetScrollWidth_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_SCROLLWIDTH_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 50);
    }


    [Fact]
    public async Task GetScrollHeight_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_SCROLLHEIGHT_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 50);
    }


    [Fact]
    public async Task GetScrollLeft_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_SCROLLLEFT_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.Equal(0, resultAsNumber);
    }

    [Fact]
    public async Task SetScrollLeft_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_SCROLLLEFT_INPROCESS).ClickAsync();

        int result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        Assert.True(result > 0);
    }


    [Fact]
    public async Task GetScrollTop_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_SCROLLTOP_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.Equal(0, resultAsNumber);
    }

    [Fact]
    public async Task SetScrollTop_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SET_SCROLLTOP_INPROCESS).ClickAsync();

        int result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        Assert.True(result > 0);
    }



    [Fact]
    public async Task GetBoundingClientRect_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_BOUNDING_CLIENT_RECT_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.True(result?.Length > 0);

        DOMRect? domRect = JsonSerializer.Deserialize<DOMRect?>(result);
        Assert.NotNull(domRect);
    }

    [Fact]
    public async Task GetClientRects_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_CLIENT_RECTS_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.True(result?.Length > 0);

        foreach (string json in result.Split(';')) {
            DOMRect? domRect = JsonSerializer.Deserialize<DOMRect?>(json);
            Assert.NotNull(domRect);
        }
    }


    [Fact]
    public async Task HasAttribute_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_HAS_ATTRIBUTE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }

    [Fact]
    public async Task HasAttributes_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_HAS_ATTRIBUTES_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }


    [Fact]
    public async Task PointerCapture_InProcess() {
        ILocator popoverElement = Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT);
        ILocator labelOutput = Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT);

        await popoverElement.EvaluateAsync("node => node.showPopover()");

        // hasPointerCapture false
        {
            await popoverElement.HoverAsync();
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
            await popoverElement.HoverAsync();
            string? result = await labelOutput.TextContentAsync();
            Assert.Equal("False", result);
        }
    }


    [Fact]
    public async Task Scroll_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SCROLL_INPROCESS).ClickAsync();

        int resultLeft = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        Assert.True(resultLeft > 0);
        int resultTop = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        Assert.True(resultTop > 0);
    }

    [Fact]
    public async Task ScrollBy_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SCROLL_BY_INPROCESS).ClickAsync();

        int resultLeft = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        Assert.True(resultLeft > 0);
        int resultTop = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        Assert.True(resultTop > 0);
    }

    [Fact]
    public async Task ScrollIntoView_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SCROLL_INTO_VIEW_INPROCESS).HoverAsync();
        int initial = await Page.EvaluateAsync<int>("window.scrollY;");

        await Page.GetByTestId(HTMLElementGroup.BUTTON_SCROLL_INTO_VIEW_INPROCESS).ClickAsync();
        await Task.Delay(100);
        int scrolled = await Page.EvaluateAsync<int>("window.scrollY;");

        Assert.True(scrolled > initial);
    }


    [Fact]
    public async Task RequestFullscreen_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REQUEST_FULLSCREEN_INPROCESS).ClickAsync();
    }



    [Fact]
    public async Task RegisterOnTransitionstart_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITIONSTART_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementGroup.TEST_TRANSITIONSTART_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnTransitionend_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITIONEND_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(600);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementGroup.TEST_TRANSITIONEND_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnTransitionrun_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITIONRUN_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementGroup.TEST_TRANSITIONRUN_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnTransitioncancel_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITIONCANCEL_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#222';");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementGroup.TEST_TRANSITIONCANCEL_EVENT, result);
    }


    [Fact]
    public async Task RegisterOnAnimationstart_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATIONSTART_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementGroup.TEST_ANIMATIONSTART_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnAnimationnend_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATIONEND_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(600);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementGroup.TEST_ANIMATIONEND_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnAnimationiteration_InProcess() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATIONITERATION_INPROCESS).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start-infinite');");
        await Task.Delay(600);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementGroup.TEST_ANIMATIONITERATION_EVENT, result);
    }


    // does not work in Chromium Browser. To make this test work, go to PlayWrightFixture.InitializeAsync() and change "Chromium" to "Firefox"
    //[Fact]
    //public async Task RegisterOnAnimationcancel_InProcess() {
    //    await Page.GetByTestId(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATIONCANCEL_INPROCESS).ClickAsync();
    //    await Task.Delay(100);

    //    await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
    //    await Task.Delay(100);
    //    await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.remove('animation-start');");
    //    await Task.Delay(100);

    //    string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
    //    Assert.Equal(HTMLElementGroup.TEST_ANIMATIONCANCEL_EVENT, result);
    //}

    #endregion
}
