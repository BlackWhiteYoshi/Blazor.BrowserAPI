using AutoInterfaceAttributes;

namespace BrowserAPI.Implementation;

/// <summary>
/// This interface is a collection of language related functionalities,
/// for example <see href="https://developer.mozilla.org/en-US/docs/Web/API/Navigator/language">navigator.language</see>
/// or <see href="https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Global_attributes/lang">document.documentElement.lang</see> attribute.<br />
/// It is not an official API.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
public sealed class Language(IModuleManager moduleManager) : ILanguage {
    /// <summary>
    /// <para>navigator.language</para>
    /// <para>Returns a string representing the preferred language of the user, usually the language of the browser UI. Examples of valid language codes include "en", "en-US", "fr", "fr-FR", "es-ES", etc.</para>
    /// </summary>
    public ValueTask<string> BrowserLanguage => GetBrowserLanguage(default);

    /// <inheritdoc cref="BrowserLanguage" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetBrowserLanguage(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("LanguageAPI.getBrowserLanguage", cancellationToken);


    /// <summary>
    /// <para>navigator.languages</para>
    /// <para>
    /// Returns an array of strings representing the languages known to the user, by order of preference.
    /// The language is described using language tags according to RFC 5646: Tags for Identifying Languages (also known as BCP 47).
    /// In the returned array they are ordered by preference with the most preferred language first.
    /// </para>
    /// <para>The value of navigator.language is the first element of the returned array.</para>
    /// </summary>
    public ValueTask<string[]> BrowserLanguages => GetBrowserLanguages(default);

    /// <inheritdoc cref="BrowserLanguages" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string[]> GetBrowserLanguages(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string[]>("LanguageAPI.getBrowserLanguages", cancellationToken);


    /// <summary>
    /// <para>document.documentElement.lang</para>
    /// <para>The content of the "lang" attribute on the html tag.</para>
    /// <para>language abbreviation: e.g. "en", "fr", "es", "de"</para>
    /// </summary>
    public ValueTask<string> HtmlLanguage => GetHtmlLanguage(default);

    /// <inheritdoc cref="HtmlLanguage" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetHtmlLanguage(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("LanguageAPI.getHtmlLanguage", cancellationToken);

    /// <inheritdoc cref="HtmlLanguage" />
    /// <param name="language">language abbreviation: e.g. "en", "fr", "es", "de"</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask SetHtmlLanguage(string language, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("LanguageAPI.setHtmlLanguage", cancellationToken, [language]);
}
