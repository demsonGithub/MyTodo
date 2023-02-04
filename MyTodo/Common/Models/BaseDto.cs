using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Common.Models
{
    public class BaseDto
    {
        private int _id;
        private DateTime _createTime;
        private DateTime _modifyTime;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        public DateTime ModifyTime
        {
            get { return _modifyTime; }
            set { _modifyTime = value; }
        }
    }
}