using BrowserAPI.Test.Client;
using Microsoft.Playwright;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class DialogTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task GetOpen_Property() {
        await Page.GetByTestId(DialogGroup.BUTTON_GET_OPEN_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(DialogGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetOpen_Method() {
        await Page.GetByTestId(DialogGroup.BUTTON_GET_OPEN_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(DialogGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task SetOpen() {
        await Page.GetByTestId(DialogGroup.BUTTON_SET_OPEN).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsEqualTo(string.Empty);
    }


    [Test]
    public async Task GetReturnValue_Property() {
        const string RESULT = "return value result";
        ILocator dialog = Page.GetByTestId(DialogGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync($"dialog => dialog.returnValue = '{RESULT}';");

        await Page.GetByTestId(DialogGroup.BUTTON_GET_RETURN_VALUE_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(DialogGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(RESULT);
    }

    [Test]
    public async Task GetReturnValue_Method() {
        const string RESULT = "return value result";
        ILocator dialog = Page.GetByTestId(DialogGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync($"dialog => dialog.returnValue = '{RESULT}';");

        await Page.GetByTestId(DialogGroup.BUTTON_GET_RETURN_VALUE_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(DialogGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(RESULT);
    }

    [Test]
    public async Task SetReturnValue() {
        await Page.GetByTestId(DialogGroup.BUTTON_SET_RETURN_VALUE).ClickAsync();

        ILocator dialog = Page.GetByTestId(DialogGroup.DIALOG_ELEMENT);
        string result = await dialog.EvaluateAsync<string>("dialog => dialog.returnValue;");
        await Assert.That(result).IsEqualTo(DialogGroup.TEST_RETURN_VALUE);
    }


    [Test]
    public async Task Show() {
        await Page.GetByTestId(DialogGroup.BUTTON_SHOW).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task ShowModal() {
        await Page.GetByTestId(DialogGroup.BUTTON_SHOW_MODAL).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task Close() {
        ILocator dialog = Page.GetByTestId(DialogGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.show();");

        await Page.GetByTestId(DialogGroup.BUTTON_CLOSE).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        await Assert.That(open).IsNull();
    }

    [Test]
    public async Task CloseReturnValue() {
        ILocator dialog = Page.GetByTestId(DialogGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.show();");

        await Page.GetByTestId(DialogGroup.BUTTON_CLOSE_RETURN_VALUE).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        string result = await dialog.EvaluateAsync<string>("dialog => dialog.returnValue;");
        await Assert.That(open).IsNull();
        await Assert.That(result).IsEqualTo(DialogGroup.TEST_RETURN_VALUE);
    }


    [Test]
    public async Task RegisterOnCancel() {
        await Page.GetByTestId(DialogGroup.BUTTON_REGISTER_ON_CANCEL).ClickAsync();
        ILocator dialog = Page.GetByTestId(DialogGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.showModal();");
        await dialog.PressAsync("Escape");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(DialogGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DialogGroup.TEST_CANCEL_EVENT);
    }

    [Test]
    public async Task RegisterOnClose() {
        await Page.GetByTestId(DialogGroup.BUTTON_REGISTER_ON_CLOSE).ClickAsync();
        ILocator dialog = Page.GetByTestId(DialogGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.show();");
        await dialog.EvaluateAsync("dialog => dialog.close();");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(DialogGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DialogGroup.TEST_CLOSE_EVENT);
    }
}
