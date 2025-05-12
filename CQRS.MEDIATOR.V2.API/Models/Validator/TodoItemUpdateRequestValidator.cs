using CQRS.MEDIATOR.V2.API.Models.Request;
using FluentValidation;

namespace CQRS.MEDIATOR.V2.API.Models.Validator
{
    public class TodoItemUpdateRequestValidator : AbstractValidator<TodoItemUpdateRequest>
    {
        public TodoItemUpdateRequestValidator()
        {
            RuleFor(x => x.TodoItemId).NotEmpty()
                .WithMessage("Id is required");
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
                .WithMessage("Start date must be less than or equal to end date");
            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => DateTime.Today)
                .WithMessage("End date must be greater than or equal today");
        }
    }
}
