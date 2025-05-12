using CQRS.MEDIATOR.V2.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CQRS.MEDIATOR.V2.API.Filters
{
    public class GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger) : IExceptionFilter
    {
        public ILogger<GlobalExceptionFilter> Logger { get; } = logger;

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            Result<Exception> result;

            Logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);

            if (exception is DbUpdateException dbUpdateException)
            {
                Logger.LogError(dbUpdateException, "An unhandled exception occurred: {Message}", dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
                result = Result<Exception>.Failure(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
            else if (exception is DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                Logger.LogError(dbUpdateConcurrencyException, "An unhandled exception occurred: {Message}", dbUpdateConcurrencyException.InnerException?.Message ?? dbUpdateConcurrencyException.Message);
                result = Result<Exception>.Failure(dbUpdateConcurrencyException.InnerException?.Message ?? dbUpdateConcurrencyException.Message);
            }
            else
            {
                Logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);
                result = Result<Exception>.Failure(exception.Message);
            }

            context.Result = new ObjectResult(result)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}
