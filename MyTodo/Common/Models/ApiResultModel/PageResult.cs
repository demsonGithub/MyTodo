using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTodo;
using MyTodo.Common;
using MyTodo.Common.Models;
using MyTodo.Common.Models.ApiResultModel;

namespace MyTodo.Common.Models.ApiResultModel
{
    public class PageResult<T>
    {
        public int PageNum { get; set; }

        public int PageSize { get; set; }

        public int Total { get; set; }

        public List<T> DataList { get; set; }
    }
}