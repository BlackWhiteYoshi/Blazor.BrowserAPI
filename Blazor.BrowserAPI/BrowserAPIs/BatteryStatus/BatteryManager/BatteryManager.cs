using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>
/// Provides information about the system's battery charge level.
/// The <see cref="IBatteryStatus.GetBattery"/> method returns a promise that resolves with a BatteryManager interface.
/// </para>
/// <para>Since Chrome 103, the BatteryManager interface of Battery Status API only expose to secure context.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="DisposeAsync"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class BatteryManager(IJSObjectReference batteryManagerJS) : BatteryManagerBase(batteryManagerJS), IBatteryManager {
    /// <summary>
    /// Releases the JS instance for this Manager.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() {
        DisposeEventTrigger();
        return batteryManagerJS.DisposeTrySync();
    }


    /// <summary>
    /// Indicating whether the battery is currently being charged.
    /// </summary>
    public ValueTask<bool> Charging => GetCharging(CancellationToken.None);

    /// <inheritdoc cref="Charging" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetCharging(CancellationToken cancellationToken) => batteryManagerJS.InvokeTrySync<bool>("getCharging", cancellationToken);


    /// <summary>
    /// Representing the remaining time in seconds until the battery is fully charged, or 0 if the battery is already fully charged.
    /// </summary>
    public ValueTask<double> ChargingTime => GetChargingTime(CancellationToken.None);

    /// <inheritdoc cref="ChargingTime" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<double> GetChargingTime(CancellationToken cancellationToken) => await batteryManagerJS.InvokeTrySync<double?>("getChargingTime", cancellationToken) ?? double.PositiveInfinity;


    /// <summary>
    /// Representing the remaining time in seconds until the battery is completely discharged and the system suspends.
    /// </summary>
    public ValueTask<double> DischargingTime => GetDischargingTime(CancellationToken.None);

    /// <inheritdoc cref="DischargingTime" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<double> GetDischargingTime(CancellationToken cancellationToken) => await batteryManagerJS.InvokeTrySync<double?>("getDischargingTime", cancellationToken) ?? double.PositiveInfinity;


    /// <summary>
    /// Representing the system's battery charge level scaled to a value between 0.0 and 1.0.
    /// </summary>
    public ValueTask<double> Level => GetLevel(CancellationToken.None);

    /// <inheritdoc cref="Level" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetLevel(CancellationToken cancellationToken) => batteryManagerJS.InvokeTrySync<double>("getLevel", cancellationToken);
}
