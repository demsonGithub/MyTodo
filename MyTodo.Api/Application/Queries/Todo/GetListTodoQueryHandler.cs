using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Queries
{
    public class GetListTodoQueryHandler : IRequestHandler<GetListTodoQuery, PageResult<TodoDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITodoRepository _todoRepository;

        public GetListTodoQueryHandler(IMapper mapper, ITodoRepository todoRepository)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;
        }

        public async Task<PageResult<TodoDto>> Handle(GetListTodoQuery request, CancellationToken cancellationToken)
        {
            int pageNum = request.PageNum;
            int pageSize = request.PageSize;

            var todolist = await _todoRepository.GetListAsync(pageNum, pageSize, i => EF.Functions.Like(i.Title, $"%{request.Keywords}%"));

            var todoDtolist = _mapper.Map<List<TodoDto>>(todolist);

            var result = new PageResult<TodoDto>(pageNum, pageSize, 100, todoDtolist);

            return result;
        }
    }
}