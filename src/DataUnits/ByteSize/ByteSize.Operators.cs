using System.Numerics;

namespace DataUnits;

public partial struct ByteSize : 
                                    IEqualityOperators<ByteSize, ByteSize, bool>, 
                                    IAdditionOperators<ByteSize, ByteSize, ByteSize>, 
                                    ISubtractionOperators<ByteSize, ByteSize, ByteSize>,
                                    IMultiplyOperators<ByteSize, long, ByteSize>,
                                    IMultiplyOperators<ByteSize, double, ByteSize>,
                                    IComparisonOperators<ByteSize, ByteSize, bool>
{
    public static implicit operator long(ByteSize byteSize)
    {
        return byteSize.Bytes;
    }

    public static implicit operator ByteSize(long bytes)
    {
        return ByteSize.FromBytes(bytes);
    }

    public static bool operator ==(ByteSize left, ByteSize right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ByteSize left, ByteSize right)
    {
        return (left == right) == false;
    }

    public static bool operator >(ByteSize left, ByteSize right)
    {
        return left.Bytes > right.Bytes;
    }

    public static bool operator >=(ByteSize left, ByteSize right)
    {
        return left.Bytes >= right.Bytes;
    }

    public static bool operator <(ByteSize left, ByteSize right)
    {
        return left.Bytes < right.Bytes;
    }

    public static bool operator <=(ByteSize left, ByteSize right)
    {
        return left.Bytes <= right.Bytes;
    }

    public static ByteSize operator +(ByteSize left, ByteSize right)
    {
        return left.Add(right);
    }

    public static ByteSize operator -(ByteSize left, ByteSize right)
    {
        return left.Subtract(right);
    }

    public static ByteSize operator *(ByteSize left, long factor)
    {
        return new ByteSize(left.Bytes * factor);
    }   

    public static ByteSize operator *(ByteSize left, double factor)
    {
        return new ByteSize((long)(left.Bytes * factor));
    }

    public static BitRate operator /(ByteSize size, TimeSpan time)
    {
        return BitRate.FromBits((long)(size.Bytes * 8 / time.TotalSeconds));
    }

    public static TimeSpan operator /(ByteSize size, BitRate rate)
    {
        return TimeSpan.FromSeconds((double)size.Bytes * 8 / rate.BitsPerSecond);
    }
}
