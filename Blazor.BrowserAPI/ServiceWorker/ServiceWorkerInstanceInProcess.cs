using AutoInterfaceAttributes;
using Microsoft.JSInterop;

namespace BrowserAPI;

/// <summary>
/// The <i>ServiceWorker</i> interface of the Service Worker API provides a reference to a service worker. Multiple browsing contexts (e.g. pages, workers, etc.) can be associated with the same service worker, each through a unique ServiceWorker object.
/// </summary>
[AutoInterface(Inheritance = new[] { typeof(IDisposable) })]
internal sealed class ServiceWorkerInstanceInProcess : ServiceWorkerInstanceBase, IServiceWorkerInstanceInProcess {
    private new readonly IJSInProcessObjectReference _serviceWorker; 
    
    public ServiceWorkerInstanceInProcess(IModuleManager moduleManager, IJSInProcessObjectReference serviceWorker) : base(moduleManager, serviceWorker) {
        _serviceWorker = serviceWorker;
    }

    void IDisposable.Dispose() => _serviceWorker.Dispose();


    /// <summary>
    /// Returns the <i>ServiceWorker</i> serialized script URL defined as part of ServiceWorkerRegistration. The URL must be on the same origin as the document that registers the ServiceWorker.
    /// </summary>
    public string ScriptUrl => _moduleManager.InvokeSync<string>("serviceWorkerInstanceScriptURL", _serviceWorker);

    /// <summary>
    /// The state read-only property of the <i>ServiceWorker</i> interface returns a string representing the current state of the service worker. It can be one of the following values: parsed, installing, installed, activating, activated, or redundant. 
    /// </summary>
    public string State => _moduleManager.InvokeSync<string>("serviceWorkerInstanceState", _serviceWorker);

    /// <summary>
    /// The <i>postMessage()</i> method of the ServiceWorker interface sends a message to the worker. This accepts a single parameter, which is the data to send to the worker. The data may be any JavaScript object which can be handled by the structured clone algorithm.
    /// </summary>
    /// <param name="message"></param>
    public void PostMessage(object message) => _moduleManager.InvokeSync("serviceWorkerInstancePostMessage", _serviceWorker, message);
}
