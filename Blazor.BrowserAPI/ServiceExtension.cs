using Microsoft.Extensions.DependencyInjection;

namespace BrowserAPI;

public static class ServiceExtension {
    public static IServiceCollection AddBrowserAPI(this IServiceCollection services) {
        services.AddScoped<IModuleManager, ModuleManager>()
            .AddScoped<ILocalStorage, LocalStorage>()
            .AddScoped<ILocalStorageInProcess, LocalStorageInProcess>()
            .AddScoped<ISessionStorage, SessionStorage>()
            .AddScoped<ISessionStorageInProcess, SessionStorageInProcess>()
            .AddScoped<ICookieStorage, CookieStorage>()
            .AddScoped<ICookieStorageInProcess, CookieStorageInProcess>()
            .AddScoped<IDownload, Download>()
            .AddScoped<IClipboard, Clipboard>()
            .AddScoped<ILanguage, Language>()
            .AddScoped<ILanguageInProcess, LanguageInProcess>()
            .AddScoped<IServiceWorkerContainer, ServiceWorkerContainer>()
            .AddScoped<IServiceWorkerContainerInProcess, ServiceWorkerContainerInProcess>()
            .AddScoped<IDialogFactory, DialogFactory>();

        return services;
    }
}
