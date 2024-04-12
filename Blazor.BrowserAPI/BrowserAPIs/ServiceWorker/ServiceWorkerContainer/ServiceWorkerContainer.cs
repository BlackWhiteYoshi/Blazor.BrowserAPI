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
/// <param name="moduleManager"></param>
[AutoInterface(Namespace = "BrowserAPI", Modifier = "public partial")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class ServiceWorkerContainer(IModuleManager moduleManager) : ServiceWorkerContainerBase, IServiceWorkerContainer {
    private protected override IModuleManager ModuleManager => moduleManager;


    /// <summary>
    /// Registers a service worker and returns a <see cref="IServiceWorkerRegistration">ServiceWorkerRegistration</see> object, which can be used to track the registration.<br />
    /// If service worker is not supported, null is returned.
    /// </summary>
    /// <param name="scriptURL">relative file path to the service worker script (e.g. "/sw.js")</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistration?> RegisterWithWorkerRegistration(string scriptURL, CancellationToken cancellationToken = default) {
        IJSObjectReference? serviceWorkerRegistration = await RegisterWithWorkerRegistrationBase(scriptURL, cancellationToken);
        if (serviceWorkerRegistration == null)
            return null;

        return new ServiceWorkerRegistration(serviceWorkerRegistration);
    }


    /// <summary>
    /// Provides a way of delaying code execution until a service worker is active.
    /// It returns a Promise that will never reject, and which waits indefinitely until the ServiceWorkerRegistration associated with the current page has an ServiceWorkerRegistration.active worker.
    /// Once that condition is met, it resolves with the ServiceWorkerRegistration.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistration> DelayUntilReady(CancellationToken cancellationToken = default) {
        IJSObjectReference serviceWorkerRegistration = await DelayUntilReadyBase(cancellationToken);
        return new ServiceWorkerRegistration(serviceWorkerRegistration);
    }


    /// <summary>
    /// The <i>getRegistration()</i> method of the ServiceWorkerContainer interface gets a ServiceWorkerRegistration object whose scope URL matches the provided client URL.
    /// The method returns a Promise that resolves to a ServiceWorkerRegistration or undefined.
    /// </summary>
    /// <param name="clientUrl">The registration whose scope matches this URL will be returned. Relative URLs are resolved with the current client as the base.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistration?> GetRegistration(string clientUrl, CancellationToken cancellationToken = default) {
        IJSObjectReference? serviceWorkerRegistration = await GetRegistrationBase(clientUrl, cancellationToken);
        if (serviceWorkerRegistration == null)
            return null;

        return new ServiceWorkerRegistration(serviceWorkerRegistration);
    }

    /// <summary>
    /// The <i>getRegistrations()</i> method of the ServiceWorkerContainer interface gets all ServiceWorkerRegistrations associated with a ServiceWorkerContainer, in an array.
    /// The method returns a Promise that resolves to an array of ServiceWorkerRegistration.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistration[]> GetRegistrations(CancellationToken cancellationToken = default) {
        IJSObjectReference[] serviceWorkerRegistrations = await GetRegistrationsBase(cancellationToken);

        ServiceWorkerRegistration[] result = new ServiceWorkerRegistration[serviceWorkerRegistrations.Length];
        for (int i = 0; i < serviceWorkerRegistrations.Length; i++)
            result[i] = new ServiceWorkerRegistration(serviceWorkerRegistrations[i]);
        return result;
    }


    /// <summary>
    /// Returns a <i>ServiceWorker</i> object if its state is activating or activated (the same object returned by ServiceWorkerRegistration.active).
    /// This property returns null during a force-refresh request (Shift + refresh) or if there is no active worker.
    /// </summary>
    public ValueTask<IServiceWorker?> Controller => GetController(default);

    /// <summary>
    /// Returns a <i>ServiceWorker</i> object if its state is activating or activated (the same object returned by ServiceWorkerRegistration.active).
    /// This property returns null during a force-refresh request (Shift + refresh) or if there is no active worker.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorker?> GetController(CancellationToken cancellationToken) {
        try {
            IJSObjectReference serviceWorker = await moduleManager.InvokeTrySync<IJSObjectReference>("serviceWorkerContainerController", cancellationToken);
            return new ServiceWorker(serviceWorker);
        }
        catch (JSException) {
            return null;
        }
    }


    /// <summary>
    /// The <i>startMessages()</i> method of the ServiceWorkerContainer interface explicitly starts the flow of messages being dispatched from a service worker to pages under its control (e.g. sent via Client.postMessage()).
    /// This can be used to react to sent messages earlier, even before that page's content has finished loading.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask StartMessages(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("serviceWorkerContainerStartMessages", cancellationToken);
}
