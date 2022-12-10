using Microsoft.AspNetCore.Mvc.Testing;

namespace DigitalMushrooms.NewsAggregator.FunctionalTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    
}