namespace MyTodo.Api.Application.Commands
{
    public class UpdateTodoCommand : IRequest<TodoDetailDto>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int Status { get; set; }
    }
}