using DataUnits.Base;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace DataUnits;

internal class GenericTypeConverter<TElement> : TypeConverter
    where TElement : struct, IElement<TElement>
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string);
    }

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (value is string stringValue)
        {
            if (TElement.TryParse(stringValue, culture, out TElement result))
            {
                return result;
            }
        }

        throw new Exception();
    }

    public override bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
    {
        return destinationType == typeof(string);
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (value is TElement sizeValue)
        {
            return sizeValue.ToString(null, culture);
        }

        throw new Exception();
    }
}
