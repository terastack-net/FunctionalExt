using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.Json.Serialization;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace C2i.Common.C2iCSharpFunctionalExtensions.FunctionalApiResult
{
    internal class ResultOfTEJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType) return false;

            return typeToConvert.GetGenericTypeDefinition() == typeof(Return<,>);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type wrappedValue = typeToConvert.GetGenericArguments()[0];
            Type wrappedError = typeToConvert.GetGenericArguments()[1];

            var genericResultType = typeof(ResultOfTEJsonConverterConverterOfT<,>).MakeGenericType(wrappedValue, wrappedError);
            JsonConverter? converter = Activator.CreateInstance(genericResultType) as JsonConverter;

            return converter!;
        }
    }

    internal class ResultOfTEJsonConverterConverterOfT<TValue, TError> : JsonConverter<Return<TValue, TError>>
    {
        public override Return<TValue, TError> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return ToResultTE(JsonSerializer.Deserialize<ResultDto<TValue, TError>>(ref reader, options));
            }
            catch (JsonException)
            {
                return Return.Failure<TValue, TError>(default!);
            }
        }

        public override void Write(Utf8JsonWriter writer, Return<TValue, TError> value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, ToResultTEDto(value), options);

        private static Return<TValue, TError> ToResultTE(ResultDto<TValue, TError>? resultDto)
            => resultDto is not null
               ? resultDto.IsSuccess
                 ? Return.Success<TValue, TError>(resultDto.Value)
                 : Return.Failure<TValue, TError>(resultDto.Error)
               : Return.Failure<TValue, TError>(default!);

        private static ResultDto<TValue, TError> ToResultTEDto(Return<TValue, TError> result)
        => result.IsSuccess
           ? ResultDto.Success<TValue, TError>(result.Value)
           : ResultDto.Failure<TValue, TError>(result.Error);
    }
}
