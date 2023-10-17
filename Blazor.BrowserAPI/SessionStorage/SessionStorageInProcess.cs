using AutoInterfaceAttributes;

namespace BrowserAPI;

/// <summary>
/// The read-only sessionStorage property accesses a session Storage object for the current origin.<br />
/// sessionStorage is similar to localStorage; the difference is that while data in localStorage doesn't expire, data in sessionStorage is cleared when the page session ends.
/// </summary>
[AutoInterface]
internal sealed class SessionStorageInProcess : ISessionStorageInProcess {
    private readonly IModuleManager _moduleManager;

    public SessionStorageInProcess(IModuleManager moduleManager) {
        _moduleManager = moduleManager;
    }


    /// <summary>
    /// Returns an integer representing the number of data items stored in sessionStorage.
    /// </summary>
    public int Length => _moduleManager.InvokeSync<int>("sessionStorageLength");

    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in sessionStorage.
    /// </summary>
    /// <param name="index">An integer representing the number of the key you want to get the name of. This is a zero-based index.</param>
    /// <returns></returns>
    public string? Key(int index) => _moduleManager.InvokeSync<string?>("sessionStorageKey", index);

    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to retrieve the value of.</param>
    /// <returns></returns>
    public string? GetItem(string key) => _moduleManager.InvokeSync<string?>("sessionStorageGetItem", key);

    /// <summary>
    /// When passed a key name and value, will add that key to sessionStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to create/update.</param>
    /// <param name="value">A string containing the value you want to give the key you are creating/updating.</param>
    public void SetItem(string key, string value) => _moduleManager.InvokeSync("sessionStorageSetItem", key, value);

    /// <summary>
    /// When passed a key name, will remove that key from sessionStorage.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to remove.</param>
    public void RemoveItem(string key) => _moduleManager.InvokeSync("sessionStorageRemoveItem", key);

    /// <summary>
    /// When invoked, will empty all keys out of sessionStorage.
    /// </summary>
    public void Clear() => _moduleManager.InvokeSync("sessionStorageClear");
}
