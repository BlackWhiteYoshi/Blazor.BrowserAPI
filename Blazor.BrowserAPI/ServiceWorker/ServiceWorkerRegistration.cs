using AutoInterfaceAttributes;
using Microsoft.JSInterop;

namespace BrowserAPI;

/// <summary>
/// The <i>ServiceWorkerRegistration</i> interface of the Service Worker API represents the service worker registration. You register a service worker to control one or more pages that share the same origin.
/// </summary>
[AutoInterface(Inheritance = new[] { typeof(IAsyncDisposable) })]
internal sealed class ServiceWorkerRegistration : ServiceWorkerRegistrationBase, IServiceWorkerRegistration {
    public ServiceWorkerRegistration(IModuleManager moduleManager, IJSObjectReference serviceWorkerRegistration) : base(moduleManager, serviceWorkerRegistration) { }

    ValueTask IAsyncDisposable.DisposeAsync() => _serviceWorkerRegistration.DisposeAsync();


    /// <summary>
    /// The <i>active</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is activating or activated. This property is initially set to null. 
    /// </summary>
    public ValueTask<IServiceWorkerInstance?> Active => GetActive(default);

    /// <summary>
    /// The <i>active</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is activating or activated. This property is initially set to null. 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerInstance?> GetActive(CancellationToken cancellationToken) {
        try {
            IJSObjectReference serviceWorker = await _moduleManager.InvokeTrySync<IJSObjectReference>("serviceWorkerRegistrationActive", cancellationToken, _serviceWorkerRegistration);
            return new ServiceWorkerInstance(_moduleManager, serviceWorker);
        }
        catch (JSException) {
            return null;
        }
    }


    /// <summary>
    /// The <i>installing</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is installing. This property is initially set to null. 
    /// </summary>
    public ValueTask<IServiceWorkerInstance?> Installing => GetInstalling(default);

    /// <summary>
    /// The <i>installing</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is installing. This property is initially set to null. 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerInstance?> GetInstalling(CancellationToken cancellationToken) {
        try {
            IJSObjectReference serviceWorker = await _moduleManager.InvokeTrySync<IJSObjectReference>("serviceWorkerRegistrationInstalling", cancellationToken, _serviceWorkerRegistration);
            return new ServiceWorkerInstance(_moduleManager, serviceWorker);
        }
        catch (JSException) {
            return null;
        }
    }


    /// <summary>
    /// The <i>waiting</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is installed. This property is initially set to null. 
    /// </summary>
    public ValueTask<IServiceWorkerInstance?> Waiting => GetWaiting(default);

    /// <summary>
    /// The <i>waiting</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is installed. This property is initially set to null. 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerInstance?> GetWaiting(CancellationToken cancellationToken) {
        try {
            IJSObjectReference serviceWorker = await _moduleManager.InvokeTrySync<IJSObjectReference>("serviceWorkerRegistrationWaiting", cancellationToken, _serviceWorkerRegistration);
            return new ServiceWorkerInstance(_moduleManager, serviceWorker);
        }
        catch (JSException) {
            return null;
        }
    }



    /// <summary>
    /// The <i>scope</i> read-only property of the ServiceWorkerRegistration interface returns a unique identifier for a service worker registration. The service worker must be on the same origin as the document that registers the ServiceWorker. 
    /// </summary>
    public ValueTask<string> Scope => GetScope(default);

    /// <summary>
    /// The <i>scope</i> read-only property of the ServiceWorkerRegistration interface returns a unique identifier for a service worker registration. The service worker must be on the same origin as the document that registers the ServiceWorker. 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetScope(CancellationToken cancellationToken) => _moduleManager.InvokeTrySync<string>("serviceWorkerRegistrationScope", default, _serviceWorkerRegistration);


    /// <summary>
    /// The <i>updateViaCache</i> read-only property of the ServiceWorkerRegistration interface updates the cache using the mode specified in the call to ServiceWorkerContainer.register. Requests for importScripts still go via the HTTP cache. updateViaCache offers control over this behavior. 
    /// </summary>
    public ValueTask<string> UpdateViaCache => GetUpdateViaCache(default);

    /// <summary>
    /// The <i>updateViaCache</i> read-only property of the ServiceWorkerRegistration interface updates the cache using the mode specified in the call to ServiceWorkerContainer.register. Requests for importScripts still go via the HTTP cache. updateViaCache offers control over this behavior. 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetUpdateViaCache(CancellationToken cancellationToken) => _moduleManager.InvokeTrySync<string>("serviceWorkerRegistrationUpdateViaCache", default, _serviceWorkerRegistration);



    /// <summary>
    /// The <i>update()</i> method of the ServiceWorkerRegistration interface attempts to update the service worker. It fetches the worker's script URL, and if the new worker is not byte-by-byte identical to the current worker, it installs the new worker. The fetch of the worker bypasses any browser caches if the previous fetch occurred over 24 hours ago. 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistration> Update(CancellationToken cancellationToken) {
        IJSObjectReference serviceWorkerRegistration = await UpdateBase(cancellationToken);
        return new ServiceWorkerRegistration(_moduleManager, serviceWorkerRegistration);
    }
}
