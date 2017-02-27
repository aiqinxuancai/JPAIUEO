using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace JPAIUEO.Base
{
    class Yin
    {
        public string ping { get; set; }
        public string pian { get; set; }
        public string luoma { get; set; }
        public string baseLine { get; set; }
    }

    

    class YinData
    {
        static ArrayList listYin = new ArrayList();

        public static void InitData()
        {
            JObject root = JObject.Parse(Properties.Resources.data);
            foreach (var item in root)
            {
                foreach (JObject yin in item.Value)
                {
                    Yin y = new Yin { ping = yin["ping"].ToString(),
                        pian = yin["pian"].ToString(),
                        luoma = yin["luoma"].ToString(),
                        baseLine = item.Key
                    };
                    listYin.Add(y);
                }
            }
            //PingToYinText("イカくつした");


        }

        public static Yin GetYin(string _luoma)
        {
            var yin = (Yin)listYin.ToArray().First(e => ((Yin)e).luoma == _luoma);
            return yin;
        }

        /// <summary>
        /// 根据平假名片假名获取其音
        /// </summary>
        /// <param name="_ping"></param>
        /// <returns></returns>
        public static Yin PingToYin(string _ping)
        {
            var yin = (Yin)listYin.ToArray().FirstOrDefault(e => ((Yin)e).ping == _ping || ((Yin)e).pian == _ping);
            //var data = from Yin y in listYin where y.luoma == _luoma select y;

            return yin;
        }

        /// <summary>
        /// 用于完整翻译平假名文本串到音字符串 如果有失败 则返回空
        /// </summary>
        /// <param name="_luoma"></param>
        /// <returns></returns>
        public static string PingToYinText(string _text)
        {
            string full = "";
            foreach (var item in _text) 
            {
                var yin = PingToYin(item.ToString());
                if (yin != null)
                    return "";
            }
            return full;
        }

        /// <summary>
        /// 随机取一个音
        /// </summary>
        /// <returns></returns>
        public static Yin GetYinRandom()
        {
            Random a = new Random();
            var id = a.Next(0, listYin.Count - 1);
            return (Yin)listYin[id];
        }



    }
}
