using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading;

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
    public static ValueTask InvokeVoidTrySync(this IJSRuntime jsRuntime, string identifier, params object?[]? args) => jsRuntime.InvokeVoidTrySync(identifier, CancellationToken.None, args);

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
    /// <param name="jsRuntime">Represents an instance of a JavaScript runtime to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="timeout">The duration after which to cancel the async operation. Overrides default timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>).</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns></returns>
    public static async ValueTask InvokeVoidTrySync(this IJSRuntime jsRuntime, string identifier, TimeSpan timeout, params object?[]? args)
        => await jsRuntime.InvokeTrySync<Microsoft.JSInterop.Infrastructure.IJSVoidResult>(identifier, timeout, args);


    /// <summary>
    /// <para>Invokes the specified JavaScript function synchronously if possible, otherwise asynchronously.</para>
    /// <para>When the specified JavaScript function returns a promise, you should use <see cref="IJSRuntime.InvokeAsync{TValue}(string, object?[])"/> instead.</para>
    /// </summary>
    /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
    /// <param name="jsRuntime">Represents an instance of a JavaScript runtime to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns>An instance of <typeparamref name="TValue"/> obtained by JSON-deserializing the return value.</returns>
    public static ValueTask<TValue> InvokeTrySync<TValue>(this IJSRuntime jsRuntime, string identifier, params object?[]? args) => jsRuntime.InvokeTrySync<TValue>(identifier, CancellationToken.None, args);

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
    /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
    /// <param name="jsRuntime">Represents an instance of a JavaScript runtime to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="timeout">The duration after which to cancel the async operation. Overrides default timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>).</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns></returns>
    public static ValueTask<TValue> InvokTrySync<TValue>(this IJSRuntime jsRuntime, string identifier, TimeSpan timeout, params object?[]? args) {
        if (jsRuntime is IJSInProcessRuntime jsInProcessRuntime)
            return ValueTask.FromResult(jsInProcessRuntime.Invoke<TValue>(identifier, args));
        else
            return jsRuntime.InvokeAsync<TValue>(identifier, timeout, args);
    }


