using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyTodo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ApiResult<string>> GetToken([FromBody] GetTokenCommand command)
        {
            var result = await _mediator.Send(command, HttpContext.RequestAborted);

            return ApiResult<string>.Success(result);
        }
    }
}