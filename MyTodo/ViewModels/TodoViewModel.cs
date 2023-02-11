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
using System.Threading;
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
            set { _currentDto = value; RaisePropertyChanged(); }
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }
        public DelegateCommand<TodoDto> SelectedCommand { get; private set; }
        public DelegateCommand<TodoDto> DeleteCommand { get; private set; }

        public TodoViewModel(IContainerProvider containerProvider, ITodoService todoService) : base(containerProvider)
        {
            _todoService = todoService;

            TodoDtos = new ObservableCollection<TodoDto>();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            SelectedCommand = new DelegateCommand<TodoDto>(Selected);
            DeleteCommand = new DelegateCommand<TodoDto>(Delete);
        }

        private void Execute(string cmdType)
        {
            switch (cmdType)
            {
                case "新增":
                    Add();
                    break;

                case "保存":
                    Save();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 添加待办
        /// </summary>
        private void Add()
        {
            CurrentDto = new TodoDto();
            IsRightDrawerOpen = true;
        }

        private async void Save()
        {
            if (string.IsNullOrWhiteSpace(CurrentDto.Title) ||
                string.IsNullOrWhiteSpace(CurrentDto.Content))
                return;

            WaitLoading(true);
            try
            {
                if (CurrentDto.Id > 0)
                {
                    // 修改
                    var todoDto = await _todoService.UpdateAsync(CurrentDto);

                    var target = TodoDtos.FirstOrDefault(x => x.Id == todoDto.Id);
                    if (target != null)
                    {
                        target.Title = CurrentDto.Title;
                        target.Content = CurrentDto.Content;
                        target.Status = CurrentDto.Status;
                    }
                    IsRightDrawerOpen = false;
                }
                else
                {
                    // 新增
                    var todoDto = await _todoService.AddAsync(CurrentDto);
                    TodoDtos.Add(todoDto);
                    IsRightDrawerOpen = false;
                }
            }
            catch
            {
            }
            finally
            {
                WaitLoading(false);
            }
        }

        private async void Selected(TodoDto todoDto)
        {
            var todoResult = await _todoService.GetAsync(todoDto.Id);

            CurrentDto = todoResult;
            IsRightDrawerOpen = true;
        }

        private async void Delete(TodoDto obj)
        {
            await _todoService.DeleteAsync(obj.Id);
            TodoDtos.Remove(obj);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            GetDataAsync();
        }

        private async void GetDataAsync()
        {
            WaitLoading(true);
            TodoDtos.Clear();

            var todoDtoList = await _todoService.GetListAsync(1, 20);

            foreach (var item in todoDtoList.DataList)
            {
                TodoDtos.Add(item);
            }

            WaitLoading(false);
        }
    }
}