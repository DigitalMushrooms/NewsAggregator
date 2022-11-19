using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.TheGuardian.Queries.GetContent;

public class GetContentQuery : IRequest<PaginatedList<Article>>
{
}

public class GetContentQueryHandler : IRequestHandler<GetContentQuery, PaginatedList<Article>>
{
    private readonly ITheGuardianApi _theGuardianApi;

    public GetContentQueryHandler(ITheGuardianApi theGuardianApi)
    {
        _theGuardianApi = theGuardianApi;
    }
    
    public async Task<PaginatedList<Article>> Handle(GetContentQuery request, CancellationToken cancellationToken)
    {
        PaginatedList<Article> articles = await _theGuardianApi.GetContent();
        return articles;
    }
}