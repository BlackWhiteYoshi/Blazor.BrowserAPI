# ModuleManager

The ModuleManager is responsible for the access of the JS-module at "_content/Blazor.BrowserAPI/BrowserAPI.js".  
It starts fetching the js file with the constructor.

It contains a get-property to retrieve and observe the state of the module download.


<br><br />
## Example

To ensure the download of the JS-file has finished, you can inject the *IModuleLoader* interface and await *ModuleDownload*.

```csharp
using BrowserAPI;

public static class Program {
    public static async Task Main(string[] args) {
        WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddBrowserAPI();
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


<br><br />
## Members

### IModuleManager

#### Properties

| **Name**         | **Type**                 | get/set | **Dexcription**                                                                                   |
| ---------------- | ------------------------ | ------- | ------------------------------------------------------------------------------------------------- |
| ModuleDownload   | Task<IJSObjectReference> | get     | A Task that represents the download of the module. If this tasks finishes, the download finishes. |
