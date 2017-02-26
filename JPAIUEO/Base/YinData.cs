using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;

namespace JPAIUEO.Base
{
    class Yin
    {
        public string ping { get; set; }
        public string pian { get; set; }
        public string luoma { get; set; }
    }

    

    class YinData
    {
        static ArrayList listYin = new ArrayList();

        public static void InitData()
        {
            //listYin.Add(new Yin { ping = "あ",  pian = , luoma = "a"  });
            var text = Properties.Resources.YinText.Replace("\r", "");
            var data = text.Split("\n".ToCharArray());

            for ( int i = 0; i < data.Length; i++)
            {
                Yin y = new Yin { ping = data[i], pian = data[i + 1], luoma = data[i + 2] };

                listYin.Add(y);

                i = i + 2;

            }

            //var jsonVer = JsonConvert.SerializeObject(listYin);
            //File.WriteAllText("data.json", jsonVer);
            
            //JsonConvert.DeserializeObject<Yin[]>(jsonVer)

            //GetYin("a");
        }

        public static Yin GetYin(string _luoma)
        {
            var yin = (Yin)listYin.ToArray().First(e => ((Yin)e).luoma == _luoma);
            //var data = from Yin y in listYin where y.luoma == _luoma select y;
            return yin;
        }

        public static Yin GetYinRandom()
        {
            Random a = new Random();
            var id = a.Next(0, listYin.Count - 1);
            return (Yin)listYin[id];
        }



    }
}
