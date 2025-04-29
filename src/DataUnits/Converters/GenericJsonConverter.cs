using DataUnits.Base;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataUnits;

internal class GenericJsonConverter<TValue> : JsonConverter<TValue>
    where TValue : struct, IValue<TValue>
{
    public override TValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out long bytesValue))
        {
            return TValue.Create(bytesValue);
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            string? value = reader.GetString();

            if (TValue.TryParse(value, CultureInfo.InvariantCulture, out TValue result))
            {
                return result;
            }
        }

        throw new ArgumentException();
    }

    public override void Write(Utf8JsonWriter writer, TValue value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}
