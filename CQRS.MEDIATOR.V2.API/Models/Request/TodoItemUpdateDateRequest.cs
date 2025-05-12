namespace CQRS.MEDIATOR.V2.API.Models.Request
{
    public record TodoItemUpdateDateRequest(long TodoItemId, DateTime? StartDate, DateTime? EndDate);
}
