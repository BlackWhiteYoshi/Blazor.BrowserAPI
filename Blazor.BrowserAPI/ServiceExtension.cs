using Microsoft.Extensions.DependencyInjection;

namespace BrowserAPI;

public static class ServiceExtension {
    public static IServiceCollection AddBrowserAPI(this IServiceCollection services) {
        services.AddScoped<IModuleLoader, BrowserAPICore>()
            .AddScoped(GetBrowserAPIService<ILocalStorage>)
            .AddScoped(GetBrowserAPIService<ILocalStorageInProcess>)
            .AddScoped(GetBrowserAPIService<ISessionStorage>)
            .AddScoped(GetBrowserAPIService<ISessionStorageInProcess>)
            .AddScoped(GetBrowserAPIService<ICookieStorage>)
            .AddScoped(GetBrowserAPIService<ICookieStorageInProcess>)
            .AddScoped(GetBrowserAPIService<IDownload>)
            .AddScoped(GetBrowserAPIService<IClipboard>)
            .AddScoped(GetBrowserAPIService<ILanguage>)
            .AddScoped(GetBrowserAPIService<ILanguageInProcess>);

        return services;


        static T GetBrowserAPIService<T>(IServiceProvider serviceProvider) => (T)serviceProvider.GetRequiredService<IModuleLoader>();
    }
}
