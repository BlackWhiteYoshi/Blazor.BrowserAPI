# Network Information API

The *Network Information API* provides information about the system's connection in terms of general connection type (e.g., 'wifi, 'cellular', etc.).
This can be used to select high definition content or low definition content based on the user's connection.

The interface consists of a single *NetworkInformation* object,
an instance of which is returned by the Navigator.connection property or the WorkerNavigator.connection property.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase, IDisposable {
    [Inject]
    public required INetworkInformation NetworkInformation { private get; init; }

    private string onlineIndicator = string.Empty;

    protected override async Task OnInitializedAsync() {
        NetworkInformation.OnOnline += SetGreen;
        NetworkInformation.OnOffline += SetRed;

        if (await NetworkInformation.OnLine)
            onlineIndicator = "green";
        else
            onlineIndicator = "red";
    }

    public void Dispose() {
        NetworkInformation.OnOnline -= SetGreen;
        NetworkInformation.OnOffline -= SetRed;
    }


    private void SetGreen() => onlineIndicator = "green";

    private void SetRed() => onlineIndicator = "red";


    private async Task DownloadImage() {
        if (await NetworkInformation.SaveData) {
            // download small resolution image ...
        }
        else {
            // download original image ...
        }
    }
}
```


<br><br />
## Members

### INetworkInformation

The NetworkInformation interface of the Network Information API provides information about the connection a device is using to communicate with the network and provides a means for scripts to be notified if the connection type changes.
The NetworkInformation interface cannot be instantiated. It is instead accessed through the connection property of the Navigator interface or the WorkerNavigator interface.

#### Properties

| **Name**      | **Type**                | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| ------------- | ----------------------- | ------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnLine        | ValueTask&lt;bool&gt;   | get     | The onLine property of the Navigator interface returns whether the device is connected to the network, with true meaning online and false meaning offline. The property's value changes after the browser checks its network connection, usually when the user follows links or when a script requests a remote page. For example, the property should return false when users click links soon after they lose internet connection. When its value changes, an online or offline event is fired on the window. |
| Downlink      | ValueTask&lt;double&gt; | get     | Returns the effective bandwidth estimate in megabits per second, rounded to the nearest multiple of 25 kilobits per seconds. This value is based on recently observed application layer throughput across recently active connections, excluding connections made to a private address space. In the absence of recent bandwidth measurement data, the attribute value is determined by the properties of the underlying connection technology.                                                                 |
| DownlinkMax   | ValueTask&lt;double&gt; | get     | Returns the maximum downlink speed, in megabits per second (Mbps), for the underlying connection technology.                                                                                                                                                                                                                                                                                                                                                                                                    |
| EffectiveType | ValueTask&lt;string&gt; | get     | Returns the effective type of the connection meaning one of 'slow-2g', '2g', '3g', or '4g'. This value is determined using a combination of recently observed round-trip time and downlink values.                                                                                                                                                                                                                                                                                                              |
| Type          | ValueTask&lt;string&gt; | get     | Returns the type of connection a device is using to communicate with the network. It will be one of the following values: "bluetooth", "cellular", "ethernet", "none", "wifi", "wimax", "other", "unknown"                                                                                                                                                                                                                                                                                                      |
| RTT           | ValueTask&lt;int&gt;    | get     | Returns the estimated effective round-trip time of the current connection, rounded to the nearest multiple of 25 milliseconds. This value is based on recently observed application-layer RTT measurements across recently active connections. It excludes connections made to a private address space. If no recent measurement data is available, the value is based on the properties of the underlying connection technology.                                                                               |
| SaveData      | ValueTask&lt;bool&gt;   | get     | Returns true if the user has set a reduced data usage option on the user agent.                                                                                                                                                                                                                                                                                                                                                                                                                                 |

#### Methods

| **Name**         | **Parameters**                      | **ReturnType**          | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| ---------------- | ----------------------------------- | ----------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetOnLine        | CancellationToken cancellationToken | ValueTask&lt;bool&gt;   | The onLine property of the Navigator interface returns whether the device is connected to the network, with true meaning online and false meaning offline. The property's value changes after the browser checks its network connection, usually when the user follows links or when a script requests a remote page. For example, the property should return false when users click links soon after they lose internet connection. When its value changes, an online or offline event is fired on the window. |
| GetDownlink      | CancellationToken cancellationToken | ValueTask&lt;double&gt; | Returns the effective bandwidth estimate in megabits per second, rounded to the nearest multiple of 25 kilobits per seconds. This value is based on recently observed application layer throughput across recently active connections, excluding connections made to a private address space. In the absence of recent bandwidth measurement data, the attribute value is determined by the properties of the underlying connection technology.                                                                 |
| GetDownlinkMax   | CancellationToken cancellationToken | ValueTask&lt;double&gt; | Returns the maximum downlink speed, in megabits per second (Mbps), for the underlying connection technology.                                                                                                                                                                                                                                                                                                                                                                                                    |
| GetEffectiveType | CancellationToken cancellationToken | ValueTask&lt;string&gt; | Returns the effective type of the connection meaning one of 'slow-2g', '2g', '3g', or '4g'. This value is determined using a combination of recently observed round-trip time and downlink values.                                                                                                                                                                                                                                                                                                              |
| GetType          | CancellationToken cancellationToken | ValueTask&lt;string&gt; | Returns the type of connection a device is using to communicate with the network. It will be one of the following values: "bluetooth", "cellular", "ethernet", "none", "wifi", "wimax", "other", "unknown"                                                                                                                                                                                                                                                                                                      |
| GetRTT           | CancellationToken cancellationToken | ValueTask&lt;int&gt;    | Returns the estimated effective round-trip time of the current connection, rounded to the nearest multiple of 25 milliseconds. This value is based on recently observed application-layer RTT measurements across recently active connections. It excludes connections made to a private address space. If no recent measurement data is available, the value is based on the properties of the underlying connection technology.                                                                               |
| GetSaveData      | CancellationToken cancellationToken | ValueTask&lt;bool&gt;   | Returns true if the user has set a reduced data usage option on the user agent.                                                                                                                                                                                                                                                                                                                                                                                                                                 |

#### Events

| **Name**  | **Type** | **Description**                                                                                                                                                                                                                                                  |
| --------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnOnline  | Action   | Fired when the browser has gained access to the network and the value of *navigator.onLine* has switched to true.                                                                                                                                                |
| OnOffline | Action   | Fired when the browser has lost access to the network and the value of *navigator.onLine* has switched to false.                                                                                                                                                 |
| OnChange  | Action   | The event that's fired when connection information changes, and the event is received by the NetworkInformation object.<br />That does not include the property *navigator.onLine*, for tracking changes of that property use the *OnOnline*/*OnOffline* events. |


<br></br>
### INetworkInformationInProcess

The NetworkInformation interface of the Network Information API provides information about the connection a device is using to communicate with the network and provides a means for scripts to be notified if the connection type changes.
The NetworkInformation interface cannot be instantiated. It is instead accessed through the connection property of the Navigator interface or the WorkerNavigator interface.

#### Properties

| **Name**      | **Type** | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| ------------- | -------- | ------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnLine        | bool     | get     | The onLine property of the Navigator interface returns whether the device is connected to the network, with true meaning online and false meaning offline. The property's value changes after the browser checks its network connection, usually when the user follows links or when a script requests a remote page. For example, the property should return false when users click links soon after they lose internet connection. When its value changes, an online or offline event is fired on the window. |
| Downlink      | double   | get     | Returns the effective bandwidth estimate in megabits per second, rounded to the nearest multiple of 25 kilobits per seconds. This value is based on recently observed application layer throughput across recently active connections, excluding connections made to a private address space. In the absence of recent bandwidth measurement data, the attribute value is determined by the properties of the underlying connection technology.                                                                 |
| DownlinkMax   | double   | get     | Returns the maximum downlink speed, in megabits per second (Mbps), for the underlying connection technology.                                                                                                                                                                                                                                                                                                                                                                                                    |
| EffectiveType | string   | get     | Returns the effective type of the connection meaning one of 'slow-2g', '2g', '3g', or '4g'. This value is determined using a combination of recently observed round-trip time and downlink values.                                                                                                                                                                                                                                                                                                              |
| Type          | string   | get     | Returns the type of connection a device is using to communicate with the network. It will be one of the following values: "bluetooth", "cellular", "ethernet", "none", "wifi", "wimax", "other", "unknown"                                                                                                                                                                                                                                                                                                      |
| RTT           | int      | get     | Returns the estimated effective round-trip time of the current connection, rounded to the nearest multiple of 25 milliseconds. This value is based on recently observed application-layer RTT measurements across recently active connections. It excludes connections made to a private address space. If no recent measurement data is available, the value is based on the properties of the underlying connection technology.                                                                               |
| SaveData      | bool     | get     | Returns true if the user has set a reduced data usage option on the user agent.                                                                                                                                                                                                                                                                                                                                                                                                                                 |

#### Events

| **Name**  | **Type** | **Description**                                                                                                                                                                                                                                                  |
| --------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnOnline  | Action   | Fired when the browser has gained access to the network and the value of *navigator.onLine* has switched to true.                                                                                                                                                |
| OnOffline | Action   | Fired when the browser has lost access to the network and the value of *navigator.onLine* has switched to false.                                                                                                                                                 |
| OnChange  | Action   | The event that's fired when connection information changes, and the event is received by the NetworkInformation object.<br />That does not include the property *navigator.onLine*, for tracking changes of that property use the *OnOnline*/*OnOffline* events. |
