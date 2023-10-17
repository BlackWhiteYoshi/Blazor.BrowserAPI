﻿using AutoInterfaceAttributes;
using Microsoft.JSInterop;

namespace BrowserAPI;

[AutoInterface(Modifier = "public partial")]
internal sealed class ServiceWorkerContainerInProcess : ServiceWorkerContainerBase, IServiceWorkerContainerInProcess {
    public ServiceWorkerContainerInProcess(IModuleManager moduleManager) : base(moduleManager) { }


    /// <summary>
    /// Registers a service worker and returns a <see cref="IServiceWorkerRegistration">ServiceWorkerRegistration</see> object, which can be used to track the registration.<br />
    /// If service worker is not supported, null is returned.
    /// </summary>
    /// <param name="scriptURL">relative file path to the service worker script (e.g. "/sw.js")</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistrationInProcess?> RegisterWithWorkerRegistration(string scriptURL, CancellationToken cancellationToken = default) {
        IJSObjectReference? serviceWorkerRegistration = await RegisterWithWorkerRegistrationBase(scriptURL, cancellationToken);
        if (serviceWorkerRegistration == null)
            return null;

        return new ServiceWorkerRegistrationInProcess((IJSInProcessObjectReference)serviceWorkerRegistration);
    }


    /// <summary>
    /// Provides a way of delaying code execution until a service worker is active. It returns a Promise that will never reject, and which waits indefinitely until the ServiceWorkerRegistration associated with the current page has an ServiceWorkerRegistration.active worker. Once that condition is met, it resolves with the ServiceWorkerRegistration.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistrationInProcess> DelayUntilReady(CancellationToken cancellationToken = default) {
        IJSObjectReference serviceWorkerRegistration = await DelayUntilReadyBase(cancellationToken);
        return new ServiceWorkerRegistrationInProcess((IJSInProcessObjectReference)serviceWorkerRegistration);
    }


    /// <summary>
    /// The <i>getRegistration()</i> method of the ServiceWorkerContainer interface gets a ServiceWorkerRegistration object whose scope URL matches the provided client URL. The method returns a Promise that resolves to a ServiceWorkerRegistration or undefined.
    /// </summary>
    /// <param name="clientUrl">The registration whose scope matches this URL will be returned. Relative URLs are resolved with the current client as the base.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistrationInProcess?> GetRegistration(string clientUrl, CancellationToken cancellationToken = default) {
        IJSObjectReference? serviceWorkerRegistration = await GetRegistrationBase(clientUrl, cancellationToken);
        if (serviceWorkerRegistration == null)
            return null;

        return new ServiceWorkerRegistrationInProcess((IJSInProcessObjectReference)serviceWorkerRegistration);
    }

    /// <summary>
    /// The <i>getRegistrations()</i> method of the ServiceWorkerContainer interface gets all ServiceWorkerRegistrations associated with a ServiceWorkerContainer, in an array. The method returns a Promise that resolves to an array of ServiceWorkerRegistration.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IServiceWorkerRegistrationInProcess[]> GetRegistrations(CancellationToken cancellationToken = default) {
        IJSObjectReference[] serviceWorkerRegistrations = await GetRegistrationsBase(cancellationToken);

        ServiceWorkerRegistrationInProcess[] result = new ServiceWorkerRegistrationInProcess[serviceWorkerRegistrations.Length];
        for (int i = 0; i < serviceWorkerRegistrations.Length; i++)
            result[i] = new ServiceWorkerRegistrationInProcess((IJSInProcessObjectReference)serviceWorkerRegistrations[i]);
        return result;
    }


    /// <summary>
    /// Returns a <i>ServiceWorker</i> object if its state is activating or activated (the same object returned by ServiceWorkerRegistration.active). This property returns null during a force-refresh request (Shift + refresh) or if there is no active worker.
    /// </summary>
    public IServiceWorkerInProcess? Controller {
        get {
            try {
                IJSInProcessObjectReference serviceWorker = _moduleManager.InvokeSync<IJSInProcessObjectReference>("serviceWorkerContainerController");
                return new ServiceWorkerInProcess(serviceWorker);
            }
            catch (JSException) {
                return null;
            }
        }
    }

    
    /// <summary>
    /// The <i>startMessages()</i> method of the ServiceWorkerContainer interface explicitly starts the flow of messages being dispatched from a service worker to pages under its control (e.g. sent via Client.postMessage()). This can be used to react to sent messages earlier, even before that page's content has finished loading.
    /// </summary>
    public void StartMessages() => _moduleManager.InvokeSync("serviceWorkerContainerStartMessages");
}
