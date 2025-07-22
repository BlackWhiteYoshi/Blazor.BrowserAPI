namespace BrowserAPI;

/// <summary>
/// The GeolocationCoordinates interface represents the position and altitude of the device on Earth, as well as the accuracy with which these properties are calculated.
/// The geographic position information is provided in terms of World Geodetic System coordinates (WGS84).
/// </summary>
public readonly record struct GeolocationCoordinates {
    /// <summary>
    /// Representing the position's latitude in decimal degrees.
    /// </summary>
    public double Latitude { get; init; }

    /// <summary>
    /// Representing the position's longitude in decimal degrees.
    /// </summary>
    public double Longitude { get; init; }

    /// <summary>
    /// Representing the position's altitude in meters, relative to nominal sea level.
    /// This value can be null if the implementation cannot provide the data.
    /// </summary>
    public double? Altitude { get; init; }

    /// <summary>
    /// Representing the accuracy of the latitude and longitude properties, expressed in meters.
    /// </summary>
    public double Accuracy { get; init; }

    /// <summary>
    /// Representing the accuracy of the altitude expressed in meters. This value can be null if the implementation cannot provide the data.
    /// </summary>
    public double? AltitudeAccuracy { get; init; }

    /// <summary>
    /// Representing the direction towards which the device is facing.
    /// This value, specified in degrees, indicates how far off from heading true north the device is.
    /// 0 degrees represents true north, and the direction is determined clockwise (which means that east is 90 degrees and west is 270 degrees).
    /// If speed is 0, heading is NaN. If the device is unable to provide heading information, this value is null.
    /// </summary>
    public double? Heading { get; init; }

    /// <summary>
    /// Representing the velocity of the device in meters per second.
    /// This value can be null.
    /// </summary>
    public double? Speed { get; init; }

    /// <summary>
    /// A timestamp, given as Unix time in milliseconds, representing the time at which the location was retrieved.
    /// </summary>
    public long Timestamp { get; init; }
}
