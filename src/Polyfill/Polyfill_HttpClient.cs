﻿// <auto-generated />

#pragma warning disable

#if ((NETFRAMEWORK && HTTPREFERENCED) || NETSTANDARD || NETCOREAPP2X || NETCOREAPP3X)

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Link = System.ComponentModel.DescriptionAttribute;

static partial class Polyfill
{
    /// <summary>
    /// Send a GET request to the specified Uri and return the response body as a stream in an asynchronous operation.
    /// </summary>
    /// <remarks>
    /// This operation will not block. The returned <see cref="Task{Stream}"/> object will complete after the response headers are read.
    /// This method does not read nor buffer the response body.
    /// </remarks>
    /// <param name="requestUri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getstreamasync#system-net-http-httpclient-getstreamasync(system-string-system-threading-cancellationtoken)")]
    public static async Task<Stream> GetStreamAsync(
        this HttpClient target,
        string requestUri,
        CancellationToken cancellationToken = default)
    {
        try
        {
            // Must not be disposed for the stream to be usable
            var response = await target.GetAsync(
                requestUri,
                HttpCompletionOption.ResponseHeadersRead,
                cancellationToken
            ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        }
        // Older versions of HttpClient methods don't propagate the cancellation token inside the exception
        catch (OperationCanceledException ex) when (
            ex.CancellationToken != cancellationToken &&
            cancellationToken.IsCancellationRequested)
        {
            throw new OperationCanceledException(ex.Message, ex.InnerException, cancellationToken);
        }
    }

    /// <summary>
    /// Send a GET request to the specified Uri and return the response body as a stream in an asynchronous operation.
    /// </summary>
    /// <remarks>
    /// This operation will not block. The returned <see cref="Task{Stream}"/> object will complete after the response headers are read.
    /// This method does not read nor buffer the response body.
    /// </remarks>
    /// <param name="requestUri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getstreamasync#system-net-http-httpclient-getstreamasync(system-uri-system-threading-cancellationtoken)")]
    public static Task<Stream> GetStreamAsync(
        this HttpClient target,
        Uri requestUri,
        CancellationToken cancellationToken = default) =>
        target.GetStreamAsync(requestUri.ToString(), cancellationToken);

    /// <summary>
    /// Send a GET request to the specified Uri and return the response body as a byte array in an asynchronous operation.
    /// </summary>
    /// <remarks>
    /// This operation will not block. The returned Task{Byte[]} object will complete after the response headers are read.
    /// This method does not read nor buffer the response body.
    /// </remarks>
    /// <param name="requestUri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getbytearrayasync#system-net-http-httpclient-getbytearrayasync(system-string-system-threading-cancellationtoken)")]
    public static async Task<byte[]> GetByteArrayAsync(
        this HttpClient target,
        string requestUri,
        CancellationToken cancellationToken = default)
    {
        try
        {
            using var response = await target.GetAsync(
                requestUri,
                HttpCompletionOption.ResponseHeadersRead,
                cancellationToken
            ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);
        }
        // Older versions of HttpClient methods don't propagate the cancellation token inside the exception
        catch (OperationCanceledException exception) when (
            exception.CancellationToken != cancellationToken &&
            cancellationToken.IsCancellationRequested)
        {
            throw new OperationCanceledException(exception.Message, exception.InnerException, cancellationToken);
        }
    }

    /// <summary>
    /// Send a GET request to the specified Uri and return the response body as a byte array in an asynchronous operation.
    /// </summary>
    /// <remarks>
    /// This operation will not block. The returned Task{byte[]} object will complete after the response headers are read.
    /// This method does not read nor buffer the response body.
    /// </remarks>
    /// <param name="requestUri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getbytearrayasync#system-net-http-httpclient-getbytearrayasync(system-uri-system-threading-cancellationtoken)")]
    public static Task<byte[]> GetByteArrayAsync(
        this HttpClient target,
        Uri requestUri,
        CancellationToken cancellationToken = default) =>
        target.GetByteArrayAsync(requestUri.ToString(), cancellationToken);

    /// <summary>
    /// Send a GET request to the specified Uri and return the response body as a string in an asynchronous operation.
    /// </summary>
    /// <remarks>
    /// This operation will not block. The returned <see cref="Task{String}"/> object will complete after the response headers are read.
    /// This method does not read nor buffer the response body.
    /// </remarks>
    /// <param name="requestUri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getstringasync#system-net-http-httpclient-getstringasync(system-string-system-threading-cancellationtoken)")]
    public static async Task<string> GetStringAsync(
        this HttpClient target,
        string requestUri,
        CancellationToken cancellationToken = default)
    {
        try
        {
            using var response = await target.GetAsync(
                requestUri,
                HttpCompletionOption.ResponseHeadersRead,
                cancellationToken
            ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        }
        // Older versions of HttpClient methods don't propagate the cancellation token inside the exception
        catch (OperationCanceledException exception) when (
            exception.CancellationToken != cancellationToken &&
            cancellationToken.IsCancellationRequested)
        {
            throw new OperationCanceledException(exception.Message, exception.InnerException, cancellationToken);
        }
    }

    /// <summary>
    /// Send a GET request to the specified Uri and return the response body as a string in an asynchronous operation.
    /// </summary>
    /// <remarks>
    /// This operation will not block. The returned <see cref="Task{String}"/> object will complete after the response headers are read.
    /// This method does not read nor buffer the response body.
    /// </remarks>
    /// <param name="requestUri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getstringasync#system-net-http-httpclient-getstringasync(system-uri-system-threading-cancellationtoken)")]
    public static Task<string> GetStringAsync(
        this HttpClient target,
        Uri requestUri,
        CancellationToken cancellationToken = default) =>
        target.GetStringAsync(requestUri.ToString(), cancellationToken);
}
#endif