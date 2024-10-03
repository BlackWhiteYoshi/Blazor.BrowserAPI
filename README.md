# Blazor.BrowserAPI

A Blazor library that provides easy access to browser APIs without the need to use any JavaScript.
Since JavaScript functionality for Blazor is primarly used for accessing BrowserAPIs, for most applications there will be no need to write any additional JavaScript.  
It supports asynchronous communication as well as synchronous (JSRuntime and JSInProcessRuntime).

You can find the test page at [blazor-browserapi.firerocket.de](https://blazor-browserapi.firerocket.de).


## Available Browser APIs

- [Clipboard](Blazor.BrowserAPI/BrowserAPIs/Clipboard/Clipboard.md)
- [Console](Blazor.BrowserAPI/BrowserAPIs/Console/Console.md)
- [CookieStorage](Blazor.BrowserAPI/BrowserAPIs/CookieStorage/CookieStorage.md)
- [Dialog](Blazor.BrowserAPI/BrowserAPIs/Dialog/Dialog.md)
- [Download](Blazor.BrowserAPI/BrowserAPIs/Download/Download.md)
- [Geolocation](Blazor.BrowserAPI/BrowserAPIs/Geolocation/Geolocation.md)
- [HTMLElement](Blazor.BrowserAPI/BrowserAPIs/HTMLElement/HTMLElement.md)
- [HTMLMediaElement (audio/video)](Blazor.BrowserAPI/BrowserAPIs/HTMLMediaElement/HTMLMediaElement.md)
- [Language](Blazor.BrowserAPI/BrowserAPIs/Language/Language.md)
- [LocalStorage](Blazor.BrowserAPI/BrowserAPIs/LocalStorage/LocalStorage.md)
- [MediaDevices (microphone/camera)](Blazor.BrowserAPI/BrowserAPIs/MediaDevices/MediaDevices.md)
- [SensorAPI](Blazor.BrowserAPI/BrowserAPIs/SensorAPI/SensorAPI.md)
- [ServiceWorker](Blazor.BrowserAPI/BrowserAPIs/ServiceWorker/ServiceWorker.md)
- [SessionStorage](Blazor.BrowserAPI/BrowserAPIs/SessionStorage/SessionStorage.md)

## Other APIs

- [ModuleManager](Blazor.BrowserAPI/ModuleManager/ModuleManager.md)


<br></br>
## Get Started

1. Add PackageReference to your .csproj file

```xml
<ItemGroup>
  <PackageReference Include="Blazor.BrowserAPI" Version="{latest version}" />
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
## Namespace BrowserAPI.Implementation

There exists 2 namespaces in this Library: *BrowserAPI* and *BrowserAPI.Implementation*.
Members inside the *BrowserAPI.Implementation* namespace should not be used directly and there is no guarantee that the members of a class will be stable.
However, the class names inside *BrowserAPI.Implementation* will be stable, so using them for service provider registration is fine.


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
- 0.1.2  
  Changed internal classes to public and moved them to namespace *BrowserAPI.Implementation*
- 0.2.0  
  Added IBrowserAPIModule for [CircleDI](https://github.com/BlackWhiteYoshi/CircleDI) and [Jab](https://github.com/pakrym/jab)
- 0.3.0  
  Added Geolocation (11 BrowserAPIs)
- 0.4.0  
  Breaking Change: removed HTMLElementFactory and DialogFactory and added ElementFactory/ElementFactoryInProcess instead.
- 0.5.0  
  Added HTMLMediaElement (12 BrowserAPIs)
- 0.6.0  
  Added MediaDevices (13 BrowserAPIs)
