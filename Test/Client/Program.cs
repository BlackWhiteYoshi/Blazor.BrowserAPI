using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BrowserAPI.Test.Client;

public static class Program {
    public static async Task Main(string[] args) {
        WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddBrowserAPI();
        builder.RootComponents.Add<App>("#app");
        WebAssemblyHost host = builder.Build();

        IModuleManager moduleManager = host.Services.GetRequiredService<IModuleManager>();
        await moduleManager.LoadModule();

        await host.RunAsync();
    }
}
