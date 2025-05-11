using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.EntitiesModelBuilder;
using Microsoft.EntityFrameworkCore;

namespace CQRS.MEDIATOR.V2.API.DataContext
{
    public class ApplicationDataBaseContext(DbContextOptions<ApplicationDataBaseContext> options) : DbContext(options)
    {
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StatusModelBuilder());
            modelBuilder.ApplyConfiguration(new TodoItemModelBuilder());
        }
    }
}
