namespace BrowserAPI;

/// <summary>
/// <para>A DOMRect describes the size and position of a rectangle.</para>
/// <para>
/// The type of box represented by the DOMRect is specified by the method or property that returned it.
/// For example, Range.getBoundingClientRect() specifies the rectangle that bounds the content of the range using such objects.
/// </para>
/// </summary>
public readonly record struct DOMRect {
    /// <summary>
    /// The x coordinate of the DOMRect's origin (typically the top-left corner of the rectangle).
    /// </summary>
    public double X { get; init; }

    /// <summary>
    /// The y coordinate of the DOMRect's origin (typically the top-left corner of the rectangle).
    /// </summary>
    public double Y { get; init; }

    /// <summary>
    /// The width of the DOMRect.
    /// </summary>
    public double Width { get; init; }

    /// <summary>
    /// The height of the DOMRect.
    /// </summary>
    public double Height { get; init; }

    /// <summary>
    /// Returns the top coordinate value of the DOMRect (has the same value as y, or y + height if height is negative).
    /// </summary>
    public double Top { get; init; }

    /// <summary>
    /// Returns the bottom coordinate value of the DOMRect (has the same value as y + height, or y if height is negative).
    /// </summary>
    public double Bottom { get; init; }

    /// <summary>
    /// Returns the left coordinate value of the DOMRect (has the same value as x, or x + width if width is negative).
    /// </summary>
    public double Left { get; init; }

    /// <summary>
    /// Returns the right coordinate value of the DOMRect (has the same value as x + width, or x if width is negative).
    /// </summary>
    public double Right { get; init; }
}
