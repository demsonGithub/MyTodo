namespace MyTodo.Api.Application.Commands
{
    public class DeleteMemoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}