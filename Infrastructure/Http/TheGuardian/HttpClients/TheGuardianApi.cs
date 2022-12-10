using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using Domain.Options.TheGuardian;
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

    public async Task<PaginatedList<Article>> GetContent(ContentFilterOptions contentFilters)
    {
        string url = _uriBuilder
            .WithStarRating(contentFilters.StarRating)
            .Build();

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        HttpResponseMessage responseMessage = await _httpClient.SendAsync(request);
        await using Stream responseContent = await responseMessage.Content.ReadAsStreamAsync();
        responseMessage.EnsureSuccessStatusCode();

        using var streamReader = new StreamReader(responseContent);
        using var jsonTextReader = new JsonTextReader(streamReader);    
        var jsonSerializer = new JsonSerializer();
        var deserializedResponse = jsonSerializer.Deserialize<ResponseWrapper>(jsonTextReader);

        if (deserializedResponse == null)
        {
            throw new NullReferenceException("Problem during deserializing response.");
        }

        PaginatedList<Article> result = ToPaginatedList(deserializedResponse);
        return result;
    }

    private static PaginatedList<Article> ToPaginatedList(ResponseWrapper deserializedResponse)
    {
        Response response = deserializedResponse.Response;
        var result = new PaginatedList<Article>
        {
            Items = response.Results.Select(r => new Article
            {
                Id = r.Id,
                PublicationDate = r.WebPublicationDate,
                Title = r.WebTitle
            }).ToList(),
            CurrentPage = response.CurrentPage,
            Pages = response.Pages,
            PageSize = response.PageSize
        };
        return result;
    }
}