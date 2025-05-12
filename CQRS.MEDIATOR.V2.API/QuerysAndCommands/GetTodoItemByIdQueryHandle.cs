using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Services.Contract;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class GetTodoItemByIdQueryHandle(ITodoItemService todoItemService) : IRequestHandler<GetTodoItemByIdQuery, Result<TodoItemDto>>
    {
        public async Task<Result<TodoItemDto>> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            var result = request.IncludeStatus
                ? await todoItemService.GetByIdWithStatusAsync(request.Id)
                : await todoItemService.GetByAsync(x => x.TodoItemId == request.Id);

            var resultDto = TodoItemDto.Map(result);

            return result == null
                ? Result<TodoItemDto>.Failure("data not available")
                : Result<TodoItemDto>.Success(resultDto);
        }
    }
}
