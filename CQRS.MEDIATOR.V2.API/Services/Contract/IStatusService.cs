using CQRS.MEDIATOR.V2.API.Entities;

namespace CQRS.MEDIATOR.V2.API.Services.Contract
{
    public interface IStatusService : IServices<Status>
    {
        Task<bool> UpdateActiveStatusOnlyAsync(long id, bool active);
    }
}
