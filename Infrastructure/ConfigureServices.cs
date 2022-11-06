using Application.Interfaces;
using Infrastructure.Http.Builders;
using Infrastructure.Http.HttpClients;
using Infrastructure.Http.Options;
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

        services.AddTransient<GuardianUriBuilder>();
        
        return services;
    }
}