using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class DialogInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Fact]
    public async Task GetOpen() {
        await Page.GetByTestId(DialogInProcessGroup.BUTTON_GET_OPEN).ClickAsync();

        string? result = await Page.GetByTestId(DialogInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetOpen() {
        await Page.GetByTestId(DialogInProcessGroup.BUTTON_SET_OPEN).ClickAsync();

        string? open = await Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        Assert.Equal(string.Empty, open);
    }


    [Fact]
    public async Task GetReturnValue() {
        const string RESULT = "return value result";
        ILocator dialog = Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync($"dialog => dialog.returnValue = '{RESULT}';");

        await Page.GetByTestId(DialogInProcessGroup.BUTTON_GET_RETURN_VALUE).ClickAsync();

        string? result = await Page.GetByTestId(DialogInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(RESULT, result);
    }

    [Fact]
    public async Task SetReturnValue() {
        await Page.GetByTestId(DialogInProcessGroup.BUTTON_SET_RETURN_VALUE).ClickAsync();

        ILocator dialog = Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT);
        string result = await dialog.EvaluateAsync<string>("dialog => dialog.returnValue;");
        Assert.Equal(DialogInProcessGroup.TEST_RETURN_VALUE, result);
    }


    [Fact]
    public async Task Show() {
        await Page.GetByTestId(DialogInProcessGroup.BUTTON_SHOW).ClickAsync();

        string? open = await Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        Assert.Equal(string.Empty, open);
    }

    [Fact]
    public async Task ShowModal() {
        await Page.GetByTestId(DialogInProcessGroup.BUTTON_SHOW_MODAL).ClickAsync();

        string? open = await Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        Assert.Equal(string.Empty, open);
    }

    [Fact]
    public async Task Close() {
        ILocator dialog = Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.show();");

        await Page.GetByTestId(DialogInProcessGroup.BUTTON_CLOSE).ClickAsync();

        string? open = await Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        Assert.Null(open);
    }

    [Fact]
    public async Task CloseReturnValue() {
        ILocator dialog = Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.show();");

        await Page.GetByTestId(DialogInProcessGroup.BUTTON_CLOSE_RETURN_VALUE).ClickAsync();

        string? open = await Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        string result = await dialog.EvaluateAsync<string>("dialog => dialog.returnValue;");
        Assert.Null(open);
        Assert.Equal(DialogInProcessGroup.TEST_RETURN_VALUE, result);
    }


    [Fact]
    public async Task RegisterOnCancel() {
        await Page.GetByTestId(DialogInProcessGroup.BUTTON_REGISTER_ON_CANCEL).ClickAsync();
        ILocator dialog = Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.showModal();");
        await dialog.PressAsync("Escape");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(DialogInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(DialogInProcessGroup.TEST_CANCEL_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnClose() {
        await Page.GetByTestId(DialogInProcessGroup.BUTTON_REGISTER_ON_CLOSE).ClickAsync();
        ILocator dialog = Page.GetByTestId(DialogInProcessGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.show();");
        await dialog.EvaluateAsync("dialog => dialog.close();");
        await Task.Delay(100);

        string? result = await Page.GetByTestId(DialogInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(DialogInProcessGroup.TEST_CLOSE_EVENT, result);
    }
}
