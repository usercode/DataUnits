using Xunit;

namespace DataUnits.Tests.BitRates;

public class BaseTests
{
    [Fact]
    public void DifferentSizes()
    {
        Assert.Equal(1, BitRate.FromBits(1).BitsPerSecond);
        Assert.Equal(1000, BitRate.FromKilobits(1).BitsPerSecond);
        Assert.Equal(1000 * 1000, BitRate.FromMegabits(1).BitsPerSecond);
        Assert.Equal(1000 * 1000 * 1000, BitRate.FromGigabits(1).BitsPerSecond);
        Assert.Equal(1000L * 1000 * 1000 * 1000, BitRate.FromTerabits(1).BitsPerSecond);
    }

    [Fact]
    public void DecimalValues()
    {
        Assert.Equal(1000 * 1.5, BitRate.FromKilobits(1.5));
    }

    [Fact]
    public void NegativeValues()
    {
        Assert.Equal(-100, BitRate.FromBits(-100).BitsPerSecond);
        Assert.Equal(-1000, BitRate.FromKilobits(-1).BitsPerSecond);
    }

    [Fact]
    public void NegativeValuesToString()
    {
        Assert.Equal("-100 bps", BitRate.FromBits(-100).ToString());
        Assert.Equal("-1 Kbps", BitRate.FromKilobits(-1).ToString());
    }

    [Fact]
    public void From()
    {
        Assert.Equal(1000 * 1.5, BitRate.From(1.5, BitUnit.Kilobit));
    }
}
