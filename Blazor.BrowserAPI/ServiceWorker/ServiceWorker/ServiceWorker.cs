using AutoInterfaceAttributes;
using Microsoft.JSInterop;

namespace BrowserAPI;

[AutoInterface(Modifier = "public partial", Inheritance = new[] { typeof(IAsyncDisposable) })]
internal sealed class ServiceWorker : ServiceWorkerBase, IServiceWorker {
    protected override IJSObjectReference ServiceWorkerJS { get; }

    public ServiceWorker(IJSObjectReference serviceWorker) {
        ServiceWorkerJS = serviceWorker;
    }

    ValueTask IAsyncDisposable.DisposeAsync() => ServiceWorkerJS.DisposeAsync();


    /// <summary>
    /// Returns the <i>ServiceWorker</i> serialized script URL defined as part of ServiceWorkerRegistration. The URL must be on the same origin as the document that registers the ServiceWorker.
    /// </summary>
    public ValueTask<string> ScriptUrl => GetScriptUrl(default);

    /// <summary>
    /// Returns the <i>ServiceWorker</i> serialized script URL defined as part of ServiceWorkerRegistration. The URL must be on the same origin as the document that registers the ServiceWorker.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetScriptUrl(CancellationToken cancellationToken) => ServiceWorkerJS.InvokeTrySync<string>("scriptURL", cancellationToken);


    /// <summary>
    /// The state read-only property of the <i>ServiceWorker</i> interface returns a string representing the current state of the service worker. It can be one of the following values: parsed, installing, installed, activating, activated, or redundant.
    /// </summary>
    public ValueTask<string> State => GetState(default);

    /// <summary>
    /// The state read-only property of the <i>ServiceWorker</i> interface returns a string representing the current state of the service worker. It can be one of the following values: parsed, installing, installed, activating, activated, or redundant.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetState(CancellationToken cancellationToken) => ServiceWorkerJS.InvokeTrySync<string>("state", cancellationToken);


    /// <summary>
    /// The <i>postMessage()</i> method of the ServiceWorker interface sends a message to the worker. This accepts a single parameter, which is the data to send to the worker. The data may be any JavaScript object which can be handled by the structured clone algorithm.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask PostMessage(object message, CancellationToken cancellationToken = default) => ServiceWorkerJS.InvokeVoidTrySync("postMessage", cancellationToken, message);
}
