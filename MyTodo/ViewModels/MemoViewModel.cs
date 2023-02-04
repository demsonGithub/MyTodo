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
    public class MemoViewModel : BindableBase
    {
        private bool _isRightDrawerOpen;
        private ObservableCollection<MemoDto> _memoDtos;

        public bool IsRightDrawerOpen
        {
            get { return _isRightDrawerOpen; }
            set { _isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return _memoDtos; }
            set { _memoDtos = value; RaisePropertyChanged(); }
        }

        public DelegateCommand AddMemoCommand { get; private set; }

        public MemoViewModel()
        {
            MemoDtos = new ObservableCollection<MemoDto>();
            AddMemoCommand = new DelegateCommand(Add);
            CreateMockData();
        }

        private void CreateMockData()
        {
            for (int i = 0; i < 20; i++)
            {
                MemoDtos.Add(new MemoDto() { Id = i, Title = $"备忘录{i}", Content = $"内容...{i}" });
            }
        }

        private void Add()
        {
            IsRightDrawerOpen = true;
        }
    }
}