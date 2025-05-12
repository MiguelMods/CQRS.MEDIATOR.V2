using CQRS.MEDIATOR.V2.API.Entities;

namespace CQRS.MEDIATOR.V2.API.Repositories.Contracs
{
    public interface ITodoItemRepository : IGenericRepository<TodoItem>
    {
        Task<IEnumerable<TodoItem>> GetAllWithStatusAsync();
        Task<TodoItem> GetByIdWithStatusAsync(long id);
        Task<IEnumerable<TodoItem>> GetAllByStatusIdAsync(long statusId);
    }
}
