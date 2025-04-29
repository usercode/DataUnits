using DataUnits.Base;
using System.Diagnostics.CodeAnalysis;

namespace DataUnits;

public partial struct BitRate : IParsable<BitRate>
{
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? formatProvider, [MaybeNullWhen(false)] out BitRate value)
    {
        return Parsable.TryParse<BitRate, BitUnit>(s, formatProvider, out value);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, [MaybeNullWhen(false)] out BitRate value)
    {
        return TryParse(s, null, out value);
    }

    public static BitRate Parse(string? s, IFormatProvider? formatProvider = null)
    {
        if (TryParse(s, formatProvider, out BitRate value))
        {
            return value;
        }

        throw new FormatException($"Input doesn't contain valid byte size value: {s}");
    }
}
