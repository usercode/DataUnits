using System.Globalization;
using Xunit;

namespace DataUnits.Tests.BitRates;

public class ParsingTests
{
    [Fact]
    public void ParseBytes()
    {
        BitRate.TryParse("1bps", CultureInfo.InvariantCulture, out BitRate result);

        Assert.Equal(1, result.BitsPerSecond);
    }

    [Fact]
    public void ParseKilobytes()
    {
        BitRate.TryParse("1Kbps", CultureInfo.InvariantCulture, out BitRate result);

        Assert.Equal(1000, result.BitsPerSecond);
    }

    [Fact]
    public void ParseMegabytes()
    {
        BitRate.TryParse("1Mbps", CultureInfo.InvariantCulture, out BitRate result);

        Assert.Equal(1000 * 1000, result.BitsPerSecond);
    }

    [Fact]
    public void ParseGigabytes()
    {
        BitRate.TryParse("1Gbps", CultureInfo.InvariantCulture, out BitRate result);

        Assert.Equal(1000 * 1000 * 1000, result.BitsPerSecond);
    }

    [Fact]
    public void ParseTerabytes()
    {
        BitRate.TryParse("1Tbps", CultureInfo.InvariantCulture, out BitRate result);

        Assert.Equal(1000L * 1000 * 1000 * 1000, result.BitsPerSecond);
    }

    [Fact]
    public void ParseFloatValue()
    {
        BitRate.TryParse("1.5 Kbps", CultureInfo.InvariantCulture, out BitRate result);

        Assert.Equal(1000 + 1000 / 2, result.BitsPerSecond);
    }

    [Fact]
    public void IgnoreWhiteSpaces()
    {
        BitRate.TryParse(" 1 Kbps ", CultureInfo.InvariantCulture, out BitRate result);

        Assert.Equal(1000, result.BitsPerSecond);
    }

    [Fact]
    public void IgnoreCase()
    {
        BitRate.TryParse("1mbps", CultureInfo.InvariantCulture, out BitRate result);

        Assert.Equal(1000 * 1000, result.BitsPerSecond);
    }

    [Fact]
    public void NegativeValue()
    {
        Assert.Equal(-1000, BitRate.Parse("-1 Kbps", CultureInfo.InvariantCulture).BitsPerSecond);
    }

    [Fact]
    public void PositiveValue()
    {
        Assert.Equal(1000, BitRate.Parse("+1 Kbps", CultureInfo.InvariantCulture).BitsPerSecond);
    }
}
