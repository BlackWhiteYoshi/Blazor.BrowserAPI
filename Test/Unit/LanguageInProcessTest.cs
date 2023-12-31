﻿using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using Xunit;

namespace BrowserAPI.UnitTest;

public sealed class LanguageInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Fact]
    public async Task GetBrowserLanguage() {
        string expected = await Page.EvaluateAsync<string>("navigator.language;");

        await Page.GetByTestId(LanguageGroup.BUTTON_GET_BROWSER_LANGUAGE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(LanguageGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task GetHtmlLanguage() {
        await Page.GetByTestId(LanguageGroup.BUTTON_GET_HTML_LANGUAGE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(LanguageGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("en", result);
    }

    [Fact]
    public async Task SetHtmlLanguage() {
        await Page.GetByTestId(LanguageGroup.BUTTON_SET_HTML_LANGUAGE_INPROCESS).ClickAsync();

        IElementHandle? htmlElement = await Page.QuerySelectorAsync("html");
        string? htmlLanguage = await htmlElement!.GetAttributeAsync("lang");
        Assert.Equal(LanguageGroup.TEST_SET_HTML, htmlLanguage);
    }
}
