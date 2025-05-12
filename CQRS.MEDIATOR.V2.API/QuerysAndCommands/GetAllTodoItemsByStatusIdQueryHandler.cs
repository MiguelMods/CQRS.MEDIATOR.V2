using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Repositories.Contracs;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class GetAllTodoItemsByStatusIdQueryHandler(ITodoItemRepository todoItemRepository) : IRequestHandler<GetAllTodoItemsByStatusIdQuery, Result<IEnumerable<TodoItemDto>>>
    {
        public async Task<Result<IEnumerable<TodoItemDto>>> Handle(GetAllTodoItemsByStatusIdQuery request, CancellationToken cancellationToken)
        {
            var result = await todoItemRepository.GetAllByStatusIdAsync(request.StatusId);
            var resultDto = result.Select(TodoItemDto.Map);
            return Result<IEnumerable<TodoItemDto>>.Success(resultDto);
        }
    }
}
