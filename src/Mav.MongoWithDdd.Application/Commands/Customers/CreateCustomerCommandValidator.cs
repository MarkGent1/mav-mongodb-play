using FluentValidation;

namespace Mav.MongoWithDdd.Application.Commands.Customers;

public class CreateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Address).NotNull();
        RuleFor(x => x.Address.Street).NotEmpty();
        RuleFor(x => x.Address.City).NotEmpty();
        RuleFor(x => x.Address.Postcode).NotEmpty();
    }
}
