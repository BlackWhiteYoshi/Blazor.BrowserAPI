﻿using AutoInterfaceAttributes;

namespace BrowserAPI.Implementation;

/// <summary>
/// The localStorage read-only property of the window interface allows you to access a Storage object for the Document's origin;<br />
/// the stored data is saved across browser sessions.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
public sealed class LocalStorage(IModuleManager moduleManager) : ILocalStorage {
    /// <summary>
    /// Returns an integer representing the number of data items stored in localStorage.
    /// </summary>
    public ValueTask<int> Length => GetLength(default);

    /// <summary>
    /// Returns an integer representing the number of data items stored in localStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetLength(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("LocalStorageAPI.count", cancellationToken);

    /// <summary>
    /// When passed a number <i>n</i>, this method will return the name of the nth key in localStorage.
    /// </summary>
    /// <param name="index">An integer representing the number of the key you want to get the name of. This is a zero-based index.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string?> Key(int index, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync<string?>("LocalStorageAPI.key", cancellationToken, [index]);

    /// <summary>
    /// When passed a key name, will return that key's value.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to retrieve the value of.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string?> GetItem(string key, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync<string?>("LocalStorageAPI.getItem", cancellationToken, [key]);

    /// <summary>
    /// When passed a key name and value, will add that key to localStorage, or update that key's value if it already exists.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to create/update.</param>
    /// <param name="value">A string containing the value you want to give the key you are creating/updating.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask SetItem(string key, string value, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("LocalStorageAPI.setItem", cancellationToken, [key, value]);

    /// <summary>
    /// When passed a key name, will remove that key from localStorage.
    /// </summary>
    /// <param name="key">A string containing the name of the key you want to remove.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask RemoveItem(string key, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("LocalStorageAPI.removeItem", cancellationToken, [key]);

    /// <summary>
    /// When invoked, will empty all keys out of localStorage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Clear(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("LocalStorageAPI.clear", cancellationToken);
}
