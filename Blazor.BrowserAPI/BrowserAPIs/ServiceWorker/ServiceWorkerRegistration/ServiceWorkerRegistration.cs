using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>
/// The <i>ServiceWorkerRegistration</i> interface of the Service Worker API represents the service worker registration.
/// You register a service worker to control one or more pages that share the same origin.
/// </para>
/// <para>Objects of this class must disposed manually, so do not forget to call <see cref="DisposeAsync"/> when you are done with it.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Modifier = "public partial", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class ServiceWorkerRegistration(IJSObjectReference serviceWorkerRegistration) : ServiceWorkerRegistrationBase, IServiceWorkerRegistration {
    protected override IJSObjectReference ServiceWorkerRegistrationJS => serviceWorkerRegistration;

    public ValueTask DisposeAsync() => serviceWorkerRegistration.DisposeTrySync();


    /// <summary>
    /// The <i>active</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is activating or activated. This property is initially set to null.
    /// </summary>
    public ValueTask<IServiceWorker?> Active => GetActive(default);

    /// <summary>
    /// The <i>active</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is activating or activated. This property is initially set to null.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorker?> GetActive(CancellationToken cancellationToken) {
        try {
            IJSObjectReference serviceWorker = await serviceWorkerRegistration.InvokeTrySync<IJSObjectReference>("active", cancellationToken);
            return new ServiceWorker(serviceWorker);
        }
        catch (JSException) {
            return null;
        }
    }


    /// <summary>
    /// The <i>installing</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is installing. This property is initially set to null.
    /// </summary>
    public ValueTask<IServiceWorker?> Installing => GetInstalling(default);

    /// <summary>
    /// The <i>installing</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is installing. This property is initially set to null.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorker?> GetInstalling(CancellationToken cancellationToken) {
        try {
            IJSObjectReference serviceWorker = await serviceWorkerRegistration.InvokeTrySync<IJSObjectReference>("installing", cancellationToken);
            return new ServiceWorker(serviceWorker);
        }
        catch (JSException) {
            return null;
        }
    }


    /// <summary>
    /// The <i>waiting</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is installed. This property is initially set to null.
    /// </summary>
    public ValueTask<IServiceWorker?> Waiting => GetWaiting(default);

    /// <summary>
    /// The <i>waiting</i> property of the ServiceWorkerRegistration interface returns a service worker whose ServiceWorker.state is installed. This property is initially set to null.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorker?> GetWaiting(CancellationToken cancellationToken) {
        try {
            IJSObjectReference serviceWorker = await serviceWorkerRegistration.InvokeTrySync<IJSObjectReference>("waiting", cancellationToken);
            return new ServiceWorker(serviceWorker);
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
    public ValueTask<string> GetScope(CancellationToken cancellationToken) => serviceWorkerRegistration.InvokeTrySync<string>("scope", default);


    /// <summary>
    /// <para>The <i>updateViaCache</i> read-only property of the ServiceWorkerRegistration interface updates the cache using the mode specified in the call to ServiceWorkerContainer.register. Requests for importScripts still go via the HTTP cache. updateViaCache offers control over this behavior.</para>
    /// <para>
    /// Returns one of the following values:<br />
    /// - <b>imports</b>: meaning the HTTP cache is not consulted for update of the service worker, but is consulted for importScripts.<br />
    /// - <b>all</b>: meaning the HTTP cache is consulted in both cases<br />
    /// - <b>none</b>: meaning the HTTP cache is never consulted.
    /// </para>
    /// </summary>
    public ValueTask<string> UpdateViaCache => GetUpdateViaCache(default);

    /// <summary>
    /// <para>The <i>updateViaCache</i> read-only property of the ServiceWorkerRegistration interface updates the cache using the mode specified in the call to ServiceWorkerContainer.register. Requests for importScripts still go via the HTTP cache. updateViaCache offers control over this behavior.</para>
    /// <para>
    /// Returns one of the following values:<br />
    /// - <b>imports</b>: meaning the HTTP cache is not consulted for update of the service worker, but is consulted for importScripts.<br />
    /// - <b>all</b>: meaning the HTTP cache is consulted in both cases<br />
    /// - <b>none</b>: meaning the HTTP cache is never consulted.
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetUpdateViaCache(CancellationToken cancellationToken) => serviceWorkerRegistration.InvokeTrySync<string>("updateViaCache", default);



    /// <summary>
    /// The <i>update()</i> method of the ServiceWorkerRegistration interface attempts to update the service worker.
    /// It fetches the worker's script URL, and if the new worker is not byte-by-byte identical to the current worker, it installs the new worker.
    /// The fetch of the worker bypasses any browser caches if the previous fetch occurred over 24 hours ago.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistration> Update(CancellationToken cancellationToken = default) {
        IJSObjectReference serviceWorkerRegistration = await UpdateBase(cancellationToken);
        return new ServiceWorkerRegistration(serviceWorkerRegistration);
    }
}
