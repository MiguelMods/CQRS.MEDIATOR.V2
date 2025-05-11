using System.Linq.Expressions;
using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.Repositories.Contracs;
using CQRS.MEDIATOR.V2.API.Services.Contract;

namespace CQRS.MEDIATOR.V2.API.Services.Implementations
{
    public class StatusService(IUnitOfWork unitOfWork) : IStatusService
    {
        private IUnitOfWork UnitOfWork { get; } = unitOfWork;
        private IGenericRepository<Status> StatusRepository { get; } = unitOfWork.GetRepository<Status>();
        public async Task<IEnumerable<Status>> GetAllAsync()
            => await StatusRepository.GetAllAsync();
        public async Task<Status> GetByAsync(Expression<Func<Status, bool>> expression)
            => await StatusRepository.GetByAsync(expression);
        public async Task<Status> AddAsync(Status entity)
        {
            var nameIsTaked = await StatusRepository.GetByAsync(x => x.Name.ToLower() == entity.Name.ToLower());

            if (nameIsTaked != null)
                throw new Exception("Name is already taken");

            // set default values for now
            entity.CreatedBy = "System";

            var status = await StatusRepository.AddAsync(entity);
            var result = await UnitOfWork.SaveChangesAsync();

            if (result)
                return status;

            throw new Exception("Error while saving changes");
        }
        public Task<Status> UpdateAsync(Status entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteByAsync(Expression<Func<Status, bool>> expression)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateActiveStatusOnlyAsync(long Id, bool active)
        {
            var status = await StatusRepository.GetByAsync(x => x.StatusId == Id) ?? throw new Exception("Status not found");
            
            status.Active = !active;

            var result = await StatusRepository.UpdateAsync(status);
            var saveResult = await UnitOfWork.SaveChangesAsync();
            
            if (saveResult)
                return true;
            
            throw new Exception("Error while saving changes");
        }
    }
}
