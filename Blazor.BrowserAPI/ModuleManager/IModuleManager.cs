using Microsoft.JSInterop;
using Microsoft.JSInterop.Infrastructure;

namespace BrowserAPI;

/// <summary>
/// <para>
/// The ModuleManager is responsible for the access of the JS-module at "_content/Blazor.BrowserAPI/BrowserAPI.js".<br />
/// The necessary module is lazy loaded the first time when it is needed,
/// but it also contains a method to start the module download manually.
/// </para>
/// <para>However, when *InProcess*-classes are used, the module must be loaded beforehand, otherwise an Exception is thrown.</para>
/// </summary>
public interface IModuleManager {
    /// <summary>
    /// Starts the download of the JS module. Returns a Task that represents the download of the module. If this tasks finishes, the download finishes.
    /// </summary>
    /// <returns>A Task that represents the download of the module. If this tasks finishes, the download finishes.</returns>
    public Task<IJSObjectReference> LoadModule();


    internal void InvokeSync(string identifier, object?[]? args = null) => InvokeSync<IJSVoidResult>(identifier, args);

    internal TResult InvokeSync<TResult>(string identifier, object?[]? args = null);


    internal async ValueTask InvokeTrySync(string identifier, CancellationToken cancellationToken, object?[]? args = null) => await InvokeTrySync<IJSVoidResult>(identifier, cancellationToken, args);

    internal ValueTask<TResult> InvokeTrySync<TResult>(string identifier, CancellationToken cancellationToken, object?[]? args = null);


    internal async ValueTask InvokeAsync(string identifier, CancellationToken cancellationToken, object?[]? args = null) => await InvokeAsync<IJSVoidResult>(identifier, cancellationToken, args);

    internal ValueTask<TResult> InvokeAsync<TResult>(string identifier, CancellationToken cancellationToken, object?[]? args = null);
}
