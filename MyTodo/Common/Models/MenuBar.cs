using Prism.Mvvm;

namespace MyTodo.Common.Models
{
    /// <summary>
    /// 系统导航菜单实体类
    /// </summary>
    public class MenuBar : BindableBase
    {
        private string _icon;

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        private string _title;

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _nameSpace;

        /// <summary>
        /// 菜单命名空间
        /// </summary>
        public string NameSpace
        {
            get { return _nameSpace; }
            set { _nameSpace = value; }
        }
    }
}