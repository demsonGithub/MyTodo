using MediatR;

namespace MyTodo.Api.Application.Queries
{
    public class GetListTodoQuery : IRequest<List<TodoDto>>
    {
        public string? Keywords { get; set; }
    }
}