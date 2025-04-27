using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataUnits
{
    internal class ByteSizeJsonConverter : JsonConverter<ByteSize>
    {
        public override ByteSize Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out long bytesValue))
            {
                return ByteSize.FromBytes(bytesValue);
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                string? value = reader.GetString();

                return ByteSize.Parse(value, CultureInfo.InvariantCulture);
            }

            throw new ArgumentException();
        }

        public override void Write(Utf8JsonWriter writer, ByteSize value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Bytes);
        }
    }
}
