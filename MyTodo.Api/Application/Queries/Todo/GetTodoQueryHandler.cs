using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Queries
{
    public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, TodoDto>
    {
        private readonly IMapper _mapper;
        private readonly ITodoRepository _todoRepository;

        public GetTodoQueryHandler(IMapper mapper, ITodoRepository todoRepository)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;
        }

        public async Task<TodoDto> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            var entity = await _todoRepository.GetAsync(request.Id);

            var todoDto = _mapper.Map<TodoDto>(entity);

            return todoDto;
        }
    }
}