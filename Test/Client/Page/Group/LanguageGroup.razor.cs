using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class LanguageGroup {
    public const string DATA_TESTID_GET_BROWSER_LANGUAGE_PROPERTY = "get-browser-language-property";
    public const string DATA_TESTID_GET_BROWSER_LANGUAGE_METHOD = "get-browser-language-method";
    public const string DATA_TESTID_GET_HTML_LANGUAGE_PROPERTY = "get-html-language-property";
    public const string DATA_TESTID_GET_HTML_LANGUAGE_METHOD = "get-html-language-method";
    public const string DATA_TESTID_SET_HTML_LANGUAGE = "set-html-language";

    public const string DATA_TESTID_GET_BROWSER_LANGUAGE_INPROCESS = "get-browser-language-inprocess";
    public const string DATA_TESTID_GET_HTML_LANGUAGE_INPROCESS = "get-html-language-inprocess";
    public const string DATA_TESTID_SET_HTML_LANGUAGE_INPROCESS = "set-html-language-inprocess";

    public const string DATA_TESTID_OUTPUT = "language-output";

    public const string SET_HTML_TEST = "html language test";


    [Inject]
    public required ILanguage Language { private get; init; }

    [Inject]
    public required ILanguageInProcess LanguageInProcess { private get; init; }

    private string labelOutput = string.Empty;
    
    
    private async Task GetBrowserLanguage_Property() {
        labelOutput = await Language.BrowserLanguage;
    }

    private async Task GetBrowserLanguage_Method() {
        labelOutput = await Language.GetBrowserLanguage(default);
    }

    private async Task GetHtmlLanguage_Property() {
        labelOutput = await Language.HtmlLanguage;
    }

    private async Task GetHtmlLanguage_Method() {
        labelOutput = await Language.GetHtmlLanguage(default);
    }

    private async Task SetHtmlLanguage() {
        await Language.SetHtmlLanguage(SET_HTML_TEST);
    }


    private void GetBrowserLanguage_InProcess() {
        labelOutput = LanguageInProcess.BrowserLanguage;
    }

    private void GetHtmlLanguage_InProcess() {
        labelOutput = LanguageInProcess.HtmlLanguage;
    }

    private void SetHtmlLanguage_InProcess() {
        LanguageInProcess.HtmlLanguage = SET_HTML_TEST;
    }
}
