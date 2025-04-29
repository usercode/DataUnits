using DataUnits.Base;

namespace DataUnits;

public partial struct ByteSize : IFormattable
{
    public string ToString(ByteUnit? unit, string? format = null, IFormatProvider? formatProvider = null)
    {
        return Formattable.ToString(this, unit, format, formatProvider);
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
