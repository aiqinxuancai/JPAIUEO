using MahApps.Metro.Controls;
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
using MahApps;
using System.Windows.Controls.Primitives;

namespace JPAIUEO
{
    /// <summary>
    /// WindowAnswerYin.xaml 的交互逻辑
    /// </summary>
    public partial class WindowAnswerYin : MetroWindow
    {
        public WindowAnswerYin()
        {
            InitializeComponent();
            AllowsTransparency = true;
            label2.Inlines.Add(new Run("a") {  Foreground = Brushes.Orange});
        }

        public static void Load(object from)
        {
            WindowAnswerYin window = new WindowAnswerYin();
            //window.Owner = (MainWindow)from;
            //window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //window.ShowDialog();

            double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            //double x1 = SystemParameters.PrimaryScreenWidth;//得到屏幕整体宽度
            //double y1 = SystemParameters.PrimaryScreenHeight;//得到屏幕整体高度

            window.Left = x - window.Width - 10;
            window.Top = y - window.Height;

            window.Show();

            
        }

        private void toggleButtonUnChecked()
        {
            this.toggleButton1.IsChecked = false;
            this.toggleButton2.IsChecked = false;
            this.toggleButton3.IsChecked = false;
            this.toggleButton4.IsChecked = false;
        }


        private void toggleButton_Click(object sender, RoutedEventArgs e)
        {
            

            toggleButtonUnChecked();
            ((ToggleButton)sender).IsChecked = true;
        }
    }
}
