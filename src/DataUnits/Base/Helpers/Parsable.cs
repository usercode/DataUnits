using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DataUnits.Base;

internal static partial class Parsable
{
    [GeneratedRegex(@"^\s*(?<value>-?[0-9]+(\p{P}[0-9]+)?)\s*(?<symbol>[a-z]{0,4})?\s*$", RegexOptions.IgnoreCase)]
    private static partial Regex Regex();

    public static bool TryParse<TValue, TUnit>([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TValue value)
        where TValue : struct, IValue<TValue, TUnit>
        where TUnit : IUnit<TUnit>
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

        if (double.TryParse(match.Groups["value"].Value, provider, out double current) == false)
        {
            value = new TValue();

            return false;
        }

        string symbol = match.Groups["symbol"].Value;

        TUnit? unit;

        if (string.IsNullOrEmpty(symbol))
        {
            unit = TUnit.All[0];
        }
        else
        {
            unit = TUnit.All.FirstOrDefault(x => string.Equals(symbol, x.Symbol, StringComparison.OrdinalIgnoreCase));

            if (unit == null)
            {
                value = new TValue();

                return false;
            }
        }

        current *= unit.NumberOfLowestValue;

        value = TValue.Create((long)current);

        return true;
    }
}
