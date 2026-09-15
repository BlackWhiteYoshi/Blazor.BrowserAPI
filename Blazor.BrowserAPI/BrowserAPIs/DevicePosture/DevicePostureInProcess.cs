using AutoInterfaceAttributes;

namespace BrowserAPI.Implementation;

/// <summary>
/// The DevicePosture interface of the Device Posture API represents the device's posture, that is, whether the viewport is in a flat or folded state.<br />
/// It allows developers to create user interfaces that adapt to a foldable device's posture and respond to posture changes.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
public sealed class DevicePostureInProcess(IModuleManager moduleManager) : DevicePostureBase(moduleManager), IDevicePostureInProcess {
    /// <summary>
    /// A string representing the device's current posture. The value can be one of:<br/>
    /// - "continuous": Indicates a flat screen posture — this can include a foldable device while it is being used flat, a seamless curved display, or a standard desktop, laptop, tablet or mobile screen.<br/>
    /// - "folded"; Indicates a folded screen posture — this can include a foldable device being used in a book or laptop posture.
    /// </summary>
    public string Type => moduleManager.InvokeSync<string>("DevicePostureAPI.getType");
}
