using AutoInterfaceAttributes;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>This interface is obsolete and will be removed in the future.</para>
/// <para>
/// The following functionalities are available in other interfaces:<br />
/// - <see cref="ILanguageInProcess.BrowserLanguage"/> (navigator.language) -> <see cref="INavigatorInProcess.Language"/><br />
/// - <see cref="ILanguageInProcess.BrowserLanguages"/> (navigator.languages) -> <see cref="INavigatorInProcess.Languages"/><br />
/// - <see cref="ILanguageInProcess.HtmlLanguage"/> (document.documentElement.lang) -> <see cref="IDocumentInProcess.DocumentElement"/>.<see cref="IHTMLElementInProcess.Lang">Lang</see>
/// </para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
public sealed class LanguageInProcess(IModuleManager moduleManager) : ILanguageInProcess {
    /// <summary>
    /// <para>navigator.language</para>
    /// <para>
    /// Deprecated, use <see cref="INavigatorInProcess.Language"/> instead:
    /// <code>
    /// [Inject]
    /// public required INavigatorInProcess Navigator { private get; init; }
    /// ...
    /// string value = Navigator.Language;
    /// </code>
    /// </para>
    /// </summary>
    [Obsolete("Will be removed at Release. Use INavigator.Language instead.")]
    public string BrowserLanguage => moduleManager.InvokeSync<string>("LanguageAPI.getBrowserLanguage");

    /// <summary>
    /// <para>navigator.languages</para>
    /// <para>
    /// Deprecated, use <see cref="INavigatorInProcess.Languages"/> instead:
    /// <code>
    /// [Inject]
    /// public required INavigatorInProcess Navigator { private get; init; }
    /// ...
    /// string[] value = Navigator.Languages;
    /// </code>
    /// </para>
    /// </summary>
    [Obsolete("Will be removed at Release. Use INavigator.Languages instead.")]
    public string[] BrowserLanguages => moduleManager.InvokeSync<string[]>("LanguageAPI.getBrowserLanguages");

    /// <summary>
    /// <para>document.documentElement.lang</para>
    /// <para>
    /// Deprecated, use <see cref="IDocumentInProcess.DocumentElement"/>.<see cref="IHTMLElementInProcess.Lang">Lang</see> instead:
    /// <code>
    /// [Inject]
    /// public required IDocumentInProcess Document { private get; init; }
    /// ...
    /// string value = Document.DocumentElement.Lang;
    /// Document.DocumentElement.Lang = newValue;
    /// </code>
    /// </para>
    /// </summary>
    [Obsolete("Will be removed at Release. Use IDocument.DocumentElement.Lang instead.")]
    public string HtmlLanguage {
        get => moduleManager.InvokeSync<string>("LanguageAPI.getHtmlLanguage");
        set => moduleManager.InvokeSync("LanguageAPI.setHtmlLanguage", [value]);
    }
}
