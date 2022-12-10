using System.Collections.Specialized;
using System.Web;
using Infrastructure.Http.TheGuardian.Options;
using Microsoft.Extensions.Options;

namespace Infrastructure.Http.TheGuardian.Builders;

public class TheGuardianUriBuilder
{
    private readonly HttpClientOptions _options;
    private readonly UriBuilder _uriBuilder;
    private readonly NameValueCollection _query;

    public TheGuardianUriBuilder(IOptions<HttpClientOptions> options)
    {
        _options = options.Value;
        _uriBuilder = new UriBuilder(_options.Url);
        _query = HttpUtility.ParseQueryString(string.Empty);
    }

    public TheGuardianUriBuilder WithStarRating(int? rating)
    {
        const string starRatingQueryName = "star-rating";
        if (rating == null)
        {
            _query.Remove(starRatingQueryName);
            return this;
        }
        _query[starRatingQueryName] = rating.Value.ToString();
        return this;
    }

    public string Build()
    {
        _query[Constants.Url.ApiKey] = _options.Key;
        _uriBuilder.Query = _query.ToString();
        return _uriBuilder.ToString();
    }
}