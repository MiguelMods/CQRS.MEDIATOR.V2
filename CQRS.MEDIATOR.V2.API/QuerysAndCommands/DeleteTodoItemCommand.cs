using CQRS.MEDIATOR.V2.API.Models;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class DeleteTodoItemCommand(long todoItemId, bool Delete) : IRequest<Result<bool>>
    {
        public long TodoItemId { get; } = todoItemId;
        public bool Delete { get; } = Delete;
    }
}

