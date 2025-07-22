# Geolocation

The Geolocation API allows the user to provide their location to web applications if they so desire.
For privacy reasons, the user is asked for permission to report location information.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase {
    [Inject]
    public required IGeolocation Geolocation { private get; init; }

    private async Task Example() {
        await Geolocation.GetCurrentPosition(OutputCurrentPosition, OutputGeolocationError);
    }

    private void OutputCurrentPosition(GeolocationCoordinates geolocationCoordinates)
        => Console.WriteLine(geolocationCoordinates);

    private void OutputGeolocationError(int errorCode, string message)
        => Console.WriteLine($"{errorCode}: {message}");
}
```


<br><br />
## Members

### IGeolocation

The Geolocation API allows the user to provide their location to web applications if they so desire.
For privacy reasons, the user is asked for permission to report location information.

#### Methods

| **Name**                | **Parameters**                                                                                                                                                                                                                          | **ReturnType**                          | **Description**                                                                                                                                                                               |
| ----------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetCurrentPosition      | Action&lt;GeolocationCoordinates&gt; successCallback, [Action&lt;int, string&gt;? errorCallback = null], [long maximumAge = 0], [long timeout = -1], [bool enableHighAccuracy = false], [CancellationToken cancellationToken = default] | ValueTask                               | Is used to get the current position of the device.                                                                                                                                            |
| GetCurrentPositionAsync | [long maximumAge = 0], [long timeout = -1], [bool enableHighAccuracy = false], [CancellationToken cancellationToken = default]                                                                                                          | ValueTask&lt;GeolocationCoordinates&gt; | Is used to get the current position of the device.                                                                                                                                            |
| WatchPosition           | Action&lt;GeolocationCoordinates&gt; successCallback, [Action&lt;int, string&gt;? errorCallback = null], [long maximumAge = 0], [long timeout = -1], [bool enableHighAccuracy = false], [CancellationToken cancellationToken = default] | ValueTask&lt;int&gt;                    | Is used to register a handler function that will be called automatically each time the position of the device changes. You can also, optionally, specify an error handling callback function. |
| ClearWatch              | int watchId, [CancellationToken cancellationToken = default]                                                                                                                                                                            | ValueTask                               | Is used to unregister location/error monitoring handlers previously installed using WatchPosition.                                                                                            |


<br></br>
### IGeolocationInProcess

The Geolocation API allows the user to provide their location to web applications if they so desire.
For privacy reasons, the user is asked for permission to report location information.

#### Methods

| **Name**                | **Parameters**                                                                                                                                                                         | **ReturnType**                          | **Description**                                                                                                                                                                               |
| ----------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetCurrentPosition      | Action&lt;GeolocationCoordinates&gt; successCallback, [Action&lt;int, string&gt;? errorCallback = null], [long maximumAge = 0], [long timeout = -1], [bool enableHighAccuracy = false] | void                                    | Is used to get the current position of the device.                                                                                                                                            |
| GetCurrentPositionAsync | [long maximumAge = 0], [long timeout = -1], [bool enableHighAccuracy = false], [CancellationToken cancellationToken = default]                                                         | ValueTask&lt;GeolocationCoordinates&gt; | Is used to get the current position of the device.                                                                                                                                            |
| WatchPosition           | Action&lt;GeolocationCoordinates&gt; successCallback, [Action&lt;int, string&gt;? errorCallback = null], [long maximumAge = 0], [long timeout = -1], [bool enableHighAccuracy = false] | int                                     | Is used to register a handler function that will be called automatically each time the position of the device changes. You can also, optionally, specify an error handling callback function. |
| ClearWatch              | int watchId                                                                                                                                                                            | void                                    | Is used to unregister location/error monitoring handlers previously installed using WatchPosition.                                                                                            |
