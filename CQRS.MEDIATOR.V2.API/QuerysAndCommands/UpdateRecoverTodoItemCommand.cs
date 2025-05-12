using CQRS.MEDIATOR.V2.API.Models;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class UpdateRecoverTodoItemCommand(long todoItemId) : IRequest<Result<bool>>
    {
        public long TodoItemId { get; } = todoItemId;
    }
}
