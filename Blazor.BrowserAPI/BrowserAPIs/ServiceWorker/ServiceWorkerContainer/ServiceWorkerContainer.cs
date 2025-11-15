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
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class ServiceWorkerContainer(IModuleManager moduleManager) : ServiceWorkerContainerBase(moduleManager), IServiceWorkerContainer {
    /// <summary>
    /// Registers a service worker and returns a <see cref="IServiceWorkerRegistration">ServiceWorkerRegistration</see> object, which can be used to track the registration.
    /// </summary>
    /// <param name="scriptURL">relative file path to the service worker script (e.g. "/sw.js")</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistration> RegisterWithWorkerRegistration(string scriptURL, CancellationToken cancellationToken = default) {
        IJSObjectReference serviceWorkerRegistration = await moduleManager.InvokeAsync<IJSObjectReference>("ServiceWorkerContainerAPI.registerWithWorkerRegistration", cancellationToken, [scriptURL]);
        return new ServiceWorkerRegistration(serviceWorkerRegistration);
    }


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
    /// Provides a way of delaying code execution until a service worker is active.
    /// It returns a Promise that will never reject, and which waits indefinitely until the ServiceWorkerRegistration associated with the current page has an ServiceWorkerRegistration.active worker.
    /// Once that condition is met, it resolves with the ServiceWorkerRegistration.
    /// </summary>
    public ValueTask<IServiceWorkerRegistration> Ready => GetReady(CancellationToken.None);

    /// <inheritdoc cref="Ready" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistration> GetReady(CancellationToken cancellationToken) {
        IJSObjectReference serviceWorkerRegistration = await moduleManager.InvokeAsync<IJSObjectReference>("ServiceWorkerContainerAPI.getReady", cancellationToken);
        return new ServiceWorkerRegistration(serviceWorkerRegistration);
    }


    /// <summary>
    /// Gets a ServiceWorkerRegistration object whose scope URL matches the provided client URL.
    /// The method returns a Promise that resolves to a ServiceWorkerRegistration or undefined.
    /// </summary>
    /// <param name="clientUrl">The registration whose scope matches this URL will be returned. Relative URLs are resolved with the current client as the base.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistration?> GetRegistration(string clientUrl, CancellationToken cancellationToken = default) {
        IJSObjectReference?[] singleReference = await moduleManager.InvokeAsync<IJSObjectReference?[]>("ServiceWorkerContainerAPI.getRegistration", cancellationToken, [clientUrl]);
        if (singleReference[0] is IJSObjectReference serviceWorkerRegistration)
            return new ServiceWorkerRegistration(serviceWorkerRegistration);
        else
            return null;
    }

    /// <summary>
    /// Gets all ServiceWorkerRegistrations associated with a ServiceWorkerContainer, in an array.
    /// The method returns a Promise that resolves to an array of ServiceWorkerRegistration.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistration[]> GetRegistrations(CancellationToken cancellationToken = default) {
        IJSObjectReference[] serviceWorkerRegistrations = await moduleManager.InvokeAsync<IJSObjectReference[]>("ServiceWorkerContainerAPI.getRegistrations", cancellationToken);

        ServiceWorkerRegistration[] result = new ServiceWorkerRegistration[serviceWorkerRegistrations.Length];
        for (int i = 0; i < serviceWorkerRegistrations.Length; i++)
            result[i] = new ServiceWorkerRegistration(serviceWorkerRegistrations[i]);
        return result;
    }


    /// <summary>
    /// Explicitly starts the flow of messages being dispatched from a service worker to pages under its control (e.g. sent via Client.postMessage()).
    /// This can be used to react to sent messages earlier, even before that page's content has finished loading.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask StartMessages(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("ServiceWorkerContainerAPI.startMessages", cancellationToken);
}
