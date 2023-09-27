# Blazor.BrowserAPI

A Blazor Library that provides easy access to browser APIs without the need to use any JavaScript.
It supports asynchronous communication as well as synchronous (JSRuntime and JSInProcessRuntime).

It supports:

- LocalStorage
- SessionStorage
- CookieStorage
- Download
- Clipboard
- Language


## Get Started

1. Add PackageReference to your .csproj file

```xml
<ItemGroup>
  <PackageReference Include="Blazor.BrowserAPI" Version="x.x.x" />
</ItemGroup>
```

2. Register BrowserAPI in your dependency container

```csharp
services.AddBrowserAPI();
```

3. Add namespace to your *_Imports.razor*

```razor
@using BrowserAPI
```


For documentation or sourcecode see [github.com/BlackWhiteYoshi/Blazor.BrowserAPI](https://github.com/BlackWhiteYoshi/Blazor.BrowserAPI).
