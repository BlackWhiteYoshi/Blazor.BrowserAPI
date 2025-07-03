using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using System.Text.Json;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class HTMLElement(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    #region HTMLElement

    [Test]
    public async Task GetInnerText_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_INNERTEXT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("test bold italic underlined");
    }

    [Test]
    public async Task GetInnerText_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_INNERTEXT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("test bold italic underlined");
    }

    [Test]
    public async Task SetInnerText() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_INNERTEXT);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).InnerHTMLAsync();
        string expected = HTMLElementGroup.TEST_INNERTEXT.Replace("<", "&lt;").Replace(">", "&gt;");
        await Assert.That(result).IsEqualTo(expected);
    }


    [Test]
    public async Task GetOuterText_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OUTERTEXT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("test bold italic underlined");
    }

    [Test]
    public async Task GetOuterText_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OUTERTEXT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("test bold italic underlined");
    }

    [Test]
    public async Task SetOuterText() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_OUTERTEXT);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).InnerHTMLAsync();
        string expected = HTMLElementGroup.TEST_OUTERTEXT.Replace("<", "&lt;").Replace(">", "&gt;");
        await Assert.That(result).IsEqualTo(expected);
    }


    [Test]
    public async Task GetStyle_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_STYLE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("visibility: visible;");
    }

    [Test]
    public async Task GetStyle_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_STYLE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("visibility: visible;");
    }

    [Test]
    public async Task SetStyle() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_STYLE);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("style");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_STYLE);
    }



    [Test]
    public async Task GetOffsetWidth_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OFFSETWIDTH_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetOffsetWidth_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OFFSETWIDTH_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }


    [Test]
    public async Task GetOffsetHeight_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OFFSETHEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetOffsetHeight_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OFFSETHEIGHT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }


    [Test]
    public async Task GetOffsetLeft_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OFFSETLEFT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetOffsetLeft_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OFFSETLEFT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }


    [Test]
    public async Task GetOffsetTop_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OFFSETTOP_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetOffsetTop_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OFFSETTOP_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }


    [Test]
    public async Task GetOffsetParent_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OFFSETPARENT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetOffsetParent_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OFFSETPARENT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }



    [Test]
    public async Task HasFocus_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.focus();");

        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_HASFOCUS_PROPERTY).HoverAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task HasFocus_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.focus();");

        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_HASFOCUS_METHOD).HoverAsync();

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task Click() {
        bool consoleClicked = false;
        Page.Console += ConsoleListener;
        void ConsoleListener(object? sender, IConsoleMessage message) => consoleClicked = message.Text == "clicked";
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.addEventListener('click', () => console.log('clicked'));");

        await ExecuteTest(HTMLElementGroup.BUTTON_CLICK);

        Page.Console -= ConsoleListener;
        await Assert.That(consoleClicked).IsTrue();
    }

    [Test]
    public async Task Focus() {
        await ExecuteTest(HTMLElementGroup.BUTTON_FOCUS);

        bool hasFocus = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<bool>("node => node === document.activeElement;");
        await Assert.That(hasFocus).IsTrue();
    }

    [Test]
    public async Task Blur() {
        ILocator htmlElement = Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT);

        // set focus
        {
            await htmlElement.EvaluateAsync("node => node.focus()");
            bool hasFocus = await htmlElement.EvaluateAsync<bool>("node => node === document.activeElement;");
            await Assert.That(hasFocus).IsTrue();
        }

        await Page.GetByTestId(HTMLElementGroup.BUTTON_BLUR).HoverAsync();

        // has no focus anymore
        {
            bool hasFocus = await htmlElement.EvaluateAsync<bool>("node => node === document.activeElement;");
            await Assert.That(hasFocus).IsFalse();
        }
    }

    [Test]
    public async Task ShowPopover() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SHOW_POPOVER);

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
        await Assert.That(visible).IsTrue();
    }

    [Test]
    public async Task HidePopover() {
        // show popover
        {
            await Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.showPopover();");

            bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
            await Assert.That(visible).IsTrue();
        }

        // hide again
        {
            await ExecuteTest(HTMLElementGroup.BUTTON_HIDE_POPOVER);

            bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
            await Assert.That(visible).IsFalse();
        }
    }

    [Test]
    public async Task TogglePopover() {
        await ExecuteTest(HTMLElementGroup.BUTTON_TOGGLE_POPOVER);

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
        await Assert.That(visible).IsTrue();
    }

    [Test]
    public async Task TogglePopoverParameter() {
        await ExecuteTest(HTMLElementGroup.BUTTON_TOGGLE_POPOVER_PARAMETER);

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementGroup.POPOVER_ELEMENT}\"]");
        await Assert.That(visible).IsFalse();
    }

    #endregion


    #region Element

    [Test]
    public async Task GetInnerHtml_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_INNERHTML_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("<!--!-->\n            test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u>");
    }

    [Test]
    public async Task GetInnerHtml_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_INNERHTML_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("<!--!-->\n            test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u>");
    }

    [Test]
    public async Task SetInnerHtml() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_INNERHTML);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).InnerHTMLAsync();
        string expected = HTMLElementGroup.TEST_INNERHTML;
        await Assert.That(result).IsEqualTo(expected);
    }


    [Test]
    public async Task GetOuterHtml_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OUTERHTML_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        const string expected = """
            <div data-testid="htmlelement-html-element" class="html-element" tabindex="-1" style="visibility: visible;" _bl_4=""><!--!-->
                        test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u></div>
            """;
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GetOuterHtml_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OUTERHTML_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        const string expected = """
            <div data-testid="htmlelement-html-element" class="html-element" tabindex="-1" style="visibility: visible;" _bl_4=""><!--!-->
                        test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u></div>
            """;
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task SetOuterHtml() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_OUTERHTML);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).InnerHTMLAsync();
        string expected = HTMLElementGroup.TEST_OUTERHTML;
        await Assert.That(result).IsEqualTo(expected);
    }


    [Test]
    public async Task GetAttributes_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ATTRIBUTES_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("""{"data-testid":"htmlelement-html-element","class":"html-element","tabindex":"-1","style":"visibility: visible;","_bl_4":""}""");
    }

    [Test]
    public async Task GetAttributes_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ATTRIBUTES_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("""{"data-testid":"htmlelement-html-element","class":"html-element","tabindex":"-1","style":"visibility: visible;","_bl_4":""}""");
    }


    [Test]
    public async Task GetChildElementCount_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CHILD_ELEMENT_COUNT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("3");
    }

    [Test]
    public async Task GetChildElementCount_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CHILD_ELEMENT_COUNT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("3");
    }


    [Test]
    public async Task GetChildren_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CHILDREN_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("3");
    }

    [Test]
    public async Task GetChildren_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CHILDREN_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("3");
    }


    [Test]
    public async Task GetClassName_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLASSNAME_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("html-element");
    }

    [Test]
    public async Task GetClassName_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLASSNAME_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("html-element");
    }

    [Test]
    public async Task SetClassName() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_CLASSNAME);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.className;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_CLASSNAME);
    }


    [Test]
    public async Task GetClassList_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLASSLIST_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("html-element");
    }

    [Test]
    public async Task GetClassList_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLASSLIST_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("html-element");
    }



    [Test]
    public async Task GetClientWidth_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENTWIDTH_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetClientWidth_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENTWIDTH_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }


    [Test]
    public async Task GetClientHeight_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENTHEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetClientHeight_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENTHEIGHT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }


    [Test]
    public async Task GetClientLeft_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENTLEFT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetClientLeft_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENTLEFT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }


    [Test]
    public async Task GetClientTop_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENTTOP_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetClientTop_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENTTOP_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }



    [Test]
    public async Task GetScrollWidth_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLLWIDTH_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(50);
    }

    [Test]
    public async Task GetScrollWidth_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLLWIDTH_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(50);
    }


    [Test]
    public async Task GetScrollHeight_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLLHEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(50);
    }

    [Test]
    public async Task GetScrollHeight_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLLHEIGHT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(50);
    }


    [Test]
    public async Task GetScrollLeft_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLLLEFT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsEqualTo(0);
    }

    [Test]
    public async Task GetScrollLeft_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLLLEFT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsEqualTo(0);
    }

    [Test]
    public async Task SetScrollLeft() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_SCROLLLEFT);

        int result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        await Assert.That(result).IsGreaterThan(0);
    }


    [Test]
    public async Task GetScrollTop_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLLTOP_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsEqualTo(0);
    }

    [Test]
    public async Task GetScrollTop_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLLTOP_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsEqualTo(0);
    }

    [Test]
    public async Task SetScrollTop() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_SCROLLTOP);

        int result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        await Assert.That(result).IsGreaterThan(0);
    }



    [Test]
    public async Task GetBoundingClientRect() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_BOUNDING_CLIENT_RECT);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotNull().IsNotEmpty();

        DOMRect? domRect = JsonSerializer.Deserialize<DOMRect?>(result!);
        await Assert.That(domRect).IsNotNull();
    }

    [Test]
    public async Task GetClientRects() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENT_RECTS);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotNull().IsNotEmpty();

        foreach (string json in result!.Split(';')) {
            DOMRect? domRect = JsonSerializer.Deserialize<DOMRect?>(json);
            await Assert.That(domRect).IsNotNull();
        }
    }


    [Test]
    public async Task HasAttribute() {
        await ExecuteTest(HTMLElementGroup.BUTTON_HAS_ATTRIBUTE);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task HasAttributes() {
        await ExecuteTest(HTMLElementGroup.BUTTON_HAS_ATTRIBUTES);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task PointerCapture() {
        ILocator htmlElement = Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT);
        ILocator labelOutput = Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT);

        // hasPointerCapture false
        {
            await htmlElement.HoverAsync();
            string? result = await labelOutput.TextContentAsync();
            await Assert.That(result).IsEqualTo("False");
        }

        await Page.Mouse.DownAsync();

        // hasPointerCapture true
        {
            await Page.Mouse.MoveAsync(1, 1);
            string? result = await labelOutput.TextContentAsync();
            await Assert.That(result).IsEqualTo("True");
        }

        await Page.Mouse.UpAsync();

        // hasPointerCapture false
        {
            await htmlElement.HoverAsync();
            string? result = await labelOutput.TextContentAsync();
            await Assert.That(result).IsEqualTo("False");
        }
    }


    [Test]
    public async Task Scroll() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SCROLL);

        int resultLeft = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        await Assert.That(resultLeft).IsGreaterThan(0);
        int resultTop = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        await Assert.That(resultTop).IsGreaterThan(0);
    }

    [Test]
    public async Task ScrollBy() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SCROLL_BY);

        int resultLeft = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        await Assert.That(resultLeft).IsGreaterThan(0);
        int resultTop = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        await Assert.That(resultTop).IsGreaterThan(0);
    }

    [Test]
    public async Task ScrollIntoView() {
        await Page.GetByTestId(HTMLElementGroup.BUTTON_SCROLL_INTO_VIEW).HoverAsync();
        int initial = await Page.EvaluateAsync<int>("window.scrollY;");

        await ExecuteTest(HTMLElementGroup.BUTTON_SCROLL_INTO_VIEW);
        int scrolled = await Page.EvaluateAsync<int>("window.scrollY;");

        await Assert.That(scrolled).IsGreaterThan(initial);
    }


    [Test]
    public async Task RequestFullscreen() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REQUEST_FULLSCREEN);
    }



    [Test]
    public async Task RegisterOnTransitionstart() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITIONSTART);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_TRANSITIONSTART_EVENT);
    }

    [Test]
    public async Task RegisterOnTransitionend() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITIONEND);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_TRANSITIONEND_EVENT);
    }

    [Test]
    public async Task RegisterOnTransitionrun() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITIONRUN);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_TRANSITIONRUN_EVENT);
    }

    [Test]
    public async Task RegisterOnTransitioncancel() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITIONCANCEL);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#222';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_TRANSITIONCANCEL_EVENT);
    }


    [Test]
    public async Task RegisterOnAnimationstart() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATIONSTART);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_ANIMATIONSTART_EVENT);
    }

    [Test]
    public async Task RegisterOnAnimationnend() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATIONEND);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_ANIMATIONEND_EVENT);
    }

    [Test]
    public async Task RegisterOnAnimationiteration() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATIONITERATION);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start-infinite');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_ANIMATIONITERATION_EVENT);
    }

    // does not work in Chromium Browser. To make this test work, go to PlayWrightFixture.InitializeAsync() and change "Chromium" to "Firefox"
    [Test, Explicit]
    public async Task RegisterOnAnimationcancel() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATIONCANCEL);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.remove('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ANIMATIONCANCEL_EVENT);
    }

    #endregion
}
