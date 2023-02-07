using MyTodo.Common.Constants;
using MyTodo.Common.Models;
using MyTodo.Common.Models.ApiResultModel;
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
        private IHttpService _httpService;

        public TodoService()
        {
            _httpService = new HttpRestSharpService(new RestClient());
        }

        public async Task<TodoDto> GetAsync(int id)
        {
            var requestUrl = Settings.ApiBaseUrl + $"/api/todo/GetTodo?Id={id}";

            var result = await _httpService.GetAsync<ApiResult<TodoDto>>(requestUrl);

            return result.data;
        }

        public async Task<PageResult<TodoDto>> GetListAsync(int pageNum, int pageSize, string keywords = "")
        {
            var requestUrl = Settings.ApiBaseUrl + $"/api/todo/GetListTodo?PageNum={pageNum}&PageSize={pageSize}&Keywords={keywords}";

            var result = await _httpService.GetAsync<ApiResult<PageResult<TodoDto>>>(requestUrl);

            return result.data;
        }
    }
}