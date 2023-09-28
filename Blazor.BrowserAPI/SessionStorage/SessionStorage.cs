using AutoInterfaceAttributes;

namespace BrowserAPI;

/// <summary>
/// The read-only sessionStorage property accesses a session Storage object for the current origin.<br />
/// sessionStorage is similar to localStorage;<br />
/// the difference is that while data in localStorage doesn't expire, data in sessionStorage is cleared when the page session ends.
/// </summary>
[AutoInterface]
public sealed class SessionStorage : ISessionStorage {
    private readonly IModuleManager _moduleManager;

    public SessionStorage(IModuleManager moduleManager) {
        _moduleManager = moduleManager;
    }


    /// <summary>
    /// Returns an integer representing the number of data items stored in sessionStorage.
    /// </summary>
    public ValueTask<int> Length => GetLength(default);

    /// <summary>
    /// Returns an integer representing the number of data items stored in sessionStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetLength(CancellationToken cancellationToken) => _moduleManager.InvokeTrySync<int>("sessionStorageLength", cancellationToken);

    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in sessionStorage
    /// </summary>
    /// <param name="index"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string?> Key(int index, CancellationToken cancellationToken = default) => _moduleManager.InvokeTrySync<string?>("sessionStorageKey", cancellationToken, index);

    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string?> GetItem(string key, CancellationToken cancellationToken = default) => _moduleManager.InvokeTrySync<string?>("sessionStorageGetItem", cancellationToken, key);

    /// <summary>
    /// When passed a key name and value, will add that key to sessionStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask SetItem(string key, string value, CancellationToken cancellationToken = default) => _moduleManager.InvokeTrySync("sessionStorageSetItem", cancellationToken, key, value);

    /// <summary>
    /// When passed a key name, will remove that key from sessionStorage.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask RemoveItem(string key, CancellationToken cancellationToken = default) => _moduleManager.InvokeTrySync("sessionStorageRemoveItem", cancellationToken, key);

    /// <summary>
    /// When invoked, will empty all keys out of sessionStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Clear(CancellationToken cancellationToken = default) => _moduleManager.InvokeTrySync("sessionStorageClear", cancellationToken);
}
