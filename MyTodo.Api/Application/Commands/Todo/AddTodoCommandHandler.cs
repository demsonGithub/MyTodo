using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Commands
{
    public class AddTodoCommandHandler : IRequestHandler<AddTodoCommand, int>
    {
        private readonly ITodoRepository _todoRepository;

        public AddTodoCommandHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<int> Handle(AddTodoCommand request, CancellationToken cancellationToken)
        {
            string title = request.Title;
            string content = request.Content;
            int status = request.Status;

            var targetModel = Todo.Create(title, content, status);

            var entity = await _todoRepository.AddAsync(targetModel);

            await _todoRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return entity.Id;
        }
    }
}