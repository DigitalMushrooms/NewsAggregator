using Application.Interfaces;
using Infrastructure.Http.TheGuardian.Builders;
using Infrastructure.Http.TheGuardian.HttpClients;
using Infrastructure.Http.TheGuardian.Options;
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

        services.AddTransient<TheGuardianUriBuilder>();
        
        return services;
    }
}