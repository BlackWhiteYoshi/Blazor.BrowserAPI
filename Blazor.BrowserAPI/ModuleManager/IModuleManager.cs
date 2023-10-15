using Microsoft.JSInterop;
using Microsoft.JSInterop.Infrastructure;

namespace BrowserAPI;

/// <summary>
/// <para>
/// The ModuleManager is responsible for the access of the JS-module at "_content/Blazor.BrowserAPI/BrowserAPI.js".<br />
/// It starts fetching the js file with the constructor.
/// </para>
/// <para>It contains a get-property to retrieve and observe the state of the module download.</para>
/// </summary>
public interface IModuleManager {
    public Task<IJSObjectReference> ModuleDownload { get; }


    internal void InvokeSync(string identifier, params object?[]? args) => InvokeSync<IJSVoidResult>(identifier, args);

    internal TResult InvokeSync<TResult>(string identifier, params object?[]? args);


    internal async ValueTask InvokeTrySync(string identifier, CancellationToken cancellationToken, params object?[]? args) => await InvokeTrySync<IJSVoidResult>(identifier, cancellationToken, args);

    internal ValueTask<TResult> InvokeTrySync<TResult>(string identifier, CancellationToken cancellationToken, params object?[]? args);


    internal async ValueTask InvokeAsync(string identifier, CancellationToken cancellationToken, params object?[]? args) => await InvokeAsync<IJSVoidResult>(identifier, cancellationToken, args);

    internal ValueTask<TResult> InvokeAsync<TResult>(string identifier, CancellationToken cancellationToken, params object?[]? args);
}
