using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>ServiceWorkerRegistration</i> interface of the Service Worker API represents the service worker registration.
/// You register a service worker to control one or more pages that share the same origin.
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="DisposeAsync"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class ServiceWorkerRegistration(IJSObjectReference serviceWorkerRegistrationJS) : ServiceWorkerRegistrationBase(serviceWorkerRegistrationJS), IServiceWorkerRegistration {
    /// <summary>
    /// Releases the JS instance for this service worker registration.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() {
        DisposeEventTrigger();
        return serviceWorkerRegistrationJS.DisposeTrySync();
    }


    /// <summary>
    /// Returns a service worker whose ServiceWorker.state is activating or activated.
    /// This property is initially set to null.
    /// </summary>
    public ValueTask<IServiceWorker?> Active => GetActive(CancellationToken.None);

    /// <inheritdoc cref="Active" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorker?> GetActive(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await serviceWorkerRegistrationJS.InvokeTrySync<IJSObjectReference?[]>("getActive", cancellationToken);
        if (singleReference[0] is IJSObjectReference serviceWorker)
            return new ServiceWorker(serviceWorker);
        else
            return null;
    }


    /// <summary>
    /// Returns a service worker whose ServiceWorker.state is installing.
    /// This property is initially set to null.
    /// </summary>
    public ValueTask<IServiceWorker?> Installing => GetInstalling(CancellationToken.None);

    /// <inheritdoc cref="Installing" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorker?> GetInstalling(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await serviceWorkerRegistrationJS.InvokeTrySync<IJSObjectReference?[]>("getInstalling", cancellationToken);
        if (singleReference[0] is IJSObjectReference serviceWorker)
            return new ServiceWorker(serviceWorker);
        else
            return null;
    }


    /// <summary>
    /// Returns a service worker whose ServiceWorker.state is installed.
    /// This property is initially set to null.
    /// </summary>
    public ValueTask<IServiceWorker?> Waiting => GetWaiting(CancellationToken.None);

    /// <inheritdoc cref="Waiting" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorker?> GetWaiting(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await serviceWorkerRegistrationJS.InvokeTrySync<IJSObjectReference?[]>("getWaiting", cancellationToken);
        if (singleReference[0] is IJSObjectReference serviceWorker)
            return new ServiceWorker(serviceWorker);
        else
            return null;
    }



    /// <summary>
    /// Returns a unique identifier for a service worker registration.
    /// The service worker must be on the same origin as the document that registers the ServiceWorker.
    /// </summary>
    public ValueTask<string> Scope => GetScope(CancellationToken.None);

    /// <inheritdoc cref="Scope" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetScope(CancellationToken cancellationToken) => serviceWorkerRegistrationJS.InvokeTrySync<string>("getScope", cancellationToken);


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
    public ValueTask<string> UpdateViaCache => GetUpdateViaCache(CancellationToken.None);

    /// <inheritdoc cref="UpdateViaCache" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetUpdateViaCache(CancellationToken cancellationToken) => serviceWorkerRegistrationJS.InvokeTrySync<string>("getUpdateViaCache", cancellationToken);



    /// <summary>
    /// Attempts to update the service worker.
    /// It fetches the worker's script URL, and if the new worker is not byte-by-byte identical to the current worker, it installs the new worker.
    /// The fetch of the worker bypasses any browser caches if the previous fetch occurred over 24 hours ago.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistration> Update(CancellationToken cancellationToken = default) {
        IJSObjectReference serviceWorkerRegistration = await serviceWorkerRegistrationJS.InvokeAsync<IJSObjectReference>("update", cancellationToken);
        return new ServiceWorkerRegistration(serviceWorkerRegistration);
    }
}
