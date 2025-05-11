using CQRS.MEDIATOR.V2.API.Models.Request;
using FluentValidation;

namespace CQRS.MEDIATOR.V2.API.Models.Validator
{
    public class StatusUpdateRequestValidator : AbstractValidator<StatusUpdateRequest>
    {
        public StatusUpdateRequestValidator()
        {
            RuleFor(x => x.StatusId)
                .NotEmpty()
                .WithMessage("StatusId is required")
                .GreaterThan(0)
                .WithMessage("StatusId must be greater than 0");
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Title is required")
                .MaximumLength(50)
                .WithMessage("Title must be less than 50 characters");
            RuleFor(x => x.Description)
                .MaximumLength(200)
                .WithMessage("Description must be less than 200 characters");
            RuleFor(x => x.Active)
                .NotNull()
                .WithMessage("Active IsCompleted is required");
        }
    }
}
