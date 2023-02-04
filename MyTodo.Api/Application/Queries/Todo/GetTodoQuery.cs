using MediatR;

namespace MyTodo.Api.Application.Queries
{
    public class GetTodoQuery : IRequest<TodoDto>
    {
        public int Id { get; set; }
    }
}