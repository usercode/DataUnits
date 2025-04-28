using System.Globalization;
using Xunit;

namespace DataUnits.Tests;

public class ToStringTests
{
    [Fact]
    public void Integer()
    {
        Assert.Equal("123 B", ByteSize.FromBytes(123).ToString(CultureInfo.InvariantCulture));
        Assert.Equal("1001 B", ByteSize.FromBytes(1001).ToString(CultureInfo.InvariantCulture));
        Assert.Equal("123 KB", ByteSize.FromKilobytes(123).ToString(CultureInfo.InvariantCulture));
        Assert.Equal("123 MB", ByteSize.FromMegabytes(123).ToString(CultureInfo.InvariantCulture));
        Assert.Equal("123 GB", ByteSize.FromGigabytes(123).ToString(CultureInfo.InvariantCulture));
        Assert.Equal("123 TB", ByteSize.FromTerabytes(123).ToString(CultureInfo.InvariantCulture));
    }

    [Fact]
    public void Float()
    {
        Assert.Equal("1.5 KB", ByteSize.FromKilobytes(1.5).ToString(CultureInfo.InvariantCulture));
        Assert.Equal("1.5 MB", ByteSize.FromMegabytes(1.5).ToString(CultureInfo.InvariantCulture));
        Assert.Equal("1.5 GB", ByteSize.FromGigabytes(1.5).ToString(CultureInfo.InvariantCulture));
        Assert.Equal("1.5 TB", ByteSize.FromTerabytes(1.5).ToString(CultureInfo.InvariantCulture));
    }

    [Fact]
    public void ExplicitUnit()
    {
        Assert.Equal("1024 KB", ByteSize.FromMegabytes(1).ToString(ByteUnit.Kilobyte, null, CultureInfo.InvariantCulture));
    }
}
