using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using Xunit;

namespace BrowserAPI.UnitTest;

public sealed class DialogTest : PlayWrightTest {
    public DialogTest(PlayWrightFixture playWrightFixture) : base(playWrightFixture) { }


    [Fact]
    public async Task GetOpen_Property() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_GET_OPEN_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(DialogGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task GetOpen_Method() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_GET_OPEN_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(DialogGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal("False", result);
    }

    [Fact]
    public async Task SetOpen() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_SET_OPEN).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG).GetAttributeAsync("open");
        Assert.Equal(string.Empty, open);
    }


    [Fact]
    public async Task GetReturnValue_Property() {
        const string RESULT = "return value result";
        ILocator dialog = Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG);
        await dialog.EvaluateAsync($"dialog => dialog.returnValue = '{RESULT}';");

        await Page.GetByTestId(DialogGroup.DATA_TESTID_GET_RETURN_VALUE_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(DialogGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(RESULT, result);
    }

    [Fact]
    public async Task GetReturnValue_Method() {
        const string RESULT = "return value result";
        ILocator dialog = Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG);
        await dialog.EvaluateAsync($"dialog => dialog.returnValue = '{RESULT}';");

        await Page.GetByTestId(DialogGroup.DATA_TESTID_GET_RETURN_VALUE_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(DialogGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(RESULT, result);
    }

    [Fact]
    public async Task SetReturnValue() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_SET_RETURN_VALUE).ClickAsync();

        ILocator dialog = Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG);
        string result = await dialog.EvaluateAsync<string>("dialog => dialog.returnValue;");
        Assert.Equal(DialogGroup.RETURN_VALUE_TEST, result);
    }


    [Fact]
    public async Task Show() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_SHOW).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG).GetAttributeAsync("open");
        Assert.Equal(string.Empty, open);
    }

    [Fact]
    public async Task ShowModal() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_SHOW_MODAL).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG).GetAttributeAsync("open");
        Assert.Equal(string.Empty, open);
    }

    [Fact]
    public async Task Close() {
        ILocator dialog = Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG);
        await dialog.EvaluateAsync("dialog => dialog.show();");

        await Page.GetByTestId(DialogGroup.DATA_TESTID_CLOSE).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG).GetAttributeAsync("open");
        Assert.Null(open);
    }

    [Fact]
    public async Task CloseReturnValue() {
        ILocator dialog = Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG);
        await dialog.EvaluateAsync("dialog => dialog.show();");

        await Page.GetByTestId(DialogGroup.DATA_TESTID_CLOSE_RETURN_VALUE).ClickAsync();

        string? open = await Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG).GetAttributeAsync("open");
        string result = await dialog.EvaluateAsync<string>("dialog => dialog.returnValue;");
        Assert.Null(open);
        Assert.Equal(DialogGroup.RETURN_VALUE_TEST, result);
    }


    [Fact]
    public async Task RegisterOnCancel() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_REGISTER_ON_CANCEL).ClickAsync();
        ILocator dialog = Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG);
        await dialog.EvaluateAsync("dialog => dialog.showModal();");
        await dialog.PressAsync("Escape");

        string? result = await Page.GetByTestId(DialogGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(DialogGroup.CANCEL_EVENT_TEST, result);
    }

    [Fact]
    public async Task RegisterOnClose() {
        await Page.GetByTestId(DialogGroup.DATA_TESTID_REGISTER_ON_CLOSE).ClickAsync();
        ILocator dialog = Page.GetByTestId(DialogGroup.DATA_TESTID_DIALOG);
        await dialog.EvaluateAsync("dialog => { dialog.show(); dialog.close() }");

        string? result = await Page.GetByTestId(DialogGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(DialogGroup.CLOSE_EVENT_TEST, result);
    }
}
