using System.Text.Json.Serialization;

namespace BrowserAPI;

/// <summary>
/// The MediaTrackConstraints dictionary is used to describe a set of capabilities and the value or values each can take on.
/// A constraints dictionary is passed into <see href="https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrack/applyConstraints">applyConstraints()</see> to allow a script to establish a set of exact (required) values or ranges and/or preferred values or ranges of values for the track,
/// and the most recently-requested set of custom constraints can be retrieved by calling <see href="https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrack/getConstraints">getConstraints()</see>.
/// </summary>
public readonly record struct MediaTrackConstraints {
    /// <summary>
    /// A ConstrainDouble specifying the video aspect ratio or range of aspect ratios which are acceptable and/or required.
    /// </summary>
    public ConstrainDouble? AspectRatio { get; init; }

    /// <summary>
    /// A ConstrainBoolean object which specifies whether automatic gain control is preferred and/or required.
    /// </summary>
    public ConstrainBoolean? AutoGainControl { get; init; }

    /// <summary>
    /// A ConstrainULong specifying the channel count or range of channel counts which are acceptable and/or required.
    /// </summary>
    public ConstrainULong? ChannelCount { get; init; }

    /// <summary>
    /// A ConstrainDOMString object specifying a device ID or an array of device IDs which are acceptable and/or required.
    /// </summary>
    public ConstrainDOMString? DeviceId { get; init; }

    /// <summary>
    /// <para>
    /// A ConstrainDOMString which specifies the types of display surface that may be selected by the user.
    /// This may be a single one of the following strings, or a list of them to allow multiple source surfaces:
    /// </para>
    /// <para>
    /// "browser" - The stream contains the contents of a single browser tab selected by the user.<br />
    /// "monitor" - The stream's video track contains the entire contents of one or more of the user's screens.<br />
    /// "window" - The stream contains a single window selected by the user for sharing.
    /// </para>
    /// </summary>
    public ConstrainDOMString? DisplaySurface { get; init; }

    /// <summary>
    /// A ConstrainBoolean object specifying whether or not echo cancellation is preferred and/or required.
    /// </summary>
    public ConstrainBoolean? EchoCancellation { get; init; }

    /// <summary>
    /// <para>
    /// A ConstrainDOMString object specifying a facing or an array of facings which are acceptable and/or required.<br />
    /// The following strings are permitted values for the facing mode.
    /// These may represent separate cameras, or they may represent directions in which an adjustable camera can be pointed.
    /// </para>
    /// <para>
    /// "user" - The video source is facing toward the user; this includes, for example, the front-facing camera on a smartphone.<br />
    /// "environment" - The video source is facing away from the user, thereby viewing their environment. This is the back camera on a smartphone.<br />
    /// "left" - The video source is facing toward the user but to their left, such as a camera aimed toward the user but over their left shoulder.<br />
    /// "right" - The video source is facing toward the user but to their right, such as a camera aimed toward the user but over their right shoulder.
    /// </para>
    /// </summary>
    public ConstrainDOMString? FacingMode { get; init; }

    /// <summary>
    /// A ConstrainDouble specifying the frame rate or range of frame rates which are acceptable and/or required.
    /// </summary>
    public ConstrainDouble? FrameRate { get; init; }

    /// <summary>
    /// A ConstrainDOMString object specifying a group ID or an array of group IDs which are acceptable and/or required.
    /// </summary>
    public ConstrainDOMString? GroupId { get; init; }

    /// <summary>
    /// A ConstrainULong specifying the video height or range of heights which are acceptable and/or required.
    /// </summary>
    public ConstrainULong? Height { get; init; }

    /// <summary>
    /// A ConstrainBoolean which specifies whether noise suppression is preferred and/or required.
    /// </summary>
    public ConstrainBoolean? NoiseSuppression { get; init; }

    /// <summary>
    /// A ConstrainULong specifying the sample rate or range of sample rates which are acceptable and/or required.
    /// </summary>
    public ConstrainULong? SampleRate { get; init; }

    /// <summary>
    /// A ConstrainULong specifying the sample size or range of sample sizes which are acceptable and/or required.
    /// </summary>
    public ConstrainULong? SampleSize { get; init; }

    /// <summary>
    /// A ConstrainULong specifying the video width or range of widths which are acceptable and/or required.
    /// </summary>
    public ConstrainULong? Width { get; init; }
}


