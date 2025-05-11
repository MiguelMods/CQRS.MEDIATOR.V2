using CQRS.MEDIATOR.V2.API.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CQRS.MEDIATOR.V2.API.Filters
{
    public class RequestModelValidatorFilter(IServiceProvider serviceProvider) : IAsyncActionFilter
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument == null)
                {
                    var result = Result<string[]>.Failure([$"Model Data is null"], "Validation Errors");
                    context.Result = new BadRequestObjectResult(result);
                    return;
                }

                var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());

                if (_serviceProvider.GetService(validatorType) is IValidator validator)
                {
                    var validationContext = new ValidationContext<object>(argument);
                    var validationResult = await validator.ValidateAsync(validationContext);

                    if (!validationResult.IsValid)
                    {
                        var result = Result<string[]>.Failure([.. validationResult.Errors.Select(e => e.ErrorMessage)], "Validation Errors");
                        context.Result = new BadRequestObjectResult(result);
                        return;
                    }
                }
            }

            await next();
        }
    }
}
