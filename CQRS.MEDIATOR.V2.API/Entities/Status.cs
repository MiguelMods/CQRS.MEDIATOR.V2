namespace CQRS.MEDIATOR.V2.API.Entities
{
    public class Status : BaseEntity
    {
        public long StatusId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
