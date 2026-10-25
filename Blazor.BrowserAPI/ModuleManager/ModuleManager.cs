using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>
/// The ModuleManager is responsible for the access of the JS-module at "_content/Blazor.BrowserAPI/BrowserAPI.js".<br/>
/// The necessary module is lazy loaded the first time when it is needed,
/// but it also contains a method to start the module download manually.
/// </para>
/// <para>However, when *InProcess*-classes are used, the module must be loaded beforehand, otherwise an Exception is thrown.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class ModuleManager(IJSRuntime jsRuntime) : IModuleManager {
    private readonly CancellationTokenSource cancellationTokenSource = new();
    private Task<IJSObjectReference>? moduleDownload;

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
    /// Starts the download of the JS module. Returns a Task that represents the download of the module. If this Task finishes, the download finishes.<br/>
    /// The JS module is only downloaded once. When called several times, the same ongoing/finished task is returned.
    /// </summary>
    /// <returns>A Task that represents the download of the module. If this tasks finishes, the download finishes.</returns>
    public Task<IJSObjectReference> LoadModule() => moduleDownload ??= jsRuntime.InvokeAsync<IJSObjectReference>("import", cancellationTokenSource.Token, "/_content/Blazor.BrowserAPI/BrowserAPI.js").AsTask();


    /// <summary>
    /// Invokes the specified JavaScript function located inside the JS-module synchronously.
    /// </summary>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    [AutoInterfaceVisibilityInternal]
    void IModuleManager.InvokeSync(string identifier, object?[]? args = null) => InvokeSync<IJSVoidResult>(identifier, args);
    
    /// <summary>
    /// Invokes the specified JavaScript function located inside the JS-module synchronously.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns></returns>
    [AutoInterfaceVisibilityInternal]
    TResult IModuleManager.InvokeSync<TResult>(string identifier, object?[]? args = null) => InvokeSync<TResult>(identifier, args);

    private TResult InvokeSync<TResult>(string identifier, object?[]? args = null) {
        Task<IJSObjectReference> moduleTask = LoadModule();
        if (!moduleTask.IsCompletedSuccessfully)
            throw new JSException(jsRuntime switch {
                IJSInProcessRuntime => "JS-module is not loaded yet. To make sure the module is downloaded, you can await the 'IModuleManager.LoadModule' method.",
                _ => "Synchronous JS invoke is only supported in Blazor webassembly."
            });

        IJSInProcessObjectReference module = (IJSInProcessObjectReference)moduleTask.Result;
        return module.Invoke<TResult>(identifier, args);
    }

    
    /// <summary>
    /// <para>Invokes the specified JavaScript function located inside the JS-module synchronously if possible, otherwise asynchronously.</para>
    /// <para>When the specified JavaScript function returns a promise, you should use <see cref="IModuleManager.InvokeAsync(string, CancellationToken, object?[])"/> instead.</para>
    /// </summary>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns></returns>
    [AutoInterfaceVisibilityInternal]
    async ValueTask IModuleManager.InvokeTrySync(string identifier, CancellationToken cancellationToken, object?[]? args = null) => await InvokeTrySync<IJSVoidResult>(identifier, cancellationToken, args);
    
    /// <summary>
    /// <para>Invokes the specified JavaScript function located inside the JS-module synchronously if possible, otherwise asynchronously.</para>
    /// <para>When the specified JavaScript function returns a promise, you should use <see cref="IModuleManager.InvokeAsync{TResult}(string, CancellationToken, object?[])"/> instead.</para>
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns></returns>
    [AutoInterfaceVisibilityInternal]
    ValueTask<TResult> IModuleManager.InvokeTrySync<TResult>(string identifier, CancellationToken cancellationToken, object?[]? args = null) => InvokeTrySync<TResult>(identifier, cancellationToken, args);

    private async ValueTask<TResult> InvokeTrySync<TResult>(string identifier, CancellationToken cancellationToken, object?[]? args = null) {
        IJSObjectReference module = await LoadModule();
        return await module.InvokeTrySync<TResult>(identifier, cancellationToken, args);
    }


    /// <summary>
    /// Invokes the specified JavaScript function located inside the JS-module asynchronously.
    /// </summary>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns></returns>
    [AutoInterfaceVisibilityInternal]
    async ValueTask IModuleManager.InvokeAsync(string identifier, CancellationToken cancellationToken, object?[]? args = null) => await InvokeAsync<IJSVoidResult>(identifier, cancellationToken, args);

    /// <summary>
    /// Invokes the specified JavaScript function located inside the JS-module asynchronously.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns></returns>
    [AutoInterfaceVisibilityInternal]
    ValueTask<TResult> IModuleManager.InvokeAsync<TResult>(string identifier, CancellationToken cancellationToken, object?[]? args = null) => InvokeAsync<TResult>(identifier, cancellationToken, args);

    private async ValueTask<TResult> InvokeAsync<TResult>(string identifier, CancellationToken cancellationToken, object?[]? args = null) {
        IJSObjectReference module = await LoadModule();
        return await module.InvokeAsync<TResult>(identifier, cancellationToken, args);
    }
}
