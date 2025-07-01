using BrowserAPI.Test.Client;
using Microsoft.Playwright;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class DialogInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task GetOpen() {
        await Page.GetByTestId(DialogInProcessGroup.BUTTON_GET_OPEN).ClickAsync();

        string? result = await Page.GetByTestId(DialogInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetOpen() {
        await Page.GetByTestId(DialogInProcessGroup.BUTTON_SET_OPEN).ClickAsync();

        string? open = await Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsEqualTo(string.Empty);
    }


    [Test]
    public async Task GetReturnValue() {
        const string RESULT = "return value result";
        ILocator dialog = Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync($"dialog => dialog.returnValue = '{RESULT}';");

        await Page.GetByTestId(DialogInProcessGroup.BUTTON_GET_RETURN_VALUE).ClickAsync();

        string? result = await Page.GetByTestId(DialogInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(RESULT);
    }

    [Test]
    public async Task SetReturnValue() {
        await Page.GetByTestId(DialogInProcessGroup.BUTTON_SET_RETURN_VALUE).ClickAsync();

        ILocator dialog = Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT);
        string result = await dialog.EvaluateAsync<string>("dialog => dialog.returnValue;");
        await Assert.That(result).IsEqualTo(DialogInProcessGroup.TEST_RETURN_VALUE);
    }


    [Test]
    public async Task Show() {
        await Page.GetByTestId(DialogInProcessGroup.BUTTON_SHOW).ClickAsync();

        string? open = await Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task ShowModal() {
        await Page.GetByTestId(DialogInProcessGroup.BUTTON_SHOW_MODAL).ClickAsync();

        string? open = await Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task Close() {
        ILocator dialog = Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.show();");

        await Page.GetByTestId(DialogInProcessGroup.BUTTON_CLOSE).ClickAsync();

        string? open = await Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsNull();
    }

    [Test]
    public async Task CloseReturnValue() {
        ILocator dialog = Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.show();");

        await Page.GetByTestId(DialogInProcessGroup.BUTTON_CLOSE_RETURN_VALUE).ClickAsync();

        string? open = await Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        string result = await dialog.EvaluateAsync<string>("dialog => dialog.returnValue;");
        await Assert.That(open).IsNull();
        await Assert.That(result).IsEqualTo(DialogInProcessGroup.TEST_RETURN_VALUE);
    }


    [Test]
    public async Task RegisterOnCancel() {
        await Page.GetByTestId(DialogInProcessGroup.BUTTON_REGISTER_ON_CANCEL).ClickAsync();
        ILocator dialog = Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.showModal();");
        await dialog.PressAsync("Escape");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(DialogInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DialogInProcessGroup.TEST_CANCEL_EVENT);
    }

    [Test]
    public async Task RegisterOnClose() {
        await Page.GetByTestId(DialogInProcessGroup.BUTTON_REGISTER_ON_CLOSE).ClickAsync();
        ILocator dialog = Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.show();");
        await dialog.EvaluateAsync("dialog => dialog.close();");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(DialogInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DialogInProcessGroup.TEST_CLOSE_EVENT);
    }
}
