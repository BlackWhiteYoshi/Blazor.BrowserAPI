using Microsoft.JSInterop;

namespace BrowserAPI;

/// <summary>
/// <para>
/// The ModuleManager is responsible for the access of the JS-module at "_content/Blazor.BrowserAPI/BrowserAPI.js".<br />
/// It starts fetching the js file with the constructor.
/// </para>
/// <para>It contains a get-property to retrieve and observe the state of the module download.</para>
/// </summary>
internal sealed class ModuleManager : IModuleManager, IDisposable, IAsyncDisposable {
    /// <summary>
    /// A Task that represents the download of the module. If this tasks finishes, the download finishes.
    /// </summary>
    public Task<IJSObjectReference> ModuleDownload { get; }
    
    private readonly CancellationTokenSource cancellationTokenSource = new();

    public ModuleManager(IJSRuntime jsRuntime) {
        ModuleDownload = jsRuntime.InvokeAsync<IJSObjectReference>("import", cancellationTokenSource.Token, "/_content/Blazor.BrowserAPI/BrowserAPI.js").AsTask();
    }

    public void Dispose() {
        if (cancellationTokenSource.IsCancellationRequested)
            return;

        cancellationTokenSource.Cancel();
        cancellationTokenSource.Dispose();

        if (ModuleDownload.IsCompletedSuccessfully)
            _ = ModuleDownload.Result.DisposeAsync().Preserve();
    }

    public ValueTask DisposeAsync() {
        if (cancellationTokenSource.IsCancellationRequested)
            return ValueTask.CompletedTask;

        cancellationTokenSource.Cancel();
        cancellationTokenSource.Dispose();

        if (ModuleDownload.IsCompletedSuccessfully)
            return ModuleDownload.Result.DisposeAsync();
        else
            return ValueTask.CompletedTask;
    }


    TResult IModuleManager.InvokeSync<TResult>(string identifier, params object?[]? args) {
        if (!ModuleDownload.IsCompletedSuccessfully)
            throw new JSException("JS-module is not loaded yet. To make sure the module is downloaded, you can await IModuleLoader.ModuleDownload.");

        IJSInProcessObjectReference module = (IJSInProcessObjectReference)ModuleDownload.Result;
        return module.Invoke<TResult>(identifier, args);
    }

    async ValueTask<TResult> IModuleManager.InvokeTrySync<TResult>(string identifier, CancellationToken cancellationToken, params object?[]? args) {
        IJSObjectReference module = await ModuleDownload;
        return await module.InvokeTrySync<TResult>(identifier, cancellationToken, args);
    }

    async ValueTask<TResult> IModuleManager.InvokeAsync<TResult>(string identifier, CancellationToken cancellationToken, params object?[]? args) {
        IJSObjectReference module = await ModuleDownload;
        return await module.InvokeAsync<TResult>(identifier, cancellationToken, args);
    }
}
