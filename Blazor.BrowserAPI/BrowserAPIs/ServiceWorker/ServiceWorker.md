# ServiceWorker

Service workers essentially act as proxy servers that sit between web applications, the browser, and the network (when available).
They are intended, among other things, to enable the creation of effective offline experiences, intercept network requests and take appropriate action based on whether the network is available, and update assets residing on the server.
They will also allow access to push notifications and background sync APIs.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase {
    [Inject]
    public required IServiceWorkerContainer ServiceWorkerContainer { private get; init; }

    private async Task Example() {
        await ServiceWorkerContainer.Register("service-worker.js");
    }
}
```


<br><br />
## Members

### IServiceWorkerContainer

*navigator.serviceWorker*

The *ServiceWorkerContainer* interface of the *Service Worker API* provides an object representing the service worker as an overall unit in the network ecosystem,
including facilities to register, unregister and update service workers, and access the state of service workers and their registrations.  
Most importantly, it exposes the *ServiceWorkerContainer.register()* method used to register service workers,
and the *ServiceWorkerContainer.controller* property used to determine whether or not the current page is actively controlled.


#### Properties

| **Name**   | **Type**                                    | get/set | **Description**                                                                                                                                                                                                                                                                                                                                        |
| ---------- | ------------------------------------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Controller | ValueTask&lt;IServiceWorker?&gt;            | get     | Returns a *ServiceWorker* object if its state is activating or activated (the same object returned by ServiceWorkerRegistration.active). This property returns null during a force-refresh request (Shift + refresh) or if there is no active worker.                                                                                                  |
| Ready      | ValueTask&lt;IServiceWorkerRegistration&gt; | get     | Provides a way of delaying code execution until a service worker is active. It returns a Promise that will never reject, and which waits indefinitely until the ServiceWorkerRegistration associated with the current page has an ServiceWorkerRegistration.active worker. Once that condition is met, it resolves with the ServiceWorkerRegistration. |

#### Methods

| **Name**                       | **Parameters**                                                    | **ReturnType**                                | **Description**                                                                                                                                                                                                                                          |
| ------------------------------ | ----------------------------------------------------------------- | --------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetController                  | CancellationToken cancellationToken                               | ValueTask&lt;IServiceWorker?&gt;              | see Property *Controller*                                                                                                                                                                                                                                |
| GetReady                       | [CancellationToken cancellationToken = default]                   | ValueTask&lt;IServiceWorkerRegistration&gt;   | see Property *Ready*                                                                                                                                                                                                                                     |
| Register                       | string scriptURL, [CancellationToken cancellationToken = default] | ValueTask                                     | Registers a service worker.                                                                                                                                                                                                                              |
| RegisterWithWorkerRegistration | string scriptURL, [CancellationToken cancellationToken = default] | ValueTask&lt;IServiceWorkerRegistration&gt;   | Registers a service worker and returns a *ServiceWorkerRegistration* object, which can be used to track the registration.                                                                                                                                |
| GetRegistration                | string clientUrl, [CancellationToken cancellationToken = default] | ValueTask&lt;IServiceWorkerRegistration?&gt;  | Gets a ServiceWorkerRegistration object whose scope URL matches the provided client URL. The method returns a Promise that resolves to a ServiceWorkerRegistration or undefined.                                                                         |
| GetRegistrations               | [CancellationToken cancellationToken = default]                   | ValueTask&lt;IServiceWorkerRegistration[]&gt; | Gets all ServiceWorkerRegistrations associated with a ServiceWorkerContainer, in an array. The method returns a Promise that resolves to an array of ServiceWorkerRegistration.                                                                          |
| StartMessages                  | [CancellationToken cancellationToken = default]                   | ValueTask                                     | Explicitly starts the flow of messages being dispatched from a service worker to pages under its control (e.g. sent via Client.postMessage()). This can be used to react to sent messages earlier, even before that page's content has finished loading. |

#### Events

| **Name**           | **Type**             | **Description**                                                                                                                                                                                                                           |
| ------------------ | -------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnControllerChange | Action               | Occurs when the document's associated *ServiceWorkerRegistration* acquires a new active worker.                                                                                                                                           |
| OnMessage          | Action&lt;string&gt; | Is used in a page controlled by a service worker to receive messages from the service worker.<br></br>Parameter is of type [MessageEvent](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerContainer/message_event) as json. |


<br></br>
### ServiceWorkerRegistration

The ServiceWorkerRegistration* interface of the Service Worker API represents the service worker registration.
You register a service worker to control one or more pages that share the same origin.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.


#### Properties

| **Name**       | **Type**                         | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| -------------- | -------------------------------- | ------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Active         | ValueTask&lt;IServiceWorker?&gt; | get     | Returns a service worker whose ServiceWorker.state is activating or activated. This property is initially set to null.                                                                                                                                                                                                                                                                                                                                                                                            |
| Installing     | ValueTask&lt;IServiceWorker?&gt; | get     | Returns a service worker whose ServiceWorker.state is installing. This property is initially set to null.                                                                                                                                                                                                                                                                                                                                                                                                         |
| Waiting        | ValueTask&lt;IServiceWorker?&gt; | get     | Returns a service worker whose ServiceWorker.state is installed. This property is initially set to null.                                                                                                                                                                                                                                                                                                                                                                                                          |
| Scope          | ValueTask&lt;string&gt;          | get     | Returns a unique identifier for a service worker registration. The service worker must be on the same origin as the document that registers the ServiceWorker.                                                                                                                                                                                                                                                                                                                                                    |
| UpdateViaCache | ValueTask&lt;string&gt;          | get     | Updates the cache using the mode specified in the call to ServiceWorkerContainer.register. Requests for importScripts still go via the HTTP cache. updateViaCache offers control over this behavior.<br></br>Returns one of the following values:<br />- **imports**: meaning the HTTP cache is not consulted for update of the service worker, but is consulted for importScripts.<br />- **all**: meaning the HTTP cache is consulted in both cases<br />- **none**: meaning the HTTP cache is never consulted. |

#### Methods

| **Name**          | **Parameters**                                  | **ReturnType**                              | **Description**                                                                                                                                                                                                                                                                                                                                                                                                     |
| ----------------- | ----------------------------------------------- | ------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetActive         | CancellationToken cancellationToken             | ValueTask&lt;IServiceWorker?&gt;            | see Property *Active*                                                                                                                                                                                                                                                                                                                                                                                               |
| GetInstalling     | CancellationToken cancellationToken             | ValueTask&lt;IServiceWorker?&gt;            | see Property *Installing*                                                                                                                                                                                                                                                                                                                                                                                           |
| GetWaiting        | CancellationToken cancellationToken             | ValueTask&lt;IServiceWorker?&gt;            | see Property *Waiting*                                                                                                                                                                                                                                                                                                                                                                                              |
| GetScope          | CancellationToken cancellationToken             | ValueTask&lt;string&gt;                     | see Property *Scope*                                                                                                                                                                                                                                                                                                                                                                                                |
| GetUpdateViaCache | CancellationToken cancellationToken             | ValueTask&lt;string&gt;                     | see Property *UpdateViaCache*                                                                                                                                                                                                                                                                                                                                                                                       |
| Unregister        | [CancellationToken cancellationToken = defaul]  | ValueTask&lt;bool&gt;                       | Unregisters the service worker registration and returns a Promise. The promise will resolve to false if no registration was found, otherwise it resolves to true irrespective of whether unregistration happened or not (it may not unregister if someone else just called ServiceWorkerContainer.register() with the same scope.) The service worker will finish any ongoing operations before it is unregistered. |
| Update            | [CancellationToken cancellationToken = default] | ValueTask&lt;IServiceWorkerRegistration&gt; | Attempts to update the service worker. It fetches the worker's script URL, and if the new worker is not byte-by-byte identical to the current worker, it installs the new worker. The fetch of the worker bypasses any browser caches if the previous fetch occurred over 24 hours ago.                                                                                                                             |

#### Events

| **Name**      | **Type** | **Description**                                                                                      |
| ------------- | -------- | ---------------------------------------------------------------------------------------------------- |
| OnUpdateFound | Action   | Is fired any time the *ServiceWorkerRegistration.installing* property acquires a new service worker. |


<br></br>
### IServiceWorker

The *ServiceWorker* interface of the Service Worker API provides a reference to a service worker.
Multiple browsing contexts (e.g. pages, workers, etc.) can be associated with the same service worker, each through a unique ServiceWorker object.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.


#### Properties

| **Name**  | **Type**                | get/set | **Description**                                                                                                                                                                      |
| ----------| ----------------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ScriptUrl | ValueTask&lt;string&gt; | get     | Returns the *ServiceWorker* serialized script URL defined as part of ServiceWorkerRegistration. The URL must be on the same origin as the document that registers the ServiceWorker. |
| State     | ValueTask&lt;string&gt; | get     | Returns a string representing the current state of the service worker. It can be one of the following values: parsed, installing, installed, activating, activated, or redundant.    |

#### Methods

| **Name**     | **Parameters**                                                  | **ReturnType**          | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| ------------ | --------------------------------------------------------------- | ----------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetScriptUrl | CancellationToken cancellationToken                             | ValueTask&lt;string&gt; | see Property *ScriptUrl*                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| GetState     | CancellationToken cancellationToken                             | ValueTask&lt;string&gt; | see Property *State*                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| PostMessage  | object message, [CancellationToken cancellationToken = default] | ValueTask               | Sends a message to the worker. This accepts a single parameter, which is the data to send to the worker. The data may be any JavaScript object which can be handled by the structured clone algorithm.<br />The service worker can send back information to its clients by using the postMessage() method. The message will not be sent back to this ServiceWorker object but to the associated ServiceWorkerContainer available via navigator.serviceWorker. |

#### Events

| **Name**      | **Type**                  | **Description**                                                                                                                                                                                                  |
| ------------- | ------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnStateChange | Action&lt;string&gt;      | Fires anytime the ServiceWorker.state changes.<br />Parameter is the new state of the service worker. It can be one of the following values: parsed, installing, installed, activating, activated, or redundant. |
| OnError       | Action&lt;JsonElement&gt; | Fires whenever an error occurs in the service worker.<br />Parameter is of type [Event](https://developer.mozilla.org/en-US/docs/Web/API/Event) as JSON.                                                         |


<br></br>
<br></br>
### IServiceWorkerContainerInProcess

*navigator.serviceWorker*

The *ServiceWorkerContainer* interface of the *Service Worker API* provides an object representing the service worker as an overall unit in the network ecosystem,
including facilities to register, unregister and update service workers, and access the state of service workers and their registrations.  
Most importantly, it exposes the *ServiceWorkerContainer.register()* method used to register service workers,
and the *ServiceWorkerContainer.controller* property used to determine whether or not the current page is actively controlled.


#### Properties

| **Name**   | **Type**                                             | get/set | **Description**                                                                                                                                                                                                                                                                                                                                        |
| ---------- | ---------------------------------------------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Controller | IServiceWorkerRegistrationInProcess?                 | get     | Returns a *ServiceWorker* object if its state is activating or activated (the same object returned by ServiceWorkerRegistration.active). This property returns null during a force-refresh request (Shift + refresh) or if there is no active worker.                                                                                                  |
| Ready      | ValueTask&lt;IServiceWorkerRegistrationInProcess&gt; | get     | Provides a way of delaying code execution until a service worker is active. It returns a Promise that will never reject, and which waits indefinitely until the ServiceWorkerRegistration associated with the current page has an ServiceWorkerRegistration.active worker. Once that condition is met, it resolves with the ServiceWorkerRegistration. |

#### Methods

| **Name**                       | **Parameters**                                                    | **ReturnType**                                         | **Description**                                                                                                                                                                                                                                          |
| ------------------------------ | ----------------------------------------------------------------- | ------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetReady                       | [CancellationToken cancellationToken = default]                   | ValueTask&lt;IServiceWorkerRegistrationInProcess&gt;   | see Property *Ready*                                                                                                                                                                                                                                     |
| Register                       | string scriptURL, [CancellationToken cancellationToken = default] | ValueTask                                              | Registers a service worker.                                                                                                                                                                                                                              |
| RegisterWithWorkerRegistration | string scriptURL, [CancellationToken cancellationToken = default] | ValueTask&lt;IServiceWorkerRegistrationInProcess&gt;   | Registers a service worker and returns a *ServiceWorkerRegistration* object, which can be used to track the registration.                                                                                                                                |
| GetRegistration                | string clientUrl, [CancellationToken cancellationToken = default] | ValueTask&lt;IServiceWorkerRegistrationInProcess?&gt;  | Gets a ServiceWorkerRegistration object whose scope URL matches the provided client URL. The method returns a Promise that resolves to a ServiceWorkerRegistration or undefined.                                                                         |
| GetRegistrations               | [CancellationToken cancellationToken = default]                   | ValueTask&lt;IServiceWorkerRegistrationInProcess[]&gt; | Gets all ServiceWorkerRegistrations associated with a ServiceWorkerContainer, in an array. The method returns a Promise that resolves to an array of ServiceWorkerRegistration.                                                                          |
| StartMessages                  | *empty*                                                           | void                                                   | Explicitly starts the flow of messages being dispatched from a service worker to pages under its control (e.g. sent via Client.postMessage()). This can be used to react to sent messages earlier, even before that page's content has finished loading. |

#### Events

| **Name**           | **Type**             | **Description**                                                                                                                                                                                                                           |
| ------------------ | -------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnControllerChange | Action               | Occurs when the document's associated *ServiceWorkerRegistration* acquires a new active worker.                                                                                                                                           |
| OnMessage          | Action&lt;string&gt; | Is used in a page controlled by a service worker to receive messages from the service worker.<br></br>Parameter is of type [MessageEvent](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerContainer/message_event) as json. |


<br></br>
### ServiceWorkerRegistrationInProcess

The ServiceWorkerRegistration* interface of the Service Worker API represents the service worker registration.
You register a service worker to control one or more pages that share the same origin.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.


#### Properties

| **Name**       | **Type**                 | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| -------------- | ------------------------ | ------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Active         | IServiceWorkerInProcess? | get     | Returns a service worker whose ServiceWorker.state is activating or activated. This property is initially set to null.                                                                                                                                                                                                                                                                                                                                                                                            |
| Installing     | IServiceWorkerInProcess? | get     | Returns a service worker whose ServiceWorker.state is installing. This property is initially set to null.                                                                                                                                                                                                                                                                                                                                                                                                         |
| Waiting        | IServiceWorkerInProcess? | get     | Returns a service worker whose ServiceWorker.state is installed. This property is initially set to null.                                                                                                                                                                                                                                                                                                                                                                                                          |
| Scope          | string                   | get     | Returns a unique identifier for a service worker registration. The service worker must be on the same origin as the document that registers the ServiceWorker.                                                                                                                                                                                                                                                                                                                                                    |
| UpdateViaCache | string                   | get     | Updates the cache using the mode specified in the call to ServiceWorkerContainer.register. Requests for importScripts still go via the HTTP cache. updateViaCache offers control over this behavior.<br></br>Returns one of the following values:<br />- **imports**: meaning the HTTP cache is not consulted for update of the service worker, but is consulted for importScripts.<br />- **all**: meaning the HTTP cache is consulted in both cases<br />- **none**: meaning the HTTP cache is never consulted. |

#### Methods

| **Name**          | **Parameters**                                  | **ReturnType**                                       | **Description**                                                                                                                                                                                                                                                                                                                                                                                                     |
| ----------------- | ----------------------------------------------- | ---------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Unregister        | [CancellationToken cancellationToken = defaul]  | ValueTask&lt;bool&gt;                                | Unregisters the service worker registration and returns a Promise. The promise will resolve to false if no registration was found, otherwise it resolves to true irrespective of whether unregistration happened or not (it may not unregister if someone else just called ServiceWorkerContainer.register() with the same scope.) The service worker will finish any ongoing operations before it is unregistered. |
| Update            | [CancellationToken cancellationToken = default] | ValueTask&lt;IServiceWorkerRegistrationInProcess&gt; | Attempts to update the service worker. It fetches the worker's script URL, and if the new worker is not byte-by-byte identical to the current worker, it installs the new worker. The fetch of the worker bypasses any browser caches if the previous fetch occurred over 24 hours ago.                                                                                                                             |

#### Events

| **Name**      | **Type** | **Description**                                                                                      |
| ------------- | -------- | ---------------------------------------------------------------------------------------------------- |
| OnUpdateFound | Action   | Is fired any time the *ServiceWorkerRegistration.installing* property acquires a new service worker. |


<br></br>
### IServiceWorkerInProcess

The *ServiceWorker* interface of the Service Worker API provides a reference to a service worker.
Multiple browsing contexts (e.g. pages, workers, etc.) can be associated with the same service worker, each through a unique ServiceWorker object.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.


#### Properties

| **Name**  | **Type** | get/set | **Description**                                                                                                                                                                      |
| ----------| -------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ScriptUrl | string   | get     | Returns the *ServiceWorker* serialized script URL defined as part of ServiceWorkerRegistration. The URL must be on the same origin as the document that registers the ServiceWorker. |
| State     | string   | get     | Returns a string representing the current state of the service worker. It can be one of the following values: parsed, installing, installed, activating, activated, or redundant.    |

#### Methods

| **Name**     | **Parameters** | **ReturnType** | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| ------------ | -------------- | -------------  | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| PostMessage  | object message | void           | Sends a message to the worker. This accepts a single parameter, which is the data to send to the worker. The data may be any JavaScript object which can be handled by the structured clone algorithm.<br />The service worker can send back information to its clients by using the postMessage() method. The message will not be sent back to this ServiceWorker object but to the associated ServiceWorkerContainer available via navigator.serviceWorker. |

#### Events

| **Name**      | **Type**                  | **Description**                                                                                                                                                                                                  |
| ------------- | ------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnStateChange | Action&lt;string&gt;      | Fires anytime the ServiceWorker.state changes.<br />Parameter is the new state of the service worker. It can be one of the following values: parsed, installing, installed, activating, activated, or redundant. |
| OnError       | Action&lt;JsonElement&gt; | Fires whenever an error occurs in the service worker.<br />Parameter is of type [Event](https://developer.mozilla.org/en-US/docs/Web/API/Event) as JSON.                                                         |
