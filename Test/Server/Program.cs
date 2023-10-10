namespace BrowserAPI.Test.Server;

public static class Program {
    public interface IAssemblyMarker { }


    public static void Main(string[] args) {
        WebApplication app = CreateWebApplication(args);
        app.Run();
    }


    public static WebApplication CreateWebApplication(params string[] args) {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        WebApplication app = builder.Build();

        ConfigurePipeline(app);
        return app;
    }

    private static void ConfigurePipeline(WebApplication app) {
        app.UseDeveloperExceptionPage();
        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();
        app.MapFallbackToFile("/index.html");
    }
}
