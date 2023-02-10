using MyTodo.Common.Models;
using MyTodo.Extensions;
using MyTodo.Views;
using Prism.Commands;
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
    public class MainViewModel : BindableBase
    {
        public MainViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();
            CreateMenuBar();
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            GoBackCommand = new DelegateCommand(() =>
            {
                if (_journal != null && _journal.CanGoBack)
                    _journal.GoBack();
            });

            GoForwardCommand = new DelegateCommand(() =>
            {
                if (_journal != null && _journal.CanGoForward)
                    _journal.GoForward();
            });

            _regionManager.RegisterViewWithRegion(PrismManager.MainViewRegionName, typeof(IndexView));
        }

        private readonly IRegionManager _regionManager;
        private IRegionNavigationJournal _journal;

        private ObservableCollection<MenuBar> _menuBars;

        public ObservableCollection<MenuBar> MenuBars
        {
            get
            {
                return _menuBars;
            }
            set { _menuBars = value; RaisePropertyChanged(); }
        }

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; private set; }

        private void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar { Icon = "Home", Title = "首页", NameSpace = "IndexView" });
            MenuBars.Add(new MenuBar { Icon = "NotebookOutline", Title = "待办事项", NameSpace = "TodoView" });
            MenuBars.Add(new MenuBar { Icon = "NotebookPlus", Title = "备忘录", NameSpace = "MemoView" });
            MenuBars.Add(new MenuBar { Icon = "Cog", Title = "设置", NameSpace = "SettingsView" });
        }

        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                return;

            _regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back =>
            {
                _journal = back.Context.NavigationService.Journal;
            });
        }
    }
}