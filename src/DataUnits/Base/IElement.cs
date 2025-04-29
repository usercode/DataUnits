using System.Diagnostics.CodeAnalysis;

namespace DataUnits.Base;

internal interface IElement<TELement, TUnit> : IElement<TELement>
    where TELement : struct, IElement<TELement, TUnit>
    where TUnit : IUnit<TUnit>
{
}

internal interface IElement<TELement>
    where TELement : struct, IElement<TELement>
{
    abstract static TELement Create(long value);

    abstract static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TELement result);

    long Value { get; }

    string ToString(string? format, IFormatProvider? formatProvider);
}
