using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace JPAIUEO.Service
{
    class AppSetting
    {

        public bool OpenQingYin { set; get; }
        public bool OpenZhuoYin { set; get; }
        public bool OpenBanZhuoYin { set; get; }

        public static AppSetting m_appSetting;
        public static object m_lock = new object();


        public static void Init()
        {
            m_appSetting = new AppSetting();
            m_appSetting.OpenQingYin = true;
            m_appSetting.OpenZhuoYin = false;
            m_appSetting.OpenBanZhuoYin = false;
            Save();
        }

        public static bool Load()
        {
            if (File.Exists(@".\config.json"))
            {
                try
                {
                	m_appSetting = JsonConvert.DeserializeObject<AppSetting>(File.ReadAllText(@".\config.json"));
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    if (m_appSetting == null)
                    {
                        Init();
                    }
                }
            }
            else
            {
                Init();
            }
            return true;
        }


        public static void Save()
        {
            lock(m_lock)
            {
                File.WriteAllText(@".\config.json", JsonConvert.SerializeObject(m_appSetting));
            }
            
        }







    }
}
