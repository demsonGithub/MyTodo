using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Queries
{
    public class GetListTodoQueryHandler : IRequestHandler<GetListTodoQuery, List<TodoDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITodoRepository _todoRepository;

        public GetListTodoQueryHandler(IMapper mapper, ITodoRepository todoRepository)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;
        }

        public async Task<List<TodoDto>> Handle(GetListTodoQuery request, CancellationToken cancellationToken)
        {
            var todolist = await _todoRepository.GetListAsync(i => EF.Functions.Like(i.Title, $"%{request.Keywords}%"));

            var todoDtolist = _mapper.Map<List<TodoDto>>(todolist);

            return todoDtolist;
        }
    }
}