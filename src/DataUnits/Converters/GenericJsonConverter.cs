using DataUnits.Base;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataUnits;

internal class GenericJsonConverter<TElement> : JsonConverter<TElement>
    where TElement : struct, IElement<TElement>
{
    public override TElement Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out long bytesValue))
        {
            return TElement.Create(bytesValue);
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            string? value = reader.GetString();

            if (TElement.TryParse(value, CultureInfo.InvariantCulture, out TElement result))
            {
                return result;
            }
        }

        throw new ArgumentException();
    }

    public override void Write(Utf8JsonWriter writer, TElement value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}
