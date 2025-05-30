﻿using BrowserAPI.Test.Client;
using Microsoft.Playwright;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class LanguageInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    [Retry(3)]
    public async Task GetBrowserLanguage() {
        string expected = await Page.EvaluateAsync<string>("navigator.language;");

        await Page.GetByTestId(LanguageInProcessGroup.BUTTON_GET_BROWSER_LANGUAGE).ClickAsync();

        string? result = await Page.GetByTestId(LanguageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Retry(3)]
    public async Task GetHtmlLanguage() {
        await Page.GetByTestId(LanguageInProcessGroup.BUTTON_GET_HTML_LANGUAGE).ClickAsync();

        string? result = await Page.GetByTestId(LanguageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("en");
    }

    [Test]
    [Retry(3)]
    public async Task SetHtmlLanguage() {
        await Page.GetByTestId(LanguageInProcessGroup.BUTTON_SET_HTML_LANGUAGE).ClickAsync();

        IElementHandle? htmlElement = await Page.QuerySelectorAsync("html");
        string? htmlLanguage = await htmlElement!.GetAttributeAsync("lang");
        await Assert.That(htmlLanguage).IsEqualTo(LanguageInProcessGroup.TEST_SET_HTML);
    }
}
