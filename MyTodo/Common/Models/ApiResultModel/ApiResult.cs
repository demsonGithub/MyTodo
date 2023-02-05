using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Common.Models.ApiResultModel
{
    public class ApiResult<T>
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 响应结果
        /// </summary>
        public T data { get; set; }
    }
}