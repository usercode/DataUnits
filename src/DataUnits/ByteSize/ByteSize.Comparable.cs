namespace DataUnits;

public partial struct ByteSize : IComparable, IComparable<ByteSize>
{
    public int CompareTo(ByteSize other)
    {
        return Bytes.CompareTo(other.Bytes);
    }

    public int CompareTo(object? obj)
    {
        if (obj is ByteSize byteSize)
        {
            return CompareTo(byteSize);
        }

        throw new ArgumentException();
    }
}
