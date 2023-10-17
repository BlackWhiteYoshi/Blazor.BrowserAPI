using AutoInterfaceAttributes;
using Microsoft.JSInterop;

namespace BrowserAPI;

[AutoInterface(Modifier = "public partial", Inheritance = new[] { typeof(IDisposable) })]
internal sealed class ServiceWorkerInProcess : ServiceWorkerBase, IServiceWorkerInProcess {
    private readonly IJSInProcessObjectReference _serviceWorker;
    protected override IJSObjectReference ServiceWorkerJS => _serviceWorker;

    public ServiceWorkerInProcess(IJSInProcessObjectReference serviceWorker) {
        _serviceWorker = serviceWorker;
    }

    void IDisposable.Dispose() => _serviceWorker.Dispose();


    /// <summary>
    /// Returns the <i>ServiceWorker</i> serialized script URL defined as part of ServiceWorkerRegistration. The URL must be on the same origin as the document that registers the ServiceWorker.
    /// </summary>
    public string ScriptUrl => _serviceWorker.Invoke<string>("scriptURL");

    /// <summary>
    /// The state read-only property of the <i>ServiceWorker</i> interface returns a string representing the current state of the service worker. It can be one of the following values: parsed, installing, installed, activating, activated, or redundant.
    /// </summary>
    public string State => _serviceWorker.Invoke<string>("state");

    /// <summary>
    /// <para>
    /// The <i>postMessage()</i> method of the ServiceWorker interface sends a message to the worker.
    /// This accepts a single parameter, which is the data to send to the worker.
    /// The data may be any JavaScript object which can be handled by the structured clone algorithm.
    /// </para>
    /// <para>
    /// The service worker can send back information to its clients by using the postMessage() method.
    /// The message will not be sent back to this ServiceWorker object but to the associated ServiceWorkerContainer available via navigator.serviceWorker.
    /// </para>
    /// </summary>
    /// <param name="message">
    /// <para>The object to deliver to the worker; this will be in the data field in the event delivered to the message event. This may be any JavaScript object handled by the structured clone algorithm.</para>
    /// <para>The message parameter is mandatory.If the data to be passed to the worker is unimportant, null or undefined must be passed explicitly.</para>
    /// </param>
    public void PostMessage(object message) => _serviceWorker.InvokeVoid("postMessage", message);
}
