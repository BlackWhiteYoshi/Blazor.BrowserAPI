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
public readonly record struct MediaTrackSupportedConstraints {
    /// <summary>
    /// A Flag whose value is true if this constraint is supported in the current environment.
    /// </summary>
    public bool AspectRatio { get; init; }

    /// <summary>
    /// A Flag whose value is true if this constraint is supported in the current environment.
    /// </summary>
    public bool AutoGainControl { get; init; }

    /// <summary>
    /// A Flag whose value is true if this constraint is supported in the current environment.
    /// </summary>
    public bool ChannelCount { get; init; }

    /// <summary>
    /// A Flag whose value is true if this constraint is supported in the current environment.
    /// </summary>
    public bool DeviceId { get; init; }

    /// <summary>
    /// A Flag whose value is true if this constraint is supported in the current environment.
    /// </summary>
    public bool DisplaySurface { get; init; }

    /// <summary>
    /// A Flag whose value is true if this constraint is supported in the current environment.
    /// </summary>
    public bool EchoCancellation { get; init; }

    /// <summary>
    /// A Flag whose value is true if this constraint is supported in the current environment.
    /// </summary>
    public bool FacingMode { get; init; }

    /// <summary>
    /// A Flag whose value is true if this constraint is supported in the current environment.
    /// </summary>
    public bool FrameRate { get; init; }

    /// <summary>
    /// A Flag whose value is true if this constraint is supported in the current environment.
    /// </summary>
    public bool GroupId { get; init; }

    /// <summary>
    /// A Flag whose value is true if this constraint is supported in the current environment.
    /// </summary>
    public bool Height { get; init; }

    /// <summary>
    /// A Flag whose value is true if this constraint is supported in the current environment.
    /// </summary>
    public bool NoiseSuppression { get; init; }

    /// <summary>
    /// A Flag whose value is true if this constraint is supported in the current environment.
    /// </summary>
    public bool SampleRate { get; init; }

    /// <summary>
    /// A Flag whose value is true if this constraint is supported in the current environment.
    /// </summary>
    public bool SampleSize { get; init; }

    /// <summary>
    /// A Flag whose value is true if this constraint is supported in the current environment.
    /// </summary>
    public bool Width { get; init; }
}
