using CQRS.MEDIATOR.V2.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS.MEDIATOR.V2.API.DataContext
{
    public class ApplicationDataBaseContext(DbContextOptions<ApplicationDataBaseContext> options) : DbContext(options)
    {
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
