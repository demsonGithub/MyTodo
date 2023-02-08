using MediatR;

namespace MyTodo.Api.Application.Queries
{
    public class GetTodoDetailQuery : IRequest<TodoDetailDto>
    {
        public int Id { get; set; }
    }
}