using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BrowserAPI.Test.Client;

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
