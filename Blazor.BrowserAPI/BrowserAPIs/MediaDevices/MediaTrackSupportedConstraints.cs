namespace BrowserAPI;

/// <summary>
/// <para>
/// The <i>MediaTrackSupportedConstraints</i> dictionary establishes the list of constrainable properties recognized by the user agent or browser in its implementation of the MediaStreamTrack object.
/// An object conforming to MediaTrackSupportedConstraints is returned by <see cref="IMediaDevices.GetSupportedConstraints"/>.
/// </para>
/// <para>
/// Because of the way interface definitions in WebIDL work, if a constraint is requested but not supported, no error will occur.
/// Instead, the specified constraints will be applied, with any unrecognized constraints stripped from the request.
/// That can lead to confusing and hard to debug errors, so be sure to use getSupportedConstraints() to retrieve this information before attempting to establish constraints
/// if you need to know the difference between silently ignoring a constraint and a constraint being accepted.
/// </para>
/// <para>n actual constraint set is described using an object based on the MediaTrackConstraints dictionary.</para>
/// <para>To learn more about how constraints work, see <see href="https://developer.mozilla.org/en-US/docs/Web/API/Media_Capture_and_Streams_API/Constraints">Capabilities, constraints, and settings</see>.</para>
/// </summary>
/// <param name="AspectRatio">A Flag whose value is true if this constraint is supported in the current environment.</param>
/// <param name="AutoGainControl">A Flag whose value is true if this constraint is supported in the current environment.</param>
/// <param name="ChannelCoun">A Flag whose value is true if this constraint is supported in the current environment.</param>
/// <param name="DeviceId">A Flag whose value is true if this constraint is supported in the current environment.</param>
/// <param name="DisplaySurface">A Flag whose value is true if this constraint is supported in the current environment.</param>
/// <param name="EchoCancellation">A Flag whose value is true if this constraint is supported in the current environment.</param>
/// <param name="FacingMode">A Flag whose value is true if this constraint is supported in the current environment.</param>
/// <param name="FrameRate">A Flag whose value is true if this constraint is supported in the current environment.</param>
/// <param name="GroupId">A Flag whose value is true if this constraint is supported in the current environment.</param>
/// <param name="Height">A Flag whose value is true if this constraint is supported in the current environment.</param>
/// <param name="NoiseSuppression">A Flag whose value is true if this constraint is supported in the current environment.</param>
/// <param name="SampleRate">A Flag whose value is true if this constraint is supported in the current environment.</param>
/// <param name="SampleSize">A Flag whose value is true if this constraint is supported in the current environment.</param>
/// <param name="Width">A Flag whose value is true if this constraint is supported in the current environment.</param>
public readonly record struct MediaTrackSupportedConstraints(bool AspectRatio, bool AutoGainControl, bool ChannelCoun, bool DeviceId, bool DisplaySurface, bool EchoCancellation, bool FacingMode,
    bool FrameRate, bool GroupId, bool Height, bool NoiseSuppression, bool SampleRate, bool SampleSize, bool Width);
