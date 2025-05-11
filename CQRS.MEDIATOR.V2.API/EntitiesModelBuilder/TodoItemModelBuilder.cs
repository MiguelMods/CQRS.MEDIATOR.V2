using CQRS.MEDIATOR.V2.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.MEDIATOR.V2.API.EntitiesModelBuilder
{
    public class TodoItemModelBuilder : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasKey(e => e.TodoItemId);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(e => e.IsCompleted).HasDefaultValue(false);
            builder.Property(e => e.StartDate).IsRequired(false);
            builder.Property(e => e.EndDate).IsRequired(false);
            builder.Property(e => e.StatusId).IsRequired();
            builder.HasOne(e => e.Status)
                   .WithMany()
                   .HasForeignKey(e => e.StatusId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Property(e => e.Active).HasDefaultValue(true);
            builder.Property(e => e.CreatedBy).IsRequired().HasMaxLength(100);
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.LastUpdatedBy).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.LastUpdatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
            builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()").HasMaxLength(35);
            builder.Property(e => e.Deleted).HasDefaultValue(false);
        }
    }
}
