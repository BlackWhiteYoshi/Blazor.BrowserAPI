﻿using AutoInterfaceAttributes;
using Microsoft.JSInterop;

namespace BrowserAPI;

/// <summary>
/// The <i>ServiceWorkerRegistration</i> interface of the Service Worker API represents the service worker registration. You register a service worker to control one or more pages that share the same origin.
/// </summary>
[AutoInterface(Inheritance = new[] { typeof(IDisposable) })]
internal sealed class ServiceWorkerRegistrationInProcess : ServiceWorkerRegistrationBase, IServiceWorkerRegistrationInProcess {
    private new readonly IJSInProcessObjectReference _serviceWorkerRegistration;

    public ServiceWorkerRegistrationInProcess(IModuleManager moduleManager, IJSInProcessObjectReference serviceWorkerRegistration) : base(moduleManager, serviceWorkerRegistration) {
        _serviceWorkerRegistration = serviceWorkerRegistration;
    }


    void IDisposable.Dispose() => _serviceWorkerRegistration.Dispose();


    /// <summary>
    /// The <i>active</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is activating or activated. This property is initially set to null. 
    /// </summary>
    public IServiceWorkerInstanceInProcess? Active {
        get {
            try {
                IJSInProcessObjectReference serviceWorker = _moduleManager.InvokeSync<IJSInProcessObjectReference>("serviceWorkerRegistrationActive", _serviceWorkerRegistration);
                return new ServiceWorkerInstanceInProcess(_moduleManager, serviceWorker);
            }
            catch (JSException) {
                return null;
            }
        }
    }

    /// <summary>
    /// The <i>installing</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is installing. This property is initially set to null. 
    /// </summary>
    public IServiceWorkerInstanceInProcess? Installing {
        get {
            try {
                IJSInProcessObjectReference serviceWorker = _moduleManager.InvokeSync<IJSInProcessObjectReference>("serviceWorkerRegistrationInstalling", _serviceWorkerRegistration);
                return new ServiceWorkerInstanceInProcess(_moduleManager, serviceWorker);
            }
            catch (JSException) {
                return null;
            }
        }
    }

    /// <summary>
    /// The <i>waiting</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is installed. This property is initially set to null. 
    /// </summary>
    public IServiceWorkerInstanceInProcess? Waiting {
        get {
            try {
                IJSInProcessObjectReference serviceWorker = _moduleManager.InvokeSync<IJSInProcessObjectReference>("serviceWorkerRegistrationWaiting", _serviceWorkerRegistration);
                return new ServiceWorkerInstanceInProcess(_moduleManager, serviceWorker);
            }
            catch (JSException) {
                return null;
            }
        }
    }


    /// <summary>
    /// The <i>scope</i> read-only property of the ServiceWorkerRegistration interface returns a unique identifier for a service worker registration. The service worker must be on the same origin as the document that registers the ServiceWorker. 
    /// </summary>
    public string Scope => _moduleManager.InvokeSync<string>("serviceWorkerRegistrationScope", _serviceWorkerRegistration);

    /// <summary>
    /// The <i>updateViaCache</i> read-only property of the ServiceWorkerRegistration interface updates the cache using the mode specified in the call to ServiceWorkerContainer.register. Requests for importScripts still go via the HTTP cache. updateViaCache offers control over this behavior. 
    /// </summary>
    public string UpdateViaCache => _moduleManager.InvokeSync<string>("serviceWorkerRegistrationUpdateViaCache", _serviceWorkerRegistration);


    /// <summary>
    /// The <i>update()</i> method of the ServiceWorkerRegistration interface attempts to update the service worker. It fetches the worker's script URL, and if the new worker is not byte-by-byte identical to the current worker, it installs the new worker. The fetch of the worker bypasses any browser caches if the previous fetch occurred over 24 hours ago. 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistrationInProcess> Update(CancellationToken cancellationToken) {
        IJSObjectReference serviceWorkerRegistration = await UpdateBase(cancellationToken);
        return new ServiceWorkerRegistrationInProcess(_moduleManager, (IJSInProcessObjectReference)serviceWorkerRegistration);
    }
}
