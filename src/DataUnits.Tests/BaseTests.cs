using Xunit;

namespace DataUnits.Tests;

public class BaseTests
{
    [Fact]
    public void DifferentSizes()
    {
        Assert.Equal(1, ByteSize.FromBytes(1).Bytes);
        Assert.Equal(1024, ByteSize.FromKilobytes(1).Bytes);
        Assert.Equal(1024 * 1024, ByteSize.FromMegabytes(1).Bytes);
        Assert.Equal(1024 * 1024 * 1024, ByteSize.FromGigabytes(1).Bytes);
        Assert.Equal(1024L * 1024 * 1024 * 1024, ByteSize.FromTerabytes(1).Bytes);
    }

    [Fact]
    public void DecimalValues()
    {
        Assert.Equal(1024L * 1.5, ByteSize.FromKilobytes(1.5));
    }

    [Fact]
    public void NegativeValues()
    {
        Assert.Equal(-100, ByteSize.FromBytes(-100).Bytes);
        Assert.Equal(-1024, ByteSize.FromKilobytes(-1).Bytes);
    }

    [Fact]
    public void NegativeValuesToString()
    {
        Assert.Equal("-100 B", ByteSize.FromBytes(-100).ToString());
        Assert.Equal("-1 KB", ByteSize.FromKilobytes(-1).ToString());
    }

    [Fact]
    public void From()
    {
        Assert.Equal(1024L * 1.5, ByteSize.From(1.5, ByteUnit.Kilobyte));
    }
}
