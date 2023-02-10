using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Commands
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, TodoDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ITodoRepository _todoRepository;

        public UpdateTodoCommandHandler(IMapper mapper, ITodoRepository todoRepository)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;
        }

        public async Task<TodoDetailDto> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _todoRepository.GetAsync(request.Id);

            entity.SetAllProperty(request.Title, request.Content, request.Status);

            await _todoRepository.UnitOfWork.SaveEntitiesAsync();

            var result = _mapper.Map<TodoDetailDto>(entity);

            return result;
        }
    }
}