using CQRS.MEDIATOR.V2.API.Models;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class GetAllTodoITemsQuery(bool IncludeStatus = false) : IRequest<Result<IEnumerable<TodoItemDto>>>
    {
        public bool IncludeStatus { get; set; } = IncludeStatus;
    }
}
