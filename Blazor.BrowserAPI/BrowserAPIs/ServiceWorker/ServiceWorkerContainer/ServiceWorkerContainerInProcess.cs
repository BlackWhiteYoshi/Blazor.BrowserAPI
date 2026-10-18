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
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IServiceWorkerContainerBase<IJSInProcessObjectReference, IServiceWorkerRegistrationInProcess, IServiceWorkerInProcess, INotificationInProcess>)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class ServiceWorkerContainerInProcess(IModuleManager moduleManager) : ServiceWorkerContainerBase<IJSInProcessObjectReference, IServiceWorkerRegistrationInProcess, IServiceWorkerInProcess, INotificationInProcess>(moduleManager), IServiceWorkerContainerInProcess {
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
    /// Explicitly starts the flow of messages being dispatched from a service worker to pages under its control (e.g. sent via Client.postMessage()).
    /// This can be used to react to sent messages earlier, even before that page's content has finished loading.
    /// </summary>
    public void StartMessages() => moduleManager.InvokeSync("ServiceWorkerContainerAPI.startMessages");
}
