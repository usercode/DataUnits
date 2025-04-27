using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace DataUnits;

/// <summary>
/// Represents a byte size value.
/// </summary>
[JsonConverter(typeof(ByteSizeJsonConverter))]
[TypeConverter(typeof(ByteSizeTypeConverter))]
public readonly partial struct ByteSize
{
    private ByteSize(long bytes)
    {
        Bytes = bytes;
    }

    /// <summary>
    /// Gets the number of bytes.
    /// </summary>
    public long Bytes { get; }

    /// <summary>
    /// Gets the number of kilobytes
    /// </summary>
    public double Kilobytes => (double)Bytes / ByteUnit.Kilobyte.NumberOfBytes;

    /// <summary>
    /// Gets the number of megabytes
    /// </summary>
    public double Megabytes => (double)Bytes / ByteUnit.Megabyte.NumberOfBytes;

    /// <summary>
    /// Gets the number of gigabytes
    /// </summary>
    public double Gigabytes => (double)Bytes / ByteUnit.Gigabyte.NumberOfBytes;

    /// <summary>
    /// Gets the number of terabytes
    /// </summary>
    public double Terabytes => (double)Bytes / ByteUnit.Terabyte.NumberOfBytes;

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

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is ByteSize byteSize)
        {
            return Equals(byteSize);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Bytes.GetHashCode();
    }
}
