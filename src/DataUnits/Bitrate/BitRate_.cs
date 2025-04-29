using DataUnits.Base;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DataUnits;

/// <summary>
/// Represents bits per seconds
/// </summary>
[JsonConverter(typeof(GenericJsonConverter<BitRate>))]
[TypeConverter(typeof(GenericTypeConverter<BitRate>))]
public readonly partial struct BitRate : IElement<BitRate, BitUnit>
{
    private BitRate(long bitsPerSecond)
    {
        BitsPerSecond = bitsPerSecond;
    }

    long IElement<BitRate>.Value => BitsPerSecond;

    static BitRate IElement<BitRate>.Create(long value) => new BitRate(value);
    
    /// <summary>
    /// Bits per seconds.
    /// </summary>
    public long BitsPerSecond { get; }

    /// <summary>
    /// Gets the number of kilobits.
    /// </summary>
    public double Kilobits => (double)BitsPerSecond / BitUnit.Kilobit.NumberOfBits;

    /// <summary>
    /// Gets the number of megabits.
    /// </summary>
    public double Megabits => (double)BitsPerSecond / BitUnit.Megabit.NumberOfBits;

    /// <summary>
    /// Gets the number of gigabits.
    /// </summary>
    public double Gigabits => (double)BitsPerSecond / BitUnit.Gigabit.NumberOfBits;

    /// <summary>
    /// Gets the number of terabits.
    /// </summary>
    public double Terabits => (double)BitsPerSecond / BitUnit.Terabit.NumberOfBits;

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