#if NET10_0_OR_GREATER

    /// <summary>
    /// Invokes the specified JavaScript constructor function synchronously if possible, otherwise asynchronously. The function is invoked with the <c>new</c> operator.
    /// </summary>
    /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
    /// <param name="identifier">An identifier for the constructor function to invoke. For example, the value <c>"someScope.SomeClass"</c> will invoke the constructor <c>window.someScope.SomeClass</c>.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns>An <see cref="IJSObjectReference"/> instance that represents the created JS object.</returns>
    public static ValueTask<IJSObjectReference> InvokeConstructorTrySync(this IJSRuntime jsRuntime, string identifier, params object?[]? args) => jsRuntime.InvokeConstructorTrySync(identifier, CancellationToken.None, args);

    /// <summary>
    /// Invokes the specified JavaScript constructor function synchronously if possible, otherwise asynchronously. The function is invoked with the <c>new</c> operator.
    /// </summary>
    /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
    /// <param name="identifier">An identifier for the constructor function to invoke. For example, the value <c>"someScope.SomeClass"</c> will invoke the constructor <c>window.someScope.SomeClass</c>.</param>
    /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns>An <see cref="IJSObjectReference"/> instance that represents the created JS object.</returns>
    public static ValueTask<IJSObjectReference> InvokeConstructorTrySync(this IJSRuntime jsRuntime, string identifier, CancellationToken cancellationToken, params object?[]? args) {
        if (jsRuntime is IJSInProcessRuntime jsInProcessRuntime)
            return ValueTask.FromResult((IJSObjectReference)jsInProcessRuntime.InvokeConstructor(identifier, args));
        else
            return jsRuntime.InvokeConstructorAsync(identifier, cancellationToken, args);
    }

    /// <summary>
    /// Invokes the specified JavaScript constructor function synchronously if possible, otherwise asynchronously. The function is invoked with the <c>new</c> operator.
    /// </summary>
    /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
    /// <param name="identifier">An identifier for the constructor function to invoke. For example, the value <c>"someScope.SomeClass"</c> will invoke the constructor <c>window.someScope.SomeClass</c>.</param>
    /// <param name="timeout">The duration after which to cancel the async operation. Overrides default timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>).</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns>An <see cref="IJSObjectReference"/> instance that represents the created JS object.</returns>
    public static ValueTask<IJSObjectReference> InvokeConstructorTrySync(this IJSRuntime jsRuntime, string identifier, TimeSpan timeout, params object?[]? args) {
        if (jsRuntime is IJSInProcessRuntime jsInProcessRuntime)
            return ValueTask.FromResult((IJSObjectReference)jsInProcessRuntime.InvokeConstructor(identifier, args));
        else
            return jsRuntime.InvokeConstructorAsync(identifier, timeout, args);
    }


    /// <summary>
    /// Reads the value of the specified JavaScript property synchronously if possible, otherwise asynchronously.
    /// </summary>
    /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
    /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
    /// <param name="identifier">An identifier for the property to read. For example, the value <c>"someScope.someProp"</c> will read the value of the property <c>window.someScope.someProp</c>.</param>
    /// <returns>An instance of <typeparamref name="TValue"/> obtained by JSON-deserializing the return value.</returns>
    public static ValueTask<TValue> GetValueTrySync<TValue>(this IJSRuntime jsRuntime, string identifier) => jsRuntime.GetValueTrySync<TValue>(identifier, CancellationToken.None);

    /// <summary>
    /// Reads the value of the specified JavaScript property synchronously if possible, otherwise asynchronously.
    /// </summary>
    /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
    /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
    /// <param name="identifier">An identifier for the property to read. For example, the value <c>"someScope.someProp"</c> will read the value of the property <c>window.someScope.someProp</c>.</param>
    /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.</param>
    /// <returns>An instance of <typeparamref name="TValue"/> obtained by JSON-deserializing the return value.</returns>
    public static ValueTask<TValue> GetValueTrySync<TValue>(this IJSRuntime jsRuntime, string identifier, CancellationToken cancellationToken) {
        if (jsRuntime is IJSInProcessRuntime jsInProcessRuntime)
            return ValueTask.FromResult(jsInProcessRuntime.GetValue<TValue>(identifier));
        else
            return jsRuntime.GetValueAsync<TValue>(identifier, cancellationToken);
    }

    /// <summary>
    /// Reads the value of the specified JavaScript property synchronously if possible, otherwise asynchronously.
    /// </summary>
    /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
    /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
    /// <param name="identifier">An identifier for the property to read. For example, the value <c>"someScope.someProp"</c> will read the value of the property <c>window.someScope.someProp</c>.</param>
    /// <param name="timeout">The duration after which to cancel the async operation. Overrides default timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>).</param>
    /// <returns>An instance of <typeparamref name="TValue"/> obtained by JSON-deserializing the return value.</returns>
    public static ValueTask<TValue> GetValueTrySync<TValue>(this IJSRuntime jsRuntime, string identifier, TimeSpan timeout) {
        if (jsRuntime is IJSInProcessRuntime jsInProcessRuntime)
            return ValueTask.FromResult(jsInProcessRuntime.GetValue<TValue>(identifier));
        else
            return jsRuntime.GetValueAsync<TValue>(identifier, timeout);
    }


    /// <summary>
    /// Updates the value of the specified JavaScript property synchronously if possible, otherwise asynchronously.. If the property is not defined on the target object, it will be created.
    /// </summary>
    /// <typeparam name="TValue">JSON-serializable argument type.</typeparam>
    /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
    /// <param name="identifier">An identifier for the property to set. For example, the value <c>"someScope.someProp"</c> will update the property <c>window.someScope.someProp</c>.</param>
    /// <param name="value">JSON-serializable value.</param>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous invocation operation.</returns>
    public static ValueTask SetValueTrySync<TValue>(this IJSRuntime jsRuntime, string identifier, TValue value) => jsRuntime.SetValueTrySync(identifier, value, CancellationToken.None);

    /// <summary>
    /// Updates the value of the specified JavaScript property synchronously if possible, otherwise asynchronously.. If the property is not defined on the target object, it will be created.
    /// </summary>
    /// <typeparam name="TValue">JSON-serializable argument type.</typeparam>
    /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
    /// <param name="identifier">An identifier for the property to set. For example, the value <c>"someScope.someProp"</c> will update the property <c>window.someScope.someProp</c>.</param>
    /// <param name="value">JSON-serializable value.</param>
    /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.</param>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous invocation operation.</returns>
    public static ValueTask SetValueTrySync<TValue>(this IJSRuntime jsRuntime, string identifier, TValue value, CancellationToken cancellationToken) {
        if (jsRuntime is IJSInProcessRuntime jsInProcessRuntime) {
            jsInProcessRuntime.SetValue(identifier, value);
            return ValueTask.CompletedTask;
        }
        else
            return jsRuntime.SetValueAsync(identifier, value, cancellationToken);
    }

    /// <summary>
    /// Updates the value of the specified JavaScript property synchronously if possible, otherwise asynchronously.. If the property is not defined on the target object, it will be created.
    /// </summary>
    /// <typeparam name="TValue">JSON-serializable argument type.</typeparam>
    /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
    /// <param name="identifier">An identifier for the property to set. For example, the value <c>"someScope.someProp"</c> will update the property <c>window.someScope.someProp</c>.</param>
    /// <param name="value">JSON-serializable value.</param>
    /// <param name="timeout">The duration after which to cancel the async operation. Overrides default timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>).</param>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous invocation operation.</returns>
    public static ValueTask SetValueTrySync<TValue>(this IJSRuntime jsRuntime, string identifier, TValue value, TimeSpan timeout) {
        if (jsRuntime is IJSInProcessRuntime jsInProcessRuntime) {
            jsInProcessRuntime.SetValue(identifier, value);
            return ValueTask.CompletedTask;
        }
        else
            return jsRuntime.SetValueAsync(identifier, value, timeout);
    }
