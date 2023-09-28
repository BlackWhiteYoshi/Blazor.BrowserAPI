using AutoInterfaceAttributes;

namespace BrowserAPI;

/// <summary>
/// The read-only sessionStorage property accesses a session Storage object for the current origin.<br />
/// sessionStorage is similar to localStorage;<br />
/// the difference is that while data in localStorage doesn't expire, data in sessionStorage is cleared when the page session ends.
/// </summary>
[AutoInterface(Name = "ISessionStorage")]
[AutoInterface(Name = "ISessionStorageInProcess")]
public sealed partial class BrowserAPICore : ISessionStorage, ISessionStorageInProcess {
    /// <summary>
    /// Returns an integer representing the number of data items stored in sessionStorage.
    /// </summary>
    int ISessionStorageInProcess.Length => InvokeSync<int>("sessionStorageLength");

    /// <summary>
    /// Returns an integer representing the number of data items stored in sessionStorage.
    /// </summary>
    ValueTask<int> ISessionStorage.Length => InvokeTrySync<int>("sessionStorageLength", default);

    /// <summary>
    /// Returns an integer representing the number of data items stored in sessionStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<int> ISessionStorage.GetLength(CancellationToken cancellationToken) => InvokeTrySync<int>("sessionStorageLength", cancellationToken);


    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in sessionStorage.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    string? ISessionStorageInProcess.Key(int index) => InvokeSync<string?>("sessionStorageKey", index);

    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in sessionStorage
    /// </summary>
    /// <param name="index"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<string?> ISessionStorage.Key(int index, CancellationToken cancellationToken = default) => InvokeTrySync<string?>("sessionStorageKey", cancellationToken, index);


    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    string? ISessionStorageInProcess.GetItem(string key) => InvokeSync<string?>("sessionStorageGetItem", key);

    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<string?> ISessionStorage.GetItem(string key, CancellationToken cancellationToken = default) => InvokeTrySync<string?>("sessionStorageGetItem", cancellationToken, key);


    /// <summary>
    /// When passed a key name and value, will add that key to sessionStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void ISessionStorageInProcess.SetItem(string key, string value) => InvokeSync("sessionStorageSetItem", key, value);

    /// <summary>
    /// When passed a key name and value, will add that key to sessionStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask ISessionStorage.SetItem(string key, string value, CancellationToken cancellationToken = default) => InvokeTrySync("sessionStorageSetItem", cancellationToken, key, value);


    /// <summary>
    /// When passed a key name, will remove that key from sessionStorage.
    /// </summary>
    /// <param name="key"></param>
    void ISessionStorageInProcess.RemoveItem(string key) => InvokeSync("sessionStorageRemoveItem", key);

    /// <summary>
    /// When passed a key name, will remove that key from sessionStorage.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask ISessionStorage.RemoveItem(string key, CancellationToken cancellationToken = default) => InvokeTrySync("sessionStorageRemoveItem", cancellationToken, key);


    /// <summary>
    /// When invoked, will empty all keys out of sessionStorage.
    /// </summary>
    void ISessionStorageInProcess.Clear() => InvokeSync("sessionStorageClear");

    /// <summary>
    /// When invoked, will empty all keys out of sessionStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask ISessionStorage.Clear(CancellationToken cancellationToken = default) => InvokeTrySync("sessionStorageClear", cancellationToken);
}
