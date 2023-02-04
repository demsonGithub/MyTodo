using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyTodo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MemoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResult<MemoDto>> GetMemo([FromQuery] GetMemoQuery query)
        {
            var result = await _mediator.Send(query, HttpContext.RequestAborted);
            return ApiResult<MemoDto>.Success(result);
        }

        [HttpGet]
        public async Task<ApiResult<List<MemoDto>>> GetListMemo([FromQuery] GetListMemoQuery query)
        {
            var result = await _mediator.Send(query, HttpContext.RequestAborted);
            return ApiResult<List<MemoDto>>.Success(result);
        }

        [HttpPost]
        public async Task<ApiResult<int>> AddMemo([FromBody] AddMemoCommand command)
        {
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return ApiResult<int>.Success(result);
        }

        [HttpPost]
        public async Task<ApiResult> UpdateMemo([FromBody] UpdateMemoCommand command)
        {
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return result ? ApiResult.Success() : ApiResult.Error("修改失败");
        }

        [HttpPost]
        public async Task<ApiResult> DeleteMemo([FromBody] DeleteMemoCommand command)
        {
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return result ? ApiResult.Success() : ApiResult.Error("删除失败");
        }
    }
}