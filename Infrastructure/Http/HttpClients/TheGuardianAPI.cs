using Application.Interfaces;
using Infrastructure.Http.Options;
using Microsoft.Extensions.Options;

namespace Infrastructure.Http.HttpClients;

public class TheGuardianApi : ITheGuardianApi
{
    private readonly HttpClient _httpClient;

    public TheGuardianApi(HttpClient httpClient, IOptions<HttpClientOptions> options)
    {
        HttpClientOptions options1 = options.Value;

        httpClient.BaseAddress = new Uri(options1.Url);
        
        _httpClient = httpClient;
    }
}