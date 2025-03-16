#nullable enable
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpFunctionalExtensions.Json.Serialization
{
    internal class ResultOfTJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType) return false;

            return typeToConvert.GetGenericTypeDefinition() == typeof(Return<>);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type wrappedType = typeToConvert.GetGenericArguments()[0];

            var genericResultType = typeof(ResultOfTJsonConverter<>).MakeGenericType(wrappedType);
            JsonConverter? converter = Activator.CreateInstance(genericResultType) as JsonConverter;

            return converter!;
        }
    }

    internal class ResultOfTJsonConverter<T> : JsonConverter<Return<T>>
    {
        public override Return<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return ToResult(JsonSerializer.Deserialize<ResultDto<T>>(ref reader, options));
            }
            catch (JsonException)
            {
                return Return.Failure<T>(DtoMessages.ContentJsonNotResult);
            }
        }

        public override void Write(Utf8JsonWriter writer, Return<T> value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, ToResultDto(value), options);

        private static Return<T> ToResult(ResultDto<T>? resultDto)
        {
            if (resultDto is not null)
            {
                if (resultDto.IsSuccess)
                {
                    return Return.Success<T>(resultDto.Value!);
                }

                if (resultDto.Error is not null)
                {
                    return Return.Failure<T>(resultDto.Error);
                }

                return Return.Failure<T>("ResultDto was not successful and ErrorMessage is null");
            }

            return Return.Failure<T>(DtoMessages.ContentJsonNotResult);
        }

        private static ResultDto<T> ToResultDto(Return<T> result)
        => result.IsSuccess
           ? ResultDto.Success<T>(result.Value)
           : ResultDto.Failure<T>(result.Error);
    }
}
