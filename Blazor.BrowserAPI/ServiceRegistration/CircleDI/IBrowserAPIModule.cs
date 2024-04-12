using CircleDIAttributes;

namespace BrowserAPI;

/// <summary>
/// <para>
/// CircleDI service providers can import this module to register all services available in this library.<br />
/// All services includes every BrowserAPI service and <see cref="IModuleManager"/>.
/// </para>
/// <para>All services will be registered as scoped.</para>
/// </summary>
[ScopedAttribute<IModuleManager, Implementation.ModuleManager>]
[ScopedAttribute<IClipboard, Implementation.Clipboard>]
[ScopedAttribute<IConsole, Implementation.Console>]
[ScopedAttribute<IConsoleInProcess, Implementation.ConsoleInProcess>]
[ScopedAttribute<ICookieStorage, Implementation.CookieStorage>]
[ScopedAttribute<ICookieStorageInProcess, Implementation.CookieStorageInProcess>]
[ScopedAttribute<IDialogFactory, Implementation.DialogFactory>]
[ScopedAttribute<IDownload, Implementation.Download>]
[ScopedAttribute<IHTMLElementFactory, Implementation.HTMLElementFactory>]
[ScopedAttribute<ILanguage, Implementation.Language>]
[ScopedAttribute<ILanguageInProcess, Implementation.LanguageInProcess>]
[ScopedAttribute<ILocalStorage, Implementation.LocalStorage>]
[ScopedAttribute<ILocalStorageInProcess, Implementation.LocalStorageInProcess>]
[ScopedAttribute<IServiceWorkerContainer, Implementation.ServiceWorkerContainer>]
[ScopedAttribute<IServiceWorkerContainerInProcess, Implementation.ServiceWorkerContainerInProcess>]
[ScopedAttribute<ISessionStorage, Implementation.SessionStorage>]
[ScopedAttribute<ISessionStorageInProcess, Implementation.SessionStorageInProcess>]
public interface IBrowserAPICircleDIModule;