/// <summary>
/// <para>
/// The <i>ConstrainBoolean</i> constraint type is used to specify a constraint for a property whose value is a Boolean value.<br />
/// Its value may be:
/// </para>
/// <para>
/// <see cref="bool">bool</see> - a plain Boolean.<br />
/// <see cref="Exact(bool)">Exact</see> - A Boolean which must be the value of the property. If the property can't be set to this value, matching will fail.<br />
/// <see cref="Ideal(bool)">Ideal</see> - A Boolean specifying an ideal value for the property. If possible, this value will be used, but if it's not possible, the user agent will use the closest possible match.
/// </para>
/// </summary>
public readonly record struct ConstrainBoolean {
    [JsonInclude] internal MediaTrackConstraintPreference Preference { get; }
    [JsonInclude] internal bool Value { get; }

    private ConstrainBoolean(MediaTrackConstraintPreference preference, bool value) {
        Preference = preference;
        Value = value;
    }


    /// <summary>
    /// implicit conversion, so a plain bool can be used.
    /// </summary>
    /// <param name="value">a plain bool</param>
    public static implicit operator ConstrainBoolean(bool value) => new(MediaTrackConstraintPreference.None, value);

    /// <summary>
    /// Creates an <see cref="ConstrainBoolean"/> as an "exact" object.<br />
    /// If the property can't be set to this value, matching will fail.
    /// </summary>
    /// <param name="value">The required value.</param>
    /// <returns></returns>
    public static ConstrainBoolean Exact(bool value) => new(MediaTrackConstraintPreference.Exact, value);

    /// <summary>
    /// Creates an <see cref="ConstrainBoolean"/> as an "ideal" object.<br />
    /// If possible, this value will be used, but if it's not possible, the user agent will use the closest possible match.
    /// </summary>
    /// <param name="value">The ideal value.</param>
    /// <returns></returns>
    public static ConstrainBoolean Ideal(bool value) => new(MediaTrackConstraintPreference.Ideal, value);
}

/// <summary>
/// <para>
/// The <i>ConstrainDouble</i> constraint type is used to specify a constraint for a property whose value is a double-precision floating-point number.<br />
/// Its value may be:
/// </para>
/// <para>
/// <see cref="double">double</see> - a plain Double.<br />
/// <see cref="Exact(double)">Exact</see> - A decimal number specifying a specific, required, value the property must have to be considered acceptable.<br />
/// <see cref="Ideal(double)">Ideal</see> - A decimal number specifying an ideal value for the property. If possible, this value will be used, but if it's not possible, the user agent will use the closest possible match.<br />
/// <see cref="Ideal(double?, double?, double?)">Ideal(ideal, min, max)</see> - A decimal number specifying the smallest/largest permissible value of the property it describes. If the value cannot remain equal to or greater/less than this value, matching will fail.
/// </para>
/// </summary>
public readonly record struct ConstrainDouble {
    [JsonInclude] internal MediaTrackConstraintPreference Preference { get; }
    [JsonInclude] internal double? Value { get; }
    [JsonInclude] internal double? Min { get; }
    [JsonInclude] internal double? Max { get; }

    private ConstrainDouble(MediaTrackConstraintPreference preference, double? value, double? min, double? max) {
        Preference = preference;
        Value = value;
        Min = min;
        Max = max;
    }


    /// <summary>
    /// implicit conversion, so a plain double can be used.
    /// </summary>
    /// <param name="value">a plain double</param>
    public static implicit operator ConstrainDouble(double value) => new(MediaTrackConstraintPreference.None, value, null, null);

    /// <summary>
    /// Creates an <see cref="ConstrainDouble"/> as an "exact" object.<br />
    /// If the property can't be set to this value, matching will fail.
    /// </summary>
    /// <param name="value">A double specifying a specific, required, value the property must have to be considered acceptable.</param>
    /// <returns></returns>
    public static ConstrainDouble Exact(double value) => new(MediaTrackConstraintPreference.Exact, value, null, null);

    /// <summary>
    /// Creates an <see cref="ConstrainDouble"/> as an "ideal" object.<br />
    /// If possible, this value will be used, but if it's not possible, the user agent will use the closest possible match.
    /// </summary>
    /// <param name="value">The ideal value.</param>
    /// <returns></returns>
    public static ConstrainDouble Ideal(double value) => new(MediaTrackConstraintPreference.Ideal, value, null, null);
    /// <summary>
    /// Creates an <see cref="ConstrainDouble"/> as an "ideal-min-max" object. Each value is optional, but at least one value should be set.<br />
    /// When ideal value is specified - If possible, this value will be used, but if it's not possible, the user agent will use the closest possible match.<br />
    /// When min value is specified - If the value cannot remain equal to or greater than than this value, matching will fail.<br />
    /// When max value is specified - If the value cannot remain equal to or less than than this value, matching will fail.
    /// </summary>
    /// <param name="ideal">The ideal value.</param>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns></returns>
    public static ConstrainDouble Ideal(double? ideal, double? min, double? max) => new(MediaTrackConstraintPreference.Ideal, ideal, min, max);
}

