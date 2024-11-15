using Microsoft.AspNetCore.Components.Server;

namespace BrowserAPI.Test.ClientHost;

public static class Program {
    public interface IAssemblyMarker;

    [Flags]
    private enum RenderMode {
        Server = 1,
        Webassembly = 2,
        Static = 4
    }


    public static Task Main(string[] args) {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        bool isDevelopmentEnvironment = builder.Environment.IsDevelopment();

        RenderMode renderMode = builder.Configuration["RenderMode"] switch {
            "auto" => RenderMode.Server | RenderMode.Webassembly,
            "webassembly" => RenderMode.Webassembly,
            "server" => RenderMode.Server,
            "static" => RenderMode.Static,
            _ => throw new ArgumentException($"invalid config of 'RenderMode': {builder.Configuration["RenderMode"]}")
        };

        bool preRender = bool.TryParse(builder.Configuration["Prerender"], out bool value) switch {
            true /* value present */ => value,
            false /* default value */ => true
        };

        // check for valid startup configuration
        if (renderMode == RenderMode.Static && !preRender)
            throw new ArgumentException($"invalid combination of 'RenderMode' and 'Prerender': static without prerendering basically means doing nothing");


        // configure Services
        {
            IServiceCollection services = builder.Services;

            IRazorComponentsBuilder razorComponentsBuilder = builder.Services.AddRazorComponents();
            if (renderMode.HasFlag(RenderMode.Server))
                razorComponentsBuilder.AddInteractiveServerComponents().AddCircuitOptions((CircuitOptions options) => options.DetailedErrors = builder.Environment.IsDevelopment());
            if (renderMode.HasFlag(RenderMode.Webassembly))
                razorComponentsBuilder.AddInteractiveWebAssemblyComponents();

            builder.Services.AddBrowserAPI();
        }

        WebApplication app = builder.Build();

        // configure Pipeline
        {
            if (isDevelopmentEnvironment) {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            //app.MapStaticAssets(); // does not serve audio file correctly
            app.UseAntiforgery();

            RazorComponentsEndpointConventionBuilder razorComponentsEndpointBuilder = app.MapRazorComponents<Root>().AddAdditionalAssemblies(typeof(Client.App).Assembly);
            if (renderMode.HasFlag(RenderMode.Server))
                razorComponentsEndpointBuilder.AddInteractiveServerRenderMode();
            if (renderMode.HasFlag(RenderMode.Webassembly))
                razorComponentsEndpointBuilder.AddInteractiveWebAssemblyRenderMode();
        }


        app.Services.GetRequiredService<ILogger<RenderMode>>()
            .LogInformation("Application starting with: RenderMode={}, Prerender={}", renderMode, preRender);

        return app.RunAsync();
    }
}
