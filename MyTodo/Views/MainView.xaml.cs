using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyTodo.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            btnMin.Click += (sender, e) =>
            {
                this.WindowState = WindowState.Minimized;
            };

            btnMax.Click += (sender, e) =>
            {
                if (WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            };
            btnClose.Click += (sender, e) =>
            {
                this.Close();
            };

            ColorZone.MouseMove += (sender, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    this.DragMove();
            };

            ColorZone.MouseDoubleClick += (sender, e) =>
            {
                if (WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            };

            menuBar.SelectionChanged += (sender, e) =>
            {
                drawerHost.IsLeftDrawerOpen = false;
            };
        }
    }
}