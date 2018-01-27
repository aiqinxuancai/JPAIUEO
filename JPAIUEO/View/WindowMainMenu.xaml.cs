using JPAIUEO.Service;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace JPAIUEO.View
{
    /// <summary>
    /// WindowMainMenu.xaml 的交互逻辑
    /// </summary>
    public partial class WindowMainMenu : MetroWindow
    {
        public WindowMainMenu()
        {
            InitializeComponent();
            //menuView.exitThisProcessDelegate += MenuView_exitThisProcessDelegate;
        }

        private void MenuView_exitThisProcessDelegate()
        {
            throw new NotImplementedException();
        }

        private void windowMainMenu_LostFocus(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine("LostFocus");
        }

        public static void Load()
        {
            WindowMainMenu window = new WindowMainMenu();

            Win32.POINT point = new Win32.POINT();
            Win32.GetCursorPos(out point);

            double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度

            window.Left = point.X - window.Width;
            window.Top = point.Y - window.Height;

            window.Show();

        }

        private void windowMainMenu_Deactivated(object sender, EventArgs e)
        {
            this.Close();
        }

        private void windowMainMenu_Loaded(object sender, RoutedEventArgs e)
        {
            this.Activate();
        }
    }
}
