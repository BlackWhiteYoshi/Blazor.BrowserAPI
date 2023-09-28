using AutoInterfaceAttributes;

namespace BrowserAPI;

/// <summary>
/// The localStorage read-only property of the window interface allows you to access a Storage object for the Document's origin;<br />
/// the stored data is saved across browser sessions.
/// </summary>
[AutoInterface]
public sealed class LocalStorageInProcess : ILocalStorageInProcess {
    private readonly IModuleManager _moduleManager;

    public LocalStorageInProcess(IModuleManager moduleManager) {
        _moduleManager = moduleManager;
    }


    /// <summary>
    /// Returns an integer representing the number of data items stored in localStorage.
    /// </summary>
    public int Length => _moduleManager.InvokeSync<int>("localStorageLength");

    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in localStorage.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public string? Key(int index) => _moduleManager.InvokeSync<string?>("localStorageKey", index);

    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string? GetItem(string key) => _moduleManager.InvokeSync<string?>("localStorageGetItem", key);

    /// <summary>
    /// When passed a key name and value, will add that key to localStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetItem(string key, string value) => _moduleManager.InvokeSync("localStorageSetItem", key, value);

    /// <summary>
    /// When passed a key name, will remove that key from localStorage.
    /// </summary>
    /// <param name="key"></param>
    public void RemoveItem(string key) => _moduleManager.InvokeSync("localStorageRemoveItem", key);

    /// <summary>
    /// When invoked, will empty all keys out of localStorage.
    /// </summary>
    public void Clear() => _moduleManager.InvokeSync("localStorageClear");
}
