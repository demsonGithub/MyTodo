using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Queries
{
    public class GetListMemoQueryHandler : IRequestHandler<GetListMemoQuery, List<MemoDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMemoRepository _memoRepository;

        public GetListMemoQueryHandler(IMapper mapper, IMemoRepository memoRepository)
        {
            _mapper = mapper;
            _memoRepository = memoRepository;
        }

        public async Task<List<MemoDto>> Handle(GetListMemoQuery request, CancellationToken cancellationToken)
        {
            var memolist = await _memoRepository.GetListAsync(i => EF.Functions.Like(i.Title, $"%{request.Keywords}%"));

            var memoDtolist = _mapper.Map<List<MemoDto>>(memolist);

            return memoDtolist;
        }
    }
}