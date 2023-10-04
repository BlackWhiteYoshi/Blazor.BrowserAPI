using AutoInterfaceAttributes;

namespace BrowserAPI;

/// <summary>
/// The Document property cookie lets you read and write cookies associated with the document.
/// </summary>
[AutoInterface]
internal sealed class CookieStorage : ICookieStorage {
    private readonly IModuleManager _moduleManager;

    public CookieStorage(IModuleManager moduleManager) {
        _moduleManager = moduleManager;
    }


    /// <summary>
    /// <para>document.cookie</para>
    /// <para>
    /// Returns a string containing a semicolon-separated list of all cookies (i.e. key=value pairs).<br />
    /// Note that each key and value may be surrounded by whitespace (space and tab characters).
    /// </para>
    /// </summary>
    public ValueTask<string> AllCookies => GetAllCookies(default);

    /// <summary>
    /// <para>document.cookie</para>
    /// <para>
    /// Returns a string containing a semicolon-separated list of all cookies (i.e. key=value pairs).<br />
    /// Note that each key and value may be surrounded by whitespace (space and tab characters).
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetAllCookies(CancellationToken cancellationToken) => _moduleManager.InvokeTrySync<string>("getAllCookies", cancellationToken);

    /// <summary>
    /// Returns an integer representing the number of cookies stored in cookieStorage.
    /// </summary>
    public ValueTask<int> Length => GetLength(default);

    /// <summary>
    /// Returns an integer representing the number of cookies stored in cookieStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetLength(CancellationToken cancellationToken) => _moduleManager.InvokeTrySync<int>("cookieStorageLength", cancellationToken);

    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in cookieStorage.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string?> Key(int index, CancellationToken cancellationToken = default) => _moduleManager.InvokeTrySync<string?>("cookieStorageKey", cancellationToken, index);

    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string?> GetCookie(string key, CancellationToken cancellationToken = default) => _moduleManager.InvokeTrySync<string?>("cookieStorageGetCookie", cancellationToken, key);

    /// <summary>
    /// When passed a key name and value, will add that key to cookieStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expires">Time in ms until the cookie gets removed.<br />Default is not setting this attribute, so it will be a session cookie and gets discarded when the client shuts down.</param>
    /// <param name="path"></param>
    /// <param name="sameSite"></param>
    /// <param name="secure"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask SetCookie(string key, string value, int? expires = null, string path = "/", CookieSameSite sameSite = CookieSameSite.None, bool secure = false, CancellationToken cancellationToken = default)
        => _moduleManager.InvokeTrySync("cookieStorageSetCookie", cancellationToken, key, value, expires, path, sameSite.ToString(), secure);

    /// <summary>
    /// When passed a key name, will remove that key from cookieStorage.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask RemoveCookie(string key, CancellationToken cancellationToken = default) => _moduleManager.InvokeTrySync("cookieStorageRemoveCookie", cancellationToken, key);

    /// <summary>
    /// When invoked, will empty all keys out of cookieStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Clear(CancellationToken cancellationToken = default) => _moduleManager.InvokeTrySync("cookieStorageClear", cancellationToken);
}
