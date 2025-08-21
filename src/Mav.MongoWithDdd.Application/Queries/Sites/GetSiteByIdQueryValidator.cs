using FluentValidation;

namespace Mav.MongoWithDdd.Application.Queries.Sites;

public class GetSiteByIdQueryValidator : AbstractValidator<GetSiteByIdQuery>
{
    public GetSiteByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
