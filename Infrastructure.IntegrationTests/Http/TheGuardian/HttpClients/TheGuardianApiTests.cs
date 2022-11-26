using System.Net;
using Application.Common.Models;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Http.TheGuardian.Builders;
using Infrastructure.Http.TheGuardian.HttpClients;
using Infrastructure.Http.TheGuardian.Options;
using Microsoft.Extensions.Options;
using RichardSzalay.MockHttp;

namespace Infrastructure.IntegrationTests.Http.TheGuardian.HttpClients;

public class TheGuardianApiTests
{
    private static readonly TheGuardianUriBuilder UriBuilder;

    static TheGuardianApiTests()
    {
        var httpClientOptions = new HttpClientOptions { Url = "http://localhost" };
        var options = new OptionsWrapper<HttpClientOptions>(httpClientOptions);
        UriBuilder = new TheGuardianUriBuilder(options);
    }
    
    [Fact]
    public async Task GetContent_ReturnsHttpRequestException()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("*").Respond(HttpStatusCode.InternalServerError);
        var httpClient = mockHttp.ToHttpClient();
        var theGuardianApi = new TheGuardianApi(httpClient, UriBuilder);

        // Act
        Func<Task<PaginatedList<Article>>> act = () => theGuardianApi.GetContent();

        // Asset
        await act.Should().ThrowAsync<HttpRequestException>();
    }
}