using Xunit;
using System.Text.Json;

namespace DataUnits.Tests.ByteSizes;

public class JsonTests
{
    [Fact]
    public void Serialize()
    {
        string json = JsonSerializer.Serialize(ByteSize.FromKilobytes(1));

        Assert.Equal("1024", json);
    }

    [Fact]
    public void Deserialize()
    {
        ByteSize result = JsonSerializer.Deserialize<ByteSize>("1024");

        Assert.Equal(1, result.Kilobytes);
    }

    [Fact]
    public void DeserializeFormattedValue()
    {
        ByteSize result = JsonSerializer.Deserialize<ByteSize>("\"1.5 KB\"");

        Assert.Equal(1.5, result.Kilobytes);
    }
}
