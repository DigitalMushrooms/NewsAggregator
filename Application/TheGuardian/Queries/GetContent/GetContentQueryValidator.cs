using FluentValidation;

namespace Application.TheGuardian.Queries.GetContent;

public class GetContentQueryValidator : AbstractValidator<GetContentQuery>
{
    public GetContentQueryValidator()
    {
        RuleFor(x => x.StarRating)
            .InclusiveBetween(1, 5);
    }
}