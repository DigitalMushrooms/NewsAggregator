using Application.Common.Mappings;
using AutoMapper;

namespace Application.UnitTests.Common.Mappings;

public class MapperConfigurationTests
{
    private readonly IConfigurationProvider _configuration;

    public MapperConfigurationTests()
    {
        _configuration = new MapperConfiguration(config => 
            config.AddProfile<MappingProfile>());
    }
    
    [Fact]
    public void AssertConfigurationIsValid_ShouldHaveValidConfiguration_ReturnsWithoutException()
    {
        _configuration.AssertConfigurationIsValid();
    }
}