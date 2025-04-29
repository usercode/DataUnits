using Xunit;
using System.Text.Json;

namespace DataUnits.Tests.BitRates;

public class JsonTests
{
    [Fact]
    public void Serialize()
    {
        string json = JsonSerializer.Serialize(BitRate.FromKilobits(1));

        Assert.Equal("1000", json);
    }

    [Fact]
    public void Deserialize()
    {
        BitRate result = JsonSerializer.Deserialize<BitRate>("1000");

        Assert.Equal(1, result.Kilobits);
    }

    [Fact]
    public void DeserializeFormattedValue()
    {
        BitRate result = JsonSerializer.Deserialize<BitRate>("\"1.5 Kbps\"");

        Assert.Equal(1.5, result.Kilobits);
    }
}
