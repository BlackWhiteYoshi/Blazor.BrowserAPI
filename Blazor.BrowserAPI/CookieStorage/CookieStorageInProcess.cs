using AutoInterfaceAttributes;

namespace BrowserAPI;

/// <summary>
/// The Document property cookie lets you read and write cookies associated with the document.
/// </summary>
[AutoInterface]
public sealed class CookieStorageInProcess : ICookieStorageInProcess {
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
    /// <param name="index"></param>
    /// <returns></returns>
    public string? Key(int index) => _moduleManager.InvokeSync<string?>("cookieStorageKey", index);

    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string? GetCookie(string key) => _moduleManager.InvokeSync<string?>("cookieStorageGetCookie", key);

    /// <summary>
    /// When passed a key name and value, will add that key to cookieStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expires">Time in ms until the cookie gets removed.<br />Default is not setting this attribute, so it will be a session cookie and gets discarded when the client shuts down.</param>
    /// <param name="path"></param>
    /// <param name="sameSite"></param>
    /// <param name="secure"></param>
    public void SetCookie(string key, string value, int? expires = null, string path = "/", CookieSameSite sameSite = CookieSameSite.None, bool secure = false)
        => _moduleManager.InvokeSync("cookieStorageSetCookie", key, value, expires, path, sameSite.ToString(), secure);

    /// <summary>
    /// When passed a key name, will remove that key from cookieStorage.
    /// </summary>
    /// <param name="key"></param>
    public void RemoveCookie(string key) => _moduleManager.InvokeSync("cookieStorageRemoveCookie", key);

    /// <summary>
    /// When invoked, will empty all keys out of cookieStorage.
    /// </summary>
    public void Clear() => _moduleManager.InvokeSync("cookieStorageClear");
}
