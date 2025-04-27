using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DataUnits;

public partial struct ByteSize : IParsable<ByteSize>
{
    [GeneratedRegex(@"^\s*(?<value>-?[0-9]+(\p{P}[0-9]+)?)\s*(?<symbol>[a-z]{1,2})\s*$", RegexOptions.IgnoreCase)]
    private static partial Regex Regex();

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ByteSize result)
    {
        if (s == null)
        {
            result = new ByteSize();

            return false;
        }

        Match match = Regex().Match(s);

        if (match.Success == false)
        {
            result = new ByteSize();

            return false;
        }

        if (double.TryParse(match.Groups["value"].Value, provider, out double value) == false)
        {
            result = new ByteSize();

            return false;
        }

        string symbol = match.Groups["symbol"].Value;

        //calculate the byte value
        for (int i = 0; i < ByteUnit.All.Length; i++)
        {
            if (string.Equals(symbol, ByteUnit.All[i].Symbol, StringComparison.OrdinalIgnoreCase))
            {
                value *= ByteUnit.All[i].NumberOfBytes;

                break;
            }
        }

        result = ByteSize.FromBytes((long)value);

        return true;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, [MaybeNullWhen(false)] out ByteSize result)
    {
        return TryParse(s, null, out result);
    }

    public static ByteSize Parse(string? s, IFormatProvider? provider = null)
    {
        if (TryParse(s, provider, out ByteSize result))
        {
            return result;
        }

        throw new FormatException($"Input doesn't contain valid byte size value: {s}");
    }
}
