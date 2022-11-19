namespace Application.Common.Models;

public class PaginatedList<TItem>
{
    public List<TItem> Items { get; set; } = new();
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int Pages { get; set; }
}