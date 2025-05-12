namespace CQRS.MEDIATOR.V2.API.Models.Request
{
    public record TodoItemCreateRequest(string? Title, string? Description, bool IsCompleted, DateTime? StartDate, DateTime? EndDate);
}
