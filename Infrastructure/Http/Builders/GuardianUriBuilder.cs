using System.Collections.Specialized;
using System.Web;
using Infrastructure.Http.Options;
using Microsoft.Extensions.Options;

namespace Infrastructure.Http.Builders;

public class GuardianUriBuilder
{
    private readonly HttpClientOptions _options;
    private readonly UriBuilder _uriBuilder;
    private readonly NameValueCollection _query;

    public GuardianUriBuilder(IOptions<HttpClientOptions> options)
    {
        _options = options.Value;
        _uriBuilder = new UriBuilder(_options.Url);
        _query = HttpUtility.ParseQueryString(string.Empty);
    }

    public string Build()
    {
        _query["api-key"] = _options.Key;
        _uriBuilder.Query = _query.ToString();
        return _uriBuilder.ToString();
    }
}