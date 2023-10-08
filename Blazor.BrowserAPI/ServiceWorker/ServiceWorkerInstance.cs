using AutoInterfaceAttributes;
using Microsoft.JSInterop;

namespace BrowserAPI;

/// <summary>
/// The <i>ServiceWorker</i> interface of the Service Worker API provides a reference to a service worker. Multiple browsing contexts (e.g. pages, workers, etc.) can be associated with the same service worker, each through a unique ServiceWorker object.
/// </summary>
[AutoInterface(Inheritance = new[] { typeof(IAsyncDisposable) })]
internal sealed class ServiceWorkerInstance : ServiceWorkerInstanceBase, IServiceWorkerInstance {
    public ServiceWorkerInstance(IModuleManager moduleManager, IJSObjectReference serviceWorker) : base(moduleManager, serviceWorker) { }

    ValueTask IAsyncDisposable.DisposeAsync() => _serviceWorker.DisposeAsync();


    /// <summary>
    /// Returns the <i>ServiceWorker</i> serialized script URL defined as part of ServiceWorkerRegistration. The URL must be on the same origin as the document that registers the ServiceWorker.
    /// </summary>
    public ValueTask<string> ScriptUrl => GetScriptUrl(default);

    /// <summary>
    /// Returns the <i>ServiceWorker</i> serialized script URL defined as part of ServiceWorkerRegistration. The URL must be on the same origin as the document that registers the ServiceWorker.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetScriptUrl(CancellationToken cancellationToken) => _moduleManager.InvokeTrySync<string>("serviceWorkerInstanceScriptURL", cancellationToken, _serviceWorker);


    /// <summary>
    /// The state read-only property of the <i>ServiceWorker</i> interface returns a string representing the current state of the service worker. It can be one of the following values: parsed, installing, installed, activating, activated, or redundant. 
    /// </summary>
    public ValueTask<string> State => GetState(default);

    /// <summary>
    /// The state read-only property of the <i>ServiceWorker</i> interface returns a string representing the current state of the service worker. It can be one of the following values: parsed, installing, installed, activating, activated, or redundant. 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetState(CancellationToken cancellationToken) => _moduleManager.InvokeTrySync<string>("serviceWorkerInstanceState", cancellationToken, _serviceWorker);


    /// <summary>
    /// The <i>postMessage()</i> method of the ServiceWorker interface sends a message to the worker. This accepts a single parameter, which is the data to send to the worker. The data may be any JavaScript object which can be handled by the structured clone algorithm.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask PostMessage(object message, CancellationToken cancellationToken = default) => _moduleManager.InvokeTrySync("serviceWorkerInstancePostMessage", cancellationToken, _serviceWorker, message);
}
