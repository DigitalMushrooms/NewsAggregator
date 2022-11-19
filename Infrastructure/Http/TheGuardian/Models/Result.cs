using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Http.TheGuardian.Models;

public class Result : IMapFrom<Article>
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

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Result, Article>()
            .ForMember(article => article.Publisher, opt => opt.MapFrom(result => PublisherName.TheGuardian))
            .ForMember(article => article.PublicationDate, opt => opt.MapFrom(result => result.WebPublicationDate))
            .ForMember(article => article.Title, opt => opt.MapFrom(result => result.WebTitle));
    }
}