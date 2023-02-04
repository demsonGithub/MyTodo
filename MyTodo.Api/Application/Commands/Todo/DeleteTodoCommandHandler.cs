using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Commands
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, bool>
    {
        private readonly ITodoRepository _todoRepository;

        public DeleteTodoCommandHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            await _todoRepository.DeleteAsync(request.Id);

            return await _todoRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}