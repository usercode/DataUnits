using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DataUnits.Base;

internal static class Parsable
{
    public static bool TryParse<TValue, TUnit>(Regex regex, [NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TValue value)
        where TValue : struct, IValue<TValue, TUnit>
        where TUnit : IUnit<TUnit>
    {
        if (s == null)
        {
            value = new TValue();

            return false;
        }

        Match match = regex.Match(s);

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

        //calculate value
        TUnit? unit = TUnit.All.FirstOrDefault(x => string.Equals(symbol, x.Symbol, StringComparison.OrdinalIgnoreCase));

        if (unit == null)
        {
            value = new TValue();

            return false;
        }

        current *= unit.NumberOfLowestElements;

        value = TValue.Create((long)current);

        return true;
    }
}
