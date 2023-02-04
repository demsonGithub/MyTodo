using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Queries
{
    public class GetMemoQueryHandler : IRequestHandler<GetMemoQuery, MemoDto>
    {
        private readonly IMapper _mapper;
        private readonly IMemoRepository _memoRepository;

        public GetMemoQueryHandler(IMapper mapper, IMemoRepository memoRepository)
        {
            _mapper = mapper;
            _memoRepository = memoRepository;
        }

        public async Task<MemoDto> Handle(GetMemoQuery request, CancellationToken cancellationToken)
        {
            var entity = await _memoRepository.GetAsync(request.Id);

            var memoDto = _mapper.Map<MemoDto>(entity);

            return memoDto;
        }
    }
}