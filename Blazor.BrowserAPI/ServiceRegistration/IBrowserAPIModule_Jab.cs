namespace Jab;

/// <summary>
/// <para>
/// Jab service providers can import this module to register all services available in this library.<br />
/// All services includes every BrowserAPI service and <see cref="BrowserAPI.IModuleManager"/>.
/// </para>
/// <para>All services will be registered as scoped.</para>
/// </summary>
[ServiceProviderModule]
[Scoped<BrowserAPI.IModuleManager, BrowserAPI.Implementation.ModuleManager>]
[Scoped<BrowserAPI.IClipboard, BrowserAPI.Implementation.Clipboard>]
[Scoped<BrowserAPI.IConsole, BrowserAPI.Implementation.Console>]
[Scoped<BrowserAPI.IConsoleInProcess, BrowserAPI.Implementation.ConsoleInProcess>]
[Scoped<BrowserAPI.ICookieStorage, BrowserAPI.Implementation.CookieStorage>]
[Scoped<BrowserAPI.ICookieStorageInProcess, BrowserAPI.Implementation.CookieStorageInProcess>]
[Scoped<BrowserAPI.IDocument, BrowserAPI.Implementation.Document>]
[Scoped<BrowserAPI.IDocumentInProcess, BrowserAPI.Implementation.DocumentInProcess>]
[Scoped<BrowserAPI.IDownload, BrowserAPI.Implementation.Download>]
[Scoped<BrowserAPI.IElementFactory, BrowserAPI.Implementation.ElementFactory>]
[Scoped<BrowserAPI.IElementFactoryInProcess, BrowserAPI.Implementation.ElementFactoryInProcess>]
[Scoped<BrowserAPI.IFileSystem, BrowserAPI.Implementation.FileSystem>]
[Scoped<BrowserAPI.IFileSystemInProcess, BrowserAPI.Implementation.FileSystemInProcess>]
[Scoped<BrowserAPI.IGamepadAPI, BrowserAPI.Implementation.GamepadAPI>]
[Scoped<BrowserAPI.IGamepadAPIInProcess, BrowserAPI.Implementation.GamepadAPIInProcess>]
[Scoped<BrowserAPI.IGeolocation, BrowserAPI.Implementation.Geolocation>]
[Scoped<BrowserAPI.IGeolocationInProcess, BrowserAPI.Implementation.GeolocationInProcess>]
[Scoped<BrowserAPI.IHistory, BrowserAPI.Implementation.History>]
[Scoped<BrowserAPI.IHistoryInProcess, BrowserAPI.Implementation.HistoryInProcess>]
[Scoped<BrowserAPI.ILanguage, BrowserAPI.Implementation.Language>]
[Scoped<BrowserAPI.ILanguageInProcess, BrowserAPI.Implementation.LanguageInProcess>]
[Scoped<BrowserAPI.ILocalStorage, BrowserAPI.Implementation.LocalStorage>]
[Scoped<BrowserAPI.ILocalStorageInProcess, BrowserAPI.Implementation.LocalStorageInProcess>]
[Scoped<BrowserAPI.IMediaDevices, BrowserAPI.Implementation.MediaDevices>]
[Scoped<BrowserAPI.IMediaDevicesInProcess, BrowserAPI.Implementation.MediaDevicesInProcess>]
[Scoped<BrowserAPI.INetworkInformation, BrowserAPI.Implementation.NetworkInformation>]
[Scoped<BrowserAPI.INetworkInformationInProcess, BrowserAPI.Implementation.NetworkInformationInProcess>]
[Scoped<BrowserAPI.IPermissions, BrowserAPI.Implementation.Permissions>]
[Scoped<BrowserAPI.IPermissionsInProcess, BrowserAPI.Implementation.PermissionsInProcess>]
[Scoped<BrowserAPI.ISensorAPI, BrowserAPI.Implementation.SensorAPI>]
[Scoped<BrowserAPI.ISensorAPIInProcess, BrowserAPI.Implementation.SensorAPIInProcess>]
[Scoped<BrowserAPI.IServiceWorkerContainer, BrowserAPI.Implementation.ServiceWorkerContainer>]
[Scoped<BrowserAPI.IServiceWorkerContainerInProcess, BrowserAPI.Implementation.ServiceWorkerContainerInProcess>]
[Scoped<BrowserAPI.ISessionStorage, BrowserAPI.Implementation.SessionStorage>]
[Scoped<BrowserAPI.ISessionStorageInProcess, BrowserAPI.Implementation.SessionStorageInProcess>]
[Scoped<BrowserAPI.IWindowManagement, BrowserAPI.Implementation.WindowManagement>]
[Scoped<BrowserAPI.IWindowManagementInProcess, BrowserAPI.Implementation.WindowManagementInProcess>]
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
