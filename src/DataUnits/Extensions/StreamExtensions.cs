namespace DataUnits;

public static class StreamExtensions
{
    /// <summary>
    /// Gets the <see cref="ByteSize" /> of a stream.
    /// </summary>
    public static ByteSize GetByteSize(this Stream stream)
    {
        return ByteSize.FromBytes(stream.Length);
    }
}
