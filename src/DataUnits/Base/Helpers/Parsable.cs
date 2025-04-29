using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DataUnits.Base;

internal static class Parsable
{
    public static bool TryParse<TElement, TUnit>(Regex regex, [NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TElement result)
        where TElement : struct, IElement<TElement, TUnit>
        where TUnit : IUnit<TUnit>
    {
        if (s == null)
        {
            result = new TElement();

            return false;
        }

        Match match = regex.Match(s);

        if (match.Success == false)
        {
            result = new TElement();

            return false;
        }

        if (double.TryParse(match.Groups["value"].Value, provider, out double value) == false)
        {
            result = new TElement();

            return false;
        }

        string symbol = match.Groups["symbol"].Value;

        //calculate value
        for (int i = 0; i < TUnit.All.Length; i++)
        {
            if (string.Equals(symbol, TUnit.All[i].Symbol, StringComparison.OrdinalIgnoreCase))
            {
                value *= TUnit.All[i].NumberOfLowestElements;

                break;
            }
        }

        result = TElement.Create((long)value);

        return true;
    }
}
