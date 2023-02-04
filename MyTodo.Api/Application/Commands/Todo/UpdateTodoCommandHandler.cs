using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Commands
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, bool>
    {
        private readonly ITodoRepository _todoRepository;

        public UpdateTodoCommandHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<bool> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _todoRepository.GetAsync(request.Id);

            entity.SetAllProperty(request.Title, request.Content, request.Status);

            return await _todoRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}