namespace Infrastructure.Http.TheGuardian.Options;

public class HttpClientOptions
{
    public static string TheGuardianSection = "HttpClient:TheGuardian";
    public string Url { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
}