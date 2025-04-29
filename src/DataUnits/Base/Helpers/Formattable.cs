namespace DataUnits.Base;

internal static class Formattable
{
    public static string ToString<TElement, TUnit>(TElement element, TUnit? unit, string? format = null, IFormatProvider? formatProvider = null)
        where TElement : struct, IElement<TElement, TUnit>
        where TUnit : IUnit<TUnit>
    {
        format ??= "0.###";

        double value = element.Value;

        if (unit == null)
        {
            unit = TUnit.All[0];

            for (int i = 0; i < TUnit.All.Length; i++)
            {
                unit = TUnit.All[i];
                double v = value / unit.NumberOfLowestElements;

                if (Math.Abs(v) < TUnit.UnitSize)
                {
                    value = v;
                    break;
                }
            }
        }
        else
        {
            value /= unit.NumberOfLowestElements;
        }

        return $"{value.ToString(format, formatProvider)} {unit.Symbol}";
    }
}
