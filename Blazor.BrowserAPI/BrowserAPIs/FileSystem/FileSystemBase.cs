using AutoInterfaceAttributes;
using Microsoft.JSInterop;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IFileSystem")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IFileSystemInProcess")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class FileSystemBase(IModuleManager moduleManager) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IModuleManager moduleManager = moduleManager;


    private static KeyValuePair<string, KeyValuePair<string, string[]>[]>[]? MapTypes((string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types) {
        if (types is null)
            return null;

        KeyValuePair<string, KeyValuePair<string, string[]>[]>[] result = new KeyValuePair<string, KeyValuePair<string, string[]>[]>[types.Length];
        for (int i = 0; i < result.Length; i++) {
            KeyValuePair<string, string[]>[] accept = new KeyValuePair<string, string[]>[types[i].accept.Length];
            for (int j = 0; j < accept.Length; j++) {
                string[] fileExtensions = new string[types[i].accept[j].fileExtensions.Length];
                for (int k = 0; k < fileExtensions.Length; k++)
                    fileExtensions[k] = types[i].accept[j].fileExtensions[k];

                accept[j] = new KeyValuePair<string, string[]>(types[i].accept[j].MIMEtype, fileExtensions);
            }

            result[i] = new KeyValuePair<string, KeyValuePair<string, string[]>[]>(types[i].description, accept);
        }

        return result;
    }

    private protected ValueTask<IJSObjectReference> ShowOpenFilePickerBase(string? id, PickerDialogStartIn startIn, bool excludeAcceptAllOption, (string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types, CancellationToken cancellationToken)
        => moduleManager.InvokeAsync<IJSObjectReference>("FileSystemAPI.showOpenFilePicker", cancellationToken, [id, startIn.WellKnownDirectoryOrFileHandle, excludeAcceptAllOption, MapTypes(types)]);

    private protected ValueTask<IJSObjectReference[]> ShowOpenFilePickerMultipleFilesBase(string? id, PickerDialogStartIn startIn, bool excludeAcceptAllOption, (string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types, CancellationToken cancellationToken)
        => moduleManager.InvokeAsync<IJSObjectReference[]>("FileSystemAPI.showOpenFilePickerMultipleFiles", cancellationToken, [id, startIn.WellKnownDirectoryOrFileHandle, excludeAcceptAllOption, MapTypes(types)]);

    private protected ValueTask<IJSObjectReference> ShowSaveFilePickerBase(string? suggestedName, string? id, PickerDialogStartIn startIn, bool excludeAcceptAllOption, (string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types, CancellationToken cancellationToken)
        => moduleManager.InvokeAsync<IJSObjectReference>("FileSystemAPI.showSaveFilePicker", cancellationToken, [suggestedName, id, startIn.WellKnownDirectoryOrFileHandle, excludeAcceptAllOption, MapTypes(types)]);

    private protected ValueTask<IJSObjectReference> ShowDirectoryPickerBase(string mode, string? id, PickerDialogStartIn startIn, CancellationToken cancellationToken)
        => moduleManager.InvokeAsync<IJSObjectReference>("FileSystemAPI.showDirectoryPicker", cancellationToken, [mode, id, startIn.WellKnownDirectoryOrFileHandle]);


    private readonly record struct Estimate(long? Usage, long? Quota);

    /// <summary>
    /// <para>Asks the Storage Manager for how much storage the current origin takes up (usage), and how much space is available (quota).</para>
    /// <para>This method operates asynchronously, so it returns a Promise which resolves once the information is available. The promise's fulfillment handler is called with an object containing the usage and quota data.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<(long? usage, long? quota)> StorageManagerEstimate(CancellationToken cancellationToken = default) {
        Estimate estimate = await moduleManager.InvokeAsync<Estimate>("FileSystemAPI.storageManagerEstimate", cancellationToken);
        return (estimate.Usage, estimate.Quota);
    }

    /// <summary>
    /// Requests permission to use persistent storage, and returns a Promise that resolves to true if permission is granted and bucket mode is persistent, and false otherwise.
    /// The browser may or may not honor the request, depending on browser-specific rules.
    /// (For more details, see the guide to <see href="https://developer.mozilla.org/en-US/docs/Web/API/Storage_API/Storage_quotas_and_eviction_criteria#does_browser-stored_data_persist">Storage quotas and eviction criteria</see>.)
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> StorageManagerPersist(CancellationToken cancellationToken = default) => moduleManager.InvokeAsync<bool>("FileSystemAPI.storageManagerPersist", cancellationToken);

    /// <summary>
    /// Returns a Promise that resolves to true if your site's storage bucket is persistent.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> StorageManagerPersisted(CancellationToken cancellationToken = default) => moduleManager.InvokeAsync<bool>("FileSystemAPI.storageManagerPersisted", cancellationToken);

    private protected ValueTask<IJSObjectReference> StorageManagerGetDirectoryBase(CancellationToken cancellationToken)
        => moduleManager.InvokeAsync<IJSObjectReference>("FileSystemAPI.storageManagerGetDirectory", cancellationToken);
}
