using DataUnits.Base;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DataUnits;

public partial struct BitRate : IParsable<BitRate>
{
    [GeneratedRegex(@"^\s*(?<value>-?[0-9]+(\p{P}[0-9]+)?)\s*(?<symbol>[a-z]{1,2}ps)\s*$", RegexOptions.IgnoreCase)]
    private static partial Regex Regex();

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? formatProvider, [MaybeNullWhen(false)] out BitRate value)
    {
        return Parsable.TryParse<BitRate, BitUnit>(Regex(), s, formatProvider, out value);
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
