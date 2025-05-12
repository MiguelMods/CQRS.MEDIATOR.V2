using CQRS.MEDIATOR.V2.API.Entities;
using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Models.Request;
using CQRS.MEDIATOR.V2.API.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.MEDIATOR.V2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController(ITodoItemService todoItemService) : ControllerBase
    {
        [HttpGet("{includeStatus:bool?}")]
        public async Task<IActionResult> Get(bool includeStatus = true)
        {
            var result = includeStatus
                ? await todoItemService.GetAllWithStatusAsync()
                : await todoItemService.GetAllAsync();

            if (result == null)
                return NotFound(Result<IEnumerable<TodoItem>>.Failure([], "data not avaible"));

            return Ok(Result<IEnumerable<TodoItem>>.Success(result));
        }

        [HttpGet("{id:long}/{includeStatus:bool?}")]
        public async Task<IActionResult> Get(long id, bool includeStatus = true)
        {
            var result = includeStatus
                ? await todoItemService.GetByIdWithStatusAsync(id)
                : await todoItemService.GetByAsync(x => x.TodoItemId == id);

            if (result == null)
                return NotFound(Result<TodoItem>.Failure("data not avaible"));

            return Ok(Result<TodoItem>.Success(result));
        }

        [HttpGet("status/{statusId:long}")]
        public async Task<IActionResult> GetByStatusId(long statusId)
        {
            var result = await todoItemService.GetAllByStatusIdAsync(statusId);
            if (result == null)
                return NotFound(Result<IEnumerable<TodoItem>>.Failure("data not avaible"));
            return Ok(Result<IEnumerable<TodoItem>>.Success(result));
        }

        [HttpPut("{id:long}/status/{statusid:long}")]
        public async Task<IActionResult> UpdateTodoStatus(long id, long statusId)
        {
            var result = await todoItemService.UpdateTodoStatusAsync(id, statusId);

            if (result == false)
                return NotFound(Result<bool>.Failure("data not avaible"));

            return Ok(Result<bool>.Success(true));
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] TodoItemCreateRequest request)
        {
            var result = await todoItemService.AddAsync(new TodoItem
            {
                Title = request.Title,
                Description = request.Description,
                IsCompleted = request.IsCompleted,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            });

            if (result == null)
                return NotFound(Result<TodoItem>.Failure("data not avaible"));

            return CreatedAtAction(nameof(Get), new { id = result.TodoItemId }, Result<TodoItem>.Success(result));
        }

        [HttpPut("")]
        public async Task<IActionResult> Put([FromBody] TodoItemUpdateRequest request)
        {
            var result = await todoItemService.UpdateAsync(new TodoItem
            {
                TodoItemId = request.TodoItemId,
                Title = request.Title,
                Description = request.Description,
                IsCompleted = request.IsCompleted,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            });

            if (result == null)
                return NotFound(Result<TodoItem>.Failure("data not avaible"));

            return Ok(Result<TodoItem>.Success(result));
        }

        [HttpPut("date")]
        public async Task<IActionResult> UpdateTodoDate([FromBody] TodoItemUpdateDateRequest request)
        {
            var result = await todoItemService.UpdateTodoDateAsync(new TodoItem
            {
                TodoItemId = request.TodoItemId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            });

            if (result == false)
                return NotFound(Result<bool>.Failure("data not avaible"));

            return Ok(Result<bool>.Success(true));
        }

        [HttpDelete("{id:long}/{delete:bool?}")]
        public async Task<IActionResult> Delete(long id, bool delete = false)
        {
            var result = delete
                ? await todoItemService.DeleteRegisterAsync(id)
                : await todoItemService.DeleteByAsync(x => x.TodoItemId == id);

            if (result == false)
                return NotFound(Result<bool>.Failure("data not avaible"));

            return Ok(Result<bool>.Success(true));
        }

        [HttpPut("recover/{id:long}")]
        public async Task<IActionResult> Recover(long id)
        {
            var result = await todoItemService.RecoverDeleteAsync(id);
            if (result == false)
                return NotFound(Result<bool>.Failure("data not avaible"));
            return Ok(Result<bool>.Success(true));
        }
    }
}