using Xunit;

namespace DataUnits.Tests;

public class BitRateOperatorTests
{
    [Fact]
    public void ImplicitCast()
    {
        Assert.Equal(123, BitRate.FromBits(123));
    }

    [Fact]
    public void Add()
    {
        Assert.Equal(2, BitRate.FromBits(1) + BitRate.FromBits(1));
    }

    [Fact]
    public void Subtract()
    {
        Assert.Equal(2, BitRate.FromBits(3) - BitRate.FromBits(1));
    }

    [Fact]
    public void Equal()
    {
        Assert.True(BitRate.FromBits(1) == BitRate.FromBits(1));
        Assert.False(BitRate.FromBits(1) == BitRate.FromBits(2));
    }

    [Fact]
    public void NotEqual()
    {
        Assert.True(BitRate.FromBits(1) != BitRate.FromBits(2));
        Assert.False(BitRate.FromBits(1) != BitRate.FromBits(1));
    }

    [Fact]
    public void GreaterThan()
    {
        Assert.True(BitRate.FromBits(2) > BitRate.FromBits(1));
        Assert.False(BitRate.FromBits(1) > BitRate.FromBits(2));
    }

    [Fact]
    public void SmallerThan()
    {
        Assert.True(BitRate.FromBits(1) < BitRate.FromBits(2));
        Assert.False(BitRate.FromBits(2) < BitRate.FromBits(1));
    }
}
