using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using Xunit;

namespace BrowserAPI.UnitTest;

public sealed class DialogInProcessTest : PlayWrightTest {
    public DialogInProcessTest(PlayWrightFixture playWrightFixture) : base(playWrightFixture) { }


    [Fact]
    public async Task GetOpen_InProcess() {
        await Page.GetByTestId(DialogGroup.BUTTON_GET_OPEN_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(DialogGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetOpen_InProcess() {
        await Page.GetByTestId(DialogGroup.BUTTON_SET_OPEN_INPROCESS).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        Assert.Equal(string.Empty, open);
    }


    [Fact]
    public async Task GetReturnValue_InProcess() {
        const string RESULT = "return value result";
        ILocator dialog = Page.GetByTestId(DialogGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync($"dialog => dialog.returnValue = '{RESULT}';");

        await Page.GetByTestId(DialogGroup.BUTTON_GET_RETURN_VALUE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(DialogGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(RESULT, result);
    }

    [Fact]
    public async Task SetReturnValue_InProcess() {
        await Page.GetByTestId(DialogGroup.BUTTON_SET_RETURN_VALUE_INPROCESS).ClickAsync();

        ILocator dialog = Page.GetByTestId(DialogGroup.DIALOG_ELEMENT);
        string result = await dialog.EvaluateAsync<string>("dialog => dialog.returnValue;");
        Assert.Equal(DialogGroup.TEST_RETURN_VALUE, result);
    }


    [Fact]
    public async Task Show_InProcess() {
        await Page.GetByTestId(DialogGroup.BUTTON_SHOW_INPROCESS).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        Assert.Equal(string.Empty, open);
    }

    [Fact]
    public async Task ShowModal_InProcess() {
        await Page.GetByTestId(DialogGroup.BUTTON_SHOW_MODAL_INPROCESS).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        Assert.Equal(string.Empty, open);
    }

    [Fact]
    public async Task Close_InProcess() {
        ILocator dialog = Page.GetByTestId(DialogGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.show();");

        await Page.GetByTestId(DialogGroup.BUTTON_CLOSE_INPROCESS).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        Assert.Null(open);
    }

    [Fact]
    public async Task CloseReturnValue_InProcess() {
        ILocator dialog = Page.GetByTestId(DialogGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.show();");

        await Page.GetByTestId(DialogGroup.BUTTON_CLOSE_RETURN_VALUE_INPROCESS).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DIALOG_ELEMENT).GetAttributeAsync("open");
        string result = await dialog.EvaluateAsync<string>("dialog => dialog.returnValue;");
        Assert.Null(open);
        Assert.Equal(DialogGroup.TEST_RETURN_VALUE, result);
    }


    [Fact]
    public async Task RegisterOnCancel_InProcess() {
        await Page.GetByTestId(DialogGroup.BUTTON_REGISTER_ON_CANCEL_INPROCESS).ClickAsync();
        ILocator dialog = Page.GetByTestId(DialogGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => dialog.showModal();");
        await dialog.PressAsync("Escape");

        string? result = await Page.GetByTestId(DialogGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(DialogGroup.TEST_CANCEL_EVENT, result);
    }

    [Fact]
    public async Task RegisterOnClose_InProcess() {
        await Page.GetByTestId(DialogGroup.BUTTON_REGISTER_ON_CLOSE_INPROCESS).ClickAsync();
        ILocator dialog = Page.GetByTestId(DialogGroup.DIALOG_ELEMENT);
        await dialog.EvaluateAsync("dialog => { dialog.show(); dialog.close() }");

        string? result = await Page.GetByTestId(DialogGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(DialogGroup.TEST_CLOSE_EVENT, result);
    }
}
