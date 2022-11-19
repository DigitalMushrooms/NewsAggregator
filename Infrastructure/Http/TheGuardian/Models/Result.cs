namespace Infrastructure.Http.TheGuardian.Models;

public class Result
{
    public string Id { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string SectionId { get; set; } = null!;
    public string SectionName { get; set; } = null!;
    public DateTimeOffset WebPublicationDate { get; set; }
    public string WebTitle { get; set; } = null!;
    public string WebUrl { get; set; } = null!;
    public string ApiUrl { get; set; } = null!;
    public bool IsHosted { get; set; }
    public string PillarId { get; set; } = null!;
    public string PillarName { get; set; } = null!;
}