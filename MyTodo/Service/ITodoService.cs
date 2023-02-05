using MyTodo.Common.Models;
using MyTodo.Common.Models.ApiResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Service
{
    public interface ITodoService
    {
        Task<TodoDto> GetAsync(int id);

        Task<PageResult<TodoDto>> GetListAsync(int pageNum, int pageSize, string keywords = "");
    }
}