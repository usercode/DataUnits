using System.Diagnostics.CodeAnalysis;

namespace DataUnits;

public partial struct BitRate : IEquatable<BitRate>
{
    public bool Equals(BitRate other)
    {
        return BitsPerSecond == other.BitsPerSecond;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is BitRate bitRate)
        {
            return Equals(bitRate);
        }

        return false;
    }
}
