namespace CQRS.MEDIATOR.V2.API.Models
{
    public class StatusDto
    {
        public long StatusId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public Guid? RowGuid { get; set; }
        public bool Deleted { get; set; }
    }
}
