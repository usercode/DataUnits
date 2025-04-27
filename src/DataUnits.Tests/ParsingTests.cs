using Xunit;

namespace DataUnits.Tests;

public class ParsingTests
{
    [Fact]
    public void ParseBytes()
    {
        ByteSize.TryParse("1B", out ByteSize result);

        Assert.Equal(1, result.Bytes);
    }

    [Fact]
    public void ParseKilobytes()
    {
        ByteSize.TryParse("1KB", out ByteSize result);

        Assert.Equal(1024, result.Bytes);
    }

    [Fact]
    public void ParseMegabytes()
    {
        ByteSize.TryParse("1MB", out ByteSize result);

        Assert.Equal(1024 * 1024, result.Bytes);
    }

    [Fact]
    public void ParseGigabytes()
    {
        ByteSize.TryParse("1GB", out ByteSize result);

        Assert.Equal(1024 * 1024 * 1024, result.Bytes);
    }

    [Fact]
    public void ParseTerabytes()
    {
        ByteSize.TryParse("1TB", out ByteSize result);

        Assert.Equal(1024L * 1024 * 1024 * 1024, result.Bytes);
    }

    [Fact]
    public void ParseFloatValue()
    {
        ByteSize.TryParse($"{1.5} KB", out ByteSize result);

        Assert.Equal(1024 + 1024 / 2, result.Bytes);
    }

    [Fact]
    public void IgnoreWhiteSpaces()
    {
        ByteSize.TryParse(" 1 KB ", out ByteSize result);

        Assert.Equal(1024, result.Bytes);
    }

    [Fact]
    public void IgnoreCase()
    {
        ByteSize.TryParse("1mb", out ByteSize result);

        Assert.Equal(1024 * 1024, result.Bytes);
    }
}
