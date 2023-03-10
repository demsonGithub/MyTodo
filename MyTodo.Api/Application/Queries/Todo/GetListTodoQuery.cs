using MediatR;

namespace MyTodo.Api.Application.Queries
{
    public class GetListTodoQuery : IRequest<PageResult<TodoDetailDto>>
    {
        public int PageNum { get; set; }

        public int PageSize { get; set; }

        public string? Keywords { get; set; }
    }
}