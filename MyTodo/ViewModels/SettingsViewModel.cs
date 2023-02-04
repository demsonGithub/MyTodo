using MyTodo.Common.Models;
using MyTodo.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace MyTodo.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        private ObservableCollection<MenuBar> _menuBars;
        private readonly IRegionManager _regionManager;

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return _menuBars; }
            set { _menuBars = value; RaisePropertyChanged(); }
        }

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }

        public SettingsViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            CreateMockData();
            _regionManager = regionManager;
        }

        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                return;

            _regionManager.Regions[PrismManager.SettingsViewRegionName].RequestNavigate(obj.NameSpace);
        }

        private void CreateMockData()
        {
            MenuBars.Add(new MenuBar { Icon = "Palette", Title = "个性化", NameSpace = "IndividuationView" });
            MenuBars.Add(new MenuBar { Icon = "Cog", Title = "系统设置", NameSpace = "SystemSetView" });
            MenuBars.Add(new MenuBar { Icon = "Information", Title = "关于更多", NameSpace = "AboutView" });
        }
    }
}