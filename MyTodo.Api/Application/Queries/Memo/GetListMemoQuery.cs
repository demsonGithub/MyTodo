namespace MyTodo.Api.Application.Queries
{
    public class GetListMemoQuery : IRequest<List<MemoDto>>
    {
        public string? Keywords { get; set; }
    }
}