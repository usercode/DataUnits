using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataUnits
{
    internal class ByteSizeJsonConverter : JsonConverter<ByteSize>
    {
        public override ByteSize Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return ByteSize.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, ByteSize value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
