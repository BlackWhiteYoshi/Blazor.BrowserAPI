using AutoInterfaceAttributes;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The NetworkInformation interface of the Network Information API provides information about the connection a device is using to communicate with the network and provides a means for scripts to be notified if the connection type changes.
/// The NetworkInformation interface cannot be instantiated. It is instead accessed through the connection property of the Navigator interface or the WorkerNavigator interface.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class NetworkInformation(IModuleManager moduleManager) : NetworkInformationBase(moduleManager), INetworkInformation {
    /// <summary>
    /// <para>
    /// The onLine property of the Navigator interface returns whether the device is connected to the network, with true meaning online and false meaning offline.
    /// The property's value changes after the browser checks its network connection, usually when the user follows links or when a script requests a remote page.
    /// For example, the property should return false when users click links soon after they lose internet connection.
    /// When its value changes, an online or offline event is fired on the window.
    /// </para>
    /// <para>
    /// Browsers and operating systems leverage different heuristics to determine whether the device is online.
    /// In general, connection to LAN is considered online, even though the LAN may not have Internet access.
    /// For example, the computer may be running a virtualization software that has virtual ethernet adapters that are always "connected".
    /// On Windows, the online status is determined by whether it can reach a Microsoft home server, which may be blocked by firewalls or VPNs, even if the computer has Internet access.
    /// Therefore, this property is inherently unreliable, and you should not disable features based on the online status, only provide hints when the user may seem offline.
    /// </para>
    /// </summary>
    public ValueTask<bool> OnLine => GetOnLine(default);

    /// <inheritdoc cref="OnLine" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetOnLine(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("NetworkInformationAPI.getOnLine", cancellationToken);



    /// <summary>
    /// Returns the effective bandwidth estimate in megabits per second, rounded to the nearest multiple of 25 kilobits per seconds.
    /// This value is based on recently observed application layer throughput across recently active connections, excluding connections made to a private address space.
    /// In the absence of recent bandwidth measurement data, the attribute value is determined by the properties of the underlying connection technology.
    /// </summary>
    public ValueTask<double> Downlink => GetDownlink(default);

    /// <inheritdoc cref="Downlink" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetDownlink(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<double>("NetworkInformationAPI.getDownlink", cancellationToken);


    /// <summary>
    /// Returns the maximum downlink speed, in megabits per second (Mbps), for the underlying connection technology.
    /// </summary>
    public ValueTask<double> DownlinkMax => GetDownlinkMax(default);

    /// <inheritdoc cref="DownlinkMax" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetDownlinkMax(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<double>("NetworkInformationAPI.getDownlinkMax", cancellationToken);


    /// <summary>
    /// Returns the effective type of the connection meaning one of 'slow-2g', '2g', '3g', or '4g'.
    /// This value is determined using a combination of recently observed round-trip time and downlink values.
    /// </summary>
    public ValueTask<string> EffectiveType => GetEffectiveType(default);

    /// <inheritdoc cref="EffectiveType" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetEffectiveType(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("NetworkInformationAPI.getEffectiveType", cancellationToken);


    /// <summary>
    /// Returns the type of connection a device is using to communicate with the network. It will be one of the following values:<br />
    /// "bluetooth", "cellular", "ethernet", "none", "wifi", "wimax", "other", "unknown"
    /// </summary>
    public ValueTask<string> Type => GetType(default);

    /// <inheritdoc cref="Type" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetType(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("NetworkInformationAPI.getType", cancellationToken);


    /// <summary>
    /// Returns the estimated effective round-trip time of the current connection, rounded to the nearest multiple of 25 milliseconds.
    /// This value is based on recently observed application-layer RTT measurements across recently active connections.
    /// It excludes connections made to a private address space.
    /// If no recent measurement data is available, the value is based on the properties of the underlying connection technology.
    /// </summary>
    public ValueTask<int> RTT => GetRTT(default);

    /// <inheritdoc cref="RTT" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetRTT(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("NetworkInformationAPI.getRTT", cancellationToken);


    /// <summary>
    /// Returns true if the user has set a reduced data usage option on the user agent.
    /// </summary>
    public ValueTask<bool> SaveData => GetSaveData(default);

    /// <inheritdoc cref="SaveData" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetSaveData(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("NetworkInformationAPI.getSaveData", cancellationToken);
}
