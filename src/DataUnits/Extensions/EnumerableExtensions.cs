namespace DataUnits;

public static class EnumerableExtensions
{
    /// <summary>
    /// Computes the sum of a sequence of <see cref="ByteSize"/> values.
    /// </summary>
    public static ByteSize Sum(this IEnumerable<ByteSize> byteSizes)
    {
        return new ByteSize(byteSizes.Sum(x => x.Bytes));
    }
}
