using MyTodo.Common.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.ViewModels
{
    public class IndexViewModel : BindableBase
    {
        private ObservableCollection<TaskBar> _taskBars;
        private ObservableCollection<TodoDto> _todoDtos;
        private ObservableCollection<MemoDto> _memoDtos;

        public ObservableCollection<TaskBar> TaskBars
        {
            get { return _taskBars; }
            set { _taskBars = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<TodoDto> TodoDtos
        {
            get { return _todoDtos; }
            set { _todoDtos = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return _memoDtos; }
            set { _memoDtos = value; RaisePropertyChanged(); }
        }

        public IndexViewModel()
        {
            TaskBars = new ObservableCollection<TaskBar>();
            CreateTaskBars();
            CreateMockData();
        }

        private void CreateTaskBars()
        {
            TaskBars.Add(new TaskBar { Icon = "ClockFast", Title = "汇总", Content = "9", Color = "#FF0CA0FF", Target = "" });
            TaskBars.Add(new TaskBar { Icon = "ClockCheckOutline", Title = "已完成", Content = "9", Color = "#FF1ECA3A", Target = "" });
            TaskBars.Add(new TaskBar { Icon = "ChartLineVariant", Title = "完成比例", Content = "100%", Color = "#FF02C6DC", Target = "" });
            TaskBars.Add(new TaskBar { Icon = "PlaylistStar", Title = "备忘录", Content = "19", Color = "#FFFFA000", Target = "" });
        }

        private void CreateMockData()
        {
            TodoDtos = new ObservableCollection<TodoDto>();
            MemoDtos = new ObservableCollection<MemoDto>();

            for (int i = 0; i < 10; i++)
            {
                TodoDtos.Add(new TodoDto() { Id = i, Title = $"待办事项{i}", Content = $"内容{i}" });

                MemoDtos.Add(new MemoDto() { Id = i, Title = $"备忘录{i}", Content = $"备忘录内容{i}" });
            }
        }
    }
}