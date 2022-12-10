using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using Domain.Options.TheGuardian;
using FluentValidation;
using MediatR;

namespace Application.TheGuardian.Queries.GetContent;

public class GetContentQuery : IRequest<PaginatedList<Article>>
{
    public int? StarRating { get; set; }
}

public class GetContentQueryHandler : IRequestHandler<GetContentQuery, PaginatedList<Article>>
{
    private readonly IValidator<GetContentQuery> _validator;
    private readonly ITheGuardianApi _theGuardianApi;

    public GetContentQueryHandler(IValidator<GetContentQuery> validator, ITheGuardianApi theGuardianApi)
    {
        _validator = validator;
        _theGuardianApi = theGuardianApi;
    }
    
    public async Task<PaginatedList<Article>> Handle(GetContentQuery request, CancellationToken cancellationToken)
    {
        var options = new ContentFilterOptions { StarRating = request.StarRating };
        PaginatedList<Article> articles = await _theGuardianApi.GetContent(options);
        return articles;
    }
}