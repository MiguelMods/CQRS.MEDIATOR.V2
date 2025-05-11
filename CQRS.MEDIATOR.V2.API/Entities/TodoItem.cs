namespace CQRS.MEDIATOR.V2.API.Entities
{
    public class TodoItem : BaseEntity
    {
        public long TodoItemId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
