using Application.Interfaces;
using Infrastructure.Http.Builders;
using Newtonsoft.Json;

namespace Infrastructure.Http.HttpClients;

public class TheGuardianApi : ITheGuardianApi
{
    private readonly HttpClient _httpClient;
    private readonly GuardianUriBuilder _builder;

    public TheGuardianApi(HttpClient httpClient, GuardianUriBuilder builder)
    {
        _httpClient = httpClient;
        _builder = builder;
    }

    public async Task GetContent()
    {
        string url = _builder.Build();
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        HttpResponseMessage response = await _httpClient.SendAsync(request);
        
        await using Stream responseContent = await response.Content.ReadAsStreamAsync();
        response.EnsureSuccessStatusCode();

        using var streamReader = new StreamReader(responseContent);
        using var jsonTextReader = new JsonTextReader(streamReader);    
        var jsonSerializer = new JsonSerializer();
        // TODO: Finish the method to return a strongly typed instance.
        object? deserializedResponse = jsonSerializer.Deserialize(jsonTextReader);
    }
}