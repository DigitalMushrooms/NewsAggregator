using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Http.TheGuardian.Models;

public class Response : IMapFrom<PaginatedList<Article>>
{
    public string Status { get; set; } = null!;
    public string UserTier { get; set; } = null!;
    public int Total { get; set; }
    public int StartIndex { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int Pages { get; set; }
    public OrderBy OrderBy { get; set; }
    public IReadOnlyList<Result> Results { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Response, PaginatedList<Article>>()
            .ForMember(result => result.Items, opt => opt.MapFrom(response => response.Results));
    }
}

public enum OrderBy
{
    Newest,
    Oldest,
    Relevance
}