using AutoInterfaceAttributes;

namespace BrowserAPI;

/// <summary>
/// <para>The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI.</para>
/// <para>The document.documentElement.lang attribute sets the language of the content in the HTML page.</para>
/// </summary>
[AutoInterface]
internal sealed class Language(IModuleManager moduleManager) : ILanguage {
    /// <summary>
    /// <para>navigator.language</para>
    /// <para>The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI. Examples of valid language codes include "en", "en-US", "fr", "fr-FR", "es-ES", etc.</para>
    /// </summary>
    public ValueTask<string> BrowserLanguage => GetBrowserLanguage(default);

    /// <summary>
    /// <para>navigator.language</para>
    /// <para>The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI. Examples of valid language codes include "en", "en-US", "fr", "fr-FR", "es-ES", etc.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetBrowserLanguage(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("LanguageBrowser", cancellationToken);

    /// <summary>
    /// <para>document.documentElement.lang</para>
    /// <para>Returns the content of the "lang" attribute on the html tag.</para>
    /// </summary>
    public ValueTask<string> HtmlLanguage => GetHtmlLanguage(default);

    /// <summary>
    /// <para>document.documentElement.lang</para>
    /// <para>Returns the content of the "lang" attribute on the html tag.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetHtmlLanguage(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("LanguageHtmlRead", cancellationToken);

    /// <summary>
    /// <para>document.documentElement.lang</para>
    /// <para>Sets the content of the "lang" attribute on the html tag.</para>
    /// </summary>
    /// <param name="language">language abbreviation: e.g. "en", "fr", "es", "de"</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask SetHtmlLanguage(string language, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("LanguageHtmlWrite", cancellationToken, language);
}
