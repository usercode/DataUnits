namespace DataUnits.Base;

internal interface IUnit<T> where T : IUnit<T>
{
    public string Symbol { get; }
    public long NumberOfLowestElements { get; }

    public abstract static long UnitSize { get; }
    public abstract static T[] All { get; }
}
