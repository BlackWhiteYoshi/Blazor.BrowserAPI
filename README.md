# Blazor.BrowserAPI

A Blazor library that provides easy access to browser APIs without the need to use any JavaScript.
Since JavaScript functionality for Blazor is primarly used for accessing BrowserAPIs, for most applications there will be no need to write any additional JavaScript.  
It supports asynchronous communication as well as synchronous (JSRuntime and JSInProcessRuntime).


## Available Browser APIs

- [Clipboard](Blazor.BrowserAPI/Clipboard/Clipboard.md)
- [Console](Blazor.BrowserAPI/Console/Console.md)
- [CookieStorage](Blazor.BrowserAPI/CookieStorage/CookieStorage.md)
- [Dialog](Blazor.BrowserAPI/Dialog/Dialog.md)
- [Download](Blazor.BrowserAPI/Download/Download.md)
- [HTMLElement](Blazor.BrowserAPI/HTMLElement/HTMLElement.md)
- [Language](Blazor.BrowserAPI/Language/Language.md)
- [LocalStorage](Blazor.BrowserAPI/LocalStorage/LocalStorage.md)
- [ServiceWorker](Blazor.BrowserAPI/ServiceWorker/ServiceWorker.md)
- [SessionStorage](Blazor.BrowserAPI/SessionStorage/SessionStorage.md)

## Other APIs

- [ModuleManager](Blazor.BrowserAPI/ModuleManager/ModuleManager.md)


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

The necessary JS file is fetched automatically the first time.
However, if you use a functionality of BrowserAPI synchronous (JSInProcessRuntime) before the download has finished, you get an error like:

*JS-module is not loaded yet. To make sure the module is downloaded, you can await IModuleLoader.ModuleDownload.*

To ensure the download has finished, you can use the [*IModuleManager*](Blazor.BrowserAPI/ModuleManager/ModuleManager.md) interface.


<br></br>
## Preview

This package is in preview and breaking changes may occur.  
There are more interfaces coming.


<br></br>
## Release Notes

- 0.1  
  First version. Includes 10 BrowserAPIs: Clipboard, Console, CookieStorage, Dialog, Download, HTMLElement, Language, LocalStorage, ServiceWorker, SessionStorage
- 0.1.1  
  Changed SetCookie parameters: *expires* to seconds and *samesite* to string.
