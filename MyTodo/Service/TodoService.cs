using MyTodo.Common.Constants;
using MyTodo.Common.Models;
using MyTodo.Common.Models.ApiResultModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
            var requestUrl = Settings.ApiBaseUrl + $"/api/todo/GetTodoDetail?Id={id}";

            var result = await _httpService.GetAsync<ApiResult<TodoDto>>(requestUrl);

            return result.data;
        }

        public async Task<PageResult<TodoDto>> GetListAsync(int pageNum, int pageSize, string keywords = "")
        {
            var requestUrl = Settings.ApiBaseUrl + $"/api/todo/GetListTodo?PageNum={pageNum}&PageSize={pageSize}&Keywords={keywords}";

            var result = await _httpService.GetAsync<ApiResult<PageResult<TodoDto>>>(requestUrl);

            return result.data;
        }

        public async Task<TodoDto> AddAsync(TodoDto dto)
        {
            var requestUrl = Settings.ApiBaseUrl + $"/api/todo/AddTodo";

            var parameter = new
            {
                Title = dto.Title,
                Content = dto.Content,
                Status = dto.Status,
            };

            var result = await _httpService.PostAsync<ApiResult<TodoDto>>(requestUrl, parameter);

            return result.data;
        }
    }
}