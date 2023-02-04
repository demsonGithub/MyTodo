using MyTodo.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.ViewModels
{
    public class TodoViewModel : BindableBase
    {
        private ObservableCollection<TodoDto> _todoDtos;
        private bool _isRightDrawerOpen;

        public ObservableCollection<TodoDto> TodoDtos
        {
            get { return _todoDtos; }
            set { _todoDtos = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 右侧抽屉窗口是否展开
        /// </summary>
        public bool IsRightDrawerOpen
        {
            get { return _isRightDrawerOpen; }
            set { _isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        public DelegateCommand AddTodoCommand { get; private set; }

        public TodoViewModel()
        {
            TodoDtos = new ObservableCollection<TodoDto>();
            AddTodoCommand = new DelegateCommand(Add);
            CreateMockData();
        }

        /// <summary>
        /// 添加待办
        /// </summary>
        private void Add()
        {
            IsRightDrawerOpen = true;
        }

        private void CreateMockData()
        {
            for (int i = 0; i < 20; i++)
            {
                TodoDtos.Add(new TodoDto() { Id = i, Title = $"待办{i}", Content = $"内容...{i}" });
            }
        }
    }
}