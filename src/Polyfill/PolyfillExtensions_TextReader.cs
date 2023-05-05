#pragma warning disable

// ReSharper disable RedundantUsingDirective
// ReSharper disable UnusedMember.Global

using System;
using System.IO;
using System.Runtime.InteropServices;
using Description = System.ComponentModel.DescriptionAttribute;
using System.Threading;
using System.Threading.Tasks;
// ReSharper disable RedundantAttributeSuffix

static partial class PolyfillExtensions
{
#if TASKSEXTENSIONSREFERENCED && (NETFRAMEWORK || NETSTANDARD2_0 || NETCOREAPP2_0)
    /// <summary>
    /// Asynchronously reads the characters from the current stream into a memory block.
    /// </summary>
    /// <param name="buffer">
    /// When this method returns, contains the specified memory block of characters replaced by the characters read
    /// from the current source.
    /// </param>
    /// <param name="cancellationToken">
    /// The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.
    /// </param>
    /// <returns>
    /// A value task that represents the asynchronous read operation. The value of the type parameter of the value task
    /// contains the number of characters that have been read, or 0 if at the end of the stream and no data was read.
    /// The number will be less than or equal to the <paramref name="buffer"/> length, depending on whether the data is
    /// available within the stream.
    /// </returns>
    [Description("https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader.readasync#system-io-textreader-readasync(system-memory((system-char))-system-threading-cancellationtoken)")]
    public static ValueTask<int> ReadAsync(
        this TextReader target,
        Memory<char> buffer,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (!MemoryMarshal.TryGetArray((ReadOnlyMemory<char>)buffer, out var segment))
        {
            segment = new(buffer.ToArray());
        }

        return new(target.ReadAsync(segment.Array!, segment.Offset, segment.Count));
    }
#endif

#if !NET7_0_OR_GREATER
    /// <summary>
    /// Reads all characters from the current position to the end of the stream asynchronously and returns them as one string.
    /// </summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous read operation. The value of the <c>TResult</c> parameter contains
    /// a string with the characters from the current position to the end of the stream.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The number of characters is larger than <see cref="int.MaxValue"/>.</exception>
    /// <exception cref="ObjectDisposedException">The stream reader has been disposed.</exception>
    /// <exception cref="InvalidOperationException">The reader is currently in use by a previous read operation.</exception>
    [Description("https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader.readtoendasync#system-io-textreader-readtoendasync(system-threading-cancellationtoken)")]
    public static Task<string> ReadToEndAsync(
        this TextReader target,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return target.ReadToEndAsync();
    }
#endif
}