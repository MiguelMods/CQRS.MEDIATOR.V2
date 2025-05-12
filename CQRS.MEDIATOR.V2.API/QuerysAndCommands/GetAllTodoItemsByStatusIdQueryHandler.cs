using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Repositories.Contracs;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class GetAllTodoItemsByStatusIdQueryHandler(ITodoItemRepository todoItemRepository) : IRequestHandler<GetAllTodoItemsByStatusIdQuery, Result<IEnumerable<TodoItem>>>
    {
        public async Task<Result<IEnumerable<TodoItem>>> Handle(GetAllTodoItemsByStatusIdQuery request, CancellationToken cancellationToken)
        {
            var result = await todoItemRepository.GetAllByStatusIdAsync(request.StatusId);
            return Result<IEnumerable<TodoItem>>.Success(result);
        }
    }
}