/// <summary>
/// <para>
/// The <i>ConstrainULong</i> constraint type is used to specify a constraint for a property whose value is an integer.<br />
/// Its value may be:
/// </para>
/// <para>
/// <see cref="ulong">ulong</see> - a plain UInt64.<br />
/// <see cref="Exact(ulong)">Exact</see> - An integer specifying a specific, required, value the property must have to be considered acceptable.<br />
/// <see cref="Ideal(ulong)">Ideal</see> - An integer specifying an ideal value for the property. If possible, this value will be used, but if it's not possible, the user agent will use the closest possible match.<br />
/// <see cref="Ideal(ulong?, ulong?, ulong?)">Ideal(ideal, min, max)</see> - An integer specifying the smallest/largest permissible value of the property it describes. If the value cannot remain equal to or greater/less than this value, matching will fail.
/// </para>
/// </summary>
public readonly record struct ConstrainULong {
    [JsonInclude] internal MediaTrackConstraintPreference Preference { get; }
    [JsonInclude] internal ulong? Value { get; }
    [JsonInclude] internal ulong? Min { get; }
    [JsonInclude] internal ulong? Max { get; }

    private ConstrainULong(MediaTrackConstraintPreference preference, ulong? value, ulong? min, ulong? max) {
        Preference = preference;
        Value = value;
        Min = min;
        Max = max;
    }


    /// <summary>
    /// implicit conversion, so a plain ulong can be used.
    /// </summary>
    /// <param name="value">a plain ulong</param>
    public static implicit operator ConstrainULong(ulong value) => new(MediaTrackConstraintPreference.None, value, null, null);

    /// <summary>
    /// Creates an <see cref="ConstrainULong"/> as an "exact" object.<br />
    /// If the property can't be set to this value, matching will fail.
    /// </summary>
    /// <param name="value">A ulong specifying a specific, required, value the property must have to be considered acceptable.</param>
    /// <returns></returns>
    public static ConstrainULong Exact(ulong value) => new(MediaTrackConstraintPreference.Exact, value, null, null);

    /// <summary>
    /// Creates an <see cref="ConstrainULong"/> as an "ideal" object.<br />
    /// If possible, this value will be used, but if it's not possible, the user agent will use the closest possible match.
    /// </summary>
    /// <param name="value">The ideal value.</param>
    /// <returns></returns>
    public static ConstrainULong Ideal(ulong value) => new(MediaTrackConstraintPreference.Ideal, value, null, null);
    /// <summary>
    /// Creates an <see cref="ConstrainULong"/> as an "ideal-min-max" object. Each value is optional, but at least one value should be set.<br />
    /// When ideal value is specified - If possible, this value will be used, but if it's not possible, the user agent will use the closest possible match.<br />
    /// When min value is specified - If the value cannot remain equal to or greater than than this value, matching will fail.<br />
    /// When max value is specified - If the value cannot remain equal to or less than than this value, matching will fail.
    /// </summary>
    /// <param name="ideal">The ideal value.</param>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns></returns>
    public static ConstrainULong Ideal(ulong? ideal, ulong? min, ulong? max) => new(MediaTrackConstraintPreference.Ideal, ideal, min, max);
}

