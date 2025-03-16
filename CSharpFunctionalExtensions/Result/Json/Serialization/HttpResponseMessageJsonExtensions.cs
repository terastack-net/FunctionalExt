#nullable enable
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Json.Serialization
{
    public static class HttpResponseMessageJsonExtensions
    {
        public static async Task<Return> ReadResultAsync(this HttpResponseMessage response, bool ensureSuccessStatusCode = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (response is null)
            {
                return Return.Failure(DtoMessages.HttpResponseMessageIsNull);
            }

            if (ensureSuccessStatusCode && !response.IsSuccessStatusCode)
            {
                return Return.Failure(DtoMessages.NotSuccessStatusCodeFormat(response.StatusCode, await response.Content.ReadAsStringAsync()));
            }

            return await
            Return.Try(() => response.Content.ReadFromJsonAsync<Return>(CSharpFunctionalExtensionsJsonSerializerOptions.Options, cancellationToken), ex => new Exception( DtoMessages.ContentJsonNotResult) )
                  .Bind(result => result);
        }

        public static async Task<Return<T>> ReadResultAsync<T>(this HttpResponseMessage response, bool ensureSuccessStatusCode = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (response is null)
            {
                return Return.Failure<T>(DtoMessages.HttpResponseMessageIsNull);
            }

            if (ensureSuccessStatusCode && !response.IsSuccessStatusCode)
            {
                return Return.Failure<T>(DtoMessages.NotSuccessStatusCodeFormat(response.StatusCode, await response.Content.ReadAsStringAsync()));
            }

            return await
            Return.Try(() => response.Content.ReadFromJsonAsync<Return<T>>(CSharpFunctionalExtensionsJsonSerializerOptions.Options, cancellationToken), ex => new Exception(DtoMessages.ContentJsonNotResult))
                  .Bind(result => result);
        }

        public static async Task<Return<T, E>> ReadResultAsync<T, E>(this HttpResponseMessage response, bool ensureSuccessStatusCode = true, CancellationToken cancellationToken = default(CancellationToken))
            where E : new()
        {
            if (response is null ||
                (ensureSuccessStatusCode && !response.IsSuccessStatusCode))
            {
                return Return.Failure<T, E>(new());
            }

            try
            {
                return await response.Content.ReadFromJsonAsync<Return<T, E>>(CSharpFunctionalExtensionsJsonSerializerOptions.Options, cancellationToken);
            }
            catch (JsonException)
            {
                return Return.Failure<T, E>(new());
            }
        }

        public static async Task<UnitResult<E>> ReadUnitResultAsync<E>(this HttpResponseMessage? response, bool ensureSuccessStatusCode = true, CancellationToken cancellationToken = default(CancellationToken))
            where E : new()
        {
            if (response is null ||
                (ensureSuccessStatusCode && !response.IsSuccessStatusCode))
            {
                return UnitResult.Failure<E>(new());
            }

            try
            {
                return await response.Content.ReadFromJsonAsync<UnitResult<E>>(CSharpFunctionalExtensionsJsonSerializerOptions.Options, cancellationToken);
            }
            catch (JsonException)
            {
                return UnitResult.Failure<E>(new());
            }
        }
    }
}
