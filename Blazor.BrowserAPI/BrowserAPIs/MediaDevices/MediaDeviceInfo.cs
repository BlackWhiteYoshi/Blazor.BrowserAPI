﻿namespace BrowserAPI;

/// <summary>
/// <para>
/// The MediaDeviceInfo interface of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/Media_Capture_and_Streams_API">Media Capture and Streams API</see>
/// contains information that describes a single media input or output device.
/// </para>
/// <para>
/// The list of devices obtained by calling <see cref="IMediaDevices.EnumerateDevices">navigator.mediaDevices.enumerateDevices()</see>
/// is an array of MediaDeviceInfo objects, one per media device.
/// </para>
/// </summary>
public readonly record struct MediaDeviceInfo {
    /// <summary>
    /// Returns a string that is an identifier for the represented device that is persisted across sessions.
    /// It is un-guessable by other applications and unique to the origin of the calling application.
    /// It is reset when the user clears cookies (for Private Browsing, a different identifier is used that is not persisted across sessions).
    /// </summary>
    public string DeviceId { get; init; }

    /// <summary>
    /// Returns a string that is a group identifier.
    /// Two devices have the same group identifier if they belong to the same physical device
    /// — for example a monitor with both a built-in camera and a microphone.
    /// </summary>
    public string GroupId { get; init; }

    /// <summary>
    /// Returns an enumerated value that is either<br />
    /// - "videoinput"<br />
    /// - "audioinput"<br />
    /// - "audiooutput"
    /// </summary>
    public string Kind { get; init; }

    /// <summary>
    /// Returns a string describing this device (for example "External USB Webcam").
    /// </summary>
    public string Label { get; init; }
}
