using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Services.Contract;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class DeleteTodoItemCommandHandler(ITodoItemService todoItemService) : IRequestHandler<DeleteTodoItemCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var result = request.Delete ? await todoItemService.DeleteRegisterAsync(request.TodoItemId) : await todoItemService.DeleteByAsync(x => x.TodoItemId == request.TodoItemId);
            return result ? Result<bool>.Success(result) : Result<bool>.Failure(result, "Entity not delete");
        }
    }
}

