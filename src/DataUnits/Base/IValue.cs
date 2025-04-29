using System.Diagnostics.CodeAnalysis;

namespace DataUnits.Base;

internal interface IValue<TValue, TUnit> : IValue<TValue>
    where TValue : struct, IValue<TValue, TUnit>
    where TUnit : IUnit<TUnit>
{
}

internal interface IValue<TValue>
    where TValue : struct, IValue<TValue>
{
    abstract static TValue Create(long value);

    abstract static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TValue value);

    long Value { get; }

    string ToString(string? format, IFormatProvider? formatProvider);
}
