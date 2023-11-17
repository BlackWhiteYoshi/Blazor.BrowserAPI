using AutoInterfaceAttributes;

namespace BrowserAPI;

/// <summary>
/// The read-only sessionStorage property accesses a session Storage object for the current origin.<br />
/// sessionStorage is similar to localStorage; the difference is that while data in localStorage doesn't expire, data in sessionStorage is cleared when the page session ends.
/// </summary>
[AutoInterface]
internal sealed class SessionStorage(IModuleManager moduleManager) : ISessionStorage {
    /// <summary>
    /// Returns an integer representing the number of data items stored in sessionStorage.
    /// </summary>
    public ValueTask<int> Length => GetLength(default);

    /// <summary>
    /// Returns an integer representing the number of data items stored in sessionStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetLength(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("sessionStorageLength", cancellationToken);

    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in sessionStorage
    /// </summary>
    /// <param name="index">An integer representing the number of the key you want to get the name of. This is a zero-based index.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string?> Key(int index, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync<string?>("sessionStorageKey", cancellationToken, [index]);

    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to retrieve the value of.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string?> GetItem(string key, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync<string?>("sessionStorageGetItem", cancellationToken, [key]);

    /// <summary>
    /// When passed a key name and value, will add that key to sessionStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to create/update.</param>
    /// <param name="value">A string containing the value you want to give the key you are creating/updating.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask SetItem(string key, string value, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("sessionStorageSetItem", cancellationToken, [key, value]);

    /// <summary>
    /// When passed a key name, will remove that key from sessionStorage.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to remove.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask RemoveItem(string key, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("sessionStorageRemoveItem", cancellationToken, [key]);

    /// <summary>
    /// When invoked, will empty all keys out of sessionStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Clear(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("sessionStorageClear", cancellationToken);
}
