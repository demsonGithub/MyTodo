namespace MyTodo.Api.Application.Commands
{
    public class UpdateMemoCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}