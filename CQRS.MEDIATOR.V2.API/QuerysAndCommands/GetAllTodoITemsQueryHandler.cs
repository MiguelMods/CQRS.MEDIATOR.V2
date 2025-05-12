using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Services.Contract;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class GetAllTodoITemsQueryHandler(ITodoItemService todoItemService) : IRequestHandler<GetAllTodoITemsQuery, Result<IEnumerable<TodoItem>>>
    {
        public async Task<Result<IEnumerable<TodoItem>>> Handle(GetAllTodoITemsQuery request, CancellationToken cancellationToken)
        {
            var result = request.IncludeStatus ?
                await todoItemService.GetAllWithStatusAsync() :
                await todoItemService.GetAllAsync();

            return Result<IEnumerable<TodoItem>>.Success(result);
        }
    }
}
