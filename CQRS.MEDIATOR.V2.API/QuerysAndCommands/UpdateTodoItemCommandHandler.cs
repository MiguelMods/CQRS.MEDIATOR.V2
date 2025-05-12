using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Services.Contract;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class UpdateTodoItemCommandHandler(ITodoItemService todoItemService) : IRequestHandler<UpdateTodoItemCommand, Result<TodoItem>>
    {
        public async Task<Result<TodoItem>> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem
            {
                TodoItemId = request.TodoItemId,
                Title = request.Title,
                Description = request.Description,
                IsCompleted = request.IsCompleted,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };
            var result = await todoItemService.UpdateAsync(todoItem);
            return result != null ? Result<TodoItem>.Success(result) : Result<TodoItem>.Failure(new(), "data not available");
        }
    }
}
