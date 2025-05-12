using CQRS.MEDIATOR.V2.API.Entities;

namespace CQRS.MEDIATOR.V2.API.Models
{
    public record TodoItemDto(long TodoItemId, string? Title, string? Description, bool IsCompleted, DateTime? StartDate, DateTime? EndDate, long StatusId, StatusDto? Status, bool Active, string? CreatedBy, DateTime CreatedAt, string? LastUpdatedBy, DateTime? LastUpdatedAt, Guid? RowGuid, bool Deleted) 
    {
        public static TodoItemDto Map(TodoItem todoItem)
            => new
            (
                todoItem.TodoItemId,
                todoItem.Title,
                todoItem.Description,
                todoItem.IsCompleted,
                todoItem.StartDate,
                todoItem.EndDate,
                todoItem.StatusId,
                todoItem.Status != null ? 
                new (todoItem.Status.StatusId, todoItem.Status.Name, todoItem.Status.Description, todoItem.Status.Active, todoItem.Status.CreatedBy, todoItem.Status.CreatedAt, todoItem.Status.LastUpdatedBy, todoItem.Status.LastUpdatedAt, todoItem.Status.RowGuid, todoItem.Status.Deleted)
                : null,
                todoItem.Active,
                todoItem.CreatedBy,
                todoItem.CreatedAt,
                todoItem.LastUpdatedBy,
                todoItem.LastUpdatedAt,
                todoItem.RowGuid,
                todoItem.Deleted
            );
    }
}
