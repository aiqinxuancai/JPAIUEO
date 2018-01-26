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

    enum YIN_TYPE { QING, ZHUO, BANZHUO };

    class Yin
    {
        /// <summary>
        /// 平假名
        /// </summary>
        public string ping { get; set; }
        /// <summary>
        /// 片假名
        /// </summary>
        public string pian { get; set; }
        /// <summary>
        /// 罗马音读音
        /// </summary>
        public string pronunciation { get; set; }
        /// <summary>
        /// 元音
        /// </summary>
        public string baseLine { get; set; }

        /// <summary>
        /// 音类型（清音 浊音 半浊音）
        /// </summary>
        public YIN_TYPE type { get; set; }
        
    }

    

    class YinData
    {
        static ArrayList listYin = new ArrayList();

        public static void InitData()
        {
            JObject root = JObject.Parse(Encoding.UTF8.GetString(Properties.Resources.data));

            //载入清音
            JObject qingRoot = (JObject)root["qing"];
            
            foreach (var item in qingRoot)
            {
                foreach (JObject yin in item.Value)
                {
                    Yin y = new Yin {
                        ping = yin["ping"].ToString(),
                        pian = yin["pian"].ToString(),
                        pronunciation = yin["pronunciation"].ToString(),
                        baseLine = item.Key,
                        type = YIN_TYPE.QING
                    };
                    listYin.Add(y);
                }
            }
            //PingToYinText("イカくつした");


        }

        public static Yin GetYin(string _luoma)
        {
            var yin = (Yin)listYin.ToArray().First(e => ((Yin)e).pronunciation == _luoma);
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
                if (yin == null)
                {
                    full += item.ToString();
                    continue;
                }
                    
                full += yin.pronunciation;
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
