using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Queries
{
    public class GetTodoDetailQueryHandler : IRequestHandler<GetTodoDetailQuery, TodoDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ITodoRepository _todoRepository;

        public GetTodoDetailQueryHandler(IMapper mapper, ITodoRepository todoRepository)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;
        }

        public async Task<TodoDetailDto> Handle(GetTodoDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _todoRepository.GetAsync(request.Id);

            var todoDto = _mapper.Map<TodoDetailDto>(entity);

            return todoDto;
        }
    }
}