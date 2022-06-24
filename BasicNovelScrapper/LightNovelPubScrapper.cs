using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicNovelScrapper
{
    public class LightNovelPubScrapper
    {
        public string url = "https://www.lightnovelpub.com/genre/all/popular/all/1";


        public List<Novel> GetNovels()
        {
            
            var web = new HtmlWeb();
            List<Novel> Novels = new List<Novel>();

            HtmlNode nextButton = null;
            var index = 1;
            var count = 0;
            do
            {
                var document = web.Load(url);
                var nodes = document.DocumentNode.SelectNodes("/html/body/main/article/ul/li");
                foreach (var node in nodes)
                {
                    var novel = new Novel
                    {
                        title = node.SelectSingleNode("div[2]/h4").InnerText.Trim().Replace("&#x27;", "'"),
                        rating = node.SelectSingleNode("div[2]/div[1]/div/p/strong").InnerText,
                        chapters = node.SelectSingleNode("div[2]/div[2]/span[2]").InnerText.Trim(),
                        status = node.SelectSingleNode("div[2]/div[4]").InnerText.Trim(),
                    };
                    count++;
                    Novels.Add(novel);
                }
                nextButton = document.DocumentNode.SelectSingleNode("/html/body/main/article/nav[2]/div/ul/li[6]/a");
                url = url.Replace(Convert.ToString(index), Convert.ToString(index + 1));
                index++;
            }while (nextButton != null);


            return Novels;

           /* foreach(var novel in Novels)
            {
                Console.WriteLine(novel.title);
                Console.WriteLine(novel.rating);
                Console.WriteLine(novel.chapters);
                Console.WriteLine(novel.status);
                Console.WriteLine("-----------");
            }
            Console.WriteLine(count);*/

        }
    }
}
