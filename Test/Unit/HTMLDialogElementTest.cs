using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class HTMLDialogElementTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task ToHTMLElement() {
        await ExecuteTest(HTMLDialogElementGroup.BUTTON_TO_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLDialogElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetClosedBy_Property() {
        await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).EvaluateAsync($"dialog => dialog.closedBy = '{HTMLDialogElementGroup.TEST_CLOSED_BY}';");

        await ExecuteTest(HTMLDialogElementGroup.BUTTON_GET_CLOSED_BY_PROPERTY);

        string? result = await Page.GetByTestId(HTMLDialogElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLDialogElementGroup.TEST_CLOSED_BY);
    }

    [Test]
    public async Task GetClosedBy_Method() {
        await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).EvaluateAsync($"dialog => dialog.closedBy = '{HTMLDialogElementGroup.TEST_CLOSED_BY}';");

        await ExecuteTest(HTMLDialogElementGroup.BUTTON_GET_CLOSED_BY_METHOD);

        string? result = await Page.GetByTestId(HTMLDialogElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLDialogElementGroup.TEST_CLOSED_BY);
    }

    [Test]
    public async Task SetClosedBy() {
        await ExecuteTest(HTMLDialogElementGroup.BUTTON_SET_RETURN_VALUE);

        string result = await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).EvaluateAsync<string>("dialog => dialog.returnValue;");
        await Assert.That(result).IsEqualTo(HTMLDialogElementGroup.TEST_RETURN_VALUE);
    }


    [Test]
    public async Task GetOpen_Property() {
        await ExecuteTest(HTMLDialogElementGroup.BUTTON_GET_OPEN_PROPERTY);

        string? result = await Page.GetByTestId(HTMLDialogElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetOpen_Method() {
        await ExecuteTest(HTMLDialogElementGroup.BUTTON_GET_OPEN_METHOD);

        string? result = await Page.GetByTestId(HTMLDialogElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetOpen() {
        await ExecuteTest(HTMLDialogElementGroup.BUTTON_SET_OPEN);

        string? open = await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsEqualTo(string.Empty);
    }


    [Test]
    public async Task GetReturnValue_Property() {
        await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).EvaluateAsync($"dialog => dialog.returnValue = '{HTMLDialogElementGroup.TEST_RETURN_VALUE}';");

        await ExecuteTest(HTMLDialogElementGroup.BUTTON_GET_RETURN_VALUE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLDialogElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLDialogElementGroup.TEST_RETURN_VALUE);
    }

    [Test]
    public async Task GetReturnValue_Method() {
        await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).EvaluateAsync($"dialog => dialog.returnValue = '{HTMLDialogElementGroup.TEST_RETURN_VALUE}';");

        await ExecuteTest(HTMLDialogElementGroup.BUTTON_GET_RETURN_VALUE_METHOD);

        string? result = await Page.GetByTestId(HTMLDialogElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLDialogElementGroup.TEST_RETURN_VALUE);
    }

    [Test]
    public async Task SetReturnValue() {
        await ExecuteTest(HTMLDialogElementGroup.BUTTON_SET_RETURN_VALUE);

        string result = await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).EvaluateAsync<string>("dialog => dialog.returnValue;");
        await Assert.That(result).IsEqualTo(HTMLDialogElementGroup.TEST_RETURN_VALUE);
    }


    [Test]
    public async Task Show() {
        await ExecuteTest(HTMLDialogElementGroup.BUTTON_SHOW);

        string? open = await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task ShowModal() {
        await ExecuteTest(HTMLDialogElementGroup.BUTTON_SHOW_MODAL);

        string? open = await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task Close() {
        await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).EvaluateAsync("dialog => dialog.show();");

        await ExecuteTest(HTMLDialogElementGroup.BUTTON_CLOSE);

        string? open = await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsNull();
    }

    [Test]
    public async Task CloseReturnValue() {
        await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).EvaluateAsync("dialog => dialog.show();");

        await ExecuteTest(HTMLDialogElementGroup.BUTTON_CLOSE_RETURN_VALUE);

        string? open = await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsNull();
        string result = await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).EvaluateAsync<string>("dialog => dialog.returnValue;");
        await Assert.That(result).IsEqualTo(HTMLDialogElementGroup.TEST_RETURN_VALUE);
    }

    [Test]
    public async Task RequestClose() {
        await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).EvaluateAsync("dialog => dialog.show();");

        await ExecuteTest(HTMLDialogElementGroup.BUTTON_REQUEST_CLOSE);

        string? open = await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsNull();
    }


    [Test]
    public async Task RegisterOnClose() {
        await ExecuteTest(HTMLDialogElementGroup.BUTTON_REGISTER_ON_CLOSE);

        await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).EvaluateAsync("dialog => dialog.show();");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).EvaluateAsync("dialog => dialog.close();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLDialogElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLDialogElementGroup.TEST_EVENT_CLOSE);
    }

    [Test]
    public async Task RegisterOnCancel() {
        await ExecuteTest(HTMLDialogElementGroup.BUTTON_REGISTER_ON_CANCEL);

        await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).EvaluateAsync("dialog => dialog.showModal();");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).PressAsync("Escape");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLDialogElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLDialogElementGroup.TEST_EVENT_CANCEL);
    }
}
