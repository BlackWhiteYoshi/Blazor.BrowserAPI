﻿using AutoInterfaceAttributes;

namespace BrowserAPI;

/// <summary>
/// <para>The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI.</para>
/// <para>The document.documentElement.lang attribute sets the language of the content in the HTML page.</para>
/// </summary>
[AutoInterface]
internal sealed class LanguageInProcess(IModuleManager moduleManager) : ILanguageInProcess {
    /// <summary>
    /// <para>navigator.language</para>
    /// <para>The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI. Examples of valid language codes include "en", "en-US", "fr", "fr-FR", "es-ES", etc.</para>
    /// </summary>
    public string BrowserLanguage => moduleManager.InvokeSync<string>("LanguageBrowser");

    /// <summary>
    /// <para>document.documentElement.lang</para>
    /// <para>The content of the "lang" attribute on the html tag.</para>
    /// <para>language abbreviation: e.g. "en", "fr", "es", "de"</para>
    /// </summary>
    public string HtmlLanguage {
        get => moduleManager.InvokeSync<string>("LanguageHtmlRead");
        set => moduleManager.InvokeSync("LanguageHtmlWrite", value);
    }
}
