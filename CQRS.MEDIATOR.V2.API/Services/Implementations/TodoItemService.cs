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

        public async Task<IEnumerable<TodoItem>> GetAllWithStatusAsync()
            => await UnitOfWork.TodoItemRepository.GetAllWithStatusAsync();

        public async Task<TodoItem> GetByIdWithStatusAsync(long id)
            => await UnitOfWork.TodoItemRepository.GetByIdWithStatusAsync(id);

        public Task<IEnumerable<TodoItem>> GetAllByStatusIdAsync(long statusId)
            => UnitOfWork.TodoItemRepository.GetAllByStatusIdAsync(statusId);

        public async Task<bool> UpdateTodoStatusAsync(long id, long statusId)
        {
            var todoItem = await TodoItemRepository.GetByAsync(x => x.TodoItemId == id) ?? throw new Exception("TodoItem not found");

            if (todoItem.StatusId == statusId)
                return true;

            var status = await UnitOfWork.GetRepository<Status>().GetByAsync(x => x.StatusId == statusId) ?? throw new Exception("Status not found");

            todoItem.StatusId = status.StatusId;

            var update = await TodoItemRepository.UpdateAsync(todoItem);
            var result = await UnitOfWork.SaveChangesAsync();

            if (result)
                return result;

            throw new Exception("Error while updating changes");
        }

        public async Task<bool> UpdateTodoDateAsync(TodoItem todoItem)
        {
            var item = await TodoItemRepository.GetByAsync(x => x.TodoItemId == todoItem.TodoItemId) ?? throw new Exception("TodoItem not found");

            item.StartDate = todoItem.StartDate;
            item.EndDate = todoItem.EndDate;

            var result = await TodoItemRepository.UpdateAsync(item);
            var saveResult = await UnitOfWork.SaveChangesAsync();

            if (saveResult)
                return saveResult;

            throw new Exception("Error while updating changes");
        }

        public async Task<TodoItem> GetByAsync(Expression<Func<TodoItem, bool>> expression)
            => await TodoItemRepository.GetByAsync(expression);

        public async Task<TodoItem> AddAsync(TodoItem entity)
        {
            var todoItem = await TodoItemRepository.AddAsync(entity);

            var status = await UnitOfWork.GetRepository<Status>().GetByAsync(x => x.Name == "Pending") ?? throw new Exception("Status not found");

            todoItem.StatusId = status.StatusId;
            todoItem.CreatedBy = "System";

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

            var status = await UnitOfWork.GetRepository<Status>().GetByAsync(x => x.StatusId == entity.StatusId) ?? throw new Exception("Status not found");
            todoItem.StatusId = status.StatusId;

            var result = await TodoItemRepository.UpdateAsync(todoItem);
            var saveResult = await UnitOfWork.SaveChangesAsync();

            if (saveResult)
                return todoItem;

            throw new Exception("Error while updated changes");
        }

        public async Task<bool> DeleteByAsync(Expression<Func<TodoItem, bool>> expression)
        {
            var todoItem = await TodoItemRepository.GetByAsync(expression) ?? throw new Exception("TodoItem not found");

            todoItem.Deleted = true;

            await TodoItemRepository.UpdateAsync(todoItem);
            var saveResult = await UnitOfWork.SaveChangesAsync();

            if (saveResult)
                return saveResult;

            throw new Exception("Error while deleting changes");
        }

        public async Task<bool> RecoverDeleteAsync(long id)
        {
            var todoItem = await TodoItemRepository.GetByAsync(x => x.TodoItemId == id) ?? throw new Exception("TodoItem not found");

            todoItem.Deleted = false;

            await TodoItemRepository.UpdateAsync(todoItem);
            var saveResult = await UnitOfWork.SaveChangesAsync();

            if (saveResult)
                return saveResult;

            throw new Exception("Error while recovering changes");
        }

        public async Task<bool> DeleteRegisterAsync(long id)
        {
            var todoItem = await TodoItemRepository.GetByAsync(x => x.TodoItemId == id) ?? throw new Exception("TodoItem not found");

            var result = await TodoItemRepository.DeleteByAsync(x => x.TodoItemId == todoItem.TodoItemId);

            var saveResult = await UnitOfWork.SaveChangesAsync();

            if (saveResult)
                return result;

            throw new Exception("Error while deleting changes");
        }
    }
}