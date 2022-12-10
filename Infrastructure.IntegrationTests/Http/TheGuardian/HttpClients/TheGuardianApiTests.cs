using System.Net;
using Application.Common.Models;
using AutoFixture;
using Domain.Entities;
using Domain.Options.TheGuardian;
using FluentAssertions;
using Infrastructure.Http.TheGuardian;
using Infrastructure.Http.TheGuardian.Builders;
using Infrastructure.Http.TheGuardian.HttpClients;
using Infrastructure.Http.TheGuardian.Options;
using Infrastructure.IntegrationTests.Builders.SpecimenBuilders;
using Microsoft.Extensions.Options;
using RichardSzalay.MockHttp;

namespace Infrastructure.IntegrationTests.Http.TheGuardian.HttpClients;

public class TheGuardianApiTests
{
    private static readonly MockHttpMessageHandler MockHttp;
    private static readonly HttpClientOptions HttpClientOptions;
    private static readonly TheGuardianUriBuilder UriBuilder;

    static TheGuardianApiTests()
    {
        MockHttp = new MockHttpMessageHandler();
        
        var fixture = new Fixture();
        fixture.Customizations.Add(new HttpClientOptionsSpecimenBuilder());
        HttpClientOptions = fixture.Freeze<HttpClientOptions>();
        
        var options = new OptionsWrapper<HttpClientOptions>(HttpClientOptions);
        UriBuilder = new TheGuardianUriBuilder(options);
    }
    
    [Fact]
    public async Task GetContent_ReturnsHttpRequestException()
    {
        // Arrange
        MockedRequest? request = MockHttp
            .When(HttpClientOptions.Url)
            .WithQueryString(Constants.Url.ApiKey, HttpClientOptions.Key)
            .Respond(HttpStatusCode.InternalServerError);
        var httpClient = MockHttp.ToHttpClient();
        var theGuardianApi = new TheGuardianApi(httpClient, UriBuilder);
        var options = new ContentFilterOptions();

        // Act
        Func<Task<PaginatedList<Article>>> act = () => theGuardianApi.GetContent(options);

        // Asset
        await act.Should().ThrowAsync<HttpRequestException>();
        MockHttp.GetMatchCount(request).Should().Be(1);
    }
}