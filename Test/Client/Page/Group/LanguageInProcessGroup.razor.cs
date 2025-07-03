using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class LanguageInProcessGroup : ComponentBase {
    public const string TEST_SET_HTML = "html language test inprocess";


    [Inject]
    public required ILanguageInProcess Language { private get; init; }


    public const string LABEL_OUTPUT = "language-inprocess-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_BROWSER_LANGUAGE = "language-inprocess-get-browser-language";
    private void GetBrowserLanguage() {
        labelOutput = Language.BrowserLanguage;
    }

    public const string BUTTON_GET_BROWSER_LANGUAGES = "language-inprocess-get-browser-languages";
    private void GetBrowserLanguages() {
        labelOutput = string.Join("; ", Language.BrowserLanguages);
    }

    public const string BUTTON_GET_HTML_LANGUAGE = "language-inprocess-get-html-language";
    private void GetHtmlLanguage() {
        labelOutput = Language.HtmlLanguage;
    }

    public const string BUTTON_SET_HTML_LANGUAGE = "language-inprocess-set-html-language";
    private void SetHtmlLanguage() {
        Language.HtmlLanguage = TEST_SET_HTML;
    }
}
