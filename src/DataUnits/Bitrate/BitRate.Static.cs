namespace DataUnits;

public partial struct BitRate
{
    public static BitRate From(double value, BitUnit unit)
    {
        return new BitRate((long)(value * unit.Bits));
    }

    public static BitRate FromBits(long bits)
    {
        return new BitRate(bits);
    }

    public static BitRate FromKilobits(double value)
    {
        return From(value, BitUnit.Kilobit);
    }

    public static BitRate FromMegabits(double value)
    {
        return From(value, BitUnit.Megabit);
    }

    public static BitRate FromGigabits(double value)
    {
        return From(value, BitUnit.Gigabit);
    }

    public static BitRate FromTerabits(double value)
    {
        return From(value, BitUnit.Terabit);
    }
}
