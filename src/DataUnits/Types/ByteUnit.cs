namespace DataUnits;

/// <summary>
/// ByteUnit
/// </summary>
public class ByteUnit
{
    public const long UnitSize = 1024;
    public static ByteUnit Byte { get; } = new ByteUnit("B", 1);
    public static ByteUnit Kilobyte { get; } = new ByteUnit("KB", UnitSize);
    public static ByteUnit Megabyte { get; } = new ByteUnit("MB", UnitSize * UnitSize);
    public static ByteUnit Gigabyte { get; } = new ByteUnit("GB", UnitSize * UnitSize * UnitSize);
    public static ByteUnit Terabyte { get; } = new ByteUnit("TB", UnitSize * UnitSize * UnitSize * UnitSize);

    public static ByteUnit[] All = [Byte, Kilobyte, Megabyte, Gigabyte, Terabyte];

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

    public override string ToString()
    {
        return $"{Symbol} ({NumberOfBytes} bytes)";
    }
}
