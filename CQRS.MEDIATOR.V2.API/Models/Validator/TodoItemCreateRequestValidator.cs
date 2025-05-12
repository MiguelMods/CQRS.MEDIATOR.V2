using CQRS.MEDIATOR.V2.API.Models.Request;
using FluentValidation;

namespace CQRS.MEDIATOR.V2.API.Models.Validator
{
    public class TodoItemCreateRequestValidator : AbstractValidator<TodoItemCreateRequest>
    {
        public TodoItemCreateRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .MaximumLength(100)
                .WithMessage("Title must be less than 50 characters");
            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Description must be less than 200 characters");
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate)
                .When(x => x.EndDate != null)
                .WithMessage("Start date must be less than or equal to end date");
        }
    }
}
