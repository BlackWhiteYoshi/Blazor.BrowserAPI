using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>
/// The <i>ServiceWorkerRegistration</i> interface of the Service Worker API represents the service worker registration.
/// You register a service worker to control one or more pages that share the same origin.
/// </para>
/// <para>Objects of this class must disposed manually, so do not forget to call <see cref="Dispose"/> when you are done with it.</para>
/// </summary>
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
    /// The <i>active</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is activating or activated. This property is initially set to null.
    /// </summary>
    public IServiceWorkerInProcess? Active {
        get {
            try {
                IJSInProcessObjectReference serviceWorker = ServiceWorkerRegistrationJS.Invoke<IJSInProcessObjectReference>("active");
                return new ServiceWorkerInProcess(serviceWorker);
            }
            catch (JSException) {
                return null;
            }
        }
    }

    /// <summary>
    /// The <i>installing</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is installing. This property is initially set to null.
    /// </summary>
    public IServiceWorkerInProcess? Installing {
        get {
            try {
                IJSInProcessObjectReference serviceWorker = ServiceWorkerRegistrationJS.Invoke<IJSInProcessObjectReference>("installing");
                return new ServiceWorkerInProcess(serviceWorker);
            }
            catch (JSException) {
                return null;
            }
        }
    }

    /// <summary>
    /// The <i>waiting</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is installed. This property is initially set to null.
    /// </summary>
    public IServiceWorkerInProcess? Waiting {
        get {
            try {
                IJSInProcessObjectReference serviceWorker = ServiceWorkerRegistrationJS.Invoke<IJSInProcessObjectReference>("waiting");
                return new ServiceWorkerInProcess(serviceWorker);
            }
            catch (JSException) {
                return null;
            }
        }
    }


    /// <summary>
    /// The <i>scope</i> read-only property of the ServiceWorkerRegistration interface returns a unique identifier for a service worker registration. The service worker must be on the same origin as the document that registers the ServiceWorker.
    /// </summary>
    public string Scope => ServiceWorkerRegistrationJS.Invoke<string>("scope");

    /// <summary>
    /// <para>The <i>updateViaCache</i> read-only property of the ServiceWorkerRegistration interface updates the cache using the mode specified in the call to ServiceWorkerContainer.register. Requests for importScripts still go via the HTTP cache. updateViaCache offers control over this behavior.</para>
    /// <para>
    /// Returns one of the following values:<br />
    /// - <b>imports</b>: meaning the HTTP cache is not consulted for update of the service worker, but is consulted for importScripts.<br />
    /// - <b>all</b>: meaning the HTTP cache is consulted in both cases<br />
    /// - <b>none</b>: meaning the HTTP cache is never consulted.
    /// </para>
    /// </summary>
    public string UpdateViaCache => ServiceWorkerRegistrationJS.Invoke<string>("updateViaCache");


    /// <summary>
    /// The <i>update()</i> method of the ServiceWorkerRegistration interface attempts to update the service worker. It fetches the worker's script URL, and if the new worker is not byte-by-byte identical to the current worker, it installs the new worker. The fetch of the worker bypasses any browser caches if the previous fetch occurred over 24 hours ago.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistrationInProcess> Update(CancellationToken cancellationToken = default) {
        IJSObjectReference serviceWorkerRegistration = await UpdateBase(cancellationToken);
        return new ServiceWorkerRegistrationInProcess((IJSInProcessObjectReference)serviceWorkerRegistration);
    }
}
