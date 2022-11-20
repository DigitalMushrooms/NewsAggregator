namespace Domain.Entities;

public class Article
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public DateTimeOffset PublicationDate { get; set; }
}

public enum PublisherName
{
    TheGuardian
}