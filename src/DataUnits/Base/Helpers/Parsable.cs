using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DataUnits.Base;

internal static partial class Parsable
{
    [GeneratedRegex(@"^\s*(?<value>[+-]?[0-9.,]+)\s*(?<symbol>[a-z]{0,4})\s*$", RegexOptions.IgnoreCase)]
    private static partial Regex Regex();

    public static bool TryParse<TValue, TUnit>([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TValue value)
        where TValue : struct, IValue<TValue, TUnit>
        where TUnit : class, IUnit<TUnit>
    {
        if (s == null)
        {
            value = new TValue();

            return false;
        }

        Match match = Regex().Match(s);

        if (match.Success == false)
        {
            value = new TValue();

            return false;
        }

        if (double.TryParse(match.Groups["value"].ValueSpan, provider, out double current) == false)
        {
            value = new TValue();

            return false;
        }

        ReadOnlySpan<char> symbol = match.Groups["symbol"].ValueSpan;

        TUnit? unit = null;

        if (symbol.Length == 0)
        {
            //use base unit
            unit = TUnit.BaseUnit;
        }
        else
        {
            //find unit by symbol
            for (int i = 0; i < TUnit.All.Length; i++)
            {
                if (symbol.Equals(TUnit.All[i].Symbol, StringComparison.OrdinalIgnoreCase))
                {
                    unit = TUnit.All[i];
                    break;
                }
            }

            if (unit == null)
            {
                value = new TValue();

                return false;
            }
        }

        current *= unit.LowestValue;

        value = TValue.Create((long)current);

        return true;
    }
}
