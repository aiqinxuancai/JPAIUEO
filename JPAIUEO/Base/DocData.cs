using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace JPAIUEO.Base
{

    class Doc
    {
        public string fullString { get; set; }
        /// <summary>
        /// 平假名
        /// </summary>
        public string ping { get; set; }
        public string luoma { get; set; }
        public string jp { get; set; }
        public string cn { get; set; }
        public string baseText { get; set; }
    }

    class DocData
    {
        static ArrayList docList = new ArrayList();

        public static void InitData()
        {
            var zz = @"●(.*)\s*（(.*)）[①②③0○\s]*(.*)\r\n";
            Regex reg = new Regex(zz);
            var match = reg.Matches(Properties.Resources.danci2);
            foreach(Match line in match)
            {
                var groups = line.Groups;
                if (groups.Count == 4)
                {
                    Doc y = new Doc
                    {
                        baseText = groups[0].ToString(),
                        fullString = groups[1].ToString().Trim(" ".ToArray()) + " - " + groups[2].ToString() + "(" + YinData.PingToYinText(groups[2].ToString()) + ") - " + groups[3].ToString().Trim(" ".ToArray()),
                        ping = groups[2].ToString().Trim(" ".ToArray()),
                        luoma = YinData.PingToYinText(groups[2].ToString()).Trim(" ".ToArray()),
                        jp = groups[1].ToString().Trim(" ".ToArray()),
                        cn = groups[3].ToString().Trim(" ".ToArray())
                    };
                    docList.Add(y);

                    //foreach (Group data in groups)
                    //{
                    //    Debug.WriteLine(data.Value);
                    //}
                }
            }
        }


        public static Doc GetYinDoc(Yin yin)
        {
            var newList = docList.ToArray().Where(e => ((Doc)e).ping.Contains(yin.ping)).ToList();
            Random a = new Random();
            var id = a.Next(0, newList.Count - 1);
            var ret = (Doc)newList[id];
            if (ret == null)
                return new Doc();
            return ret;
        }
    }
}
