﻿using BrowserAPI.Test.Client;
using Microsoft.Playwright;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class LanguageTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task GetBrowserLanguage_Property() {
        string expected = await Page.EvaluateAsync<string>("navigator.language;");

        await ExecuteTest(LanguageGroup.BUTTON_GET_BROWSER_LANGUAGE_PROPERTY);

        string? result = await Page.GetByTestId(LanguageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GetBrowserLanguage_Method() {
        string expected = await Page.EvaluateAsync<string>("navigator.language;");

        await ExecuteTest(LanguageGroup.BUTTON_GET_BROWSER_LANGUAGE_METHOD);

        string? result = await Page.GetByTestId(LanguageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(expected);
    }


    [Test]
    public async Task GetBrowserLanguages_Property() {
        string expected = await Page.EvaluateAsync<string>("navigator.languages.join('; ');");

        await ExecuteTest(LanguageGroup.BUTTON_GET_BROWSER_LANGUAGES_PROPERTY);

        string? result = await Page.GetByTestId(LanguageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GetBrowserLanguages_Method() {
        string expected = await Page.EvaluateAsync<string>("navigator.languages.join('; ');");

        await ExecuteTest(LanguageGroup.BUTTON_GET_BROWSER_LANGUAGES_METHOD);

        string? result = await Page.GetByTestId(LanguageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(expected);
    }


    [Test]
    public async Task GetHtmlLanguage_Property() {
        await ExecuteTest(LanguageGroup.BUTTON_GET_HTML_LANGUAGE_PROPERTY);

        string? result = await Page.GetByTestId(LanguageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("en");
    }

    [Test]
    public async Task GetHtmlLanguage_Method() {
        await ExecuteTest(LanguageGroup.BUTTON_GET_HTML_LANGUAGE_METHOD);

        string? result = await Page.GetByTestId(LanguageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("en");
    }

    [Test]
    public async Task SetHtmlLanguage() {
        await ExecuteTest(LanguageGroup.BUTTON_SET_HTML_LANGUAGE);

        IElementHandle? htmlElement = await Page.QuerySelectorAsync("html");
        string? htmlLanguage = await htmlElement!.GetAttributeAsync("lang");
        await Assert.That(htmlLanguage).IsEqualTo(LanguageGroup.TEST_SET_HTML);
    }
}
