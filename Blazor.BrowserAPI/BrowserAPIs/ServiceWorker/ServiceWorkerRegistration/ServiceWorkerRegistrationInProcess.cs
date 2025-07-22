using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>ServiceWorkerRegistration</i> interface of the Service Worker API represents the service worker registration.
/// You register a service worker to control one or more pages that share the same origin.
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="Dispose"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class ServiceWorkerRegistrationInProcess(IJSInProcessObjectReference serviceWorkerRegistrationJS) : ServiceWorkerRegistrationBase(serviceWorkerRegistrationJS), IServiceWorkerRegistrationInProcess {
    private IJSInProcessObjectReference ServiceWorkerRegistrationJS => (IJSInProcessObjectReference)base.serviceWorkerRegistrationJS;

    /// <summary>
    /// Releases the JS instance for this service worker registration.
    /// </summary>
    public void Dispose() {
        DisposeEventTrigger();
        ServiceWorkerRegistrationJS.Dispose();
    }


    /// <summary>
    /// Returns a service worker whose ServiceWorker.state is activating or activated.
    /// This property is initially set to null.
    /// </summary>
    public IServiceWorkerInProcess? Active {
        get {
            IJSInProcessObjectReference?[] singleReference = ServiceWorkerRegistrationJS.Invoke<IJSInProcessObjectReference?[]>("getActive");
            if (singleReference[0] is IJSInProcessObjectReference serviceWorker)
                return new ServiceWorkerInProcess(serviceWorker);
            else
                return null;
        }
    }

    /// <summary>
    /// Returns a service worker whose ServiceWorker.state is installing.
    /// This property is initially set to null.
    /// </summary>
    public IServiceWorkerInProcess? Installing {
        get {
            IJSInProcessObjectReference?[] singleReference = ServiceWorkerRegistrationJS.Invoke<IJSInProcessObjectReference?[]>("getInstalling");
            if (singleReference[0] is IJSInProcessObjectReference serviceWorker)
                return new ServiceWorkerInProcess(serviceWorker);
            else
                return null;
        }
    }

    /// <summary>
    /// Returns a service worker whose ServiceWorker.state is installed.
    /// This property is initially set to null.
    /// </summary>
    public IServiceWorkerInProcess? Waiting {
        get {
            IJSInProcessObjectReference?[] singleReference = ServiceWorkerRegistrationJS.Invoke<IJSInProcessObjectReference?[]>("getWaiting");
            if (singleReference[0] is IJSInProcessObjectReference serviceWorker)
                return new ServiceWorkerInProcess(serviceWorker);
            else
                return null;
        }
    }


    /// <summary>
    /// Returns a unique identifier for a service worker registration.
    /// The service worker must be on the same origin as the document that registers the ServiceWorker.
    /// </summary>
    public string Scope => ServiceWorkerRegistrationJS.Invoke<string>("getScope");

    /// <summary>
    /// <para>
    /// Updates the cache using the mode specified in the call to ServiceWorkerContainer.register.
    /// Requests for importScripts still go via the HTTP cache. updateViaCache offers control over this behavior.
    /// </para>
    /// <para>
    /// Returns one of the following values:<br />
    /// - <b>imports</b>: meaning the HTTP cache is not consulted for update of the service worker, but is consulted for importScripts.<br />
    /// - <b>all</b>: meaning the HTTP cache is consulted in both cases<br />
    /// - <b>none</b>: meaning the HTTP cache is never consulted.
    /// </para>
    /// </summary>
    public string UpdateViaCache => ServiceWorkerRegistrationJS.Invoke<string>("getUpdateViaCache");


    /// <summary>
    /// Attempts to update the service worker.
    /// It fetches the worker's script URL, and if the new worker is not byte-by-byte identical to the current worker, it installs the new worker.
    /// The fetch of the worker bypasses any browser caches if the previous fetch occurred over 24 hours ago.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistrationInProcess> Update(CancellationToken cancellationToken = default) {
        IJSInProcessObjectReference serviceWorkerRegistration = await ServiceWorkerRegistrationJS.InvokeAsync<IJSInProcessObjectReference>("update", cancellationToken);
        return new ServiceWorkerRegistrationInProcess(serviceWorkerRegistration);
    }
}
