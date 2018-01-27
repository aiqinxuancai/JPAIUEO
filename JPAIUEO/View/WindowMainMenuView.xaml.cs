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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JPAIUEO.View
{
    /// <summary>
    /// WindowMainMenuView.xaml 的交互逻辑
    /// </summary>
    public partial class WindowMainMenuView : UserControl
    {

        //public delegate void ExitThisProcessDelegate();
        //public event ExitThisProcessDelegate exitThisProcessDelegate;

        public WindowMainMenuView()
        {
            InitializeComponent();



        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            //退出
            System.Environment.Exit(0);
        }




    }
}
