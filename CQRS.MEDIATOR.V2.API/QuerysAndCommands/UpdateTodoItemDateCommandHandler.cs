using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Services.Contract;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class UpdateTodoItemDateCommandHandler(ITodoItemService todoItemService) : IRequestHandler<UpdateTodoItemDateCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(UpdateTodoItemDateCommand request, CancellationToken cancellationToken)
        {
            var result = await todoItemService.UpdateTodoDateAsync(new()
            {
                TodoItemId = request.TodoItemId,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            });
            return result ? Result<bool>.Success(result) : Result<bool>.Failure(result, "Entity not update");
        }
    }
}
