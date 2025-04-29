using DataUnits.Base;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DataUnits;

public partial struct BitRate : IParsable<BitRate>
{
    [GeneratedRegex(@"^\s*(?<value>-?[0-9]+(\p{P}[0-9]+)?)\s*(?<symbol>[a-z]{1,2}ps)\s*$", RegexOptions.IgnoreCase)]
    private static partial Regex Regex();

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out BitRate result)
    {
        return Parsable.TryParse<BitRate, BitUnit>(Regex(), s, provider, out result);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, [MaybeNullWhen(false)] out BitRate result)
    {
        return TryParse(s, null, out result);
    }

    public static BitRate Parse(string? s, IFormatProvider? provider = null)
    {
        if (TryParse(s, provider, out BitRate result))
        {
            return result;
        }

        throw new FormatException($"Input doesn't contain valid byte size value: {s}");
    }
}
