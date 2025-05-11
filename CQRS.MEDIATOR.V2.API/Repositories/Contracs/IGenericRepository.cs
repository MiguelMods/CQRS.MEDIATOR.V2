using System.Linq.Expressions;

namespace CQRS.MEDIATOR.V2.API.Repositories.Contracs
{
    public interface IGenericRepository<Type> where Type : class
    {
        Task<IEnumerable<Type>> GetAllAsync();
        Task<Type> GetByAsync(Expression<Func<Type, bool>> expression);
        Task<Type> AddAsync(Type entity);
        Task<Type> UpdateAsync(Type entity);
        Task<bool> DeleteByAsync(Expression<Func<Type, bool>> expression);
    }
}
