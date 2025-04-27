namespace DataUnits;

public partial struct ByteSize : IFormattable
{
    public string ToString(ByteUnit? unit, string? format = null, IFormatProvider? formatProvider = null)
    {
        format ??= "0.###";

        double value = Bytes;

        if (unit == null)
        {
            unit = ByteUnit.Byte;

            for (int i = 0; i < ByteUnit.All.Length; i++)
            {
                unit = ByteUnit.All[i];
                double v = value / unit.NumberOfBytes;

                if (v < ByteUnit.UnitSize)
                {
                    value = v;
                    break;
                }
            }
        }
        else
        {
            value /= unit.NumberOfBytes;
        }

        return $"{value.ToString(format, formatProvider)} {unit.Symbol}";
    }

    public string ToString(string? format, IFormatProvider? formatProvider = null)
    {
        return ToString(null, format, formatProvider);
    }

    public override string ToString()
    {
        return ToString(null, null, null);
    }
}
