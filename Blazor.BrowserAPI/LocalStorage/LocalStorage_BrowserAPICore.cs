using AutoInterfaceAttributes;

namespace BrowserAPI;

/// <summary>
/// The localStorage read-only property of the window interface allows you to access a Storage object for the Document's origin;<br />
/// the stored data is saved across browser sessions.
/// </summary>
[AutoInterface(Name = "ILocalStorage")]
public sealed partial class BrowserAPICore : ILocalStorage {
    /// <summary>
    /// Returns an integer representing the number of data items stored in localStorage.
    /// </summary>
    ValueTask<int> ILocalStorage.Length => ((ILocalStorage)this).GetLength(default);

    /// <summary>
    /// Returns an integer representing the number of data items stored in localStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<int> ILocalStorage.GetLength(CancellationToken cancellationToken) => InvokeTrySync<int>("localStorageLength", cancellationToken);

    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in localStorage.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<string?> ILocalStorage.Key(int index, CancellationToken cancellationToken = default) => InvokeTrySync<string?>("localStorageKey", cancellationToken, index);

    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<string?> ILocalStorage.GetItem(string key, CancellationToken cancellationToken = default) => InvokeTrySync<string?>("localStorageGetItem", cancellationToken, key);

    /// <summary>
    /// When passed a key name and value, will add that key to localStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask ILocalStorage.SetItem(string key, string value, CancellationToken cancellationToken = default) => InvokeTrySync("localStorageSetItem", cancellationToken, key, value);

    /// <summary>
    /// When passed a key name, will remove that key from localStorage.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask ILocalStorage.RemoveItem(string key, CancellationToken cancellationToken = default) => InvokeTrySync("localStorageRemoveItem", cancellationToken, key);

    /// <summary>
    /// When invoked, will empty all keys out of localStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask ILocalStorage.Clear(CancellationToken cancellationToken = default) => InvokeTrySync("localStorageClear", cancellationToken);
}
