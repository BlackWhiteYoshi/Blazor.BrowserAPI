using AutoInterfaceAttributes;

namespace BrowserAPI;

/// <summary>
/// The read-only sessionStorage property accesses a session Storage object for the current origin.<br />
/// sessionStorage is similar to localStorage;<br />
/// the difference is that while data in localStorage doesn't expire, data in sessionStorage is cleared when the page session ends.
/// </summary>
[AutoInterface(Name = "ISessionStorageInProcess")]
public sealed partial class BrowserAPICore : ISessionStorageInProcess {
    /// <summary>
    /// Returns an integer representing the number of data items stored in sessionStorage.
    /// </summary>
    int ISessionStorageInProcess.Length => InvokeSync<int>("sessionStorageLength");

    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in sessionStorage.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    string? ISessionStorageInProcess.Key(int index) => InvokeSync<string?>("sessionStorageKey", index);

    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    string? ISessionStorageInProcess.GetItem(string key) => InvokeSync<string?>("sessionStorageGetItem", key);

    /// <summary>
    /// When passed a key name and value, will add that key to sessionStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void ISessionStorageInProcess.SetItem(string key, string value) => InvokeSync("sessionStorageSetItem", key, value);

    /// <summary>
    /// When passed a key name, will remove that key from sessionStorage.
    /// </summary>
    /// <param name="key"></param>
    void ISessionStorageInProcess.RemoveItem(string key) => InvokeSync("sessionStorageRemoveItem", key);

    /// <summary>
    /// When invoked, will empty all keys out of sessionStorage.
    /// </summary>
    void ISessionStorageInProcess.Clear() => InvokeSync("sessionStorageClear");
}
