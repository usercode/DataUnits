using DataUnits.Base;

namespace DataUnits;

/// <summary>
/// Unit for bit rates.
/// </summary>
public class BitUnit : IUnit<BitUnit>
{
    public static long UnitSize { get; } = 1000;
    public static BitUnit Bit { get; } = new BitUnit("bps", 1);
    public static BitUnit Kilobit { get; } = new BitUnit("Kbps", UnitSize);
    public static BitUnit Megabit { get; } = new BitUnit("Mbps", UnitSize * UnitSize);
    public static BitUnit Gigabit { get; } = new BitUnit("Gbps", UnitSize * UnitSize * UnitSize);
    public static BitUnit Terabit { get; } = new BitUnit("Tbps", UnitSize * UnitSize * UnitSize * UnitSize);
    public static BitUnit[] All { get; } = [Bit, Kilobit, Megabit, Gigabit, Terabit];
    public static BitUnit BaseUnit => Bit;

    public BitUnit(string symbol, long bits)
    {
        Symbol = symbol;
        Bits = bits;
    }

    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; }

    /// <summary>
    /// Bits
    /// </summary>
    public long Bits { get; }   

    long IUnit<BitUnit>.LowestValue => Bits;

    public override string ToString()
    {
        return $"{Symbol} ({Bits} bps)";
    }
}
