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

    public ByteUnit(string symbol, long numberOfBytes)
    {
        Symbol = symbol;
        NumberOfBytes = numberOfBytes;
    }

    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; }

    /// <summary>
    /// NumberOfBytes
    /// </summary>
    public long NumberOfBytes { get; }

    long IUnit<ByteUnit>.NumberOfLowestElements => NumberOfBytes;

    public override string ToString()
    {
        return $"{Symbol} ({NumberOfBytes} bytes)";
    }
}
