using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using System.Text.Json;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class HTMLElementInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override Task InitializeAsync()
        => TestContext.Current?.TestName switch {
            nameof(GetAccessKeyLabel) => NewPage(BrowserId.Firefox),
            _ => NewPage(BrowserId.Chromium)
        };


    #region HTMLElement

    [Test]
    public async Task GetAccessKey() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('accessKey', '{HTMLElementInProcessGroup.TEST_ACCESS_KEY}');");
        await Task.Delay(SMALL_WAIT_TIME);

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


    [Test]
    public async Task GetAccessKeyLabel() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('accessKey', '{HTMLElementInProcessGroup.TEST_ACCESS_KEY}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ACCESS_KEY_LABEL);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).EndsWith(HTMLElementInProcessGroup.TEST_ACCESS_KEY);
    }


    [Test]
    public async Task GetAttributeStyleMap() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.style.{HTMLElementInProcessGroup.TEST_STYLE_NAME} = '{HTMLElementInProcessGroup.TEST_STYLE_VALUE}';");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.style.{HTMLElementInProcessGroup.TEST_STYLE_NAME} = '{HTMLElementInProcessGroup.TEST_STYLE_VALUE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REMOVE_ATTRIBUTE_STYLE_MAP);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync("style");
        await Assert.That(result).IsEmpty();
    }


    [Test]
    public async Task GetAutocapitalize() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('autocapitalize', '{HTMLElementInProcessGroup.TEST_AUTOCAPITALIZE}');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('autofocus', '');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('contentEditable', '');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('data-{HTMLElementInProcessGroup.TEST_DATASET_NAME}', '{HTMLElementInProcessGroup.TEST_DATASET_VALUE}');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('data-{HTMLElementInProcessGroup.TEST_DATASET_NAME}', '{HTMLElementInProcessGroup.TEST_DATASET_VALUE}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REMOVE_DATASET);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync($"data-{HTMLElementInProcessGroup.TEST_DATASET_NAME}");
        await Assert.That(result).IsNull();
    }


    [Test]
    public async Task GetDir() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('dir', '{HTMLElementInProcessGroup.TEST_DIR}');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('draggable', 'true');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('enterKeyHint', '{HTMLElementInProcessGroup.TEST_ENTER_KEY_HINT}');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('hidden', '');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('inert', '');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('inputMode', '{HTMLElementInProcessGroup.TEST_INPUT_MODE}');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('lang', '{HTMLElementInProcessGroup.TEST_LANG}');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('nonce', '{HTMLElementInProcessGroup.TEST_NONCE}');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('popover', '{HTMLElementInProcessGroup.TEST_POPOVER}');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('spellcheck', '');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.style.visibility = 'visible';");
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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('tabIndex', '{HTMLElementInProcessGroup.TEST_TAB_INDEX}');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('title', '{HTMLElementInProcessGroup.TEST_TITLE}');");
        await Task.Delay(SMALL_WAIT_TIME);

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
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('translate', '');");
        await Task.Delay(SMALL_WAIT_TIME);

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


    // events

    [Test]
    public async Task RegisterOnChange() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync("""
            node => {
                const tempElement = document.createElement("input");
                tempElement.setAttribute("data-testid", "temp");
                node.appendChild(tempElement);
            }
            """);
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_CHANGE);

        await Page.GetByTestId("temp").FillAsync("something");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").BlurAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_EVENT_CHANGE);
    }

    [Test]
    public async Task RegisterOnCommand() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_COMMAND);

        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync("""
            node => {
                const popoverElement = node.nextElementSibling;

                const tempButton = document.createElement("button");
                tempButton.setAttribute("data-testid", "temp");
                tempButton.commandForElement = popoverElement;
                tempButton.command = "show-popover";
                node.appendChild(tempButton);
                tempButton.click();
            }
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("id='temp', command='show-popover'");
    }

    [Test]
    public async Task RegisterOnLoad() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync("""
            node => {
                const tempElement = document.createElement("img");
                tempElement.setAttribute("data-testid", "temp");
                node.appendChild(tempElement);
            }
            """);
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_LOAD);

        await Page.GetByTestId("temp").EvaluateAsync("node => node.src = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADklEQVR4AWL69//ffwAAAAD//+Rp924AAAAGSURBVAMACf8D/Z3TzWsAAAAASUVORK5CYII=';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task RegisterOnError() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync("""
            node => {
                const tempElement = document.createElement("img");
                tempElement.setAttribute("data-testid", "temp");
                node.appendChild(tempElement);
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_ERROR);

        await Page.GetByTestId("temp").EvaluateAsync("node => node.src = 'wrong/path';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }


    [Test]
    public async Task RegisterOnDrag() {
        await Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.removeAttribute('popover');");
        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.setAttribute("draggable", "true");
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_DRAG);

        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).DragToAsync(Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='uninitialized', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragStart() {
        await Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.removeAttribute('popover');");
        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.setAttribute("draggable", "true");
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_DRAG_START);

        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).DragToAsync(Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='uninitialized', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragEnd() {
        await Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.removeAttribute('popover');");
        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.setAttribute("draggable", "true");
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_DRAG_END);

        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).DragToAsync(Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='uninitialized', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragEnter() {
        await Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.removeAttribute('popover');");
        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.setAttribute("draggable", "true");
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_DRAG_ENTER);

        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).DragToAsync(Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='all', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragLeave() {
        await Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.removeAttribute('popover');");
        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.setAttribute("draggable", "true");
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_DRAG_LEAVE);

        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).DragToAsync(Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='all', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragOver() {
        await Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.removeAttribute('popover');");
        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.setAttribute("draggable", "true");
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_DRAG_OVER);

        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).DragToAsync(Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='all', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDrop() {
        await Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("popover");
                node.addEventListener("dragover", e => e.preventDefault());
            }
            """);
        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.setAttribute("draggable", "true");
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_DROP);

        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).DragToAsync(Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='all', types='[]', files='[]'");
    }


    [Test]
    public async Task RegisterOnToggle() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_TOGGLE);

        await Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.showPopover();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("oldState='closed', newState='open'");
    }

    [Test]
    public async Task RegisterOnBeforeToggle() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_BEFORE_TOGGLE);

        await Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.showPopover();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("oldState='closed', newState='open'");
    }

    #endregion


    #region Node/Element

    [Test]
    public async Task GetAttributes() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ATTRIBUTES);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("""{"data-testid":"htmlelement-inprocess-html-element","class":"html-element",""");
    }

    [Test]
    public async Task GetClassList() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CLASS_LIST);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("html-element");
    }

    [Test]
    public async Task GetClassNamey() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CLASS_NAME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("html-element");
    }

    [Test]
    public async Task SetClassName() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_CLASS_NAME);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.className;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_CLASSNAME);
    }


    [Test]
    public async Task GetClientWidthy() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CLIENT_WIDTH);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetClientHeight() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CLIENT_HEIGHT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetClientLeft() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CLIENT_LEFT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetClientTop() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CLIENT_TOP);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }


    [Test]
    public async Task GetCurrentCSSZoom() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_CURRENT_CSS_ZOOM);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }


    [Test]
    public async Task GetId() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.id = '{HTMLElementInProcessGroup.TEST_ID}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ID);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ID);
    }

    [Test]
    public async Task SetId() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ID);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.id;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ID);
    }


    [Test]
    public async Task GetIsConnected() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_IS_CONNECTED);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetInnerHtml() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_INNER_HTML);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("<!--!-->\n            test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u>");
    }

    [Test]
    public async Task SetInnerHtml() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_INNER_HTML);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).InnerHTMLAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_INNERHTML);
    }


    [Test]
    public async Task GetOuterHtml() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_OUTER_HTML);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("""<div data-testid="htmlelement-inprocess-html-element" class="html-element" """);
    }

    [Test]
    public async Task SetOuterHtml() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_OUTER_HTML);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT_CONTAINER).InnerHTMLAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_OUTERHTML);
    }


    [Test]
    public async Task GetPart() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('part', 'header-part body-part');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_PART);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("header-part,body-part");
    }


    [Test]
    public async Task GetScrollWidth() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_SCROLL_WIDTH);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(50);
    }

    [Test]
    public async Task GetScrollHeight() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_SCROLL_HEIGHT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(50);
    }

    [Test]
    public async Task GetScrollLeft() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_SCROLL_LEFT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsEqualTo(0);
    }

    [Test]
    public async Task SetScrollLeft() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_SCROLL_LEFT);

        int result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        await Assert.That(result).IsGreaterThan(0);
    }

    [Test]
    public async Task GetScrollTop() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_SCROLL_TOP);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsEqualTo(0);
    }

    [Test]
    public async Task SetScrollTop() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_SCROLL_TOP);

        int result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        await Assert.That(result).IsGreaterThan(0);
    }


    [Test]
    public async Task GetSlot() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.slot = '{HTMLElementInProcessGroup.TEST_SLOT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_SLOT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.slot;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_SLOT);
    }

    [Test]
    public async Task SetSlot() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_SLOT);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.slot;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_SLOT);
    }


    [Test]
    public async Task GetLocalName() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_LOCAL_NAME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("div");
    }

    [Test]
    public async Task GetNamespaceURI() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_NAMESPACE_URI);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("http://www.w3.org/1999/xhtml");
    }

    [Test]
    public async Task GetPrefix() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_PREFIX);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("no prefix");
    }

    [Test]
    public async Task GetBaseURI() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_BASE_URI);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/");
    }

    [Test]
    public async Task GetTagName() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_TAG_NAME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("DIV");
    }

    [Test]
    public async Task GetNodeName() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_NODE_NAME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("DIV");
    }

    [Test]
    public async Task GetNodeType() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_NODE_TYPE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }


    // properties - Tree nodes

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
    public async Task GetFirstElementChild() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_FIRST_ELEMENT_CHILD);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetLastElementChild() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_LAST_ELEMENT_CHILD);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetPreviousElementSibling() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_PREVIOUS_ELEMENT_SIBLING);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetNextElementSibling() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_NEXT_ELEMENT_SIBLING);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetParentElement() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_PARENT_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // properties - ARIA

    [Test]
    public async Task GetAriaAtomic() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaAtomic = '{HTMLElementInProcessGroup.TEST_ARIA_ATOMIC}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_ATOMIC);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_ATOMIC);
    }

    [Test]
    public async Task SetAriaAtomic() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_ATOMIC);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaAtomic;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_ATOMIC);
    }


    [Test]
    public async Task GetAriaAutoComplete() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaAutoComplete = '{HTMLElementInProcessGroup.TEST_ARIA_AUTO_COMPLETE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_AUTO_COMPLETE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_AUTO_COMPLETE);
    }

    [Test]
    public async Task SetAriaAutoComplete() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_AUTO_COMPLETE);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaAutoComplete;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_AUTO_COMPLETE);
    }


    [Test]
    public async Task GetAriaBrailleLabel() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaBrailleLabel = '{HTMLElementInProcessGroup.TEST_ARIA_BRAILLE_LABEL}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_BRAILLE_LABEL);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_BRAILLE_LABEL);
    }

    [Test]
    public async Task SetAriaBrailleLabel() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_BRAILLE_LABEL);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaBrailleLabel;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_BRAILLE_LABEL);
    }


    [Test]
    public async Task GetAriaBrailleRoleDescription() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaBrailleRoleDescription = '{HTMLElementInProcessGroup.TEST_ARIA_BRAILLE_ROLE_DESCRIPTION}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_BRAILLE_ROLE_DESCRIPTION);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_BRAILLE_ROLE_DESCRIPTION);
    }

    [Test]
    public async Task SetAriaBrailleRoleDescription() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_BRAILLE_ROLE_DESCRIPTION);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaBrailleRoleDescription;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_BRAILLE_ROLE_DESCRIPTION);
    }


    [Test]
    public async Task GetAriaBusy() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaBusy = '{HTMLElementInProcessGroup.TEST_ARIA_BUSY}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_BUSY);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_BUSY);
    }

    [Test]
    public async Task SetAriaBusy() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_BUSY);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaBusy;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_BUSY);
    }


    [Test]
    public async Task GetAriaChecked() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaChecked = '{HTMLElementInProcessGroup.TEST_ARIA_CHECKED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_CHECKED);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_CHECKED);
    }

    [Test]
    public async Task SetAriaChecked() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_CHECKED);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaChecked;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_CHECKED);
    }


    [Test]
    public async Task GetAriaColCount() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaColCount = '{HTMLElementInProcessGroup.TEST_ARIA_COL_COUNT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_COL_COUNT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_COL_COUNT);
    }

    [Test]
    public async Task SetAriaColCount() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_COL_COUNT);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaColCount;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_COL_COUNT);
    }


    [Test]
    public async Task GetAriaColIndex() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaColIndex = '{HTMLElementInProcessGroup.TEST_ARIA_COL_INDEX}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_COL_INDEX);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_COL_INDEX);
    }

    [Test]
    public async Task SetAriaColIndex() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_COL_INDEX);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaColIndex;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_COL_INDEX);
    }


    [Test]
    public async Task GetAriaColIndexText() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaColIndexText = '{HTMLElementInProcessGroup.TEST_ARIA_COL_INDEX_TEXT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_COL_INDEX_TEXT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_COL_INDEX_TEXT);
    }

    [Test]
    public async Task SetAriaColIndexText() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_COL_INDEX_TEXT);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaColIndexText;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_COL_INDEX_TEXT);
    }


    [Test]
    public async Task GetAriaColSpan() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaColSpan = '{HTMLElementInProcessGroup.TEST_ARIA_COL_SPAN}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_COL_SPAN);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_COL_SPAN);
    }

    [Test]
    public async Task SetAriaColSpan() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_COL_SPAN);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaColSpan;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_COL_SPAN);
    }


    [Test]
    public async Task GetAriaCurrent() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaCurrent = '{HTMLElementInProcessGroup.TEST_ARIA_CURRENT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_CURRENT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_CURRENT);
    }

    [Test]
    public async Task SetAriaCurrent() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_CURRENT);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaCurrent;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_CURRENT);
    }


    [Test]
    public async Task GetAriaDescription() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaDescription = '{HTMLElementInProcessGroup.TEST_ARIA_DESCRIPTION}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_DESCRIPTION);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_DESCRIPTION);
    }

    [Test]
    public async Task SetAriaDescription() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_DESCRIPTION);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaDescription;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_DESCRIPTION);
    }


    [Test]
    public async Task GetAriaDisabled() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaDisabled = '{HTMLElementInProcessGroup.TEST_ARIA_DISABLED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_DISABLED);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_DISABLED);
    }

    [Test]
    public async Task SetAriaDisabled() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_DISABLED);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaDisabled;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_DISABLED);
    }


    [Test]
    public async Task GetAriaExpanded() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaExpanded = '{HTMLElementInProcessGroup.TEST_ARIA_EXPANDED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_EXPANDED);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_EXPANDED);
    }

    [Test]
    public async Task SetAriaExpanded() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_EXPANDED);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaExpanded;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_EXPANDED);
    }


    [Test]
    public async Task GetAriaHasPopup() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaHasPopup = '{HTMLElementInProcessGroup.TEST_ARIA_HAS_POPUP}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_HAS_POPUP);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_HAS_POPUP);
    }

    [Test]
    public async Task SetAriaHasPopup() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_HAS_POPUP);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaHasPopup;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_HAS_POPUP);
    }


    [Test]
    public async Task GetAriaHidden() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaHidden = '{HTMLElementInProcessGroup.TEST_ARIA_HIDDEN}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_HIDDEN);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_HIDDEN);
    }

    [Test]
    public async Task SetAriaHidden() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_HIDDEN);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaHidden;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_HIDDEN);
    }


    [Test]
    public async Task GetAriaInvalid() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaInvalid = '{HTMLElementInProcessGroup.TEST_ARIA_INVALID}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_INVALID);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_INVALID);
    }

    [Test]
    public async Task SetAriaInvalid() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_INVALID);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaInvalid;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_INVALID);
    }


    [Test]
    public async Task GetAriaKeyShortcuts() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaKeyShortcuts = '{HTMLElementInProcessGroup.TEST_ARIA_KEY_SHORTCUTS}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_KEY_SHORTCUTS);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_KEY_SHORTCUTS);
    }

    [Test]
    public async Task SetAriaKeyShortcuts() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_KEY_SHORTCUTS);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaKeyShortcuts;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_KEY_SHORTCUTS);
    }


    [Test]
    public async Task GetAriaLabel() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaLabel = '{HTMLElementInProcessGroup.TEST_ARIA_LABEL}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_LABEL);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_LABEL);
    }

    [Test]
    public async Task SetAriaLabel() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_LABEL);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaLabel;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_LABEL);
    }


    [Test]
    public async Task GetAriaLevel() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaLevel = '{HTMLElementInProcessGroup.TEST_ARIA_LEVEL}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_LEVEL);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_LEVEL);
    }

    [Test]
    public async Task SetAriaLevel() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_LEVEL);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaLevel;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_LEVEL);
    }


    [Test]
    public async Task GetAriaLive() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaLive = '{HTMLElementInProcessGroup.TEST_ARIA_LIVE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_LIVE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_LIVE);
    }

    [Test]
    public async Task SetAriaLive() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_LIVE);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaLive;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_LIVE);
    }


    [Test]
    public async Task GetAriaModal() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaModal = '{HTMLElementInProcessGroup.TEST_ARIA_MODAL}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_MODAL);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_MODAL);
    }

    [Test]
    public async Task SetAriaModal() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_MODAL);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaModal;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_MODAL);
    }


    [Test]
    public async Task GetAriaMultiline() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaMultiline = '{HTMLElementInProcessGroup.TEST_ARIA_MULTILINE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_MULTILINE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_MULTILINE);
    }

    [Test]
    public async Task SetAriaMultiline() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_MULTILINE);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaMultiline;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_MULTILINE);
    }


    [Test]
    public async Task GetAriaMultiSelectable() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaMultiSelectable = '{HTMLElementInProcessGroup.TEST_ARIA_MULTI_SELECTABLE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_MULTI_SELECTABLE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_MULTI_SELECTABLE);
    }

    [Test]
    public async Task SetAriaMultiSelectable() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_MULTI_SELECTABLE);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaMultiSelectable;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_MULTI_SELECTABLE);
    }


    [Test]
    public async Task GetAriaOrientation() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaOrientation = '{HTMLElementInProcessGroup.TEST_ARIA_ORIENTATION}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_ORIENTATION);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_ORIENTATION);
    }

    [Test]
    public async Task SetAriaOrientation() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_ORIENTATION);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaOrientation;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_ORIENTATION);
    }


    [Test]
    public async Task GetAriaPlaceholder() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaPlaceholder = '{HTMLElementInProcessGroup.TEST_ARIA_PLACEHOLDER}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_PLACEHOLDER);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_PLACEHOLDER);
    }

    [Test]
    public async Task SetAriaPlaceholder() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_PLACEHOLDER);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaPlaceholder;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_PLACEHOLDER);
    }


    [Test]
    public async Task GetAriaPosInSet() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaPosInSet = '{HTMLElementInProcessGroup.TEST_ARIA_POS_IN_SET}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_POS_IN_SET);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_POS_IN_SET);
    }

    [Test]
    public async Task SetAriaPosInSet() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_POS_IN_SET);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaPosInSet;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_POS_IN_SET);
    }


    [Test]
    public async Task GetAriaPressed() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaPressed = '{HTMLElementInProcessGroup.TEST_ARIA_PRESSED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_PRESSED);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_PRESSED);
    }

    [Test]
    public async Task SetAriaPressed() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_PRESSED);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaPressed;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_PRESSED);
    }


    [Test]
    public async Task GetAriaReadOnly() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaReadOnly = '{HTMLElementInProcessGroup.TEST_ARIA_READ_ONLY}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_READ_ONLY);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_READ_ONLY);
    }

    [Test]
    public async Task SetAriaReadOnly() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_READ_ONLY);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaReadOnly;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_READ_ONLY);
    }


    [Test]
    public async Task GetAriaRequired() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRequired = '{HTMLElementInProcessGroup.TEST_ARIA_REQUIRED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_REQUIRED);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_REQUIRED);
    }

    [Test]
    public async Task SetAriaRequired() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_REQUIRED);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaRequired;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_REQUIRED);
    }


    [Test]
    public async Task GetAriaRoleDescription() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRoleDescription = '{HTMLElementInProcessGroup.TEST_ARIA_ROLE_DESCRIPTION}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_ROLE_DESCRIPTION);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_ROLE_DESCRIPTION);
    }

    [Test]
    public async Task SetAriaRoleDescription() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_ROLE_DESCRIPTION);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaRoleDescription;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_ROLE_DESCRIPTION);
    }


    [Test]
    public async Task GetAriaRowCount() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRowCount = '{HTMLElementInProcessGroup.TEST_ARIA_ROW_COUNT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_ROW_COUNT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_ROW_COUNT);
    }

    [Test]
    public async Task SetAriaRowCount() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_ROW_COUNT);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaRowCount;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_ROW_COUNT);
    }


    [Test]
    public async Task GetAriaRowIndex() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRowIndex = '{HTMLElementInProcessGroup.TEST_ARIA_ROW_INDEX}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_ROW_INDEX);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_ROW_INDEX);
    }

    [Test]
    public async Task SetAriaRowIndex() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_ROW_INDEX);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaRowIndex;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_ROW_INDEX);
    }


    [Test]
    public async Task GetAriaRowIndexText() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRowIndexText = '{HTMLElementInProcessGroup.TEST_ARIA_ROW_INDEX_TEXT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_ROW_INDEX_TEXT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_ROW_INDEX_TEXT);
    }

    [Test]
    public async Task SetAriaRowIndexText() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_ROW_INDEX_TEXT);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaRowIndexText;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_ROW_INDEX_TEXT);
    }


    [Test]
    public async Task GetAriaRowSpan() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRowSpan = '{HTMLElementInProcessGroup.TEST_ARIA_ROW_SPAN}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_ROW_SPAN);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_ROW_SPAN);
    }

    [Test]
    public async Task SetAriaRowSpan() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_ROW_SPAN);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaRowSpan;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_ROW_SPAN);
    }


    [Test]
    public async Task GetAriaSelected() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaSelected = '{HTMLElementInProcessGroup.TEST_ARIA_SELECTED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_SELECTED);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_SELECTED);
    }

    [Test]
    public async Task SetAriaSelected() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_SELECTED);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaSelected;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_SELECTED);
    }


    [Test]
    public async Task GetAriaSetSize() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaSetSize = '{HTMLElementInProcessGroup.TEST_ARIA_SET_SIZE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_SET_SIZE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_SET_SIZE);
    }

    [Test]
    public async Task SetAriaSetSize() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_SET_SIZE);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaSetSize;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_SET_SIZE);
    }


    [Test]
    public async Task GetAriaSort() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaSort = '{HTMLElementInProcessGroup.TEST_ARIA_SORT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_SORT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_SORT);
    }

    [Test]
    public async Task SetAriaSort() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_SORT);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaSort;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_SORT);
    }


    [Test]
    public async Task GetAriaValueMax() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaValueMax = '{HTMLElementInProcessGroup.TEST_ARIA_VALUE_MAX}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_VALUE_MAX);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_VALUE_MAX);
    }

    [Test]
    public async Task SetAriaValueMax() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_VALUE_MAX);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaValueMax;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_VALUE_MAX);
    }


    [Test]
    public async Task GetAriaValueMin() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaValueMin = '{HTMLElementInProcessGroup.TEST_ARIA_VALUE_MIN}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_VALUE_MIN);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_VALUE_MIN);
    }

    [Test]
    public async Task SetAriaValueMin() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_VALUE_MIN);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaValueMin;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_VALUE_MIN);
    }


    [Test]
    public async Task GetAriaValueNow() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaValueNow = '{HTMLElementInProcessGroup.TEST_ARIA_VALUE_NOW}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_VALUE_NOW);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_VALUE_NOW);
    }

    [Test]
    public async Task SetAriaValueNow() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_VALUE_NOW);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaValueNow;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_VALUE_NOW);
    }


    [Test]
    public async Task GetAriaValueText() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaValueText = '{HTMLElementInProcessGroup.TEST_ARIA_VALUE_TEXT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ARIA_VALUE_TEXT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_VALUE_TEXT);
    }

    [Test]
    public async Task SetAriaValueText() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ARIA_VALUE_TEXT);

        string result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaValueText;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_ARIA_VALUE_TEXT);
    }


    // methods

    [Test]
    public async Task CheckVisibility() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_CHECK_VISIBILITY);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task ComputedStyleMap() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_COMPUTED_STYLE_MAP);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

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
    public async Task Matches() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_MATCHES);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task RequestFullscreen() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REQUEST_FULLSCREEN);

        bool isFullScreen = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<bool>("node => node === document.fullscreenElement;");
        await Assert.That(isFullScreen).IsTrue();
    }

    [Test]
    public async Task RequestPointerLock() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REQUEST_POINTER_LOCK);

        bool isPointerLocked = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<bool>("node => node === document.pointerLockElement;");
        await Assert.That(isPointerLocked).IsTrue();
    }

    [Test]
    public async Task IsDefaultNamespace() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_IS_DEFAULT_NAMESPACE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task LookupPrefix() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_LOOKUP_PREFIX);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(no prefix)");
    }

    [Test]
    public async Task LookupNamespaceURI() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_LOOKUP_NAMESPACE_URI);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("http://www.w3.org/1999/xhtml");
    }

    [Test]
    public async Task Normalize() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.append('-textNode1-', '-textNode2-');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_NORMALIZE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.lastChild.textContent;");
        await Assert.That(result).IsEqualTo("-textNode1--textNode2-");
    }


    // methods - Pointer Capture

    [Test] // tests "SetPointerCapture", "ReleasePointerCapture", "HasPointerCapture"
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


    // methods - Scroll

    [Test]
    public async Task Scroll() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SCROLL);

        int resultLeft = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        await Assert.That(resultLeft).IsGreaterThan(0);
        int resultTop = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        await Assert.That(resultTop).IsGreaterThan(0);
    }

    [Test]
    public async Task ScrollTo() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SCROLL_TO);

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


    // methods - Attribute

    [Test]
    public async Task GetAttribute() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ATTRIBUTE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.HTML_ELEMENT);
    }

    [Test]
    public async Task GetAttributeNS() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ATTRIBUTE_NS);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.HTML_ELEMENT);
    }

    [Test]
    public async Task GetAttributeNames() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ATTRIBUTE_NAMES);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task SetAttribute() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ATTRIBUTE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync(HTMLElementInProcessGroup.TEST_CUSTOM_NAME);
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task SetAttributeNS() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_SET_ATTRIBUTE_NS);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync(HTMLElementInProcessGroup.TEST_CUSTOM_NAME);
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task ToggleAttribute() {
        {
            await ExecuteTest(HTMLElementInProcessGroup.BUTTON_TOGGLE_ATTRIBUTE);

            string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync(HTMLElementInProcessGroup.TEST_CUSTOM_NAME);
            await Assert.That(result).IsNotNull();
        }

        {
            await ExecuteTest(HTMLElementInProcessGroup.BUTTON_TOGGLE_ATTRIBUTE);

            string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync(HTMLElementInProcessGroup.TEST_CUSTOM_NAME);
            await Assert.That(result).IsNull();
        }
    }

    [Test]
    public async Task RemoveAttribute() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('{HTMLElementInProcessGroup.TEST_CUSTOM_NAME}', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REMOVE_ATTRIBUTE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync(HTMLElementInProcessGroup.TEST_CUSTOM_NAME);
        await Assert.That(result).IsNull();
    }

    [Test]
    public async Task RemoveAttributeNS() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('{HTMLElementInProcessGroup.TEST_CUSTOM_NAME}', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REMOVE_ATTRIBUTE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).GetAttributeAsync(HTMLElementInProcessGroup.TEST_CUSTOM_NAME);
        await Assert.That(result).IsNull();
    }

    [Test]
    public async Task HasAttribute() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_HAS_ATTRIBUTE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task HasAttributeNS() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_HAS_ATTRIBUTE_NS);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task HasAttributes() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_HAS_ATTRIBUTES);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // methods - Tree-nodes

    [Test]
    public async Task GetElementsByClassName() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync($"node => node.children[0].setAttribute('class', '{HTMLElementInProcessGroup.TEST_CUSTOM_NAME}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ELEMENTS_BY_CLASS_NAME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetElementsByTagName() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ELEMENTS_BY_TAG_NAME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetElementsByTagNameNS() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_GET_ELEMENTS_BY_TAG_NAME_NS);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task QuerySelector() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_QUERY_SELECTOR);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task QuerySelectorAll() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_QUERY_SELECTOR_ALL);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task Closest() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_CLOSEST);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task Before_String() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_BEFORE_STRING);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.previousSibling.textContent;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task Before_HtmlElement() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_BEFORE_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.previousElementSibling.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.HIDDEN_ELEMENT);
    }

    [Test]
    public async Task After_String() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_AFTER_STRING);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.nextSibling.textContent;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task After_HtmlElement() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_AFTER_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.nextElementSibling.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.HIDDEN_ELEMENT);
    }


    [Test]
    public async Task Prepend_String() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_PREPEND_STRING);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.firstChild.textContent;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task Prepend_HtmlElement() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_PREPEND_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.firstChild.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.HIDDEN_ELEMENT);
    }

    [Test]
    public async Task AppendChild() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_APPEND_CHILD);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.lastChild.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.HIDDEN_ELEMENT);
    }

    [Test]
    public async Task Append_String() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_APPEND_STRING);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.lastChild.textContent;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task Append_HtmlElement() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_APPEND_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.lastChild.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.HIDDEN_ELEMENT);
    }

    [Test]
    public async Task InsertAdjacentElement() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_INSERT_ADJACENT_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.firstChild.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.HIDDEN_ELEMENT);
    }

    [Test]
    public async Task InsertAdjacentHTML() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_INSERT_ADJACENT_HTML);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.firstChild.outerHTML;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_INSERT_HTML);
    }

    [Test]
    public async Task InsertAdjacentText() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_INSERT_ADJACENT_TEXT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.firstChild.textContent;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_CUSTOM_VALUE);
    }


    [Test]
    public async Task RemoveChild() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).EvaluateAsync($"""node => document.querySelector("[data-testid='{HTMLElementInProcessGroup.HTML_ELEMENT}']").appendChild(node);""");
        await Task.Delay(SMALL_WAIT_TIME);
        int childCount = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.children.length;");
        await Assert.That(childCount).IsEqualTo(4);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REMOVE_CHILD);

        int result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.children.length;");
        await Assert.That(result).IsEqualTo(3);
    }

    [Test]
    public async Task Remove() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REMOVE);

        bool result = await Page.EvaluateAsync<bool>($"""document.querySelector("[data-testid='{HTMLElementInProcessGroup.HTML_ELEMENT}']") === null;""");
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReplaceChild() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).EvaluateAsync($"""node => document.querySelector("[data-testid='{HTMLElementInProcessGroup.HTML_ELEMENT}']").appendChild(node);""");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REPLACE_CHILD);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT).EvaluateAsync<string?>("node => node.parentElement.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.HTML_ELEMENT);
    }

    [Test]
    public async Task ReplaceChild_Index() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).EvaluateAsync($"""node => document.querySelector("[data-testid='{HTMLElementInProcessGroup.HTML_ELEMENT}']").prepend(node);""");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REPLACE_CHILD_INDEX);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.POPOVER_ELEMENT).EvaluateAsync<string?>("node => node.parentElement.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.HTML_ELEMENT);
    }

    [Test]
    public async Task ReplaceWith_String() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REPLACE_WITH_STRING);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync<string?>("node => node.firstChild.textContent;");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task ReplaceWith_HtmlElement() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REPLACE_WITH_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync<string?>("node => node.firstElementChild.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.HIDDEN_ELEMENT);
    }

    [Test]
    public async Task ReplaceChildren_String() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REPLACE_CHILDREN_STRING);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.children.length === 0 ? node.firstChild.textContent : 'child-count is not 0';");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task ReplaceChildren_HtmlElement() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REPLACE_CHILDREN_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.children.length === 1 ? node.firstElementChild.getAttribute('data-testid') : 'child-count is not 1';");
        await Assert.That(result).IsEqualTo(HTMLElementInProcessGroup.HIDDEN_ELEMENT);
    }


    [Test]
    public async Task CloneNode() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_CLONE_NODE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task IsSameNode() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_IS_SAME_NODE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task IsEqualNode() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_IS_EQUAL_NODE);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task Contains() {
        await Page.GetByTestId(HTMLElementInProcessGroup.HIDDEN_ELEMENT).EvaluateAsync($"""node => document.querySelector("[data-testid='{HTMLElementInProcessGroup.HTML_ELEMENT}']").appendChild(node);""");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_CONTAINS);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task CompareDocumentPosition() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_COMPARE_DOCUMENT_POSITION);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("4");
    }


    // events

    [Test]
    public async Task RegisterOnTransitionStart() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_TRANSITION_START);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_TRANSITIONSTART_EVENT);
    }

    [Test]
    public async Task RegisterOnTransitionEnd() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_TRANSITION_END);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_TRANSITIONEND_EVENT);
    }

    [Test]
    public async Task RegisterOnTransitionRun() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_TRANSITION_RUN);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_TRANSITIONRUN_EVENT);
    }

    [Test]
    public async Task RegisterOnTransitionCancel() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_TRANSITION_CANCEL);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#222';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_TRANSITIONCANCEL_EVENT);
    }


    [Test]
    public async Task RegisterOnAnimationStart() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_ANIMATION_START);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_ANIMATIONSTART_EVENT);
    }

    [Test]
    public async Task RegisterOnAnimationnEnd() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_ANIMATION_END);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_ANIMATIONEND_EVENT);
    }

    [Test]
    public async Task RegisterOnAnimationIteration() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_ANIMATION_ITERATION);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start-infinite');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_ANIMATIONITERATION_EVENT);
    }

    [Test]
    public async Task RegisterOnAnimationCancel() {
        await ExecuteTest(HTMLElementInProcessGroup.BUTTON_REGISTER_ON_ANIMATION_CANCEL);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start-infinite');");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(HTMLElementInProcessGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.remove('animation-start-infinite');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementInProcessGroup.TEST_ANIMATIONCANCEL_EVENT);
    }

    #endregion
}
