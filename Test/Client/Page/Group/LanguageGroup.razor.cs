using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class LanguageGroup : ComponentBase {
    public const string TEST_SET_HTML = "html language test";


    [Inject]
    public required ILanguage Language { private get; init; }

    [Inject]
    public required ILanguageInProcess LanguageInProcess { private get; init; }


    public const string LABEL_OUTPUT = "language-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_BROWSER_LANGUAGE_PROPERTY = "get-browser-language-property";
    private async Task GetBrowserLanguage_Property() {
        labelOutput = await Language.BrowserLanguage;
    }

    public const string BUTTON_GET_BROWSER_LANGUAGE_METHOD = "get-browser-language-method";
    private async Task GetBrowserLanguage_Method() {
        labelOutput = await Language.GetBrowserLanguage(default);
    }

    public const string BUTTON_GET_HTML_LANGUAGE_PROPERTY = "get-html-language-property";
    private async Task GetHtmlLanguage_Property() {
        labelOutput = await Language.HtmlLanguage;
    }

    public const string BUTTON_GET_HTML_LANGUAGE_METHOD = "get-html-language-method";
    private async Task GetHtmlLanguage_Method() {
        labelOutput = await Language.GetHtmlLanguage(default);
    }

    public const string BUTTON_SET_HTML_LANGUAGE = "set-html-language";
    private async Task SetHtmlLanguage() {
        await Language.SetHtmlLanguage(TEST_SET_HTML);
    }


    public const string BUTTON_GET_BROWSER_LANGUAGE_INPROCESS = "get-browser-language-inprocess";
    private void GetBrowserLanguage_InProcess() {
        labelOutput = LanguageInProcess.BrowserLanguage;
    }

    public const string BUTTON_GET_HTML_LANGUAGE_INPROCESS = "get-html-language-inprocess";
    private void GetHtmlLanguage_InProcess() {
        labelOutput = LanguageInProcess.HtmlLanguage;
    }

    public const string BUTTON_SET_HTML_LANGUAGE_INPROCESS = "set-html-language-inprocess";
    private void SetHtmlLanguage_InProcess() {
        LanguageInProcess.HtmlLanguage = TEST_SET_HTML;
    }
}
