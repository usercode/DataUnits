namespace DataUnits.Base;

internal interface IValue<TValue, TUnit> : IValue<TValue>
    where TValue : struct, IValue<TValue, TUnit>
    where TUnit : class, IUnit<TUnit>
{
}

internal interface IValue<TValue> : IComparable, IComparable<TValue>, IEquatable<TValue>, IFormattable, IParsable<TValue>
    where TValue : struct, IValue<TValue>
{
    abstract static TValue Create(long value);

    long Value { get; }
}
