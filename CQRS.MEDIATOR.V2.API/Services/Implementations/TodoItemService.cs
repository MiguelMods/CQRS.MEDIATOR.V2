using System.Linq.Expressions;
using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.Repositories.Contracs;
using CQRS.MEDIATOR.V2.API.Services.Contract;

namespace CQRS.MEDIATOR.V2.API.Services.Implementations
{
    public class TodoItemService(IUnitOfWork unitOfWork) : ITodoItemService
    {
        private IUnitOfWork UnitOfWork { get; } = unitOfWork;
        private IGenericRepository<TodoItem> TodoItemRepository { get; } = unitOfWork.GetRepository<TodoItem>();

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
            => await TodoItemRepository.GetAllAsync();

        public async Task<TodoItem> GetByAsync(Expression<Func<TodoItem, bool>> expression)
            => await TodoItemRepository.GetByAsync(expression);

        public async Task<TodoItem> AddAsync(TodoItem entity)
        {
            var todoItem = await TodoItemRepository.AddAsync(entity);
            var result = await UnitOfWork.SaveChangesAsync();

            if (result)
                return todoItem;

            throw new Exception("Error while saving changes");
        }

        public async Task<TodoItem> UpdateAsync(TodoItem entity)
        {
            var todoItem = await TodoItemRepository.GetByAsync(x => x.TodoItemId == entity.TodoItemId) ?? throw new Exception("TodoItem not found");

            todoItem.Title = entity.Title;
            todoItem.Description = entity.Description;
            todoItem.IsCompleted = entity.IsCompleted;
            todoItem.StartDate = entity.StartDate;
            todoItem.EndDate = entity.EndDate;

            if (todoItem.IsCompleted)
            {
                todoItem.EndDate = todoItem.EndDate == null ? DateTime.Now : todoItem.EndDate;
            }

            var result = await TodoItemRepository.UpdateAsync(todoItem);
            var saveResult = await UnitOfWork.SaveChangesAsync();

            if (saveResult)
                return todoItem;

            throw new Exception("Error while updated changes");
        }

        public async Task<bool> DeleteByAsync(Expression<Func<TodoItem, bool>> expression)
        {
            var todoItem = await TodoItemRepository.GetByAsync(expression) ?? throw new Exception("TodoItem not found");
            
            var result = await TodoItemRepository.DeleteByAsync(x => x.TodoItemId == todoItem.TodoItemId);
            var saveResult = await UnitOfWork.SaveChangesAsync();

            if (saveResult)
                return result;

            throw new Exception("Error while deleting changes");
        }
    }
}
