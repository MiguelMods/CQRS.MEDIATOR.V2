namespace CQRS.MEDIATOR.V2.API.Repositories.Contracs
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        ITodoItemRepository TodoItemRepository { get; }
        Task<bool> SaveChangesAsync();
    }
}
