namespace CQRS.MEDIATOR.V2.API.Models
{
    public record StatusDto(long StatusId, string? Name, string? Description, bool Active, string? CreatedBy, DateTime CreatedAt, string? LastUpdatedBy, DateTime? LastUpdatedAt, Guid? RowGuid, bool Deleted);
}
