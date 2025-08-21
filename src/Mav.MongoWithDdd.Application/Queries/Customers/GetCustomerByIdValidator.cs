using FluentValidation;

namespace Mav.MongoWithDdd.Application.Queries.Customers;

public class GetCustomerByIdValidator : AbstractValidator<GetCustomerByIdQuery>
{
    public GetCustomerByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
