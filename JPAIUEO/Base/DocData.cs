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
        public string ping { get; set; }
        public string pian { get; set; }
        public string luoma { get; set; }
        public string baseLine { get; set; }
    }

    class DocData
    {
        static ArrayList docList = new ArrayList();

        public static void InitData()
        {
            var zz = @"●(.*)\s*（(.*)）[0①②③○\s]*(.*)";
            Regex reg = new Regex(zz);
            var match = reg.Matches(Properties.Resources.danci2);
            foreach(Match line in match)
            {
                var groups = line.Groups;
                if (groups.Count == 3)
                {



                    foreach (Group data in groups)
                    {
                        Debug.WriteLine(data.Value);
                    }
                }
            }
        }



    }
}
