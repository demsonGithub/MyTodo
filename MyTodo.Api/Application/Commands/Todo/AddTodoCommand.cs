namespace MyTodo.Api.Application.Commands
{
    public class AddTodoCommand : IRequest<TodoDetailDto>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
    }
}