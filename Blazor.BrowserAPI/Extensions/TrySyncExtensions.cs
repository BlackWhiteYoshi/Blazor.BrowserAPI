using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

/// <summary>
/// <para>Extensions for <see cref="IJSRuntime"/> and <see cref="IJSObjectReference"/>.</para>
/// <para>This class contains <i>TrySync</i>-methods, which will use <see cref="IJSInProcessRuntime.Invoke{TResult}(string, object?[])"/> if possible, otherwise <see cref="IJSRuntime.InvokeAsync{TResult}(string, object?[])"/>.</para>
/// </summary>
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public static class TrySyncExtensions {
    /// <summary>
    /// <para>Invokes the specified JavaScript function synchronously if possible, otherwise asynchronously.</para>
    /// <para>When the specified JavaScript function returns a promise, you should use <see cref="IJSRuntime.InvokeAsync{TValue}(string, object?[])"/> instead.</para>
    /// </summary>
    /// <param name="jsRuntime">Represents an instance of a JavaScript runtime to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns></returns>
    public static ValueTask InvokeVoidTrySync(this IJSRuntime jsRuntime, string identifier, params object?[]? args) => jsRuntime.InvokeVoidTrySync(identifier, default, args);

    /// <summary>
    /// <para>Invokes the specified JavaScript function synchronously if possible, otherwise asynchronously.</para>
    /// <para>When the specified JavaScript function returns a promise, you should use <see cref="IJSRuntime.InvokeAsync{TValue}(string, object?[])"/> instead.</para>
    /// </summary>
    /// <param name="jsRuntime">Represents an instance of a JavaScript runtime to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns></returns>
    public static async ValueTask InvokeVoidTrySync(this IJSRuntime jsRuntime, string identifier, CancellationToken cancellationToken, params object?[]? args)
        => await jsRuntime.InvokeTrySync<Microsoft.JSInterop.Infrastructure.IJSVoidResult>(identifier, cancellationToken, args);


    /// <summary>
    /// <para>Invokes the specified JavaScript function synchronously if possible, otherwise asynchronously.</para>
    /// <para>When the specified JavaScript function returns a promise, you should use <see cref="IJSRuntime.InvokeAsync{TValue}(string, object?[])"/> instead.</para>
    /// </summary>
    /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
    /// <param name="jsRuntime">Represents an instance of a JavaScript runtime to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns>An instance of <typeparamref name="TValue"/> obtained by JSON-deserializing the return value.</returns>
    public static ValueTask<TValue> InvokeTrySync<TValue>(this IJSRuntime jsRuntime, string identifier, params object?[]? args) => jsRuntime.InvokeTrySync<TValue>(identifier, default, args);

    /// <summary>
    /// <para>Invokes the specified JavaScript function synchronously if possible, otherwise asynchronously.</para>
    /// <para>When the specified JavaScript function returns a promise, you should use <see cref="IJSRuntime.InvokeAsync{TValue}(string, object?[])"/> instead.</para>
    /// </summary>
    /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
    /// <param name="jsRuntime">Represents an instance of a JavaScript runtime to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns>An instance of <typeparamref name="TValue"/> obtained by JSON-deserializing the return value.</returns>
    public static ValueTask<TValue> InvokeTrySync<TValue>(this IJSRuntime jsRuntime, string identifier, CancellationToken cancellationToken, params object?[]? args) {
        if (jsRuntime is IJSInProcessRuntime jsInProcessRuntime)
            return ValueTask.FromResult(jsInProcessRuntime.Invoke<TValue>(identifier, args));
        else
            return jsRuntime.InvokeAsync<TValue>(identifier, cancellationToken, args);
    }



    /// <summary>
    /// <para>Invokes the specified JavaScript function synchronously if possible, otherwise asynchronously.</para>
    /// <para>When the specified JavaScript function returns a promise, you should use <see cref="IJSRuntime.InvokeAsync{TValue}(string, object?[])"/> instead.</para>
    /// </summary>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns></returns>
    public static ValueTask InvokeVoidTrySync(this IJSObjectReference module, string identifier, params object?[]? args) => module.InvokeVoidTrySync(identifier, default, args);

    /// <summary>
    /// <para>Invokes the specified JavaScript function synchronously if possible, otherwise asynchronously.</para>
    /// <para>When the specified JavaScript function returns a promise, you should use <see cref="IJSRuntime.InvokeAsync{TValue}(string, object?[])"/> instead.</para>
    /// </summary>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns></returns>
    public static async ValueTask InvokeVoidTrySync(this IJSObjectReference module, string identifier, CancellationToken cancellationToken, params object?[]? args)
        => await module.InvokeTrySync<Microsoft.JSInterop.Infrastructure.IJSVoidResult>(identifier, cancellationToken, args);


    /// <summary>
    /// <para>Invokes the specified JavaScript function synchronously if possible, otherwise asynchronously.</para>
    /// <para>When the specified JavaScript function returns a promise, you should use <see cref="IJSRuntime.InvokeAsync{TValue}(string, object?[])"/> instead.</para>
    /// </summary>
    /// <typeparam name="TResult">The JSON-serializable return type.</typeparam>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> obtained by JSON-deserializing the return value.</returns>
    public static ValueTask<TResult> InvokeTrySync<TResult>(this IJSObjectReference module, string identifier, params object?[]? args) => module.InvokeTrySync<TResult>(identifier, default, args);

    /// <summary>
    /// <para>Invokes the specified JavaScript function synchronously if possible, otherwise asynchronously.</para>
    /// <para>When the specified JavaScript function returns a promise, you should use <see cref="IJSRuntime.InvokeAsync{TValue}(string, object?[])"/> instead.</para>
    /// </summary>
    /// <typeparam name="TResult">The JSON-serializable return type.</typeparam>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> obtained by JSON-deserializing the return value.</returns>
    public static ValueTask<TResult> InvokeTrySync<TResult>(this IJSObjectReference module, string identifier, CancellationToken cancellationToken, params object?[]? args) {
        if (module is IJSInProcessObjectReference moduleInProcess)
            return ValueTask.FromResult(moduleInProcess.Invoke<TResult>(identifier, args));
        else
            return module.InvokeAsync<TResult>(identifier, cancellationToken, args);
    }


    /// <summary>
    /// Invokes Dispose if possible, otherwise DisposeAsync.
    /// </summary>
    /// <param name="module"></param>
    /// <returns></returns>
    public static ValueTask DisposeTrySync(this IJSObjectReference module) {
        if (module is IJSInProcessObjectReference moduleInProcess) {
            moduleInProcess.Dispose();
            return ValueTask.CompletedTask;
        }
        else
            return module.DisposeAsync();
    }
}
