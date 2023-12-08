# Blazor.BrowserAPI

A Blazor library that provides easy access to browser APIs without the need to use any JavaScript.
Since JavaScript functionality for Blazor is primarly used for accessing BrowserAPIs, for most applications there will be no need to write any additional JavaScript.  
It supports asynchronous communication as well as synchronous (JSRuntime and JSInProcessRuntime).


## Available Browser APIs

- Clipboard
- Console
- CookieStorage
- Dialog
- Download
- HTMLElement
- Language
- LocalStorage
- ServiceWorker
- SessionStorage


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


For documentation or sourcecode see [github.com/BlackWhiteYoshi/Blazor.BrowserAPI](https://github.com/BlackWhiteYoshi/Blazor.BrowserAPI).
