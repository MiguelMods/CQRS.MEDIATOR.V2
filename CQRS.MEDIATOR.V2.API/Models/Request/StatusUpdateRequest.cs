namespace CQRS.MEDIATOR.V2.API.Models.Request
{
    public record StatusUpdateRequest(long StatusId, string? Name, string? Description, bool Active);
}
