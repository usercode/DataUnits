namespace DataUnits;

public partial struct ByteSize
{
    public static ByteSize From(double value, ByteUnit unit)
    {
        return FromBytes((long)(value * unit.NumberOfBytes));
    }

    public static ByteSize FromBytes(long value)
    {
        return new ByteSize(value);
    }

    public static ByteSize FromKilobytes(double value)
    {
        return From(value, ByteUnit.Kilobyte);
    }

    public static ByteSize FromMegabytes(double value)
    {
        return From(value, ByteUnit.Megabyte);
    }

    public static ByteSize FromGigabytes(double value)
    {
        return From(value, ByteUnit.Gigabyte);
    }

    public static ByteSize FromTerabytes(double value)
    {
        return From(value, ByteUnit.Terabyte);
    }  
}
