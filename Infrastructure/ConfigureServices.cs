using Application.Interfaces;
using Infrastructure.HttpClients;
using Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOptions<HttpClientOptions>().Bind(configuration.GetSection(HttpClientOptions.TheGuardianSection));
        
        services.AddHttpClient<ITheGuardianApi, TheGuardianApi>();
        
        return services;
    }
}