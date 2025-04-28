using Xunit;

namespace DataUnits.Tests;

public class BitRateTests
{
    [Fact]
    public void CalculateBitRate()
    {
        BitRate bitRate = ByteSize.FromBytes(1) / TimeSpan.FromSeconds(2);

        Assert.Equal(4, bitRate.BitsPerSecond);
    }

    [Fact]
    public void CalculateTime()
    {
        TimeSpan time = ByteSize.FromBytes(1) / BitRate.FromBits(4);

        Assert.Equal(2, time.TotalSeconds);
    }

    [Fact]
    public void CalculateByteSize()
    {
        ByteSize byteSize = BitRate.FromBits(8) * TimeSpan.FromSeconds(2);

        Assert.Equal(2, byteSize.Bytes);
    }
}
