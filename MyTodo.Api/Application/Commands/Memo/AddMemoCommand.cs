namespace MyTodo.Api.Application.Commands
{
    public class AddMemoCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}