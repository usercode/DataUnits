using Xunit;
using System.Text.Json;

namespace DataUnits.Tests;

public class JsonTests
{
    [Fact]
    public void Serialize()
    {
        string json = JsonSerializer.Serialize(ByteSize.FromMegabytes(123));

        ByteSize result = JsonSerializer.Deserialize<ByteSize>(json);

        Assert.Equal("\"123 MB\"", json);
        Assert.Equal(123, result.Megabytes);
    }
}
