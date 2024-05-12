using Microsoft.Extensions.DependencyInjection;

namespace BrowserAPI;

/// <summary>
/// Contains the extension method <see cref="AddBrowserAPI(IServiceCollection)"/>
/// </summary>
public static class AddBrowserAPIExtension {
    /// <summary>
    /// <para>
    /// Registers all services available in this library.<br />
    /// All services includes every BrowserAPI service and <see cref="IModuleManager"/>.
    /// </para>
    /// <para>All services will be registered as scoped.</para>
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddBrowserAPI(this IServiceCollection services) {
        services.AddScoped<IModuleManager, Implementation.ModuleManager>()
            .AddScoped<IClipboard, Implementation.Clipboard>()
            .AddScoped<IConsole, Implementation.Console>()
            .AddScoped<IConsoleInProcess, Implementation.ConsoleInProcess>()
            .AddScoped<ICookieStorage, Implementation.CookieStorage>()
            .AddScoped<ICookieStorageInProcess, Implementation.CookieStorageInProcess>()
            .AddScoped<IDownload, Implementation.Download>()
            .AddScoped<IElementFactory, Implementation.ElementFactory>()
            .AddScoped<IElementFactoryInProcess, Implementation.ElementFactoryInProcess>()
            .AddScoped<IGeolocation, Implementation.Geolocation>()
            .AddScoped<IGeolocationInProcess, Implementation.GeolocationInProcess>()
            .AddScoped<ILanguage, Implementation.Language>()
            .AddScoped<ILanguageInProcess, Implementation.LanguageInProcess>()
            .AddScoped<ILocalStorage, Implementation.LocalStorage>()
            .AddScoped<ILocalStorageInProcess, Implementation.LocalStorageInProcess>()
            .AddScoped<IServiceWorkerContainer, Implementation.ServiceWorkerContainer>()
            .AddScoped<IServiceWorkerContainerInProcess, Implementation.ServiceWorkerContainerInProcess>()
            .AddScoped<ISessionStorage, Implementation.SessionStorage>()
            .AddScoped<ISessionStorageInProcess, Implementation.SessionStorageInProcess>();

        return services;
    }
}
