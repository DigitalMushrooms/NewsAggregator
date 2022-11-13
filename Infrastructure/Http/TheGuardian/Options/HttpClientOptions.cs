namespace Infrastructure.Http.TheGuardian.Options;

public class HttpClientOptions
{
    public static string TheGuardianSection = "HttpClient:TheGuardian";
    public string Url => string.Empty;
    public string Key => string.Empty;
}