#endif


    /// <summary>
    /// <para>Invokes the specified JavaScript function synchronously if possible, otherwise asynchronously.</para>
    /// <para>When the specified JavaScript function returns a promise, you should use <see cref="IJSRuntime.InvokeAsync{TValue}(string, object?[])"/> instead.</para>
    /// </summary>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns></returns>
    public static ValueTask InvokeVoidTrySync(this IJSObjectReference module, string identifier, params object?[]? args) => module.InvokeVoidTrySync(identifier, CancellationToken.None, args);

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
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="timeout">The duration after which to cancel the async operation. Overrides default timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>).</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns></returns>
    public static async ValueTask InvokeVoidTrySync(this IJSObjectReference module, string identifier, TimeSpan timeout, params object?[]? args)
        => await module.InvokeTrySync<Microsoft.JSInterop.Infrastructure.IJSVoidResult>(identifier, timeout, args);


    /// <summary>
    /// <para>Invokes the specified JavaScript function synchronously if possible, otherwise asynchronously.</para>
    /// <para>When the specified JavaScript function returns a promise, you should use <see cref="IJSRuntime.InvokeAsync{TValue}(string, object?[])"/> instead.</para>
    /// </summary>
    /// <typeparam name="TResult">The JSON-serializable return type.</typeparam>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> obtained by JSON-deserializing the return value.</returns>
    public static ValueTask<TResult> InvokeTrySync<TResult>(this IJSObjectReference module, string identifier, params object?[]? args) => module.InvokeTrySync<TResult>(identifier, CancellationToken.None, args);

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
    /// <para>Invokes the specified JavaScript function synchronously if possible, otherwise asynchronously.</para>
    /// <para>When the specified JavaScript function returns a promise, you should use <see cref="IJSRuntime.InvokeAsync{TValue}(string, object?[])"/> instead.</para>
    /// </summary>
    /// <typeparam name="TResult">The JSON-serializable return type.</typeparam>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
    /// <param name="timeout">The duration after which to cancel the async operation. Overrides default timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>).</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> obtained by JSON-deserializing the return value.</returns>
    public static ValueTask<TResult> InvokeTrySync<TResult>(this IJSObjectReference module, string identifier, TimeSpan timeout, params object?[]? args) {
        if (module is IJSInProcessObjectReference moduleInProcess)
            return ValueTask.FromResult(moduleInProcess.Invoke<TResult>(identifier, args));
        else
            return module.InvokeAsync<TResult>(identifier, timeout, args);
    }


