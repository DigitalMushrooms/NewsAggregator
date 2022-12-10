using Ardalis.HttpClientTestExtensions;
using WebAPI;

namespace DigitalMushrooms.NewsAggregator.FunctionalTests.ControllerApis;

public class TheGuardianControllerGetContentTests : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
    private readonly HttpClient _client;

    public TheGuardianControllerGetContentTests(CustomWebApplicationFactory<WebMarker> factory)
    {
        _client = factory.CreateClient();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(6)]
    public async Task GetContent_SendStarRatingOutOfScope_ReturnsBadRequest(int starRatingValue)
    {
        var url = $"api/TheGuardian?starRating={starRatingValue}";
        await _client.GetAndEnsureBadRequestAsync(url);
    }
}