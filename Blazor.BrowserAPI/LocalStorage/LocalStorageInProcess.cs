using AutoInterfaceAttributes;

namespace BrowserAPI.Implementation;

/// <summary>
/// The localStorage read-only property of the window interface allows you to access a Storage object for the Document's origin;<br />
/// the stored data is saved across browser sessions.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
public sealed class LocalStorageInProcess(IModuleManager moduleManager) : ILocalStorageInProcess {
    /// <summary>
    /// Returns an integer representing the number of data items stored in localStorage.
    /// </summary>
    public int Length => moduleManager.InvokeSync<int>("localStorageLength");

    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in localStorage.
    /// </summary>
    /// <param name="index">An integer representing the number of the key you want to get the name of. This is a zero-based index.</param>
    /// <returns></returns>
    public string? Key(int index) => moduleManager.InvokeSync<string?>("localStorageKey", [index]);

    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to retrieve the value of.</param>
    /// <returns></returns>
    public string? GetItem(string key) => moduleManager.InvokeSync<string?>("localStorageGetItem", [key]);

    /// <summary>
    /// When passed a key name and value, will add that key to localStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to create/update.</param>
    /// <param name="value">A string containing the value you want to give the key you are creating/updating.</param>
    public void SetItem(string key, string value) => moduleManager.InvokeSync("localStorageSetItem", [key, value]);

    /// <summary>
    /// When passed a key name, will remove that key from localStorage.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to remove.</param>
    public void RemoveItem(string key) => moduleManager.InvokeSync("localStorageRemoveItem", [key]);

    /// <summary>
    /// When invoked, will empty all keys out of localStorage.
    /// </summary>
    public void Clear() => moduleManager.InvokeSync("localStorageClear");
}
