using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Commands
{
    public class AddTodoCommandHandler : IRequestHandler<AddTodoCommand, TodoDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ITodoRepository _todoRepository;

        public AddTodoCommandHandler(IMapper mapper, ITodoRepository todoRepository)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;
        }

        public async Task<TodoDetailDto> Handle(AddTodoCommand request, CancellationToken cancellationToken)
        {
            string title = request.Title;
            string content = request.Content;
            int status = request.Status;

            var targetModel = Todo.Create(title, content, status);

            var entity = await _todoRepository.AddAsync(targetModel);

            await _todoRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            var result = _mapper.Map<TodoDetailDto>(entity);

            return result;
        }
    }
}