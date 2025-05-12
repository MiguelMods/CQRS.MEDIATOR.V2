using CQRS.MEDIATOR.V2.API.Models;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class UpdateTodoItemStatusCommand(long TodoItemId, long StatusId) : IRequest<Result<bool>>
    {
        public long TodoItemId { get; } = TodoItemId;
        public long StatusId { get; } = StatusId;
    }
}