#if NET10_0_OR_GREATER

    /// <summary>
    /// Invokes the specified JavaScript constructor function synchronously if possible, otherwise asynchronously. The function is invoked with the <c>new</c> operator.
    /// </summary>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the constructor function to invoke. For example, the value <c>"someScope.SomeClass"</c> will invoke the constructor <c>window.someScope.SomeClass</c>.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns>An <see cref="IJSObjectReference"/> instance that represents the created JS object.</returns>
    public static ValueTask<IJSObjectReference> InvokeConstructorTrySync(this IJSObjectReference module, string identifier, params object?[]? args) => module.InvokeConstructorTrySync(identifier, CancellationToken.None, args);

    /// <summary>
    /// Invokes the specified JavaScript constructor function synchronously if possible, otherwise asynchronously. The function is invoked with the <c>new</c> operator.
    /// </summary>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the constructor function to invoke. For example, the value <c>"someScope.SomeClass"</c> will invoke the constructor <c>window.someScope.SomeClass</c>.</param>
    /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns>An <see cref="IJSObjectReference"/> instance that represents the created JS object.</returns>
    public static ValueTask<IJSObjectReference> InvokeConstructorTrySync(this IJSObjectReference module, string identifier, CancellationToken cancellationToken, params object?[]? args) {
        if (module is IJSInProcessObjectReference moduleInProcess)
            return ValueTask.FromResult((IJSObjectReference)moduleInProcess.InvokeConstructor(identifier, args));
        else
            return module.InvokeConstructorAsync(identifier, cancellationToken, args);
    }

    /// <summary>
    /// Invokes the specified JavaScript constructor function synchronously if possible, otherwise asynchronously. The function is invoked with the <c>new</c> operator.
    /// </summary>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the constructor function to invoke. For example, the value <c>"someScope.SomeClass"</c> will invoke the constructor <c>window.someScope.SomeClass</c>.</param>
    /// <param name="timeout">The duration after which to cancel the async operation. Overrides default timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>).</param>
    /// <param name="args">JSON-serializable arguments.</param>
    /// <returns>An <see cref="IJSObjectReference"/> instance that represents the created JS object.</returns>
    public static ValueTask<IJSObjectReference> InvokeConstructorTrySync(this IJSObjectReference module, string identifier, TimeSpan timeout, params object?[]? args) {
        if (module is IJSInProcessObjectReference moduleInProcess)
            return ValueTask.FromResult((IJSObjectReference)moduleInProcess.InvokeConstructor(identifier, args));
        else
            return module.InvokeConstructorAsync(identifier, timeout, args);
    }


    /// <summary>
    /// Reads the value of the specified JavaScript property synchronously if possible, otherwise asynchronously.
    /// </summary>
    /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the property to read. For example, the value <c>"someScope.someProp"</c> will read the value of the property <c>window.someScope.someProp</c>.</param>
    /// <returns>An instance of <typeparamref name="TValue"/> obtained by JSON-deserializing the return value.</returns>
    public static ValueTask<TValue> GetValueTrySync<TValue>(this IJSObjectReference module, string identifier) => module.GetValueTrySync<TValue>(identifier, CancellationToken.None);

    /// <summary>
    /// Reads the value of the specified JavaScript property synchronously if possible, otherwise asynchronously.
    /// </summary>
    /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the property to read. For example, the value <c>"someScope.someProp"</c> will read the value of the property <c>window.someScope.someProp</c>.</param>
    /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.</param>
    /// <returns>An instance of <typeparamref name="TValue"/> obtained by JSON-deserializing the return value.</returns>
    public static ValueTask<TValue> GetValueTrySync<TValue>(this IJSObjectReference module, string identifier, CancellationToken cancellationToken) {
        if (module is IJSInProcessObjectReference moduleInProcess)
            return ValueTask.FromResult(moduleInProcess.GetValue<TValue>(identifier));
        else
            return module.GetValueAsync<TValue>(identifier, cancellationToken);
    }

    /// <summary>
    /// Reads the value of the specified JavaScript property synchronously if possible, otherwise asynchronously.
    /// </summary>
    /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the property to read. For example, the value <c>"someScope.someProp"</c> will read the value of the property <c>window.someScope.someProp</c>.</param>
    /// <param name="timeout">The duration after which to cancel the async operation. Overrides default timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>).</param>
    /// <returns>An instance of <typeparamref name="TValue"/> obtained by JSON-deserializing the return value.</returns>
    public static ValueTask<TValue> GetValueTrySync<TValue>(this IJSObjectReference module, string identifier, TimeSpan timeout) {
        if (module is IJSInProcessObjectReference moduleInProcess)
            return ValueTask.FromResult(moduleInProcess.GetValue<TValue>(identifier));
        else
            return module.GetValueAsync<TValue>(identifier, timeout);
    }


    /// <summary>
    /// Updates the value of the specified JavaScript property synchronously if possible, otherwise asynchronously.. If the property is not defined on the target object, it will be created.
    /// </summary>
    /// <typeparam name="TValue">JSON-serializable argument type.</typeparam>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the property to set. For example, the value <c>"someScope.someProp"</c> will update the property <c>window.someScope.someProp</c>.</param>
    /// <param name="value">JSON-serializable value.</param>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous invocation operation.</returns>
    public static ValueTask SetValueTrySync<TValue>(this IJSObjectReference module, string identifier, TValue value) => module.SetValueTrySync(identifier, value, CancellationToken.None);

    /// <summary>
    /// Updates the value of the specified JavaScript property synchronously if possible, otherwise asynchronously.. If the property is not defined on the target object, it will be created.
    /// </summary>
    /// <typeparam name="TValue">JSON-serializable argument type.</typeparam>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the property to set. For example, the value <c>"someScope.someProp"</c> will update the property <c>window.someScope.someProp</c>.</param>
    /// <param name="value">JSON-serializable value.</param>
    /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.</param>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous invocation operation.</returns>
    public static ValueTask SetValueTrySync<TValue>(this IJSObjectReference module, string identifier, TValue value, CancellationToken cancellationToken) {
        if (module is IJSInProcessObjectReference moduleInProcess) {
            moduleInProcess.SetValue(identifier, value);
            return ValueTask.CompletedTask;
        }
        else
            return module.SetValueAsync(identifier, value, cancellationToken);
    }

    /// <summary>
    /// Updates the value of the specified JavaScript property synchronously if possible, otherwise asynchronously.. If the property is not defined on the target object, it will be created.
    /// </summary>
    /// <typeparam name="TValue">JSON-serializable argument type.</typeparam>
    /// <param name="module">Represents an instance of a JavaScript module to which calls may be dispatched.</param>
    /// <param name="identifier">An identifier for the property to set. For example, the value <c>"someScope.someProp"</c> will update the property <c>window.someScope.someProp</c>.</param>
    /// <param name="value">JSON-serializable value.</param>
    /// <param name="timeout">The duration after which to cancel the async operation. Overrides default timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>).</param>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous invocation operation.</returns>
    public static ValueTask SetValueTrySync<TValue>(this IJSObjectReference module, string identifier, TValue value, TimeSpan timeout) {
        if (module is IJSInProcessObjectReference moduleInProcess) {
            moduleInProcess.SetValue(identifier, value);
            return ValueTask.CompletedTask;
        }
        else
            return module.SetValueAsync(identifier, value, timeout);
    }
#endif


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
