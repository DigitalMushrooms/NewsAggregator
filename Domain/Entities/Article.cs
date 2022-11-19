namespace Domain.Entities;

public class Article : BaseEntity
{
    public PublisherName Publisher { get; set; }
    public string Title { get; set; } = null!;
    public DateTimeOffset PublicationDate { get; set; }
}

public enum PublisherName
{
    TheGuardian
}