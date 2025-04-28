namespace DataUnits;

/// <summary>
/// Unit for bit rates.
/// </summary>
public class BitUnit
{
    public const long UnitSize = 1000;
    public static BitUnit Bit { get; } = new BitUnit("bps", 1);
    public static BitUnit Kilobit { get; } = new BitUnit("Kbps", UnitSize);
    public static BitUnit Megabit { get; } = new BitUnit("Mbps", UnitSize * UnitSize);
    public static BitUnit Gigabit { get; } = new BitUnit("Gbps", UnitSize * UnitSize * UnitSize);
    public static BitUnit Terabit { get; } = new BitUnit("Tbps", UnitSize * UnitSize * UnitSize * UnitSize);

    public static BitUnit[] All = [Bit, Kilobit, Megabit, Gigabit, Terabit];

    public BitUnit(string symbol, long numberOfBits)
    {
        Symbol = symbol;
        NumberOfBits = numberOfBits;
    }

    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; }

    /// <summary>
    /// NumberOfBits
    /// </summary>
    public long NumberOfBits { get; }

    public override string ToString()
    {
        return $"{Symbol} ({NumberOfBits} bits)";
    }
}
