# CookieStorage

The Document property cookie lets you read and write cookies associated with the document.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase {
    [Inject]
    public required ICookieStorage CookieStorage { private get; init; }

    private async Task Example() {
        await CookieStorage.SetCookie("example key", "example content");
        string? content = await CookieStorage.GetCookie("example key"); // returns "example content"
    }
}
```


<br><br />
## Members

### ICookieStorage

#### Properties

| **Name**   | **Type**          | get/set | **Dexcription**                                                                                                                                                                                         |
| ---------- | ----------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| AllCookies | ValueTask<string> | get     | document.cookie; Returns a string containing a semicolon-separated list of all cookies (i.e. key=value pairs). Note that each key and value may be surrounded by whitespace (space and tab characters). |
| Length     | ValueTask<int>    | get     | Returns an integer representing the number of cookies stored in cookieStorage.                                                                                                                          |

#### Methods

| **Name**      | **Parameters**                                                                                                                                                           | **ReturnType**     | **Dexcription**                                                                                                                                                                                         |
| ----------    | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetAllCookies | CancellationToken cancellationToken                                                                                                                                      | ValueTask<string>  | document.cookie; Returns a string containing a semicolon-separated list of all cookies (i.e. key=value pairs). Note that each key and value may be surrounded by whitespace (space and tab characters). |
| GetLength     | CancellationToken cancellationToken                                                                                                                                      | ValueTask<int>     | Returns an integer representing the number of cookies stored in cookieStorage.                                                                                                                          |
| Key           | int index, [CancellationToken cancellationToken = default]                                                                                                               | ValueTask<string?> | When passed a number *n*, this method will return the name of the nth key in cookieStorage.                                                                                                             |
| GetCookie     | string key, [CancellationToken cancellationToken = default]                                                                                                              | ValueTask<string?> | When passed a key name, will return that key's value.                                                                                                                                                   |
| SetCookie     | string key, string value, [int? expires = null], [string path = "/"], [string sameSite = "none"], [bool secure = false], [CancellationToken cancellationToken = default] | ValueTask          | When passed a key name and value, will add that key to cookieStorage, or update that key's value if it already exists.                                                                                  |
| RemoveCookie  | string key, [CancellationToken cancellationToken = default]                                                                                                              | ValueTask          | When passed a key name, will remove that key from cookieStorage.                                                                                                                                        |
| Clear         | [CancellationToken cancellationToken = default]                                                                                                                          | ValueTask          | When invoked, will empty all keys out of cookieStorage.                                                                                                                                                 |


<br></br>
### ICookieStorageInProcess

#### Properties

| **Name**   | **Type** | get/set | **Dexcription**                                                                                                                                                                                         |
| ---------- | -------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| AllCookies | string   | get     | document.cookie; Returns a string containing a semicolon-separated list of all cookies (i.e. key=value pairs). Note that each key and value may be surrounded by whitespace (space and tab characters). |
| Length     | int      | get     | Returns an integer representing the number of data items stored in sessionStorage.                                                                                                                      |

#### Methods

| **Name**     | **Parameters**                                                                                                          | **ReturnType**     | **Dexcription**                                                                                              |
| ------------ | ----------------------------------------------------------------------------------------------------------------------- | ------------------ | ------------------------------------------------------------------------------------------------------------ |
| Key          | int index                                                                                                               | string? | When passed a number *n*, this method will return the name of the nth key in cookieStorage.                             |
| GetCookie    | string key                                                                                                              | string? | When passed a key name, will return that key's value.                                                                   |
| SetCookie    | string key, string value, [int? expires = null], [string path = "/"], [string sameSite = "none"], [bool secure = false] | void    | When passed a key name and value, will add that key to cookieStorage, or update that key's value if it already exists.  |
| RemoveCookie | string key                                                                                                              | void    | WWhen passed a key name, will remove that key from cookieStorage.                                                       |
| Clear        | *empty*                                                                                                                 | void    | When invoked, will empty all keys out of cookieStorage.                                                                 |
