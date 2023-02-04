using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Common.Models
{
    /// <summary>
    /// 任务栏
    /// </summary>
    public class TaskBar : BindableBase
    {
        private string _icon;
        private string _title;
        private string _content;
        private string _color;
        private string _target;

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        /// 触发目标
        /// </summary>
        public string Target
        {
            get { return _target; }
            set { _target = value; }
        }
    }
}