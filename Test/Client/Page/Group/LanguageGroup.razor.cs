using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class LanguageGroup : ComponentBase {
    public const string TEST_SET_HTML = "html language test";


    [Inject]
    public required ILanguage Language { private get; init; }


    public const string LABEL_OUTPUT = "language-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_BROWSER_LANGUAGE_PROPERTY = "language-get-browser-language-property";
    private async Task GetBrowserLanguage_Property() {
        labelOutput = await Language.BrowserLanguage;
    }

    public const string BUTTON_GET_BROWSER_LANGUAGE_METHOD = "language-get-browser-language-method";
    private async Task GetBrowserLanguage_Method() {
        labelOutput = await Language.GetBrowserLanguage(default);
    }


    public const string BUTTON_GET_BROWSER_LANGUAGES_PROPERTY = "language-get-browser-languages-property";
    private async Task GetBrowserLanguages_Property() {
        labelOutput = string.Join("; ", await Language.BrowserLanguages);
    }

    public const string BUTTON_GET_BROWSER_LANGUAGES_METHOD = "language-get-browser-languages-method";
    private async Task GetBrowserLanguages_Method() {
        labelOutput = string.Join("; ", await Language.GetBrowserLanguages(default));
    }


    public const string BUTTON_GET_HTML_LANGUAGE_PROPERTY = "language-get-html-language-property";
    private async Task GetHtmlLanguage_Property() {
        labelOutput = await Language.HtmlLanguage;
    }

    public const string BUTTON_GET_HTML_LANGUAGE_METHOD = "language-get-html-language-method";
    private async Task GetHtmlLanguage_Method() {
        labelOutput = await Language.GetHtmlLanguage(default);
    }

    public const string BUTTON_SET_HTML_LANGUAGE = "language-set-html-language";
    private async Task SetHtmlLanguage() {
        await Language.SetHtmlLanguage(TEST_SET_HTML);
    }
}
