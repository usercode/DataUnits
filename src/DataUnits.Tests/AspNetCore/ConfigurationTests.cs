using Microsoft.Extensions.Configuration;
using Xunit;

namespace DataUnits.Tests.AspNetCore;

public class ConfigurationTests
{
    public ConfigurationTests()
    {
        ConfigurationBuilder builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        Configuration = builder.Build();
    }

    public IConfiguration Configuration { get; }

    [Fact]
    public void Read()
    {
        MyOptions? options = Configuration.GetSection("Settings").Get<MyOptions>();

        ArgumentNullException.ThrowIfNull(options);

        Assert.Equal(4096, options.MaxBytesAsNumber.Bytes);
        Assert.Equal(2048, options.MaxBytesAsString.Bytes);
        Assert.Equal(1024, options.MaxSize.Bytes);
    }
}
