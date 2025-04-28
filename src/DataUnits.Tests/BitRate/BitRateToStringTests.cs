using System.Globalization;
using Xunit;

namespace DataUnits.Tests;

public class BitRateToStringTests
{
    [Fact]
    public void Integer()
    {
        Assert.Equal("123 bps", BitRate.FromBits(123).ToString(CultureInfo.InvariantCulture));
        Assert.Equal("123 Kbps", BitRate.FromKilobits(123).ToString(CultureInfo.InvariantCulture));
        Assert.Equal("123 Mbps", BitRate.FromMegabits(123).ToString(CultureInfo.InvariantCulture));
        Assert.Equal("123 Gbps", BitRate.FromGigabits(123).ToString(CultureInfo.InvariantCulture));
    }

    [Fact]
    public void Float()
    {
        Assert.Equal("1.5 Kbps", BitRate.FromKilobits(1.5).ToString(CultureInfo.InvariantCulture));
        Assert.Equal("1.5 Mbps", BitRate.FromMegabits(1.5).ToString(CultureInfo.InvariantCulture));
        Assert.Equal("1.5 Gbps", BitRate.FromGigabits(1.5).ToString(CultureInfo.InvariantCulture));
    }

    [Fact]
    public void ExplicitUnit()
    {        
        Assert.Equal("1000 Kbps", BitRate.FromMegabits(1).ToString(BitUnit.Kilobit, null, CultureInfo.InvariantCulture));
    }
}
