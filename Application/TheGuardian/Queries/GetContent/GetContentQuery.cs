using Application.Interfaces;
using MediatR;

namespace Application.TheGuardian.Queries.GetContent;

public class GetContentQuery : IRequest
{
}

public class GetContentQueryHandler : IRequestHandler<GetContentQuery>
{
    private readonly ITheGuardianApi _theGuardianApi;

    public GetContentQueryHandler(ITheGuardianApi theGuardianApi)
    {
        _theGuardianApi = theGuardianApi;
    }
    
    public Task<Unit> Handle(GetContentQuery request, CancellationToken cancellationToken)
    {
        
        return Task.FromResult(Unit.Value);
    }
}