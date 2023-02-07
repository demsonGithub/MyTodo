using ImTools;
using MyTodo.Common.Models;
using MyTodo.Service;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.ViewModels
{
    public class TodoViewModel : NavigationViewModel
    {
        private ObservableCollection<TodoDto> _todoDtos;
        private bool _isRightDrawerOpen;
        private readonly ITodoService _todoService;

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

        private TodoDto _currentDto;

        /// <summary>
        /// 新增/编辑选中的对象
        /// </summary>
        public TodoDto CurrentDto
        {
            get { return _currentDto; }
            set { _currentDto = value; }
        }

        public DelegateCommand AddTodoCommand { get; private set; }

        public DelegateCommand<TodoDto> SelectedCommand { get; private set; }

        public TodoViewModel(IContainerProvider containerProvider, ITodoService todoService) : base(containerProvider)
        {
            _todoService = todoService;

            TodoDtos = new ObservableCollection<TodoDto>();
            AddTodoCommand = new DelegateCommand(Add);
            SelectedCommand = new DelegateCommand<TodoDto>(Selected);
        }

        /// <summary>
        /// 添加待办
        /// </summary>
        private void Add()
        {
            IsRightDrawerOpen = true;
        }

        private async void Selected(TodoDto todoDto)
        {
            var todoResult = await _todoService.GetAsync(todoDto.Id);

            CurrentDto = todoResult;
            IsRightDrawerOpen = true;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            GetDataAsync();
        }

        private async void GetDataAsync()
        {
            WaitLoading(true);

            var todoDtoList = await _todoService.GetListAsync(1, 20);

            foreach (var item in todoDtoList.DataList)
            {
                TodoDtos.Add(item);
            }

            WaitLoading(false);
        }
    }
}