using AutoInterfaceAttributes;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>This interface is obsolete and will be removed in the future.</para>
/// <para>
/// The following functionalities are available in other interfaces:<br />
/// - <see cref="ILanguage.BrowserLanguage"/> (navigator.language) -> <see cref="INavigator.Language"/><br />
/// - <see cref="ILanguage.BrowserLanguages"/> (navigator.languages) -> <see cref="INavigator.Languages"/><br />
/// - <see cref="ILanguage.HtmlLanguage"/> (document.documentElement.lang) -> <see cref="IDocument.DocumentElement"/>.<see cref="IHTMLElement.Lang">Lang</see>
/// </para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
public sealed class Language(IModuleManager moduleManager) : ILanguage {
    /// <summary>
    /// <para>navigator.language</para>
    /// <para>
    /// Deprecated, use <see cref="INavigator.Language"/> instead:
    /// <code>
    /// [Inject]
    /// public required INavigator Navigator { private get; init; }
    /// ...
    /// string value = await Navigator.Language;
    /// </code>
    /// </para>
    /// </summary>
    [Obsolete("Will be removed at Release. Use INavigator.Language instead.")]
    public ValueTask<string> BrowserLanguage => GetBrowserLanguage(CancellationToken.None);

    /// <inheritdoc cref="BrowserLanguage" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Obsolete("Will be removed at Release. Use INavigator.Language instead.")]
    public ValueTask<string> GetBrowserLanguage(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("LanguageAPI.getBrowserLanguage", cancellationToken);


    /// <summary>
    /// <para>navigator.languages</para>
    /// <para>
    /// Deprecated, use <see cref="INavigator.Languages"/> instead:
    /// <code>
    /// [Inject]
    /// public required INavigator Navigator { private get; init; }
    /// ...
    /// string[] value = await Navigator.Languages;
    /// </code>
    /// </para>
    /// </summary>
    [Obsolete("Will be removed at Release. Use INavigator.Languages instead.")]
    public ValueTask<string[]> BrowserLanguages => GetBrowserLanguages(CancellationToken.None);

    /// <inheritdoc cref="BrowserLanguages" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Obsolete("Will be removed at Release. Use INavigator.Languages instead.")]
    public ValueTask<string[]> GetBrowserLanguages(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string[]>("LanguageAPI.getBrowserLanguages", cancellationToken);


    /// <summary>
    /// <para>document.documentElement.lang</para>
    /// <para>
    /// Deprecated, use <see cref="IDocument.DocumentElement"/>.<see cref="IHTMLElement.Lang">Lang</see> instead:
    /// <code>
    /// [Inject]
    /// public required IDocument Document { private get; init; }
    /// ...
    /// string value = await Document.DocumentElement.Lang;
    /// await Document.DocumentElement.SetLang(newValue);
    /// </code>
    /// </para>
    /// </summary>
    [Obsolete("Will be removed at Release. Use IDocument.DocumentElement.Lang instead.")]
    public ValueTask<string> HtmlLanguage => GetHtmlLanguage(CancellationToken.None);

    /// <inheritdoc cref="HtmlLanguage" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Obsolete("Will be removed at Release. Use IDocument.DocumentElement.Lang instead.")]
    public ValueTask<string> GetHtmlLanguage(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("LanguageAPI.getHtmlLanguage", cancellationToken);

    /// <inheritdoc cref="HtmlLanguage" />
    /// <param name="language">language abbreviation: e.g. "en", "fr", "es", "de"</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Obsolete("Will be removed at Release. Use IDocument.DocumentElement.Lang instead.")]
    public ValueTask SetHtmlLanguage(string language, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("LanguageAPI.setHtmlLanguage", cancellationToken, [language]);
}
