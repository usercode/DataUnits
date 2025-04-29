using DataUnits.Base;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DataUnits;

public partial struct ByteSize : IParsable<ByteSize>
{
    [GeneratedRegex(@"^\s*(?<value>-?[0-9]+(\p{P}[0-9]+)?)\s*(?<symbol>[a-z]{1,2})\s*$", RegexOptions.IgnoreCase)]
    private static partial Regex Regex();

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ByteSize value)
    {
        return Parsable.TryParse<ByteSize, ByteUnit>(Regex(), s, provider, out value);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, [MaybeNullWhen(false)] out ByteSize value)
    {
        return TryParse(s, null, out value);
    }

    public static ByteSize Parse(string? s, IFormatProvider? provider = null)
    {
        if (TryParse(s, provider, out ByteSize value))
        {
            return value;
        }

        throw new FormatException($"Input doesn't contain valid byte size value: {s}");
    }
}
