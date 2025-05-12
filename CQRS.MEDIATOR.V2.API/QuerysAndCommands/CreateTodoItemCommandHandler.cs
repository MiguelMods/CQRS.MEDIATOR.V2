using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Services.Contract;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class CreateTodoItemCommandHandler(ITodoItemService todoItemService) : IRequestHandler<CreateTodoItemCommand, Result<TodoItemDto>>
    {
        public async Task<Result<TodoItemDto>> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem
            {
                Title = request.Title,
                Description = request.Description,
                IsCompleted = request.IsCompleted,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };
            var entity = await todoItemService.AddAsync(todoItem);
            var dto = TodoItemDto.Map(entity);
            return entity != null ? Result<TodoItemDto>.Success(dto) : Result<TodoItemDto>.Failure("Entity not update");
        }
    }
}
