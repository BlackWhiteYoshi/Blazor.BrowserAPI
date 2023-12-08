using Microsoft.Extensions.DependencyInjection;

namespace BrowserAPI;

public static class ServiceExtension {
    public static IServiceCollection AddBrowserAPI(this IServiceCollection services) {
        services.AddScoped<IModuleManager, ModuleManager>()
            .AddScoped<IClipboard, Clipboard>()
            .AddScoped<IConsole, Console>()
            .AddScoped<IConsoleInProcess, ConsoleInProcess>()
            .AddScoped<ICookieStorage, CookieStorage>()
            .AddScoped<ICookieStorageInProcess, CookieStorageInProcess>()
            .AddScoped<IDialogFactory, DialogFactory>()
            .AddScoped<IDownload, Download>()
            .AddScoped<IHTMLElementFactory, HTMLElementFactory>()
            .AddScoped<ILanguage, Language>()
            .AddScoped<ILanguageInProcess, LanguageInProcess>()
            .AddScoped<ILocalStorage, LocalStorage>()
            .AddScoped<ILocalStorageInProcess, LocalStorageInProcess>()
            .AddScoped<IServiceWorkerContainer, ServiceWorkerContainer>()
            .AddScoped<IServiceWorkerContainerInProcess, ServiceWorkerContainerInProcess>()
            .AddScoped<ISessionStorage, SessionStorage>()
            .AddScoped<ISessionStorageInProcess, SessionStorageInProcess>();

        return services;
    }
}
