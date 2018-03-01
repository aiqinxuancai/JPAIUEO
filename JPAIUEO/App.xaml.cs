using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using JPAIUEO.Base;
using JPAIUEO.Service;

namespace JPAIUEO
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

            ////var newInt = (b << 16) | a;

            AppSetting.Load();
            YinData.InitData();
            DocData.InitData();
        }
        
    }
}
