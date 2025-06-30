using AutoInterfaceAttributes;
using Microsoft.JSInterop;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IWritableFileStream")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IWritableFileStreamInProcess")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class WritableFileStreamBase(IJSObjectReference writableFileStreamJS) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IJSObjectReference writableFileStreamJS = writableFileStreamJS;


    /// <summary>
    /// <para>Writes content into the file the method is called on, at the current file cursor offset.</para>
    /// <para>
    /// No changes are written to the actual file on disk until the stream has been closed.
    /// Changes are typically written to a temporary file instead.
    /// This method can also be used to seek to a byte point within the stream and truncate to modify the total bytes the file contains.
    /// </para>
    /// </summary>
    /// <param name="data">The file data to write</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Write(string data, CancellationToken cancellationToken = default) => writableFileStreamJS.InvokeVoidAsync("write", cancellationToken, [data]);

    /// <summary>
    /// <para>Writes content into the file the method is called on, at the current file cursor offset.</para>
    /// <para>
    /// No changes are written to the actual file on disk until the stream has been closed.
    /// Changes are typically written to a temporary file instead.
    /// This method can also be used to seek to a byte point within the stream and truncate to modify the total bytes the file contains.
    /// </para>
    /// </summary>
    /// <param name="data">The file data to write</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Write(byte[] data, CancellationToken cancellationToken = default) => writableFileStreamJS.InvokeVoidAsync("write", cancellationToken, [data]);

    /// <summary>
    /// Updates the current file cursor offset to the position (in bytes) specified.
    /// </summary>
    /// <param name="position">A number specifying the byte position from the beginning of the file.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Seek(int position, CancellationToken cancellationToken = default) => writableFileStreamJS.InvokeVoidAsync("seek", cancellationToken, [position]);

    /// <summary>
    /// <para>Resizes the file associated with the stream to be the specified size in bytes.</para>
    /// <para>If the size specified is larger than the current file size the file is padded with 0x00 bytes.</para>
    /// <para>
    /// The file cursor is also updated when truncate() is called.
    /// If the offset is smaller than the size, it remains unchanged.
    /// If the offset is larger than size, the offset is set to that size.
    /// This ensures that subsequent writes do not error.
    /// </para>
    /// <para>No changes are written to the actual file on disk until the stream has been closed. Changes are typically written to a temporary file instead.</para>
    /// </summary>
    /// <param name="size">A number specifying the number of bytes to resize the stream to.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Truncate(int size, CancellationToken cancellationToken = default) => writableFileStreamJS.InvokeVoidAsync("truncate", cancellationToken, [size]);

    /// <summary>
    /// Aborts the stream, signaling that the producer can no longer successfully write to the stream and it is to be immediately moved to an error state, with any queued writes discarded.
    /// </summary>
    /// <param name="reason">A string providing a human-readable reason for the abort.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Abort(object? reason = null, CancellationToken cancellationToken = default) => writableFileStreamJS.InvokeVoidAsync("abort", cancellationToken, [reason]);

    /// <summary>
    /// <para>Closes the associated stream. All chunks written before this method is called are sent before the returned promise is fulfilled.</para>
    /// <para>This is equivalent to getting a WritableStreamDefaultWriter with getWriter(), calling close() on it.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Close(CancellationToken cancellationToken = default) => writableFileStreamJS.InvokeVoidAsync("close", cancellationToken);
}
