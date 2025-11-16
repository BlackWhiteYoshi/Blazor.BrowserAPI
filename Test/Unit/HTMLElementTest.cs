using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using TUnit.Core.Interfaces;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class HTMLElementTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override Task InitializeAsync()
        => (TestContext.Current as ITestMetadata)?.DisplayName switch {
            nameof(GetAccessKeyLabel_Property) or nameof(GetAccessKeyLabel_Method) => NewPage(BrowserId.Firefox),
            _ => NewPage(BrowserId.Chromium)
        };


    [Test]
    public async Task ToHTMLDialogElement() {
        await ExecuteTest(HTMLElementGroup.BUTTON_TO_HTML_DIALOG_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task ToHTMLMediaElement() {
        await ExecuteTest(HTMLElementGroup.BUTTON_TO_HTML_MEDIA_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    #region HTMLElement

    [Test]
    public async Task GetAccessKey_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('accessKey', '{HTMLElementGroup.TEST_ACCESS_KEY}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ACCESS_KEY_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ACCESS_KEY);
    }

    [Test]
    public async Task GetAccessKey_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('accessKey', '{HTMLElementGroup.TEST_ACCESS_KEY}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ACCESS_KEY_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ACCESS_KEY);
    }

    [Test]
    public async Task SetAccessKey() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ACCESS_KEY);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("accessKey");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ACCESS_KEY);
    }


    [Test]
    public async Task GetAccessKeyLabel_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('accessKey', '{HTMLElementGroup.TEST_ACCESS_KEY}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ACCESS_KEY_LABEL_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).EndsWith(HTMLElementGroup.TEST_ACCESS_KEY);
    }

    [Test]
    public async Task GetAccessKeyLabel_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('accessKey', '{HTMLElementGroup.TEST_ACCESS_KEY}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ACCESS_KEY_LABEL_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).EndsWith(HTMLElementGroup.TEST_ACCESS_KEY);
    }


    [Test]
    public async Task GetAttributeStyleMap_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.style.{HTMLElementGroup.TEST_STYLE_NAME} = '{HTMLElementGroup.TEST_STYLE_VALUE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ATTRIBUTE_STYLE_MAP_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo($"{HTMLElementGroup.TEST_STYLE_NAME} = {HTMLElementGroup.TEST_STYLE_VALUE}");
    }

    [Test]
    public async Task GetAttributeStyleMap_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.style.{HTMLElementGroup.TEST_STYLE_NAME} = '{HTMLElementGroup.TEST_STYLE_VALUE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ATTRIBUTE_STYLE_MAP_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo($"{HTMLElementGroup.TEST_STYLE_NAME} = {HTMLElementGroup.TEST_STYLE_VALUE}");
    }

    [Test]
    public async Task SetAttributeStyleMap() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ATTRIBUTE_STYLE_MAP);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("style");
        await Assert.That(result).IsEqualTo($"{HTMLElementGroup.TEST_STYLE_NAME}: {HTMLElementGroup.TEST_STYLE_VALUE};");
    }

    [Test]
    public async Task RemoveAttributeStyleMap() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.style.{HTMLElementGroup.TEST_STYLE_NAME} = '{HTMLElementGroup.TEST_STYLE_VALUE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_REMOVE_ATTRIBUTE_STYLE_MAP);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("style");
        await Assert.That(result).IsEmpty();
    }


    [Test]
    public async Task GetAutocapitalize_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('autocapitalize', '{HTMLElementGroup.TEST_AUTOCAPITALIZE}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_AUTOCAPITALIZE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_AUTOCAPITALIZE);
    }

    [Test]
    public async Task GetAutocapitalize_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('autocapitalize', '{HTMLElementGroup.TEST_AUTOCAPITALIZE}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_AUTOCAPITALIZE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_AUTOCAPITALIZE);
    }

    [Test]
    public async Task SetAutocapitalize() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_AUTOCAPITALIZE);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("autocapitalize");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_AUTOCAPITALIZE);
    }


    [Test]
    public async Task GetAutofocus_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('autofocus', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_AUTOFOCUS_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetAutofocus_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('autofocus', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_AUTOFOCUS_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetAutofocus() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_AUTOFOCUS);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("autofocus");
        await Assert.That(result).IsNotNull();
    }


    [Test]
    public async Task GetContentEditable_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('contentEditable', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CONTENT_EDITABLE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("true");
    }

    [Test]
    public async Task GetContentEditable_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('contentEditable', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CONTENT_EDITABLE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("true");
    }

    [Test]
    public async Task SetContentEditable() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_CONTENT_EDITABLE);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("contenteditable");
        await Assert.That(result).IsEqualTo("true");
    }


    [Test]
    public async Task GetDataset_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('data-{HTMLElementGroup.TEST_DATASET_NAME}', '{HTMLElementGroup.TEST_DATASET_VALUE}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_DATASET_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo($"testid = htmlelement-html-element, {HTMLElementGroup.TEST_DATASET_NAME} = {HTMLElementGroup.TEST_DATASET_VALUE}");
    }

    [Test]
    public async Task GetDataset_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('data-{HTMLElementGroup.TEST_DATASET_NAME}', '{HTMLElementGroup.TEST_DATASET_VALUE}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_DATASET_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo($"testid = htmlelement-html-element, {HTMLElementGroup.TEST_DATASET_NAME} = {HTMLElementGroup.TEST_DATASET_VALUE}");

    }

    [Test]
    public async Task SetDataset() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_DATASET);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync($"data-{HTMLElementGroup.TEST_DATASET_NAME}");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_DATASET_VALUE);
    }

    [Test]
    public async Task RemoveDataset() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('data-{HTMLElementGroup.TEST_DATASET_NAME}', '{HTMLElementGroup.TEST_DATASET_VALUE}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_REMOVE_DATASET);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync($"data-{HTMLElementGroup.TEST_DATASET_NAME}");
        await Assert.That(result).IsNull();
    }


    [Test]
    public async Task GetDir_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('dir', '{HTMLElementGroup.TEST_DIR}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_DIR_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_DIR);
    }

    [Test]
    public async Task GetDir_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('dir', '{HTMLElementGroup.TEST_DIR}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_DIR_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_DIR);
    }

    [Test]
    public async Task SetDir() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_DIR);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("dir");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_DIR);
    }


    [Test]
    public async Task GetDraggable_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('draggable', 'true');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_DRAGGABLE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetDraggable_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('draggable', 'true');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_DRAGGABLE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetDraggable() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_DRAGGABLE);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("draggable");
        await Assert.That(result).IsEqualTo("true");
    }


    [Test]
    public async Task GetEnterKeyHint_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('enterKeyHint', '{HTMLElementGroup.TEST_ENTER_KEY_HINT}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ENTER_KEY_HINT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ENTER_KEY_HINT);
    }

    [Test]
    public async Task GetEnterKeyHint_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('enterKeyHint', '{HTMLElementGroup.TEST_ENTER_KEY_HINT}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ENTER_KEY_HINT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ENTER_KEY_HINT);
    }

    [Test]
    public async Task SetEnterKeyHint() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ENTER_KEY_HINT);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("enterKeyHint");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ENTER_KEY_HINT);
    }


    [Test]
    public async Task GetHidden_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('hidden', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_HIDDEN_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetHidden_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('hidden', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_HIDDEN_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetHidden() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_HIDDEN);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("hidden");
        await Assert.That(result).IsNotNull();
    }


    [Test]
    public async Task GetInert_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('inert', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_INERT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetInert_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('inert', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_INERT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetInert() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_INERT);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("inert");
        await Assert.That(result).IsNotNull();
    }


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
    public async Task GetInputMode_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('inputMode', '{HTMLElementGroup.TEST_INPUT_MODE}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_INPUT_MODE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_INPUT_MODE);
    }

    [Test]
    public async Task GetInputMode_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('inputMode', '{HTMLElementGroup.TEST_INPUT_MODE}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_INPUT_MODE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_INPUT_MODE);
    }

    [Test]
    public async Task SetInputMode() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_INPUT_MODE);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("inputMode");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_INPUT_MODE);
    }


    [Test]
    public async Task GetIsContentEditable_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_IS_CONTENT_EDITABLE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetIsContentEditable_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_IS_CONTENT_EDITABLE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task GetLang_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('lang', '{HTMLElementGroup.TEST_LANG}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_LANG_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_LANG);
    }

    [Test]
    public async Task GetLang_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('lang', '{HTMLElementGroup.TEST_LANG}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_LANG_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_LANG);
    }

    [Test]
    public async Task SetLang() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_LANG);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("lang");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_LANG);
    }


    [Test]
    public async Task GetNonce_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('nonce', '{HTMLElementGroup.TEST_NONCE}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_NONCE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_NONCE);
    }

    [Test]
    public async Task GetNonce_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('nonce', '{HTMLElementGroup.TEST_NONCE}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_NONCE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_NONCE);
    }

    [Test]
    public async Task SetNonce() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_NONCE);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.nonce;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_NONCE);
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
    public async Task GetPopover_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('popover', '{HTMLElementGroup.TEST_POPOVER}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_POPOVER_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_POPOVER);
    }

    [Test]
    public async Task GetPopover_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('popover', '{HTMLElementGroup.TEST_POPOVER}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_POPOVER_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_POPOVER);
    }

    [Test]
    public async Task SetPopover() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_POPOVER);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("popover");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_POPOVER);
    }


    [Test]
    public async Task GetSpellcheck_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('spellcheck', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SPELLCHECK_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetSpellcheck_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('spellcheck', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SPELLCHECK_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetSpellcheck() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_SPELLCHECK);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("spellcheck");
        await Assert.That(result).IsEqualTo("true");
    }


    [Test]
    public async Task GetStyle_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.style.visibility = 'visible';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_STYLE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("visibility: visible;");
    }

    [Test]
    public async Task GetStyle_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.style.visibility = 'visible';");
        await Task.Delay(SMALL_WAIT_TIME);

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
    public async Task GetTabIndex_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('tabIndex', '{HTMLElementGroup.TEST_TAB_INDEX}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_TAB_INDEX_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_TAB_INDEX.ToString());
    }

    [Test]
    public async Task GetTabIndex_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('tabIndex', '{HTMLElementGroup.TEST_TAB_INDEX}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_TAB_INDEX_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_TAB_INDEX.ToString());
    }

    [Test]
    public async Task SetTabIndex() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_TAB_INDEX);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("tabIndex");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_TAB_INDEX.ToString());
    }


    [Test]
    public async Task GetTitle_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('title', '{HTMLElementGroup.TEST_TITLE}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_TITLE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_TITLE);
    }

    [Test]
    public async Task GetTitle_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('title', '{HTMLElementGroup.TEST_TITLE}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_TITLE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_TITLE);
    }

    [Test]
    public async Task SetTitle() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_TITLE);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("title");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_TITLE);
    }


    [Test]
    public async Task GetTranslate_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('translate', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_TRANSLATE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetTranslate_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('translate', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_TRANSLATE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetTranslate() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_TRANSLATE);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync("translate");
        await Assert.That(result).IsEqualTo("yes");
    }


    // extra

    [Test]
    public async Task HasFocus_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.focus();");
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_HASFOCUS_PROPERTY).HoverAsync(); // button has @onpointerenter-trigger for not loosing focus

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task HasFocus_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.focus();");
        await Page.GetByTestId(HTMLElementGroup.BUTTON_GET_HASFOCUS_METHOD).HoverAsync(); // button has @onpointerenter-trigger for not loosing focus

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // methods

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

        await Page.GetByTestId(HTMLElementGroup.BUTTON_BLUR).HoverAsync(); // button has @onpointerenter-trigger for not loosing focus

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


    // events

    [Test]
    public async Task RegisterOnChange() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync("""
            node => {
                const tempElement = document.createElement("input");
                tempElement.setAttribute("data-testid", "temp");
                node.appendChild(tempElement);
            }
            """);
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_CHANGE);

        await Page.GetByTestId("temp").FillAsync("something");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").BlurAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_EVENT_CHANGE);
    }

    [Test]
    public async Task RegisterOnCommand() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_COMMAND);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync("""
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

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("id='temp', command='show-popover'");
    }

    [Test]
    public async Task RegisterOnLoad() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync("""
            node => {
                const tempElement = document.createElement("img");
                tempElement.setAttribute("data-testid", "temp");
                node.appendChild(tempElement);
            }
            """);
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_LOAD);

        await Page.GetByTestId("temp").EvaluateAsync("node => node.src = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADklEQVR4AWL69//ffwAAAAD//+Rp924AAAAGSURBVAMACf8D/Z3TzWsAAAAASUVORK5CYII=';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task RegisterOnError() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync("""
            node => {
                const tempElement = document.createElement("img");
                tempElement.setAttribute("data-testid", "temp");
                node.appendChild(tempElement);
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_ERROR);

        await Page.GetByTestId("temp").EvaluateAsync("node => node.src = 'wrong/path';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }


    [Test]
    public async Task RegisterOnDrag() {
        await Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.removeAttribute('popover');");
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.setAttribute("draggable", "true");
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_DRAG);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).DragToAsync(Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='uninitialized', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragStart() {
        await Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.removeAttribute('popover');");
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.setAttribute("draggable", "true");
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_DRAG_START);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).DragToAsync(Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='uninitialized', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragEnd() {
        await Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.removeAttribute('popover');");
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.setAttribute("draggable", "true");
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_DRAG_END);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).DragToAsync(Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='uninitialized', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragEnter() {
        await Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.removeAttribute('popover');");
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.setAttribute("draggable", "true");
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_DRAG_ENTER);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).DragToAsync(Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='all', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragLeave() {
        await Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.removeAttribute('popover');");
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.setAttribute("draggable", "true");
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_DRAG_LEAVE);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).DragToAsync(Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='all', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragOver() {
        await Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.removeAttribute('popover');");
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.setAttribute("draggable", "true");
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_DRAG_OVER);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).DragToAsync(Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='all', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDrop() {
        await Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("popover");
                node.addEventListener("dragover", e => e.preventDefault());
            }
            """);
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.setAttribute("draggable", "true");
            };
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_DROP);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).DragToAsync(Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='copy', effectAllowed='all', types='[]', files='[]'");
    }


    [Test]
    public async Task RegisterOnToggle() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_TOGGLE);

        await Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.showPopover();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("oldState='closed', newState='open'");
    }

    [Test]
    public async Task RegisterOnBeforeToggle() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_BEFORE_TOGGLE);

        await Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT).EvaluateAsync("node => node.showPopover();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("oldState='closed', newState='open'");
    }

    #endregion


    #region Node/Element

    [Test]
    public async Task GetAttributes_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ATTRIBUTES_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("""{"data-testid":"htmlelement-html-element","class":"html-element",""");
    }

    [Test]
    public async Task GetAttributes_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ATTRIBUTES_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("""{"data-testid":"htmlelement-html-element","class":"html-element",""");
    }


    [Test]
    public async Task GetClassList_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLASS_LIST_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("html-element");
    }

    [Test]
    public async Task GetClassList_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLASS_LIST_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("html-element");
    }


    [Test]
    public async Task GetClassName_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLASS_NAME_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("html-element");
    }

    [Test]
    public async Task GetClassName_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLASS_NAME_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("html-element");
    }

    [Test]
    public async Task SetClassName() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_CLASS_NAME);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.className;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_CLASSNAME);
    }


    [Test]
    public async Task GetClientWidth_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENT_WIDTH_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetClientWidth_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENT_WIDTH_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetClientHeight_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENT_HEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetClientHeight_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENT_HEIGHT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetClientLeft_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENT_LEFT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetClientLeft_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENT_LEFT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetClientTop_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENT_TOP_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task GetClientTop_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENT_TOP_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
    }


    [Test]
    public async Task GetCurrentCSSZoom_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CURRENT_CSS_ZOOM_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetCurrentCSSZoom_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CURRENT_CSS_ZOOM_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }


    [Test]
    public async Task GetId_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.id = '{HTMLElementGroup.TEST_ID}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ID_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ID);
    }

    [Test]
    public async Task GetId_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.id = '{HTMLElementGroup.TEST_ID}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ID_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ID);
    }

    [Test]
    public async Task SetId() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ID);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.id;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ID);
    }


    [Test]
    public async Task GetIsConnected_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_IS_CONNECTED_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetIsConnected_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_IS_CONNECTED_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetInnerHtml_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_INNER_HTML_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("<!--!-->\n            test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u>");
    }

    [Test]
    public async Task GetInnerHtml_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_INNER_HTML_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("<!--!-->\n            test <!--!--><b>bold</b> <!--!--><i>italic</i> <!--!--><u>underlined</u>");
    }

    [Test]
    public async Task SetInnerHtml() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_INNER_HTML);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).InnerHTMLAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_INNERHTML);
    }


    [Test]
    public async Task GetOuterHtml_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OUTER_HTML_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("""<div data-testid="htmlelement-html-element" class="html-element" """);
    }

    [Test]
    public async Task GetOuterHtml_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_OUTER_HTML_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("""<div data-testid="htmlelement-html-element" class="html-element" """);
    }

    [Test]
    public async Task SetOuterHtml() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_OUTER_HTML);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).InnerHTMLAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_OUTERHTML);
    }


    [Test]
    public async Task GetPart_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('part', 'header-part body-part');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_PART_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("header-part,body-part");
    }

    [Test]
    public async Task GetPart_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('part', 'header-part body-part');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_PART_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("header-part,body-part");
    }


    [Test]
    public async Task GetScrollWidth_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLL_WIDTH_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(50);
    }

    [Test]
    public async Task GetScrollWidth_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLL_WIDTH_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(50);
    }

    [Test]
    public async Task GetScrollHeight_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLL_HEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(50);
    }

    [Test]
    public async Task GetScrollHeight_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLL_HEIGHT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(50);
    }

    [Test]
    public async Task GetScrollLeft_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLL_LEFT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsEqualTo(0);
    }

    [Test]
    public async Task GetScrollLeft_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLL_LEFT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsEqualTo(0);
    }

    [Test]
    public async Task SetScrollLeft() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_SCROLL_LEFT);

        int result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        await Assert.That(result).IsGreaterThan(0);
    }

    [Test]
    public async Task GetScrollTop_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLL_TOP_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsEqualTo(0);
    }

    [Test]
    public async Task GetScrollTop_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SCROLL_TOP_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isInteger).IsTrue();
        await Assert.That(resultAsNumber).IsEqualTo(0);
    }

    [Test]
    public async Task SetScrollTop() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_SCROLL_TOP);

        int result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        await Assert.That(result).IsGreaterThan(0);
    }


    [Test]
    public async Task GetSlot_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.slot = '{HTMLElementGroup.TEST_SLOT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SLOT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_SLOT);
    }

    [Test]
    public async Task GetSlot_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.slot = '{HTMLElementGroup.TEST_SLOT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_SLOT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_SLOT);
    }

    [Test]
    public async Task SetSlot() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_SLOT);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.slot;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_SLOT);
    }


    [Test]
    public async Task GetTextContent_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_TEXT_CONTENT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("\n            test bold italic underlined");
    }

    [Test]
    public async Task GetTextContent_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_TEXT_CONTENT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("\n            test bold italic underlined");
    }

    [Test]
    public async Task SetTextContent() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_TEXT_CONTENT);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.textContent;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_TEXT_CONTENT);
    }


    [Test]
    public async Task GetLocalName_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_LOCAL_NAME_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("div");
    }

    [Test]
    public async Task GetLocalName_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_LOCAL_NAME_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("div");
    }

    [Test]
    public async Task GetNamespaceURI_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_NAMESPACE_URI_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("http://www.w3.org/1999/xhtml");
    }

    [Test]
    public async Task GetNamespaceURI_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_NAMESPACE_URI_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("http://www.w3.org/1999/xhtml");
    }

    [Test]
    public async Task GetPrefix_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_PREFIX_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("no prefix");
    }

    [Test]
    public async Task GetPrefix_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_PREFIX_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("no prefix");
    }

    [Test]
    public async Task GetBaseURI_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_BASE_URI_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/");
    }

    [Test]
    public async Task GetBaseURI_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_BASE_URI_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000/");
    }

    [Test]
    public async Task GetTagName_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_TAG_NAME_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("DIV");
    }

    [Test]
    public async Task GetTagName_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_TAG_NAME_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("DIV");
    }

    [Test]
    public async Task GetNodeName_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_NODE_NAME_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("DIV");
    }

    [Test]
    public async Task GetNodeName_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_NODE_NAME_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("DIV");
    }

    [Test]
    public async Task GetNodeType_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_NODE_TYPE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetNodeType_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_NODE_TYPE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }


    // properties - Tree nodes

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
    public async Task GetFirstElementChild_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_FIRST_ELEMENT_CHILD_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetFirstElementChild_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_FIRST_ELEMENT_CHILD_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetLastElementChild_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_LAST_ELEMENT_CHILD_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetLastElementChild_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_LAST_ELEMENT_CHILD_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetPreviousElementSibling_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_PREVIOUS_ELEMENT_SIBLING_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetPreviousElementSibling_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_PREVIOUS_ELEMENT_SIBLING_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task GetNextElementSibling_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_NEXT_ELEMENT_SIBLING_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetNextElementSibling_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_NEXT_ELEMENT_SIBLING_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task GetParentElement_Property() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_PARENT_ELEMENT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetParentElement_Method() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_PARENT_ELEMENT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // properties - ARIA

    [Test]
    public async Task GetAriaAtomic_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaAtomic = '{HTMLElementGroup.TEST_ARIA_ATOMIC}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_ATOMIC_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ATOMIC);
    }

    [Test]
    public async Task GetAriaAtomic_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaAtomic = '{HTMLElementGroup.TEST_ARIA_ATOMIC}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_ATOMIC_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ATOMIC);
    }

    [Test]
    public async Task SetAriaAtomic() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_ATOMIC);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaAtomic;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ATOMIC);
    }


    [Test]
    public async Task GetAriaAutoComplete_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaAutoComplete = '{HTMLElementGroup.TEST_ARIA_AUTO_COMPLETE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_AUTO_COMPLETE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_AUTO_COMPLETE);
    }

    [Test]
    public async Task GetAriaAutoComplete_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaAutoComplete = '{HTMLElementGroup.TEST_ARIA_AUTO_COMPLETE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_AUTO_COMPLETE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_AUTO_COMPLETE);
    }

    [Test]
    public async Task SetAriaAutoComplete() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_AUTO_COMPLETE);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaAutoComplete;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_AUTO_COMPLETE);
    }


    [Test]
    public async Task GetAriaBrailleLabel_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaBrailleLabel = '{HTMLElementGroup.TEST_ARIA_BRAILLE_LABEL}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_BRAILLE_LABEL_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_BRAILLE_LABEL);
    }

    [Test]
    public async Task GetAriaBrailleLabel_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaBrailleLabel = '{HTMLElementGroup.TEST_ARIA_BRAILLE_LABEL}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_BRAILLE_LABEL_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_BRAILLE_LABEL);
    }

    [Test]
    public async Task SetAriaBrailleLabel() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_BRAILLE_LABEL);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaBrailleLabel;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_BRAILLE_LABEL);
    }


    [Test]
    public async Task GetAriaBrailleRoleDescription_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaBrailleRoleDescription = '{HTMLElementGroup.TEST_ARIA_BRAILLE_ROLE_DESCRIPTION}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_BRAILLE_ROLE_DESCRIPTION_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_BRAILLE_ROLE_DESCRIPTION);
    }

    [Test]
    public async Task GetAriaBrailleRoleDescription_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaBrailleRoleDescription = '{HTMLElementGroup.TEST_ARIA_BRAILLE_ROLE_DESCRIPTION}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_BRAILLE_ROLE_DESCRIPTION_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_BRAILLE_ROLE_DESCRIPTION);
    }

    [Test]
    public async Task SetAriaBrailleRoleDescription() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_BRAILLE_ROLE_DESCRIPTION);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaBrailleRoleDescription;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_BRAILLE_ROLE_DESCRIPTION);
    }


    [Test]
    public async Task GetAriaBusy_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaBusy = '{HTMLElementGroup.TEST_ARIA_BUSY}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_BUSY_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_BUSY);
    }

    [Test]
    public async Task GetAriaBusy_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaBusy = '{HTMLElementGroup.TEST_ARIA_BUSY}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_BUSY_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_BUSY);
    }

    [Test]
    public async Task SetAriaBusy() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_BUSY);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaBusy;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_BUSY);
    }


    [Test]
    public async Task GetAriaChecked_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaChecked = '{HTMLElementGroup.TEST_ARIA_CHECKED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_CHECKED_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_CHECKED);
    }

    [Test]
    public async Task GetAriaChecked_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaChecked = '{HTMLElementGroup.TEST_ARIA_CHECKED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_CHECKED_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_CHECKED);
    }

    [Test]
    public async Task SetAriaChecked() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_CHECKED);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaChecked;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_CHECKED);
    }


    [Test]
    public async Task GetAriaColCount_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaColCount = '{HTMLElementGroup.TEST_ARIA_COL_COUNT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_COL_COUNT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_COL_COUNT);
    }

    [Test]
    public async Task GetAriaColCount_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaColCount = '{HTMLElementGroup.TEST_ARIA_COL_COUNT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_COL_COUNT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_COL_COUNT);
    }

    [Test]
    public async Task SetAriaColCount() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_COL_COUNT);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaColCount;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_COL_COUNT);
    }


    [Test]
    public async Task GetAriaColIndex_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaColIndex = '{HTMLElementGroup.TEST_ARIA_COL_INDEX}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_COL_INDEX_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_COL_INDEX);
    }

    [Test]
    public async Task GetAriaColIndex_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaColIndex = '{HTMLElementGroup.TEST_ARIA_COL_INDEX}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_COL_INDEX_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_COL_INDEX);
    }

    [Test]
    public async Task SetAriaColIndex() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_COL_INDEX);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaColIndex;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_COL_INDEX);
    }


    [Test]
    public async Task GetAriaColIndexText_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaColIndexText = '{HTMLElementGroup.TEST_ARIA_COL_INDEX_TEXT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_COL_INDEX_TEXT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_COL_INDEX_TEXT);
    }

    [Test]
    public async Task GetAriaColIndexText_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaColIndexText = '{HTMLElementGroup.TEST_ARIA_COL_INDEX_TEXT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_COL_INDEX_TEXT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_COL_INDEX_TEXT);
    }

    [Test]
    public async Task SetAriaColIndexText() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_COL_INDEX_TEXT);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaColIndexText;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_COL_INDEX_TEXT);
    }


    [Test]
    public async Task GetAriaColSpan_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaColSpan = '{HTMLElementGroup.TEST_ARIA_COL_SPAN}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_COL_SPAN_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_COL_SPAN);
    }

    [Test]
    public async Task GetAriaColSpan_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaColSpan = '{HTMLElementGroup.TEST_ARIA_COL_SPAN}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_COL_SPAN_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_COL_SPAN);
    }

    [Test]
    public async Task SetAriaColSpan() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_COL_SPAN);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaColSpan;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_COL_SPAN);
    }


    [Test]
    public async Task GetAriaCurrent_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaCurrent = '{HTMLElementGroup.TEST_ARIA_CURRENT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_CURRENT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_CURRENT);
    }

    [Test]
    public async Task GetAriaCurrent_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaCurrent = '{HTMLElementGroup.TEST_ARIA_CURRENT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_CURRENT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_CURRENT);
    }

    [Test]
    public async Task SetAriaCurrent() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_CURRENT);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaCurrent;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_CURRENT);
    }


    [Test]
    public async Task GetAriaDescription_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaDescription = '{HTMLElementGroup.TEST_ARIA_DESCRIPTION}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_DESCRIPTION_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_DESCRIPTION);
    }

    [Test]
    public async Task GetAriaDescription_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaDescription = '{HTMLElementGroup.TEST_ARIA_DESCRIPTION}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_DESCRIPTION_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_DESCRIPTION);
    }

    [Test]
    public async Task SetAriaDescription() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_DESCRIPTION);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaDescription;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_DESCRIPTION);
    }


    [Test]
    public async Task GetAriaDisabled_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaDisabled = '{HTMLElementGroup.TEST_ARIA_DISABLED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_DISABLED_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_DISABLED);
    }

    [Test]
    public async Task GetAriaDisabled_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaDisabled = '{HTMLElementGroup.TEST_ARIA_DISABLED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_DISABLED_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_DISABLED);
    }

    [Test]
    public async Task SetAriaDisabled() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_DISABLED);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaDisabled;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_DISABLED);
    }


    [Test]
    public async Task GetAriaExpanded_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaExpanded = '{HTMLElementGroup.TEST_ARIA_EXPANDED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_EXPANDED_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_EXPANDED);
    }

    [Test]
    public async Task GetAriaExpanded_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaExpanded = '{HTMLElementGroup.TEST_ARIA_EXPANDED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_EXPANDED_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_EXPANDED);
    }

    [Test]
    public async Task SetAriaExpanded() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_EXPANDED);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaExpanded;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_EXPANDED);
    }


    [Test]
    public async Task GetAriaHasPopup_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaHasPopup = '{HTMLElementGroup.TEST_ARIA_HAS_POPUP}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_HAS_POPUP_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_HAS_POPUP);
    }

    [Test]
    public async Task GetAriaHasPopup_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaHasPopup = '{HTMLElementGroup.TEST_ARIA_HAS_POPUP}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_HAS_POPUP_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_HAS_POPUP);
    }

    [Test]
    public async Task SetAriaHasPopup() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_HAS_POPUP);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaHasPopup;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_HAS_POPUP);
    }


    [Test]
    public async Task GetAriaHidden_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaHidden = '{HTMLElementGroup.TEST_ARIA_HIDDEN}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_HIDDEN_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_HIDDEN);
    }

    [Test]
    public async Task GetAriaHidden_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaHidden = '{HTMLElementGroup.TEST_ARIA_HIDDEN}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_HIDDEN_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_HIDDEN);
    }

    [Test]
    public async Task SetAriaHidden() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_HIDDEN);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaHidden;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_HIDDEN);
    }


    [Test]
    public async Task GetAriaInvalid_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaInvalid = '{HTMLElementGroup.TEST_ARIA_INVALID}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_INVALID_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_INVALID);
    }

    [Test]
    public async Task GetAriaInvalid_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaInvalid = '{HTMLElementGroup.TEST_ARIA_INVALID}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_INVALID_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_INVALID);
    }

    [Test]
    public async Task SetAriaInvalid() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_INVALID);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaInvalid;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_INVALID);
    }


    [Test]
    public async Task GetAriaKeyShortcuts_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaKeyShortcuts = '{HTMLElementGroup.TEST_ARIA_KEY_SHORTCUTS}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_KEY_SHORTCUTS_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_KEY_SHORTCUTS);
    }

    [Test]
    public async Task GetAriaKeyShortcuts_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaKeyShortcuts = '{HTMLElementGroup.TEST_ARIA_KEY_SHORTCUTS}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_KEY_SHORTCUTS_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_KEY_SHORTCUTS);
    }

    [Test]
    public async Task SetAriaKeyShortcuts() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_KEY_SHORTCUTS);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaKeyShortcuts;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_KEY_SHORTCUTS);
    }


    [Test]
    public async Task GetAriaLabel_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaLabel = '{HTMLElementGroup.TEST_ARIA_LABEL}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_LABEL_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_LABEL);
    }

    [Test]
    public async Task GetAriaLabel_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaLabel = '{HTMLElementGroup.TEST_ARIA_LABEL}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_LABEL_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_LABEL);
    }

    [Test]
    public async Task SetAriaLabel() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_LABEL);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaLabel;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_LABEL);
    }


    [Test]
    public async Task GetAriaLevel_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaLevel = '{HTMLElementGroup.TEST_ARIA_LEVEL}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_LEVEL_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_LEVEL);
    }

    [Test]
    public async Task GetAriaLevel_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaLevel = '{HTMLElementGroup.TEST_ARIA_LEVEL}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_LEVEL_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_LEVEL);
    }

    [Test]
    public async Task SetAriaLevel() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_LEVEL);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaLevel;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_LEVEL);
    }


    [Test]
    public async Task GetAriaLive_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaLive = '{HTMLElementGroup.TEST_ARIA_LIVE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_LIVE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_LIVE);
    }

    [Test]
    public async Task GetAriaLive_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaLive = '{HTMLElementGroup.TEST_ARIA_LIVE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_LIVE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_LIVE);
    }

    [Test]
    public async Task SetAriaLive() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_LIVE);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaLive;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_LIVE);
    }


    [Test]
    public async Task GetAriaModal_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaModal = '{HTMLElementGroup.TEST_ARIA_MODAL}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_MODAL_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_MODAL);
    }

    [Test]
    public async Task GetAriaModal_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaModal = '{HTMLElementGroup.TEST_ARIA_MODAL}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_MODAL_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_MODAL);
    }

    [Test]
    public async Task SetAriaModal() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_MODAL);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaModal;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_MODAL);
    }


    [Test]
    public async Task GetAriaMultiline_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaMultiline = '{HTMLElementGroup.TEST_ARIA_MULTILINE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_MULTILINE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_MULTILINE);
    }

    [Test]
    public async Task GetAriaMultiline_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaMultiline = '{HTMLElementGroup.TEST_ARIA_MULTILINE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_MULTILINE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_MULTILINE);
    }

    [Test]
    public async Task SetAriaMultiline() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_MULTILINE);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaMultiline;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_MULTILINE);
    }


    [Test]
    public async Task GetAriaMultiSelectable_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaMultiSelectable = '{HTMLElementGroup.TEST_ARIA_MULTI_SELECTABLE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_MULTI_SELECTABLE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_MULTI_SELECTABLE);
    }

    [Test]
    public async Task GetAriaMultiSelectable_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaMultiSelectable = '{HTMLElementGroup.TEST_ARIA_MULTI_SELECTABLE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_MULTI_SELECTABLE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_MULTI_SELECTABLE);
    }

    [Test]
    public async Task SetAriaMultiSelectable() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_MULTI_SELECTABLE);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaMultiSelectable;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_MULTI_SELECTABLE);
    }


    [Test]
    public async Task GetAriaOrientation_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaOrientation = '{HTMLElementGroup.TEST_ARIA_ORIENTATION}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_ORIENTATION_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ORIENTATION);
    }

    [Test]
    public async Task GetAriaOrientation_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaOrientation = '{HTMLElementGroup.TEST_ARIA_ORIENTATION}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_ORIENTATION_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ORIENTATION);
    }

    [Test]
    public async Task SetAriaOrientation() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_ORIENTATION);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaOrientation;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ORIENTATION);
    }


    [Test]
    public async Task GetAriaPlaceholder_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaPlaceholder = '{HTMLElementGroup.TEST_ARIA_PLACEHOLDER}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_PLACEHOLDER_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_PLACEHOLDER);
    }

    [Test]
    public async Task GetAriaPlaceholder_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaPlaceholder = '{HTMLElementGroup.TEST_ARIA_PLACEHOLDER}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_PLACEHOLDER_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_PLACEHOLDER);
    }

    [Test]
    public async Task SetAriaPlaceholder() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_PLACEHOLDER);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaPlaceholder;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_PLACEHOLDER);
    }


    [Test]
    public async Task GetAriaPosInSet_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaPosInSet = '{HTMLElementGroup.TEST_ARIA_POS_IN_SET}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_POS_IN_SET_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_POS_IN_SET);
    }

    [Test]
    public async Task GetAriaPosInSet_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaPosInSet = '{HTMLElementGroup.TEST_ARIA_POS_IN_SET}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_POS_IN_SET_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_POS_IN_SET);
    }

    [Test]
    public async Task SetAriaPosInSet() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_POS_IN_SET);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaPosInSet;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_POS_IN_SET);
    }


    [Test]
    public async Task GetAriaPressed_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaPressed = '{HTMLElementGroup.TEST_ARIA_PRESSED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_PRESSED_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_PRESSED);
    }

    [Test]
    public async Task GetAriaPressed_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaPressed = '{HTMLElementGroup.TEST_ARIA_PRESSED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_PRESSED_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_PRESSED);
    }

    [Test]
    public async Task SetAriaPressed() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_PRESSED);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaPressed;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_PRESSED);
    }


    [Test]
    public async Task GetAriaReadOnly_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaReadOnly = '{HTMLElementGroup.TEST_ARIA_READ_ONLY}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_READ_ONLY_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_READ_ONLY);
    }

    [Test]
    public async Task GetAriaReadOnly_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaReadOnly = '{HTMLElementGroup.TEST_ARIA_READ_ONLY}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_READ_ONLY_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_READ_ONLY);
    }

    [Test]
    public async Task SetAriaReadOnly() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_READ_ONLY);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaReadOnly;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_READ_ONLY);
    }


    [Test]
    public async Task GetAriaRequired_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRequired = '{HTMLElementGroup.TEST_ARIA_REQUIRED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_REQUIRED_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_REQUIRED);
    }

    [Test]
    public async Task GetAriaRequired_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRequired = '{HTMLElementGroup.TEST_ARIA_REQUIRED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_REQUIRED_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_REQUIRED);
    }

    [Test]
    public async Task SetAriaRequired() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_REQUIRED);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaRequired;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_REQUIRED);
    }


    [Test]
    public async Task GetAriaRoleDescription_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRoleDescription = '{HTMLElementGroup.TEST_ARIA_ROLE_DESCRIPTION}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_ROLE_DESCRIPTION_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROLE_DESCRIPTION);
    }

    [Test]
    public async Task GetAriaRoleDescription_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRoleDescription = '{HTMLElementGroup.TEST_ARIA_ROLE_DESCRIPTION}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_ROLE_DESCRIPTION_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROLE_DESCRIPTION);
    }

    [Test]
    public async Task SetAriaRoleDescription() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_ROLE_DESCRIPTION);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaRoleDescription;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROLE_DESCRIPTION);
    }


    [Test]
    public async Task GetAriaRowCount_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRowCount = '{HTMLElementGroup.TEST_ARIA_ROW_COUNT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_ROW_COUNT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROW_COUNT);
    }

    [Test]
    public async Task GetAriaRowCount_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRowCount = '{HTMLElementGroup.TEST_ARIA_ROW_COUNT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_ROW_COUNT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROW_COUNT);
    }

    [Test]
    public async Task SetAriaRowCount() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_ROW_COUNT);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaRowCount;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROW_COUNT);
    }


    [Test]
    public async Task GetAriaRowIndex_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRowIndex = '{HTMLElementGroup.TEST_ARIA_ROW_INDEX}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_ROW_INDEX_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROW_INDEX);
    }

    [Test]
    public async Task GetAriaRowIndex_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRowIndex = '{HTMLElementGroup.TEST_ARIA_ROW_INDEX}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_ROW_INDEX_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROW_INDEX);
    }

    [Test]
    public async Task SetAriaRowIndex() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_ROW_INDEX);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaRowIndex;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROW_INDEX);
    }


    [Test]
    public async Task GetAriaRowIndexText_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRowIndexText = '{HTMLElementGroup.TEST_ARIA_ROW_INDEX_TEXT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_ROW_INDEX_TEXT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROW_INDEX_TEXT);
    }

    [Test]
    public async Task GetAriaRowIndexText_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRowIndexText = '{HTMLElementGroup.TEST_ARIA_ROW_INDEX_TEXT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_ROW_INDEX_TEXT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROW_INDEX_TEXT);
    }

    [Test]
    public async Task SetAriaRowIndexText() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_ROW_INDEX_TEXT);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaRowIndexText;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROW_INDEX_TEXT);
    }


    [Test]
    public async Task GetAriaRowSpan_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRowSpan = '{HTMLElementGroup.TEST_ARIA_ROW_SPAN}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_ROW_SPAN_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROW_SPAN);
    }

    [Test]
    public async Task GetAriaRowSpan_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaRowSpan = '{HTMLElementGroup.TEST_ARIA_ROW_SPAN}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_ROW_SPAN_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROW_SPAN);
    }

    [Test]
    public async Task SetAriaRowSpan() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_ROW_SPAN);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaRowSpan;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_ROW_SPAN);
    }


    [Test]
    public async Task GetAriaSelected_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaSelected = '{HTMLElementGroup.TEST_ARIA_SELECTED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_SELECTED_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_SELECTED);
    }

    [Test]
    public async Task GetAriaSelected_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaSelected = '{HTMLElementGroup.TEST_ARIA_SELECTED}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_SELECTED_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_SELECTED);
    }

    [Test]
    public async Task SetAriaSelected() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_SELECTED);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaSelected;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_SELECTED);
    }


    [Test]
    public async Task GetAriaSetSize_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaSetSize = '{HTMLElementGroup.TEST_ARIA_SET_SIZE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_SET_SIZE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_SET_SIZE);
    }

    [Test]
    public async Task GetAriaSetSize_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaSetSize = '{HTMLElementGroup.TEST_ARIA_SET_SIZE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_SET_SIZE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_SET_SIZE);
    }

    [Test]
    public async Task SetAriaSetSize() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_SET_SIZE);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaSetSize;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_SET_SIZE);
    }


    [Test]
    public async Task GetAriaSort_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaSort = '{HTMLElementGroup.TEST_ARIA_SORT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_SORT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_SORT);
    }

    [Test]
    public async Task GetAriaSort_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaSort = '{HTMLElementGroup.TEST_ARIA_SORT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_SORT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_SORT);
    }

    [Test]
    public async Task SetAriaSort() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_SORT);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaSort;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_SORT);
    }


    [Test]
    public async Task GetAriaValueMax_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaValueMax = '{HTMLElementGroup.TEST_ARIA_VALUE_MAX}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_VALUE_MAX_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_VALUE_MAX);
    }

    [Test]
    public async Task GetAriaValueMax_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaValueMax = '{HTMLElementGroup.TEST_ARIA_VALUE_MAX}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_VALUE_MAX_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_VALUE_MAX);
    }

    [Test]
    public async Task SetAriaValueMax() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_VALUE_MAX);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaValueMax;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_VALUE_MAX);
    }


    [Test]
    public async Task GetAriaValueMin_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaValueMin = '{HTMLElementGroup.TEST_ARIA_VALUE_MIN}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_VALUE_MIN_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_VALUE_MIN);
    }

    [Test]
    public async Task GetAriaValueMin_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaValueMin = '{HTMLElementGroup.TEST_ARIA_VALUE_MIN}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_VALUE_MIN_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_VALUE_MIN);
    }

    [Test]
    public async Task SetAriaValueMin() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_VALUE_MIN);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaValueMin;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_VALUE_MIN);
    }


    [Test]
    public async Task GetAriaValueNow_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaValueNow = '{HTMLElementGroup.TEST_ARIA_VALUE_NOW}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_VALUE_NOW_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_VALUE_NOW);
    }

    [Test]
    public async Task GetAriaValueNow_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaValueNow = '{HTMLElementGroup.TEST_ARIA_VALUE_NOW}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_VALUE_NOW_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_VALUE_NOW);
    }

    [Test]
    public async Task SetAriaValueNow() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_VALUE_NOW);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaValueNow;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_VALUE_NOW);
    }


    [Test]
    public async Task GetAriaValueText_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaValueText = '{HTMLElementGroup.TEST_ARIA_VALUE_TEXT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_VALUE_TEXT_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_VALUE_TEXT);
    }

    [Test]
    public async Task GetAriaValueText_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.ariaValueText = '{HTMLElementGroup.TEST_ARIA_VALUE_TEXT}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ARIA_VALUE_TEXT_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_VALUE_TEXT);
    }

    [Test]
    public async Task SetAriaValueText() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ARIA_VALUE_TEXT);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.ariaValueText;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ARIA_VALUE_TEXT);
    }


    [Test]
    public async Task GetRole_Property() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.role = '{HTMLElementGroup.TEST_ROLE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ROLE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ROLE);
    }

    [Test]
    public async Task GetRole_Method() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.role = '{HTMLElementGroup.TEST_ROLE}';");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ROLE_METHOD);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ROLE);
    }

    [Test]
    public async Task SetRole() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ROLE);

        string result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string>("node => node.role;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_ROLE);
    }


    // methods

    [Test]
    public async Task CheckVisibility() {
        await ExecuteTest(HTMLElementGroup.BUTTON_CHECK_VISIBILITY);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task ComputedStyleMap() {
        await ExecuteTest(HTMLElementGroup.BUTTON_COMPUTED_STYLE_MAP);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GetBoundingClientRect() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_BOUNDING_CLIENT_RECT);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(nameof(DOMRect));
    }

    [Test]
    public async Task GetClientRects() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_CLIENT_RECTS);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotNullOrEmpty();

        foreach (string item in result!.Split(';'))
            await Assert.That(item).StartsWith(nameof(DOMRect));
    }

    [Test]
    public async Task Matches() {
        await ExecuteTest(HTMLElementGroup.BUTTON_MATCHES);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task RequestFullscreen() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REQUEST_FULLSCREEN);

        bool isFullScreen = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<bool>("node => node === document.fullscreenElement;");
        await Assert.That(isFullScreen).IsTrue();
    }

    [Test]
    public async Task RequestPointerLock() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REQUEST_POINTER_LOCK);

        bool isPointerLocked = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<bool>("node => node === document.pointerLockElement;");
        await Assert.That(isPointerLocked).IsTrue();
    }

    [Test]
    public async Task IsDefaultNamespace() {
        await ExecuteTest(HTMLElementGroup.BUTTON_IS_DEFAULT_NAMESPACE);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task LookupPrefix() {
        await ExecuteTest(HTMLElementGroup.BUTTON_LOOKUP_PREFIX);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(no prefix)");
    }

    [Test]
    public async Task LookupNamespaceURI() {
        await ExecuteTest(HTMLElementGroup.BUTTON_LOOKUP_NAMESPACE_URI);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("http://www.w3.org/1999/xhtml");
    }

    [Test]
    public async Task Normalize() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.append('-textNode1-', '-textNode2-');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_NORMALIZE);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.lastChild.textContent;");
        await Assert.That(result).IsEqualTo("-textNode1--textNode2-");
    }


    // methods - Pointer Capture

    [Test] // tests "SetPointerCapture", "ReleasePointerCapture", "HasPointerCapture"
    public async Task PointerCapture() {
        ILocator htmlElement = Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT);
        ILocator labelOutput = Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT);

        // hasPointerCapture false
        {
            await htmlElement.HoverAsync();
            string? result = await labelOutput.TextContentAsync();
            await Assert.That(result).IsEqualTo("HasPointerCapture=False");
        }

        await Page.Mouse.DownAsync();

        // hasPointerCapture true
        {
            await Page.Mouse.MoveAsync(1, 1);
            string? result = await labelOutput.TextContentAsync();
            await Assert.That(result).IsEqualTo("HasPointerCapture=True");
        }

        await Page.Mouse.UpAsync();

        // hasPointerCapture false
        {
            await htmlElement.HoverAsync();
            string? result = await labelOutput.TextContentAsync();
            await Assert.That(result).IsEqualTo("HasPointerCapture=False");
        }
    }


    // methods - Scroll

    [Test]
    public async Task Scroll() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SCROLL);

        int resultLeft = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollLeft;");
        await Assert.That(resultLeft).IsGreaterThan(0);
        int resultTop = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.scrollTop;");
        await Assert.That(resultTop).IsGreaterThan(0);
    }

    [Test]
    public async Task ScrollTo() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SCROLL_TO);

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


    // methods - Attribute

    [Test]
    public async Task GetAttribute() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ATTRIBUTE);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.HTML_ELEMENT);
    }

    [Test]
    public async Task GetAttributeNS() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ATTRIBUTE_NS);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.HTML_ELEMENT);
    }

    [Test]
    public async Task GetAttributeNames() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ATTRIBUTE_NAMES);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task SetAttribute() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ATTRIBUTE);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync(HTMLElementGroup.TEST_CUSTOM_NAME);
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task SetAttributeNS() {
        await ExecuteTest(HTMLElementGroup.BUTTON_SET_ATTRIBUTE_NS);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync(HTMLElementGroup.TEST_CUSTOM_NAME);
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task ToggleAttribute() {
        {
            await ExecuteTest(HTMLElementGroup.BUTTON_TOGGLE_ATTRIBUTE);

            string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync(HTMLElementGroup.TEST_CUSTOM_NAME);
            await Assert.That(result).IsNotNull();
        }

        {
            await ExecuteTest(HTMLElementGroup.BUTTON_TOGGLE_ATTRIBUTE);

            string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync(HTMLElementGroup.TEST_CUSTOM_NAME);
            await Assert.That(result).IsNull();
        }
    }

    [Test]
    public async Task RemoveAttribute() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('{HTMLElementGroup.TEST_CUSTOM_NAME}', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_REMOVE_ATTRIBUTE);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync(HTMLElementGroup.TEST_CUSTOM_NAME);
        await Assert.That(result).IsNull();
    }

    [Test]
    public async Task RemoveAttributeNS() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.setAttribute('{HTMLElementGroup.TEST_CUSTOM_NAME}', '');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_REMOVE_ATTRIBUTE);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).GetAttributeAsync(HTMLElementGroup.TEST_CUSTOM_NAME);
        await Assert.That(result).IsNull();
    }

    [Test]
    public async Task HasAttribute() {
        await ExecuteTest(HTMLElementGroup.BUTTON_HAS_ATTRIBUTE);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task HasAttributeNS() {
        await ExecuteTest(HTMLElementGroup.BUTTON_HAS_ATTRIBUTE_NS);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task HasAttributes() {
        await ExecuteTest(HTMLElementGroup.BUTTON_HAS_ATTRIBUTES);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // methods - Tree-nodes

    [Test]
    public async Task GetElementsByClassName() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.children[0].setAttribute('class', '{HTMLElementGroup.TEST_CUSTOM_NAME}');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ELEMENTS_BY_CLASS_NAME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetElementsByTagName() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ELEMENTS_BY_TAG_NAME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetElementsByTagNameNS() {
        await ExecuteTest(HTMLElementGroup.BUTTON_GET_ELEMENTS_BY_TAG_NAME_NS);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task QuerySelector() {
        await ExecuteTest(HTMLElementGroup.BUTTON_QUERY_SELECTOR);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task QuerySelectorAll() {
        await ExecuteTest(HTMLElementGroup.BUTTON_QUERY_SELECTOR_ALL);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task Closest() {
        await ExecuteTest(HTMLElementGroup.BUTTON_CLOSEST);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task Before_String() {
        await ExecuteTest(HTMLElementGroup.BUTTON_BEFORE_STRING);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.previousSibling.textContent;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task Before_HtmlElement() {
        await ExecuteTest(HTMLElementGroup.BUTTON_BEFORE_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.previousElementSibling.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.HIDDEN_ELEMENT);
    }

    [Test]
    public async Task After_String() {
        await ExecuteTest(HTMLElementGroup.BUTTON_AFTER_STRING);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.nextSibling.textContent;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task After_HtmlElement() {
        await ExecuteTest(HTMLElementGroup.BUTTON_AFTER_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.nextElementSibling.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.HIDDEN_ELEMENT);
    }


    [Test]
    public async Task Prepend_String() {
        await ExecuteTest(HTMLElementGroup.BUTTON_PREPEND_STRING);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.firstChild.textContent;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task Prepend_HtmlElement() {
        await ExecuteTest(HTMLElementGroup.BUTTON_PREPEND_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.firstChild.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.HIDDEN_ELEMENT);
    }

    [Test]
    public async Task AppendChild() {
        await ExecuteTest(HTMLElementGroup.BUTTON_APPEND_CHILD);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.lastChild.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.HIDDEN_ELEMENT);
    }

    [Test]
    public async Task Append_String() {
        await ExecuteTest(HTMLElementGroup.BUTTON_APPEND_STRING);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.lastChild.textContent;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task Append_HtmlElement() {
        await ExecuteTest(HTMLElementGroup.BUTTON_APPEND_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.lastChild.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.HIDDEN_ELEMENT);
    }

    [Test]
    public async Task InsertAdjacentElement() {
        await ExecuteTest(HTMLElementGroup.BUTTON_INSERT_ADJACENT_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.firstChild.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.HIDDEN_ELEMENT);
    }

    [Test]
    public async Task InsertAdjacentHTML() {
        await ExecuteTest(HTMLElementGroup.BUTTON_INSERT_ADJACENT_HTML);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.firstChild.outerHTML;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_INSERT_HTML);
    }

    [Test]
    public async Task InsertAdjacentText() {
        await ExecuteTest(HTMLElementGroup.BUTTON_INSERT_ADJACENT_TEXT);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.firstChild.textContent;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_CUSTOM_VALUE);
    }


    [Test]
    public async Task RemoveChild() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync($"""node => document.querySelector("[data-testid='{HTMLElementGroup.HTML_ELEMENT}']").appendChild(node);""");
        await Task.Delay(SMALL_WAIT_TIME);
        int childCount = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.children.length;");
        await Assert.That(childCount).IsEqualTo(4);

        await ExecuteTest(HTMLElementGroup.BUTTON_REMOVE_CHILD);

        int result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<int>("node => node.children.length;");
        await Assert.That(result).IsEqualTo(3);
    }

    [Test]
    public async Task Remove() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REMOVE);

        bool result = await Page.EvaluateAsync<bool>($"""document.querySelector("[data-testid='{HTMLElementGroup.HTML_ELEMENT}']") === null;""");
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReplaceChild() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync($"""node => document.querySelector("[data-testid='{HTMLElementGroup.HTML_ELEMENT}']").appendChild(node);""");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_REPLACE_CHILD);

        string? result = await Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT).EvaluateAsync<string?>("node => node.parentElement.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.HTML_ELEMENT);
    }

    [Test]
    public async Task ReplaceChild_Index() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync($"""node => document.querySelector("[data-testid='{HTMLElementGroup.HTML_ELEMENT}']").prepend(node);""");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_REPLACE_CHILD_INDEX);

        string? result = await Page.GetByTestId(HTMLElementGroup.POPOVER_ELEMENT).EvaluateAsync<string?>("node => node.parentElement.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.HTML_ELEMENT);
    }

    [Test]
    public async Task ReplaceWith_String() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REPLACE_WITH_STRING);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync<string?>("node => node.firstChild.textContent;");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task ReplaceWith_HtmlElement() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REPLACE_WITH_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync<string?>("node => node.firstElementChild.getAttribute('data-testid');");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.HIDDEN_ELEMENT);
    }

    [Test]
    public async Task ReplaceChildren_String() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REPLACE_CHILDREN_STRING);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.children.length === 0 ? node.firstChild.textContent : 'child-count is not 0';");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_CUSTOM_VALUE);
    }

    [Test]
    public async Task ReplaceChildren_HtmlElement() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REPLACE_CHILDREN_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync<string?>("node => node.children.length === 1 ? node.firstElementChild.getAttribute('data-testid') : 'child-count is not 1';");
        await Assert.That(result).IsEqualTo(HTMLElementGroup.HIDDEN_ELEMENT);
    }


    [Test]
    public async Task CloneNode() {
        await ExecuteTest(HTMLElementGroup.BUTTON_CLONE_NODE);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task IsSameNode() {
        await ExecuteTest(HTMLElementGroup.BUTTON_IS_SAME_NODE);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task IsEqualNode() {
        await ExecuteTest(HTMLElementGroup.BUTTON_IS_EQUAL_NODE);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task Contains() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync($"""node => document.querySelector("[data-testid='{HTMLElementGroup.HTML_ELEMENT}']").appendChild(node);""");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_CONTAINS);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task CompareDocumentPosition() {
        await ExecuteTest(HTMLElementGroup.BUTTON_COMPARE_DOCUMENT_POSITION);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out _);
        await Assert.That(isInteger).IsTrue();
    }


    // events

    [Test]
    public async Task RegisterOnInput() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync("""
            node => {
                const tempElement = document.createElement("input");
                tempElement.setAttribute("data-testid", "temp");
                node.appendChild(tempElement);
            }
            """);
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_INPUT);

        await Page.GetByTestId("temp").FillAsync("something");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("data=something, inputType=insertText, isComposing=False");
    }

    [Test]
    public async Task RegisterOnBeforeInput() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync("""
            node => {
                const tempElement = document.createElement("input");
                tempElement.setAttribute("data-testid", "temp");
                node.appendChild(tempElement);
            }
            """);
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_BEFORE_INPUT);

        await Page.GetByTestId("temp").FillAsync("something");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("data=something, inputType=insertText, isComposing=False");
    }

    [Test]
    public async Task RegisterOnContentVisibilityAutoStateChange() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_CONTENT_VISIBILITY_AUTO_STATE_CHANGE);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.contentVisibility = 'auto';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("skipped=False");
    }

    [Test]
    public async Task RegisterOnBeforeMatch() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_BEFORE_MATCH);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync("""
            node => {
                const htmlElement = node.firstElementChild;
                htmlElement.setAttribute("id", "htmlelement-fragment");
                htmlElement.setAttribute("hidden", "until-found");

                const a = document.createElement("a");
                a.href = "#htmlelement-fragment";
                node.appendChild(a);
                a.click();
            }
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_EVENT_BEFORE_MATCH);
    }

    [Test]
    public async Task RegisterOnSecurityPolicyViolation() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_SECURITY_POLICY_VIOLATION);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("""
            node => {
                //const script = document.createElement("script");
                //script.innerText = "console.log('inline script');";
                //node.appendChild(script);

                const event = new Event("securitypolicyviolation");
                event.blockedURI = "s1";
                event.effectiveDirective = "s2";
                event.documentURI = "s3";
                event.lineNumber = 4;
                event.columnNumber = 5;
                event.originalPolicy = "s6";
                event.referrer = "s7";
                event.sourceFile = "s8";
                event.sample = "s9";
                event.statusCode = 10;
                event.disposition = "s11";
                node.dispatchEvent(event);
            }
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("SecurityPolicyViolationEvent { BlockedURI = s1, EffectiveDirective = s2, DocumentURI = s3, LineNumber = 4, ColumnNumber = 5, OriginalPolicy = s6, Referrer = s7, SourceFile = s8, Sample = s9, StatusCode = 10, Disposition = s11 }");
    }

    [Test]
    public async Task RegisterOnSelectStart() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_SELECT_START);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_EVENT_SELECT_START);
    }


    [Test]
    public async Task RegisterOnKeyDown() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync("""
            node => {
                const tempElement = document.createElement("input");
                tempElement.setAttribute("data-testid", "temp");
                node.appendChild(tempElement);
            }
            """);
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_KEY_DOWN);

        await Page.GetByTestId("temp").PressAsync("a");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("KeyboardEvent { Key = a, Code = KeyA, Location = 0, CtrlKey = False, ShiftKey = False, AltKey = False, MetaKey = False, Repeat = False, IsComposing = False }");
    }

    [Test]
    public async Task RegisterOnKeyUp() {
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT_CONTAINER).EvaluateAsync("""
            node => {
                const tempElement = document.createElement("input");
                tempElement.setAttribute("data-testid", "temp");
                node.appendChild(tempElement);
            }
            """);
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_KEY_UP);

        await Page.GetByTestId("temp").PressAsync("a");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("KeyboardEvent { Key = a, Code = KeyA, Location = 0, CtrlKey = False, ShiftKey = False, AltKey = False, MetaKey = False, Repeat = False, IsComposing = False }");
    }


    [Test]
    public async Task RegisterOnClick() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_CLICK);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnDblClick() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_DBL_CLICK);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).DblClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnAuxClick() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_AUX_CLICK);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).ClickAsync(new LocatorClickOptions() { Button = MouseButton.Right });
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnContextMenu() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_CONTEXT_MENU);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).ClickAsync(new LocatorClickOptions() { Button = MouseButton.Right });
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseDown() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_MOUSE_DOWN);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseUp() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_MOUSE_UP);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnWheel() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_WHEEL);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).HoverAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Mouse.WheelAsync(0.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("WheelEvent { DeltaX = 0, DeltaY = 1, DeltaZ = 0, DeltaMode = 0 }");
    }

    [Test]
    public async Task RegisterOnMouseMove() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_MOUSE_MOVE);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).HoverAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseOver() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_MOUSE_OVER);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).HoverAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseOut() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_MOUSE_OUT);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).HoverAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).HoverAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseEnter() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_MOUSE_ENTER);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).HoverAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseLeave() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_MOUSE_LEAVE);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).HoverAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).HoverAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }


    [Test]
    public async Task RegisterOnTouchStart() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_TOUCH_START);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).TapAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("TouchEvent");
    }

    [Test]
    public async Task RegisterOnTouchEnd() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_TOUCH_END);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).TapAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("TouchEvent");
    }

    [Test]
    public async Task RegisterOnTouchMove() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_TOUCH_MOVE);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                const event = new Event("touchmove");
                event.touches = [];
                event.targetTouches = [];
                event.changedTouches = [];
                event.ctrlKey = false;
                event.shiftKey = false;
                event.altKey = false;
                event.metaKey = false;
                node.dispatchEvent(event);
            };
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("TouchEvent");
    }

    [Test]
    public async Task RegisterOnTouchCancel() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_TOUCH_CANCEL);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                const event = new Event("touchcancel");
                event.touches = [];
                event.targetTouches = [];
                event.changedTouches = [];
                event.ctrlKey = false;
                event.shiftKey = false;
                event.altKey = false;
                event.metaKey = false;
                node.dispatchEvent(event);
            };
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("TouchEvent");
    }


    [Test]
    public async Task RegisterOnPointerDown() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_POINTER_DOWN);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerUp() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_POINTER_UP);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerMove() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_POINTER_MOVE);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).HoverAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerOver() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_POINTER_OVER);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).HoverAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerOut() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_POINTER_OUT);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).HoverAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).HoverAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerEnter() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_POINTER_ENTER);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).HoverAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerLeave() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_POINTER_LEAVE);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).HoverAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).HoverAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerCancel() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_POINTER_CANCEL);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                const event = new Event("pointercancel");
                event.pointerId = 0;
                event.persistentDeviceId = 0;
                event.pointerType = "";
                event.width = 1;
                event.height = 1;
                event.pressure = 1;
                event.tangentialPressure = 0;
                event.twist = 0;
                event.tiltX = 0;
                event.tiltY = 0;
                event.altitudeAngle = 0;
                event.azimuthAngle = 0;
                event.isPrimary = true;
                event.button = 0;
                event.buttons = 0;
                event.movementX = 0;
                event.movementY = 0;
                event.clientX = 0;
                event.clientY = 0;
                event.offsetX = 0;
                event.offsetY = 0;
                event.pageX = 0;
                event.pageY = 0;
                event.screenX = 0;
                event.screenY = 0;
                event.ctrlKey = false;
                event.shiftKey = false;
                event.altKey = false;
                event.metaKey = false;
                node.dispatchEvent(event);
            };
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerRawUpdate() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("node => node.removeAttribute('hidden')");
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_POINTER_RAW_UPDATE);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).HoverAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnGotPointerCapture() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.addEventListener("pointerdown", event => node.setPointerCapture(event.pointerId));
            }
            """);
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_GOT_POINTER_CAPTURE);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnLostPointerCapture() {
        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).EvaluateAsync("""
            node => {
                node.removeAttribute("hidden");
                node.addEventListener("pointerdown", event => node.setPointerCapture(event.pointerId));
                node.addEventListener("pointerup", event => node.releasePointerCapture(event.pointerId));
            }
            """);
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_LOST_POINTER_CAPTURE);

        await Page.GetByTestId(HTMLElementGroup.HIDDEN_ELEMENT).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }


    [Test]
    public async Task RegisterOnScroll() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_SCROLL);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).HoverAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Mouse.WheelAsync(0.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_EVENT_SCROLL_START);
    }

    [Test]
    public async Task RegisterOnScrollEnd() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_SCROLL_END);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).HoverAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Mouse.WheelAsync(0.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_EVENT_SCROLL_END);
    }


    [Test]
    public async Task RegisterOnFocus() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_FOCUS);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).FocusAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_EVENT_FOCUS);
    }

    [Test]
    public async Task RegisterOnFocusIn() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_FOCUS_IN);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).FocusAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_EVENT_FOCUS_IN);
    }

    [Test]
    public async Task RegisterOnBlur() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_BLUR);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).FocusAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).BlurAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_EVENT_BLUR);
    }

    [Test]
    public async Task RegisterOnFocusOut() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_FOCUS_OUT);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).FocusAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).BlurAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_EVENT_FOCUS_OUT);
    }


    [Test]
    public async Task RegisterOnCopy() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_COPY);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).FocusAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Keyboard.PressAsync("Control+c");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_EVENT_COPY);
    }

    [Test]
    public async Task RegisterOnPaste() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_PASTE);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).FocusAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Keyboard.PressAsync("Control+v");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_EVENT_PASTE);
    }

    [Test]
    public async Task RegisterOnCut() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_CUT);

        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).FocusAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Keyboard.PressAsync("Control+x");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLElementGroup.TEST_EVENT_CUT);
    }


    [Test]
    public async Task RegisterOnTransitionStart() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITION_START);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_EVENT_TRANSITION_START);
    }

    [Test]
    public async Task RegisterOnTransitionEnd() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITION_END);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_EVENT_TRANSITION_END);
    }

    [Test]
    public async Task RegisterOnTransitionRun() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITION_RUN);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_EVENT_TRANSITION_RUN);
    }

    [Test]
    public async Task RegisterOnTransitionCancel() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_TRANSITION_CANCEL);

        await Page.EvaluateAsync("""
            for (const htmlElement of document.getElementsByClassName("html-element"))
                htmlElement.classList.add("long-transition");
            """);
        await Task.Delay(SMALL_WAIT_TIME);

        // fluctuating test -> do multiple times with different timings
        string? result = null;
        for (int i = 0; i < 60; i++) {
            char colorNumber = (i % 10).ToString()[0];
            await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync($"node => node.style.backgroundColor = '#{colorNumber}{colorNumber}{colorNumber}';");
            await Task.Delay(i * SMALL_WAIT_TIME);

            result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
            if (result is not (null or ""))
                break;
        }

        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_EVENT_TRANSITION_CANCEL);
    }


    [Test]
    public async Task RegisterOnAnimationStart() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATION_START);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_EVENT_ANIMATION_START);
    }

    [Test]
    public async Task RegisterOnAnimationnEnd() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATION_END);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_EVENT_ANIMATION_END);
    }

    [Test]
    public async Task RegisterOnAnimationIteration() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATION_ITERATION);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start-infinite');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_EVENT_ANIMATION_ITERATION);
    }

    [Test]
    public async Task RegisterOnAnimationCancel() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_ANIMATION_CANCEL);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.add('animation-start-infinite');");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.classList.remove('animation-start-infinite');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_EVENT_ANIMATION_CANCEL);
    }


    [Test]
    public async Task RegisterOnFullscreenChange() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_FULLSCREEN_CHANGE);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.requestFullscreen();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_EVENT_FULLSCREEN_CHANGE);
    }

    [Test]
    public async Task RegisterOnFullscreenError() {
        await ExecuteTest(HTMLElementGroup.BUTTON_REGISTER_ON_FULLSCREEN_ERROR);
        await Page.GetByTestId(HTMLElementGroup.HTML_ELEMENT).EvaluateAsync("node => node.dispatchEvent(new Event('fullscreenerror'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(HTMLElementGroup.TEST_EVENT_FULLSCREEN_ERROR);
    }

    #endregion
}
