using AutoInterfaceAttributes;

namespace BrowserAPI;

/// <summary>
/// The Document property cookie lets you read and write cookies associated with the document.
/// </summary>
[AutoInterface]
internal sealed class CookieStorageInProcess : ICookieStorageInProcess {
    private readonly IModuleManager _moduleManager;

    public CookieStorageInProcess(IModuleManager moduleManager) {
        _moduleManager = moduleManager;
    }


    /// <summary>
    /// <para>document.cookie</para>
    /// <para>
    /// Returns a string containing a semicolon-separated list of all cookies (i.e. key=value pairs).<br />
    /// Note that each key and value may be surrounded by whitespace (space and tab characters).
    /// </para>
    /// </summary>
    public string AllCookies => _moduleManager.InvokeSync<string>("getAllCookies");

    /// <summary>
    /// Returns an integer representing the number of cookies stored in cookieStorage.
    /// </summary>
    public int Length => _moduleManager.InvokeSync<int>("cookieStorageLength");

    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in cookieStorage.
    /// </summary>
    /// <param name="index">An integer representing the number of the key you want to get the name of. This is a zero-based index.</param>
    /// <returns></returns>
    public string? Key(int index) => _moduleManager.InvokeSync<string?>("cookieStorageKey", index);

    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to retrieve the value of.</param>
    /// <returns></returns>
    public string? GetCookie(string key) => _moduleManager.InvokeSync<string?>("cookieStorageGetCookie", key);

    /// <summary>
    /// When passed a key name and value, will add that key to cookieStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to create/update.</param>
    /// <param name="value">A string containing the value you want to give the key you are creating/updating.</param>
    /// <param name="expires">The expiry date of the cookie. If neither expires nor max-age is specified, it will expire at the end of session.</param>
    /// <param name="path">Indicates the path that must exist in the requested URL for the browser to send the Cookie header (e.g., '/', '/mydir').<br/>Default is "/"</param>
    /// <param name="sameSite">SameSite prevents the browser from sending this cookie along with cross-site requests. Possible values are lax, strict or none.<br/>Defailt is None</param>
    /// <param name="secure">Specifies that the cookie should only be transmitted over a secure protocol.<br/>Default is false</param>
    public void SetCookie(string key, string value, int? expires = null, string path = "/", CookieSameSite sameSite = CookieSameSite.None, bool secure = false)
        => _moduleManager.InvokeSync("cookieStorageSetCookie", key, value, expires, path, sameSite.ToString(), secure);

    /// <summary>
    /// When passed a key name, will remove that key from cookieStorage.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to remove.</param>
    public void RemoveCookie(string key) => _moduleManager.InvokeSync("cookieStorageRemoveCookie", key);

    /// <summary>
    /// When invoked, will empty all keys out of cookieStorage.
    /// </summary>
    public void Clear() => _moduleManager.InvokeSync("cookieStorageClear");
}
