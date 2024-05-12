namespace CircleDIAttributes;

/// <summary>
/// <para>
/// CircleDI service providers can import this module to register all services available in this library.<br />
/// All services includes every BrowserAPI service and <see cref="BrowserAPI.IModuleManager"/>.
/// </para>
/// <para>All services will be registered as scoped, CreationTiming.Constructor, GetAccess.Property and default Name (name of the implementation class).</para>
/// </summary>
[ScopedAttribute<BrowserAPI.IModuleManager, BrowserAPI.Implementation.ModuleManager>]
[ScopedAttribute<BrowserAPI.IClipboard, BrowserAPI.Implementation.Clipboard>]
[ScopedAttribute<BrowserAPI.IConsole, BrowserAPI.Implementation.Console>]
[ScopedAttribute<BrowserAPI.IConsoleInProcess, BrowserAPI.Implementation.ConsoleInProcess>]
[ScopedAttribute<BrowserAPI.ICookieStorage, BrowserAPI.Implementation.CookieStorage>]
[ScopedAttribute<BrowserAPI.ICookieStorageInProcess, BrowserAPI.Implementation.CookieStorageInProcess>]
[ScopedAttribute<BrowserAPI.IDownload, BrowserAPI.Implementation.Download>]
[ScopedAttribute<BrowserAPI.IElementFactory, BrowserAPI.Implementation.ElementFactory>]
[ScopedAttribute<BrowserAPI.IElementFactoryInProcess, BrowserAPI.Implementation.ElementFactoryInProcess>]
[ScopedAttribute<BrowserAPI.IGeolocation, BrowserAPI.Implementation.Geolocation>]
[ScopedAttribute<BrowserAPI.IGeolocationInProcess, BrowserAPI.Implementation.GeolocationInProcess>]
[ScopedAttribute<BrowserAPI.ILanguage, BrowserAPI.Implementation.Language>]
[ScopedAttribute<BrowserAPI.ILanguageInProcess, BrowserAPI.Implementation.LanguageInProcess>]
[ScopedAttribute<BrowserAPI.ILocalStorage, BrowserAPI.Implementation.LocalStorage>]
[ScopedAttribute<BrowserAPI.ILocalStorageInProcess, BrowserAPI.Implementation.LocalStorageInProcess>]
[ScopedAttribute<BrowserAPI.IServiceWorkerContainer, BrowserAPI.Implementation.ServiceWorkerContainer>]
[ScopedAttribute<BrowserAPI.IServiceWorkerContainerInProcess, BrowserAPI.Implementation.ServiceWorkerContainerInProcess>]
[ScopedAttribute<BrowserAPI.ISessionStorage, BrowserAPI.Implementation.SessionStorage>]
[ScopedAttribute<BrowserAPI.ISessionStorageInProcess, BrowserAPI.Implementation.SessionStorageInProcess>]
public interface IBrowserAPIModule;


/// <summary>
/// <para>The register attribute from CircleDI to register a scoped service to a CircleDI service provider.</para>
/// <para>This attributes members are omitted, because only the attribute class and the type parameters are used here.</para>
/// </summary>
/// <typeparam name="TService">Type of the service.</typeparam>
/// <typeparam name="TImplementation">Type of the implementation.</typeparam>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = true)]
file sealed class ScopedAttribute<TService, TImplementation> : Attribute where TImplementation : TService;
