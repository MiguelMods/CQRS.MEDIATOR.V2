using CQRS.MEDIATOR.V2.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.MEDIATOR.V2.API.EntitiesModelBuilder
{
    public class StatusModelBuilder : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(e => e.StatusId);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(e => e.Active).HasDefaultValue(true);
            builder.Property(e => e.CreatedBy).IsRequired().HasMaxLength(100);
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.LastUpdatedBy).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.LastUpdatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
            builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()").HasMaxLength(35);
            builder.Property(e => e.Deleted).HasDefaultValue(false);
            builder.HasData(
                new Status
                {
                    StatusId = 1,
                    Name = "Active",
                    Description = "The item is active.",
                    CreatedBy = "System",
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedBy = "System",
                    LastUpdatedAt = DateTime.UtcNow,
                    RowGuid = Guid.NewGuid().ToString(),
                    Deleted = false
                }, new Status 
                {
                    StatusId = 2,
                    Name = "Pending",
                    Description = "The item is active.",
                    CreatedBy = "System",
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedBy = "System",
                    LastUpdatedAt = DateTime.UtcNow,
                    RowGuid = Guid.NewGuid().ToString(),
                    Deleted = false
                }, new Status
                {
                    StatusId = 3,
                    Name = "On Progress",
                    Description = "The item is active.",
                    CreatedBy = "System",
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedBy = "System",
                    LastUpdatedAt = DateTime.UtcNow,
                    RowGuid = Guid.NewGuid().ToString(),
                    Deleted = false
                }, new Status
                {
                    StatusId = 4,
                    Name = "Completed",
                    Description = "The item is active.",
                    CreatedBy = "System",
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedBy = "System",
                    LastUpdatedAt = DateTime.UtcNow,
                    RowGuid = Guid.NewGuid().ToString(),
                    Deleted = false
                }, new Status
                {
                    StatusId = 5,
                    Name = "Cancelled",
                    Description = "The item is active.",
                    CreatedBy = "System",
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedBy = "System",
                    LastUpdatedAt = DateTime.UtcNow,
                    RowGuid = Guid.NewGuid().ToString(),
                    Deleted = false
                }, new Status
                {
                    StatusId = 6,
                    Name = "Deleted",
                    Description = "The item is active.",
                    CreatedBy = "System",
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedBy = "System",
                    LastUpdatedAt = DateTime.UtcNow,
                    RowGuid = Guid.NewGuid().ToString(),
                    Deleted = false
                }, new Status
                {
                    StatusId = 7,
                    Name = "Archived",
                    Description = "The item is active.",
                    CreatedBy = "System",
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedBy = "System",
                    LastUpdatedAt = DateTime.UtcNow,
                    RowGuid = Guid.NewGuid().ToString(),
                    Deleted = false
                }, new Status
                {
                    StatusId = 8,
                    Name = "In Review",
                    Description = "The item is active.",
                    CreatedBy = "System",
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedBy = "System",
                    LastUpdatedAt = DateTime.UtcNow,
                    RowGuid = Guid.NewGuid().ToString(),
                    Deleted = false
                }
                );
        }
    }
}
