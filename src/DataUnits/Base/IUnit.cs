namespace DataUnits.Base;

internal interface IUnit<T> where T : class, IUnit<T>
{
    public string Symbol { get; }
    public long LowestValue { get; }
    public abstract static long UnitSize { get; }
    public abstract static T[] All { get; }
    public abstract static T BaseUnit { get; }
}
