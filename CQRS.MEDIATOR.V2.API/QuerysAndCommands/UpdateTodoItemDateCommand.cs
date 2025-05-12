using CQRS.MEDIATOR.V2.API.Models;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class UpdateTodoItemDateCommand(long TodoItemId, DateTime? StartDate, DateTime? EndDate) : IRequest<Result<bool>>
    {
        public long TodoItemId { get; } = TodoItemId;
        public DateTime? StartDate { get; } = StartDate;
        public DateTime? EndDate { get; } = EndDate;
    }
}
