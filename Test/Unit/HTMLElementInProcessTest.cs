using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using System.Text.Json;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class HTMLElementInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    private Task AddAttributeToHtmlElement(string name) => AddAttributeToHtmlElement(name, string.Empty);

    private async Task AddAttributeToHtmlElement(string name, string value) {
        await Page.WaitForSelectorAsync($"[data-testid='{HTMLElementInProcessGroup.HTML_ELEMENT}']");
        await Page.EvaluateAsync($"""document.querySelector("[data-testid='{HTMLElementInProcessGroup.HTML_ELEMENT}']").setAttribute("{name}", "{value}");""");
        await Task.Delay(SMALL_WAIT_TIME);
    }



    #region HTMLElement

    [Test]
    public async Task GetAccessKey() {
        await AddAttributeToHtmlElement("accessKey", HTMLElementInProcessGroup.TEST_ACCESS_KEY);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ACCESS_KEY);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ACCESS_KEY);
    }

    [Test]
    public async Task SetAccessKey() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ACCESS_KEY);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("accessKey");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ACCESS_KEY);
    }


    // does not work in Chromium Browser. To make this test work, go to PlayWrightFixture.InitializeAsync() and change "Chromium" to "Firefox"
    [Test, Explicit]
    public async Task GetAccessKeyLabel() {
        await AddAttributeToHtmlElement("accessKey", HTMLElementInProcessGroup.TEST_ACCESS_KEY);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ACCESS_KEY_LABEL);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).EndsWith(HTMLElementInProcessGroup.TEST_ACCESS_KEY);
    }


    [Test]
    public async Task GetAttributeStyleMap() {
        await AddAttributeToHtmlElement("style", $"{HTMLElementInProcessGroup.TEST_STYLE_NAME}: {HTMLElementInProcessGroup.TEST_STYLE_VALUE};");
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ATTRIBUTE_STYLE_MAP);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo($"{HTMLElementInProcessGroup.TEST_STYLE_NAME} = {HTMLElementInProcessGroup.TEST_STYLE_VALUE}");
    }

    [Test]
    public async Task SetAttributeStyleMap() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ATTRIBUTE_STYLE_MAP);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("style");
        await Assert.That(result).IsEqualTo($"{HTMLElementInProcessGroup.TEST_STYLE_NAME}: {HTMLElementInProcessGroup.TEST_STYLE_VALUE};");
    }

    [Test]
    public async Task RemoveAttributeStyleMap() {
        await AddAttributeToHtmlElement("style", $"{HTMLElementInProcessGroup.TEST_STYLE_NAME}: {HTMLElementInProcessGroup.TEST_STYLE_VALUE};");
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REMOVE_ATTRIBUTE_STYLE_MAP);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("style");
        await Assert.That(result).IsEmpty();
    }


    [Test]
    public async Task GetAutocapitalize() {
        await AddAttributeToHtmlElement("autocapitalize", HTMLElementInProcessGroup.TEST_AUTOCAPITALIZE);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_AUTOCAPITALIZE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_AUTOCAPITALIZE);
    }

    [Test]
    public async Task SetAutocapitalize() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_AUTOCAPITALIZE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("autocapitalize");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_AUTOCAPITALIZE);
    }


    [Test]
    public async Task GetAutofocus() {
        await AddAttributeToHtmlElement("autofocus");
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_AUTOFOCUS);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetAutofocus() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_AUTOFOCUS);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("autofocus");
        await Assert.That(result).IsNotNull();
    }


    [Test]
    public async Task GetContentEditable() {
        await AddAttributeToHtmlElement("contentEditable");
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CONTENT_EDITABLE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("true");
    }

    [Test]
    public async Task SetContentEditable() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_CONTENT_EDITABLE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("contenteditable");
        await Assert.That(result).IsEqualTo("true");
    }


    [Test]
    public async Task GetDataset() {
        await AddAttributeToHtmlElement($"data-{HTMLElementInProcessGroup.TEST_DATASET_NAME}", HTMLElementInProcessGroup.TEST_DATASET_VALUE);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_DATASET);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo($"testid = htmlelement-inprocess-html-element, {HTMLElementInProcessGroup.TEST_DATASET_NAME} = {HTMLElementInProcessGroup.TEST_DATASET_VALUE}");
    }

    [Test]
    public async Task SetDataset() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_DATASET);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync($"data-{HTMLElementInProcessGroup.TEST_DATASET_NAME}");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_DATASET_VALUE);
    }

    [Test]
    public async Task RemoveDataset() {
        await AddAttributeToHtmlElement($"data-{HTMLElementInProcessGroup.TEST_DATASET_NAME}", HTMLElementInProcessGroup.TEST_DATASET_VALUE);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REMOVE_DATASET);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync($"data-{HTMLElementInProcessGroup.TEST_DATASET_NAME}");
        await Assert.That(result).IsNull();
    }


    [Test]
    public async Task GetDir() {
        await AddAttributeToHtmlElement("dir", HTMLElementInProcessGroup.TEST_DIR);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_DIR);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_DIR);
    }

    [Test]
    public async Task SetDir() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_DIR);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("dir");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_DIR);
    }


    [Test]
    public async Task GetDraggable() {
        await AddAttributeToHtmlElement("draggable", "true");
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_DRAGGABLE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetDraggable() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_DRAGGABLE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("draggable");
        await Assert.That(result).IsEqualTo("true");
    }


    [Test]
    public async Task GetEnterKeyHint() {
        await AddAttributeToHtmlElement("enterKeyHint", HTMLElementInProcessGroup.TEST_ENTER_KEY_HINT);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ENTER_KEY_HINT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ENTER_KEY_HINT);
    }

    [Test]
    public async Task SetEnterKeyHint() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ENTER_KEY_HINT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("enterKeyHint");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ENTER_KEY_HINT);
    }


    [Test]
    public async Task GetHidden() {
        await AddAttributeToHtmlElement("hidden");
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_HIDDEN);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetHidden() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_HIDDEN);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("hidden");
        await Assert.That(result).IsNotNull();
    }


    [Test]
    public async Task GetInert() {
        await AddAttributeToHtmlElement("inert");
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_INERT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetInert() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_INERT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("inert");
        await Assert.That(result).IsNotNull();
    }


    [Test]
    public async Task GetInnerText() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_INNERTEXT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("test bold italic underlined");
    }

    [Test]
    public async Task SetInnerText() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_INNERTEXT);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).InnerHTMLAsync();
        string expected = HTMLElementInProcessGroup.TEST_INNERTEXT.Replace("<", "&lt;").Replace(">", "&gt;");
        await Assert.That(result).IsEqualTo(expected);
    }


    [Test]
    public async Task GetInputMode() {
        await AddAttributeToHtmlElement("inputMode", HTMLElementInProcessGroup.TEST_INPUT_MODE);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_INPUT_MODE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_INPUT_MODE);
    }

    [Test]
    public async Task SetInputMode() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_INPUT_MODE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("inputMode");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_INPUT_MODE);
    }


    [Test]
    public async Task GetIsContentEditable() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_IS_CONTENT_EDITABLE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task GetLang() {
        await AddAttributeToHtmlElement("lang", HTMLElementInProcessGroup.TEST_LANG);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_LANG);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_LANG);
    }

    [Test]
    public async Task SetLang() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_LANG);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("lang");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_LANG);
    }


    [Test]
    public async Task GetNonce() {
        await AddAttributeToHtmlElement("nonce", HTMLElementInProcessGroup.TEST_NONCE);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_NONCE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_NONCE);
    }

    [Test]
    public async Task SetNonce() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_NONCE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.nonce;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_NONCE);
    }


    [Test]
    public async Task GetOffsetWidth() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_OFFSETWIDTH);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetOffsetHeight() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_OFFSETHEIGHT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetOffsetLeft() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_OFFSETLEFT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetOffsetTop() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_OFFSETTOP);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetOffsetParent() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_OFFSETPARENT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetOuterText() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_OUTERTEXT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("test bold italic underlined");
    }

    [Test]
    public async Task SetOuterText() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_OUTERTEXT);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT_CONTAINER).InnerHTMLAsync();
        string expected = HTMLElementInProcessGroup.TEST_OUTERTEXT.Replace("<", "&lt;").Replace(">", "&gt;");
        await Assert.That(result).IsEqualTo(expected);
    }


    [Test]
    public async Task GetPopover() {
        await AddAttributeToHtmlElement("popover", HTMLElementInProcessGroup.TEST_POPOVER);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_POPOVER);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_POPOVER);
    }

    [Test]
    public async Task SetPopover() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_POPOVER);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("popover");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_POPOVER);
    }


    [Test]
    public async Task GetSpellcheck() {
        await AddAttributeToHtmlElement("spellcheck");
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_SPELLCHECK);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetSpellcheck() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_SPELLCHECK);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("spellcheck");
        await Assert.That(result).IsEqualTo("true");
    }


    [Test]
    public async Task GetStyle() {
        await Page.WaitForSelectorAsync($"[data-testid='{HTMLElementInProcessGroup.HTML_ELEMENT}']");
        await Page.EvaluateAsync($"""document.querySelector("[data-testid='{HTMLElementInProcessGroup.HTML_ELEMENT}']").style.visibility = "visible";""");
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_STYLE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("visibility: visible;");
    }

    [Test]
    public async Task SetStyle() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_STYLE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("style");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_STYLE);
    }


    [Test]
    public async Task GetTabIndex() {
        await AddAttributeToHtmlElement("tabIndex", HTMLElementInProcessGroup.TEST_TAB_INDEX.ToString());
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_TAB_INDEX);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_TAB_INDEX.ToString());
    }

    [Test]
    public async Task SetTabIndex() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_TAB_INDEX);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("tabIndex");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_TAB_INDEX.ToString());
    }


    [Test]
    public async Task GetTitle() {
        await AddAttributeToHtmlElement("title", HTMLElementInProcessGroup.TEST_TITLE);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_TITLE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_TITLE);
    }

    [Test]
    public async Task SetTitle() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_TITLE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("title");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_TITLE);
    }


    [Test]
    public async Task GetTranslate() {
        await AddAttributeToHtmlElement("translate");
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_TRANSLATE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetTranslate() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_TRANSLATE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("translate");
        await Assert.That(result).IsEqualTo("yes");
    }


    // extra

    [Test]
    public async Task HasFocus() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.focus();");
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_GET_HASFOCUS).HoverAsync(); // button has @onpointerenter-trigger for not loosing focus

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // methods

    [Test]
    public async Task Click() {
        bool consoleClicked = false;
        Page.Console += ConsoleListener;
        void ConsoleListener(object? sender, IConsoleMessage message) => consoleClicked = message.Text == "clicked";
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.addEventListener('click', () => console.log('clicked'));");

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_CLICK);

        Page.Console -= ConsoleListener;
        await Assert.That(consoleClicked).IsTrue();
    }

    [Test]
    public async Task Focus() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_FOCUS);

        bool hasFocus = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<bool>("node => node === document.activeElement;");
        await Assert.That(hasFocus).IsTrue();
    }

    [Test]
    public async Task Blur() {
        ILocator htmlElement = Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT);

        // set focus
        {
            await htmlElement.EvaluateAsync("node => node.focus()");
            bool hasFocus = await htmlElement.EvaluateAsync<bool>("node => node === document.activeElement;");
            await Assert.That(hasFocus).IsTrue();
        }

        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_BLUR).HoverAsync(); // button has @onpointerenter-trigger for not loosing focus

        // has no focus anymore
        {
            bool hasFocus = await htmlElement.EvaluateAsync<bool>("node => node === document.activeElement;");
            await Assert.That(hasFocus).IsFalse();
        }
    }

    [Test]
    public async Task ShowPopover() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SHOW_POPOVER);

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementInProcessGroup.POPOVER_ELEMENT}\"]");
        await Assert.That(visible).IsTrue();
    }

    [Test]
    public async Task HidePopover() {
        // show popover
        {
            await Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.showPopover();");

            bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementInProcessGroup.POPOVER_ELEMENT}\"]");
            await Assert.That(visible).IsTrue();
        }

        // hide again
        {
            await ExecuteTest(HTMLElementInProcessGroup.BUTTON_HIDE_POPOVER);

            bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementInProcessGroup.POPOVER_ELEMENT}\"]");
            await Assert.That(visible).IsFalse();
        }
    }

    [Test]
    public async Task TogglePopover() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_TOGGLE_POPOVER);

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementInProcessGroup.POPOVER_ELEMENT}\"]");
        await Assert.That(visible).IsTrue();
    }

    [Test]
    public async Task TogglePopoverParameter() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_TOGGLE_POPOVER_PARAMETER);

        bool visible = await Page.IsVisibleAsync($"p[data-testid=\"{HTMLElementInProcessGroup.POPOVER_ELEMENT}\"]");
        await Assert.That(visible).IsFalse();
    }

    #endregion


    #region Element

    [Test]
    public async Task GetInnerHtml() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_INNERHTML);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("<!--!-->\n            test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u>");
    }

    [Test]
    public async Task SetInnerHtml() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_INNERHTML);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).InnerHTMLAsync();
        string expected = HTMLElementInProcessGroup.TEST_INNERHTML;
        await Assert.That(result).IsEqualTo(expected);
    }


    [Test]
    public async Task GetOuterHtml() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_OUTERHTML);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        const string expected = """
            <div data-testid="htmlelement-inprocess-html-element" class="html-element" _bl_6=""><!--!-->
                        test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u></div>
            """;
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task SetOuterHtml() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_OUTERHTML);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT_CONTAINER).InnerHTMLAsync();
        string expected = HTMLElementInProcessGroup.TEST_OUTERHTML;
        await Assert.That(result).IsEqualTo(expected);
    }


    [Test]
    public async Task GetAttributes() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ATTRIBUTES);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("""{"data-testid":"htmlelement-inprocess-html-element","class":"html-element","_bl_6":""}""");
    }


    [Test]
    public async Task GetChildElementCount() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CHILD_ELEMENT_COUNT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("3");
    }


    [Test]
    public async Task GetChildren() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CHILDREN);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("3");
    }


    [Test]
    public async Task GetClassNamey() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CLASSNAME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("html-element");
    }

    [Test]
    public async Task SetClassName() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_CLASSNAME);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.className;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_CLASSNAME);
    }


    [Test]
    public async Task GetClassList() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CLASSLIST);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("html-element");
    }



    [Test]
    public async Task GetClientWidthy() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CLIENTWIDTH);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }


    [Test]
    public async Task GetClientHeight() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CLIENTHEIGHT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }


    [Test]
    public async Task GetClientLeft() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CLIENTLEFT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }


    [Test]
    public async Task GetClientTop() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CLIENTTOP);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }



    [Test]
    public async Task GetScrollWidth() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_SCROLLWIDTH);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(50);
    }


    [Test]
    public async Task GetScrollHeight() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_SCROLLHEIGHT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(50);
    }


    [Test]
    public async Task GetScrollLeft() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_SCROLLLEFT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsEqualTo(0);
    }

    [Test]
    public async Task SetScrollLeft() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_SCROLLLEFT);

        int result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        await Assert.That(result).IsGreaterThan(0);
    }


    [Test]
    public async Task GetScrollTop() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_SCROLLTOP);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsEqualTo(0);
    }

    [Test]
    public async Task SetScrollTop() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_SCROLLTOP);

        int result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        await Assert.That(result).IsGreaterThan(0);
    }


    // methods

    [Test]
    public async Task GetBoundingClientRect() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_BOUNDING_CLIENT_RECT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotNull().IsNotEmpty();

        DOMRect? domRect = JsonSerializer.Deserialize<DOMRect?>(result!);
        await Assert.That(domRect).IsNotNull();
    }

    [Test]
    public async Task GetClientRects() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CLIENT_RECTS);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotNull().IsNotEmpty();

        foreach (string json in result!.Split(';')) {
            DOMRect? domRect = JsonSerializer.Deserialize<DOMRect?>(json);
            await Assert.That(domRect).IsNotNull();
        }
    }


    [Test]
    public async Task HasAttribute() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_HAS_ATTRIBUTE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task HasAttributes() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_HAS_ATTRIBUTES);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task PointerCapture() {
        ILocator htmlElement = Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT);
        ILocator labelOutput = Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT);

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
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SCROLL);

        int resultLeft = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        await Assert.That(resultLeft).IsGreaterThan(0);
        int resultTop = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        await Assert.That(resultTop).IsGreaterThan(0);
    }

    [Test]
    public async Task ScrollBy() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SCROLL_BY);

        int resultLeft = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        await Assert.That(resultLeft).IsGreaterThan(0);
        int resultTop = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        await Assert.That(resultTop).IsGreaterThan(0);
    }

    [Test]
    public async Task ScrollIntoView() {
        await Page.GetByTestId(HTMLElementInProcessGroup.BUTTON_SCROLL_INTO_VIEW).HoverAsync();
        int initial = await Page.EvaluateAsync<int>("window.scrollY;");

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SCROLL_INTO_VIEW);
        int scrolled = await Page.EvaluateAsync<int>("window.scrollY;");

        await Assert.That(scrolled).IsGreaterThan(initial);
    }


    [Test]
    public async Task RequestFullscreen() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REQUEST_FULLSCREEN);
    }


    // events

    [Test]
    public async Task RegisterOnTransitionstart() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_TRANSITIONSTART);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_TRANSITIONSTART_EVENT);
    }

    [Test]
    public async Task RegisterOnTransitionend() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_TRANSITIONEND);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_TRANSITIONEND_EVENT);
    }

    [Test]
    public async Task RegisterOnTransitionrun() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_TRANSITIONRUN);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_TRANSITIONRUN_EVENT);
    }

    [Test]
    public async Task RegisterOnTransitioncancel() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_TRANSITIONCANCEL);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#222';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_TRANSITIONCANCEL_EVENT);
    }


    [Test]
    public async Task RegisterOnAnimationstart() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_ANIMATIONSTART);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_ANIMATIONSTART_EVENT);
    }

    [Test]
    public async Task RegisterOnAnimationnend() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_ANIMATIONEND);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_ANIMATIONEND_EVENT);
    }

    [Test]
    public async Task RegisterOnAnimationiteration() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_ANIMATIONITERATION);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start-infinite');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_ANIMATIONITERATION_EVENT);
    }


    // does not work in Chromium Browser. To make this test work, go to PlayWrightFixture.InitializeAsync() and change "Chromium" to "Firefox"
    [Test, Explicit]
    public async Task RegisterOnAnimationcancel() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_ANIMATIONCANCEL);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.remove('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ANIMATIONCANCEL_EVENT);
    }

    #endregion
}
