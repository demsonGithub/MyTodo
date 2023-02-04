using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Common.Models
{
    /// <summary>
    /// 待办事项
    /// </summary>
    public class TodoDto : BaseDto
    {
        private string _title;
        private string _content;
        private int _status;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}