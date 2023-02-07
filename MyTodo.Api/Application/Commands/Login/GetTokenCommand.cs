namespace MyTodo.Api.Application.Commands
{
    public class GetTokenCommand : IRequest<string>
    {
        public string Account { get; set; }

        public string Password { get; set; }
    }
}