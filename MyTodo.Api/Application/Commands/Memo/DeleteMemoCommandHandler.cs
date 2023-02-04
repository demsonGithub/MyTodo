using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Commands
{
    public class DeleteMemoCommandHandler : IRequestHandler<DeleteMemoCommand, bool>
    {
        private readonly IMemoRepository _memoRepository;

        public DeleteMemoCommandHandler(IMemoRepository memoRepository)
        {
            _memoRepository = memoRepository;
        }

        public async Task<bool> Handle(DeleteMemoCommand request, CancellationToken cancellationToken)
        {
            await _memoRepository.DeleteAsync(request.Id);

            return await _memoRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}