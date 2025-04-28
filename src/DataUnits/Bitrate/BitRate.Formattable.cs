namespace DataUnits;

public partial struct BitRate : IFormattable
{
    public string ToString(BitUnit? unit, string? format = null, IFormatProvider? formatProvider = null)
    {
        format ??= "0.###";

        double value = BitsPerSecond;

        if (unit == null)
        {
            unit = BitUnit.Bit;

            for (int i = 0; i < BitUnit.All.Length; i++)
            {
                unit = BitUnit.All[i];
                double v = value / unit.NumberOfBits;

                if (Math.Abs(v) < BitUnit.UnitSize)
                {
                    value = v;
                    break;
                }
            }
        }
        else
        {
            value /= unit.NumberOfBits;
        }

        return $"{value.ToString(format, formatProvider)} {unit.Symbol}";
    }

    public string ToString(string? format, IFormatProvider? formatProvider = null)
    {
        return ToString(null, format, formatProvider);
    }

    public string ToString(IFormatProvider? formatProvider)
    {
        return ToString(null, null, formatProvider);
    }

    public override string ToString()
    {
        return ToString(null, null, null);
    }
}
