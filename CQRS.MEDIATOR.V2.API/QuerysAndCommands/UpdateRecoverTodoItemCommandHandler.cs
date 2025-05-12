using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Services.Contract;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class UpdateRecoverTodoItemCommandHandler(ITodoItemService todoItemService) : IRequestHandler<UpdateRecoverTodoItemCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(UpdateRecoverTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await todoItemService.RecoverDeleteAsync(request.TodoItemId);
            return todoItem ? Result<bool>.Success(todoItem) : Result<bool>.Failure(todoItem, "Entity not recovered");
        }
    }
}
