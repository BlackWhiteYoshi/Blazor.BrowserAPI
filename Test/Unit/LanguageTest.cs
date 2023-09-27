using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using Xunit;

namespace Blazor.BrowserAPI.UnitTest;

public sealed class LanguageTest : PlayWrightTest {
    public LanguageTest(PlayWrightFixture playWrightFixture) : base(playWrightFixture) { }


    [Fact]
    public async Task GetBrowserLanguage_Property() {
        string expected = await Page.EvaluateAsync<string>("navigator.language");

        await Page.GetByTestId(LanguageGroup.DATA_TESTID_GET_BROWSER_LANGUAGE_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(LanguageGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task GetBrowserLanguage_Method() {
        string expected = await Page.EvaluateAsync<string>("navigator.language");

        await Page.GetByTestId(LanguageGroup.DATA_TESTID_GET_BROWSER_LANGUAGE_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(LanguageGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task GetHtmlLanguage_Property() {
        await Page.GetByTestId(LanguageGroup.DATA_TESTID_GET_HTML_LANGUAGE_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(LanguageGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal("en", result);
    }

    [Fact]
    public async Task GetHtmlLanguage_Method() {
        await Page.GetByTestId(LanguageGroup.DATA_TESTID_GET_HTML_LANGUAGE_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(LanguageGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal("en", result);
    }

    [Fact]
    public async Task SetHtmlLanguage() {
        await Page.GetByTestId(LanguageGroup.DATA_TESTID_SET_HTML_LANGUAGE).ClickAsync();

        IElementHandle? htmlElement = await Page.QuerySelectorAsync("html");
        string? htmlLanguage = await htmlElement!.GetAttributeAsync("lang");
        Assert.Equal(LanguageGroup.SET_HTML_TEST, htmlLanguage);
    }


    [Fact]
    public async Task GetBrowserLanguage_InProcess() {
        string expected = await Page.EvaluateAsync<string>("navigator.language");

        await Page.GetByTestId(LanguageGroup.DATA_TESTID_GET_BROWSER_LANGUAGE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(LanguageGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task GetHtmlLanguage_InProcess() {
        await Page.GetByTestId(LanguageGroup.DATA_TESTID_GET_HTML_LANGUAGE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(LanguageGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal("en", result);
    }

    [Fact]
    public async Task SetHtmlLanguage_InProcess() {
        await Page.GetByTestId(LanguageGroup.DATA_TESTID_SET_HTML_LANGUAGE_INPROCESS).ClickAsync();

        IElementHandle? htmlElement = await Page.QuerySelectorAsync("html");
        string? htmlLanguage = await htmlElement!.GetAttributeAsync("lang");
        Assert.Equal(LanguageGroup.SET_HTML_TEST, htmlLanguage);
    }
}
