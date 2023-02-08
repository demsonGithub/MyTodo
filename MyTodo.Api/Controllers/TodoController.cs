using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyTodo.Api.Controllers
{
    /// <summary>
    /// 待办事项
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResult<TodoDetailDto>> GetTodoDetail([FromQuery] GetTodoDetailQuery query)
        {
            var result = await _mediator.Send(query, HttpContext.RequestAborted);
            return ApiResult<TodoDetailDto>.Success(result);
        }

        [HttpGet]
        public async Task<ApiResult<PageResult<TodoDetailDto>>> GetListTodo([FromQuery] GetListTodoQuery query)
        {
            var result = await _mediator.Send(query, HttpContext.RequestAborted);
            return ApiResult<PageResult<TodoDetailDto>>.Success(result);
        }

        [HttpPost]
        public async Task<ApiResult<TodoDetailDto>> AddTodo([FromBody] AddTodoCommand command)
        {
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return ApiResult<TodoDetailDto>.Success(result);
        }

        [HttpPost]
        public async Task<ApiResult> UpdateTodo([FromBody] UpdateTodoCommand command)
        {
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return result ? ApiResult.Success() : ApiResult.Error("修改失败");
        }

        [HttpPost]
        public async Task<ApiResult> DeleteTodo([FromBody] DeleteTodoCommand command)
        {
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return result ? ApiResult.Success() : ApiResult.Error("删除失败");
        }
    }
}