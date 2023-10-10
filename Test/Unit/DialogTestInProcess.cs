using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using Xunit;

namespace BrowserAPI.UnitTest;

public sealed class DialogTestInProcess : PlayWrightTest {
    public DialogTestInProcess(PlayWrightFixture playWrightFixture) : base(playWrightFixture) { }


    [Fact]
    public async Task GetOpen_InProcess() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_GET_OPEN_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(DialogGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetOpen_InProcess() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_SET_OPEN_INPROCESS).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG).GetAttributeAsync("open");
        Assert.Equal(string.Empty, open);
    }


    [Fact]
    public async Task GetReturnValue_InProcess() {
        const string RESULT = "return value result";
        ILocator dialog = Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG);
        await dialog.EvaluateAsync($"dialog => dialog.returnValue = '{RESULT}';");

        await Page.GetByTestId(DialogGroup.DATA_TESTID_GET_RETURN_VALUE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(DialogGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(RESULT, result);
    }

    [Fact]
    public async Task SetReturnValue_InProcess() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_SET_RETURN_VALUE_INPROCESS).ClickAsync();

        ILocator dialog = Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG);
        string result = await dialog.EvaluateAsync<string>("dialog => dialog.returnValue;");
        Assert.Equal(DialogGroup.RETURN_VALUE_TEST, result);
    }


    [Fact]
    public async Task Show_InProcess() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_SHOW_INPROCESS).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG).GetAttributeAsync("open");
        Assert.Equal(string.Empty, open);
    }

    [Fact]
    public async Task ShowModal_InProcess() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_SHOW_MODAL_INPROCESS).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG).GetAttributeAsync("open");
        Assert.Equal(string.Empty, open);
    }

    [Fact]
    public async Task Close_InProcess() {
        ILocator dialog = Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG);
        await dialog.EvaluateAsync("dialog => dialog.show();");

        await Page.GetByTestId(DialogGroup.DATA_TESTID_CLOSE_INPROCESS).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG).GetAttributeAsync("open");
        Assert.Null(open);
    }

    [Fact]
    public async Task CloseReturnValue_InProcess() {
        ILocator dialog = Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG);
        await dialog.EvaluateAsync("dialog => dialog.show();");

        await Page.GetByTestId(DialogGroup.DATA_TESTID_CLOSE_RETURN_VALUE_INPROCESS).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG).GetAttributeAsync("open");
        string result = await dialog.EvaluateAsync<string>("dialog => dialog.returnValue;");
        Assert.Null(open);
        Assert.Equal(DialogGroup.RETURN_VALUE_TEST, result);
    }


    [Fact]
    public async Task RegisterOnCancel_InProcess() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_REGISTER_ON_CANCEL_INPROCESS).ClickAsync();
        ILocator dialog = Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG);
        await dialog.EvaluateAsync("dialog => dialog.showModal();");
        await dialog.PressAsync("Escape");

        string? result = await Page.GetByTestId(DialogGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(DialogGroup.CANCEL_EVENT_TEST, result);
    }

    [Fact]
    public async Task RegisterOnClose_InProcess() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_REGISTER_ON_CLOSE_INPROCESS).ClickAsync();
        ILocator dialog = Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG);
        await dialog.EvaluateAsync("dialog => { dialog.show(); dialog.close() }");

        string? result = await Page.GetByTestId(DialogGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(DialogGroup.CLOSE_EVENT_TEST, result);
    }
}
