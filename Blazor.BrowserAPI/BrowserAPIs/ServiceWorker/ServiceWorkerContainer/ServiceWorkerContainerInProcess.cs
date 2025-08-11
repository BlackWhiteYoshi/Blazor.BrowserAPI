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
public sealed class ServiceWorkerContainerInProcess(IModuleManager moduleManager) : ServiceWorkerContainerBase(moduleManager), IServiceWorkerContainerInProcess {
    /// <summary>
    /// Registers a service worker and returns a <see cref="IServiceWorkerRegistration">ServiceWorkerRegistration</see> object, which can be used to track the registration.
    /// </summary>
    /// <param name="scriptURL">relative file path to the service worker script (e.g. "/sw.js")</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistrationInProcess> RegisterWithWorkerRegistration(string scriptURL, CancellationToken cancellationToken = default) {
        IJSInProcessObjectReference serviceWorkerRegistration = await moduleManager.InvokeAsync<IJSInProcessObjectReference>("ServiceWorkerContainerAPI.registerWithWorkerRegistration", cancellationToken, [scriptURL]);
        return new ServiceWorkerRegistrationInProcess(serviceWorkerRegistration);
    }


    /// <summary>
    /// Returns a <i>ServiceWorker</i> object if its state is activating or activated (the same object returned by ServiceWorkerRegistration.active).
    /// This property returns null during a force-refresh request (Shift + refresh) or if there is no active worker.
    /// </summary>
    public IServiceWorkerInProcess? Controller {
        get {
            IJSInProcessObjectReference?[] singleReference = moduleManager.InvokeSync<IJSInProcessObjectReference?[]>("ServiceWorkerContainerAPI.getController");
            if (singleReference[0] is IJSInProcessObjectReference serviceWorker)
                return new ServiceWorkerInProcess(serviceWorker);
            else
                return null;
        }
    }

    /// <summary>
    /// Provides a way of delaying code execution until a service worker is active.
    /// It returns a Promise that will never reject, and which waits indefinitely until the ServiceWorkerRegistration associated with the current page has an ServiceWorkerRegistration.active worker.
    /// Once that condition is met, it resolves with the ServiceWorkerRegistration.
    /// </summary>
    public ValueTask<IServiceWorkerRegistrationInProcess> Ready => GetReady(default);

    /// <inheritdoc cref="Ready" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistrationInProcess> GetReady(CancellationToken cancellationToken) {
        IJSInProcessObjectReference serviceWorkerRegistration = await moduleManager.InvokeAsync<IJSInProcessObjectReference>("ServiceWorkerContainerAPI.getReady", cancellationToken);
        return new ServiceWorkerRegistrationInProcess(serviceWorkerRegistration);
    }


    /// <summary>
    /// Gets a ServiceWorkerRegistration object whose scope URL matches the provided client URL.
    /// The method returns a Promise that resolves to a ServiceWorkerRegistration or undefined.
    /// </summary>
    /// <param name="clientUrl">The registration whose scope matches this URL will be returned. Relative URLs are resolved with the current client as the base.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistrationInProcess?> GetRegistration(string clientUrl, CancellationToken cancellationToken = default) {
        IJSInProcessObjectReference?[] singleReference = await moduleManager.InvokeAsync<IJSInProcessObjectReference?[]>("ServiceWorkerContainerAPI.getRegistration", cancellationToken, [clientUrl]);
        if (singleReference[0] is IJSInProcessObjectReference serviceWorkerRegistration)
            return new ServiceWorkerRegistrationInProcess(serviceWorkerRegistration);
        else
            return null;
    }

    /// <summary>
    /// Gets all ServiceWorkerRegistrations associated with a ServiceWorkerContainer, in an array.
    /// The method returns a Promise that resolves to an array of ServiceWorkerRegistration.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistrationInProcess[]> GetRegistrations(CancellationToken cancellationToken = default) {
        IJSInProcessObjectReference[] serviceWorkerRegistrations = await moduleManager.InvokeAsync<IJSInProcessObjectReference[]>("ServiceWorkerContainerAPI.getRegistrations", cancellationToken);

        ServiceWorkerRegistrationInProcess[] result = new ServiceWorkerRegistrationInProcess[serviceWorkerRegistrations.Length];
        for (int i = 0; i < serviceWorkerRegistrations.Length; i++)
            result[i] = new ServiceWorkerRegistrationInProcess(serviceWorkerRegistrations[i]);
        return result;
    }


    /// <summary>
    /// Explicitly starts the flow of messages being dispatched from a service worker to pages under its control (e.g. sent via Client.postMessage()).
    /// This can be used to react to sent messages earlier, even before that page's content has finished loading.
    /// </summary>
    public void StartMessages() => moduleManager.InvokeSync("ServiceWorkerContainerAPI.startMessages");
}
