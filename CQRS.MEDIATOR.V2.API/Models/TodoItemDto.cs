using CQRS.MEDIATOR.V2.API.Entities;

namespace CQRS.MEDIATOR.V2.API.Models
{
    public class TodoItemDto
    {
        public long TodoItemId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long StatusId { get; set; }
        public virtual Status Status { get; set; }
        public bool Active { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public Guid? RowGuid { get; set; }
        public bool Deleted { get; set; }
    }
}
