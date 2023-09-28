using AutoInterfaceAttributes;

namespace BrowserAPI;

/// <summary>
/// The Document property cookie lets you read and write cookies associated with the document.
/// </summary>
[AutoInterface(Name = "ICookieStorage")]
[AutoInterface(Name = "ICookieStorageInProcess")]
public sealed partial class BrowserAPICore : ICookieStorage, ICookieStorageInProcess {
    /// <summary>
    /// <para>document.cookie</para>
    /// <para>
    /// Returns a string containing a semicolon-separated list of all cookies (i.e. key=value pairs).<br />
    /// Note that each key and value may be surrounded by whitespace (space and tab characters).
    /// </para>
    /// </summary>
    string ICookieStorageInProcess.AllCookies => InvokeSync<string>("getAllCookies");

    /// <summary>
    /// <para>document.cookie</para>
    /// <para>
    /// Returns a string containing a semicolon-separated list of all cookies (i.e. key=value pairs).<br />
    /// Note that each key and value may be surrounded by whitespace (space and tab characters).
    /// </para>
    /// </summary>
    ValueTask<string> ICookieStorage.AllCookies => InvokeTrySync<string>("getAllCookies", default);

    /// <summary>
    /// <para>document.cookie</para>
    /// <para>
    /// Returns a string containing a semicolon-separated list of all cookies (i.e. key=value pairs).<br />
    /// Note that each key and value may be surrounded by whitespace (space and tab characters).
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<string> ICookieStorage.GetAllCookies(CancellationToken cancellationToken) => InvokeTrySync<string>("getAllCookies", cancellationToken);


    /// <summary>
    /// Returns an integer representing the number of cookies stored in cookieStorage.
    /// </summary>
    int ICookieStorageInProcess.Length => InvokeSync<int>("cookieStorageLength");

    /// <summary>
    /// Returns an integer representing the number of cookies stored in cookieStorage.
    /// </summary>
    ValueTask<int> ICookieStorage.Length => InvokeTrySync<int>("cookieStorageLength", default);

    /// <summary>
    /// Returns an integer representing the number of cookies stored in cookieStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<int> ICookieStorage.GetLength(CancellationToken cancellationToken) => InvokeTrySync<int>("cookieStorageLength", cancellationToken);


    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in cookieStorage.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    string? ICookieStorageInProcess.Key(int index) => InvokeSync<string?>("cookieStorageKey", index);

    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in cookieStorage.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<string?> ICookieStorage.Key(int index, CancellationToken cancellationToken = default) => InvokeTrySync<string?>("cookieStorageKey", cancellationToken, index);


    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    string? ICookieStorageInProcess.GetCookie(string key) => InvokeSync<string?>("cookieStorageGetCookie", key);

    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<string?> ICookieStorage.GetCookie(string key, CancellationToken cancellationToken = default) => InvokeTrySync<string?>("cookieStorageGetCookie", cancellationToken, key);


    /// <summary>
    /// When passed a key name and value, will add that key to cookieStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expires">Time in ms until the cookie gets removed.<br />Default is not setting this attribute, so it will be a session cookie and gets discarded when the client shuts down.</param>
    /// <param name="path"></param>
    /// <param name="sameSite"></param>
    /// <param name="secure"></param>
    void ICookieStorageInProcess.SetCookie(string key, string value, int? expires = null, string path = "/", CookieSameSite sameSite = CookieSameSite.None, bool secure = false)
        => InvokeSync("cookieStorageSetCookie", key, value, expires, path, sameSite.ToString(), secure);

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
    ValueTask ICookieStorage.SetCookie(string key, string value, int? expires = null, string path = "/", CookieSameSite sameSite = CookieSameSite.None, bool secure = false, CancellationToken cancellationToken = default)
        => InvokeTrySync("cookieStorageSetCookie", cancellationToken, key, value, expires, path, sameSite.ToString(), secure);
    

    /// <summary>
    /// When passed a key name, will remove that key from cookieStorage.
    /// </summary>
    /// <param name="key"></param>
    void ICookieStorageInProcess.RemoveCookie(string key) => InvokeSync("cookieStorageRemoveCookie", key);

    /// <summary>
    /// When passed a key name, will remove that key from cookieStorage.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask ICookieStorage.RemoveCookie(string key, CancellationToken cancellationToken = default) => InvokeTrySync("cookieStorageRemoveCookie", cancellationToken, key);


    /// <summary>
    /// When invoked, will empty all keys out of cookieStorage.
    /// </summary>
    void ICookieStorageInProcess.Clear() => InvokeSync("cookieStorageClear");

    /// <summary>
    /// When invoked, will empty all keys out of cookieStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask ICookieStorage.Clear(CancellationToken cancellationToken = default) => InvokeTrySync("cookieStorageClear", cancellationToken);
}
