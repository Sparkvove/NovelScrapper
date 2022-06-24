using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicNovelScrapper
{
    public class JsonService
    {
        public JsonService(List<Novel> novels)
        {
            string filename = "LightNovelPubNovels.txt";
            string json = JsonConvert.SerializeObject(novels.ToArray());
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + filename,json);
        }
    }
}
