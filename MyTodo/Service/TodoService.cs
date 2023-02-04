using MyTodo.Api.Shared.Dtos;
using MyTodo.Shared.ApiResultModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Service
{
    public class TodoService : ITodoService
    {
        public Task<TodoDto> Get(int id)
        {
            var request = new HttpRestRequest();
            request.Method = Method.Get;
            request.Route = $"http://localhost:5212/api/Todo/GetTodo";
        }

        public Task<PageResult<TodoDto>> GetListAsync(int pageNum, int pageSize, string keywords)
        {
            throw new NotImplementedException();
        }
    }
}