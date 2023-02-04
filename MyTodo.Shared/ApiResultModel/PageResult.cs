using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Shared.ApiResultModel
{
    public class PageResult<T>
    {
        public int PageNum { get; set; }

        public int PageSize { get; set; }

        public int Total { get; set; }

        public List<T> DataList { get; set; }

        public PageResult(int pageNum, int pageSize, int total, List<T> dataList)
        {
            PageNum = pageNum;
            PageSize = pageSize;
            Total = total;
            DataList = dataList;
        }
    }
}