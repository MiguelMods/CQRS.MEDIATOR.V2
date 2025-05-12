using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Services.Contract;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class UpdateTodoItemStatusCommandHandler(ITodoItemService todoItemService) : IRequestHandler<UpdateTodoItemStatusCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(UpdateTodoItemStatusCommand request, CancellationToken cancellationToken)
        {
            var result = await todoItemService.UpdateTodoStatusAsync(request.TodoItemId, request.StatusId);
            return result ? Result<bool>.Success(true) : Result<bool>.Failure("data not available");
        }
    }
}
