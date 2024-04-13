namespace Jab;

/// <summary>
/// <para>
/// Jab service providers can import this module to register all services available in this library.<br />
/// All services includes every BrowserAPI service and <see cref="BrowserAPI.IModuleManager"/>.
/// </para>
/// <para>All services will be registered as scoped.</para>
/// </summary>
[ServiceProviderModule]
[ScopedAttribute<BrowserAPI.IModuleManager, BrowserAPI.Implementation.ModuleManager>]
[ScopedAttribute<BrowserAPI.IClipboard, BrowserAPI.Implementation.Clipboard>]
[ScopedAttribute<BrowserAPI.IConsole, BrowserAPI.Implementation.Console>]
[ScopedAttribute<BrowserAPI.IConsoleInProcess, BrowserAPI.Implementation.ConsoleInProcess>]
[ScopedAttribute<BrowserAPI.ICookieStorage, BrowserAPI.Implementation.CookieStorage>]
[ScopedAttribute<BrowserAPI.ICookieStorageInProcess, BrowserAPI.Implementation.CookieStorageInProcess>]
[ScopedAttribute<BrowserAPI.IDialogFactory, BrowserAPI.Implementation.DialogFactory>]
[ScopedAttribute<BrowserAPI.IDownload, BrowserAPI.Implementation.Download>]
[ScopedAttribute<BrowserAPI.IHTMLElementFactory, BrowserAPI.Implementation.HTMLElementFactory>]
[ScopedAttribute<BrowserAPI.ILanguage, BrowserAPI.Implementation.Language>]
[ScopedAttribute<BrowserAPI.ILanguageInProcess, BrowserAPI.Implementation.LanguageInProcess>]
[ScopedAttribute<BrowserAPI.ILocalStorage, BrowserAPI.Implementation.LocalStorage>]
[ScopedAttribute<BrowserAPI.ILocalStorageInProcess, BrowserAPI.Implementation.LocalStorageInProcess>]
[ScopedAttribute<BrowserAPI.IServiceWorkerContainer, BrowserAPI.Implementation.ServiceWorkerContainer>]
[ScopedAttribute<BrowserAPI.IServiceWorkerContainerInProcess, BrowserAPI.Implementation.ServiceWorkerContainerInProcess>]
[ScopedAttribute<BrowserAPI.ISessionStorage, BrowserAPI.Implementation.SessionStorage>]
[ScopedAttribute<BrowserAPI.ISessionStorageInProcess, BrowserAPI.Implementation.SessionStorageInProcess>]
public interface IBrowserAPIModule;


// Note: Jab attributes must have at least visibility internal to be recognized


/// <summary>
/// The attribute from Jab to mark an interface as module.
/// </summary>
[AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
internal sealed class ServiceProviderModuleAttribute : Attribute;

/// <summary>
/// <para>The register attribute from Jab to register a scoped service to a Jab service provider.</para>
/// <para>This attributes members are omitted, because only the attribute class and the type parameters are used here.</para>
/// </summary>
/// <typeparam name="TService">Type of the service.</typeparam>
/// <typeparam name="TImpl">Type of the implementation.</typeparam>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
internal sealed class ScopedAttribute<TService, TImpl> : Attribute where TImpl : TService;



// Note: the following attributes must be delclared because of Jab sanity check reasons

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
internal class ServiceProviderAttribute : Attribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
internal class ImportAttribute : Attribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
internal class SingletonAttribute : Attribute;
    
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
internal class TransientAttribute : Attribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
internal class ScopedAttribute : Attribute;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
internal class FromNamedServicesAttribute : Attribute;
