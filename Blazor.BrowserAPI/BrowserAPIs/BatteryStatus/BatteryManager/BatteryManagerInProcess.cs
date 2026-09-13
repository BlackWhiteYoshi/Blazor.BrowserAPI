using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>
/// Provides information about the system's battery charge level.
/// The <see cref="IBatteryStatusInProcess.GetBattery"/> method returns a promise that resolves with a BatteryManager interface.
/// </para>
/// <para>Since Chrome 103, the BatteryManager interface of Battery Status API only expose to secure context.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="Dispose"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class BatteryManagerInProcess(IJSInProcessObjectReference batteryManagerJS) : BatteryManagerBase(batteryManagerJS), IBatteryManagerInProcess {
    private IJSInProcessObjectReference BatteryManagerJS => (IJSInProcessObjectReference)this.batteryManagerJS;

    /// <summary>
    /// Releases the JS instance for this Manager.
    /// </summary>
    /// <returns></returns>
    public void Dispose() {
        DisposeEventTrigger();
        BatteryManagerJS.Dispose();
    }


    /// <summary>
    /// Indicating whether the battery is currently being charged.
    /// </summary>
    public bool Charging => BatteryManagerJS.Invoke<bool>("getCharging");

    /// <summary>
    /// Representing the remaining time in seconds until the battery is fully charged, or 0 if the battery is already fully charged.
    /// </summary>
    public double ChargingTime => BatteryManagerJS.Invoke<double?>("getChargingTime") ?? double.PositiveInfinity;

    /// <summary>
    /// Representing the remaining time in seconds until the battery is completely discharged and the system suspends.
    /// </summary>
    public double DischargingTime => BatteryManagerJS.Invoke<double?>("getDischargingTime") ?? double.PositiveInfinity;

    /// <summary>
    /// Representing the system's battery charge level scaled to a value between 0.0 and 1.0.
    /// </summary>
    public double Level => BatteryManagerJS.Invoke<double>("getLevel");
}
