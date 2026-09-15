using AutoInterfaceAttributes;

namespace BrowserAPI.Implementation;

/// <summary>
/// The DevicePosture interface of the Device Posture API represents the device's posture, that is, whether the viewport is in a flat or folded state.<br />
/// It allows developers to create user interfaces that adapt to a foldable device's posture and respond to posture changes.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
public sealed class DevicePosture(IModuleManager moduleManager) : DevicePostureBase(moduleManager), IDevicePosture {
    /// <summary>
    /// A string representing the device's current posture. The value can be one of:<br />
    /// - "continuous": Indicates a flat screen posture — this can include a foldable device while it is being used flat, a seamless curved display, or a standard desktop, laptop, tablet or mobile screen.<br />
    /// - "folded"; Indicates a folded screen posture — this can include a foldable device being used in a book or laptop posture.
    /// </summary>
    public ValueTask<string> Type => GetType(CancellationToken.None);

    /// <inheritdoc cref="Type" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetType(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("DevicePostureAPI.getType", cancellationToken);
}
