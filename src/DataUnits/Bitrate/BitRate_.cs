using System.Diagnostics.CodeAnalysis;

namespace DataUnits;

/// <summary>
/// Represents bits per seconds
/// </summary>
public readonly partial struct BitRate
{
    private BitRate(long bitsPerSecond)
    {
        BitsPerSecond = bitsPerSecond;
    }

    /// <summary>
    /// Bits per seconds
    /// </summary>
    public long BitsPerSecond { get; }    

    public override int GetHashCode()
    {
        return BitsPerSecond.GetHashCode();
    }

    public BitRate Add(BitRate value)
    {
        return new BitRate(BitsPerSecond + value.BitsPerSecond);
    }

    public BitRate AddKilobits(double value)
    {
        return Add(BitRate.FromKilobits(value));
    }

    public BitRate AddMegabits(double value)
    {
        return Add(BitRate.FromMegabits(value));
    }

    public BitRate AddGigabits(double value)
    {
        return Add(BitRate.FromGigabits(value));
    }

    public BitRate AddTerabits(double value)
    {
        return Add(BitRate.FromTerabits(value));
    }

    public BitRate Subtract(BitRate value)
    {
        return new BitRate(BitsPerSecond - value.BitsPerSecond);
    }
}
