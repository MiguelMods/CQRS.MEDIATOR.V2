using CQRS.MEDIATOR.V2.API.Models;
using CQRS.MEDIATOR.V2.API.Models.Request;
using CQRS.MEDIATOR.V2.API.QuerysAndCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.MEDIATOR.V2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{includeStatus:bool?}")]
        public async Task<IActionResult> Get(bool includeStatus = true)
        {
            var result = await mediator.Send(new GetAllTodoITemsQuery(includeStatus));

            if (result == null)
                return NotFound(Result<string>.Failure("data not avaible"));

            return Ok(result);
        }

        [HttpGet("{id:long}/{includeStatus:bool?}")]
        public async Task<IActionResult> Get(long id, bool includeStatus = true)
        {
            var result = await mediator.Send(new GetTodoItemByIdQuery(id, includeStatus));
            if (result == null)
                return NotFound(Result<bool>.Failure("data not avaible"));

            return Ok(result);
        }

        [HttpGet("status/{statusId:long}")]
        public async Task<IActionResult> GetByStatusId(long statusId)
        {
            var result = await mediator.Send(new GetAllTodoItemsByStatusIdQuery(statusId));

            if (result == null)
                return NotFound(Result<bool>.Failure("data not avaible"));

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] TodoItemCreateRequest request)
        {
            var result = await mediator.Send(new CreateTodoItemCommand(request.Title, request.Description, request.IsCompleted, request.StartDate, request.EndDate));

            if (result == null)
                return NotFound(Result<bool>.Failure("data not avaible"));

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(Get), new { id = result.Data?.TodoItemId }, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> Put([FromBody] TodoItemUpdateRequest request)
        {
            var result = await mediator.Send(new UpdateTodoItemCommand(request.TodoItemId, request.Title, request.Description, request.IsCompleted, request.StartDate, request.EndDate));

            if (result == null)
                return NotFound(Result<bool>.Failure("data not avaible"));

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("{id:long}/status/{statusid:long}")]
        public async Task<IActionResult> Put(long id, long statusId)
        {
            var result = await mediator.Send(new UpdateTodoItemStatusCommand(id, statusId));
            return result.IsSuccess switch
            {
                true => Ok(result),
                false => NotFound(result),
            };
        }

        [HttpPut("date")]
        public async Task<IActionResult> UpdateTodoDate([FromBody] TodoItemUpdateDateRequest request)
        {
            var result = await mediator.Send(new UpdateTodoItemDateCommand(request.TodoItemId, request.StartDate, request.EndDate));
            return result.IsSuccess switch
            {
                true => Ok(result),
                false => BadRequest(result),
            };
        }

        [HttpDelete("{id:long}/{delete:bool?}")]
        public async Task<IActionResult> Delete(long id, bool delete = false)
        {
            var result = await mediator.Send(new DeleteTodoItemCommand(id, delete));

            if (result == null)
                return NotFound(Result<bool>.Failure("data not avaible"));

            return result.IsSuccess switch
            {
                true => Ok(result),
                false => BadRequest(result),
            };
        }

        [HttpPut("recover/{id:long}")]
        public async Task<IActionResult> Recover(long id)
        {
            var result = await mediator.Send(new UpdateRecoverTodoItemCommand(id));
            
            if (result == null)
                return NotFound(Result<bool>.Failure("data not avaible"));
            
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}