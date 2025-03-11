using CSharpFunctionalExtensions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WalkSafe.Infrastructure.Converters
{

    public class ResultJsonConverter : JsonConverter<Result>
    {
        public override Result Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Implement deserialization logic if needed.
            throw new NotImplementedException("Deserialization not supported");
        }

        public override void Write(Utf8JsonWriter writer, Result value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteBoolean("IsSuccess", value.IsSuccess);
            if (value.IsFailure)
            {
                writer.WriteString("Error", value.Error);
            }

            writer.WriteEndObject();
        }
    }

}
