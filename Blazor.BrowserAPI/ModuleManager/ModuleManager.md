# ModuleManager

The ModuleManager is responsible for the access of the JS-module at *"_content/Blazor.BrowserAPI/BrowserAPI.js"*.  
The necessary module is lazy loaded the first time when it is needed,
but it also contains a method to start the module download manually.

However, when *InProcess*-classes are used, the module must be loaded beforehand, otherwise an Exception is thrown.


<br><br />
## Example

To ensure the download of the JS-file has finished, you can inject the *IModuleLoader* interface and await *LoadModule()*.

```csharp
using BrowserAPI;

public static class Program {
    public static async Task Main(string[] args) {
        WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddBrowserAPI();
        WebAssemblyHost host = builder.Build();

        IModuleManager moduleManager = host.Services.GetRequiredService<IModuleManager>();
        // starts and awaits fetching the js module
        await moduleManager.LoadModule();

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
Synchronous functionalities will throw an Exception when the module is not loaded.


<br><br />
## Members

### IModuleManager

#### Methods

| **Name**   | **Parameters** | ReturnType                     | **Description**                                                                                                                                 |
| ---------- | -------------- | ------------------------------ | ----------------------------------------------------------------------------------------------------------------------------------------------- |
| LoadModule | *empty*        | Task&lt;IJSObjectReference&gt; | Starts the download of the JS module. Returns a Task that represents the download of the module. If this tasks finishes, the download finishes. |
