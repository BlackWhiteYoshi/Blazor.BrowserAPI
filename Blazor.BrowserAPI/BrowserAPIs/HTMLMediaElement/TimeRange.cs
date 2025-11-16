namespace BrowserAPI;

/// <summary>
/// <para>
/// When loading a media resource for use by an &lt;audio&gt; or &lt;video&gt; element, the TimeRanges interface is used for representing the time ranges of the media resource that have been buffered,
/// the time ranges that have been played, and the time ranges that are seekable.
/// </para>
/// <para>
/// Several members of HTMLMediaElement objects return a normalized TimeRanges object — which the spec describes as having the following characteristics:<br />
/// The ranges in such an object are ordered, don't overlap, and don't touch(adjacent ranges are folded into one bigger range).
/// A range can be empty(referencing just a single moment in time).
/// </para>
/// </summary>
/// <param name="Start">The time for the start of the range.</param>
/// <param name="End">The time for the end of the range.</param>
public record struct TimeRange(double Start, double End);
