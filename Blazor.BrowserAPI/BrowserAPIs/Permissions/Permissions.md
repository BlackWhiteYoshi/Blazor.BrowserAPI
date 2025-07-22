# Permissions API

The *Permissions API* provides a consistent programmatic way to query the status of API permissions attributed to the current context, such as a web page or worker.
For example, it can be used to determine if permission to access a particular feature or API has been granted, denied, or requires specific user permission.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase {
    [Inject]
    public required IPermissions Permissions { private get; init; }

    private async Task<string> GetGeolocationPermissionState() {
        IPermissionStatus permissionStatus = await Permissions.Query("geolocation");
        string state = await permissionStatus.State;
        return state; // "granted", "prompt" or "denied"
    }
}
```


<br><br />
## Members

### IPermissions

The Permissions API provides a consistent programmatic way to query the status of API permissions attributed to the current context, such as a web page or worker.
For example, it can be used to determine if permission to access a particular feature or API has been granted, denied, or requires specific user permission.

The *Permissions* interface of the Permissions API provides the core Permission API functionality, such as methods for querying and revoking permissions.

#### Methods

| **Name** | **Parameters**                                                                                                     | **ReturnType**                                             | **Description**                                                                                                                                                                                                                                                                                                                                                   |
| -------- | ------------------------------------------------------------------------------------------------------------------ | ---------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Query    | string name, [bool userVisibleOnly = false], [bool sysex = false], [CancellationToken cancellationToken = default] | ValueTask&lt;[IPermissionStatus](#ipermissionstatus)&gt;   | Returns the user permission status for a given API.<br/>The user permission names are defined in the respective specifications for each feature. The permissions supported by different browser versions are listed in the [compatibility data of the Permissions interface](https://developer.mozilla.org/en-US/docs/Web/API/Permissions#browser_compatibility). |


<br></br>
### IPermissionStatus

The *PermissionStatus* interface of the Permissions API provides the state of an object and an event handler for monitoring changes to said state.v

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Properties

| **Name** | **Type**                | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| -------- | ----------------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Name     | ValueTask&lt;string&gt; | get     | Returns the name of a requested permission, identical to the *name* passed to *IPermissions.Query*.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| State    | ValueTask&lt;string&gt; | get     | Returns the state of a requested permission. This property returns one of<br />- "granted": The user, or the user agent on the user's behalf, has given express permission to use a powerful feature. The caller can use the feature possibly without having the user agent ask the user's permission.<br />- "denied": The user, or the user agent on the user's behalf, has denied access to this powerful feature. The caller can't use the feature.<br />- "prompt": The user has not given express permission to use the feature (i.e., it's the same as denied). It also means that if a caller attempts to use the feature, the user agent will either be prompting the user for permission or access to the feature will be denied. |

#### Methods

| **Name** | **Parameters**                      | **ReturnType**          | **Description**      |
| -------- | ----------------------------------- | ----------------------- | -------------------- |
| GetName  | CancellationToken cancellationToken | ValueTask&lt;string&gt; | see Property *Name*  |
| GetState | CancellationToken cancellationToken | ValueTask&lt;string&gt; | see Property *State* |

#### Events

| **Name**  | **Type** | **Description**                              |
| --------- | -------- | -------------------------------------------- |
| OnChange  | Action   | Fires whenever the *State* property changes. |



<br></br>
### IPermissionsInProcess

The Permissions API provides a consistent programmatic way to query the status of API permissions attributed to the current context, such as a web page or worker.
For example, it can be used to determine if permission to access a particular feature or API has been granted, denied, or requires specific user permission.

The *Permissions* interface of the Permissions API provides the core Permission API functionality, such as methods for querying and revoking permissions.

#### Methods

| **Name** | **Parameters**                                                                                                     | **ReturnType**                                                               | **Description**                                                                                                                                                                                                                                                                                                                                                   |
| -------- | ------------------------------------------------------------------------------------------------------------------ | ---------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Query    | string name, [bool userVisibleOnly = false], [bool sysex = false], [CancellationToken cancellationToken = default] | ValueTask&lt;[IPermissionStatusInProcess](#ipermissionstatusinprocess)&gt;   | Returns the user permission status for a given API.<br/>The user permission names are defined in the respective specifications for each feature. The permissions supported by different browser versions are listed in the [compatibility data of the Permissions interface](https://developer.mozilla.org/en-US/docs/Web/API/Permissions#browser_compatibility). |


<br></br>
### IPermissionStatusInProcess

The *PermissionStatus* interface of the Permissions API provides the state of an object and an event handler for monitoring changes to said state.v

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Properties

| **Name** | **Type** | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| -------- | -------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Name     | string   | get     | Returns the name of a requested permission, identical to the *name* passed to *IPermissions.Query*.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| State    | string   | get     | Returns the state of a requested permission. This property returns one of<br />- "granted": The user, or the user agent on the user's behalf, has given express permission to use a powerful feature. The caller can use the feature possibly without having the user agent ask the user's permission.<br />- "denied": The user, or the user agent on the user's behalf, has denied access to this powerful feature. The caller can't use the feature.<br />- "prompt": The user has not given express permission to use the feature (i.e., it's the same as denied). It also means that if a caller attempts to use the feature, the user agent will either be prompting the user for permission or access to the feature will be denied. |

#### Events

| **Name**  | **Type** | **Description**                              |
| --------- | -------- | -------------------------------------------- |
| OnChange  | Action   | Fires whenever the *State* property changes. |
