using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Services.Contract;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class GetTodoItemByIdQueryHandle(ITodoItemService todoItemService) : IRequestHandler<GetTodoItemByIdQuery, Result<TodoItem>>
    {
        public async Task<Result<TodoItem>> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            var result = request.IncludeStatus
                ? await todoItemService.GetByIdWithStatusAsync(request.Id)
                : await todoItemService.GetByAsync(x => x.TodoItemId == request.Id);

            return result == null
                ? Result<TodoItem>.Failure(new(), "data not available")
                : Result<TodoItem>.Success(result);
        }
    }
}
