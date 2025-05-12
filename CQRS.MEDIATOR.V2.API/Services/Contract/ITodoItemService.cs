using CQRS.MEDIATOR.V2.API.Entities;

namespace CQRS.MEDIATOR.V2.API.Services.Contract
{
    public interface ITodoItemService : IServices<TodoItem>
    {
        Task<IEnumerable<TodoItem>> GetAllWithStatusAsync();
        Task<TodoItem> GetByIdWithStatusAsync(long id);
        Task<IEnumerable<TodoItem>> GetAllByStatusIdAsync(long statusId);
        Task<bool> UpdateTodoStatusAsync(long id, long statusId);
        Task<bool> UpdateTodoDateAsync(TodoItem todoItem);
        Task<bool> DeleteRegisterAsync(long id);
        Task<bool> RecoverDeleteAsync(long id);
    }
}
