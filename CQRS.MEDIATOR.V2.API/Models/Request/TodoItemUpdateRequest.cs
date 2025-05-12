namespace CQRS.MEDIATOR.V2.API.Models.Request
{
    public record TodoItemUpdateRequest(long TodoItemId, string? Title, string? Description, bool IsCompleted, DateTime? StartDate, DateTime? EndDate);
}
