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
- [File System](Blazor.BrowserAPI/BrowserAPIs/FileSystem/FileSystem.md)
- [Geolocation](Blazor.BrowserAPI/BrowserAPIs/Geolocation/Geolocation.md)
- [History](Blazor.BrowserAPI/BrowserAPIs/History/History.md)
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
  - first version, includes 10 BrowserAPIs: Clipboard, Console, CookieStorage, Dialog, Download, HTMLElement, Language, LocalStorage, ServiceWorker, SessionStorage
- 0.1.1
  - changed SetCookie parameters: *expires* to seconds and *samesite* to string
- 0.1.2
  - changed internal classes to public and moved them to namespace *BrowserAPI.Implementation*
- 0.2.0
  - added IBrowserAPIModule for [CircleDI](https://github.com/BlackWhiteYoshi/CircleDI) and [Jab](https://github.com/pakrym/jab)
- 0.3.0
  - added Geolocation (11 BrowserAPIs)
- 0.4.0
  - breaking change: removed HTMLElementFactory and DialogFactory and added ElementFactory/ElementFactoryInProcess instead
- 0.5.0
  - added HTMLMediaElement (12 BrowserAPIs)
- 0.6.0
  - added MediaDevices (13 BrowserAPIs)
- 0.7.0
  - added SensorAPI (14 BrowserAPIs)  
  - changed events to use sync interop if possible
- 0.7.1
  - added .NET 9 and removed obsolete versions .NET 6 and .NET 7
- 0.7.2
  - small breaking change: *Geolocation.GetCurrentPosition()* -> first parameter *successCallback* only takes 1 parameter *GeolocationCoordinates* now and the previous second parameter *timestamp* is inlcuded in the first parameter
  - added method *Geolocation.GetCurrentPositionAsync()*
- 0.8.0
  - added FileSystem (15 BrowserAPIs)
- 0.9.0
  - added History (16 BrowserAPIs)
  - small breaking change: *OnError* in MediaRecorder, Sensor and ServiceWorker has as parameter a JsonElement instead of a string. To get the previous value, just use *ToString()* on it.
- 0.10.0
  - TODO
  - added navigator.languages to the Language API
