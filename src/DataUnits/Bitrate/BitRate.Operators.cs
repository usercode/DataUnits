using System.Numerics;

namespace DataUnits;

public partial struct BitRate : 
                                    IEqualityOperators<BitRate, BitRate, bool>, 
                                    IAdditionOperators<BitRate, BitRate, BitRate>, 
                                    ISubtractionOperators<BitRate, BitRate, BitRate>,
                                    IMultiplyOperators<BitRate, long, BitRate>,
                                    IMultiplyOperators<BitRate, double, BitRate>,
                                    IComparisonOperators<BitRate, BitRate, bool>
{
    public static implicit operator long(BitRate byteSize)
    {
        return byteSize.BitsPerSecond;
    }

    public static implicit operator BitRate(long bytes)
    {
        return BitRate.FromBits(bytes);
    }

    public static bool operator ==(BitRate left, BitRate right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(BitRate left, BitRate right)
    {
        return (left == right) == false;
    }

    public static bool operator >(BitRate left, BitRate right)
    {
        return left.BitsPerSecond > right.BitsPerSecond;
    }

    public static bool operator >=(BitRate left, BitRate right)
    {
        return left.BitsPerSecond >= right.BitsPerSecond;
    }

    public static bool operator <(BitRate left, BitRate right)
    {
        return left.BitsPerSecond < right.BitsPerSecond;
    }

    public static bool operator <=(BitRate left, BitRate right)
    {
        return left.BitsPerSecond <= right.BitsPerSecond;
    }

    public static BitRate operator +(BitRate left, BitRate right)
    {
        return left.Add(right);
    }

    public static BitRate operator -(BitRate left, BitRate right)
    {
        return left.Subtract(right);
    }

    public static BitRate operator *(BitRate left, long factor)
    {
        return new BitRate(left.BitsPerSecond * factor);
    }   

    public static BitRate operator *(BitRate left, double factor)
    {
        return new BitRate((long)(left.BitsPerSecond * factor));
    }

    public static ByteSize operator *(BitRate rate, TimeSpan time)
    {
        return ByteSize.FromBytes((long)(rate.BitsPerSecond / 8 * time.TotalSeconds));
    }
}
