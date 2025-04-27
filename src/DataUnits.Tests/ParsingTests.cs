using System.Globalization;
using Xunit;

namespace DataUnits.Tests;

public class ParsingTests
{
    [Fact]
    public void ParseBytes()
    {
        ByteSize.TryParse("1B", CultureInfo.InvariantCulture, out ByteSize result);

        Assert.Equal(1, result.Bytes);
    }

    [Fact]
    public void ParseKilobytes()
    {
        ByteSize.TryParse("1KB", CultureInfo.InvariantCulture, out ByteSize result);

        Assert.Equal(1024, result.Bytes);
    }

    [Fact]
    public void ParseMegabytes()
    {
        ByteSize.TryParse("1MB", CultureInfo.InvariantCulture, out ByteSize result);

        Assert.Equal(1024 * 1024, result.Bytes);
    }

    [Fact]
    public void ParseGigabytes()
    {
        ByteSize.TryParse("1GB", CultureInfo.InvariantCulture, out ByteSize result);

        Assert.Equal(1024 * 1024 * 1024, result.Bytes);
    }

    [Fact]
    public void ParseTerabytes()
    {
        ByteSize.TryParse("1TB", CultureInfo.InvariantCulture, out ByteSize result);

        Assert.Equal(1024L * 1024 * 1024 * 1024, result.Bytes);
    }

    [Fact]
    public void ParseFloatValue()
    {
        ByteSize.TryParse("1.5 KB", CultureInfo.InvariantCulture, out ByteSize result);

        Assert.Equal(1024 + 1024 / 2, result.Bytes);
    }

    [Fact]
    public void IgnoreWhiteSpaces()
    {
        ByteSize.TryParse(" 1 KB ", CultureInfo.InvariantCulture, out ByteSize result);

        Assert.Equal(1024, result.Bytes);
    }

    [Fact]
    public void IgnoreCase()
    {
        ByteSize.TryParse("1mb", CultureInfo.InvariantCulture, out ByteSize result);

        Assert.Equal(1024 * 1024, result.Bytes);
    }

    [Fact]
    public void NegativeValue()
    {
        Assert.Equal(-1024, ByteSize.Parse("-1 KB").Bytes);
    }
}
