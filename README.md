# DataUnits
DataUnits allows easier handling of byte size representation. (Bytes, KB, MB, GB, TB)

## How to use it

You can create a `ByteSize` object from Bits, Bytes, Kilobytes, Megabytes, Gigabytes and Terabytes.

```c#
var bytes = ByteSize.FromBytes(10);
var kilobytes = ByteSize.FromKilobytes(10);
var megabytes = ByteSize.FromMegabytes(10);
var gigabytes = ByteSize.FromGigabytes(10);
var terabytes = ByteSize.FromTerabytes(10);
```
### Parsing 

```c#
var kilobytes = ByteSize.Parse("1 KB");
var gigabytes = ByteSize.Parse(" 1GB "); //ignores whitespaces between value and unit
var gigabytes = ByteSize.Parse("1.1 GB", CultureInfo.Invariant);
```

### Arithmetic operations

```c#
var a = ByteSize.FromBytes(10) + ByteSize.FromMegabytes(5);
var b = ByteSize.FromMegabytes(100) - ByteSize.FromMegabytes(5);

a = a.AddTerabytes(10);
```
