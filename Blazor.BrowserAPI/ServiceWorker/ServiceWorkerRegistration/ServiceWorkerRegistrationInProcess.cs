using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

[AutoInterface(Modifier = "public partial", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
internal sealed class ServiceWorkerRegistrationInProcess(IJSInProcessObjectReference serviceWorkerRegistration) : ServiceWorkerRegistrationBase, IServiceWorkerRegistrationInProcess {
    protected override IJSObjectReference ServiceWorkerRegistrationJS => serviceWorkerRegistration;

    [IgnoreAutoInterface]
    public void Dispose() => serviceWorkerRegistration.Dispose();


    /// <summary>
    /// The <i>active</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is activating or activated. This property is initially set to null.
    /// </summary>
    public IServiceWorkerInProcess? Active {
        get {
            try {
                IJSInProcessObjectReference serviceWorker = serviceWorkerRegistration.Invoke<IJSInProcessObjectReference>("active");
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
                IJSInProcessObjectReference serviceWorker = serviceWorkerRegistration.Invoke<IJSInProcessObjectReference>("installing");
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
                IJSInProcessObjectReference serviceWorker = serviceWorkerRegistration.Invoke<IJSInProcessObjectReference>("waiting");
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
    public string Scope => serviceWorkerRegistration.Invoke<string>("scope");

    /// <summary>
    /// <para>The <i>updateViaCache</i> read-only property of the ServiceWorkerRegistration interface updates the cache using the mode specified in the call to ServiceWorkerContainer.register. Requests for importScripts still go via the HTTP cache. updateViaCache offers control over this behavior.</para>
    /// <para>
    /// Returns one of the following values:<br />
    /// - <b>imports</b>: meaning the HTTP cache is not consulted for update of the service worker, but is consulted for importScripts.<br />
    /// - <b>all</b>: meaning the HTTP cache is consulted in both cases<br />
    /// - <b>none</b>: meaning the HTTP cache is never consulted.
    /// </para>
    /// </summary>
    public string UpdateViaCache => serviceWorkerRegistration.Invoke<string>("updateViaCache");


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
