namespace MyTodo.Api.Application.Queries
{
    public class GetListMemoQuery : IRequest<List<MemoDto>>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string? Keywords { get; set; }
    }
}