/// <summary>
/// <para>
/// The <i>ConstrainDOMString</i> constraint type is used to specify a constraint for a property whose value is a string.
/// Its value may be:
/// </para>
/// <para>
/// <see cref="string">string</see> or <see cref="string">string</see>[] - a plain String or an array of String.<br />
/// <see cref="Exact(string)">Exact</see> - A string or an array of strings, one of which must be the value of the property. If the property can't be set to one of the listed values, matching will fail.<br />
/// <see cref="Ideal(string)">Ideal</see> - A string or an array of strings, specifying ideal values for the property. If possible, one of the listed values will be used, but if it's not possible, the user agent will use the closest possible match.<br />
/// </para>
/// </summary>
public readonly record struct ConstrainDOMString {
    [JsonInclude] internal MediaTrackConstraintPreference Preference { get; }
    [JsonInclude] internal string Value { get; } = string.Empty;
    [JsonInclude] internal string[]? Values { get; }

    private ConstrainDOMString(MediaTrackConstraintPreference preference, string value) {
        Preference = preference;
        Value = value;
    }

    private ConstrainDOMString(MediaTrackConstraintPreference preference, string[] values) {
        Preference = preference;
        Values = values;
    }


    /// <summary>
    /// implicit conversion, so a plain string can be used.
    /// </summary>
    /// <param name="value">a plain string</param>
    public static implicit operator ConstrainDOMString(string value) => new(MediaTrackConstraintPreference.None, value);
    /// <summary>
    /// implicit conversion, so a plain string[] can be used.
    /// </summary>
    /// <param name="values">a plain string[]</param>
    public static implicit operator ConstrainDOMString(string[] values) => new(MediaTrackConstraintPreference.None, values);

    /// <summary>
    /// Creates an <see cref="ConstrainDOMString"/> as an "exact" object.<br />
    /// If the property can't be set to this value, matching will fail.
    /// </summary>
    /// <param name="value">The required value.</param>
    /// <returns></returns>
    public static ConstrainDOMString Exact(string value) => new(MediaTrackConstraintPreference.Exact, value);
    /// <summary>
    /// Creates an <see cref="ConstrainDOMString"/> as an "exact" object.<br />
    /// If the property can't be set to one of the listed values, matching will fail.
    /// </summary>
    /// <param name="values">The list of possible values.</param>
    /// <returns></returns>
    public static ConstrainDOMString Exact(string[] values) => new(MediaTrackConstraintPreference.Exact, values);

    /// <summary>
    /// Creates an <see cref="ConstrainDOMString"/> as an "ideal" object.<br />
    /// If possible, this value will be used, but if it's not possible, the user agent will use the closest possible match.
    /// </summary>
    /// <param name="value">The ideal value.</param>
    /// <returns></returns>
    public static ConstrainDOMString Ideal(string value) => new(MediaTrackConstraintPreference.Ideal, value);
    /// <summary>
    /// Creates an <see cref="ConstrainDOMString"/> as an "ideal" object.<br />
    /// If possible, one of the listed values will be used, but if it's not possible, the user agent will use the closest possible match.
    /// </summary>
    /// <param name="values">The list of ideal values.</param>
    /// <returns></returns>
    public static ConstrainDOMString Ideal(string[] values) => new(MediaTrackConstraintPreference.Ideal, values);
}


internal enum MediaTrackConstraintPreference {
    None = 0,
    Exact = 1,
    Ideal = 2
}
