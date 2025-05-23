﻿using CQRS.MEDIATOR.V2.API.Models;
using MediatR;

namespace CQRS.MEDIATOR.V2.API.QuerysAndCommands
{
    public class GetAllTodoItemsByStatusIdQuery(long statusId) : IRequest<Result<IEnumerable<TodoItemDto>>>
    {
        public long StatusId { get; set; } = statusId;
    }
}
