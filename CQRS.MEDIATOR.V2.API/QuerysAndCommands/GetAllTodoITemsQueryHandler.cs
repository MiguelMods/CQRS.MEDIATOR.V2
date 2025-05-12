using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Services.Contract;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class GetAllTodoITemsQueryHandler(ITodoItemService todoItemService) : IRequestHandler<GetAllTodoITemsQuery, Result<IEnumerable<TodoItemDto>>>
    {
        public async Task<Result<IEnumerable<TodoItemDto>>> Handle(GetAllTodoITemsQuery request, CancellationToken cancellationToken)
        {
            var result = request.IncludeStatus ?
                await todoItemService.GetAllWithStatusAsync() :
                await todoItemService.GetAllAsync();

            var resultDto = result.Select(x => TodoItemDto.Map(x));

            return Result<IEnumerable<TodoItemDto>>.Success(resultDto);
        }
    }
}
