namespace DataUnits.Base;

internal static class Formattable
{
    public static string ToString<TValue, TUnit>(TValue value, TUnit? unit, string? format = null, IFormatProvider? formatProvider = null)
        where TValue : struct, IValue<TValue, TUnit>
        where TUnit : class, IUnit<TUnit>
    {
        double current = value.Value;

        if (unit == null)
        {
            unit = TUnit.BaseUnit;

            for (int i = 0; i < TUnit.All.Length; i++)
            {
                unit = TUnit.All[i];
                double v = current / unit.LowestValue;

                if (Math.Abs(v) < TUnit.UnitSize)
                {
                    current = v;
                    break;
                }
            }
        }
        else
        {
            current /= unit.LowestValue;
        }

        format ??= "###,###,###,###,##0.###";

        return $"{current.ToString(format, formatProvider)} {unit.Symbol}";
    }
}
