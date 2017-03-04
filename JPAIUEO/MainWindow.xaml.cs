using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using JPAIUEO.Base;

namespace JPAIUEO
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        static Yin m_yin = new Yin();

        public MainWindow()
        {
            InitializeComponent();
            AllowsTransparency = true;
            this.btnMenuMain.ContextMenu = null;
            RandomData();

            //var t = new DispatcherTimer(TimeSpan.FromSeconds(5), DispatcherPriority.Normal, Tick, this.Dispatcher);
            //transitioning.Content = new TextBlock { Text = "", SnapsToDevicePixels = true, TextAlignment = TextAlignment.Center };
        }

        void Tick(object sender, EventArgs e)
        {
            //var dateTime = DateTime.Now;
            //transitioning.Content = new TextBlock { Text = "Transitioning Content! " + dateTime, SnapsToDevicePixels = true , TextAlignment = TextAlignment.Center};
        }


        private void textBlockMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// 主菜单点击打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenuMain_Click(object sender, RoutedEventArgs e)
        {
            this.menuMain.PlacementTarget = this.btnMenuMain;
            this.menuMain.Placement = PlacementMode.Bottom;
            this.menuMain.IsOpen = true;
        }


        private void textBlockMainLuoMa_MouseEnter(object sender, MouseEventArgs e)
        {
            textBlockMainLuoMa.Foreground = new SolidColorBrush(Color.FromRgb(54, 54, 54));
        }

        private void textBlockMainLuoMa_MouseLeave(object sender, MouseEventArgs e)
        {
            textBlockMainLuoMa.Foreground = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMainClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void RandomData()
        {
            MainWindow.m_yin = YinData.GetYinRandom();
            textBlockMain.Text = m_yin.ping;
            textBlockMainPianJia.Text = m_yin.pian;
            textBlockMainLuoMa.Text = m_yin.luoma;
            textBlockMainLuoMa.Foreground = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
        }

        /// <summary>
        /// 切换当前的音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBlockMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RandomData();
            textBlockTransitioning.Text = "";
        }

        /// <summary>
        /// 得到一个含有当前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBlockMainLuoMa_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var doc = DocData.GetYinDoc(m_yin);
            textBlockTransitioning.Text = doc.fullString;
        }
    }
}
