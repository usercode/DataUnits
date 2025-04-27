using Xunit;

namespace DataUnits.Tests;

public class BaseTests
{
    [Fact]
    public void TestDifferentSizes()
    {
        Assert.Equal(1, ByteSize.FromBytes(1).Bytes);
        Assert.Equal(1024, ByteSize.FromKilobytes(1).Bytes);
        Assert.Equal(1024 * 1024, ByteSize.FromMegabytes(1).Bytes);
        Assert.Equal(1024 * 1024 * 1024, ByteSize.FromGigabytes(1).Bytes);
        Assert.Equal(1024L * 1024 * 1024 * 1024, ByteSize.FromTerabytes(1).Bytes);
    }

    [Fact]
    public void TestDecimalValues()
    {
        Assert.Equal(1024L * 1.5, ByteSize.FromKilobytes(1.5));
    }
}
