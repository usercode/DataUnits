# DataUnits
DataUnits allows easier handling of byte size representation. (Bytes, KB, MB, GB, TB)

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=flat-square)](https://opensource.org/licenses/MIT)
[![NuGet](https://img.shields.io/nuget/v/DataUnits.svg?style=flat-square)](https://www.nuget.org/packages/DataUnits/)

## How to use it

You can create a `ByteSize` object from bits, bytes, kilobytes, megabytes, gigabytes and terabytes.

- JsonConverter and TypeConverter are already available.

```c#
ByteSize bytes = ByteSize.FromBytes(10);
ByteSize kilobytes = ByteSize.FromKilobytes(10);
ByteSize megabytes = ByteSize.FromMegabytes(10);
ByteSize gigabytes = ByteSize.FromGigabytes(10);
ByteSize terabytes = ByteSize.FromTerabytes(10);
```

### Calculate bit rate
```c#
BitRate bitRate = ByteSize.FromBytes(1) / TimeSpan.FromSeconds(2); //4
TimeSpan time = ByteSize.FromBytes(1) / BitRate.FromBits(4); //2
ByteSize byteSize = BitRate.FromBits(8) * TimeSpan.FromSeconds(2); //2
```

### Parsable 
```c#
ByteSize bytes = ByteSize.Parse("1"); //if no size is specified, byte is used
ByteSize bytes = ByteSize.Parse("1 B");
ByteSize bytes = ByteSize.Parse("1 b"); //ignores case
ByteSize kilobytes = ByteSize.Parse("1 KB");
ByteSize gigabytes = ByteSize.Parse(" 1GB "); //ignores whitespaces
ByteSize gigabytes = ByteSize.Parse("1.1 GB", CultureInfo.Invariant);
```

### Formattable
```c#
ByteSize.FromBytes(1024).ToString(CultureInfo.InvariantCulture); // "1 KB"
ByteSize.FromKilobytes(1.5).ToString(CultureInfo.InvariantCulture); // "1.5 KB"

//use explicit unit
ByteSize.FromMegabytes(1).ToString(ByteUnit.Kilobyte, null, CultureInfo.InvariantCulture); //"1,024 KB"
```

### Comparable
```c#
bool result = ByteSize.FromBytes(1024) == ByteSize.FromKilobytes(1);
bool result = ByteSize.FromBytes(100) > ByteSize.FromKilobytes(1);
```

### Implicit operators
```c#
long value = ByteSize.FromBytes(1024); //returns byte value

ByteSize size = 1024; //use byte unit
```

### Arithmetic operations

```c#
ByteSize a = ByteSize.FromBytes(10) + ByteSize.FromMegabytes(5);
ByteSize b = ByteSize.FromMegabytes(100) - ByteSize.FromMegabytes(5);

a = a.AddTerabytes(10);
```

### JSON
```c#
JsonSerializer.Serialize(ByteSize.FromKilobytes(1)); //returns byte value as number
```

### TypeConverter

In your appsettings.json you can specify the byte size in different types:

```json
{
  "MaxContentLength": 1024
}
```

```json
{
  "MaxContentLength": "1024"
}
```

```json
{
  "MaxContentLength": "1 KB"
}
```
