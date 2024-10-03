namespace CircleDIAttributes;

/// <summary>
/// <para>
/// CircleDI service providers can import this module to register all services available in this library.<br />
/// All services includes every BrowserAPI service and <see cref="BrowserAPI.IModuleManager"/>.
/// </para>
/// <para>All services will be registered as scoped, CreationTiming.Constructor, GetAccess.Property and default Name (name of the implementation class).</para>
/// </summary>
[Scoped<BrowserAPI.IModuleManager, BrowserAPI.Implementation.ModuleManager>]
[Scoped<BrowserAPI.IClipboard, BrowserAPI.Implementation.Clipboard>]
[Scoped<BrowserAPI.IConsole, BrowserAPI.Implementation.Console>]
[Scoped<BrowserAPI.IConsoleInProcess, BrowserAPI.Implementation.ConsoleInProcess>]
[Scoped<BrowserAPI.ICookieStorage, BrowserAPI.Implementation.CookieStorage>]
[Scoped<BrowserAPI.ICookieStorageInProcess, BrowserAPI.Implementation.CookieStorageInProcess>]
[Scoped<BrowserAPI.IDownload, BrowserAPI.Implementation.Download>]
[Scoped<BrowserAPI.IElementFactory, BrowserAPI.Implementation.ElementFactory>]
[Scoped<BrowserAPI.IElementFactoryInProcess, BrowserAPI.Implementation.ElementFactoryInProcess>]
[Scoped<BrowserAPI.IGeolocation, BrowserAPI.Implementation.Geolocation>]
[Scoped<BrowserAPI.IGeolocationInProcess, BrowserAPI.Implementation.GeolocationInProcess>]
[Scoped<BrowserAPI.ILanguage, BrowserAPI.Implementation.Language>]
[Scoped<BrowserAPI.ILanguageInProcess, BrowserAPI.Implementation.LanguageInProcess>]
[Scoped<BrowserAPI.ILocalStorage, BrowserAPI.Implementation.LocalStorage>]
[Scoped<BrowserAPI.ILocalStorageInProcess, BrowserAPI.Implementation.LocalStorageInProcess>]
[Scoped<BrowserAPI.IMediaDevices, BrowserAPI.Implementation.MediaDevices>]
[Scoped<BrowserAPI.IMediaDevicesInProcess, BrowserAPI.Implementation.MediaDevicesInProcess>]
[Scoped<BrowserAPI.ISensorAPI, BrowserAPI.Implementation.SensorAPI>]
[Scoped<BrowserAPI.ISensorAPIInProcess, BrowserAPI.Implementation.SensorAPIInProcess>]
[Scoped<BrowserAPI.IServiceWorkerContainer, BrowserAPI.Implementation.ServiceWorkerContainer>]
[Scoped<BrowserAPI.IServiceWorkerContainerInProcess, BrowserAPI.Implementation.ServiceWorkerContainerInProcess>]
[Scoped<BrowserAPI.ISessionStorage, BrowserAPI.Implementation.SessionStorage>]
[Scoped<BrowserAPI.ISessionStorageInProcess, BrowserAPI.Implementation.SessionStorageInProcess>]
public interface IBrowserAPIModule;


/// <summary>
/// <para>The register attribute from CircleDI to register a scoped service to a CircleDI service provider.</para>
/// <para>This attributes members are omitted, because only the attribute class and the type parameters are used here.</para>
/// </summary>
/// <typeparam name="TService">Type of the service.</typeparam>
/// <typeparam name="TImplementation">Type of the implementation.</typeparam>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = true)]
file sealed class ScopedAttribute<TService, TImplementation> : Attribute where TImplementation : TService;
