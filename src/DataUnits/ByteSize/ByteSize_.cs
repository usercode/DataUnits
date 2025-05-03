using DataUnits.Base;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DataUnits;

/// <summary>
/// Represents a byte size value.
/// </summary>
[JsonConverter(typeof(GenericJsonConverter<ByteSize>))]
[TypeConverter(typeof(GenericTypeConverter<ByteSize>))]
public readonly partial struct ByteSize : IValue<ByteSize, ByteUnit>
{
    private ByteSize(long bytes)
    {
        Bytes = bytes;
    }

    long IValue<ByteSize>.Value => Bytes;

    static ByteSize IValue<ByteSize>.Create(long value) => new ByteSize(value);
    
    /// <summary>
    /// Gets the number of bytes.
    /// </summary>
    public long Bytes { get; }

    /// <summary>
    /// Gets the number of kilobytes.
    /// </summary>
    public double Kilobytes => (double)Bytes / ByteUnit.Kilobyte.Bytes;

    /// <summary>
    /// Gets the number of megabytes.
    /// </summary>
    public double Megabytes => (double)Bytes / ByteUnit.Megabyte.Bytes;

    /// <summary>
    /// Gets the number of gigabytes.
    /// </summary>
    public double Gigabytes => (double)Bytes / ByteUnit.Gigabyte.Bytes;

    /// <summary>
    /// Gets the number of terabytes.
    /// </summary>
    public double Terabytes => (double)Bytes / ByteUnit.Terabyte.Bytes;

    public ByteSize Add(ByteSize value)
    {
        return new ByteSize(Bytes + value.Bytes);
    }

    public ByteSize AddBytes(long value)
    {
        return Add(ByteSize.FromBytes(value));
    }

    public ByteSize AddKilobytes(long value)
    {
        return Add(ByteSize.FromKilobytes(value));
    }

    public ByteSize AddMegabytes(long value)
    {
        return Add(ByteSize.FromMegabytes(value));
    }

    public ByteSize AddGigabytes(long value)
    {
        return Add(ByteSize.FromGigabytes(value));
    }

    public ByteSize AddTerabytes(long value)
    {
        return Add(ByteSize.FromTerabytes(value));
    }

    public ByteSize Subtract(ByteSize value)
    {
        return new ByteSize(Bytes - value.Bytes);
    }   

    public override int GetHashCode()
    {
        return Bytes.GetHashCode();
    }    
}
