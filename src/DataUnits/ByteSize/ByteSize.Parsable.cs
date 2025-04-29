using DataUnits.Base;
using System.Diagnostics.CodeAnalysis;

namespace DataUnits;

public partial struct ByteSize : IParsable<ByteSize>
{
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? formatProvider, [MaybeNullWhen(false)] out ByteSize value)
    {
        return Parsable.TryParse<ByteSize, ByteUnit>(s, formatProvider, out value);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, [MaybeNullWhen(false)] out ByteSize value)
    {
        return TryParse(s, null, out value);
    }

    public static ByteSize Parse(string? s, IFormatProvider? formatProvider = null)
    {
        if (TryParse(s, formatProvider, out ByteSize value))
        {
            return value;
        }

        throw new FormatException($"Input doesn't contain valid byte size value: {s}");
    }
}
