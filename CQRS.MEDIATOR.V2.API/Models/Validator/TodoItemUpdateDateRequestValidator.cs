using CQRS.MEDIATOR.V2.API.Models.Request;
using FluentValidation;

namespace CQRS.MEDIATOR.V2.API.Models.Validator
{
    public class TodoItemUpdateDateRequestValidator : AbstractValidator<TodoItemUpdateDateRequest>
    {
        public TodoItemUpdateDateRequestValidator()
        {
            RuleFor(x => x.TodoItemId)
                .NotEmpty()
                .WithMessage("TodoItemId is required");
            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate)
                .WithMessage("Start date must be greater than or equal to current date");
            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate)
                .When(x => x.StartDate != null)
                .WithMessage("End date must be greater than or equal to start date");
        }
    }
}
