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
    /// WindowFullYinViewCell.xaml 的交互逻辑
    /// </summary>
    public partial class WindowFullYinViewCell : UserControl
    {
        public string Roma { set; get; }
        public string Ping { set; get; }
        public string Pian { set; get; }


        public WindowFullYinViewCell()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        public WindowFullYinViewCell(string roma, string ping, string pian)
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
