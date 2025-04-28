using System.Diagnostics.CodeAnalysis;

namespace DataUnits;

public partial struct ByteSize : IEquatable<ByteSize>
{
    public bool Equals(ByteSize other)
    {
        return Bytes == other.Bytes;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is ByteSize byteSize)
        {
            return Equals(byteSize);
        }

        return false;
    }
}
