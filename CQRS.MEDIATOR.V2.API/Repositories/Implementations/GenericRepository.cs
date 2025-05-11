using System.Linq.Expressions;
using CQRS.MEDIATOR.V2.API.DataContext;
using CQRS.MEDIATOR.V2.API.Repositories.Contracs;
using Microsoft.EntityFrameworkCore;

namespace CQRS.MEDIATOR.V2.API.Repositories.Implementations
{
    public class GenericRepository<Type>(ApplicationDataBaseContext context) : IGenericRepository<Type> where Type : class
    {
        public ApplicationDataBaseContext Context { get; } = context;

        public async Task<IEnumerable<Type>> GetAllAsync()
            => await Context.Set<Type>().ToListAsync();

        public async Task<Type> GetByAsync(Expression<Func<Type, bool>> expression)
            => await Context.Set<Type>().FirstOrDefaultAsync(expression);

        public async Task<Type> AddAsync(Type entity)
        {
            var newEntity = await Context.Set<Type>().AddAsync(entity);
            return newEntity.Entity;
        }

        public async Task<Type> UpdateAsync(Type entity)
        {
            var entityToUpdate = Context.Set<Type>().Update(entity);
            return entityToUpdate.Entity;
        }

        public async Task<bool> DeleteByAsync(Expression<Func<Type, bool>> expression)
        {
            var entityToDelete = await Context.Set<Type>().FirstOrDefaultAsync(expression);

            if (entityToDelete != null)
            {
                Context.Set<Type>().Remove(entityToDelete);
                return await Context.SaveChangesAsync() > 0;
            }

            throw new Exception("Error while deleting entity");
        }
    }
}
