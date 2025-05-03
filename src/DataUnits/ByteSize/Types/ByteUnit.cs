using DataUnits.Base;

namespace DataUnits;

/// <summary>
/// Unit for byte size.
/// </summary>
public class ByteUnit : IUnit<ByteUnit>
{
    public static long UnitSize { get; } = 1024;
    public static ByteUnit Byte { get; } = new ByteUnit("B", 1);
    public static ByteUnit Kilobyte { get; } = new ByteUnit("KB", UnitSize);
    public static ByteUnit Megabyte { get; } = new ByteUnit("MB", UnitSize * UnitSize);
    public static ByteUnit Gigabyte { get; } = new ByteUnit("GB", UnitSize * UnitSize * UnitSize);
    public static ByteUnit Terabyte { get; } = new ByteUnit("TB", UnitSize * UnitSize * UnitSize * UnitSize);
    public static ByteUnit[] All { get; } = [Byte, Kilobyte, Megabyte, Gigabyte, Terabyte];
    public static ByteUnit BaseUnit => Byte;

    public ByteUnit(string symbol, long bytes)
    {
        Symbol = symbol;
        Bytes = bytes;
    }

    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; }

    /// <summary>
    /// Bytes
    /// </summary>
    public long Bytes { get; }

    long IUnit<ByteUnit>.LowestValue => Bytes;

    public override string ToString()
    {
        return $"{Symbol} ({Bytes} bytes)";
    }
}
