using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class HTMLDialogElementInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task ToHTMLElement() {
        await ExecuteTest(HTMLDialogElementInProcessGroup.BUTTON_TO_HTML_ELEMENT);

        string? result = await Page.GetByTestId(HTMLDialogElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetClosedBy() {
        await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).EvaluateAsync($"dialog => dialog.closedBy = '{HTMLDialogElementInProcessGroup.TEST_CLOSED_BY}';");

        await ExecuteTest(HTMLDialogElementInProcessGroup.BUTTON_GET_CLOSED_BY);

        string? result = await Page.GetByTestId(HTMLDialogElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLDialogElementInProcessGroup.TEST_CLOSED_BY);
    }

    [Test]
    public async Task SetClosedBy() {
        await ExecuteTest(HTMLDialogElementInProcessGroup.BUTTON_SET_RETURN_VALUE);

        string result = await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).EvaluateAsync<string>("dialog => dialog.returnValue;");
        await Assert.That(result).IsEqualTo(HTMLDialogElementInProcessGroup.TEST_RETURN_VALUE);
    }


    [Test]
    public async Task GetOpen() {
        await ExecuteTest(HTMLDialogElementInProcessGroup.BUTTON_GET_OPEN);

        string? result = await Page.GetByTestId(HTMLDialogElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetOpen() {
        await ExecuteTest(HTMLDialogElementInProcessGroup.BUTTON_SET_OPEN);

        string? open = await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsEqualTo(string.Empty);
    }


    [Test]
    public async Task GetReturnValue() {
        await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).EvaluateAsync($"dialog => dialog.returnValue = '{HTMLDialogElementInProcessGroup.TEST_RETURN_VALUE}';");

        await ExecuteTest(HTMLDialogElementInProcessGroup.BUTTON_GET_RETURN_VALUE);

        string? result = await Page.GetByTestId(HTMLDialogElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLDialogElementInProcessGroup.TEST_RETURN_VALUE);
    }

    [Test]
    public async Task SetReturnValue() {
        await ExecuteTest(HTMLDialogElementInProcessGroup.BUTTON_SET_RETURN_VALUE);

        string result = await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).EvaluateAsync<string>("dialog => dialog.returnValue;");
        await Assert.That(result).IsEqualTo(HTMLDialogElementInProcessGroup.TEST_RETURN_VALUE);
    }


    [Test]
    public async Task Show() {
        await ExecuteTest(HTMLDialogElementInProcessGroup.BUTTON_SHOW);

        string? open = await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task ShowModal() {
        await ExecuteTest(HTMLDialogElementInProcessGroup.BUTTON_SHOW_MODAL);

        string? open = await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task Close() {
        await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).EvaluateAsync("dialog => dialog.show();");

        await ExecuteTest(HTMLDialogElementInProcessGroup.BUTTON_CLOSE);

        string? open = await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsNull();
    }

    [Test]
    public async Task CloseReturnValue() {
        await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).EvaluateAsync("dialog => dialog.show();");

        await ExecuteTest(HTMLDialogElementInProcessGroup.BUTTON_CLOSE_RETURN_VALUE);

        string? open = await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsNull();
        string result = await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).EvaluateAsync<string>("dialog => dialog.returnValue;");
        await Assert.That(result).IsEqualTo(HTMLDialogElementInProcessGroup.TEST_RETURN_VALUE);
    }

    [Test]
    public async Task RequestClose() {
        await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).EvaluateAsync("dialog => dialog.show();");

        await ExecuteTest(HTMLDialogElementInProcessGroup.BUTTON_REQUEST_CLOSE);

        string? open = await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsNull();
    }


    [Test]
    public async Task RegisterOnClose() {
        await ExecuteTest(HTMLDialogElementInProcessGroup.BUTTON_REGISTER_ON_CLOSE);

        await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).EvaluateAsync("dialog => dialog.show();");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).EvaluateAsync("dialog => dialog.close();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLDialogElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLDialogElementInProcessGroup.TEST_EVENT_CLOSE);
    }

    [Test]
    public async Task RegisterOnCancel() {
        await ExecuteTest(HTMLDialogElementInProcessGroup.BUTTON_REGISTER_ON_CANCEL);

        await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).EvaluateAsync("dialog => dialog.showModal();");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(HTMLDialogElementInProcessGroup.DIALOG_ELEMENT).PressAsync("Escape");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLDialogElementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLDialogElementInProcessGroup.TEST_EVENT_CANCEL);
    }
}
