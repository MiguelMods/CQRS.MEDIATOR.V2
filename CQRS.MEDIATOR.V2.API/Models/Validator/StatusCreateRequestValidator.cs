using CQRS.MEDIATOR.V2.API.Models.Request;
using FluentValidation;

namespace CQRS.MEDIATOR.V2.API.Models.Validator
{
    public class StatusCreateRequestValidator : AbstractValidator<StatusCreateRequest>
    {
        public StatusCreateRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Title is required")
                .MaximumLength(50)
                .WithMessage("Title must be less than 50 characters");
            RuleFor(x => x.Description)
                .MaximumLength(200)
                .WithMessage("Description must be less than 200 characters");
        }
    }
}
