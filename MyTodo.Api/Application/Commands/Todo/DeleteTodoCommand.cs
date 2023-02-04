namespace MyTodo.Api.Application.Commands
{
    public class DeleteTodoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}