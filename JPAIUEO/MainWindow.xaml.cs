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
using System.Threading;
using System.Diagnostics;

namespace JPAIUEO
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        static Yin m_yin = new Yin();

        bool isButtonPingDown = false;
        bool isButtonPianDown = false;

        public MainWindow()
        {
            InitializeComponent();

            this.borderPing.Visibility = Visibility.Hidden;
            this.borderPian.Visibility = Visibility.Hidden;

            AllowsTransparency = true;
            this.btnMenuMain.ContextMenu = null;
            RandomData();


            WindowAnswerYin.Load(null);
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
            buttonHand.Visibility = Visibility.Hidden;
            textBlockMainLuoMa.Foreground = new SolidColorBrush(Color.FromArgb(240, 255, 255, 255));
        }

        private void textBlockMainLuoMa_MouseLeave(object sender, MouseEventArgs e)
        {
            //把文字设置成透明
            buttonHand.Visibility = Visibility.Visible;
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
        private async void textBlockMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.isButtonPingDown = true;

            await Task.Run(() =>
            {
   
                for (int i= 0; i < 100; i++)
                {
                    Thread.Sleep(10);
                    if (this.isButtonPingDown == false)
                    {
                        return;
                    }
                    
                }

                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                {
                    if (this.isButtonPingDown == true)
                    {
                        //按下中，将平假名遮挡
                        borderPing.Visibility = Visibility.Visible;
                        this.isButtonPingDown = false;
                    }
                });
            });
        }



        private void textBlockMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.isButtonPingDown = false;
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

        private void borderPing_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            borderPing.Visibility = Visibility.Hidden;
        }

        private void borderPian_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            borderPian.Visibility = Visibility.Hidden;
        }

        private async void textBlockMainPianJia_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.isButtonPianDown = true;


            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(10);
                    if (this.isButtonPianDown == false)
                    {
                        return;
                    }

                }
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                {
                    if (this.isButtonPianDown == true)
                    {
                        //按下中，将平假名遮挡
                        borderPian.Visibility = Visibility.Visible;
                        this.isButtonPianDown = false;
                    }
                });
            });
        }

        private void textBlockMainPianJia_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.isButtonPianDown = false;
            RandomData();
            textBlockTransitioning.Text = "";
        }
    }
}
