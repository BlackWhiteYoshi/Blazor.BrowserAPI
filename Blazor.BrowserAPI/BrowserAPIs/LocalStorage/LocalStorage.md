# LocalStorage

The localStorage read-only property of the window interface allows you to access a Storage object for the Document's origin;
the stored data is saved across browser sessions.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase {
    [Inject]
    public required ILocalStorage LocalStorage { private get; init; }

    private async Task Example() {
        await LocalStorage.SetItem("example key", "example content");
        string? content = await LocalStorage.GetItem("example key"); // returns "example content"
    }
}
```


<br><br />
## Members

### ILocalStorage

#### Properties

| **Name** | **Type**             | get/set | **Description**                                                                  |
| -------- | -------------------- | ------- | -------------------------------------------------------------------------------- |
| Length   | ValueTask&lt;int&gt; | get     | Returns an integer representing the number of data items stored in localStorage. |

#### Methods

| **Name**   | **Parameters**                                                            | **ReturnType**           | **Description**                                                                                                       |
| ---------- | ------------------------------------------------------------------------- | ------------------------ | --------------------------------------------------------------------------------------------------------------------- |
| GetLength  | CancellationToken cancellationToken                                       | ValueTask&lt;int&gt;     | Returns an integer representing the number of data items stored in localStorage.                                      |
| Key        | int index, [CancellationToken cancellationToken = default]                | ValueTask&lt;string?&gt; | When passed a number *n*, this method will return the name of the nth key in localStorage.                            |
| GetItem    | string key, [CancellationToken cancellationToken = default]               | ValueTask&lt;string?&gt; | When passed a key name, will return that key's value.                                                                 |
| SetItem    | string key, string value, [CancellationToken cancellationToken = default] | ValueTask                | When passed a key name and value, will add that key to localStorage, or update that key's value if it already exists. |
| RemoveItem | string key, [CancellationToken cancellationToken = default]               | ValueTask                | When passed a key name, will remove that key from localStorage.                                                       |
| Clear      | [CancellationToken cancellationToken = default]                           | ValueTask                | When invoked, will empty all keys out of localStorage.                                                                |


<br></br>
### ILocalStorageInProcess

#### Properties

| **Name** | **Type** | get/set | **Description**                                                                  |
| -------- | -------- | ------- | -------------------------------------------------------------------------------- |
| Length   | int      | get     | Returns an integer representing the number of data items stored in localStorage. |

#### Methods

| **Name**   | **Parameters**                                                            | **ReturnType**     | **Description**                                           |
| ---------- | ------------------------------------------------------------------------- | ------------------ | --------------------------------------------------------- |
| Key        | int index                | string? | When passed a number *n*, this method will return the name of the nth key in localStorage.                            |
| GetItem    | string key               | string? | When passed a key name, will return that key's value.                                                                 |
| SetItem    | string key, string value | void    | When passed a key name and value, will add that key to localStorage, or update that key's value if it already exists. |
| RemoveItem | string key               | void    | When passed a key name, will remove that key from localStorage.                                                       |
| Clear      | *empty*                  | void    | When invoked, will empty all keys out of localStorage.                                                                |
