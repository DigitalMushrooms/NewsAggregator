using Application.Interfaces;
using Infrastructure.Http.TheGuardian.Builders;
using Infrastructure.Http.TheGuardian.Models;
using Newtonsoft.Json;

namespace Infrastructure.Http.TheGuardian.HttpClients;

public class TheGuardianApi : ITheGuardianApi
{
    private readonly HttpClient _httpClient;
    private readonly TheGuardianUriBuilder _uriBuilder;

    public TheGuardianApi(HttpClient httpClient, TheGuardianUriBuilder uriBuilder)
    {
        _httpClient = httpClient;
        _uriBuilder = uriBuilder;
    }

    public async Task GetContent()
    {
        string url = _uriBuilder.Build();
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        HttpResponseMessage response = await _httpClient.SendAsync(request);
        
        await using Stream responseContent = await response.Content.ReadAsStreamAsync();
        response.EnsureSuccessStatusCode();

        using var streamReader = new StreamReader(responseContent);
        using var jsonTextReader = new JsonTextReader(streamReader);    
        var jsonSerializer = new JsonSerializer();
        var deserializedResponse = jsonSerializer.Deserialize<ResponseWrapper>(jsonTextReader);
        // TODO: Create domain type and returns it.
    }
}