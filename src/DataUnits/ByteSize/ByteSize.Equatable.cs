namespace DataUnits;

public partial struct ByteSize : IEquatable<ByteSize>
{
    public bool Equals(ByteSize other)
    {
        return Bytes == other.Bytes;
    }
}
