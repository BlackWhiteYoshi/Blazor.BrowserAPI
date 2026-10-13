using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>navigator.serviceWorker</para>
/// <para>
/// The <i>ServiceWorkerContainer</i> interface of the <i>Service Worker API</i> provides an object representing the service worker as an overall unit in the network ecosystem, including facilities to register, unregister and update service workers, and access the state of service workers and their registrations.<br />
/// Most importantly, it exposes the <i>ServiceWorkerContainer.register()</i> method used to register service workers, and the <i>ServiceWorkerContainer.controller</i> property used to determine whether or not the current page is actively controlled.
/// </para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IServiceWorkerContainerBase<IJSObjectReference, IServiceWorkerRegistration, IServiceWorker>)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class ServiceWorkerContainer(IModuleManager moduleManager) : ServiceWorkerContainerBase<IJSObjectReference, IServiceWorkerRegistration, IServiceWorker>(moduleManager), IServiceWorkerContainer {
    /// <summary>
    /// Returns a <i>ServiceWorker</i> object if its state is activating or activated (the same object returned by ServiceWorkerRegistration.active).
    /// This property returns null during a force-refresh request (Shift + refresh) or if there is no active worker.
    /// </summary>
    public ValueTask<IServiceWorker?> Controller => GetController(CancellationToken.None);

    /// <inheritdoc cref="Controller" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorker?> GetController(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await moduleManager.InvokeTrySync<IJSObjectReference?[]>("ServiceWorkerContainerAPI.getController", cancellationToken);
        if (singleReference[0] is IJSObjectReference serviceWorker)
            return new ServiceWorker(serviceWorker);
        else
            return null;
    }


    /// <summary>
    /// Explicitly starts the flow of messages being dispatched from a service worker to pages under its control (e.g. sent via Client.postMessage()).
    /// This can be used to react to sent messages earlier, even before that page's content has finished loading.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask StartMessages(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("ServiceWorkerContainerAPI.startMessages", cancellationToken);
}
