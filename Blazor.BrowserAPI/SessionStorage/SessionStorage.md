# SessionStorage

The read-only sessionStorage property accesses a session Storage object for the current origin.  
sessionStorage is similar to localStorage; the difference is that while data in localStorage doesn't expire, data in sessionStorage is cleared when the page session ends.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase {
    [Inject]
    public required ISessionStorage SessionStorage { private get; init; }
    
    private async Task Example() {
        await SessionStorage.SetItem("example key", "example content");
        string? content = await SessionStorage.GetItem("example key"); // returns "example content"
    }
}
```


<br><br />
## Members

### ISessionStorage

#### Properties

| **Name** | **Type**       | get/set | **Dexcription**                                                                    |
| -------- | -------------- | ------- | ---------------------------------------------------------------------------------- |
| Length   | ValueTask<int> | get     | Returns an integer representing the number of data items stored in sessionStorage. |

#### Methods

| **Name**   | **Parameters**                                                            | **ReturnType**     | **Dexcription**                                                                                                         |
| ---------- | ------------------------------------------------------------------------- | ------------------ | ----------------------------------------------------------------------------------------------------------------------- |
| GetLength  | CancellationToken cancellationToken                                       | ValueTask<int>     | Returns an integer representing the number of data items stored in sessionStorage.                                      |
| Key        | int index, [CancellationToken cancellationToken = default]                | ValueTask<string?> | When passed a number *n*, this method will return the name of the nth key in sessionStorage.                            |
| GetItem    | string key, [CancellationToken cancellationToken = default]               | ValueTask<string?> | When passed a key name, will return that key's value.                                                                   |
| SetItem    | string key, string value, [CancellationToken cancellationToken = default] | ValueTask          | When passed a key name and value, will add that key to sessionStorage, or update that key's value if it already exists. |
| RemoveItem | string key, [CancellationToken cancellationToken = default]               | ValueTask          | When passed a key name, will remove that key from sessionStorage.                                                       |
| Clear      | [CancellationToken cancellationToken = default]                           | ValueTask          | When invoked, will empty all keys out of sessionStorage.                                                                |


<br></br>
### ISessionStorageInProcess

#### Properties

| **Name** | **Type** | get/set | **Dexcription**                                                                    |
| -------- | -------- | ------- | ---------------------------------------------------------------------------------- |
| Length   | int      | get     | Returns an integer representing the number of data items stored in sessionStorage. |

#### Methods

| **Name**   | **Parameters**                                                            | **ReturnType**     | **Dexcription**                                             |
| ---------- | ------------------------------------------------------------------------- | ------------------ | ----------------------------------------------------------- |
| Key        | int index                | string? | When passed a number *n*, this method will return the name of the nth key in sessionStorage.                            |
| GetItem    | string key               | string? | When passed a key name, will return that key's value.                                                                   |
| SetItem    | string key, string value | void    | When passed a key name and value, will add that key to sessionStorage, or update that key's value if it already exists. |
| RemoveItem | string key               | void    | When passed a key name, will remove that key from sessionStorage.                                                       |
| Clear      | *empty*                  | void    | When invoked, will empty all keys out of sessionStorage.                                                                |
