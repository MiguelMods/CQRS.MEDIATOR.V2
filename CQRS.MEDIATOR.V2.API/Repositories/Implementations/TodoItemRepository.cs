using CQRS.MEDIATOR.V2.API.DataContext;
using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.Repositories.Contracs;
using Microsoft.EntityFrameworkCore;

namespace CQRS.MEDIATOR.V2.API.Repositories.Implementations
{
    public class TodoItemRepository(ApplicationDataBaseContext context) : GenericRepository<TodoItem>(context), ITodoItemRepository
    {
        public async Task<IEnumerable<TodoItem>> GetAllWithStatusAsync()
            => await Context.TodoItems.Include(x => x.Status).ToListAsync();

        public async Task<TodoItem> GetByIdWithStatusAsync(long id)
            => await Context.TodoItems
                .Include(x => x.Status)
                .FirstOrDefaultAsync(x => x.TodoItemId == id) ?? throw new Exception("TodoItem not found");

        public async Task<IEnumerable<TodoItem>> GetAllByStatusIdAsync(long statusId)
            => await Context.TodoItems
                .Include(x => x.Status)
                .Where(x => x.StatusId == statusId)
                .ToListAsync();
    }
}
