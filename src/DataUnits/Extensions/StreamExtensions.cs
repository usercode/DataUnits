namespace DataUnits;

public static class StreamExtensions
{
    public static ByteSize GetByteSize(this Stream stream)
    {
        return ByteSize.FromBytes(stream.Length);
    }
}
