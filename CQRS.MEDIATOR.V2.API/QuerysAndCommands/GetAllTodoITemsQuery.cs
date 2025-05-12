using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.Models;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class GetAllTodoITemsQuery(bool IncludeStatus = false) : IRequest<Result<IEnumerable<TodoItem>>>
    {
        public bool IncludeStatus { get; set; } = IncludeStatus;
    }
}
