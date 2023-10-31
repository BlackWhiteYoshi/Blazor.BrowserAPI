namespace BrowserAPI.Test.Server;

public static class Program {
    public interface IAssemblyMarker { }


    public static void Main(string[] args) {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        WebApplication app = builder.Build();

        ConfigurePipeline(app);
        app.Run();
    }

    private static void ConfigurePipeline(WebApplication app) {
        app.UseDeveloperExceptionPage();
        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();
        app.MapFallbackToFile("/index.html");
    }
}
