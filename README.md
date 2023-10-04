# Blazor.BrowserAPI

A Blazor Library that provides easy access to browser APIs without the need to use any JavaScript.
It supports asynchronous communication as well as synchronous (JSRuntime and JSInProcessRuntime).

It supports:

- [LocalStorage](#ilocalstorage)
- [SessionStorage](#isessionstorage)
- [CookieStorage](#icookiestorage)
- [Download](#idownload)
- [Clipboard](#iclipboard)
- [Language](#ilanguage)


<br></br>
## Get Started

1. Add PackageReference to your .csproj file

```xml
<ItemGroup>
  <PackageReference Include="Blazor.BrowserAPI" Version="x.x.x" />
</ItemGroup>
```

2. Register BrowserAPI in your dependency container

```csharp
using BrowserAPI;

services.AddBrowserAPI();
```


<br></br>
## JS module

The necessary js file is fetched automatically the first time.
However, if you use a functionality of BrowserAPI synchronous (JSInProcessRuntime) before the download has finished, you get an error like:

*JS-module is not loaded yet. To make sure the module is downloaded, you can await IModuleLoader.ModuleDownload.*

To ensure the download has finished, you can inject the *IModuleLoader* interface and await *ModuleDownload*.

```csharp
using BrowserAPI;

public static class Program {
    public static async Task Main(string[] args) {
        WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddBrowserAPI();
        builder.RootComponents.Add<App>("#app");
        WebAssemblyHost host = builder.Build();

        // instantiate the object and therefore starts fetching the js module.
        IModuleLoader moduleLoader = host.Services.GetRequiredService<IModuleLoader>();
        // waits until js module download finishes
        await moduleLoader.ModuleDownload;

        await host.RunAsync();
    }
}
```

Furthermore you can prefetch the module into JavaScript, so the ModuleLoader will only get a reference to the module.
```html
<head>
  ...
  <link rel="modulepreload" href="_content/Blazor.BrowserAPI/BrowserAPI.js" />
</head>
```

**Note**:  
Asynchronous functionalities work without the need to await the download.
If the download has not finished yet, they will first await the download before invoking the function in the module.


<br></br>
## Available Interfaces

### IModuleLoader

Contains a get-property to retrieve and observe the state of the module download.

#### Properties

| **Name**         | **Type**                 | get/set | **Dexcription**                                                                                   |
| ---------------- | ------------------------ | ------- | ------------------------------------------------------------------------------------------------- |
| ModuleDownload   | Task<IJSObjectReference> | get     | A Task that represents the download of the module. If this tasks finishes, the download finishes. |


<br></br>
### ILocalStorage

The localStorage read-only property of the window interface allows you to access a Storage object for the Document's origin;
the stored data is saved across browser sessions.

#### Properties

| **Name** | **Type**       | get/set | **Dexcription**                                                                  |
| -------- | -------------- | ------- | -------------------------------------------------------------------------------- |
| Length   | ValueTask<int> | get     | Returns an integer representing the number of data items stored in localStorage. |

#### Methods

| **Name**   | **Parameters**                                                            | **ReturnType**     | **Dexcription**                                                                                                       |
| ---------- | ------------------------------------------------------------------------- | ------------------ | --------------------------------------------------------------------------------------------------------------------- |
| GetLength  | CancellationToken cancellationToken                                       | ValueTask<int>     | Returns an integer representing the number of data items stored in localStorage.                                      |
| Key        | int index, [CancellationToken cancellationToken = default]                | ValueTask<string?> | When passed a number *n*, this method will return the name of the nth key in localStorage.                            |
| GetItem    | string key, [CancellationToken cancellationToken = default]               | ValueTask<string?> | When passed a key name, will return that key's value.                                                                 |
| SetItem    | string key, string value, [CancellationToken cancellationToken = default] | ValueTask          | When passed a key name and value, will add that key to localStorage, or update that key's value if it already exists. |
| RemoveItem | string key, [CancellationToken cancellationToken = default]               | ValueTask          | When passed a key name, will remove that key from localStorage.                                                       |
| Clear      | [CancellationToken cancellationToken = default]                           | ValueTask          | When invoked, will empty all keys out of localStorage.                                                                |


<br></br>
### ILocalStorageInProcess

The localStorage read-only property of the window interface allows you to access a Storage object for the Document's origin;
the stored data is saved across browser sessions.

#### Properties

| **Name** | **Type** | get/set | **Dexcription**                                                                  |
| -------- | -------- | ------- | -------------------------------------------------------------------------------- |
| Length   | int      | get     | Returns an integer representing the number of data items stored in localStorage. |

#### Methods

| **Name**   | **Parameters**                                                            | **ReturnType**     | **Dexcription**                                           |
| ---------- | ------------------------------------------------------------------------- | ------------------ | --------------------------------------------------------- |
| Key        | int index                | string? | When passed a number *n*, this method will return the name of the nth key in localStorage.                            |
| GetItem    | string key               | string? | When passed a key name, will return that key's value.                                                                 |
| SetItem    | string key, string value | void    | When passed a key name and value, will add that key to localStorage, or update that key's value if it already exists. |
| RemoveItem | string key               | void    | When passed a key name, will remove that key from localStorage.                                                       |
| Clear      | *empty*                  | void    | When invoked, will empty all keys out of localStorage.                                                                |


<br></br>
### ISessionStorage

The read-only sessionStorage property accesses a session Storage object for the current origin.
sessionStorage is similar to localStorage;
the difference is that while data in localStorage doesn't expire, data in sessionStorage is cleared when the page session ends.

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

The read-only sessionStorage property accesses a session Storage object for the current origin.
sessionStorage is similar to localStorage;
the difference is that while data in localStorage doesn't expire, data in sessionStorage is cleared when the page session ends.

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


<br></br>
### ICookieStorage

The Document property cookie lets you read and write cookies associated with the document.

#### Properties

| **Name**   | **Type**          | get/set | **Dexcription**                                                                                                                                                                                         |
| ---------- | ----------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| AllCookies | ValueTask<string> | get     | document.cookie; Returns a string containing a semicolon-separated list of all cookies (i.e. key=value pairs). Note that each key and value may be surrounded by whitespace (space and tab characters). |
| Length     | ValueTask<int>    | get     | Returns an integer representing the number of cookies stored in cookieStorage.                                                                                                                          |

#### Methods

| **Name**      | **Parameters**                                                                                                                                                                                | **ReturnType**     | **Dexcription**                                                                                                                                                                                         |
| ----------    | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetAllCookies | CancellationToken cancellationToken                                                                                                                                                           | ValueTask<string>  | document.cookie; Returns a string containing a semicolon-separated list of all cookies (i.e. key=value pairs). Note that each key and value may be surrounded by whitespace (space and tab characters). |
| GetLength     | CancellationToken cancellationToken                                                                                                                                                           | ValueTask<int>     | Returns an integer representing the number of cookies stored in cookieStorage.                                                                                                                          |
| Key           | int index, [CancellationToken cancellationToken = default]                                                                                                                                    | ValueTask<string?> | When passed a number *n*, this method will return the name of the nth key in cookieStorage.                                                                                                             |
| GetCookie     | string key, [CancellationToken cancellationToken = default]                                                                                                                                   | ValueTask<string?> | When passed a key name, will return that key's value.                                                                                                                                                   |
| SetCookie     | string key, string value, [int? expires = null], [string path = "/"], [CookieSameSite sameSite = CookieSameSite.None], [bool secure = false], [CancellationToken cancellationToken = default] | ValueTask          | When passed a key name and value, will add that key to cookieStorage, or update that key's value if it already exists.                                                                                  |
| RemoveCookie  | string key, [CancellationToken cancellationToken = default]                                                                                                                                   | ValueTask          | When passed a key name, will remove that key from cookieStorage.                                                                                                                                        |
| Clear         | [CancellationToken cancellationToken = default]                                                                                                                                               | ValueTask          | When invoked, will empty all keys out of cookieStorage.                                                                                                                                                 |


<br></br>
### ICookieStorageInProcess

The Document property cookie lets you read and write cookies associated with the document.

#### Properties

| **Name**   | **Type** | get/set | **Dexcription**                                                                                                                                                                                         |
| ---------- | -------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| AllCookies | string   | get     | document.cookie; Returns a string containing a semicolon-separated list of all cookies (i.e. key=value pairs). Note that each key and value may be surrounded by whitespace (space and tab characters). |
| Length     | int      | get     | Returns an integer representing the number of data items stored in sessionStorage.                                                                                                                      |

#### Methods

| **Name**     | **Parameters**                                                                                                                               | **ReturnType**     | **Dexcription**                                                                                              |
| ------------ | -------------------------------------------------------------------------------------------------------------------------------------------- | ------------------ | ------------------------------------------------------------------------------------------------------------ |
| Key          | int index                                                                                                                                    | string? | When passed a number *n*, this method will return the name of the nth key in cookieStorage.                             |
| GetCookie    | string key                                                                                                                                   | string? | When passed a key name, will return that key's value.                                                                   |
| SetCookie    | string key, string value, [int? expires = null], [string path = "/"], [CookieSameSite sameSite = CookieSameSite.None], [bool secure = false] | void    | When passed a key name and value, will add that key to cookieStorage, or update that key's value if it already exists.  |
| RemoveCookie | string key                                                                                                                                   | void    | WWhen passed a key name, will remove that key from cookieStorage.                                                       |
| Clear        | *empty*                                                                                                                                      | void    | When invoked, will empty all keys out of cookieStorage.                                                                 |


<br></br>
### IDownload

Save data as a file download on the filesystem. For file upload use the *InputFile* component.

#### Methods

| **Name**       | **Parameters**                                                                                      | **ReturnType** | **Dexcription**                                                                                |
| -------------- | --------------------------------------------------------------------------------------------------- | ---------------| ---------------------------------------------------------------------------------------------- |
| DownloadAsFile | string fileName, string fileContent, [CancellationToken cancellationToken = default]                | ValueTask      | Triggers a download by adding an &lt;a&gt;-element to the document and simulate a click on it. |
| DownloadAsFile | string fileName, byte[] fileContent, [CancellationToken cancellationToken = default]                | ValueTask      | Triggers a download by adding an &lt;a&gt;-element to the document and simulate a click on it. |
| DownloadAsFile | string fileName, DotNetStreamReference fileContent, [CancellationToken cancellationToken = default] | ValueTask      | Triggers a download by adding an &lt;a&gt;-element to the document and simulate a click on it. |

**Note**: *IDownloadInProcess* does not exist, because method *DownloadAsFile* is itself an asynchronous operation.


<br></br>
### IClipboard

The Clipboard interface implements the Clipboard API, providing—if the user grants permission—both read and write access to the contents of the system clipboard.

#### Methods

| **Name** | **Parameters**                                               | **ReturnType**          | **Dexcription**                                                                                                                                                                                        |
| -------- | ------------------------------------------------------------ | ----------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Write    | string text, [CancellationToken cancellationToken = default] | ValueTask               | navigator.clipboard.writeText(text); The Clipboard interface's writeText() property writes the specified text string to the system clipboard. Text may be read back using either read() or readText(). |
| Read     | [CancellationToken cancellationToken = default]              | ValueTask&lt;string&gt; | navigator.clipboard.readText(); The Clipboard interface's readText() method returns a Promise which resolves with a copy of the textual contents of the system clipboard.                              |

**Note**: *IClipboardInProcess* does not exist, because methods *Copy* and *Paste* are itself asynchronous operations.


<br></br>
### ILanguage

The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI.  
The document.documentElement.lang attribute sets the language of the content in the HTML page.

#### Properties

| **Name**        | **Type**                | get/set | **Dexcription**                                                                                                                                                                                                                                              |
| --------------- | ----------------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| BrowserLanguage | ValueTask&lt;string&gt; | get     | navigator.language; The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI. Examples of valid language codes include "en", "en-US", "fr", "fr-FR", "es-ES", etc. |
| HtmlLanguage    | ValueTask&lt;string&gt; | get     | document.documentElement.lang; Returns the content of the "lang" attribute on the html tag.                                                                                                                                                                  |

#### Methods

| **Name**           | **Parameters**                                                   | **ReturnType**           | **Dexcription**                                                                                                                                                                                                                                              |
| ------------------ | ---------------------------------------------------------------- | ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| GetBrowserLanguage | CancellationToken cancellationToken                              | ValueTask&lt;string&gt;  | navigator.language; The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI. Examples of valid language codes include "en", "en-US", "fr", "fr-FR", "es-ES", etc. |
| GetHtmlLanguage    | CancellationToken cancellationToken                              | ValueTask&lt;string&gt;  | document.documentElement.lang; Returns the content of the "lang" attribute on the html tag.                                                                                                                                                                  |
| SetHtmlLanguage    | string language, [CancellationToken cancellationToken = default] | ValueTask                | document.documentElement.lang; Returns the content of the "lang" attribute on the html tag.                                                                                                                                                                  |


<br></br>
### ILanguageInProcess

The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI.  
The document.documentElement.lang attribute sets the language of the content in the HTML page.

#### Properties

| **Name**        | **Type** | get/set | **Dexcription**                                                                                                                                                                                                                                              |
| --------------- | -------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| BrowserLanguage | string   | get     | navigator.language; The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI. Examples of valid language codes include "en", "en-US", "fr", "fr-FR", "es-ES", etc. |
| HtmlLanguage    | string   | get/set | document.documentElement.lang; The content of the "lang" attribute on the html tag.; language abbreviation: e.g. "en", "fr", "es", "de"



<br></br>
## Preview

This package is in preview and breaking changes may occur.  
There are more interfaces coming.
