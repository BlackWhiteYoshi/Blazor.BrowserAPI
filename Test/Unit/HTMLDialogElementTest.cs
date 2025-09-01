using BrowserAPI.Test.Client;
using Microsoft.Playwright;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class HTMLDialogElementTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
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
        const string RESULT = "return value result";
        ILocator dialog = Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync($"dialog => dialog.returnValue = '{RESULT}';");

        await ExecuteTest(HTMLDialogElementGroup.BUTTON_GET_RETURN_VALUE_PROPERTY);

        string? result = await Page.GetByTestId(HTMLDialogElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(RESULT);
    }

    [Test]
    public async Task GetReturnValue_Method() {
        const string RESULT = "return value result";
        ILocator dialog = Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync($"dialog => dialog.returnValue = '{RESULT}';");

        await ExecuteTest(HTMLDialogElementGroup.BUTTON_GET_RETURN_VALUE_METHOD);

        string? result = await Page.GetByTestId(HTMLDialogElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(RESULT);
    }

    [Test]
    public async Task SetReturnValue() {
        await ExecuteTest(HTMLDialogElementGroup.BUTTON_SET_RETURN_VALUE);

        ILocator dialog = Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT);
        string result = await dialog.EvaluateAsync<string>("dialog => dialog.returnValue;");
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
        ILocator dialog = Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.show();");

        await ExecuteTest(HTMLDialogElementGroup.BUTTON_CLOSE);

        string? open = await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsNull();
    }

    [Test]
    public async Task CloseReturnValue() {
        ILocator dialog = Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.show();");

        await ExecuteTest(HTMLDialogElementGroup.BUTTON_CLOSE_RETURN_VALUE);

        string? open = await Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsNull();
        string result = await dialog.EvaluateAsync<string>("dialog => dialog.returnValue;");
        await Assert.That(result).IsEqualTo(HTMLDialogElementGroup.TEST_RETURN_VALUE);
    }


    [Test]
    public async Task RegisterOnClose() {
        await ExecuteTest(HTMLDialogElementGroup.BUTTON_REGISTER_ON_CLOSE);
        ILocator dialog = Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.show();");
        await dialog.EvaluateAsync("dialog => dialog.close();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLDialogElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLDialogElementGroup.TEST_CLOSE_EVENT);
    }

    [Test]
    public async Task RegisterOnCancel() {
        await ExecuteTest(HTMLDialogElementGroup.BUTTON_REGISTER_ON_CANCEL);
        ILocator dialog = Page.GetByTestId(HTMLDialogElementGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.showModal();");
        await dialog.PressAsync("Escape");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HTMLDialogElementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HTMLDialogElementGroup.TEST_CANCEL_EVENT);
    }
}
