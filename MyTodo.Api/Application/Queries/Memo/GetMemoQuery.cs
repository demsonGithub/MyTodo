namespace MyTodo.Api.Application.Queries
{
    public class GetMemoQuery : IRequest<MemoDto>
    {
        public int Id { get; set; }
    }
}