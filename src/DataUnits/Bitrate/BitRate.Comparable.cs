namespace DataUnits;

public partial struct BitRate : IComparable, IComparable<BitRate>
{
    public int CompareTo(BitRate other)
    {
        return BitsPerSecond.CompareTo(other.BitsPerSecond);
    }

    public int CompareTo(object? obj)
    {
        if (obj is BitRate byteSize)
        {
            return CompareTo(byteSize);
        }

        throw new ArgumentException();
    }
}
