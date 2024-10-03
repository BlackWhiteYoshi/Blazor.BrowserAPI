using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class LanguageInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Fact]
    public async Task GetBrowserLanguage() {
        string expected = await Page.EvaluateAsync<string>("navigator.language;");

        await Page.GetByTestId(LanguageInProcessGroup.BUTTON_GET_BROWSER_LANGUAGE).ClickAsync();

        string? result = await Page.GetByTestId(LanguageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task GetHtmlLanguage() {
        await Page.GetByTestId(LanguageInProcessGroup.BUTTON_GET_HTML_LANGUAGE).ClickAsync();

        string? result = await Page.GetByTestId(LanguageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("en", result);
    }

    [Fact]
    public async Task SetHtmlLanguage() {
        await Page.GetByTestId(LanguageInProcessGroup.BUTTON_SET_HTML_LANGUAGE).ClickAsync();

        IElementHandle? htmlElement = await Page.QuerySelectorAsync("html");
        string? htmlLanguage = await htmlElement!.GetAttributeAsync("lang");
        Assert.Equal(LanguageInProcessGroup.TEST_SET_HTML, htmlLanguage);
    }
}
