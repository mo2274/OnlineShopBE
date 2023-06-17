using FluentValidation;
using OnlineSystem.Core.Requests;

namespace OnlineSystem.Core.Validations;

public class ProductPayloadValidator : AbstractValidator<ProductPayload>
{
    public ProductPayloadValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithErrorCode("Name can not be empty");
        
        RuleFor(p => p.NameAr)
            .NotEmpty()
            .WithErrorCode("NameAr can not be empty");
    }
}