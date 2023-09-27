using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Infrastructure;

namespace BrowserAPI;

/// <summary>
/// Contains a get-property to retrieve and observe the state of the module download.
/// </summary>
[AutoInterface(Name = "IModuleLoader")]
public sealed partial class BrowserAPICore : IModuleLoader, IDisposable, IAsyncDisposable {
    #region construction

    /// <summary>
    /// A Task that represents the download of the module. If this tasks finishes, the download finishes.
    /// </summary>
    public Task<IJSObjectReference> ModuleDownload { get; }
    private readonly CancellationTokenSource cancellationTokenSource = new();

    public BrowserAPICore(IJSRuntime jsRuntime) {
        ModuleDownload = jsRuntime.InvokeAsync<IJSObjectReference>("import", cancellationTokenSource.Token, "/_content/Blazor.BrowserAPI/BrowserAPI.js").AsTask();
    }

    [IgnoreAutoInterface]
    public void Dispose() {
        if (cancellationTokenSource.IsCancellationRequested)
            return;

        cancellationTokenSource.Cancel();
        cancellationTokenSource.Dispose();

        if (ModuleDownload.IsCompletedSuccessfully)
            _ = ModuleDownload.Result.DisposeAsync().Preserve();
    }

    [IgnoreAutoInterface]
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

    #endregion


    #region invoke methods

    private void InvokeSync(string identifier, params object?[]? args) => InvokeSync<IJSVoidResult>(identifier, args);

    private TResult InvokeSync<TResult>(string identifier, params object?[]? args) {
        if (!ModuleDownload.IsCompletedSuccessfully)
            throw new JSException("JS-module is not loaded yet. To make sure the module is downloaded, you can await IModuleLoader.ModuleDownload.");

        IJSInProcessObjectReference module = (IJSInProcessObjectReference)ModuleDownload.Result;
        return module.Invoke<TResult>(identifier, args);
    }


    private async ValueTask InvokeTrySync(string identifier, CancellationToken cancellationToken, params object?[]? args) => await InvokeTrySync<IJSVoidResult>(identifier, cancellationToken, args);

    private async ValueTask<TResult> InvokeTrySync<TResult>(string identifier, CancellationToken cancellationToken, params object?[]? args) {
        IJSObjectReference module = await ModuleDownload;
        if (module is IJSInProcessObjectReference moduleInProcess)
            return moduleInProcess.Invoke<TResult>(identifier, args);
        else
            return await module.InvokeAsync<TResult>(identifier, cancellationToken, args);
    }


    private async ValueTask InvokeAsync(string identifier, CancellationToken cancellationToken, params object?[]? args) => await InvokeAsync<IJSVoidResult>(identifier, cancellationToken, args);

    private async ValueTask<TResult> InvokeAsync<TResult>(string identifier, CancellationToken cancellationToken, params object?[]? args) {
        IJSObjectReference module = await ModuleDownload;
        return await module.InvokeAsync<TResult>(identifier, cancellationToken, args);
    }

    #endregion
}
