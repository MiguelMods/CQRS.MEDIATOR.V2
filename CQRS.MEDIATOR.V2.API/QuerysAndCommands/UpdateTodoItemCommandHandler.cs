using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Services.Contract;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class UpdateTodoItemCommandHandler(ITodoItemService todoItemService) : IRequestHandler<UpdateTodoItemCommand, Result<TodoItemDto>>
    {
        public async Task<Result<TodoItemDto>> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
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
            var resultDto = TodoItemDto.Map(result);
            return result != null ? Result<TodoItemDto>.Success(resultDto) : Result<TodoItemDto>.Failure("data not available");
        }
    }
}
