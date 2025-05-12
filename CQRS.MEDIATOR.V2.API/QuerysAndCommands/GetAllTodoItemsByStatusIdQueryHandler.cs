using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Services.Contract;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class GetAllTodoItemsByStatusIdQueryHandler(ITodoItemService todoItemService) : IRequestHandler<GetAllTodoItemsByStatusIdQuery, Result<IEnumerable<TodoItemDto>>>
    {
        public async Task<Result<IEnumerable<TodoItemDto>>> Handle(GetAllTodoItemsByStatusIdQuery request, CancellationToken cancellationToken)
        {
            var result = await todoItemService.GetAllByStatusIdAsync(request.StatusId);
            var resultDto = result.Select(TodoItemDto.Map);
            return Result<IEnumerable<TodoItemDto>>.Success(resultDto);
        }
    }
}
