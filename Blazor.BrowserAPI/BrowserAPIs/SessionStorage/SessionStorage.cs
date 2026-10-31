using AutoInterfaceAttributes;

namespace BrowserAPI.Implementation;

/// <summary>
/// The read-only <i>sessionStorage</i> property accesses a session Storage object for the current origin.<br />
/// <i>sessionStorage</i> is similar to <i>localStorage</i>; the difference is that while data in <i>localStorage</i> doesn't expire, data in <i>sessionStorage</i> is cleared when the page session ends.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
public sealed class SessionStorage(IModuleManager moduleManager) : ISessionStorage {
    /// <summary>
    /// Returns an integer representing the number of data items stored in sessionStorage.
    /// </summary>
    public ValueTask<int> Length => GetLength(CancellationToken.None);

    /// <inheritdoc cref="Length" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetLength(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("SessionStorageAPI.count", cancellationToken);


    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in sessionStorage
    /// </summary>
    /// <param name="index">An integer representing the number of the key you want to get the name of. This is a zero-based index.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string?> Key(int index, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync<string?>("SessionStorageAPI.key", cancellationToken, [index]);

    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to retrieve the value of.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string?> GetItem(string key, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync<string?>("SessionStorageAPI.getItem", cancellationToken, [key]);

    /// <summary>
    /// When passed a key name and value, will add that key to sessionStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to create/update.</param>
    /// <param name="value">A string containing the value you want to give the key you are creating/updating.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask SetItem(string key, string value, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("SessionStorageAPI.setItem", cancellationToken, [key, value]);

    /// <summary>
    /// When passed a key name, will remove that key from sessionStorage.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to remove.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask RemoveItem(string key, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("SessionStorageAPI.removeItem", cancellationToken, [key]);

    /// <summary>
    /// When invoked, will empty all keys out of sessionStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Clear(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("SessionStorageAPI.clear", cancellationToken);
}
