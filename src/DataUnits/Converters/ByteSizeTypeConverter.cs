using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace DataUnits;

internal class ByteSizeTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string);
    }

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (value is string stringValue)
        {
            return ByteSize.Parse(stringValue, culture);
        }

        throw new Exception();
    }

    public override bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
    {
        return destinationType == typeof(string);
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (value is ByteSize sizeValue)
        {
            return sizeValue.ToString(culture);
        }

        throw new Exception();
    }
}
