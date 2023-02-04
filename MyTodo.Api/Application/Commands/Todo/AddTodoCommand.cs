namespace MyTodo.Api.Application.Commands
{
    public class AddTodoCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
    }
}