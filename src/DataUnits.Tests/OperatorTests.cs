using Xunit;

namespace DataUnits.Tests;

public class OperatorTests
{
    [Fact]
    public void ImplicitCast()
    {
        Assert.Equal(123, ByteSize.FromBytes(123));
    }

    [Fact]
    public void Add()
    {
        Assert.Equal(2, ByteSize.FromBytes(1) + ByteSize.FromBytes(1));
    }

    [Fact]
    public void Subtract()
    {
        Assert.Equal(2, ByteSize.FromBytes(3) - ByteSize.FromBytes(1));
    }

    [Fact]
    public void Equal()
    {
        Assert.True(ByteSize.FromBytes(1) == ByteSize.FromBytes(1));
        Assert.False(ByteSize.FromBytes(1) == ByteSize.FromBytes(2));
    }

    [Fact]
    public void NotEqual()
    {
        Assert.True(ByteSize.FromBytes(1) != ByteSize.FromBytes(2));
        Assert.False(ByteSize.FromBytes(1) != ByteSize.FromBytes(1));
    }

    [Fact]
    public void GreaterThan()
    {
        Assert.True(ByteSize.FromBytes(2) > ByteSize.FromBytes(1));
        Assert.False(ByteSize.FromBytes(1) > ByteSize.FromBytes(2));
    }

    [Fact]
    public void SmallerThan()
    {
        Assert.True(ByteSize.FromBytes(1) < ByteSize.FromBytes(2));
        Assert.False(ByteSize.FromBytes(2) < ByteSize.FromBytes(1));
    }
}
