using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using System.Text.Json;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class HTMLElementInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    #region HTMLElement

    [Fact]
    public async Task GetInnerText() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_INNERTEXT).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("test bold italic underlined", result);
    }

    [Fact]
    public async Task SetInnerText() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_SET_INNERTEXT).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).InnerHTMLAsync();
        string expected = HTMLElementInProcessGroup.TEST_INNERTEXT.Replace("<", "&lt;").Replace(">", "&gt;");
        Assert.Equal(expected, result);
    }


    [Fact]
    public async Task GetOuterText() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_OUTERTEXT).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("test bold italic underlined", result);
    }

    [Fact]
    public async Task SetOuterText() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_SET_OUTERTEXT).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT_CONTAINER).InnerHTMLAsync();
        string expected = HTMLElementInProcessGroup.TEST_OUTERTEXT.Replace("<", "&lt;").Replace(">", "&gt;");
        Assert.Equal(expected, result);
    }


    [Fact]
    public async Task GetStyle() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_STYLE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("visibility: visible;", result);
    }

    [Fact]
    public async Task SetStyle() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_SET_STYLE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("style");
        Assert.Equal(HTMLElementInProcessGroup.TEST_STYLE, result);
    }



    [Fact]
    public async Task GetOffsetWidth() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_OFFSETWIDTH).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetOffsetHeight() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_OFFSETHEIGHT).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetOffsetLeft() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_OFFSETLEFT).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetOffsetTop() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_OFFSETTOP).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetOffsetParent() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_OFFSETPARENT).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }



    [Fact]
    public async Task HasFocus() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.focus();");

        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_HASFOCUS).HoverAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }


    [Fact]
    public async Task Click() {
        bool consoleClicked = false;
        Page.Console += ConsoleListener;
        void ConsoleListener(object? sender, IConsoleMessage message) => consoleClicked = message.Text == "clicked";
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.addEventListener('click', () => console.log('clicked'));");

        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_CLICK).ClickAsync();

        Page.Console -= ConsoleListener;
        Assert.True(consoleClicked);
    }

    [Fact]
    public async Task Focus() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_FOCUS).ClickAsync();

        bool hasFocus = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<bool>("node => node === document.activeElement;");
        Assert.True(hasFocus);
    }

    [Fact]
    public async Task Blur() {
        ILocator htmlElement = Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT);

        // set focus
        {
            await htmlElement.EvaluateAsync("node => node.focus()");
            bool hasFocus = await htmlElement.EvaluateAsync<bool>("node => node === document.activeElement;");
            Assert.True(hasFocus);
        }

        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_BLUR).HoverAsync();

        // has no focus anymore
        {
            bool hasFocus = await htmlElement.EvaluateAsync<bool>("node => node === document.activeElement;");
            Assert.False(hasFocus);
        }
    }

    [Fact]
    public async Task ShowPopover() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_SHOW_POPOVER).ClickAsync();

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementInProcessGroup.POPOVER_ELEMENT}\"]");
        Assert.True(visible);
    }

    [Fact]
    public async Task HidePopover() {
        // show popover
        {
            await Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.showPopover();");

            bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementInProcessGroup.POPOVER_ELEMENT}\"]");
            Assert.True(visible);
        }

        // hide again
        {
            await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_HIDE_POPOVER).ClickAsync();

            bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementInProcessGroup.POPOVER_ELEMENT}\"]");
            Assert.False(visible);
        }
    }

    [Fact]
    public async Task TogglePopover() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_TOGGLE_POPOVER).ClickAsync();

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementInProcessGroup.POPOVER_ELEMENT}\"]");
        Assert.True(visible);
    }

    [Fact]
    public async Task TogglePopoverParameter() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_TOGGLE_POPOVER_PARAMETER).ClickAsync();

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementInProcessGroup.POPOVER_ELEMENT}\"]");
        Assert.False(visible);
    }

    #endregion


    #region Element

    [Fact]
    public async Task GetInnerHtml() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_INNERHTML).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("<!--!-->\n            test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u>", result);
    }

    [Fact]
    public async Task SetInnerHtml() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_SET_INNERHTML).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).InnerHTMLAsync();
        string expected = HTMLElementInProcessGroup.TEST_INNERHTML;
        Assert.Equal(expected, result);
    }


    [Fact]
    public async Task GetOuterHtml() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_OUTERHTML).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        const string expected = """
            <div data-testid="htmlelement-inprocess-html-element" class="html-element" tabindex="-1" style="visibility: visible;" _bl_6=""><!--!-->
                        test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u></div>
            """;
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task SetOuterHtml() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_SET_OUTERHTML).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT_CONTAINER).InnerHTMLAsync();
        string expected = HTMLElementInProcessGroup.TEST_OUTERHTML;
        Assert.Equal(expected, result);
    }


    [Fact]
    public async Task GetAttributes() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_ATTRIBUTES).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("""{"data-testid":"htmlelement-inprocess-html-element","class":"html-element","tabindex":"-1","style":"visibility: visible;","_bl_6":""}""", result);
    }


    [Fact]
    public async Task GetChildElementCount() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_CHILD_ELEMENT_COUNT).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("3", result);
    }


    [Fact]
    public async Task GetChildren() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_CHILDREN).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("3", result);
    }


    [Fact]
    public async Task GetClassNamey() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_CLASSNAME).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("html-element", result);
    }

    [Fact]
    public async Task SetClassName() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_SET_CLASSNAME).ClickAsync();

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.className;");
        Assert.Equal(HTMLElementInProcessGroup.TEST_CLASSNAME, result);
    }


    [Fact]
    public async Task GetClassList() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_CLASSLIST).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("html-element", result);
    }



    [Fact]
    public async Task GetClientWidthy() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_CLIENTWIDTH).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetClientHeight() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_CLIENTHEIGHT).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetClientLeft() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_CLIENTLEFT).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }


    [Fact]
    public async Task GetClientTop() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_CLIENTTOP).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 0);
    }



    [Fact]
    public async Task GetScrollWidth() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_SCROLLWIDTH).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 50);
    }


    [Fact]
    public async Task GetScrollHeight() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_SCROLLHEIGHT).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.True(resultAsNumber >= 50);
    }


    [Fact]
    public async Task GetScrollLeft() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_SCROLLLEFT).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.Equal(0, resultAsNumber);
    }

    [Fact]
    public async Task SetScrollLeft() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_SET_SCROLLLEFT).ClickAsync();

        int result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        Assert.True(result > 0);
    }


    [Fact]
    public async Task GetScrollTop() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_SCROLLTOP).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        Assert.True(isInteger);
        Assert.Equal(0, resultAsNumber);
    }

    [Fact]
    public async Task SetScrollTop() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_SET_SCROLLTOP).ClickAsync();

        int result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        Assert.True(result > 0);
    }



    [Fact]
    public async Task GetBoundingClientRect() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_BOUNDING_CLIENT_RECT).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.True(result?.Length > 0);

        DOMRect? domRect = JsonSerializer.Deserialize<DOMRect?>(result);
        Assert.NotNull(domRect);
    }

    [Fact]
    public async Task GetClientRects() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_CLIENT_RECTS).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.True(result?.Length > 0);

        foreach (string json in result.Split(';')) {
            DOMRect? domRect = JsonSerializer.Deserialize<DOMRect?>(json);
            Assert.NotNull(domRect);
        }
    }


    [Fact]
    public async Task HasAttribute() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_HAS_ATTRIBUTE).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }

    [Fact]
    public async Task HasAttributes() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_HAS_ATTRIBUTES).ClickAsync();

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("True", result);
    }


    [Fact]
    public async Task PointerCapture() {
        ILocator htmlElement = Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT);
        ILocator labelOutput = Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_SCROLL).ClickAsync();

        int resultLeft = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        Assert.True(resultLeft > 0);
        int resultTop = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        Assert.True(resultTop > 0);
    }

    [Fact]
    public async Task ScrollBy() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_SCROLL_BY).ClickAsync();

        int resultLeft = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        Assert.True(resultLeft > 0);
        int resultTop = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        Assert.True(resultTop > 0);
    }

    [Fact]
    public async Task ScrollIntoView() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_SCROLL_INTO_VIEW).HoverAsync();
        int initial = await Page.EvaluateAsync<int>("window.scrollY;");

        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_SCROLL_INTO_VIEW).ClickAsync();
        await Task.Delay(100);
        int scrolled = await Page.EvaluateAsync<int>("window.scrollY;");

        Assert.True(scrolled > initial);
    }


    [Fact]
    public async Task RequestFullscreen() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_REQUEST_FULLSCREEN).ClickAsync();
    }



    [Fact]
    public async Task RegisterOnTransitionstart() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_TRANSITIONSTART).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementInProcessGroup.TEST_TRANSITIONSTART_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnTransitionend() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_TRANSITIONEND).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(600);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementInProcessGroup.TEST_TRANSITIONEND_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnTransitionrun() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_TRANSITIONRUN).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementInProcessGroup.TEST_TRANSITIONRUN_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnTransitioncancel() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_TRANSITIONCANCEL).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#222';");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementInProcessGroup.TEST_TRANSITIONCANCEL_EVENT, result);
    }


    [Fact]
    public async Task RegisterOnAnimationstart() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_ANIMATIONSTART).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementInProcessGroup.TEST_ANIMATIONSTART_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnAnimationnend() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_ANIMATIONEND).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(600);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementInProcessGroup.TEST_ANIMATIONEND_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnAnimationiteration() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_ANIMATIONITERATION).ClickAsync();
        await Task.Delay(100);

        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start-infinite');");
        await Task.Delay(600);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith(HTMLElementInProcessGroup.TEST_ANIMATIONITERATION_EVENT, result);
    }


    // does not work in Chromium Browser. To make this test work, go to PlayWrightFixture.InitializeAsync() and change "Chromium" to "Firefox"
    //[Fact]
    //public async Task RegisterOnAnimationcancel() {
    //    await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_ANIMATIONCANCEL).ClickAsync();
    //    await Task.Delay(100);

    //    await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
    //    await Task.Delay(100);
    //    await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.remove('animation-start');");
    //    await Task.Delay(100);

    //    string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
    //    Assert.Equal(HTMLElementInProcessGroup.TEST_ANIMATIONCANCEL_EVENT, result);
    //}

    #endregion
}
