using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Commands
{
    public class AddMemoCommandHandler : IRequestHandler<AddMemoCommand, int>
    {
        private readonly IMemoRepository _memoRepository;

        public AddMemoCommandHandler(IMemoRepository memoRepository)
        {
            _memoRepository = memoRepository;
        }

        public async Task<int> Handle(AddMemoCommand request, CancellationToken cancellationToken)
        {
            string title = request.Title;
            string content = request.Content;

            var targetModel = Memo.Create(title, content);

            var entity = await _memoRepository.AddAsync(targetModel);

            await _memoRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return entity.Id;
        }
    }
}