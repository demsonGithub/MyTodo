using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Service
{
    public interface IHttpService
    {
        Task<TResponse> GetAsync<TResponse>(string url) where TResponse : class;

        Task<TResponse> PostAsync<TResponse>(string url, object? parameter) where TResponse : class;
    }
}