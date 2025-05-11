using CQRS.MEDIATOR.V2.API.DataContext;
using CQRS.MEDIATOR.V2.API.Repositories.Contracs;

namespace CQRS.MEDIATOR.V2.API.Repositories.Implementations
{
    public class UnitOfWork(ApplicationDataBaseContext context) : IUnitOfWork
    {
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
            => new GenericRepository<TEntity>(context);
        public async Task<bool> SaveChangesAsync()
            => await context.SaveChangesAsync() > 0;
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
