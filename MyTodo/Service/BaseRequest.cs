using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Service
{
    public class BaseRequest
    {
        public int TimeOut { get; set; } = 300;

        public Method Method { get; set; }

        public string? Url { get; set; }

        public string ContentType { get; set; } = "application/json";

        public object? Parameter { get; set; }
    }
}