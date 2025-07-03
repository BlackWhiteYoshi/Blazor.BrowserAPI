using BrowserAPI.Test.Client;
using Microsoft.Playwright;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class LanguageInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task GetBrowserLanguage() {
        string expected = await Page.EvaluateAsync<string>("navigator.language;");

        await ExecuteTest(LanguageInProcessGroup.BUTTON_GET_BROWSER_LANGUAGE);

        string? result = await Page.GetByTestId(LanguageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GetBrowserLanguages() {
        string expected = await Page.EvaluateAsync<string>("navigator.languages.join('; ');");

        await ExecuteTest(LanguageInProcessGroup.BUTTON_GET_BROWSER_LANGUAGES);

        string? result = await Page.GetByTestId(LanguageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GetHtmlLanguage() {
        await ExecuteTest(LanguageInProcessGroup.BUTTON_GET_HTML_LANGUAGE);

        string? result = await Page.GetByTestId(LanguageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("en");
    }

    [Test]
    public async Task SetHtmlLanguage() {
        await ExecuteTest(LanguageInProcessGroup.BUTTON_SET_HTML_LANGUAGE);

        IElementHandle? htmlElement = await Page.QuerySelectorAsync("html");
        string? htmlLanguage = await htmlElement!.GetAttributeAsync("lang");
        await Assert.That(htmlLanguage).IsEqualTo(LanguageInProcessGroup.TEST_SET_HTML);
    }
}
