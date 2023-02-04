using MyTodo.Api.Shared.ApiResultModel;
using MyTodo.Api.Shared.Dtos;
using MyTodo.Shared.ApiResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Service
{
    public interface ITodoService
    {
        Task<TodoDto> Get(int id);

        Task<PageResult<TodoDto>> GetListAsync(int pageNum, int pageSize, string keywords);
    }
}