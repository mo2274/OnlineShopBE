using FluentValidation;
using OnlineSystem.Core.Requests;

namespace OnlineSystem.Core.Validations;

public class PaginationFilterValidator : AbstractValidator<PaginationFilter>
{
    public PaginationFilterValidator()
    {
        RuleFor(p => p.PageNumber)
            .GreaterThan(0)
            .WithErrorCode("Page Number Can not be less than zero");
        
        RuleFor(p => p.PageSize)
            .GreaterThan(0)
            .WithErrorCode("Page Size Can not be less than zero");

    }
}