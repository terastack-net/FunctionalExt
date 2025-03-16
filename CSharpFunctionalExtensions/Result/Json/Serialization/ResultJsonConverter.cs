#nullable enable
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpFunctionalExtensions.Json.Serialization
{
    internal class ResultJsonConverter : JsonConverter<Return>
    {
        public override Return Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return ToResult(JsonSerializer.Deserialize<ResultDto>(ref reader, options));
            }
            catch (JsonException)
            {
                return Return.Failure(DtoMessages.ContentJsonNotResult);
            }
        }

        public override void Write(Utf8JsonWriter writer, Return value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, ToResultDto(value), options);

        private static Return ToResult(ResultDto? resultDto)
        => resultDto is not null
            ? resultDto.IsSuccess ? Return.Success() : Return.Failure(resultDto.Error)
            : Return.Failure(DtoMessages.ContentJsonNotResult);

        private static ResultDto ToResultDto(Return result)
        => result.IsSuccess ? ResultDto.Success() : ResultDto.Failure(result.Error);
    }
}
