using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Commands
{
    public class UpdateMemoCommandHandler : IRequestHandler<UpdateMemoCommand, bool>
    {
        private readonly IMemoRepository _memoRepository;

        public UpdateMemoCommandHandler(IMemoRepository memoRepository)
        {
            _memoRepository = memoRepository;
        }

        public async Task<bool> Handle(UpdateMemoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _memoRepository.GetAsync(request.Id);

            entity.SetAllProperty(request.Title, request.Content);

            return await _memoRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}