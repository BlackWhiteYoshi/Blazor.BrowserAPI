using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Implementation of <see cref="IModuleManager"/>.
/// </summary>
/// <param name="jsRuntime"></param>
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class ModuleManager(IJSRuntime jsRuntime) : IModuleManager, IDisposable, IAsyncDisposable {
    private readonly CancellationTokenSource cancellationTokenSource = new();
    private Task<IJSObjectReference>? moduleDownload;

    /// <summary>
    /// <para>Disposes the module synchronously if possible, otherwise asynchronously as fire and forget.</para>
    /// <para>If the download is running and not finished, the download will be aborted.</para>
    /// </summary>
    public void Dispose() {
        if (cancellationTokenSource.IsCancellationRequested)
            return;

        cancellationTokenSource.Cancel();
        cancellationTokenSource.Dispose();

        if (moduleDownload?.IsCompletedSuccessfully == true)
            _ = moduleDownload.Result.DisposeTrySync().Preserve();
    }

    /// <summary>
    /// <para>Disposes the module synchronously if possible, otherwise asynchronously.</para>
    /// <para>If the download is running and not finished, the download will be aborted.</para>
    /// </summary>
    public ValueTask DisposeAsync() {
        if (cancellationTokenSource.IsCancellationRequested)
            return ValueTask.CompletedTask;

        cancellationTokenSource.Cancel();
        cancellationTokenSource.Dispose();

        if (moduleDownload?.IsCompletedSuccessfully == true)
            return moduleDownload.Result.DisposeTrySync();
        else
            return ValueTask.CompletedTask;
    }


    /// <summary>
    /// Implementation of <see cref="IModuleManager.LoadModule"/>.
    /// </summary>
    /// <returns></returns>
    public Task<IJSObjectReference> LoadModule() => moduleDownload ??= jsRuntime.InvokeAsync<IJSObjectReference>("import", cancellationTokenSource.Token, "/_content/Blazor.BrowserAPI/BrowserAPI.js").AsTask();


    TResult IModuleManager.InvokeSync<TResult>(string identifier, object?[]? args = null) {
        Task<IJSObjectReference> moduleTask = LoadModule();
        if (!moduleTask.IsCompletedSuccessfully)
            throw new JSException("JS-module is not loaded yet. To make sure the module is downloaded, you can await IModuleLoader.ModuleDownload.");

        IJSInProcessObjectReference module = (IJSInProcessObjectReference)moduleTask.Result;
        return module.Invoke<TResult>(identifier, args);
    }

    async ValueTask<TResult> IModuleManager.InvokeTrySync<TResult>(string identifier, CancellationToken cancellationToken, object?[]? args = null) {
        IJSObjectReference module = await LoadModule();
        return await module.InvokeTrySync<TResult>(identifier, cancellationToken, args);
    }

    async ValueTask<TResult> IModuleManager.InvokeAsync<TResult>(string identifier, CancellationToken cancellationToken, object?[]? args = null) {
        IJSObjectReference module = await LoadModule();
        return await module.InvokeAsync<TResult>(identifier, cancellationToken, args);
    }
}
