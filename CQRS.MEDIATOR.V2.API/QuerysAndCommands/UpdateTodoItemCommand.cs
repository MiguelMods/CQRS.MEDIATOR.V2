using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.Models;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class UpdateTodoItemCommand(long TodoItemId, string? Title, string? Description, bool IsCompleted, DateTime? StartDate, DateTime? EndDate) : IRequest<Result<TodoItemDto>>
    {
        public long TodoItemId { get; } = TodoItemId;
        public string? Title { get; } = Title;
        public string? Description { get; } = Description;
        public bool IsCompleted { get; } = IsCompleted;
        public DateTime? StartDate { get; } = StartDate;
        public DateTime? EndDate { get; } = EndDate;
    }
}
