using CQRS.MEDIATOR.V2.API.Models;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class GetTodoItemByIdQuery(long id, bool includeStatus) : IRequest<Result<TodoItemDto>>
    {
        public long Id { get; set; } = id;
        public bool IncludeStatus { get; set; } = includeStatus;
    }
}
