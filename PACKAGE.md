# Blazor.BrowserAPI

A Blazor library that provides easy access to browser APIs without the need to use any JavaScript.
Since JavaScript functionality for Blazor is primarly used for accessing BrowserAPIs, for most applications there will be no need to write any additional JavaScript.  
It supports asynchronous communication as well as synchronous (JSRuntime and JSInProcessRuntime).

For documentation or sourcecode see [github.com/BlackWhiteYoshi/Blazor.BrowserAPI](https://github.com/BlackWhiteYoshi/Blazor.BrowserAPI).

You can find the test page at [blazor-browserapi.firerocket.de](https://blazor-browserapi.firerocket.de).


## Available Browser APIs

- Clipboard
- Console
- CookieStorage
- Document
- Download
- FileSystem
- GamepadAPI
- Geolocation
- History
- HTMLDialogElement
- HTMLElement
- HTMLMediaElement (audio/video)
- LocalStorage
- MediaDevices (microphone/camera)
- Navigator
- NetworkInformation
- Permissions
- SensorAPI
- ServiceWorker
- SessionStorage
- WindowManagement (screen)


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


For documentation or sourcecode see [github.com/BlackWhiteYoshi/Blazor.BrowserAPI](https://github.com/BlackWhiteYoshi/Blazor.BrowserAPI).
